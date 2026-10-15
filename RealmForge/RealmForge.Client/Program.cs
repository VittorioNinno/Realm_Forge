using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealmForge.Client;
using Microsoft.AspNetCore.Components.Authorization;
using RealmForge.Client.Services;

namespace RealmForge.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			//	API base URL comes from wwwroot/appsettings*.json, falling back to the client's own origin (hosted deployment)
			var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress;

			//	Failed API calls are reported to ApiErrorState and shown by the layout banner
			//	Pipeline: ApiErrorHandler (reports final failures) -> AuthHeaderHandler (bearer token + refresh) -> network
			builder.Services.AddScoped<ApiErrorState>();
			builder.Services.AddScoped<TokenStore>();
			builder.Services.AddScoped(sp => new HttpClient(new ApiErrorHandler(sp.GetRequiredService<ApiErrorState>())
			{
				InnerHandler = new AuthHeaderHandler(sp.GetRequiredService<TokenStore>())
				{
					InnerHandler = new HttpClientHandler()
				}
			})
			{
				BaseAddress = new Uri(apiBaseUrl)
			});

			//	Authentication state for AuthorizeView and the account page
			builder.Services.AddAuthorizationCore();
			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddScoped<AuthService>();
			builder.Services.AddScoped<TokenAuthenticationStateProvider>();
			builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<TokenAuthenticationStateProvider>());

			//	API data management service
			builder.Services.AddScoped<SpeciesDataService>();
			builder.Services.AddScoped<SubspeciesDataService>();
			builder.Services.AddScoped<FeatDataService>();

			//	UI language state management service
			builder.Services.AddSingleton<LanguageStateService>();

			var host = builder.Build();

			//	Restore the saved UI language before the first render (no flash of the default language)
			await host.Services.GetRequiredService<LanguageStateService>().InitializeAsync();

			await host.RunAsync();
		}
	}
}