using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

[Flags]
public enum ArmorTraining
{
	None = 0,
	Light = 1,
	Medium = 2,
	Heavy = 4,
	Shield = 8
}

public enum UnarmoredDefense
{
	None = 0,

	//	10 + Dex + Con, shield allowed
	Barbarian = 1,

	//	10 + Dex + Wis, no shield
	Monk = 2,

	//	2014 Draconic Bloodline: 13 + Dex
	DraconicBloodline = 3,

	//	2024 Draconic Sorcery: 10 + Dex + Cha
	DraconicSorcery = 4,

	//	2024 College of Dance: 10 + Dex + Cha without armor and shield
	Dance = 5
}

///	<summary>
///	An option of a class choice (2014 Fighting Styles, 2024 Divine / Primal Order).
///	</summary>
public sealed record RuleOption(string Key, string NameEn, string NameIt);

///	<summary>
///	Rules of the Player's Handbooks that the compendium does not carry as data, keyed by the Base content keys:
///	multiclassing, armor training, Ability Score Improvement levels, Expertise, Fighting Styles, Weapon Mastery,
///	racial increases of 2014, hit point and speed bonuses. Homebrew content falls back to the general rules.
///	</summary>
public static class CharacterRules
{
	public const int MulticlassMinimum = 13;

	// ===== Classes =====

	///	<summary>
	///	Ability scores needed to multiclass into (or out of) a class: all of them, or any one for the fighter.
	///	</summary>
	public static (IReadOnlyList<AbilityScore> Abilities, bool Any) MulticlassPrerequisite(ContextClass cls) => cls.Key switch
	{
		"barbarian" => (new[] { AbilityScore.Strength }, false),
		"bard" => (new[] { AbilityScore.Charisma }, false),
		"cleric" => (new[] { AbilityScore.Wisdom }, false),
		"druid" => (new[] { AbilityScore.Wisdom }, false),
		"fighter" => (new[] { AbilityScore.Strength, AbilityScore.Dexterity }, true),
		"monk" => (new[] { AbilityScore.Dexterity, AbilityScore.Wisdom }, false),
		"paladin" => (new[] { AbilityScore.Strength, AbilityScore.Charisma }, false),
		"ranger" => (new[] { AbilityScore.Dexterity, AbilityScore.Wisdom }, false),
		"rogue" => (new[] { AbilityScore.Dexterity }, false),
		"sorcerer" => (new[] { AbilityScore.Charisma }, false),
		"warlock" => (new[] { AbilityScore.Charisma }, false),
		"wizard" => (new[] { AbilityScore.Intelligence }, false),
		_ => (cls.PrimaryAbilities, true)
	};

	public static bool MeetsMulticlassPrerequisite(ContextClass cls, IReadOnlyList<int> scores)
	{
		var (abilities, any) = MulticlassPrerequisite(cls);
		if (abilities.Count == 0)
		{
			return true;
		}

		bool Meets(AbilityScore a) => scores[(int)a - 1] >= MulticlassMinimum;
		return any ? abilities.Any(Meets) : abilities.All(Meets);
	}

	///	<summary>
	///	Skill gained when multiclassing into the class: one of any skill (bard) or of the class list (ranger, rogue).
	///	</summary>
	public static (int Count, bool AnySkill) MulticlassSkills(ContextClass cls) => cls.Key switch
	{
		"bard" => (1, true),
		"ranger" or "rogue" => (1, false),
		_ => (0, false)
	};

	public static ArmorTraining Armor(ContextClass cls, RulesetVersion ruleset, bool startingClass)
	{
		const ArmorTraining LMS = ArmorTraining.Light | ArmorTraining.Medium | ArmorTraining.Shield;
		var is2024 = ruleset == RulesetVersion.Dnd5e_2024;
		return (cls.Key, startingClass) switch
		{
			("barbarian", true) => LMS,
			("barbarian", false) => ArmorTraining.Shield,
			("bard" or "rogue" or "warlock", _) => ArmorTraining.Light,
			("cleric", _) => LMS,
			("druid", _) => is2024 ? ArmorTraining.Light | ArmorTraining.Shield : (startingClass ? LMS : ArmorTraining.Light | ArmorTraining.Medium | ArmorTraining.Shield),
			("fighter" or "paladin", true) => LMS | ArmorTraining.Heavy,
			("fighter" or "paladin", false) => LMS,
			("ranger", _) => LMS,
			_ => ArmorTraining.None
		};
	}

