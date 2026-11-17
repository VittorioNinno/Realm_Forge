namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The clock of a campaign (game minutes from the start of day 1) and the effects of the characters running on it.
	///	</summary>
	public record CampaignClockDto(long Minutes, List<ClockEffectDto> Effects);

	public record ClockEffectDto(Guid CharacterId, string Character, string Name, long Until);

	///	<summary>
	///	A step of the clock: Minutes on from now, or Set to a time; Rations: each day that begins eats a ration.
	///	</summary>
	public class MoveClockDto
	{
		public int Minutes { get; set; }
		public long? Set { get; set; }
		public bool Rations { get; set; }
	}

	//	What the step did: the time now, the days begun, the effects ended, the characters without rations for some days
	public record ClockMovedDto(long Minutes, int Days, List<ClockEffectDto> Expired, List<ClockHungerDto> Hungry);

	public record ClockHungerDto(Guid CharacterId, string Character, int Days);
}
