using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the rules glossary with the database (same rules as EquipmentSeeder): missing entries are inserted,
///	existing base entries are updated to match their definition, Homebrew is never touched.
///	One file per family and edition in the RulesGlossaryData folder, exposing <c>public static IEnumerable&lt;RuleEntry&gt; Build()</c>.
///	</summary>
public static class RulesGlossarySeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.RulesGlossaryData";

	public static IReadOnlyList<RuleEntry> GetDefinitions()
	{
		var definitions = typeof(RulesGlossarySeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.OrderBy(t => t.Name, StringComparer.Ordinal)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && typeof(IEnumerable<RuleEntry>).IsAssignableFrom(m.ReturnType))
			.SelectMany(m => (IEnumerable<RuleEntry>)m!.Invoke(null, null)!)
			.ToList();

		foreach (var definition in definitions)
		{
			definition.IsOfficialSRD = true;
			definition.Source ??= ContentSource.RealmForge;
		}

		EnsureConsistency(definitions);
		return definitions;
	}

	///	<summary>
	///	Ids are unique, keys are unique within an edition and every "See also" key exists in the same edition.
	///	</summary>
	public static void EnsureConsistency(IReadOnlyCollection<RuleEntry> definitions)
	{
		var ids = definitions.SelectMany(e => e.Translations.Select(t => t.Id).Prepend(e.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in rules glossary seed data: [{string.Join(", ", duplicates)}]");
		}

		foreach (var edition in definitions.GroupBy(e => e.Ruleset))
		{
			var keys = edition.Select(e => e.Key).ToList();
			var duplicateKeys = keys.GroupBy(k => k).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
			if (duplicateKeys.Count > 0)
			{
				throw new InvalidOperationException($"Duplicate glossary keys in {edition.Key}: [{string.Join(", ", duplicateKeys)}]");
			}

			var missing = edition.SelectMany(e => e.RelatedKeys.Where(k => !keys.Contains(k)).Select(k => $"{e.Key} → {k}")).ToList();
			if (missing.Count > 0)
			{
				throw new InvalidOperationException($"Unknown \"See also\" keys in {edition.Key}: [{string.Join(", ", missing)}]");
			}
		}
	}

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var definitions = GetDefinitions();
		if (definitions.Count == 0)
		{
			return;
		}

		var ids = definitions.Select(d => d.Id).ToList();
		var existing = await context.RuleEntries
			.Include(e => e.Translations)
			.Where(e => ids.Contains(e.Id))
			.AsSplitQuery()
			.ToDictionaryAsync(e => e.Id, cancellationToken);

		foreach (var definition in definitions)
		{
			if (!existing.TryGetValue(definition.Id, out var entry))
			{
				context.RuleEntries.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!entry.IsOfficialSRD)
			{
				continue;
			}

			entry.Ruleset = definition.Ruleset;
			entry.Source = definition.Source;
			entry.Key = definition.Key;
			entry.Category = definition.Category;
			entry.RelatedKeys = definition.RelatedKeys.ToList();

			foreach (var source in definition.Translations)
			{
				var target = entry.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.RuleEntryTranslations.Add(new RuleEntryTranslation
					{
						Id = source.Id,
						RuleEntryId = entry.Id,
						Language = source.Language
					});
					target = context.RuleEntryTranslations.Local.First(t => t.Id == source.Id);
				}

				target.Name = source.Name;
				target.Description = source.Description;
				target.Aliases = source.Aliases.ToList();
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}
