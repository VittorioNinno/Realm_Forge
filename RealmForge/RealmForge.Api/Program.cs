using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence.Seeding;
using Scalar.AspNetCore;

namespace RealmForge.Api
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//	Configure connection string and register DbContext (PostgreSQL)
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<RealmForgeDbContext>(options =>
				options.UseNpgsql(connectionString));

			//	Accounts: ASP.NET Core Identity with bearer tokens (endpoints mapped under /api/auth)
			builder.Services.AddAuthorization();
			builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
				{
					options.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<RealmForgeDbContext>();

			//	Ownership rules for SRD and Homebrew content
			builder.Services.AddSingleton<ContentAccess>();

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
							.AllowAnyHeader();
				});
			});

			var app = builder.Build();

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