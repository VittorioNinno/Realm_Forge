using System.Net;
using System.Text.Json;
using RealmForge.Api.Email;

namespace RealmForge.Tests;

public class BrevoEmailClientTests
{
	//	Generated at runtime: a literal that looks like a key is flagged by secret scanners
	private static readonly string Key = "test-" + Guid.NewGuid().ToString("N");

	private static EmailOptions Options() => new()
	{
		BrevoApiKey = Key,
		BrevoApiUrl = "https://brevo.test/v3/smtp/email",
		FromAddress = "sender@realmforge.example",
		FromName = "RealmForge"
	};

	[Fact]
	public void Brevo_takes_precedence_over_smtp()
	{
		var options = Options();
		options.Host = "smtp.example.com";
		options.Username = "user@example.com";

		Assert.True(options.IsConfigured);
		Assert.True(options.UsesBrevo);
		Assert.False(options.UsesSmtp);
		Assert.False(new EmailOptions().IsConfigured);
	}

	[Fact]
	public async Task Posts_the_message_with_the_api_key()
	{
		var handler = new RecordingHandler(HttpStatusCode.Created);
		var client = new BrevoEmailClient(new HttpClient(handler), Microsoft.Extensions.Options.Options.Create(Options()));

		await client.SendAsync("player@example.com", "Subject", "<p>Html</p>", "Text");

		Assert.Equal(HttpMethod.Post, handler.Method);
		Assert.Equal("https://brevo.test/v3/smtp/email", handler.Uri?.ToString());
		Assert.Equal(Key, handler.ApiKey);

		using var json = JsonDocument.Parse(handler.Body!);
		var root = json.RootElement;
		Assert.Equal("sender@realmforge.example", root.GetProperty("sender").GetProperty("email").GetString());
		Assert.Equal("RealmForge", root.GetProperty("sender").GetProperty("name").GetString());
		Assert.Equal("player@example.com", root.GetProperty("to")[0].GetProperty("email").GetString());
		Assert.False(root.GetProperty("to")[0].TryGetProperty("name", out _));
		Assert.Equal("Subject", root.GetProperty("subject").GetString());
		Assert.Equal("<p>Html</p>", root.GetProperty("htmlContent").GetString());
		Assert.Equal("Text", root.GetProperty("textContent").GetString());
	}

	[Fact]
	public async Task A_refusal_reports_brevo_answer()
	{
		var handler = new RecordingHandler(HttpStatusCode.Unauthorized, "{\"code\":\"unauthorized\",\"message\":\"Key not found\"}");
		var client = new BrevoEmailClient(new HttpClient(handler), Microsoft.Extensions.Options.Options.Create(Options()));

		var error = await Assert.ThrowsAsync<HttpRequestException>(() => client.SendAsync("player@example.com", "S", "H", "T"));

		Assert.Equal(HttpStatusCode.Unauthorized, error.StatusCode);
		Assert.Contains("Key not found", error.Message);
	}

	private sealed class RecordingHandler(HttpStatusCode status, string answer = "{\"messageId\":\"<1@test>\"}") : HttpMessageHandler
	{
		public HttpMethod? Method { get; private set; }
		public Uri? Uri { get; private set; }
		public string? ApiKey { get; private set; }
		public string? Body { get; private set; }

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Method = request.Method;
			Uri = request.RequestUri;
			ApiKey = request.Headers.TryGetValues("api-key", out var values) ? values.Single() : null;
			Body = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
			return new HttpResponseMessage(status) { Content = new StringContent(answer) };
		}
	}
}
