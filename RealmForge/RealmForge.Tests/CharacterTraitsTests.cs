using System.Text.RegularExpressions;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

///	<summary>
///	The mechanics that used to be only text: subclass spell tables (kept in step with the class seed data), senses,
///	resistances, weapon training, innate spells, subclass skills and capstones.
///	</summary>
public class CharacterTraitsTests
{
	private static readonly IReadOnlyDictionary<RulesetVersion, HashSet<string>> SpellKeys = SpellSeeder.GetDefinitions()
		.GroupBy(s => s.Ruleset)
		.ToDictionary(g => g.Key, g => g.Select(s => BaseContentKeys.Of(s.Id)!).ToHashSet());

	// ===== Subclass spell tables =====

	[Fact]
	public void Every_subclass_spell_is_a_Base_spell_of_its_edition()
	{
		var subclasses = ClassSeeder.GetSubclassDefinitions().Select(s => (s.Ruleset, Key: BaseContentKeys.Of(s.Id))).ToHashSet();
		foreach (var table in SubclassSpells.Tables)
		{
			Assert.Contains((table.Ruleset, (string?)table.Subclass), subclasses);
			foreach (var key in table.Rows.SelectMany(r => r.Spells))
			{
				Assert.True(SpellKeys[table.Ruleset].Contains(key), $"{table.Ruleset} {table.Subclass}: unknown spell {key}");
			}
		}
	}

	[Fact]
	public void The_subclass_spell_tables_match_the_feature_texts()
	{
		//	Every "| level | spells |" table of a subclass feature whose header names spells is in SubclassSpells
		var names = SpellSeeder.GetDefinitions()
			.ToDictionary(s => (s.Ruleset, s.Translations.Single(t => t.Language == LanguageCode.En).Name.ToLowerInvariant().Replace('’', '\'')), s => BaseContentKeys.Of(s.Id)!);
		var found = 0;
		foreach (var subclass in ClassSeeder.GetSubclassDefinitions())
		{
			var key = BaseContentKeys.Of(subclass.Id)!;
			foreach (var feature in subclass.Features)
			{
				var text = feature.Translations.Single(t => t.Language == LanguageCode.En).Description;
				var rows = Regex.Matches(text, @"^\|\s*(\d+)\D*?\s*\|\s*([^|\n]+?)\s*\|\s*$", RegexOptions.Multiline)
					.Select(m => (Level: int.Parse(m.Groups[1].Value), Spells: m.Groups[2].Value.Split(',').Select(n => n.Trim(' ', '*', '_').ToLowerInvariant().Replace('’', '\'')).ToList()))
					.Where(r => r.Spells.All(n => names.ContainsKey((subclass.Ruleset, n)) || n == "yolande's regal presence"))
					.ToList();
				if (rows.Count == 0 || !Regex.IsMatch(text, @"\|[^|\n]*Spell[^|\n]*\|\s*$", RegexOptions.Multiline))
				{
					continue;
				}
				var tables = SubclassSpells.Tables.Where(t => t.Ruleset == subclass.Ruleset && t.Subclass == key).ToList();
				Assert.True(tables.Count > 0, $"{subclass.Ruleset} {key}: spell table missing in SubclassSpells");
				var known = tables.SelectMany(t => t.Rows.SelectMany(r => r.Spells.Select(s => (r.Level, s)))).ToHashSet();
				foreach (var (level, spells) in rows)
				{
					foreach (var name in spells)
					{
						var spell = name == "yolande's regal presence" ? "regal-presence" : names[(subclass.Ruleset, name)];
						Assert.True(known.Contains((level, spell)), $"{subclass.Ruleset} {key}: {spell} at {level} missing");
						found++;
					}
				}
			}
		}
		Assert.True(found > 300, $"only {found} subclass spells checked");
	}

