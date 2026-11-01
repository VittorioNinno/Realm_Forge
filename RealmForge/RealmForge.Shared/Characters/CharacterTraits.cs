using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	A spell a trait lets the character cast on its own (species, feat, subclass): from a character level, with a
///	fixed or chosen spellcasting ability; leveled ones are cast once per long rest without a slot.
///	</summary>
public sealed record InnateSpell(string Source, string SpellKey, int MinLevel, AbilityScore? Ability);

///	<summary>
///	Skills to choose from a trait: how many, from which ones (null: any) and whether they get Expertise.
///	</summary>
public sealed record SkillGrant(int Count, IReadOnlyList<Skill>? Options, bool Expertise = false);

///	<summary>
///	A choice of a species: the draconic ancestry of the dragonborn (its damage type) and the giant ancestry of the
///	2024 goliath.
///	</summary>
public sealed record SpeciesOption(string Key, string En, string It, DamageType? Damage = null);

///	<summary>
///	Breath Weapon of the dragonborn: damage, saving throw and DC, area, uses.
///	</summary>
public sealed record BreathWeapon(string Damage, DamageType Type, AbilityScore Save, int Dc, string AreaEn, string AreaIt, int Uses, ResourceReset Reset);

///	<summary>
///	The mechanics that the species, subclass and feat texts describe and that the sheet applies on its own: senses,
///	resistances, armor and weapon training, skills and languages to choose, innate spells, extra speeds, the
///	capstones of the classes. The texts stay in the compendium; this table turns them into numbers (Base content,
///	by key).
///	</summary>
public static class CharacterTraits
{
	// ===== Species =====

	private static readonly SpeciesOption[] DraconicAncestries =
	{
		new("black", "Black", "Nero", DamageType.Acid),
		new("blue", "Blue", "Blu", DamageType.Lightning),
		new("brass", "Brass", "Ottone", DamageType.Fire),
		new("bronze", "Bronze", "Bronzo", DamageType.Lightning),
		new("copper", "Copper", "Rame", DamageType.Acid),
		new("gold", "Gold", "Oro", DamageType.Fire),
		new("green", "Green", "Verde", DamageType.Poison),
		new("red", "Red", "Rosso", DamageType.Fire),
		new("silver", "Silver", "Argento", DamageType.Cold),
		new("white", "White", "Bianco", DamageType.Cold)
	};

	private static readonly SpeciesOption[] GiantAncestries =
	{
		new("cloud", "Cloud's Jaunt", "Balzo delle Nuvole"),
		new("fire", "Fire's Burn", "Ustione del Fuoco"),
		new("frost", "Frost's Chill", "Gelo del Ghiaccio"),
		new("hill", "Hill's Tumble", "Rovesciamento della Collina"),
		new("stone", "Stone's Endurance", "Tenacia della Pietra"),
		new("storm", "Storm's Thunder", "Tuono della Tempesta")
	};

	public static IReadOnlyList<SpeciesOption> SpeciesOptions(RulesetVersion ruleset, ContextSpecies? species) => species?.Key switch
	{
		"dragonborn" => DraconicAncestries,
		"goliath" when ruleset == RulesetVersion.Dnd5e_2024 => GiantAncestries,
		_ => Array.Empty<SpeciesOption>()
	};

	//	2024 elf lineage, gnome lineage and fiendish legacy: Intelligence, Wisdom or Charisma for their spells
	public static bool SpeciesSpellAbilityChoice(RulesetVersion ruleset, ContextSpecies? species) =>
		ruleset == RulesetVersion.Dnd5e_2024 && species?.Key is "elf" or "gnome" or "tiefling";

	public static readonly IReadOnlyList<AbilityScore> SpellAbilities = new[] { AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma };

