using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Rules;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Sessions of a campaign: masters and co-masters plan them (date, plan for the players, their own notes) and write
	///	the recap; every member reads them, without the masters' notes. Non-members get 404, like the campaign itself.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/sessions")]
	[Authorize]
	public class SessionsController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public SessionsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/sessions — newest first
		[HttpGet]
		public async Task<ActionResult<List<CampaignSessionDto>>> GetSessions(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var rows = await _context.CampaignSessions.AsNoTracking()
				.Where(s => s.CampaignId == campaignId)
				.OrderByDescending(s => s.Number)
				.ToListAsync();
			var names = await PublicNames.LoadAsync(_context, rows.Select(s => s.UpdatedById));
			return Ok(rows.Select(s => ToDto(s, role, names)).ToList());
		}

		//	POST: api/campaigns/{campaignId}/sessions — the next number
		[HttpPost]
		public async Task<ActionResult<CampaignSessionDto>> AddSession(Guid campaignId, [FromBody] SaveCampaignSessionDto dto)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!SessionRules.CanManageSessions(role))
			{
				return Forbid();
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			var count = await _context.CampaignSessions.CountAsync(s => s.CampaignId == campaignId);
			if (count >= SessionRules.MaxSessions)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {SessionRules.MaxSessions} sessions per campaign.");
			}
			var number = count == 0 ? 1 : await _context.CampaignSessions.Where(s => s.CampaignId == campaignId).MaxAsync(s => s.Number) + 1;
			var session = new CampaignSession { CampaignId = campaignId, Number = number };
			Apply(session, dto);
			_context.CampaignSessions.Add(session);
			await TouchAsync(campaignId);
			await _context.SaveChangesAsync();
			var names = await PublicNames.LoadAsync(_context, new[] { UserId });
			return Ok(ToDto(session, role, names));
		}

		//	PUT: api/campaigns/{campaignId}/sessions/{id}
		[HttpPut("{id:guid}")]
		public async Task<ActionResult<CampaignSessionDto>> UpdateSession(Guid campaignId, Guid id, [FromBody] SaveCampaignSessionDto dto)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var session = await _context.CampaignSessions.FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId);
			if (session is null)
			{
				return NotFound();
			}
			if (!SessionRules.CanManageSessions(role))
			{
				return Forbid();
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			Apply(session, dto);
			await TouchAsync(campaignId);
			await _context.SaveChangesAsync();
			var names = await PublicNames.LoadAsync(_context, new[] { UserId });
			return Ok(ToDto(session, role, names));
		}

		//	DELETE: api/campaigns/{campaignId}/sessions/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteSession(Guid campaignId, Guid id)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var session = await _context.CampaignSessions.FirstOrDefaultAsync(s => s.Id == id && s.CampaignId == campaignId);
			if (session is null)
			{
				return NotFound();
			}
			if (!SessionRules.CanManageSessions(role))
			{
				return Forbid();
			}
			_context.CampaignSessions.Remove(session);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private void Apply(CampaignSession session, SaveCampaignSessionDto dto)
		{
			session.Title = dto.Title.Trim();
			session.ScheduledAt = dto.ScheduledAt?.ToUniversalTime();
			session.Status = dto.Status;
			session.Plan = dto.Plan.Trim();
			session.Recap = dto.Recap.Trim();
			session.MasterNotes = dto.MasterNotes.Trim();
			session.UpdatedById = UserId;
			session.UpdatedAt = DateTimeOffset.UtcNow;
		}

		private static CampaignSessionDto ToDto(CampaignSession s, CampaignRole role, Dictionary<string, string> names) =>
			new(s.Id, s.Number, s.Title, s.ScheduledAt, s.Status, s.Plan, s.Recap,
				SessionRules.CanSeeMasterNotes(role) ? s.MasterNotes : null,
				names.GetValueOrDefault(s.UpdatedById, "•••"), s.UpdatedAt, SessionRules.CanManageSessions(role));

		private ActionResult? Validate(SaveCampaignSessionDto dto)
		{
			dto.Title ??= string.Empty;
			dto.Plan ??= string.Empty;
			dto.Recap ??= string.Empty;
			dto.MasterNotes ??= string.Empty;
			if (dto.Title.Trim().Length > 120 || dto.Plan.Length > 8000 || dto.Recap.Length > 8000 || dto.MasterNotes.Length > 8000)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The session is too long.");
			}
			if (!Enum.IsDefined(dto.Status))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown session status.");
			}
			if (dto.ScheduledAt is { } at && (at.Year < 2000 || at.Year > 2200))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Date out of range.");
			}
			return null;
		}

		private async Task TouchAsync(Guid campaignId)
		{
			var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
			if (campaign is not null)
			{
				campaign.UpdatedAt = DateTimeOffset.UtcNow;
			}
		}
	}

	///	<summary>
	///	Dice log of a campaign, shared by its members: rolls of the shared roller (rolled here, so nobody picks the numbers)
	///	and the rolls made on the sheets of the characters at the table. Masters and co-masters can roll behind the screen
	///	(hidden: seen by the masters and by whoever rolled). Only the last SessionRules.MaxRolls are kept.
	///	</summary>
	[ApiController]
	[Route("api/campaigns/{campaignId:guid}/rolls")]
	[Authorize]
	public class RollsController : ControllerBase
	{
		private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		private readonly RealmForgeDbContext _context;

		public RollsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/campaigns/{campaignId}/rolls?after=… — newest first; with after only the rolls made since then
		[HttpGet]
		public async Task<ActionResult<List<CampaignRollDto>>> GetRolls(Guid campaignId, [FromQuery] DateTimeOffset? after)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role);
			var query = _context.CampaignRolls.AsNoTracking()
				.Where(r => r.CampaignId == campaignId && (!r.Hidden || runs || r.UserId == UserId));
			if (after is { } since)
			{
				var utc = since.ToUniversalTime();
				query = query.Where(r => r.CreatedAt > utc);
			}
			var rows = await query.OrderByDescending(r => r.CreatedAt).Take(100).ToListAsync();
			return Ok(rows.Select(ToDto).ToList());
		}

		//	POST: api/campaigns/{campaignId}/rolls
		[HttpPost]
		public async Task<ActionResult<CampaignRollDto>> AddRoll(Guid campaignId, [FromBody] NewCampaignRollDto dto)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (dto.Hidden && !SessionRules.CanRollHidden(role))
			{
				return Forbid();
			}
			var label = dto.Label?.Trim() ?? string.Empty;
			var note = string.IsNullOrWhiteSpace(dto.Note) ? null : dto.Note.Trim();
			if (label.Length > 120 || (note?.Length ?? 0) > 200)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The label is too long.");
			}

			//	The roll keeps the colour of whoever made it and the name it is shown with
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var roll = new CampaignRoll
			{
				CampaignId = campaignId, UserId = UserId, Label = label, Note = note, Hidden = dto.Hidden,
				Color = colors.GetValueOrDefault(UserId, PlayerColors.Master)
			};
			if (dto.CharacterId is { } characterId)
			{
				//	A roll for a character of this table, by someone who can play it (the owner, a master, a co-master)
				var character = await _context.Characters.AsNoTracking()
					.Where(c => c.Id == characterId && _context.CampaignCharacters.Any(cc => cc.CampaignId == campaignId && cc.CharacterId == c.Id))
					.Select(c => new { c.Name, c.OwnerId })
					.FirstOrDefaultAsync();
				if (character is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The character is not at this table.");
				}
				if (!CampaignRules.CanEditCharacter(role, character.OwnerId == UserId))
				{
					return Forbid();
				}
				roll.CharacterId = characterId;
				roll.CharacterName = character.Name.Length > 100 ? character.Name[..100] : character.Name;
				roll.Roller = roll.CharacterName;
			}
			else
			{
				//	Without a character: the role for masters and co-masters, the nickname for a player
				var nickname = (await PublicNames.LoadAsync(_context, new[] { UserId })).GetValueOrDefault(UserId, "•••");
				roll.Roller = role switch
				{
					CampaignRole.Master => "Master",
					CampaignRole.CoMaster => "Co-master",
					_ => nickname.Length > 100 ? nickname[..100] : nickname
				};
			}

			if (dto.Dice is { Count: > 0 } dice)
			{
				//	Rolled on a sheet: the dice as they landed
				if (dice.Count > DiceNotation.MaxDice || dice.Any(d => d.Sides < 2 || d.Sides > DiceNotation.MaxSides || d.Value < 1 || d.Value > d.Sides)
					|| dto.Modifier is < -1000 or > 1000 || dto.CharacterId is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid dice.");
				}
				var kept = dice.Where(d => !d.Dropped).Sum(d => d.Value) + dto.Modifier;
				roll.Dice = JsonSerializer.Serialize(dice.Select(d => new RollDieDto(d.Sides, d.Value, d.Dropped)).ToList(), Json);
				roll.Modifier = dto.Modifier;
				roll.Total = dto.Total is { } total && total >= -2000 && total <= 2000 ? total : kept;
				roll.Expression = Describe(dice, dto.Modifier);
			}
			else
			{
				//	The shared roller: the server rolls the expression
				if (!DiceNotation.TryParse(dto.Expression, out var parsed))
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid dice expression.");
				}
				var (rolled, total) = DiceNotation.Roll(parsed, sides => RandomNumberGenerator.GetInt32(1, sides + 1));
				roll.Dice = JsonSerializer.Serialize(rolled.Select(d => new RollDieDto(d.Sides, d.Value, d.Dropped)).ToList(), Json);
				roll.Modifier = parsed.Modifier;
				roll.Total = total;
				roll.Expression = parsed.Text;
			}
			if (roll.Label.Length == 0)
			{
				roll.Label = roll.Expression;
			}

			_context.CampaignRolls.Add(roll);
			await _context.SaveChangesAsync();

			//	The log keeps the last rolls only
			var old = await _context.CampaignRolls.Where(r => r.CampaignId == campaignId)
				.OrderByDescending(r => r.CreatedAt).Skip(SessionRules.MaxRolls).ToListAsync();
			if (old.Count > 0)
			{
				_context.CampaignRolls.RemoveRange(old);
				await _context.SaveChangesAsync();
			}

			return Ok(ToDto(roll));
		}

		//	DELETE: api/campaigns/{campaignId}/rolls — the master clears the log
		[HttpDelete]
		public async Task<IActionResult> ClearRolls(Guid campaignId)
		{
			if (await CampaignAccess.RoleAsync(_context, campaignId, UserId) is not { } role)
			{
				return NotFound();
			}
			if (!SessionRules.CanClearRolls(role))
			{
				return Forbid();
			}
			await _context.CampaignRolls.Where(r => r.CampaignId == campaignId).ExecuteDeleteAsync();
			return NoContent();
		}

		private CampaignRollDto ToDto(CampaignRoll r) =>
			new(r.Id, r.Roller, r.Color, r.CharacterId is not null, r.Label, r.Expression, Read(r.Dice), r.Modifier, r.Total,
				r.Note, r.Hidden, r.UserId == UserId, r.CreatedAt, string.IsNullOrEmpty(r.UserId));

		private static List<RollDieDto> Read(string json)
		{
			try
			{
				return JsonSerializer.Deserialize<List<RollDieDto>>(json, Json) ?? new List<RollDieDto>();
			}
			catch (JsonException)
			{
				return new List<RollDieDto>();
			}
		}

		//	"2d20kh1 + 5" from the dice of a sheet roll (advantage and disadvantage show as kept dice)
		private static string Describe(List<RollDieDto> dice, int modifier)
		{
			var groups = dice.GroupBy(d => d.Sides).Select(g =>
			{
				var dropped = g.Count(d => d.Dropped);
				var kept = g.Count() - dropped;
				var highest = dropped == 0 || g.Where(d => !d.Dropped).Min(d => d.Value) >= g.Where(d => d.Dropped).Max(d => d.Value);
				return new DiceGroup(g.Count(), g.Key, dropped > 0 ? kept : 0, highest);
			});
			var text = DiceNotation.Format(groups, modifier);
			return text.Length > 80 ? text[..80] : text;
		}
	}

	///	<summary>
	///	The role of the current account in a campaign, or null when it is not a member.
	///	</summary>
	internal static class CampaignAccess
	{
		public static async Task<CampaignRole?> RoleAsync(RealmForgeDbContext context, Guid campaignId, string userId) =>
			await context.CampaignMembers.Where(m => m.CampaignId == campaignId && m.UserId == userId).Select(m => (CampaignRole?)m.Role).FirstOrDefaultAsync();

		///	<summary>
		///	Gives a colour to the members who have none yet (members from before the colours, a restored campaign) and
		///	returns the colour shown for each member: orange for the masters.
		///	</summary>
		public static async Task<Dictionary<string, string>> EnsureColorsAsync(RealmForgeDbContext context, Guid campaignId)
		{
			var members = await context.CampaignMembers.Where(m => m.CampaignId == campaignId).OrderBy(m => m.JoinedAt).ToListAsync();
			var changed = false;
			foreach (var member in members.Where(m => string.IsNullOrEmpty(m.Color)))
			{
				member.Color = PlayerColors.Pick(members.Select(m => m.Color));
				changed = true;
			}
			if (changed)
			{
				await context.SaveChangesAsync();
			}
			return members.ToDictionary(m => m.UserId, m => PlayerColors.Of(m.Role, m.Color));
		}
	}
}
