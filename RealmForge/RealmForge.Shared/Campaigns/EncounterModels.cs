namespace RealmForge.Shared.Campaigns;

public enum EncounterStatus
{
	//	Being prepared: only masters and co-masters see it
	Planned = 1,

	//	Under way: the initiative order runs
	Running = 2,

	Finished = 3
}

public enum CombatantKind
{
	Monster = 1,
	Character = 2,

	//	Anything else on the field (an NPC without a statblock, a trap, a lair)
	Other = 3
}

///	<summary>
///	How a monster looks to the players, instead of its hit points.
///	</summary>
public enum CombatantHealth
{
	Unharmed = 1,
	Wounded = 2,

	//	Half of its hit points or less
	Bloodied = 3,

	Down = 4
}

///	<summary>
///	One participant of an encounter. Monsters keep a copy of the numbers of their statblock (they stay as they were
///	when added, even if the statblock is edited later); MonsterId opens the statblock. Characters point to their sheet.
///	</summary>
public class EncounterCombatant
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public CombatantKind Kind { get; set; } = CombatantKind.Monster;
	public Guid? MonsterId { get; set; }
	public Guid? CharacterId { get; set; }
	public string Name { get; set; } = string.Empty;

	//	Null until rolled or typed
	public int? Initiative { get; set; }
	public int InitiativeBonus { get; set; }

	public int ArmorClass { get; set; }
	public int MaxHp { get; set; }
	public int Hp { get; set; }
	public int TempHp { get; set; }

	//	Experience the monster is worth (0 for characters and others)
	public int Xp { get; set; }
	public decimal? ChallengeRating { get; set; }

	//	Keys of EncounterRules.Conditions
	public List<string> Conditions { get; set; } = new();
	public string? Note { get; set; }

	//	Not shown to the players (an ambush, a hidden foe)
	public bool Hidden { get; set; }

	//	Only in the players' view, instead of the hit points
	public CombatantHealth? Health { get; set; }
}

///	<summary>
///	Who may run the encounters of a campaign, limits and the conditions a combatant can carry.
///	</summary>
public static class EncounterRules
{
	public const int MaxEncounters = 200;
	public const int MaxCombatants = 60;
	public const int MaxNameLength = 100;
	public const int MaxNotesLength = 8000;
	public const int MaxNoteLength = 300;

	public static readonly IReadOnlyList<string> Conditions = new[]
	{
		"blinded", "charmed", "deafened", "frightened", "grappled", "incapacitated", "invisible", "paralyzed",
		"petrified", "poisoned", "prone", "restrained", "stunned", "unconscious", "exhaustion", "concentrating"
	};

	//	Masters and co-masters prepare and run the encounters
	public static bool CanManage(CampaignRole role) => CampaignRules.RunsTheTable(role);

	//	The players see the encounters under way that a master showed them
	public static bool CanSee(CampaignRole role, EncounterStatus status, bool shown) =>
		CanManage(role) || (shown && status == EncounterStatus.Running);

	public static CombatantHealth HealthOf(int hp, int maxHp) =>
		hp <= 0 ? CombatantHealth.Down
		: maxHp <= 0 || hp >= maxHp ? CombatantHealth.Unharmed
		: hp * 2 <= maxHp ? CombatantHealth.Bloodied
		: CombatantHealth.Wounded;

	///	<summary>
	///	Initiative order: highest first, ties to the higher bonus; combatants without initiative go last.
	///	</summary>
	public static List<EncounterCombatant> Order(IEnumerable<EncounterCombatant> combatants) =>
		combatants
			.OrderByDescending(c => c.Initiative.HasValue)
			.ThenByDescending(c => c.Initiative ?? 0)
			.ThenByDescending(c => c.InitiativeBonus)
			.ThenBy(c => c.Kind == CombatantKind.Character ? 0 : 1)
			.ThenBy(c => c.Name, StringComparer.CurrentCultureIgnoreCase)
			.ToList();
}
