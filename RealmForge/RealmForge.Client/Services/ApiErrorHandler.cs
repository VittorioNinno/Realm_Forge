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
				case HttpStatusCode.Forbidden:
				case HttpStatusCode.Unauthorized:
					_state.Report(ApiErrorKind.Forbidden);
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