	[Fact]
	public void Domain_spells_come_with_the_levels()
	{
		Assert.Equal(new[] { "bless", "cure-wounds" }, SubclassSpells.Prepared(RulesetVersion.Dnd5e_2014, "life-domain", null, 1));
		Assert.Equal(4, SubclassSpells.Prepared(RulesetVersion.Dnd5e_2024, "life-domain", null, 3).Count);
		Assert.Empty(SubclassSpells.Prepared(RulesetVersion.Dnd5e_2024, "life-domain", null, 2));
		Assert.Equal(10, SubclassSpells.Prepared(RulesetVersion.Dnd5e_2024, "life-domain", null, 20).Count);

		//	Circle of the Land: the land decides
		Assert.Equal(7, SubclassSpells.Options(RulesetVersion.Dnd5e_2014, "circle-of-the-land").Count);
		Assert.Equal(new[] { "arid", "polar", "temperate", "tropical" }, SubclassSpells.Options(RulesetVersion.Dnd5e_2024, "circle-of-the-land"));
		Assert.Contains("fireball", SubclassSpells.Prepared(RulesetVersion.Dnd5e_2024, "circle-of-the-land", "arid", 5));
		Assert.Empty(SubclassSpells.Prepared(RulesetVersion.Dnd5e_2024, "circle-of-the-land", null, 5));

		//	2014 patrons add to the list, nothing is prepared
		Assert.Contains("burning-hands", SubclassSpells.Expanded(RulesetVersion.Dnd5e_2014, "the-fiend"));
		Assert.Empty(SubclassSpells.Prepared(RulesetVersion.Dnd5e_2014, "the-fiend", null, 20));
	}

	// ===== Species =====

	private static ContextSpecies Species(string key, params string[] subspecies) => new(Guid.NewGuid(), key, key, new List<CreatureSize> { CreatureSize.Medium }, 30,
		subspecies.Select(s => new ContextSubspecies(Guid.NewGuid(), s, s, null)).ToList());

	[Fact]
	public void Species_senses_and_resistances()
	{
		var drow = Species("elf", "dark-elf");
		Assert.Equal(120, CharacterTraits.Darkvision(RulesetVersion.Dnd5e_2014, drow, drow.Subspecies[0]));
		Assert.Equal(60, CharacterTraits.Darkvision(RulesetVersion.Dnd5e_2014, Species("half-orc"), null));
		Assert.Equal(0, CharacterTraits.Darkvision(RulesetVersion.Dnd5e_2014, Species("human"), null));
		Assert.Equal(120, CharacterTraits.Darkvision(RulesetVersion.Dnd5e_2024, Species("orc"), null));

		var stout = Species("halfling", "stout");
		Assert.Equal(new[] { DamageType.Poison }, CharacterTraits.SpeciesResistances(RulesetVersion.Dnd5e_2014, stout, stout.Subspecies[0], null));
		Assert.Equal(new[] { DamageType.Necrotic, DamageType.Radiant }, CharacterTraits.SpeciesResistances(RulesetVersion.Dnd5e_2024, Species("aasimar"), null, null));
		Assert.Equal(new[] { DamageType.Cold }, CharacterTraits.SpeciesResistances(RulesetVersion.Dnd5e_2024, Species("dragonborn"), null, "silver"));

		var infernal = Species("tiefling", "infernal");
		Assert.Equal(new[] { DamageType.Fire }, CharacterTraits.SpeciesResistances(RulesetVersion.Dnd5e_2024, infernal, infernal.Subspecies[0], null));
	}

	[Fact]
	public void Breath_Weapon_grows_with_the_level()
	{
		var dragonborn = Species("dragonborn");
		var young = CharacterTraits.Breath(RulesetVersion.Dnd5e_2014, dragonborn, "white", 1, 2, 2)!;
		Assert.Equal(("2d6", DamageType.Cold, AbilityScore.Constitution, 12), (young.Damage, young.Type, young.Save, young.Dc));
		Assert.Equal("5d6", CharacterTraits.Breath(RulesetVersion.Dnd5e_2014, dragonborn, "blue", 16, 2, 5)!.Damage);
		Assert.Equal("3d10", CharacterTraits.Breath(RulesetVersion.Dnd5e_2024, dragonborn, "red", 11, 1, 4)!.Damage);
		Assert.Null(CharacterTraits.Breath(RulesetVersion.Dnd5e_2024, dragonborn, null, 11, 1, 4));
	}

