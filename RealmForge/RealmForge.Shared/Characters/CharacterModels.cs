using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Every rules choice of a character, stored as one JSON document: origin, ability scores, the classes and each level
///	taken (hit points, increases, feats), proficiencies, languages, spells and the starting equipment. Names are never
///	stored: they come from the compendium in the reader's language. Ability arrays are in the order Strength, Dexterity,
///	Constitution, Intelligence, Wisdom, Charisma.
///	</summary>
public sealed class CharacterBuild
{
	public Alignment Alignment { get; set; } = Alignment.Neutral;
	public CreatureSize Size { get; set; } = CreatureSize.Medium;

	public AbilityMethod AbilityMethod { get; set; } = AbilityMethod.StandardArray;
	public List<int> BaseScores { get; set; } = new();

	//	Origin increases: from the background (2024) or the free part of the race (2014, e.g. the half-elf's two +1)
	public AbilityBonusMode BonusMode { get; set; } = AbilityBonusMode.TwoAndOne;
	public List<AbilityScore> BonusChoices { get; set; } = new();

	//	Species / race: skills of its traits, the feat of the 2024 human and 2014 variant human, the high elf cantrip
	public List<Skill> SpeciesSkills { get; set; } = new();
	public Guid? SpeciesFeatId { get; set; }
	public FeatChoice SpeciesFeat { get; set; } = new();
	public List<Guid> SpeciesCantrips { get; set; } = new();

	//	Choices of the background's origin feat (2024), e.g. the spells of Magic Initiate
	public FeatChoice OriginFeat { get; set; } = new();

	public List<string> Languages { get; set; } = new();

	//	First entry: the starting class. Levels[0] is character level 1
	public List<CharacterClassBuild> Classes { get; set; } = new();
	public List<CharacterLevelBuild> Levels { get; set; } = new();

	//	Starting equipment (only when the character is created): "A"/"B" for the background, the kit letter or one
	//	letter per line for the class ("" for fixed lines), and the specific items picked for "any simple weapon"
	public string? BackgroundEquipment { get; set; }
	public List<string> ClassEquipment { get; set; } = new();
	public List<EquipmentPick> EquipmentPicks { get; set; } = new();
}

///	<summary>
///	Choices made in one class.
///	</summary>
public sealed class CharacterClassBuild
{
	public Guid ClassId { get; set; }
	public Guid? SubclassId { get; set; }

	//	Starting class: the class skills; other classes: the skill of the multiclass proficiencies (bard, ranger, rogue)
	public List<Skill> Skills { get; set; } = new();
	public List<Skill> Expertise { get; set; } = new();

	public List<Guid> Cantrips { get; set; } = new();
	public List<Guid> Spells { get; set; } = new();

	//	Wizard: the spellbook (level 1+ spells known; Spells are the ones prepared from it) and the spells copied
	//	into it from scrolls or other books, which do not count against the two free spells per level
	public List<Guid> Spellbook { get; set; } = new();
	public List<Guid> SpellbookCopied { get; set; } = new();

	//	2014: key of the Fighting Style option; 2024: a Fighting Style feat or the paladin's / ranger's alternative
	public string? FightingStyle { get; set; }
	public Guid? FightingStyleFeatId { get; set; }
	public List<Guid> StyleCantrips { get; set; } = new();

	//	2024 cleric Divine Order / druid Primal Order
	public string? Order { get; set; }

	public List<Guid> WeaponMasteries { get; set; } = new();
}

///	<summary>
///	One character level: the class it was taken in, the hit die roll (null = fixed value; level 1 always takes the
///	maximum) and, at the levels that grant it, the Ability Score Improvement or the feat chosen.
///	</summary>
public sealed class CharacterLevelBuild
{
	public Guid ClassId { get; set; }
	public int? HitPointRoll { get; set; }

	//	2014 plain Ability Score Improvement: two entries (the same ability twice for +2)
	public List<AbilityScore> Increases { get; set; } = new();

	public Guid? FeatId { get; set; }
	public FeatChoice Feat { get; set; } = new();
}

