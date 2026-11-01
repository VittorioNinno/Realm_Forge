using System.Net.Http.Json;
using System.Text.Json;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Outcome of an account operation: on failure, Identity error codes (e.g. "PasswordTooShort") or client codes
	///	("Unreachable", "InvalidCredentials") that UiText.AuthError turns into messages.
	///	</summary>
	public record AuthResult(bool Success, IReadOnlyList<string> Errors)
	{
		public static AuthResult Ok() => new(true, Array.Empty<string>());
		public static AuthResult Fail(params string[] errors) => new(false, errors);
	}

	///	<summary>
	///	The signed-in user as returned by /api/auth/manage/info.
	///	</summary>
	public record CurrentUser(string Email, bool EmailConfirmed);

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
					return AuthResult.Fail(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests ? "TooManyRequests" : "InvalidCredentials");
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
		///	Profile and Homebrew counts of the signed-in user; null when there is no valid session.
		///	</summary>
		public async Task<AccountSummaryDto?> GetAccountSummaryAsync()
		{
			try
			{
				var response = await _http.GetAsync("api/account/summary");
				return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<AccountSummaryDto>() : null;
			}
			catch (HttpRequestException)
			{
				return null;
			}
		}

		///	<summary>
		///	Sets the public nickname (null or empty removes it): the status code tells why it failed (409: taken).
		///	</summary>
		public async Task<(bool Ok, System.Net.HttpStatusCode? Status)> SetNicknameAsync(string? nickname)
		{
			try
			{
				var response = await _http.PutAsJsonAsync("api/account/nickname", new NicknameRequestDto { Nickname = nickname });
				return (response.IsSuccessStatusCode, response.IsSuccessStatusCode ? null : response.StatusCode);
			}
			catch (HttpRequestException)
			{
				return (false, null);
			}
		}

		///	<summary>
		///	Sends a new confirmation e-mail (Identity answers 200 even for unknown addresses, so nothing leaks).
		///	</summary>
		public async Task<AuthResult> ResendConfirmationAsync(string email)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/resendConfirmationEmail", new { email });
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests ? "TooManyRequests" : "Unknown");
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	Confirms the e-mail with the userId/code pair received in the confirmation link.
		///	</summary>
		public async Task<AuthResult> ConfirmEmailAsync(string userId, string code, string? changedEmail)
		{
			var url = $"api/auth/confirmEmail?userId={Uri.EscapeDataString(userId)}&code={Uri.EscapeDataString(code)}";
			if (!string.IsNullOrWhiteSpace(changedEmail))
			{
				url += $"&changedEmail={Uri.EscapeDataString(changedEmail)}";
			}

			try
			{
				var response = await _http.GetAsync(url);
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail("InvalidConfirmationLink");
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	Changes the password through Identity's /manage/info endpoint (the current password is required).
		///	</summary>
		public async Task<AuthResult> ChangePasswordAsync(string oldPassword, string newPassword)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/manage/info", new { oldPassword, newPassword });
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(await ReadIdentityErrorsAsync(response));
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	Asks for a password reset e-mail. Identity answers 200 for unknown or unconfirmed addresses too
		///	(and sends nothing), so the page never reveals whether an account exists.
		///	</summary>
		public async Task<AuthResult> ForgotPasswordAsync(string email)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/forgotPassword", new { email });
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests ? "TooManyRequests" : "Unknown");
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	Sets a new password with the e-mail and the code received in the reset link.
		///	An expired or already used code comes back as "InvalidToken".
		///	</summary>
		public async Task<AuthResult> ResetPasswordAsync(string email, string resetCode, string newPassword)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/resetPassword", new { email, resetCode, newPassword });
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(await ReadIdentityErrorsAsync(response));
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	E-mail address and confirmation status of the signed-in user (one call to /manage/info);
		///	null when there is no valid session.
		///	</summary>
		public async Task<CurrentUser?> GetCurrentUserAsync()
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
				var email = info.TryGetProperty("email", out var e) ? e.GetString() : null;
				var confirmed = info.TryGetProperty("isEmailConfirmed", out var c) && c.GetBoolean();
				return email is null ? null : new CurrentUser(email, confirmed);
			}
			catch (HttpRequestException)
			{
				return null;
			}
		}

		///	<summary>
		///	Asks to change the e-mail address: Identity sends a confirmation link to the new address, and the address
		///	changes only when that link is opened.
		///	</summary>
		public async Task<AuthResult> ChangeEmailAsync(string newEmail)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/auth/manage/info", new { newEmail });
				return response.IsSuccessStatusCode ? AuthResult.Ok() : AuthResult.Fail(await ReadIdentityErrorsAsync(response));
			}
			catch (HttpRequestException)
			{
				return AuthResult.Fail("Unreachable");
			}
		}

		///	<summary>
		///	Deletes the account (the password confirms it) and signs out; null when it failed, with the reason.
		///	</summary>
		public async Task<(AccountDeletedDto? Result, string? Error)> DeleteAccountAsync(string password)
		{
			try
			{
				using var request = new HttpRequestMessage(HttpMethod.Delete, "api/account") { Content = JsonContent.Create(new DeleteAccountRequestDto { Password = password }) };
				var response = await _http.SendAsync(request);
				if (!response.IsSuccessStatusCode)
				{
					return (null, response.StatusCode switch
					{
						System.Net.HttpStatusCode.BadRequest => "WrongPassword",
						System.Net.HttpStatusCode.TooManyRequests => "TooManyRequests",
						_ => "Unknown"
					});
				}
				var result = await response.Content.ReadFromJsonAsync<AccountDeletedDto>();
				await _tokens.ClearAsync();
				return (result, null);
			}
			catch (HttpRequestException)
			{
				return (null, "Unreachable");
			}
		}

		//	Identity returns { "errors": { "PasswordTooShort": ["..."], "DuplicateUserName": ["..."] } }
		private static async Task<string[]> ReadIdentityErrorsAsync(HttpResponseMessage response)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
			{
				return new[] { "TooManyRequests" };
			}
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