	[Fact]
	public void Lineage_spells_follow_the_character_level()
	{
		var elf = Species("elf", "wood-elf");
		var spells = CharacterTraits.SpeciesSpells(RulesetVersion.Dnd5e_2024, elf, elf.Subspecies[0], AbilityScore.Wisdom);
		Assert.Equal(new[] { "druidcraft", "longstrider", "pass-without-trace" }, spells.Select(s => s.SpellKey));
		Assert.All(spells, s => Assert.Equal(AbilityScore.Wisdom, s.Ability));
		Assert.Equal(new[] { 1, 3, 5 }, spells.Select(s => s.MinLevel));
		foreach (var key in new[] { "druidcraft", "longstrider", "pass-without-trace", "thaumaturgy", "fire-bolt", "hellish-rebuke", "chill-touch", "false-life",
			"ray-of-enfeeblement", "poison-spray", "ray-of-sickness", "hold-person", "light", "prestidigitation", "detect-magic", "misty-step", "minor-illusion",
			"speak-with-animals", "mending", "dancing-lights", "faerie-fire", "darkness" })
		{
			Assert.True(SpellKeys[RulesetVersion.Dnd5e_2024].Contains(key), key);
		}
		foreach (var key in new[] { "thaumaturgy", "hellish-rebuke", "darkness", "dancing-lights", "faerie-fire", "minor-illusion" })
		{
			Assert.True(SpellKeys[RulesetVersion.Dnd5e_2014].Contains(key), key);
		}
	}

	// ===== Calculator =====

	private static readonly RulesetVersion R2024 = RulesetVersion.Dnd5e_2024;

