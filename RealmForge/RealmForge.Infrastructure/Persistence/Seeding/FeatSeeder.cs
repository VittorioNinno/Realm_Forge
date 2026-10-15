using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the official SRD feats with the database.
///	Missing feats are inserted; existing SRD feats are updated to match their seed definition,
///	so fixes to the seed texts reach existing databases too. Homebrew rows are never touched.
///	</summary>
public static class FeatSeeder
{
	///	<summary>
	///	Every feat definition, discovered from the static classes in the FeatsData namespace that expose
	///	<c>public static Feat Build()</c>. Adding a new seeder file is enough: it cannot be forgotten.
	///	</summary>
	public static IReadOnlyList<Feat> GetDefinitions()
	{
		var definitions = typeof(Alert2014Seeder).Assembly.GetTypes()
			.Where(t => t.Namespace == typeof(Alert2014Seeder).Namespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(Feat))
			.Select(m => (Feat)m!.Invoke(null, null)!)
			.ToList();

		EnsureUniqueIds(definitions);
		return definitions;
	}

	///	<summary>
	///	Fails fast when two definitions share a feat id or a translation id (copy-paste mistakes).
	///	</summary>
	public static void EnsureUniqueIds(IEnumerable<Feat> definitions)
	{
		var list = definitions.ToList();

		var duplicateFeatIds = list.GroupBy(f => f.Id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
		var duplicateTranslationIds = list.SelectMany(f => f.Translations).GroupBy(t => t.Id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

		if (duplicateFeatIds.Count > 0 || duplicateTranslationIds.Count > 0)
		{
			throw new InvalidOperationException(
				$"Duplicate ids in feat seed data. Feats: [{string.Join(", ", duplicateFeatIds)}] Translations: [{string.Join(", ", duplicateTranslationIds)}]");
		}
	}

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var definitions = GetDefinitions();
		var ids = definitions.Select(d => d.Id).ToList();

		//	One query for all existing seeded feats instead of one round-trip per feat
		var existing = await context.Feats
			.Include(f => f.Translations)
			.Where(f => ids.Contains(f.Id))
			.ToDictionaryAsync(f => f.Id, cancellationToken);

		foreach (var definition in definitions)
		{
			if (!existing.TryGetValue(definition.Id, out var feat))
			{
				context.Feats.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!feat.IsOfficialSRD)
			{
				continue;
			}

			feat.Category = definition.Category;
			feat.Ruleset = definition.Ruleset;
			feat.PrerequisiteMinimumLevel = definition.PrerequisiteMinimumLevel;
			feat.PrerequisiteAbilities = definition.PrerequisiteAbilities;
			feat.PrerequisiteMinimumScore = definition.PrerequisiteMinimumScore;
			feat.PrerequisiteFeature = definition.PrerequisiteFeature;

			foreach (var source in definition.Translations)
			{
				var target = feat.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	Added through the context: a new child with a preset Guid key, discovered only via the collection,
					//	would be taken by EF for an existing row (UPDATE affecting 0 rows)
					context.FeatTranslations.Add(new FeatTranslation
					{
						Id = source.Id,
						FeatId = feat.Id,
						Language = source.Language,
						Name = source.Name,
						Description = source.Description,
						PrerequisiteNote = source.PrerequisiteNote
					});
				}
				else
				{
					target.Name = source.Name;
					target.Description = source.Description;
					target.PrerequisiteNote = source.PrerequisiteNote;
				}
			}
		}

		//	Single transaction: either the whole SRD set is synchronized or nothing changes
		await context.SaveChangesAsync(cancellationToken);
	}
}
