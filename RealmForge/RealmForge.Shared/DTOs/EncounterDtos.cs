using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	public record EncounterSummaryDto(
		Guid Id,
		string Name,
		EncounterStatus Status,
		int Round,
		int Monsters,
		int MonsterXp,
		bool Shown,
		DateTimeOffset UpdatedAt);

	///	<summary>
	///	A character of the campaign, for the party of an encounter.
	///	</summary>
	public record EncounterPartyMemberDto(Guid CharacterId, string Name, int Level, string OwnerName);

	///	<summary>
	///	An encounter. For the players (CanManage false) the hidden combatants are left out, the notes are empty and the
	///	monsters show Health instead of hit points and armor class. Version grows at every save: a save with an older
	///	version answers 409 (someone else changed it meanwhile).
	///	</summary>
	public record EncounterDto(
		Guid Id,
		Guid CampaignId,
		string Name,
		string Notes,
		EncounterStatus Status,
		int Round,
		Guid? CurrentId,
		bool Shown,
		List<EncounterCombatant> Combatants,
		List<Guid> PartyIds,
		List<EncounterPartyMemberDto> Characters,
		bool CanManage,
		RulesetVersion? Ruleset,
		int Version,
		DateTimeOffset UpdatedAt);

	public class SaveEncounterDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Notes { get; set; }
		public EncounterStatus Status { get; set; } = EncounterStatus.Planned;
		public int Round { get; set; }

		//	The combatant whose turn it is
		public Guid? CurrentId { get; set; }
		public bool Shown { get; set; }
		public List<EncounterCombatant> Combatants { get; set; } = new();

		//	The characters the difficulty is computed for
		public List<Guid> PartyIds { get; set; } = new();

		//	Version the client started from (null: overwrite)
		public int? Version { get; set; }
	}
}
