using RealmForge.Shared.Campaigns;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A session of the campaign: number, title, date, status, the plan (what the players should know beforehand), the
	///	recap and, for masters and co-masters only, their notes (null for the players).
	///	</summary>
	public record CampaignSessionDto(
		Guid Id,
		int Number,
		string Title,
		DateTimeOffset? ScheduledAt,
		CampaignSessionStatus Status,
		string Plan,
		string Recap,
		string? MasterNotes,
		string UpdatedBy,
		DateTimeOffset UpdatedAt,
		bool CanEdit);

	public class SaveCampaignSessionDto
	{
		public string Title { get; set; } = string.Empty;
		public DateTimeOffset? ScheduledAt { get; set; }
		public CampaignSessionStatus Status { get; set; } = CampaignSessionStatus.Planned;
		public string Plan { get; set; } = string.Empty;
		public string Recap { get; set; } = string.Empty;
		public string MasterNotes { get; set; } = string.Empty;
	}

	///	<summary>
	///	A die of a shared roll (Dropped: left out by advantage, disadvantage or keep).
	///	</summary>
	public record RollDieDto(int Sides, int Value, bool Dropped = false);

	///	<summary>
	///	A roll in the dice log of the campaign: who rolled it (and for which character), what for, the dice and the total.
	///	Hidden rolls are seen only by the masters and by whoever rolled them.
	///	</summary>
	public record CampaignRollDto(
		Guid Id,
		string Roller,
		string? CharacterName,
		string Label,
		string Expression,
		List<RollDieDto> Dice,
		int Modifier,
		int Total,
		string? Note,
		bool Hidden,
		bool IsMine,
		DateTimeOffset CreatedAt);

	///	<summary>
	///	A new roll. With Expression and no Dice the server rolls it (the shared roller of the campaign page); a roll made on
	///	a character sheet sends its dice, modifier and total, with the character it was made for.
	///	</summary>
	public class NewCampaignRollDto
	{
		public string? Label { get; set; }
		public string? Expression { get; set; }
		public Guid? CharacterId { get; set; }
		public List<RollDieDto>? Dice { get; set; }
		public int Modifier { get; set; }
		public int? Total { get; set; }
		public string? Note { get; set; }
		public bool Hidden { get; set; }
	}
}
