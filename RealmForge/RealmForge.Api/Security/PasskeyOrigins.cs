namespace RealmForge.Api.Security
{
	///	<summary>
	///	The client origins a passkey may be created or used from: the same list as CORS (Cors:AllowedOrigins), without
	///	the trailing slash a browser never sends.
	///	</summary>
	public static class PasskeyOrigins
	{
		public static string[] Allowed(IConfiguration configuration) =>
			(configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>())
				.Where(o => !string.IsNullOrWhiteSpace(o))
				.Select(o => o.Trim().TrimEnd('/'))
				.ToArray();
	}
}