	public static int Darkvision(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies)
	{
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			if (subspecies?.Key == "dark-elf")
			{
				return 120;
			}
			return species?.Key is "dwarf" or "elf" or "gnome" or "half-elf" or "half-orc" or "tiefling" ? 60 : 0;
		}
		if (subspecies?.Key == "drow")
		{
			return 120;
		}
		return species?.Key switch
		{
			"dwarf" or "orc" => 120,
			"aasimar" or "dragonborn" or "elf" or "gnome" or "tiefling" => 60,
			_ => 0
		};
	}

	public static IReadOnlyList<DamageType> SpeciesResistances(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies, string? option)
	{
		var list = new List<DamageType>();
		if (species?.Key == "dragonborn" && DraconicAncestries.FirstOrDefault(a => a.Key == option)?.Damage is { } damage)
		{
			list.Add(damage);
		}
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			if (species?.Key == "dwarf" || subspecies?.Key == "stout")
			{
				list.Add(DamageType.Poison);
			}
			if (species?.Key == "tiefling")
			{
				list.Add(DamageType.Fire);
			}
			return list;
		}
		switch (species?.Key)
		{
			case "aasimar": list.Add(DamageType.Necrotic); list.Add(DamageType.Radiant); break;
			case "dwarf": list.Add(DamageType.Poison); break;
		}
		switch (subspecies?.Key)
		{
			case "abyssal": list.Add(DamageType.Poison); break;
			case "chthonic": list.Add(DamageType.Necrotic); break;
			case "infernal": list.Add(DamageType.Fire); break;
		}
		return list;
	}

	//	2014 mountain dwarf: Dwarven Armor Training
	public static ArmorTraining SpeciesArmor(RulesetVersion ruleset, ContextSubspecies? subspecies) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subspecies?.Key == "mountain-dwarf" ? ArmorTraining.Light | ArmorTraining.Medium : ArmorTraining.None;

	///	<summary>
	///	2014 Dwarven Combat Training, Elf Weapon Training and Drow Weapon Training (English item names).
	///	</summary>
	public static IReadOnlyList<string> SpeciesWeapons(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies)
	{
		if (ruleset != RulesetVersion.Dnd5e_2014)
		{
			return Array.Empty<string>();
		}
		return (species?.Key, subspecies?.Key) switch
		{
			("dwarf", _) => new[] { "battleaxe", "handaxe", "light hammer", "warhammer" },
			(_, "high-elf" or "wood-elf") => new[] { "longsword", "shortsword", "shortbow", "longbow" },
			(_, "dark-elf") => new[] { "rapier", "shortsword", "hand crossbow" },
			_ => Array.Empty<string>()
		};
	}

	///	<summary>
	///	Spells of the species traits (2014 drow, forest gnome and tiefling; 2024 aasimar, lineages and legacies).
	///	The 2014 high elf's wizard cantrip is a choice, see <see cref="CharacterRules.SpeciesCantrips"/>.
	///	</summary>
	public static IReadOnlyList<InnateSpell> SpeciesSpells(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies, AbilityScore? chosen)
	{
		const string source = "species";
		InnateSpell S(string key, int level, AbilityScore? ability) => new(source, key, level, ability);
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			var cha = AbilityScore.Charisma;
			return (species?.Key, subspecies?.Key) switch
			{
				(_, "dark-elf") => new[] { S("dancing-lights", 1, cha), S("faerie-fire", 3, cha), S("darkness", 5, cha) },
				(_, "forest-gnome") => new[] { S("minor-illusion", 1, AbilityScore.Intelligence) },
				("tiefling", _) => new[] { S("thaumaturgy", 1, cha), S("hellish-rebuke", 3, cha), S("darkness", 5, cha) },
				_ => Array.Empty<InnateSpell>()
			};
		}

		var ability = chosen ?? AbilityScore.Charisma;
		return (species?.Key, subspecies?.Key) switch
		{
			("aasimar", _) => new[] { S("light", 1, AbilityScore.Charisma) },
			(_, "drow") => new[] { S("dancing-lights", 1, ability), S("faerie-fire", 3, ability), S("darkness", 5, ability) },
			(_, "high-elf") => new[] { S("prestidigitation", 1, ability), S("detect-magic", 3, ability), S("misty-step", 5, ability) },
			(_, "wood-elf") => new[] { S("druidcraft", 1, ability), S("longstrider", 3, ability), S("pass-without-trace", 5, ability) },
			(_, "forest-gnome") => new[] { S("minor-illusion", 1, ability), S("speak-with-animals", 1, ability) },
			(_, "rock-gnome") => new[] { S("mending", 1, ability), S("prestidigitation", 1, ability) },
			(_, "abyssal") => new[] { S("thaumaturgy", 1, ability), S("poison-spray", 1, ability), S("ray-of-sickness", 3, ability), S("hold-person", 5, ability) },
			(_, "chthonic") => new[] { S("thaumaturgy", 1, ability), S("chill-touch", 1, ability), S("false-life", 3, ability), S("ray-of-enfeeblement", 5, ability) },
			(_, "infernal") => new[] { S("thaumaturgy", 1, ability), S("fire-bolt", 1, ability), S("hellish-rebuke", 3, ability), S("darkness", 5, ability) },
			_ => Array.Empty<InnateSpell>()
		};
	}

	//	2024 dragonborn Draconic Flight (level 5, for 10 minutes once per long rest) and the extra speeds
	public static int SpeciesFlyLevel(RulesetVersion ruleset, ContextSpecies? species) =>
		ruleset == RulesetVersion.Dnd5e_2024 && species?.Key == "dragonborn" ? 5 : 0;

	public static BreathWeapon? Breath(RulesetVersion ruleset, ContextSpecies? species, string? option, int level, int constitution, int proficiency)
	{
		if (species?.Key != "dragonborn" || DraconicAncestries.FirstOrDefault(a => a.Key == option) is not { Damage: { } type } ancestry)
		{
			return null;
		}
		var dc = 8 + constitution + proficiency;
		if (ruleset == RulesetVersion.Dnd5e_2024)
		{
			var dice = level >= 17 ? 4 : level >= 11 ? 3 : level >= 5 ? 2 : 1;
			return new BreathWeapon($"{dice}d10", type, AbilityScore.Dexterity, dc, "15-foot Cone or 30-foot Line", "cono di 4,5 m o linea di 9 m", proficiency, ResourceReset.LongRest);
		}
		var d6 = level >= 16 ? 5 : level >= 11 ? 4 : level >= 6 ? 3 : 2;
		var line = ancestry.Key is "black" or "blue" or "brass" or "bronze" or "copper";
		var save = type is DamageType.Cold or DamageType.Poison ? AbilityScore.Constitution : AbilityScore.Dexterity;
		return new BreathWeapon($"{d6}d6", type, save, dc,
			line ? "5 by 30 ft. line" : "15 ft. cone", line ? "linea di 1,5 × 9 m" : "cono di 4,5 m", 1, ResourceReset.ShortRest);
	}

	// ===== Subclasses =====

	public static ArmorTraining SubclassArmor(RulesetVersion ruleset, string? subclass) => (ruleset, subclass) switch
	{
		(RulesetVersion.Dnd5e_2014, "life-domain" or "nature-domain" or "tempest-domain" or "war-domain") => ArmorTraining.Heavy,
		(_, "college-of-valor") => ArmorTraining.Medium | ArmorTraining.Shield,
		_ => ArmorTraining.None
	};

	public static bool SubclassMartial(RulesetVersion ruleset, string? subclass) => (ruleset, subclass) switch
	{
		(RulesetVersion.Dnd5e_2014, "tempest-domain" or "war-domain") => true,
		(_, "college-of-valor") => true,
		_ => false
	};

	//	Skills fixed by the subclass (2024 Warrior of Mercy)
	public static IReadOnlyList<Skill> SubclassFixedSkills(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass == "warrior-of-mercy" && classLevel >= 3 ? new[] { Skill.Insight, Skill.Medicine } : Array.Empty<Skill>();

	///	<summary>
	///	Skills to choose from the subclass: Bonus Proficiencies of the College of Lore, Blessings of Knowledge (with
	///	Expertise), Acolyte of Nature, Student of War (2024), Otherworldly Glamour.
	///	</summary>
	public static SkillGrant? SubclassSkills(RulesetVersion ruleset, ContextClass cls, string? subclass, int classLevel)
	{
		var is2024 = ruleset == RulesetVersion.Dnd5e_2024;
		return subclass switch
		{
			"college-of-lore" when classLevel >= 3 => new SkillGrant(3, null),
			"knowledge-domain" when !is2024 => new SkillGrant(2, new[] { Skill.Arcana, Skill.History, Skill.Nature, Skill.Religion }, Expertise: true),
			"nature-domain" when !is2024 => new SkillGrant(1, new[] { Skill.AnimalHandling, Skill.Nature, Skill.Survival }),
			"battle-master" when is2024 && classLevel >= 3 => new SkillGrant(1, cls.SkillOptions),
			"fey-wanderer" when is2024 && classLevel >= 3 => new SkillGrant(1, new[] { Skill.Deception, Skill.Performance, Skill.Persuasion }),
			_ => null
		};
	}

	//	2014 Blessings of Knowledge: two languages
	public static int SubclassLanguages(RulesetVersion ruleset, string? subclass) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subclass == "knowledge-domain" ? 2 : 0;

	//	2014 Acolyte of Nature: a druid cantrip (the cleric's spellcasting ability)
	public static (int Count, SpellcastingClass List)? SubclassCantrips(RulesetVersion ruleset, string? subclass) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subclass == "nature-domain" ? (1, SpellcastingClass.Druid) : null;

	//	2014 Circle of the Land: Bonus Cantrip (one more druid cantrip)
	public static int SubclassExtraCantrips(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subclass == "circle-of-the-land" && classLevel >= 2 ? 1 : 0;

	//	2014 Way of Shadow: minor illusion (Shadow Arts)
	public static IReadOnlyList<InnateSpell> SubclassInnate(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subclass == "way-of-shadow" && classLevel >= 3
			? new[] { new InnateSpell("subclass", "minor-illusion", 1, AbilityScore.Wisdom) }
			: Array.Empty<InnateSpell>();

	///	<summary>
	///	Spells a bard can take from other lists: 2014 Magical Secrets (two from any class at 10, 14, 18) and
	///	Additional Magical Secrets (Lore, two at 6), counted among the known spells; 2024 Magical Secrets (bard 10:
	///	prepared spells also from the cleric, druid and wizard lists) and Magical Discoveries (Lore 6: two more, from
	///	those lists, always prepared). Null lists: any class.
	///	</summary>
	public static (int Extra, int OffList, IReadOnlyList<SpellcastingClass>? Lists) ExtraSpellLists(RulesetVersion ruleset, ContextClass cls, string? subclass, int classLevel)
	{
		if (cls.Key != "bard")
		{
			return (0, 0, Array.Empty<SpellcastingClass>());
		}
		var lore = subclass == "college-of-lore" && classLevel >= 6 ? 2 : 0;
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			var secrets = (classLevel >= 10 ? 2 : 0) + (classLevel >= 14 ? 2 : 0) + (classLevel >= 18 ? 2 : 0);
			return (secrets + lore, secrets + lore, null);
		}
		var lists = new[] { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard };
		if (classLevel >= 10)
		{
			return (lore, int.MaxValue, lists);
		}
		return (lore, lore, lore > 0 ? lists : Array.Empty<SpellcastingClass>());
	}

	public static int SubclassDarkvision(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass is "gloom-stalker" or "warrior-of-shadow" && classLevel >= 3 ? 60 : 0;

	//	2024 Gloom Stalker Dread Ambusher: Wisdom modifier to Initiative
	public static AbilityScore? SubclassInitiative(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass == "gloom-stalker" && classLevel >= 3 ? AbilityScore.Wisdom : null;

	//	2024 Gloom Stalker Iron Mind: Wisdom saving throws
	public static AbilityScore? SubclassSave(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass == "gloom-stalker" && classLevel >= 7 ? AbilityScore.Wisdom : null;

	//	2024 Fey Wanderer Otherworldly Glamour: Wisdom modifier (at least +1) to Charisma checks
	public static bool CharismaChecksPlusWisdom(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass == "fey-wanderer" && classLevel >= 3;

	//	2014 Champion Remarkable Athlete: half the proficiency bonus (rounded up) to Strength, Dexterity and
	//	Constitution checks without proficiency
	public static bool RemarkableAthlete(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subclass == "champion" && classLevel >= 7;

	//	2024 College of Dance: Dazzling Footwork (10 + Dex + Cha without armor and shield)
	public static bool DanceDefense(RulesetVersion ruleset, string? subclass, int classLevel) =>
		ruleset == RulesetVersion.Dnd5e_2024 && subclass == "college-of-dance" && classLevel >= 3;

	// ===== Classes =====

	///	<summary>
	///	Capstones that raise two abilities by 4 (barbarian Primal Champion, maximum 24; 2024 monk Body and Mind,
	///	maximum 25).
	///	</summary>
	public static IReadOnlyList<(AbilityScore Ability, int Bonus, int Maximum)> Capstones(RulesetVersion ruleset, ComputedCharacter c)
	{
		var list = new List<(AbilityScore, int, int)>();
		if (c.ClassLevel("barbarian") >= 20)
		{
			list.Add((AbilityScore.Strength, 4, 24));
			list.Add((AbilityScore.Constitution, 4, 24));
		}
		if (ruleset == RulesetVersion.Dnd5e_2024 && c.ClassLevel("monk") >= 20)
		{
			list.Add((AbilityScore.Dexterity, 4, 25));
			list.Add((AbilityScore.Wisdom, 4, 25));
		}
		return list;
	}

	//	2024 ranger Roving (level 6): +10 feet without heavy armor, and Climb and Swim Speed equal to the Speed
	public static bool Roving(RulesetVersion ruleset, ComputedCharacter c) => ruleset == RulesetVersion.Dnd5e_2024 && c.ClassLevel("ranger") >= 6;

	//	2014 monk Purity of Body (level 10): immune to poison damage and to disease
	public static bool PurityOfBody(RulesetVersion ruleset, ComputedCharacter c) => ruleset == RulesetVersion.Dnd5e_2014 && c.ClassLevel("monk") >= 10;

	// ===== Feats =====

	public static int FeatBlindsight(ContextFeat feat, RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2024 && feat.Key == "skulker" ? 10 : 0;

	public static int FeatTruesight(ContextFeat feat) => feat.Key == "boon-of-truesight" ? 60 : 0;

	public static int FeatHitPoints(ContextFeat feat) => feat.Key == "boon-of-fortitude" ? 40 : 0;

	public static int FeatSpeed(ContextFeat feat) => feat.Key == "boon-of-speed" ? 30 : 0;

	//	2024 Athlete: Climb Speed equal to the Speed
	public static bool FeatClimb(ContextFeat feat, RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2024 && feat.Key == "athlete";

	//	Fixed spells of the 2024 origin-of-magic feats (the spellcasting ability is the ability the feat raised); the
	//	Fey Touched / Shadow Touched level 1 spell of a school is a choice (FeatChoice.Spells)
	public static IReadOnlyList<string> FeatSpells(ContextFeat feat, RulesetVersion ruleset) => (ruleset, feat.Key) switch
	{
		(RulesetVersion.Dnd5e_2024, "fey-touched") => new[] { "misty-step" },
		(RulesetVersion.Dnd5e_2024, "shadow-touched") => new[] { "invisibility" },
		(RulesetVersion.Dnd5e_2024, "telekinetic") => new[] { "mage-hand" },
		(RulesetVersion.Dnd5e_2024, "telepathic") => new[] { "detect-thoughts" },
		_ => Array.Empty<string>()
	};

	//	Schools of the level 1 spell chosen with Fey Touched / Shadow Touched
	public static IReadOnlyList<SpellSchool> FeatSpellSchools(ContextFeat feat, RulesetVersion ruleset) => (ruleset, feat.Key) switch
	{
		(RulesetVersion.Dnd5e_2024, "fey-touched") => new[] { SpellSchool.Divination, SpellSchool.Enchantment },
		(RulesetVersion.Dnd5e_2024, "shadow-touched") => new[] { SpellSchool.Illusion, SpellSchool.Necromancy },
		_ => Array.Empty<SpellSchool>()
	};

	//	Dual Wielder (2014): +1 AC with a melee weapon in each hand
	public static bool DualWielderAc(ContextFeat feat, RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2014 && feat.Key == "dual-wielder";

	//	Medium Armor Master: Dexterity up to +3 with medium armor
	public static bool MediumArmorMaster(ContextFeat feat) => feat.Key == "medium-armor-master";

	//	Heavy Armor Master: bludgeoning, piercing and slashing damage reduced by 3 (2014) or the Proficiency Bonus (2024)
	public static int HeavyArmorReduction(ContextFeat feat, RulesetVersion ruleset, int proficiency) =>
		feat.Key == "heavy-armor-master" ? (ruleset == RulesetVersion.Dnd5e_2024 ? proficiency : 3) : 0;
}
