using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the official SRD backgrounds with the database (same rules as FeatSeeder):
///	missing backgrounds are inserted, existing SRD backgrounds are updated, Homebrew is never touched.
///	One file per background in the BackgroundsData folder, exposing <c>public static Background Build()</c>,
///	with ids from DeterministicGuid (e.g. ForSrd(Dnd5e_2024, "background", "acolyte")).
///	</summary>
public static class BackgroundSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData";

	public static IReadOnlyList<Background> GetDefinitions()
	{
		var definitions = typeof(BackgroundSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(Background))
			.Select(m => (Background)m!.Invoke(null, null)!)
			.ToList();

		EnsureUniqueIds(definitions);
		return definitions;
	}

	public static void EnsureUniqueIds(IEnumerable<Background> definitions)
	{
		var ids = definitions.SelectMany(b => b.Translations.Select(t => t.Id).Prepend(b.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in background seed data: [{string.Join(", ", duplicates)}]");
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
		var existing = await context.Backgrounds
			.Include(b => b.Translations)
			.Where(b => ids.Contains(b.Id))
			.ToDictionaryAsync(b => b.Id, cancellationToken);

		foreach (var definition in definitions)
		{
			if (!existing.TryGetValue(definition.Id, out var background))
			{
				context.Backgrounds.Add(definition);
				continue;
			}

			if (!background.IsOfficialSRD)
			{
				continue;
			}

			background.Ruleset = definition.Ruleset;
			background.AbilityOptions = definition.AbilityOptions;
			background.SkillProficiencies = definition.SkillProficiencies;
			background.OriginFeatId = definition.OriginFeatId;

			foreach (var source in definition.Translations)
			{
				var target = background.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.BackgroundTranslations.Add(new BackgroundTranslation
					{
						Id = source.Id,
						BackgroundId = background.Id,
						Language = source.Language
					});
					target = context.BackgroundTranslations.Local.First(t => t.Id == source.Id);
				}

				target.Name = source.Name;
				target.Description = source.Description;
				target.ToolProficiencies = source.ToolProficiencies;
				target.Languages = source.Languages;
				target.Equipment = source.Equipment;
				target.OriginFeatNote = source.OriginFeatNote;
				target.FeatureName = source.FeatureName;
				target.FeatureDescription = source.FeatureDescription;
				target.CharacteristicsIntro = source.CharacteristicsIntro;
				target.PersonalityTraits = source.PersonalityTraits;
				target.Ideals = source.Ideals;
				target.Bonds = source.Bonds;
				target.Flaws = source.Flaws;
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}
