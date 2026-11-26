using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The soundboard of a campaign: links to audio files or streams hosted elsewhere, or audio files the masters upload
	///	(kept in the database: up to 4 MB each, 30 MB a campaign), as tracks that loop (music, ambience) or one-shot effects. A master plays one and every screen at the table follows: the
	///	track in time with its start, the effect once.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/sounds")]
	[Authorize]
	public class SoundsController : ControllerBase
	{
		public const int MaxSounds = 60;
		public const int MaxScenes = 30;
		public const int MaxLayers = 4;

		private readonly RealmForgeDbContext _context;

		public SoundsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/sounds — the masters' soundboard, with what is playing
		[HttpGet]
		public async Task<ActionResult<CampaignSoundboardDto>> GetSounds(Guid campaignId)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			var sounds = await _context.CampaignSounds.AsNoTracking().Where(s => s.CampaignId == campaignId).OrderBy(s => s.Effect).ThenBy(s => s.Name).ToListAsync();
			var playing = await _context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId).Select(c => new { c.SoundTrackId, c.SoundSceneId }).FirstAsync();
			var scenes = await _context.CampaignSoundScenes.AsNoTracking().Where(s => s.CampaignId == campaignId).OrderBy(s => s.Name).ToListAsync();
			var used = await StorageUsedAsync(campaignId);
			return Ok(new CampaignSoundboardDto(sounds.Select(ToDto).ToList(), playing.SoundTrackId, scenes.Select(ToDto).ToList(), playing.SoundSceneId, used, SoundFiles.MaxCampaignBytes));
		}

		//	POST: api/campaigns/{campaignId}/sounds
		[HttpPost]
		public async Task<ActionResult<CampaignSoundDto>> AddSound(Guid campaignId, [FromBody] SaveCampaignSoundDto dto)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			if (await _context.CampaignSounds.CountAsync(s => s.CampaignId == campaignId) >= MaxSounds)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxSounds} sounds per campaign.");
			}
			var sound = new CampaignSound { CampaignId = campaignId };
			Apply(sound, dto);
			_context.CampaignSounds.Add(sound);
			await _context.SaveChangesAsync();
			return Ok(ToDto(sound));
		}

		//	POST: api/campaigns/{campaignId}/sounds/file — a sound from an audio file of the master's device (multipart: file,
		//	name, effect, volume): mp3, ogg, m4a or wav by its content, up to 4 MB, within the 30 MB of the campaign
		[HttpPost("file")]
		[RequestSizeLimit(SoundFiles.MaxFileBytes + 64 * 1024)]
		[RequestFormLimits(MultipartBodyLengthLimit = SoundFiles.MaxFileBytes + 64 * 1024)]
		public async Task<ActionResult<CampaignSoundDto>> UploadSound(Guid campaignId, IFormFile? file, [FromForm] string? name, [FromForm] bool effect, [FromForm] int volume = 80)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			var title = (name ?? string.Empty).Trim();
			if (file is null || file.Length is 0 || title.Length is 0 or > 80 || volume is < 0 or > 100)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 80 characters, an audio file, a volume from 0 to 100.");
			}
			if (file.Length > SoundFiles.MaxFileBytes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "An audio file up to 4 MB.");
			}
			if (await _context.CampaignSounds.CountAsync(s => s.CampaignId == campaignId) >= MaxSounds)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxSounds} sounds per campaign.");
			}
			if (await StorageUsedAsync(campaignId) + file.Length > SoundFiles.MaxCampaignBytes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The audio files of this campaign would pass 30 MB: remove some first.");
			}
			byte[] data;
			using (var stream = new MemoryStream((int)file.Length))
			{
				await file.CopyToAsync(stream);
				data = stream.ToArray();
			}
			if (SoundFiles.Sniff(data) is not { } type)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "An mp3, ogg, m4a or wav file.");
			}
			var stored = new CampaignSoundFile { CampaignId = campaignId, ContentType = type, Size = data.Length, Data = data };
			var sound = new CampaignSound { CampaignId = campaignId, Name = title, Url = SoundFiles.Prefix + stored.Id, Effect = effect, Volume = volume };
			_context.CampaignSoundFiles.Add(stored);
			_context.CampaignSounds.Add(sound);
			await _context.SaveChangesAsync();
			return Ok(ToDto(sound));
		}

		//	PUT: api/campaigns/{campaignId}/sounds/{id}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateSound(Guid campaignId, Guid id, [FromBody] SaveCampaignSoundDto dto)
		{
			var (sound, error) = await MastersSoundAsync(campaignId, id);
			if (sound is null)
			{
				return error!;
			}
			if (Validate(dto, sound.Url) is { } invalid)
			{
				return invalid;
			}
			Apply(sound, dto);
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/sounds/{id} — stops it when it is playing
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteSound(Guid campaignId, Guid id)
		{
			var (sound, error) = await MastersSoundAsync(campaignId, id);
			if (sound is null)
			{
				return error!;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			if (campaign.SoundTrackId == id)
			{
				campaign.SoundTrackId = null;
				campaign.SoundTrackAt = null;
			}
			if (campaign.SoundCueId == id)
			{
				campaign.SoundCueId = null;
				campaign.SoundCueAt = null;
			}
			campaign.SoundLayers = JoinIds(SplitIds(campaign.SoundLayers).Where(l => l != id));
			foreach (var scene in await _context.CampaignSoundScenes.Where(s => s.CampaignId == campaignId).ToListAsync())
			{
				scene.TrackId = scene.TrackId == id ? null : scene.TrackId;
				scene.CueId = scene.CueId == id ? null : scene.CueId;
				scene.Layers = JoinIds(SplitIds(scene.Layers).Where(l => l != id)) ?? string.Empty;
			}
			if (SoundFiles.FileId(sound.Url) is { } fileId)
			{
				await _context.CampaignSoundFiles.Where(f => f.Id == fileId && f.CampaignId == campaignId).ExecuteDeleteAsync();
			}
			_context.CampaignSounds.Remove(sound);
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/sounds/{id}/play — a track becomes the one of the table (from its start), an
		//	effect sounds once on every screen
		[HttpPost("{id:guid}/play")]
		public async Task<IActionResult> Play(Guid campaignId, Guid id)
		{
			var (sound, error) = await MastersSoundAsync(campaignId, id);
			if (sound is null)
			{
				return error!;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			var now = DateTimeOffset.UtcNow;
			if (sound.Effect)
			{
				campaign.SoundCueId = sound.Id;
				campaign.SoundCueAt = now;
			}
			else
			{
				//	A track on its own ends the scene playing
				campaign.SoundTrackId = sound.Id;
				campaign.SoundTrackAt = now;
				campaign.SoundLayers = null;
				campaign.SoundSceneId = null;
			}
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/sounds/stop — silence at the table
		[HttpPost("stop")]
		public async Task<IActionResult> Stop(Guid campaignId)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			campaign.SoundTrackId = null;
			campaign.SoundTrackAt = null;
			campaign.SoundLayers = null;
			campaign.SoundSceneId = null;
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ----- Scenes -----

		//	POST: api/campaigns/{campaignId}/sounds/scenes
		[HttpPost("scenes")]
		public async Task<ActionResult<SoundSceneDto>> AddScene(Guid campaignId, [FromBody] SaveSoundSceneDto dto)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (await _context.CampaignSoundScenes.CountAsync(s => s.CampaignId == campaignId) >= MaxScenes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxScenes} scenes per campaign.");
			}
			var scene = new CampaignSoundScene { CampaignId = campaignId };
			if (await ApplyAsync(scene, dto) is { } error)
			{
				return error;
			}
			_context.CampaignSoundScenes.Add(scene);
			await _context.SaveChangesAsync();
			return Ok(ToDto(scene));
		}

		//	PUT: api/campaigns/{campaignId}/sounds/scenes/{id}
		[HttpPut("scenes/{id:guid}")]
		public async Task<IActionResult> UpdateScene(Guid campaignId, Guid id, [FromBody] SaveSoundSceneDto dto)
		{
			var (scene, error) = await MastersSceneAsync(campaignId, id);
			if (scene is null)
			{
				return error!;
			}
			if (await ApplyAsync(scene, dto) is { } invalid)
			{
				return invalid;
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{campaignId}/sounds/scenes/{id} — what it plays goes on until stopped
		[HttpDelete("scenes/{id:guid}")]
		public async Task<IActionResult> DeleteScene(Guid campaignId, Guid id)
		{
			var (scene, error) = await MastersSceneAsync(campaignId, id);
			if (scene is null)
			{
				return error!;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			if (campaign.SoundSceneId == id)
			{
				campaign.SoundSceneId = null;
			}
			_context.CampaignSoundScenes.Remove(scene);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/sounds/scenes/{id}/play — the track, the loops and the effect at once
		[HttpPost("scenes/{id:guid}/play")]
		public async Task<IActionResult> PlayScene(Guid campaignId, Guid id)
		{
			var (scene, error) = await MastersSceneAsync(campaignId, id);
			if (scene is null)
			{
				return error!;
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			Start(campaign, scene);
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	A scene starts at the table: its track from now (none: silence under the loops), its loops, its effect once
		public static void Start(Campaign campaign, CampaignSoundScene scene)
		{
			var now = DateTimeOffset.UtcNow;
			campaign.SoundTrackId = scene.TrackId;
			campaign.SoundTrackAt = now;
			campaign.SoundLayers = JoinIds(SplitIds(scene.Layers));
			campaign.SoundSceneId = scene.Id;
			if (scene.CueId is { } cue)
			{
				campaign.SoundCueId = cue;
				campaign.SoundCueAt = now;
			}
		}

		//	The scene tied to a map, started when the map is shown (nothing when none is, or it is already playing)
		public static async Task StartForMapAsync(RealmForgeDbContext context, Campaign campaign, Guid mapId)
		{
			var scene = await context.CampaignSoundScenes.AsNoTracking().Where(s => s.CampaignId == campaign.Id && s.MapId == mapId).OrderBy(s => s.CreatedAt).FirstOrDefaultAsync();
			if (scene is not null && campaign.SoundSceneId != scene.Id)
			{
				Start(campaign, scene);
			}
		}

		public static List<Guid> SplitIds(string? ids) =>
			(ids ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => Guid.TryParse(i, out var g) ? g : Guid.Empty).Where(g => g != Guid.Empty).Distinct().ToList();

		private static string? JoinIds(IEnumerable<Guid> ids)
		{
			var list = ids.Distinct().ToList();
			return list.Count == 0 ? null : string.Join(',', list);
		}

		//	What the table plays: the track (with its start) and the last effect (with its moment)
		public static async Task<MapSoundDto?> StateAsync(RealmForgeDbContext context, Guid campaignId)
		{
			var state = await context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId)
				.Select(c => new { c.SoundTrackId, c.SoundTrackAt, c.SoundCueId, c.SoundCueAt, c.SoundLayers }).FirstOrDefaultAsync();
			var layerIds = SplitIds(state?.SoundLayers);
			if (state is null || (state.SoundTrackId is null && state.SoundCueId is null && layerIds.Count == 0))
			{
				return null;
			}
			var ids = new[] { state.SoundTrackId, state.SoundCueId }.OfType<Guid>().Concat(layerIds).ToList();
			var sounds = await context.CampaignSounds.AsNoTracking().Where(s => ids.Contains(s.Id)).ToDictionaryAsync(s => s.Id);
			var track = state.SoundTrackId is { } t ? sounds.GetValueOrDefault(t) : null;
			var cue = state.SoundCueId is { } c ? sounds.GetValueOrDefault(c) : null;
			return new MapSoundDto(
				track?.Id, track?.Url, track?.Volume ?? 0, track is null ? null : state.SoundTrackAt,
				cue?.Id, cue?.Url, cue?.Volume ?? 0, cue is null ? null : state.SoundCueAt,
				layerIds.Select(l => sounds.GetValueOrDefault(l)).OfType<CampaignSound>().Select(l => new MapSoundLayerDto(l.Id, l.Url, l.Volume)).ToList());
		}

		// ----- Helpers -----

		private async Task WakeTableAsync(Guid campaignId)
		{
			var now = DateTimeOffset.UtcNow;
			foreach (var map in await _context.CampaignMaps.Where(m => m.CampaignId == campaignId && m.Shown).ToListAsync())
			{
				map.UpdatedAt = now;
			}
		}

		private async Task<ActionResult?> MasterAsync(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			return CampaignRules.RunsTheTable(role) ? null : Forbid();
		}

		private async Task<(CampaignSound? Sound, ActionResult? Error)> MastersSoundAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var sound = await _context.CampaignSounds.FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId);
			return sound is null ? (null, NotFound()) : (sound, null);
		}

		//	The bytes of the audio files of a campaign
		private Task<long> StorageUsedAsync(Guid campaignId) =>
			_context.CampaignSoundFiles.Where(f => f.CampaignId == campaignId).SumAsync(f => (long)f.Size);

		//	A name and a link to an audio file or stream over https (or, for a sound already of an uploaded file, its own)
		private ActionResult? Validate(SaveCampaignSoundDto dto, string? current = null)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var url = (dto.Url ?? string.Empty).Trim();
			var ownFile = SoundFiles.IsFile(current) && url == current;
			if (name.Length is 0 or > 80 || url.Length is 0 or > 500 || dto.Volume is < 0 or > 100
				|| (!ownFile && (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 80 characters, an https link up to 500, a volume from 0 to 100.");
			}
			return null;
		}

		private static void Apply(CampaignSound sound, SaveCampaignSoundDto dto)
		{
			sound.Name = dto.Name.Trim();
			sound.Url = dto.Url.Trim();
			sound.Effect = dto.Effect;
			sound.Volume = dto.Volume;
		}

		private static CampaignSoundDto ToDto(CampaignSound s) => new(s.Id, s.Name, s.Url, s.Effect, s.Volume);

		private static SoundSceneDto ToDto(CampaignSoundScene s) => new(s.Id, s.Name, s.TrackId, SplitIds(s.Layers), s.CueId, s.MapId);

		private async Task<(CampaignSoundScene? Scene, ActionResult? Error)> MastersSceneAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var scene = await _context.CampaignSoundScenes.FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId);
			return scene is null ? (null, NotFound()) : (scene, null);
		}

		//	A name, sounds of the campaign (a track that loops, up to four loops, an effect) and a map of the campaign
		private async Task<ActionResult?> ApplyAsync(CampaignSoundScene scene, SaveSoundSceneDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var layers = (dto.Layers ?? new()).Distinct().ToList();
			var wanted = layers.Concat(new[] { dto.TrackId, dto.CueId }.OfType<Guid>()).Distinct().ToList();
			var sounds = await _context.CampaignSounds.AsNoTracking().Where(s => s.CampaignId == scene.CampaignId && wanted.Contains(s.Id)).ToDictionaryAsync(s => s.Id);
			var mapOk = dto.MapId is not { } mapId || await _context.CampaignMaps.AnyAsync(m => m.Id == mapId && m.CampaignId == scene.CampaignId);
			if (name.Length is 0 or > 80 || layers.Count > MaxLayers || sounds.Count != wanted.Count || !mapOk
				|| (dto.TrackId is { } track && sounds[track].Effect) || (dto.CueId is { } cue && !sounds[cue].Effect)
				|| (dto.TrackId is null && layers.Count == 0 && dto.CueId is null))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 80 characters, a track, up to four loops and an effect of this campaign, a map of it.");
			}
			scene.Name = name;
			scene.TrackId = dto.TrackId;
			scene.Layers = JoinIds(layers) ?? string.Empty;
			scene.CueId = dto.CueId;
			scene.MapId = dto.MapId;
			return null;
		}
	}
}
