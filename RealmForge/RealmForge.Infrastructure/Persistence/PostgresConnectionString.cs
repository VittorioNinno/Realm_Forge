using System.Text;

namespace RealmForge.Infrastructure.Persistence;

///	<summary>
///	Accepts both connection string formats: the Npgsql one ("Host=...;Database=...") and the URL that hosted
///	PostgreSQL services such as Neon show ("postgresql://&lt;user&gt;:&lt;password&gt;@&lt;host&gt;/&lt;database&gt;?sslmode=require").
///	</summary>
public static class PostgresConnectionString
{
	///	<summary>
	///	Returns the Npgsql form of <paramref name="value"/>; strings already in that form are returned unchanged.
	///	</summary>
	public static string Normalize(string value)
	{
		var trimmed = value.Trim();
		if (!trimmed.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
			&& !trimmed.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
		{
			return trimmed;
		}

		var uri = new Uri(trimmed);
		var userInfo = uri.UserInfo.Split(':', 2);

		var builder = new StringBuilder()
			.Append("Host=").Append(uri.Host)
			.Append(";Port=").Append(uri.IsDefaultPort || uri.Port <= 0 ? 5432 : uri.Port)
			.Append(";Database=").Append(Uri.UnescapeDataString(uri.AbsolutePath.TrimStart('/')))
			.Append(";Username=").Append(Uri.UnescapeDataString(userInfo[0]));

		if (userInfo.Length > 1)
		{
			builder.Append(";Password=").Append(Uri.UnescapeDataString(userInfo[1]));
		}

		//	Query options of the URL with their Npgsql names; unknown options are ignored
		foreach (var pair in uri.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
		{
			var parts = pair.Split('=', 2);
			var name = parts[0].ToLowerInvariant() switch
			{
				"sslmode" => "SSL Mode",
				"channel_binding" => "Channel Binding",
				_ => null
			};

			if (name != null && parts.Length == 2)
			{
				builder.Append(';').Append(name).Append('=').Append(Uri.UnescapeDataString(parts[1]));
			}
		}

		return builder.ToString();
	}
}