///	<summary>
///	Choices of a feat: the abilities it increases (+1 each; the 2024 Ability Score Improvement takes two entries),
///	skills and expertise it grants (Skill Expert), the spells of Magic Initiate, the languages of Linguist.
///	</summary>
public sealed class FeatChoice
{
	public List<AbilityScore> Increases { get; set; } = new();
	public List<Skill> Skills { get; set; } = new();
	public List<Skill> Expertise { get; set; } = new();
	public SpellcastingClass? SpellList { get; set; }
	public AbilityScore? SpellcastingAbility { get; set; }
	public List<Guid> Cantrips { get; set; } = new();
	public List<Guid> Spells { get; set; } = new();
	public List<string> Languages { get; set; } = new();
}

///	<summary>
///	Item picked for a generic line of starting equipment ("any martial melee weapon"). Slot: "class/0/1/2" or
///	"background/0/0/1" (row or kit, option, item).
///	</summary>
public sealed class EquipmentPick
{
	public string Slot { get; set; } = string.Empty;
	public List<Guid> Items { get; set; } = new();
}

///	<summary>
///	Everything that changes at the table: hit points, resources, conditions, inventory, coins, notes. Saved as the
///	player uses the sheet, without touching the rules choices.
///	</summary>
public sealed class CharacterSheetState
{
	//	Null: at the maximum
	public int? CurrentHitPoints { get; set; }
	public int TemporaryHitPoints { get; set; }
	public int MaxHitPointsAdjustment { get; set; }
	public int ArmorClassAdjustment { get; set; }
	public int SpeedAdjustment { get; set; }
	public int InitiativeAdjustment { get; set; }

	//	Hit dice spent, by die size ("8" → 2)
	public Dictionary<int, int> HitDiceSpent { get; set; } = new();
	public int DeathSaveSuccesses { get; set; }
	public int DeathSaveFailures { get; set; }
	public List<string> Conditions { get; set; } = new();
	public int Exhaustion { get; set; }
	public bool Inspiration { get; set; }

	//	Spell the character is concentrating on (ends on its own at 0 hit points)
	public Guid? Concentration { get; set; }

	//	Raised each time a master changes hit points or conditions from an encounter: a sheet saved from an older
	//	stamp keeps the values of the encounter (see SheetVitals)
	public int VitalsStamp { get; set; }

	//	Spent spell slots per spell level (index 0 = level 1) and spent Pact Magic slots
	public List<int> SpentSlots { get; set; } = new();
	public int SpentPactSlots { get; set; }

	public List<InventoryItem> Inventory { get; set; } = new();
	public CoinPurse Coins { get; set; } = new();
	public List<ResourceCounter> Resources { get; set; } = new();

	//	Uses spent of the class resources the sheet computes on its own (key of CharacterResources → spent)
	public Dictionary<string, int> ResourceUses { get; set; } = new();

	//	Changes of spells the rules allow right now (after a long rest, after a level), and the class levels the
	//	sheet has already seen, to notice a level up
	public List<SpellChangeGrant> SpellChanges { get; set; } = new();
	public Dictionary<string, int> ClassLevelsSeen { get; set; } = new();

	public int Experience { get; set; }

	//	How the character gains levels: experience points or story milestones decided by the game master
	public AdvancementType Advancement { get; set; } = AdvancementType.Experience;

	//	Identity card of the sheet: portrait (a small data URL made in the browser) and personal details
	public string? Portrait { get; set; }

	//	Where the portrait sits in its square frame, as CSS background-position percentages (null: centred)
	public int? PortraitX { get; set; }
	public int? PortraitY { get; set; }
	public string? Age { get; set; }
	public string? Gender { get; set; }
	public string? Faith { get; set; }
	public string? Height { get; set; }
	public string? Weight { get; set; }

	public string? Traits { get; set; }
	public string? Ideals { get; set; }
	public string? Bonds { get; set; }
	public string? Flaws { get; set; }
	public string? Appearance { get; set; }
	public string? Backstory { get; set; }
	public string? Allies { get; set; }
	public string? Notes { get; set; }

