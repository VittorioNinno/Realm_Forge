namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	The soundboard of a campaign (the masters') and the track playing at the table.
	///	</summary>
	public record CampaignSoundboardDto(List<CampaignSoundDto> Sounds, Guid? Playing, List<SoundSceneDto>? Scenes = null, Guid? PlayingScene = null, long StorageUsed = 0, long StorageMax = 0);

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

	///	<summary>
	///	Audio files uploaded for a soundboard: their limits, and what a file is from its first bytes (the name and the
	///	type the browser declares are not trusted).
	///	</summary>
	public static class SoundFiles
	{
		//	The link of a sound whose audio is an uploaded file: "rf-file:{id}"
		public const string Prefix = "rf-file:";
		public const int MaxFileBytes = 4 * 1024 * 1024;
		public const long MaxCampaignBytes = 30L * 1024 * 1024;
		public const string Accept = ".mp3,.ogg,.oga,.m4a,.wav,audio/mpeg,audio/ogg,audio/mp4,audio/x-m4a,audio/wav";

		public static bool IsFile(string? url) => url is not null && url.StartsWith(Prefix, StringComparison.Ordinal);

		public static Guid? FileId(string? url) => IsFile(url) && Guid.TryParse(url![Prefix.Length..], out var id) ? id : null;

		//	The content type of an mp3, ogg, m4a or wav file from its first bytes; null for anything else
		public static string? Sniff(ReadOnlySpan<byte> head)
		{
			if (head.Length < 12)
			{
				return null;
			}
			//	ID3 tag, or an MPEG audio frame sync (11 bits set) of layer III
			if ((head[0] == 'I' && head[1] == 'D' && head[2] == '3') || (head[0] == 0xFF && (head[1] & 0xE0) == 0xE0 && (head[1] & 0x06) == 0x02))
			{
				return "audio/mpeg";
			}
			if (head[0] == 'O' && head[1] == 'g' && head[2] == 'g' && head[3] == 'S')
			{
				return "audio/ogg";
			}
			if (head[0] == 'R' && head[1] == 'I' && head[2] == 'F' && head[3] == 'F' && head[8] == 'W' && head[9] == 'A' && head[10] == 'V' && head[11] == 'E')
			{
				return "audio/wav";
			}
			//	An MPEG-4 container ("ftyp" box): m4a audio
			if (head[4] == 'f' && head[5] == 't' && head[6] == 'y' && head[7] == 'p')
			{
				return "audio/mp4";
			}
			return null;
		}

		public static string Megabytes(long bytes) => (bytes / 1024d / 1024d).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
	}

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
