namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The soundboard of a campaign (the masters') and the track playing at the table.
	///	</summary>
	public record CampaignSoundboardDto(List<CampaignSoundDto> Sounds, Guid? Playing, List<SoundSceneDto>? Scenes = null, Guid? PlayingScene = null);

	///	<summary>
	///	A sound scene: a track, ambience loops over it (Layers) and an effect at the start (Cue); MapId: the map that
	///	starts it when shown.
	///	</summary>
	public record SoundSceneDto(Guid Id, string Name, Guid? TrackId, List<Guid> Layers, Guid? CueId, Guid? MapId);

	public class SaveSoundSceneDto
	{
		public string Name { get; set; } = string.Empty;
		public Guid? TrackId { get; set; }
		public List<Guid> Layers { get; set; } = new();
		public Guid? CueId { get; set; }
		public Guid? MapId { get; set; }
	}

	//	An ambience loop playing at the table
	public record MapSoundLayerDto(Guid Id, string Url, int Volume);

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
	public record MapSoundDto(Guid? TrackId, string? TrackUrl, int TrackVolume, DateTimeOffset? TrackAt, Guid? CueId, string? CueUrl, int CueVolume, DateTimeOffset? CueAt,
		List<MapSoundLayerDto>? Layers = null);
}