	//	Proficiencies from features the sheet does not automate (subclass skills, tools…)
	public List<Skill> ExtraSkills { get; set; } = new();
	public List<Skill> ExtraExpertise { get; set; } = new();
	public List<AbilityScore> ExtraSaves { get; set; } = new();
	public string? OtherProficiencies { get; set; }
	public string? FeatureNotes { get; set; }
}

public sealed class InventoryItem
{
	public Guid Id { get; set; } = Guid.NewGuid();

	//	Compendium item (its name follows the reader's language) or a free entry with its own name
	public Guid? EquipmentId { get; set; }
	public string? Name { get; set; }
	public int Quantity { get; set; } = 1;
	public bool Equipped { get; set; }
	public bool Attuned { get; set; }
	public string? Notes { get; set; }

	//	Magic properties (a +1 sword, a Ring of Protection, a potion…): null for an ordinary item
	public MagicItemProperties? Magic { get; set; }
}

public enum ItemRarity
{
	Common = 1,
	Uncommon = 2,
	Rare = 3,
	VeryRare = 4,
	Legendary = 5,
	Artifact = 6
}

public enum ItemRecharge
{
	None = 0,

	//	"At dawn" in the item texts: the sheet recharges it with the long rest
	LongRest = 1,
	ShortRest = 2
}

public enum MagicEffectKind
{
	ArmorClass = 1,
	UnarmoredArmorClass = 2,
	AttackAndDamage = 3,
	SavingThrows = 4,
	AbilityChecks = 5,
	SetAbilityScore = 6,
	AbilityScoreBonus = 7,
	Speed = 8,
	SpellAttack = 9,
	SpellSaveDc = 10,
	MaxHitPoints = 11,
	Initiative = 12,
	Resistance = 13
}

///	<summary>
///	One rule effect of a magic item, applied by the calculator while the item works (worn or wielded, and attuned
///	when it needs attunement).
///	</summary>
public sealed class MagicEffect
{
	public MagicEffectKind Kind { get; set; }
	public int Value { get; set; }
	public AbilityScore? Ability { get; set; }
	public DamageType? DamageType { get; set; }
}

public sealed class MagicItemProperties
{
	public ItemRarity Rarity { get; set; } = ItemRarity.Uncommon;
	public bool RequiresAttunement { get; set; }
	public List<MagicEffect> Effects { get; set; } = new();

	//	Charges (wands, staffs): spent ones and how they come back ("1d6+1" regained, or all when empty)
	public int Charges { get; set; }
	public int ChargesUsed { get; set; }
	public ItemRecharge Recharge { get; set; }
	public string? RechargeDice { get; set; }

	//	Consumable that restores hit points (potions of healing): "2d4+2"
	public string? HealDice { get; set; }

	//	Template it was made from (MagicItemCatalog), to show its rules text in our own words
	public string? Template { get; set; }
}

public sealed class CoinPurse
{
	public int Cp { get; set; }
	public int Sp { get; set; }
	public int Ep { get; set; }
	public int Gp { get; set; }
	public int Pp { get; set; }
}

///	<summary>
///	A use counter the player tracks (Rage, Ki/Focus points, Channel Divinity…), reset by a short or a long rest.
///	</summary>
public sealed class ResourceCounter
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = string.Empty;
	public int Maximum { get; set; } = 1;
	public int Used { get; set; }
	public bool ShortRest { get; set; }
}

public enum SpellChangeKind
{
	//	Any prepared spell can change (long rest of clerics, druids, wizards; 2014 paladins)
	All = 1,

	//	This many spells can be replaced with others
	Spell = 2,
	Cantrip = 3
}

public sealed class SpellChangeGrant
{
	public Guid ClassId { get; set; }
	public SpellChangeKind Kind { get; set; }
	public int Remaining { get; set; } = 1;
	public bool FromLongRest { get; set; }
}

public enum AdvancementType
{
	Experience = 0,
	Milestone = 1
}

public enum CoinType
{
	Cp = 1,
	Sp = 2,
	Ep = 3,
	Gp = 4,
	Pp = 5
}
