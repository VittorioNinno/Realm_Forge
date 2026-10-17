using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

namespace RealmForge.Api.Email
{
	///	<summary>
	///	Sends e-mails through the Brevo transactional API over HTTPS (POST /v3/smtp/email, header "api-key").
	///	Used where outbound SMTP ports are blocked, as on Render's free plan.
	///	</summary>
	public class BrevoEmailClient
	{
		private readonly HttpClient _http;
		private readonly EmailOptions _options;

		public BrevoEmailClient(HttpClient http, IOptions<EmailOptions> options)
		{
			_http = http;
			_options = options.Value;
		}

		///	<summary>
		///	Request body of the Brevo API for one recipient.
		///	</summary>
		public static BrevoMessage BuildMessage(EmailOptions options, string to, string subject, string html, string text) =>
			new(new BrevoAddress(options.SenderAddress ?? string.Empty, options.FromName),
				new[] { new BrevoAddress(to, null) },
				subject, html, text);

		///	<summary>
		///	Sends the message; throws <see cref="HttpRequestException"/> with Brevo's answer when it is refused.
		///	</summary>
		public async Task SendAsync(string to, string subject, string html, string text, CancellationToken cancellationToken = default)
		{
			using var request = new HttpRequestMessage(HttpMethod.Post, _options.BrevoApiUrl)
			{
				Content = JsonContent.Create(BuildMessage(_options, to, subject, html, text))
			};
			request.Headers.Add("api-key", _options.BrevoApiKey);
			request.Headers.Accept.ParseAdd("application/json");

			using var response = await _http.SendAsync(request, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				//	Brevo explains the refusal in the body, e.g. {"code":"unauthorized","message":"Key not found"}
				var body = await response.Content.ReadAsStringAsync(cancellationToken);
				throw new HttpRequestException($"Brevo answered {(int)response.StatusCode}: {body}", null, response.StatusCode);
			}
		}
	}

	public record BrevoAddress(
		[property: JsonPropertyName("email")] string Email,
		[property: JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? Name);

	public record BrevoMessage(
		[property: JsonPropertyName("sender")] BrevoAddress Sender,
		[property: JsonPropertyName("to")] IReadOnlyList<BrevoAddress> To,
		[property: JsonPropertyName("subject")] string Subject,
		[property: JsonPropertyName("htmlContent")] string HtmlContent,
		[property: JsonPropertyName("textContent")] string TextContent);
}
