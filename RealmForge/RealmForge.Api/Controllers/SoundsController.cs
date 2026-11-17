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
	///	The soundboard of a campaign: links to audio files or streams hosted elsewhere (nothing is uploaded), as tracks
	///	that loop (music, ambience) or one-shot effects. A master plays one and every screen at the table follows: the
	///	track in time with its start, the effect once.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/sounds")]
	[Authorize]
	public class SoundsController : ControllerBase
	{
		public const int MaxSounds = 60;

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
			var playing = await _context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId).Select(c => c.SoundTrackId).FirstAsync();
			return Ok(new CampaignSoundboardDto(sounds.Select(ToDto).ToList(), playing));
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

		//	PUT: api/campaigns/{campaignId}/sounds/{id}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateSound(Guid campaignId, Guid id, [FromBody] SaveCampaignSoundDto dto)
		{
			var (sound, error) = await MastersSoundAsync(campaignId, id);
			if (sound is null)
			{
				return error!;
			}
			if (Validate(dto) is { } invalid)
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
				campaign.SoundTrackId = sound.Id;
				campaign.SoundTrackAt = now;
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
			await WakeTableAsync(campaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	What the table plays: the track (with its start) and the last effect (with its moment)
		public static async Task<MapSoundDto?> StateAsync(RealmForgeDbContext context, Guid campaignId)
		{
			var state = await context.Campaigns.AsNoTracking().Where(c => c.Id == campaignId)
				.Select(c => new { c.SoundTrackId, c.SoundTrackAt, c.SoundCueId, c.SoundCueAt }).FirstOrDefaultAsync();
			if (state is null || (state.SoundTrackId is null && state.SoundCueId is null))
			{
				return null;
			}
			var ids = new[] { state.SoundTrackId, state.SoundCueId }.OfType<Guid>().ToList();
			var sounds = await context.CampaignSounds.AsNoTracking().Where(s => ids.Contains(s.Id)).ToDictionaryAsync(s => s.Id);
			var track = state.SoundTrackId is { } t ? sounds.GetValueOrDefault(t) : null;
			var cue = state.SoundCueId is { } c ? sounds.GetValueOrDefault(c) : null;
			return new MapSoundDto(
				track?.Id, track?.Url, track?.Volume ?? 0, track is null ? null : state.SoundTrackAt,
				cue?.Id, cue?.Url, cue?.Volume ?? 0, cue is null ? null : state.SoundCueAt);
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

		//	A name and a link to an audio file or stream over https
		private ActionResult? Validate(SaveCampaignSoundDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var url = (dto.Url ?? string.Empty).Trim();
			if (name.Length is 0 or > 80 || url.Length is 0 or > 500 || dto.Volume is < 0 or > 100
				|| !Uri.TryCreate(url, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps)
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
	}
}
