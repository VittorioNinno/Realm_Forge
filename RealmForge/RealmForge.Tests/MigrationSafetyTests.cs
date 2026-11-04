using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Tests;

///	<summary>
///	The hosted database already has rows: a migration that adds a required column without a default fails there (the
///	API applies the migrations at startup and does not start). The tests in CI run on an empty database, which hides it.
///	</summary>
public class MigrationSafetyTests
{
	//	The first migrations checked: the older ones were applied long ago
	private const string Since = "20261103200706";

	[Fact]
	public void Required_columns_added_to_existing_tables_have_a_default()
	{
		var missing = typeof(RealmForgeDbContext).Assembly.GetTypes()
			.Where(t => t.IsSubclassOf(typeof(Migration)) && !t.IsAbstract)
			.Select(t => (Type: t, Id: t.GetCustomAttribute<MigrationAttribute>()?.Id ?? string.Empty))
			.Where(m => string.CompareOrdinal(m.Id, Since) >= 0)
			.SelectMany(m => ((Migration)Activator.CreateInstance(m.Type)!).UpOperations
				.OfType<AddColumnOperation>()
				.Where(c => !c.IsNullable && c.DefaultValue is null && c.DefaultValueSql is null && c.ComputedColumnSql is null)
				.Select(c => $"{m.Id}: {c.Table}.{c.Name}"))
			.ToList();
		Assert.True(missing.Count == 0, "Required columns without a default: " + string.Join(", ", missing));
	}
}
