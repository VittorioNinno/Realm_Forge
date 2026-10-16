namespace RealmForge.Api.Email
{
	///	<summary>
	///	SMTP settings ("Email" section). Keep the password in user-secrets, never in appsettings.
	///	When Host is empty no e-mail is sent and the links are written to the API log instead.
	///	</summary>
	public class EmailOptions
	{
		public string? Host { get; set; }
		public int Port { get; set; } = 587;
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? FromAddress { get; set; }
		public string FromName { get; set; } = "RealmForge";

		//	Client address used in e-mail links when the request does not come from an allowed client origin
		public string? ClientBaseUrl { get; set; }

		public bool IsConfigured => !string.IsNullOrWhiteSpace(Host) && !string.IsNullOrWhiteSpace(Username);
	}
}
