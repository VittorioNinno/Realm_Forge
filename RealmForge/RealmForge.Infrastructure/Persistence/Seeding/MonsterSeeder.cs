using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the base monsters with the database (same rules as MagicItemSeeder): missing monsters are inserted,
///	existing base monsters are updated to match their definition, Homebrew is never touched. One file per monster in
///	the MonstersData folder, exposing <c>public static Monster Build()</c>, with ids from DeterministicGuid
///	(ForSrd(Dnd5e_2014, "monster", "adult-red-dragon", "it")).
///	</summary>
public static class MonsterSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.MonstersData";

	public static IReadOnlyList<Monster> GetDefinitions()
	{
		var definitions = typeof(MonsterSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(Monster))
			.Select(m => (Monster)m!.Invoke(null, null)!)
			.ToList();

		var ids = definitions.SelectMany(s => s.Translations.Select(t => t.Id).Prepend(s.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in monster seed data: [{string.Join(", ", duplicates)}]");
		}
		return definitions;
	}

	///	<summary>
	///	Texts of a statblock in one language, in the order of the statblock.
	///	</summary>
	public sealed record Text(
		string Name, string? Alias, string Subtitle, string ArmorClass, string Speed, string SavingThrows, string Skills,
		string DamageVulnerabilities, string DamageResistances, string DamageImmunities, string ConditionImmunities,
		string Senses, string Languages, string Traits, string Actions, string BonusActions, string Reactions, string LegendaryActions,
		string Description);

	///	<summary>
	///	A base monster of the 2014 rules, with its Italian and English texts: SRD 5.1 statblocks, and the Monster Manual
	///	ones outside the SRD with texts written for RealmForge. Abilities: Str, Dex, Con, Int, Wis, Cha; speed in feet;
	///	variantOf is the key of the statblock it varies (a swarm of insects, a giant rat, a cave bear).
	///	</summary>
	public static Monster Create(
		string key, string? variantOf, ContentSource source, CreatureSize size, CreatureType type, int armorClass, int hitPoints, string hitDice, int speed,
		int[] abilities, decimal challenge, int xp, int proficiency, int passivePerception, Text it, Text en)
	{
		var ruleset = RulesetVersion.Dnd5e_2014;
		return new Monster
		{
			Id = DeterministicGuid.ForSrd(ruleset, "monster", key),
			Ruleset = ruleset,
			IsOfficialSRD = true,
			Source = source,
			Size = size,
			Type = type,
			ArmorClass = armorClass,
			HitPoints = hitPoints,
			HitDice = hitDice,
			Speed = speed,
			Strength = abilities[0],
			Dexterity = abilities[1],
			Constitution = abilities[2],
			Intelligence = abilities[3],
			Wisdom = abilities[4],
			Charisma = abilities[5],
			ChallengeRating = challenge,
			Xp = xp,
			ProficiencyBonus = proficiency,
			PassivePerception = passivePerception,
			VariantOfId = variantOf is null ? null : DeterministicGuid.ForSrd(ruleset, "monster", variantOf),
			Translations = new List<MonsterTranslation>
			{
				Translation(DeterministicGuid.ForSrd(ruleset, "monster", key, "it"), LanguageCode.It, it),
				Translation(DeterministicGuid.ForSrd(ruleset, "monster", key, "en"), LanguageCode.En, en)
			}
		};
	}

	private static MonsterTranslation Translation(Guid id, LanguageCode language, Text t)
	{
		var tr = new MonsterTranslation { Id = id, Language = language };
		Apply(tr, t);
		return tr;
	}

	private static void Apply(MonsterTranslation tr, Text t)
	{
		tr.Name = t.Name;
		tr.Alias = t.Alias;
		tr.Subtitle = t.Subtitle;
		tr.ArmorClass = t.ArmorClass;
		tr.Speed = t.Speed;
		tr.SavingThrows = t.SavingThrows;
		tr.Skills = t.Skills;
		tr.DamageVulnerabilities = t.DamageVulnerabilities;
		tr.DamageResistances = t.DamageResistances;
		tr.DamageImmunities = t.DamageImmunities;
		tr.ConditionImmunities = t.ConditionImmunities;
		tr.Senses = t.Senses;
		tr.Languages = t.Languages;
		tr.Traits = t.Traits;
		tr.Actions = t.Actions;
		tr.BonusActions = t.BonusActions;
		tr.Reactions = t.Reactions;
		tr.LegendaryActions = t.LegendaryActions;
		tr.Description = t.Description;
	}

	private static void Copy(MonsterTranslation target, MonsterTranslation source)
	{
		target.Name = source.Name;
		target.Alias = source.Alias;
		target.Subtitle = source.Subtitle;
		target.ArmorClass = source.ArmorClass;
		target.Speed = source.Speed;
		target.SavingThrows = source.SavingThrows;
		target.Skills = source.Skills;
		target.DamageVulnerabilities = source.DamageVulnerabilities;
		target.DamageResistances = source.DamageResistances;
		target.DamageImmunities = source.DamageImmunities;
		target.ConditionImmunities = source.ConditionImmunities;
		target.Senses = source.Senses;
		target.Languages = source.Languages;
		target.Traits = source.Traits;
		target.Actions = source.Actions;
		target.BonusActions = source.BonusActions;
		target.Reactions = source.Reactions;
		target.LegendaryActions = source.LegendaryActions;
		target.Description = source.Description;
	}

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var definitions = GetDefinitions();
		if (definitions.Count == 0)
		{
			return;
		}

		var ids = definitions.Select(d => d.Id).ToList();
		var existing = await context.Monsters
			.Include(s => s.Translations)
			.Where(s => ids.Contains(s.Id))
			.AsSplitQuery()
			.ToDictionaryAsync(s => s.Id, cancellationToken);

		//	Originals first, so that the variants find them
		foreach (var definition in definitions.OrderBy(d => d.VariantOfId is null ? 0 : 1))
		{
			if (!existing.TryGetValue(definition.Id, out var monster))
			{
				context.Monsters.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!monster.IsOfficialSRD)
			{
				continue;
			}

			monster.Ruleset = definition.Ruleset;
			monster.Source = definition.Source;
			monster.Size = definition.Size;
			monster.Type = definition.Type;
			monster.ArmorClass = definition.ArmorClass;
			monster.HitPoints = definition.HitPoints;
			monster.HitDice = definition.HitDice;
			monster.Speed = definition.Speed;
			monster.Strength = definition.Strength;
			monster.Dexterity = definition.Dexterity;
			monster.Constitution = definition.Constitution;
			monster.Intelligence = definition.Intelligence;
			monster.Wisdom = definition.Wisdom;
			monster.Charisma = definition.Charisma;
			monster.ChallengeRating = definition.ChallengeRating;
			monster.Xp = definition.Xp;
			monster.ProficiencyBonus = definition.ProficiencyBonus;
			monster.PassivePerception = definition.PassivePerception;
			monster.VariantOfId = definition.VariantOfId;

			foreach (var source in definition.Translations)
			{
				var target = monster.Translations.FirstOrDefault(t => t.Language == source.Language);
				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.MonsterTranslations.Add(new MonsterTranslation { Id = source.Id, MonsterId = monster.Id, Language = source.Language });
					target = context.MonsterTranslations.Local.First(t => t.Id == source.Id);
				}
				Copy(target, source);
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}
