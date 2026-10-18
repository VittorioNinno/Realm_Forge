using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the base spells with the database (same rules as FeatSeeder): missing spells are inserted,
///	existing base spells are updated to match their definition, Homebrew is never touched.
///	One file per spell in the SpellsData folder, exposing <c>public static Spell Build()</c>,
///	with ids from DeterministicGuid (e.g. ForSrd(Dnd5e_2014, "spell", "fireball", "it")).
///	</summary>
public static class SpellSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.SpellsData";

	public static IReadOnlyList<Spell> GetDefinitions()
	{
		var definitions = typeof(SpellSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(Spell))
			.Select(m => (Spell)m!.Invoke(null, null)!)
			.ToList();

		foreach (var definition in definitions)
		{
			definition.Source ??= ContentSource.RealmForge;
		}

		EnsureUniqueIds(definitions);
		return definitions;
	}

	public static void EnsureUniqueIds(IEnumerable<Spell> definitions)
	{
		var ids = definitions.SelectMany(s => s.Translations.Select(t => t.Id).Prepend(s.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in spell seed data: [{string.Join(", ", duplicates)}]");
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
		var existing = await context.Spells
			.Include(s => s.Translations)
			.Where(s => ids.Contains(s.Id))
			.AsSplitQuery()
			.ToDictionaryAsync(s => s.Id, cancellationToken);

		foreach (var definition in definitions)
		{
			if (!existing.TryGetValue(definition.Id, out var spell))
			{
				context.Spells.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!spell.IsOfficialSRD)
			{
				continue;
			}

			spell.Ruleset = definition.Ruleset;
			spell.Source = definition.Source;
			spell.Level = definition.Level;
			spell.School = definition.School;
			spell.Classes = definition.Classes;
			spell.Ritual = definition.Ritual;
			spell.Concentration = definition.Concentration;
			spell.Verbal = definition.Verbal;
			spell.Somatic = definition.Somatic;
			spell.Material = definition.Material;

			foreach (var source in definition.Translations)
			{
				var target = spell.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.SpellTranslations.Add(new SpellTranslation
					{
						Id = source.Id,
						SpellId = spell.Id,
						Language = source.Language
					});
					target = context.SpellTranslations.Local.First(t => t.Id == source.Id);
				}

				target.Name = source.Name;
				target.Description = source.Description;
				target.HigherLevels = source.HigherLevels;
				target.CastingTime = source.CastingTime;
				target.Range = source.Range;
				target.Duration = source.Duration;
				target.MaterialComponent = source.MaterialComponent;
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}