	///	<summary>
	///	Martial weapons for the classes trained in them (also when multiclassing into them).
	///	</summary>
	public static bool MartialWeapons(ContextClass cls) => cls.Key is "barbarian" or "fighter" or "paladin" or "ranger";

	///	<summary>
	///	Weapons a class knows besides the simple / martial categories (by English name); null: all simple weapons.
	///	</summary>
	public static IReadOnlyList<string>? WeaponList(ContextClass cls, RulesetVersion ruleset)
	{
		if (ruleset == RulesetVersion.Dnd5e_2024)
		{
			return null;
		}

		return cls.Key switch
		{
			"druid" => new[] { "club", "dagger", "dart", "javelin", "mace", "quarterstaff", "scimitar", "sickle", "sling", "spear" },
			"sorcerer" or "wizard" => new[] { "dagger", "dart", "sling", "quarterstaff", "light crossbow" },
			_ => null
		};
	}

	//	2014 bard and rogue, 2014 monk: some martial weapons by name
	public static IReadOnlyList<string> ExtraWeapons(ContextClass cls, RulesetVersion ruleset) => (cls.Key, ruleset) switch
	{
		("bard" or "rogue", RulesetVersion.Dnd5e_2014) => new[] { "hand crossbow", "longsword", "rapier", "shortsword" },
		("monk", RulesetVersion.Dnd5e_2014) => new[] { "shortsword" },
		_ => Array.Empty<string>()
	};

	//	2024 rogue: martial weapons with Finesse or Light; 2024 monk: martial weapons with Light
	public static IReadOnlyList<WeaponProperty> MartialWithProperties(ContextClass cls, RulesetVersion ruleset) => (cls.Key, ruleset) switch
	{
		("rogue", RulesetVersion.Dnd5e_2024) => new[] { WeaponProperty.Finesse, WeaponProperty.Light },
		("monk", RulesetVersion.Dnd5e_2024) => new[] { WeaponProperty.Light },
		_ => Array.Empty<WeaponProperty>()
	};

	///	<summary>
	///	Class levels of the Ability Score Improvement (2014: also 19; 2024: 19 is the Epic Boon).
	///	</summary>
	public static IReadOnlyList<int> ImprovementLevels(ContextClass cls, RulesetVersion ruleset)
	{
		var levels = new List<int> { 4, 8, 12, 16 };
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			levels.Add(19);
		}
		if (cls.Key == "fighter")
		{
			levels.AddRange(new[] { 6, 14 });
		}
		if (cls.Key == "rogue")
		{
			levels.Add(10);
		}

