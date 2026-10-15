using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Adds the bearer token to every API call. On 401 it tries once to refresh the token
	///	and repeats the request; if the refresh fails the session is closed.
	///	</summary>
	public class AuthHeaderHandler : DelegatingHandler
	{
		private readonly TokenStore _tokens;

		public AuthHeaderHandler(TokenStore tokens)
		{
			_tokens = tokens;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			//	Identity endpoints that issue tokens must not carry (or refresh) an old one
			var path = request.RequestUri?.AbsolutePath ?? string.Empty;
			if (path.EndsWith("/api/auth/login") || path.EndsWith("/api/auth/register") || path.EndsWith("/api/auth/refresh"))
			{
				return await base.SendAsync(request, cancellationToken);
			}

			var tokens = await _tokens.GetAsync();
			if (tokens is null)
			{
				return await base.SendAsync(request, cancellationToken);
			}

			//	Buffer the body so the request can be sent again after a refresh
			if (request.Content != null)
			{
				await request.Content.LoadIntoBufferAsync();
			}

			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
			var response = await base.SendAsync(request, cancellationToken);

			if (response.StatusCode != HttpStatusCode.Unauthorized)
			{
				return response;
			}

			var refreshed = await TryRefreshAsync(request.RequestUri!, tokens.RefreshToken, cancellationToken);
			if (refreshed is null)
			{
				await _tokens.ClearAsync();
				return response;
			}

			response.Dispose();
			var retry = await CloneAsync(request);
			retry.Headers.Authorization = new AuthenticationHeaderValue("Bearer", refreshed.AccessToken);
			return await base.SendAsync(retry, cancellationToken);
		}

		private async Task<AuthTokens?> TryRefreshAsync(Uri requestUri, string refreshToken, CancellationToken cancellationToken)
		{
			try
			{
				var refreshUri = new Uri(requestUri, "/api/auth/refresh");
				using var refreshRequest = new HttpRequestMessage(HttpMethod.Post, refreshUri)
				{
					Content = JsonContent.Create(new { refreshToken })
				};

				using var refreshResponse = await base.SendAsync(refreshRequest, cancellationToken);
				if (!refreshResponse.IsSuccessStatusCode)
				{
					return null;
				}

				var body = await refreshResponse.Content.ReadFromJsonAsync<AccessTokenResponse>(cancellationToken: cancellationToken);
				if (body is null)
				{
					return null;
				}

				var tokens = body.ToTokens();
				await _tokens.SetAsync(tokens);
				return tokens;
			}
			catch
			{
				return null;
			}
		}

		private static async Task<HttpRequestMessage> CloneAsync(HttpRequestMessage original)
		{
			var clone = new HttpRequestMessage(original.Method, original.RequestUri);

			if (original.Content != null)
			{
				var bytes = await original.Content.ReadAsByteArrayAsync();
				clone.Content = new ByteArrayContent(bytes);
				foreach (var header in original.Content.Headers)
				{
					clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
				}
			}

			foreach (var header in original.Headers)
			{
				clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
			}

			return clone;
		}
	}

	///	<summary>
	///	Shape of the token response returned by ASP.NET Core Identity (/login and /refresh).
	///	</summary>
	public record AccessTokenResponse(string TokenType, string AccessToken, long ExpiresIn, string RefreshToken)
	{
		public AuthTokens ToTokens() => new(AccessToken, RefreshToken, DateTimeOffset.UtcNow.AddSeconds(ExpiresIn));
	}
}
