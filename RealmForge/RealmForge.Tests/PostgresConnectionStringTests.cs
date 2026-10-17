using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Tests;

public class PostgresConnectionStringTests
{
	//	Values are generated per run: no credential-like literal is committed (secret scanners flag them even in tests)
	private static readonly string User = $"user_{Guid.NewGuid():N}"[..12];
	private static readonly string Secret = $"{Guid.NewGuid():N}@:x";

	[Fact]
	public void Neon_url_becomes_an_npgsql_connection_string()
	{
		var host = "ep-sample-123456.eu-central-1.aws.neon.tech";
		var url = $"postgresql://{User}:{Uri.EscapeDataString(Secret)}@{host}/realmforge?sslmode=require&channel_binding=require";

		Assert.Equal($"Host={host};Port=5432;Database=realmforge;Username={User};Password={Secret};SSL Mode=require;Channel Binding=require",
			PostgresConnectionString.Normalize(url));
	}

	[Fact]
	public void Explicit_port_and_postgres_scheme_are_kept()
	{
		var url = $"postgres://{User}:{Uri.EscapeDataString(Secret)}@db.example:6543/rf";

		Assert.Equal($"Host=db.example;Port=6543;Database=rf;Username={User};Password={Secret}", PostgresConnectionString.Normalize(url));
	}

	[Fact]
	public void Npgsql_strings_are_returned_unchanged()
	{
		var value = $"Host=localhost;Port=5432;Database=realm_forge_db;Username={User}";
		Assert.Equal(value, PostgresConnectionString.Normalize(value));
	}
}
