using System.Net;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	HttpClient pipeline step that reports failed API calls to <see cref="ApiErrorState"/>.
	///	Services keep their current behavior; the user simply gets a visible message.
	///	</summary>
	public class ApiErrorHandler : DelegatingHandler
	{
		private readonly ApiErrorState _state;

		public ApiErrorHandler(ApiErrorState state)
		{
			_state = state;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			//	Login/registration report their own errors in the account page
			if (request.RequestUri?.AbsolutePath.Contains("/api/auth/") == true)
			{
				return await base.SendAsync(request, cancellationToken);
			}

			HttpResponseMessage response;

			try
			{
				response = await base.SendAsync(request, cancellationToken);
			}
			catch (HttpRequestException)
			{
				_state.Report(ApiErrorKind.Unreachable);
				throw;
			}

			switch (response.StatusCode)
			{
				case HttpStatusCode.Unauthorized:
					_state.Report(ApiErrorKind.Unauthorized);
					break;
				case HttpStatusCode.Forbidden:
					//	The API marks the "e-mail not confirmed" case with a header, to tell it apart from ownership errors
					var emailNotConfirmed = response.Headers.TryGetValues("X-RealmForge-Error", out var codes) && codes.Contains("EmailNotConfirmed");
					_state.Report(emailNotConfirmed ? ApiErrorKind.EmailNotConfirmed : ApiErrorKind.Forbidden);
					break;
				case HttpStatusCode.BadRequest:
				case HttpStatusCode.Conflict:
					_state.Report(ApiErrorKind.Validation);
					break;
				case >= HttpStatusCode.InternalServerError:
					_state.Report(ApiErrorKind.Server);
					break;
			}

			return response;
		}
	}
}
