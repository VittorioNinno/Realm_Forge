namespace RealmForge.Api.Email
{
	///	<summary>
	///	E-mail settings ("Email" section). Two ways to send, chosen automatically:
	///	- Brevo HTTP API when BrevoApiKey is set (hosting plans that block SMTP ports, e.g. Render free);
	///	- SMTP (e.g. Gmail with an app password) when Host and Username are set.
	///	Keep passwords and keys in user-secrets or in the hosting environment, never in appsettings.
	///	With neither configured no e-mail is sent and the links are written to the API log instead.
	///	</summary>
	public class EmailOptions
	{
		public string? Host { get; set; }
		public int Port { get; set; } = 587;
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? FromAddress { get; set; }
		public string FromName { get; set; } = "RealmForge";

		//	Brevo transactional e-mail API (https://developers.brevo.com); the sender address must be verified in Brevo
		public string? BrevoApiKey { get; set; }
		public string BrevoApiUrl { get; set; } = "https://api.brevo.com/v3/smtp/email";

		//	Client address used in e-mail links when the request does not come from an allowed client origin
		public string? ClientBaseUrl { get; set; }

		public bool UsesBrevo => !string.IsNullOrWhiteSpace(BrevoApiKey);

		public bool UsesSmtp => !UsesBrevo && !string.IsNullOrWhiteSpace(Host) && !string.IsNullOrWhiteSpace(Username);

		public bool IsConfigured => UsesBrevo || UsesSmtp;

		//	Sender shown to the recipient
		public string? SenderAddress => FromAddress ?? Username;
	}
}
