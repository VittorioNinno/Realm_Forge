using System.Text.RegularExpressions;
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
	///	The progress clocks and the factions of a campaign: the masters keep them (a clock can fill by itself with the game
	///	time, see ClockController), the players see those shown; a faction's standing moves the prices of its shops.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/progress")]
	[Authorize]
	public class ProgressController : ControllerBase
	{
		public const int MaxClocks = 30;
		public const int MaxFactions = 40;

		private readonly RealmForgeDbContext _context;

		public ProgressController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		[HttpGet]
		public async Task<ActionResult<CampaignProgressDto>> Get(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var clocks = await _context.CampaignProgressClocks.AsNoTracking().Where(c => c.CampaignId == campaignId && (runs || c.Shown)).OrderBy(c => c.CreatedAt).ToListAsync();
			var factions = await _context.CampaignFactions.AsNoTracking().Where(f => f.CampaignId == campaignId && (runs || f.Shown)).OrderBy(f => f.Name).ToListAsync();
			return Ok(new CampaignProgressDto(clocks.Select(ToDto).ToList(), factions.Select(ToDto).ToList()));
		}

		// ----- Clocks -----

		[HttpPost("clocks")]
		public async Task<ActionResult<ProgressClockDto>> AddClock(Guid campaignId, [FromBody] SaveProgressClockDto dto)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (await _context.CampaignProgressClocks.CountAsync(c => c.CampaignId == campaignId) >= MaxClocks)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxClocks} clocks per campaign.");
			}
			var clock = new CampaignProgressClock { CampaignId = campaignId };
			if (Apply(clock, dto) is { } error)
			{
				return error;
			}
			_context.CampaignProgressClocks.Add(clock);
			await _context.SaveChangesAsync();
			return Ok(ToDto(clock));
		}

		[HttpPut("clocks/{id:guid}")]
		public async Task<IActionResult> UpdateClock(Guid campaignId, Guid id, [FromBody] SaveProgressClockDto dto)
		{
			var (clock, error) = await MastersClockAsync(campaignId, id);
			if (clock is null)
			{
				return error!;
			}
			if (Apply(clock, dto) is { } invalid)
			{
				return invalid;
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/progress/clocks/{id}/step — a segment filled (or emptied)
		[HttpPost("clocks/{id:guid}/step")]
		public async Task<ActionResult<ProgressClockDto>> StepClock(Guid campaignId, Guid id, [FromBody] StepDto dto)
		{
			var (clock, error) = await MastersClockAsync(campaignId, id);
			if (clock is null)
			{
				return error!;
			}
			clock.Filled = Math.Clamp(clock.Filled + Math.Clamp(dto.Delta, -12, 12), 0, clock.Segments);
			await _context.SaveChangesAsync();
			return Ok(ToDto(clock));
		}

		[HttpDelete("clocks/{id:guid}")]
		public async Task<IActionResult> DeleteClock(Guid campaignId, Guid id)
		{
			var (clock, error) = await MastersClockAsync(campaignId, id);
			if (clock is null)
			{
				return error!;
			}
			_context.CampaignProgressClocks.Remove(clock);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ----- Factions -----

		[HttpPost("factions")]
		public async Task<ActionResult<FactionDto>> AddFaction(Guid campaignId, [FromBody] SaveFactionDto dto)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return denied;
			}
			if (await _context.CampaignFactions.CountAsync(f => f.CampaignId == campaignId) >= MaxFactions)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxFactions} factions per campaign.");
			}
			var faction = new CampaignFaction { CampaignId = campaignId };
			if (Apply(faction, dto) is { } error)
			{
				return error;
			}
			_context.CampaignFactions.Add(faction);
			await _context.SaveChangesAsync();
			return Ok(ToDto(faction));
		}

		[HttpPut("factions/{id:guid}")]
		public async Task<IActionResult> UpdateFaction(Guid campaignId, Guid id, [FromBody] SaveFactionDto dto)
		{
			var (faction, error) = await MastersFactionAsync(campaignId, id);
			if (faction is null)
			{
				return error!;
			}
			if (Apply(faction, dto) is { } invalid)
			{
				return invalid;
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	POST: api/campaigns/{campaignId}/progress/factions/{id}/step — the standing one step better (or worse)
		[HttpPost("factions/{id:guid}/step")]
		public async Task<ActionResult<FactionDto>> StepFaction(Guid campaignId, Guid id, [FromBody] StepDto dto)
		{
			var (faction, error) = await MastersFactionAsync(campaignId, id);
			if (faction is null)
			{
				return error!;
			}
			faction.Standing = Math.Clamp(faction.Standing + Math.Clamp(dto.Delta, -6, 6), FactionRules.Hostile, FactionRules.Allied);
			await _context.SaveChangesAsync();
			return Ok(ToDto(faction));
		}

		//	DELETE: the shops tied to it keep their own prices
		[HttpDelete("factions/{id:guid}")]
		public async Task<IActionResult> DeleteFaction(Guid campaignId, Guid id)
		{
			var (faction, error) = await MastersFactionAsync(campaignId, id);
			if (faction is null)
			{
				return error!;
			}
			foreach (var shop in await _context.CampaignShops.Where(s => s.FactionId == id).ToListAsync())
			{
				shop.FactionId = null;
			}
			_context.CampaignFactions.Remove(faction);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ----- Helpers -----

		private ActionResult? Apply(CampaignProgressClock clock, SaveProgressClockDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			if (name.Length is 0 or > 80 || !FactionRules.Segments.Contains(dto.Segments) || dto.TickHours is < 1 or > 24 * 30
				|| (dto.Color is { } color && !Regex.IsMatch(color, "^#[0-9a-fA-F]{6}$")))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 80 characters, 4, 6, 8 or 12 segments, every 1 to 720 hours.");
			}
			clock.Name = name;
			clock.Segments = dto.Segments;
			clock.Filled = Math.Clamp(dto.Filled, 0, dto.Segments);
			clock.Shown = dto.Shown;
			clock.Color = dto.Color ?? clock.Color;
			clock.TickHours = dto.TickHours;
			return null;
		}

		private ActionResult? Apply(CampaignFaction faction, SaveFactionDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var description = (dto.Description ?? string.Empty).Trim();
			if (name.Length is 0 or > 80 || description.Length > 1000 || dto.Standing is < FactionRules.Hostile or > FactionRules.Allied)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A name up to 80 characters, a standing from -3 to 3.");
			}
			faction.Name = name;
			faction.Description = description;
			faction.Standing = dto.Standing;
			faction.Shown = dto.Shown;
			return null;
		}

		private static ProgressClockDto ToDto(CampaignProgressClock c) => new(c.Id, c.Name, c.Segments, c.Filled, c.Shown, c.Color, c.TickHours);

		private static FactionDto ToDto(CampaignFaction f) => new(f.Id, f.Name, f.Description, f.Standing, f.Shown, FactionRules.PricePercent(f.Standing));

		private async Task<ActionResult?> MasterAsync(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			return CampaignRules.RunsTheTable(role) ? null : Forbid();
		}

		private async Task<(CampaignProgressClock? Clock, ActionResult? Error)> MastersClockAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var clock = await _context.CampaignProgressClocks.FirstOrDefaultAsync(c => c.Id == id && c.CampaignId == campaignId);
			return clock is null ? (null, NotFound()) : (clock, null);
		}

		private async Task<(CampaignFaction? Faction, ActionResult? Error)> MastersFactionAsync(Guid campaignId, Guid id)
		{
			if (await MasterAsync(campaignId) is { } denied)
			{
				return (null, denied);
			}
			var faction = await _context.CampaignFactions.FirstOrDefaultAsync(f => f.Id == id && f.CampaignId == campaignId);
			return faction is null ? (null, NotFound()) : (faction, null);
		}
	}
}