	private static (CharacterContextDto Context, CharacterInput Input) Character(RulesetVersion ruleset, ContextSpecies species, ContextClass cls, int levels,
		ContextSubclass? subclass = null, params ContextSpell[] spells)
	{
		var context = new CharacterContextDto(ruleset, new List<ContextClass> { cls }, new List<ContextSpecies> { species },
			new List<ContextBackground> { new(Guid.NewGuid(), "Sage", "sage", new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Intelligence, AbilityScore.Wisdom }, new List<Skill> { Skill.Arcana, Skill.History }, null, 0, ContextLoadout.Empty) },
			new List<ContextFeat>(), spells.ToList(), new List<ContextItem>());
		var input = new CharacterInput
		{
			Name = "Test",
			Ruleset = ruleset,
			SpeciesId = species.Id,
			SubspeciesId = species.Subspecies.FirstOrDefault()?.Id,
			BackgroundId = context.Backgrounds[0].Id,
			Build = new CharacterBuild { BaseScores = new List<int> { 15, 14, 13, 12, 10, 8 } }
		};
		input.Build.Classes.Add(new CharacterClassBuild { ClassId = cls.Id, SubclassId = subclass?.Id });
		for (var i = 0; i < levels; i++)
		{
			input.Build.Levels.Add(new CharacterLevelBuild { ClassId = cls.Id });
		}
		return (context, input);
	}

	private static ContextClass Class(string key, int hitDie, CasterProgression caster = CasterProgression.None, AbilityScore? ability = null, SpellcastingClass? list = null,
		params ContextSubclass[] subclasses) =>
		new(Guid.NewGuid(), key, key, hitDie, new List<AbilityScore>(), new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Charisma }, 2,
			Enum.GetValues<Skill>().ToList(), caster, ability, list, key == "cleric" ? 1 : 3, null, subclasses.ToList(), ContextLoadout.Empty);

	private static ContextSpell Spell(string key, int level, SpellcastingClass list) =>
		new(Guid.NewGuid(), key, level, SpellSchool.Evocation, new List<SpellcastingClass> { list }, false, false, key);

	[Fact]
	public void A_life_cleric_has_heavy_armor_and_its_domain_spells_prepared()
	{
		var life = new ContextSubclass(Guid.NewGuid(), "Life", "life-domain", CasterProgression.None, null);
		var cleric = Class("cleric", 8, CasterProgression.Full, AbilityScore.Wisdom, SpellcastingClass.Cleric, life);
		var (context, input) = Character(RulesetVersion.Dnd5e_2014, Species("dwarf", "hill-dwarf"), cleric, 1, life,
			Spell("bless", 1, SpellcastingClass.Cleric), Spell("cure-wounds", 1, SpellcastingClass.Cleric));

		var computed = CharacterCalculator.Compute(input, context);

		Assert.True(computed.ArmorTraining.HasFlag(ArmorTraining.Heavy));
		Assert.Equal(2, computed.Spellcasting.Single(s => s.Source == "class").Always.Count);
		Assert.Equal(60, computed.Darkvision);
		Assert.Contains(DamageType.Poison, computed.Resistances);
		Assert.Contains("warhammer", computed.ExtraWeapons);
	}

	[Fact]
	public void Lore_skills_must_be_chosen_and_count()
	{
		var lore = new ContextSubclass(Guid.NewGuid(), "Lore", "college-of-lore", CasterProgression.None, null);
		var bard = Class("bard", 8, CasterProgression.Full, AbilityScore.Charisma, SpellcastingClass.Bard, lore);
		var (context, input) = Character(R2024, Species("human"), bard, 3, lore);

		var missing = CharacterCalculator.Compute(input, context);
		Assert.Contains(missing.Issues, i => i.Code == IssueCodes.SkillsMissing && i.Args.Contains("Lore"));

		input.Build.Classes[0].SubclassSkills.AddRange(new[] { Skill.Stealth, Skill.Medicine, Skill.Nature });
		var done = CharacterCalculator.Compute(input, context);
		Assert.DoesNotContain(done.Issues, i => i.Code is IssueCodes.Skills or IssueCodes.SkillsMissing && i.Args.Contains("Lore"));
		Assert.Contains(Skill.Medicine, done.SkillProficiencies);
	}

	[Fact]
	public void Primal_Champion_raises_Strength_and_Constitution()
	{
		var barbarian = Class("barbarian", 12);
		var (context, input) = Character(R2024, Species("human"), barbarian, 20);
		var computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(19, computed.Score(AbilityScore.Strength));
		Assert.Equal(17, computed.Score(AbilityScore.Constitution));
	}

	[Fact]
	public void Gloom_Stalker_adds_Wisdom_to_initiative_and_sees_in_the_dark()
	{
		var gloom = new ContextSubclass(Guid.NewGuid(), "Gloom Stalker", "gloom-stalker", CasterProgression.None, null);
		var ranger = Class("ranger", 10, CasterProgression.Half, AbilityScore.Wisdom, SpellcastingClass.Ranger, gloom);
		var (context, input) = Character(R2024, Species("orc"), ranger, 7, gloom);
		var computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(180, computed.Darkvision);
		Assert.Equal(computed.Modifier(AbilityScore.Dexterity) + computed.Modifier(AbilityScore.Wisdom), computed.Initiative);
		Assert.Contains(AbilityScore.Wisdom, computed.SaveProficiencies);

		//	Roving at level 6: +10 feet, and climbing and swimming at that speed
		Assert.Equal(40, computed.Speed);
		Assert.Equal(40, computed.ClimbSpeed);
	}

	[Fact]
	public void The_ancestry_of_a_dragonborn_is_a_choice()
	{
		var fighter = Class("fighter", 10);
		var (context, input) = Character(R2024, Species("dragonborn"), fighter, 5);
		var missing = CharacterCalculator.Compute(input, context);
		Assert.Contains(missing.Issues, i => i.Code == IssueCodes.SpeciesOptionMissing);
		Assert.Null(missing.Breath);

		input.Build.SpeciesOption = "gold";
		var computed = CharacterCalculator.Compute(input, context);
		Assert.Contains(DamageType.Fire, computed.Resistances);
		Assert.Equal("2d10", computed.Breath!.Damage);
		Assert.Equal(computed.Speed, computed.FlySpeed);

		input.Build.SpeciesOption = "purple";
		Assert.Contains(CharacterCalculator.Compute(input, context).Issues, i => i.Code == IssueCodes.SpeciesOption && i.Blocking);
	}
}
