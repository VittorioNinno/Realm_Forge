namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The progress clocks and the factions of a campaign (a player: the shown ones).
	///	</summary>
	public record CampaignProgressDto(List<ProgressClockDto> Clocks, List<FactionDto> Factions);

	public record ProgressClockDto(Guid Id, string Name, int Segments, int Filled, bool Shown, string Color, int? TickHours);

	//	PricePercent: what the shops tied to it charge, as a percentage of their own prices
	public record FactionDto(Guid Id, string Name, string Description, int Standing, bool Shown, int PricePercent);

	public class SaveProgressClockDto
	{
		public string Name { get; set; } = string.Empty;
		public int Segments { get; set; } = 6;
		public int Filled { get; set; }
		public bool Shown { get; set; }
		public string? Color { get; set; }
		public int? TickHours { get; set; }
	}

	public class SaveFactionDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Standing { get; set; }
		public bool Shown { get; set; } = true;
	}

	//	A step of a clock or of a standing (+1, -1)
	public class StepDto
	{
		public int Delta { get; set; } = 1;
	}
}
