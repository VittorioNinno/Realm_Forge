using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence.Seeding;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Identity;
using RealmForge.Api.Email;

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
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<RealmForgeDbContext>(options =>
				options.UseNpgsql(connectionString ?? string.Empty));

			//	Accounts: ASP.NET Core Identity with bearer tokens (endpoints mapped under /api/auth)
			builder.Services.AddAuthorization();
			builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
				{
					options.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<RealmForgeDbContext>();

			//	Ownership rules for SRD and Homebrew content
			builder.Services.AddSingleton<ContentAccess>();

			//	E-mails for account confirmation and password reset (SMTP settings in the "Email" section / user-secrets)
			builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("Email"));
			builder.Services.AddHttpContextAccessor();
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
			var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

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
			if (email.IsConfigured)
			{
				startupLogger.LogInformation("E-mail: SMTP {Host}:{Port} as {Username}, sender {From}, password {PasswordState}",
					email.Host, email.Port, email.Username, email.FromAddress ?? email.Username, string.IsNullOrWhiteSpace(email.Password) ? "MISSING" : "set");
			}
			else
			{
				startupLogger.LogWarning("E-mail: SMTP not configured, confirmation links are written to this log");
			}

			//	Checked after Build() so that design-time tools (dotnet ef migrations add) keep working without a database
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new InvalidOperationException(
					"Missing connection string 'DefaultConnection'. For local development run, from the RealmForge.Api folder:\n" +
					"dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"Host=localhost;Port=5432;Database=realm_forge_db;Username=postgres;Password=<your password>\"");
			}

			//	Configure the HTTP request pipeline
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

			//	Apply pending migrations (development only) and synchronize the SRD data
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<RealmForgeDbContext>();
				var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

				if (app.Environment.IsDevelopment())
				{
					await dbContext.Database.MigrateAsync();
				}

				await DatabaseSeeder.SeedAsync(dbContext, logger);
			}

			await app.RunAsync();
		}
	}
}