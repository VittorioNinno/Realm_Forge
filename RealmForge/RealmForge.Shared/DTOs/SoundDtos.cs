namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The soundboard of a campaign (the masters') and the track playing at the table.
	///	</summary>
	public record CampaignSoundboardDto(List<CampaignSoundDto> Sounds, Guid? Playing);

	//	A link to an audio file or stream: a track that loops, or an effect played once
	public record CampaignSoundDto(Guid Id, string Name, string Url, bool Effect, int Volume);

	public class SaveCampaignSoundDto
	{
		public string Name { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public bool Effect { get; set; }
		public int Volume { get; set; } = 80;
	}

	///	<summary>
	///	What the table plays: the track (from TrackAt, to keep every screen in time) and the last effect (CueAt: each
	///	screen plays it once).
	///	</summary>
	public record MapSoundDto(Guid? TrackId, string? TrackUrl, int TrackVolume, DateTimeOffset? TrackAt, Guid? CueId, string? CueUrl, int CueVolume, DateTimeOffset? CueAt);
}
