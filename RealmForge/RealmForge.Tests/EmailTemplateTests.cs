using RealmForge.Api.Email;

namespace RealmForge.Tests;

public class EmailTemplateTests
{
	private static readonly EmailTemplate.Section It = new("Conferma il tuo indirizzo email", "Testo <italiano>", "Conferma email");
	private static readonly EmailTemplate.Section En = new("Confirm your e-mail address", "English text", "Confirm e-mail");

	[Fact]
	public void Action_email_has_logo_buttons_and_encoded_link()
	{
		var html = EmailTemplate.ActionEmail("preview", It, En, "https://localhost:7171/confirm-email?userId=1&code=a+b");

		Assert.Contains($"cid:{EmailTemplate.LogoCidPlaceholder}", html);
		Assert.Contains("https://localhost:7171/confirm-email?userId=1&amp;code=a+b", html);
		Assert.Contains(">Conferma email</a>", html);
		Assert.Contains(">Confirm e-mail</a>", html);

		//	User-facing texts are HTML-encoded
		Assert.Contains("Testo &lt;italiano&gt;", html);
		Assert.DoesNotContain("<italiano>", html);
	}

	[Fact]
	public void Plain_text_alternative_contains_both_languages_and_the_link()
	{
		var text = EmailTemplate.PlainText(It, En, "https://example.test/x");

		Assert.Contains("Conferma il tuo indirizzo email", text);
		Assert.Contains("Confirm your e-mail address", text);
		Assert.Equal(2, text.Split("https://example.test/x").Length - 1);
	}

	[Fact]
	public void Logo_is_embedded_in_the_api_assembly()
	{
		using var stream = typeof(IdentityEmailSender).Assembly.GetManifestResourceStream("RealmForge.Api.Email.Assets.logo.jpg");

		Assert.NotNull(stream);
		Assert.True(stream!.Length > 1000);
	}
}
