using System.Net.Http.Json;
using System.Text.Json;

namespace RealmForge.Client.Services
{
	public record AuthResult(bool Success, IReadOnlyList<string> Errors)
	{
		public static AuthResult Ok() => new(true, Array.Empty<string>());
		public static AuthResult Fail(params string[] errors) => new(false, errors);
	}

	///	<summary>
	///	Login, registration and logout against the ASP.NET Core Identity endpoints (/api/auth/*).
	///	</summary>
	public class AuthService
	{
		private readonly HttpClient _http;
		private readonly TokenStore _tokens;

		public AuthService(HttpClient http, TokenStore tokens)
		{
			_http = http;
			_tokens = tokens;
		}

		public async Task<AuthResult> LoginAsync(string email, string password)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/login", new { email, password });
				if (!response.IsSuccessStatusCode)
				{
					return AuthResult.Fail("InvalidCredentials");
				}

				var body = await response.Content.ReadFromJsonAsync<AccessTokenResponse>();
				if (body is null)
				{
					return AuthResult.Fail("InvalidCredentials");
				}

				await _tokens.SetAsync(body.ToTokens());
				return AuthResult.Ok();
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		public async Task<AuthResult> RegisterAsync(string email, string password)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/register", new { email, password });
				if (response.IsSuccessStatusCode)
				{
					return await LoginAsync(email, password);
				}

				return AuthResult.Fail(await ReadIdentityErrorsAsync(response));
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		public Task LogoutAsync() => _tokens.ClearAsync();

		///	<summary>
		///	Returns the email of the logged-in user, or null when there is no valid session.
		///	</summary>
		public async Task<string?> GetCurrentEmailAsync()
		{
			if (await _tokens.GetAsync() is null)
			{
				return null;
			}

			try
			{
				var response = await _http.GetAsync("api/auth/manage/info");
				if (!response.IsSuccessStatusCode)
				{
					return null;
				}

				var info = await response.Content.ReadFromJsonAsync<JsonElement>();
				return info.TryGetProperty("email", out var email) ? email.GetString() : null;
			}
			catch (HttpRequestException)
			{
				return null;
			}
		}

		//	Identity returns { "errors": { "PasswordTooShort": ["..."], "DuplicateUserName": ["..."] } }
		private static async Task<string[]> ReadIdentityErrorsAsync(HttpResponseMessage response)
		{
			try
			{
				var problem = await response.Content.ReadFromJsonAsync<JsonElement>();
				if (problem.TryGetProperty("errors", out var errors) && errors.ValueKind == JsonValueKind.Object)
				{
					return errors.EnumerateObject().Select(e => e.Name).ToArray();
				}
			}
			catch (JsonException)
			{
			}

			return new[] { "Unknown" };
		}
	}
}
