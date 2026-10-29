using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence.Seeding;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Identity;
using RealmForge.Api.Email;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;

namespace RealmForge.Api
{
	///	<summary>
	///	API entry point: PostgreSQL, Identity with bearer tokens under /api/auth, e-mail, CORS for the Blazor client,
	///	migrations (development) and the synchronization of the Base content at startup.
	///	</summary>
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//	Configure connection string and register DbContext (PostgreSQL)
			//	The connection string is never committed: it comes from user-secrets (development)
			//	or from the ConnectionStrings__DefaultConnection environment variable (CI / production)
			//	Hosted databases (e.g. Neon) give a postgresql:// URL: it is converted to the Npgsql format
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") is { Length: > 0 } configured
				? PostgresConnectionString.Normalize(configured)
				: null;
			builder.Services.AddDbContext<RealmForgeDbContext>(options =>
				options.UseNpgsql(connectionString ?? string.Empty));

			//	Accounts: ASP.NET Core Identity with bearer tokens (endpoints mapped under /api/auth)
			builder.Services.AddAuthorization();
			builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
				{
					options.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<RealmForgeDbContext>();

			//	Keys for bearer tokens and e-mail links live in the database: a restarted or redeployed container
			//	(e.g. on a free hosting plan) keeps users signed in and the links already sent still work
			builder.Services.AddDataProtection()
				.SetApplicationName("RealmForge")
				.PersistKeysToDbContext<RealmForgeDbContext>();

			//	Behind a hosting proxy (Render, a reverse proxy) the original scheme and client IP come from X-Forwarded-* headers
			builder.Services.Configure<ForwardedHeadersOptions>(options =>
			{
				options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
				options.KnownIPNetworks.Clear();
				options.KnownProxies.Clear();
			});

			//	Liveness probe for the hosting platform (/health)
			builder.Services.AddHealthChecks();

			//	Ownership rules for SRD and Homebrew content
			builder.Services.AddSingleton<ContentAccess>();
			builder.Services.AddScoped<ShareService>();
			builder.Services.AddScoped<RealmForge.Api.Campaigns.HomebrewLookup>();
			builder.Services.AddScoped<RealmForge.Api.Campaigns.CampaignCharacterCheck>();
			builder.Services.AddScoped<RealmForge.Api.Characters.CharacterContextBuilder>();
			builder.Services.AddScoped<RealmForge.Infrastructure.Persistence.Trash.TrashBin>();
			builder.Services.AddHostedService<RealmForge.Api.Trash.TrashPurgeService>();

			//	E-mails for account confirmation and password reset (SMTP settings in the "Email" section / user-secrets)
			builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("Email"));
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddHttpClient<BrevoEmailClient>(client => client.Timeout = TimeSpan.FromSeconds(30));
			builder.Services.AddTransient<IEmailSender<ApplicationUser>, IdentityEmailSender>();

			//	Creating or editing content requires a confirmed e-mail address
			builder.Services.AddScoped<RequireConfirmedEmailFilter>();

			//	Register controllers
			builder.Services.AddControllers();

			//	RFC 7807 problem details for errors and unhandled exceptions
			builder.Services.AddProblemDetails();

			//	Configure OpenAPI / Swagger
			builder.Services.AddOpenApi();

			const string CorsPolicyName = "AllowBlazorClient";

			//	Only the configured client origins may call the API (see "Cors:AllowedOrigins" in appsettings)
			//	A browser sends the origin without a trailing slash: "https://site.dev/" in the settings would never match
			var allowedOrigins = (builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>())
				.Where(o => !string.IsNullOrWhiteSpace(o))
				.Select(o => o.Trim().TrimEnd('/'))
				.ToArray();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicyName, policy =>
				{
					policy.WithOrigins(allowedOrigins)
							.AllowAnyMethod()
							.AllowAnyHeader()
							.WithExposedHeaders(RequireConfirmedEmailFilter.ErrorHeader);
				});
			});

			var app = builder.Build();

			//	One line at startup tells which mail settings are in use (never the password)
			var email = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<EmailOptions>>().Value;
			var startupLogger = app.Services.GetRequiredService<ILogger<Program>>();
			if (email.UsesBrevo)
			{
				startupLogger.LogInformation("E-mail: Brevo API as sender {From}, key set", email.SenderAddress ?? "MISSING (set Email:FromAddress)");
			}
			else if (email.UsesSmtp)
			{
				startupLogger.LogInformation("E-mail: SMTP {Host}:{Port} as {Username}, sender {From}, password {PasswordState}",
					email.Host, email.Port, email.Username, email.SenderAddress, string.IsNullOrWhiteSpace(email.Password) ? "MISSING" : "set");
			}
			else
			{
				startupLogger.LogWarning("E-mail: not configured (neither Brevo nor SMTP), confirmation links are written to this log");
			}


			//	Checked after Build() so that design-time tools (dotnet ef migrations add) keep working without a database
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new InvalidOperationException(
					"Missing connection string 'DefaultConnection'. For local development run, from the RealmForge.Api folder:\n" +
					"dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"Host=localhost;Port=5432;Database=realm_forge_db;Username=postgres;Password=<your password>\"");
			}

			//	Configure the HTTP request pipeline
			app.UseForwardedHeaders();
			app.UseExceptionHandler();
			app.UseStatusCodePages();

			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				app.MapScalarApiReference();
			}

			app.UseHttpsRedirection();

			app.UseCors(CorsPolicyName);

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapGroup("/api/auth").WithTags("Auth").MapIdentityApi<ApplicationUser>();
			app.MapControllers();
			app.MapHealthChecks("/health");

			//	Apply pending migrations (in development, or when Database:MigrateOnStartup is true, as on the hosted API)
			//	and synchronize the Base content
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<RealmForgeDbContext>();
				var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

				if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("Database:MigrateOnStartup"))
				{
					await dbContext.Database.MigrateAsync();
				}

				await DatabaseSeeder.SeedAsync(dbContext, logger);
			}

			await app.RunAsync();
		}
	}
}