		return levels.OrderBy(l => l).ToList();
	}

	public static int? EpicBoonLevel(RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2024 ? 19 : null;

	public sealed record ExpertiseGrant(int Level, int Count, IReadOnlyList<Skill>? Allowed);

	public static IReadOnlyList<ExpertiseGrant> Expertise(ContextClass cls, RulesetVersion ruleset)
	{
		var is2024 = ruleset == RulesetVersion.Dnd5e_2024;
		return cls.Key switch
		{
			"rogue" => new[] { new ExpertiseGrant(1, 2, null), new ExpertiseGrant(6, 2, null) },
			"bard" => is2024
				? new[] { new ExpertiseGrant(2, 2, null), new ExpertiseGrant(9, 2, null) }
				: new[] { new ExpertiseGrant(3, 2, null), new ExpertiseGrant(10, 2, null) },
			"ranger" when is2024 => new[] { new ExpertiseGrant(2, 1, null), new ExpertiseGrant(9, 2, null) },
			"wizard" when is2024 => new[] { new ExpertiseGrant(2, 1, new[] { Skill.Arcana, Skill.History, Skill.Investigation, Skill.Medicine, Skill.Nature, Skill.Religion }) },
			_ => Array.Empty<ExpertiseGrant>()
		};
	}

	public static int ExpertiseCount(ContextClass cls, RulesetVersion ruleset, int classLevel) =>
		Expertise(cls, ruleset).Where(g => g.Level <= classLevel).Sum(g => g.Count);

	public static int? FightingStyleLevel(ContextClass cls) => cls.Key switch
	{
		"fighter" => 1,
		"paladin" or "ranger" => 2,
		_ => null
	};

	//	2014 Fighting Style options of each class (SRD 5.1)
	public static readonly RuleOption Archery = new("archery", "Archery", "Tiro");
	public static readonly RuleOption Defense = new("defense", "Defense", "Difesa");
	public static readonly RuleOption Dueling = new("dueling", "Dueling", "Duellare");
	public static readonly RuleOption GreatWeapon = new("great-weapon-fighting", "Great Weapon Fighting", "Combattere con Armi Possenti");
	public static readonly RuleOption Protection = new("protection", "Protection", "Protezione");
	public static readonly RuleOption TwoWeapon = new("two-weapon-fighting", "Two-Weapon Fighting", "Combattere con Due Armi");

	public static IReadOnlyList<RuleOption> FightingStyles2014(ContextClass cls) => cls.Key switch
	{
		"fighter" => new[] { Archery, Defense, Dueling, GreatWeapon, Protection, TwoWeapon },
		"paladin" => new[] { Defense, Dueling, GreatWeapon, Protection },
		"ranger" => new[] { Archery, Defense, Dueling, TwoWeapon },
		_ => Array.Empty<RuleOption>()
	};

	//	2024: instead of a Fighting Style feat, two cantrips of the cleric (paladin) or druid (ranger) list
	public static RuleOption? StyleAlternative2024(ContextClass cls) => cls.Key switch
	{
		"paladin" => new RuleOption("blessed-warrior", "Blessed Warrior", "Guerriero Benedetto"),
		"ranger" => new RuleOption("druidic-warrior", "Druidic Warrior", "Guerriero Druidico"),
		_ => null
	};

	public static SpellcastingClass? StyleAlternativeList(string? style) => style switch
	{
		"blessed-warrior" => SpellcastingClass.Cleric,
		"druidic-warrior" => SpellcastingClass.Druid,
		_ => null
	};

	public static IReadOnlyList<RuleOption> Orders2024(ContextClass cls) => cls.Key switch
	{
		"cleric" => new[] { new RuleOption("protector", "Protector", "Protettore"), new RuleOption("thaumaturge", "Thaumaturge", "Taumaturgo") },
		"druid" => new[] { new RuleOption("magician", "Magician", "Mago"), new RuleOption("warden", "Warden", "Custode") },
		_ => Array.Empty<RuleOption>()
	};

	//	Weapon Mastery of the 2024 martial classes, by class level
	public static int WeaponMasteries(ContextClass cls, RulesetVersion ruleset, int classLevel)
	{
		if (ruleset != RulesetVersion.Dnd5e_2024)
		{
			return 0;
		}

		return cls.Key switch
		{
			"barbarian" => classLevel >= 10 ? 4 : classLevel >= 4 ? 3 : 2,
			"fighter" => classLevel >= 16 ? 6 : classLevel >= 10 ? 5 : classLevel >= 4 ? 4 : 3,
			"paladin" or "ranger" or "rogue" => 2,
			_ => 0
		};
	}

	//	Barbarian: Simple or Martial Melee weapons; the others: weapons they are proficient with
	public static bool MasteryMeleeOnly(ContextClass cls) => cls.Key == "barbarian";

	public static UnarmoredDefense UnarmoredDefenseOf(ContextClass cls, ContextSubclass? subclass, int classLevel) =>
		cls.Key switch
		{
			"barbarian" => UnarmoredDefense.Barbarian,
			"monk" => UnarmoredDefense.Monk,
			_ => subclass?.Key switch
			{
				"draconic-bloodline" => UnarmoredDefense.DraconicBloodline,
				"draconic-sorcery" when classLevel >= 3 => UnarmoredDefense.DraconicSorcery,
				_ => UnarmoredDefense.None
			}
		};

	///	<summary>
	///	Languages a class teaches by itself (Druidic, Thieves' Cant) and the ones it lets you choose.
	///	</summary>
	public static IReadOnlyList<string> ClassLanguages(ContextClass cls) => cls.Key switch
	{
		"druid" => new[] { CharacterLanguages.Druidic },
		"rogue" => new[] { CharacterLanguages.ThievesCant },
		_ => Array.Empty<string>()
	};

	public static int ClassLanguageChoices(ContextClass cls, RulesetVersion ruleset, int classLevel) => (cls.Key, ruleset) switch
	{
		//	2024 Deft Explorer; 2014 Favored Enemy (one language per favored enemy, at levels 1, 6 and 14)
		("ranger", RulesetVersion.Dnd5e_2024) => classLevel >= 2 ? 2 : 0,
		("ranger", RulesetVersion.Dnd5e_2014) => (classLevel >= 1 ? 1 : 0) + (classLevel >= 6 ? 1 : 0) + (classLevel >= 14 ? 1 : 0),
		_ => 0
	};

	//	Monk Unarmored Movement (no armor and no shield), barbarian Fast Movement (no heavy armor)
	public static int MonkSpeedBonus(int monkLevel) =>
		monkLevel >= 18 ? 30 : monkLevel >= 14 ? 25 : monkLevel >= 10 ? 20 : monkLevel >= 6 ? 15 : monkLevel >= 2 ? 10 : 0;

	//	Third casters (Eldritch Knight, Arcane Trickster): cantrips and spells known/prepared by class level
	public static (int Cantrips, int Spells) ThirdCaster(ContextSubclass subclass, int classLevel)
	{
		if (classLevel < 3)
		{
			return (0, 0);
		}

		var spells = classLevel switch
		{
			>= 20 => 13,
			19 => 12,
			>= 16 => 11,
			>= 14 => 10,
			13 => 9,
			>= 11 => 8,
			10 => 7,
			>= 8 => 6,
			7 => 5,
			>= 4 => 4,
			_ => 3
		};
		var cantrips = (subclass.Key == "arcane-trickster" ? 3 : 2) + (classLevel >= 10 ? 1 : 0);
		return (cantrips, spells);
	}

	//	Spell slots of a full caster by caster level (also the multiclass spellcaster table)
	private static readonly int[][] FullCasterSlots =
	{
		new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		new[] { 2, 0, 0, 0, 0, 0, 0, 0, 0 },
		new[] { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
		new[] { 4, 2, 0, 0, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 0, 0, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 2, 0, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 0, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 1, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 2, 0, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 3, 1, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 0, 0, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
		new[] { 4, 3, 3, 3, 2, 1, 1, 1, 1 },
		new[] { 4, 3, 3, 3, 3, 1, 1, 1, 1 },
		new[] { 4, 3, 3, 3, 3, 2, 1, 1, 1 },
		new[] { 4, 3, 3, 3, 3, 2, 2, 1, 1 }
	};

	public static int[] SlotsForCasterLevel(int casterLevel) => FullCasterSlots[Math.Clamp(casterLevel, 0, 20)].ToArray();

	public static int HighestSlot(int[] slots)
	{
		for (var i = slots.Length - 1; i >= 0; i--)
		{
			if (slots[i] > 0)
			{
				return i + 1;
			}
		}

		return 0;
	}

	//	Warlock Pact Magic: slots and their level
	public static (int Slots, int Level) PactSlots(int warlockLevel) => warlockLevel <= 0
		? (0, 0)
		: (warlockLevel >= 17 ? 4 : warlockLevel >= 11 ? 3 : warlockLevel >= 2 ? 2 : 1,
			warlockLevel >= 9 ? 5 : warlockLevel >= 7 ? 4 : warlockLevel >= 5 ? 3 : warlockLevel >= 3 ? 2 : 1);

	///	<summary>
	///	Caster level of one class for its own spells (single-class rules): full casters their level, half casters
	///	half (2014 from level 2, rounded up), third casters a third from level 3 (rounded up).
	///	</summary>
	public static int SingleClassCasterLevel(CasterProgression progression, int classLevel, RulesetVersion ruleset) => progression switch
	{
		CasterProgression.Full => classLevel,
		CasterProgression.Half => ruleset == RulesetVersion.Dnd5e_2014 && classLevel < 2 ? 0 : (classLevel + 1) / 2,
		CasterProgression.Third => classLevel < 3 ? 0 : (classLevel + 2) / 3,
		_ => 0
	};

	///	<summary>
	///	Contribution of a class to the multiclass spellcaster level: half casters round down (2014) or up (2024),
	///	third casters round down.
	///	</summary>
	public static int MulticlassCasterLevel(CasterProgression progression, int classLevel, RulesetVersion ruleset) => progression switch
	{
		CasterProgression.Full => classLevel,
		CasterProgression.Half => ruleset == RulesetVersion.Dnd5e_2024 ? (classLevel + 1) / 2 : classLevel / 2,
		CasterProgression.Third => classLevel / 3,
		_ => 0
	};

	// ===== Species (races) =====

	///	<summary>
	///	2014 racial increases (fixed part) and how many +1 the player chooses (half-elf and variant human two,
	///	not on the abilities already raised by the race).
	///	</summary>
	public static (int[] Fixed, int Choices) RacialIncreases2014(ContextSpecies? species, ContextSubspecies? subspecies)
	{
		var bonus = new int[6];
		void Add(AbilityScore a, int value) => bonus[(int)a - 1] += value;

		switch (species?.Key)
		{
			case "dwarf": Add(AbilityScore.Constitution, 2); break;
			case "elf": Add(AbilityScore.Dexterity, 2); break;
			case "halfling": Add(AbilityScore.Dexterity, 2); break;
			case "dragonborn": Add(AbilityScore.Strength, 2); Add(AbilityScore.Charisma, 1); break;
			case "gnome": Add(AbilityScore.Intelligence, 2); break;
			case "half-elf": Add(AbilityScore.Charisma, 2); break;
			case "half-orc": Add(AbilityScore.Strength, 2); Add(AbilityScore.Constitution, 1); break;
			case "tiefling": Add(AbilityScore.Charisma, 2); Add(AbilityScore.Intelligence, 1); break;
		}

		switch (subspecies?.Key)
		{
			case "hill-dwarf": Add(AbilityScore.Wisdom, 1); break;
			case "mountain-dwarf": Add(AbilityScore.Strength, 2); break;
			case "high-elf": Add(AbilityScore.Intelligence, 1); break;
			case "wood-elf": Add(AbilityScore.Wisdom, 1); break;
			case "dark-elf": Add(AbilityScore.Charisma, 1); break;
			case "lightfoot": Add(AbilityScore.Charisma, 1); break;
			case "stout": Add(AbilityScore.Constitution, 1); break;
			case "forest-gnome": Add(AbilityScore.Dexterity, 1); break;
			case "rock-gnome": Add(AbilityScore.Constitution, 1); break;
			case "standard-human": Array.Fill(bonus, 1); break;
		}

		var choices = species?.Key == "half-elf" || subspecies?.Key == "variant-human" ? 2 : 0;
		return (bonus, choices);
	}

	public static bool IsBaseRace2014(ContextSpecies? species) => species?.Key is not null;

	///	<summary>
	///	Skills of the species traits: fixed ones and how many to choose (from <c>Options</c>, or any skill when null).
	///	</summary>
	public static (IReadOnlyList<Skill> Fixed, int Choices, IReadOnlyList<Skill>? Options) SpeciesSkills(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies)
	{
		if (ruleset == RulesetVersion.Dnd5e_2014)
		{
			return (species?.Key, subspecies?.Key) switch
			{
				("elf", _) => (new[] { Skill.Perception }, 0, null),
				("half-orc", _) => (new[] { Skill.Intimidation }, 0, null),
				("half-elf", _) => (Array.Empty<Skill>(), 2, null),
				(_, "variant-human") => (Array.Empty<Skill>(), 1, null),
				_ => (Array.Empty<Skill>(), 0, null)
			};
		}

		return species?.Key switch
		{
			"human" => (Array.Empty<Skill>(), 1, null),
			"elf" => (Array.Empty<Skill>(), 1, new[] { Skill.Insight, Skill.Perception, Skill.Survival }),
			_ => (Array.Empty<Skill>(), 0, null)
		};
	}

	//	2014 variant human and 2024 human (Versatile): a feat (2024: an Origin feat)
	public static bool SpeciesGrantsFeat(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies) =>
		ruleset == RulesetVersion.Dnd5e_2024 ? species?.Key == "human" : subspecies?.Key == "variant-human";

	//	2014 high elf: one cantrip of the wizard list
	public static int SpeciesCantrips(RulesetVersion ruleset, ContextSubspecies? subspecies) =>
		ruleset == RulesetVersion.Dnd5e_2014 && subspecies?.Key == "high-elf" ? 1 : 0;

	///	<summary>
	///	2014 racial languages (Common plus the race's own) and the extra ones to choose. 2024: Common and two
	///	languages of the Standard Languages table for everyone.
	///	</summary>
	public static (IReadOnlyList<string> Fixed, int Choices) SpeciesLanguages(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies)
	{
		if (ruleset == RulesetVersion.Dnd5e_2024)
		{
			return (new[] { CharacterLanguages.Common }, 2);
		}

		var own = species?.Key switch
		{
			"dwarf" => "dwarvish",
			"elf" or "half-elf" => "elvish",
			"halfling" => "halfling",
			"dragonborn" => "draconic",
			"gnome" => "gnomish",
			"half-orc" => "orc",
			"tiefling" => "infernal",
			_ => null
		};
		var choices = species?.Key switch
		{
			"human" => 1,
			"half-elf" => 1,
			null => 0,
			_ => 0
		} + (subspecies?.Key == "high-elf" ? 1 : 0);

		//	Homebrew races: Common and two of choice
		if (species is not null && species.Key is null)
		{
			return (new[] { CharacterLanguages.Common }, 2);
		}

		return (own is null ? new[] { CharacterLanguages.Common } : new[] { CharacterLanguages.Common, own }, choices);
	}

	//	Hill dwarf (2014) and dwarf (2024) Dwarven Toughness: +1 hit point per level
	public static int SpeciesHitPointsPerLevel(RulesetVersion ruleset, ContextSpecies? species, ContextSubspecies? subspecies) =>
		ruleset == RulesetVersion.Dnd5e_2024 ? (species?.Key == "dwarf" ? 1 : 0) : (subspecies?.Key == "hill-dwarf" ? 1 : 0);

	//	2014 dwarves: speed not reduced by heavy armor
	public static bool IgnoresHeavyArmorSpeed(RulesetVersion ruleset, ContextSpecies? species) =>
		ruleset == RulesetVersion.Dnd5e_2014 && species?.Key == "dwarf";

	// ===== Feats =====

	public static bool IsRepeatable(ContextFeat feat) => feat.Key == "ability-score-improvement";

	public static int FeatSkillChoices(ContextFeat feat, RulesetVersion ruleset) => feat.Key switch
	{
		"skilled" => 3,
		"skill-expert" => 1,
		//	2024: proficiency, or Expertise when already proficient
		"keen-mind" or "observant" when ruleset == RulesetVersion.Dnd5e_2024 => 1,
		_ => 0
	};

	public static IReadOnlyList<Skill>? FeatSkillOptions(ContextFeat feat, RulesetVersion ruleset) => (feat.Key, ruleset) switch
	{
		("keen-mind", RulesetVersion.Dnd5e_2024) => new[] { Skill.Arcana, Skill.History, Skill.Investigation, Skill.Nature, Skill.Religion },
		("observant", RulesetVersion.Dnd5e_2024) => new[] { Skill.Insight, Skill.Investigation, Skill.Perception },
		_ => null
	};

	//	Skill Expert (2024): Expertise in one skill you are proficient in
	public static int FeatExpertise(ContextFeat feat) => feat.Key == "skill-expert" ? 1 : 0;

	public static int FeatLanguages(ContextFeat feat) => feat.Key == "linguist" ? 3 : 0;

	public static bool IsMagicInitiate(ContextFeat feat) => feat.Key == "magic-initiate";

	public static IReadOnlyList<SpellcastingClass> MagicInitiateLists(RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2024
		? new[] { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard }
		: new[] { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard };

	//	2014: the spellcasting ability of the chosen class; 2024: Intelligence, Wisdom or Charisma
	public static AbilityScore MagicInitiateAbility2014(SpellcastingClass list) => list switch
	{
		SpellcastingClass.Cleric or SpellcastingClass.Druid => AbilityScore.Wisdom,
		SpellcastingClass.Wizard => AbilityScore.Intelligence,
		_ => AbilityScore.Charisma
	};

	public static ArmorTraining FeatArmor(ContextFeat feat) => feat.Key switch
	{
		"lightly-armored" => ArmorTraining.Light,
		"moderately-armored" => ArmorTraining.Medium | ArmorTraining.Shield,
		"heavily-armored" => ArmorTraining.Heavy,
		_ => ArmorTraining.None
	};

	public static bool FeatMartialWeapons(ContextFeat feat) => feat.Key == "martial-weapon-training";
}
