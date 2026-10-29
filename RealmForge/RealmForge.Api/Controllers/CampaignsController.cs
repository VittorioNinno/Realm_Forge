using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Campaigns: members with their role (master, co-master, player), invitations by e-mail or by link, the characters
	///	taking part (their masters and co-masters edit them) and the Homebrew shared with the table (the players' entries
	///	wait for a master or co-master). Who may do what is in <see cref="CampaignRules"/>; a campaign is visible only to
	///	its members (others get 404).
	///	</summary>
	[ApiController]
	[Route("api/campaigns")]
	[Authorize]
	public class CampaignsController : ControllerBase
	{
		public const int MaxCampaignsPerUser = 30;
		public const int MaxMembers = 40;
		public const int MaxPendingInvites = 40;
		public const int MaxContents = 300;
		public const int MaxCharacters = 60;

		private readonly RealmForgeDbContext _context;
		private readonly UserManager<ApplicationUser> _users;
		private readonly HomebrewLookup _homebrew;
		private readonly CampaignCharacterCheck _check;

		public const int MaxNotes = 500;

		public CampaignsController(RealmForgeDbContext context, UserManager<ApplicationUser> users, HomebrewLookup homebrew, CampaignCharacterCheck check)
		{
			_context = context;
			_users = users;
			_homebrew = homebrew;
			_check = check;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		// ===== Campaigns =====

		//	GET: api/campaigns — the campaigns I play, with my role
		[HttpGet]
		public async Task<ActionResult<List<CampaignSummaryDto>>> GetCampaigns()
		{
			var rows = await _context.CampaignMembers.AsNoTracking()
				.Where(m => m.UserId == UserId)
				.Select(m => new
				{
					m.Campaign.Id,
					m.Campaign.Name,
					m.Campaign.Ruleset,
					m.Role,
					Members = m.Campaign.Members.Count,
					Characters = m.Campaign.Characters.Count,
					Pending = m.Campaign.Contents.Count(c => c.Status == CampaignContentStatus.Pending),
					m.Campaign.UpdatedAt
				})
				.ToListAsync();
			return Ok(rows
				.Select(r => new CampaignSummaryDto(r.Id, r.Name, r.Ruleset, r.Role, r.Members, r.Characters,
					CampaignRules.CanReview(r.Role) ? r.Pending : 0, r.UpdatedAt))
				.OrderByDescending(r => r.UpdatedAt)
				.ToList());
		}

		//	POST: api/campaigns — the creator is its first master
		[HttpPost]
		public async Task<ActionResult<CampaignDetailDto>> CreateCampaign([FromBody] SaveCampaignDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (Validate(dto) is { } error)
			{
				return error;
			}
			if (await _context.CampaignMembers.CountAsync(m => m.UserId == UserId) >= MaxCampaignsPerUser)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCampaignsPerUser} campaigns per account.");
			}

			var campaign = new Campaign
			{
				Name = dto.Name.Trim(),
				Description = dto.Description?.Trim() ?? string.Empty,
				Ruleset = dto.Ruleset,
				CreatedById = UserId,
				InviteCode = NewCode()
			};
			campaign.Members.Add(new CampaignMember { UserId = UserId, Role = CampaignRole.Master });
			_context.Campaigns.Add(campaign);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetCampaign), new { id = campaign.Id }, await DetailAsync(campaign.Id, lang));
		}

		//	GET: api/campaigns/{id}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CampaignDetailDto>> GetCampaign(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var detail = await DetailAsync(id, lang);
			return detail is null ? NotFound() : Ok(detail);
		}

		//	PUT: api/campaigns/{id} — name, description and edition (masters)
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateCampaign(Guid id, [FromBody] SaveCampaignDto dto)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanEditCampaign(me.Role))
			{
				return Forbid();
			}
			if (Validate(dto) is { } error)
			{
				return error;
			}
			if (dto.Ruleset is { } ruleset && await _context.CampaignCharacters.AnyAsync(c => c.CampaignId == id && c.Character.Ruleset != ruleset))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Some characters of the campaign are of another edition.");
			}
			campaign.Name = dto.Name.Trim();
			campaign.Description = dto.Description?.Trim() ?? string.Empty;
			campaign.Ruleset = dto.Ruleset;
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{id} — masters; the characters stay with their owners
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteCampaign(Guid id)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanDeleteCampaign(me.Role))
			{
				return Forbid();
			}
			_context.Campaigns.Remove(campaign);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Invitations =====

		//	GET: api/campaigns/invitations — invitations I received
		[HttpGet("invitations")]
		public async Task<ActionResult<List<CampaignInvitationDto>>> GetInvitations()
		{
			var rows = await _context.CampaignInvites.AsNoTracking()
				.Where(i => i.UserId == UserId)
				.Select(i => new { i.Id, i.CampaignId, i.Campaign.Name, i.Role, i.InvitedById, i.CreatedAt })
				.ToListAsync();
			var emails = await NamesAsync(rows.Select(r => r.InvitedById));
			return Ok(rows.Select(r => new CampaignInvitationDto(r.Id, r.CampaignId, r.Name, r.Role, emails.GetValueOrDefault(r.InvitedById, string.Empty), r.CreatedAt))
				.OrderByDescending(r => r.CreatedAt).ToList());
		}

		//	POST: api/campaigns/{id}/invites — invite an account by e-mail, with the role it will have
		[HttpPost("{id:guid}/invites")]
		public async Task<ActionResult<CampaignPendingInviteDto>> Invite(Guid id, [FromBody] CampaignInviteRequestDto request)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!Enum.IsDefined(request.Role) || !CampaignRules.CanInvite(me.Role, request.Role))
			{
				return Forbid();
			}
			var address = request.Email?.Trim();
			if (string.IsNullOrEmpty(address) || address.Length > 256 || !address.Contains('@'))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid e-mail address.");
			}
			var target = await _users.FindByEmailAsync(address);
			if (target is null)
			{
				return Problem(statusCode: StatusCodes.Status404NotFound, title: "No account with this e-mail address.");
			}
			if (await _context.CampaignMembers.AnyAsync(m => m.CampaignId == id && m.UserId == target.Id))
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "This account already plays the campaign.");
			}
			if (await _context.CampaignInvites.CountAsync(i => i.CampaignId == id) >= MaxPendingInvites
				|| await _context.CampaignMembers.CountAsync(m => m.CampaignId == id) >= MaxMembers)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxMembers} people per campaign.");
			}

			var invite = await _context.CampaignInvites.FirstOrDefaultAsync(i => i.CampaignId == id && i.UserId == target.Id);
			if (invite is null)
			{
				invite = new CampaignInvite { CampaignId = id, UserId = target.Id };
				_context.CampaignInvites.Add(invite);
			}
			invite.Role = request.Role;
			invite.InvitedById = UserId;
			invite.CreatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			var inviter = (await NamesAsync(new[] { UserId })).GetValueOrDefault(UserId, string.Empty);
			var invited = Nicknames.Display(target.Nickname, target.Email);
			return Ok(new CampaignPendingInviteDto(invite.Id, invited, invite.Role, inviter, invite.CreatedAt));
		}

		//	POST: api/campaigns/invitations/{inviteId}/accept
		[HttpPost("invitations/{inviteId:guid}/accept")]
		public async Task<ActionResult<CampaignSummaryDto>> Accept(Guid inviteId)
		{
			var invite = await _context.CampaignInvites.FirstOrDefaultAsync(i => i.Id == inviteId && i.UserId == UserId);
			if (invite is null)
			{
				return NotFound();
			}
			if (await _context.CampaignMembers.CountAsync(m => m.UserId == UserId) >= MaxCampaignsPerUser)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCampaignsPerUser} campaigns per account.");
			}
			if (!await _context.CampaignMembers.AnyAsync(m => m.CampaignId == invite.CampaignId && m.UserId == UserId))
			{
				_context.CampaignMembers.Add(new CampaignMember { CampaignId = invite.CampaignId, UserId = UserId, Role = invite.Role });
			}
			_context.CampaignInvites.Remove(invite);
			await TouchAsync(invite.CampaignId);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/invitations/{inviteId} — the invited person declines, or a master or co-master withdraws it
		[HttpDelete("invitations/{inviteId:guid}")]
		public async Task<IActionResult> DeleteInvite(Guid inviteId)
		{
			var invite = await _context.CampaignInvites.FirstOrDefaultAsync(i => i.Id == inviteId);
			if (invite is null)
			{
				return NotFound();
			}
			if (invite.UserId != UserId)
			{
				var me = await RoleAsync(invite.CampaignId);
				if (me is null)
				{
					return NotFound();
				}
				if (!CampaignRules.CanInvite(me.Value, invite.Role))
				{
					return Forbid();
				}
			}
			_context.CampaignInvites.Remove(invite);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Invite link =====

		//	POST: api/campaigns/{id}/invite-code — a new link (the old one stops working)
		[HttpPost("{id:guid}/invite-code")]
		public async Task<ActionResult<string>> NewInviteCode(Guid id)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanManageInviteLink(me.Role))
			{
				return Forbid();
			}
			campaign.InviteCode = NewCode();
			await _context.SaveChangesAsync();
			return Ok(campaign.InviteCode);
		}

		//	DELETE: api/campaigns/{id}/invite-code — nobody can join with a link
		[HttpDelete("{id:guid}/invite-code")]
		public async Task<IActionResult> DisableInviteCode(Guid id)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanManageInviteLink(me.Role))
			{
				return Forbid();
			}
			campaign.InviteCode = null;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	GET: api/campaigns/join/{code} — what the link opens
		[HttpGet("join/{code}")]
		public async Task<ActionResult<CampaignJoinPreviewDto>> JoinPreview(string code)
		{
			var campaign = await ByCodeAsync(code);
			if (campaign is null)
			{
				return NotFound();
			}
			var members = await _context.CampaignMembers.CountAsync(m => m.CampaignId == campaign.Id);
			var already = await _context.CampaignMembers.AnyAsync(m => m.CampaignId == campaign.Id && m.UserId == UserId);
			return Ok(new CampaignJoinPreviewDto(campaign.Id, campaign.Name, campaign.Ruleset, members, already));
		}

		//	POST: api/campaigns/join — join as a player with the code of the link
		[HttpPost("join")]
		public async Task<ActionResult<Guid>> Join([FromBody] CampaignJoinRequestDto request)
		{
			var campaign = await ByCodeAsync(request.Code);
			if (campaign is null)
			{
				return NotFound();
			}
			if (!await _context.CampaignMembers.AnyAsync(m => m.CampaignId == campaign.Id && m.UserId == UserId))
			{
				if (await _context.CampaignMembers.CountAsync(m => m.CampaignId == campaign.Id) >= MaxMembers
					|| await _context.CampaignMembers.CountAsync(m => m.UserId == UserId) >= MaxCampaignsPerUser)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The campaign or your account is full.");
				}
				_context.CampaignMembers.Add(new CampaignMember { CampaignId = campaign.Id, UserId = UserId, Role = CampaignRole.Player });

				//	An invitation for the same campaign is no longer needed
				_context.CampaignInvites.RemoveRange(_context.CampaignInvites.Where(i => i.CampaignId == campaign.Id && i.UserId == UserId));
				campaign.UpdatedAt = DateTimeOffset.UtcNow;
				await _context.SaveChangesAsync();
			}
			return Ok(campaign.Id);
		}

		// ===== Members =====

		//	PUT: api/campaigns/{id}/members/{userId} — a new role (masters only; a master always remains)
		[HttpPut("{id:guid}/members/{userId}")]
		public async Task<IActionResult> ChangeRole(Guid id, string userId, [FromBody] CampaignRoleRequestDto request)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanChangeRoles(me.Role) || !Enum.IsDefined(request.Role))
			{
				return Forbid();
			}
			var member = campaign.Members.FirstOrDefault(m => m.UserId == userId);
			if (member is null)
			{
				return NotFound();
			}
			var masters = campaign.Members.Count(m => m.Role == CampaignRole.Master);
			if (!CampaignRules.LeavesAMaster(masters, member.Role, request.Role))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The campaign needs at least one master.");
			}
			member.Role = request.Role;
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{id}/members/{userId|me} — a master removes someone, anyone leaves. Their characters
		//	leave the campaign, their pending entries are withdrawn (approved ones stay, the masters decide)
		[HttpDelete("{id:guid}/members/{userId}")]
		public async Task<IActionResult> RemoveMember(Guid id, string userId)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var target = userId == "me" ? UserId : userId;
			if (!CampaignRules.CanRemoveMember(me.Role, target == UserId))
			{
				return Forbid();
			}
			var member = campaign.Members.FirstOrDefault(m => m.UserId == target);
			if (member is null)
			{
				return NotFound();
			}
			var masters = campaign.Members.Count(m => m.Role == CampaignRole.Master);
			if (!CampaignRules.LeavesAMaster(masters, member.Role, null))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The campaign needs at least one master: name another master first.");
			}

			_context.CampaignMembers.Remove(member);
			_context.CampaignCharacters.RemoveRange(_context.CampaignCharacters.Where(c => c.CampaignId == id && c.Character.OwnerId == target));
			_context.CampaignContents.RemoveRange(_context.CampaignContents.Where(c => c.CampaignId == id && c.SharedById == target && c.Status == CampaignContentStatus.Pending));

			//	Their private notes go with them; what they wrote in the journal and in the masters' notes stays
			_context.CampaignNotes.RemoveRange(_context.CampaignNotes.Where(n => n.CampaignId == id && n.AuthorId == target && n.Kind == CampaignNoteKind.Private));
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Characters =====

		//	GET: api/campaigns/{id}/characters/{characterId}/check — can this character of mine join? (and why not)
		[HttpGet("{id:guid}/characters/{characterId:guid}/check")]
		public async Task<ActionResult<CampaignCharacterCheckDto>> CheckCharacter(Guid id, Guid characterId, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var (campaign, me) = await LoadAsync(id);
			var character = await _context.Characters.AsNoTracking().FirstOrDefaultAsync(c => c.Id == characterId && c.OwnerId == UserId);
			if (campaign is null || me is null || character is null)
			{
				return NotFound();
			}
			return Ok(await _check.CheckAsync(campaign, character, lang));
		}

		//	POST: api/campaigns/{id}/characters — a member brings one of their characters; 422 with the reasons when it
		//	does not meet the campaign's requirements (edition, Homebrew the table cannot use)
		[HttpPost("{id:guid}/characters")]
		public async Task<IActionResult> AddCharacter(Guid id, [FromBody] CampaignCharacterRequestDto request, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == request.CharacterId && c.OwnerId == UserId);
			if (character is null)
			{
				return NotFound();
			}
			var check = await _check.CheckAsync(campaign, character, lang);
			if (!check.Ok)
			{
				return UnprocessableEntity(check);
			}
			if (!await _context.CampaignCharacters.AnyAsync(c => c.CampaignId == id && c.CharacterId == character.Id))
			{
				if (await _context.CampaignCharacters.CountAsync(c => c.CampaignId == id) >= MaxCharacters)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCharacters} characters per campaign.");
				}
				_context.CampaignCharacters.Add(new CampaignCharacter { CampaignId = id, CharacterId = character.Id, AddedById = UserId });
				campaign.UpdatedAt = DateTimeOffset.UtcNow;
				await _context.SaveChangesAsync();
			}
			return NoContent();
		}

		//	DELETE: api/campaigns/{id}/characters/{characterId} — the owner, a master or a co-master takes it out
		[HttpDelete("{id:guid}/characters/{characterId:guid}")]
		public async Task<IActionResult> RemoveCharacter(Guid id, Guid characterId)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var link = await _context.CampaignCharacters.Include(c => c.Character).FirstOrDefaultAsync(c => c.CampaignId == id && c.CharacterId == characterId);
			if (link is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanRemoveCharacter(me.Role, link.Character.OwnerId == UserId))
			{
				return Forbid();
			}
			_context.CampaignCharacters.Remove(link);
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Shared content =====

		//	GET: api/campaigns/{id}/shareable — my Homebrew not yet shared with the campaign
		[HttpGet("{id:guid}/shareable")]
		public async Task<ActionResult<List<ShareableEntryDto>>> GetShareable(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var shared = await _context.CampaignContents.AsNoTracking().Where(c => c.CampaignId == id).Select(c => c.EntityId).ToListAsync();
			var mine = await _homebrew.ByAuthorAsync(UserId, lang);
			return Ok(mine
				.Where(e => !shared.Contains(e.Id) && (campaign.Ruleset is null || e.Ruleset == campaign.Ruleset))
				.Select(e => new ShareableEntryDto(e.Id, e.Kind, e.Name, e.Ruleset))
				.ToList());
		}

		//	POST: api/campaigns/{id}/contents — share one of my entries: approved at once for masters and co-masters,
		//	waiting for them when a player shares it
		[HttpPost("{id:guid}/contents")]
		public async Task<IActionResult> ShareContent(Guid id, [FromBody] CampaignContentRequestDto request, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var entry = (await _homebrew.FindAsync(new[] { request.EntityId }, lang)).GetValueOrDefault(request.EntityId);
			if (entry is null || entry.IsBase || entry.AuthorId != UserId)
			{
				return NotFound();
			}
			if (await _context.CampaignContents.AnyAsync(c => c.CampaignId == id && c.EntityId == entry.Id))
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "Already shared with the campaign.");
			}
			if (await _context.CampaignContents.CountAsync(c => c.CampaignId == id) >= MaxContents)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxContents} entries per campaign.");
			}
			var status = CampaignRules.StatusOfNewShare(me.Role);
			_context.CampaignContents.Add(new CampaignContent
			{
				CampaignId = id,
				EntityId = entry.Id,
				SharedById = UserId,
				Status = status,
				ReviewedById = status == CampaignContentStatus.Approved ? UserId : null
			});
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(status);
		}

		//	POST: api/campaigns/{id}/contents/{entityId}/approve — a master or co-master accepts a player's entry
		[HttpPost("{id:guid}/contents/{entityId:guid}/approve")]
		public async Task<IActionResult> Approve(Guid id, Guid entityId)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!CampaignRules.CanReview(me.Role))
			{
				return Forbid();
			}
			var content = await _context.CampaignContents.FirstOrDefaultAsync(c => c.CampaignId == id && c.EntityId == entityId);
			if (content is null)
			{
				return NotFound();
			}
			content.Status = CampaignContentStatus.Approved;
			content.ReviewedById = UserId;
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{id}/contents/{entityId} — remove (or decline) an entry, see CampaignRules.CanRemoveContent
		[HttpDelete("{id:guid}/contents/{entityId:guid}")]
		public async Task<IActionResult> RemoveContent(Guid id, Guid entityId)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var content = await _context.CampaignContents.FirstOrDefaultAsync(c => c.CampaignId == id && c.EntityId == entityId);
			if (content is null)
			{
				return NotFound();
			}
			var sharerRole = campaign.Members.FirstOrDefault(m => m.UserId == content.SharedById)?.Role;
			if (!CampaignRules.CanRemoveContent(me.Role, content.SharedById == UserId, sharerRole))
			{
				return Forbid();
			}
			_context.CampaignContents.Remove(content);
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Notes =====

		//	GET: api/campaigns/{id}/notes — the notes I can read: my private ones, the journal, the masters' (if I run the table)
		[HttpGet("{id:guid}/notes")]
		public async Task<ActionResult<List<CampaignNoteDto>>> GetNotes(Guid id)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(me.Role);
			var notes = await _context.CampaignNotes.AsNoTracking()
				.Where(n => n.CampaignId == id
					&& ((n.Kind == CampaignNoteKind.Private && n.AuthorId == UserId) || n.Kind == CampaignNoteKind.Journal || (n.Kind == CampaignNoteKind.Masters && runs)))
				.OrderByDescending(n => n.CreatedAt)
				.ToListAsync();
			var names = await NamesAsync(notes.Select(n => n.AuthorId));
			var roles = campaign.Members.ToDictionary(m => m.UserId, m => m.Role);
			return Ok(notes.Select(n => ToNoteDto(n, me.Role, names, roles)).ToList());
		}

		//	POST: api/campaigns/{id}/notes
		[HttpPost("{id:guid}/notes")]
		public async Task<ActionResult<CampaignNoteDto>> AddNote(Guid id, [FromBody] SaveCampaignNoteDto dto)
		{
			var (campaign, me) = await LoadAsync(id);
			if (campaign is null || me is null)
			{
				return NotFound();
			}
			if (!Enum.IsDefined(dto.Kind) || !CampaignRules.CanWriteNotes(dto.Kind, me.Role))
			{
				return Forbid();
			}
			if (ValidateNote(dto) is { } error)
			{
				return error;
			}
			if (await _context.CampaignNotes.CountAsync(n => n.CampaignId == id) >= MaxNotes)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxNotes} notes per campaign.");
			}
			var note = new CampaignNote { CampaignId = id, Kind = dto.Kind, AuthorId = UserId, Title = dto.Title.Trim(), Body = dto.Body.Trim() };
			_context.CampaignNotes.Add(note);
			if (note.Kind != CampaignNoteKind.Private)
			{
				campaign.UpdatedAt = DateTimeOffset.UtcNow;
			}
			await _context.SaveChangesAsync();
			var names = await NamesAsync(new[] { UserId });
			return Ok(ToNoteDto(note, me.Role, names, campaign.Members.ToDictionary(m => m.UserId, m => m.Role)));
		}

		//	PUT: api/campaigns/{id}/notes/{noteId} — the author changes title and text (the kind stays)
		[HttpPut("{id:guid}/notes/{noteId:guid}")]
		public async Task<IActionResult> UpdateNote(Guid id, Guid noteId, [FromBody] SaveCampaignNoteDto dto)
		{
			var (campaign, me) = await LoadAsync(id);
			var note = await _context.CampaignNotes.FirstOrDefaultAsync(n => n.Id == noteId && n.CampaignId == id);
			if (campaign is null || me is null || note is null || !CanSee(note, me.Role))
			{
				return NotFound();
			}
			if (!CampaignRules.CanEditNote(note.AuthorId == UserId) || !CampaignRules.CanWriteNotes(note.Kind, me.Role))
			{
				return Forbid();
			}
			if (ValidateNote(dto) is { } error)
			{
				return error;
			}
			note.Title = dto.Title.Trim();
			note.Body = dto.Body.Trim();
			note.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/campaigns/{id}/notes/{noteId}
		[HttpDelete("{id:guid}/notes/{noteId:guid}")]
		public async Task<IActionResult> DeleteNote(Guid id, Guid noteId)
		{
			var (campaign, me) = await LoadAsync(id);
			var note = await _context.CampaignNotes.FirstOrDefaultAsync(n => n.Id == noteId && n.CampaignId == id);
			if (campaign is null || me is null || note is null || !CanSee(note, me.Role))
			{
				return NotFound();
			}
			var authorRole = campaign.Members.FirstOrDefault(m => m.UserId == note.AuthorId)?.Role;
			if (!CampaignRules.CanDeleteNote(note.Kind, me.Role, note.AuthorId == UserId, authorRole))
			{
				return Forbid();
			}
			_context.CampaignNotes.Remove(note);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private bool CanSee(CampaignNote note, CampaignRole role) =>
			note.Kind == CampaignNoteKind.Private ? note.AuthorId == UserId : CampaignRules.CanReadNotes(note.Kind, role);

		private CampaignNoteDto ToNoteDto(CampaignNote n, CampaignRole myRole, Dictionary<string, string> names, Dictionary<string, CampaignRole> roles)
		{
			var mine = n.AuthorId == UserId;
			var authorRole = roles.TryGetValue(n.AuthorId, out var role) ? role : (CampaignRole?)null;
			return new CampaignNoteDto(n.Id, n.Kind, n.Title, n.Body, n.AuthorId, names.GetValueOrDefault(n.AuthorId, "•••"), mine,
				n.CreatedAt, n.UpdatedAt, CampaignRules.CanEditNote(mine), CampaignRules.CanDeleteNote(n.Kind, myRole, mine, authorRole));
		}

		private ActionResult? ValidateNote(SaveCampaignNoteDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Body) && string.IsNullOrWhiteSpace(dto.Title))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "An empty note.");
			}
			if ((dto.Title?.Trim().Length ?? 0) > 120 || (dto.Body?.Length ?? 0) > 8000)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The note is too long.");
			}
			dto.Title ??= string.Empty;
			dto.Body ??= string.Empty;
			return null;
		}

		// ===== Helpers =====

		private async Task<(Campaign? Campaign, CampaignMember? Me)> LoadAsync(Guid id)
		{
			var campaign = await _context.Campaigns.Include(c => c.Members).FirstOrDefaultAsync(c => c.Id == id);
			var me = campaign?.Members.FirstOrDefault(m => m.UserId == UserId);
			return me is null ? (null, null) : (campaign, me);
		}

		private async Task<CampaignRole?> RoleAsync(Guid campaignId) =>
			await _context.CampaignMembers.Where(m => m.CampaignId == campaignId && m.UserId == UserId).Select(m => (CampaignRole?)m.Role).FirstOrDefaultAsync();

		private async Task TouchAsync(Guid campaignId)
		{
			var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId);
			if (campaign is not null)
			{
				campaign.UpdatedAt = DateTimeOffset.UtcNow;
			}
		}

		private async Task<Campaign?> ByCodeAsync(string? code)
		{
			var value = code?.Trim();
			return string.IsNullOrEmpty(value) || value.Length > 32 ? null : await _context.Campaigns.FirstOrDefaultAsync(c => c.InviteCode == value);
		}

		//	Nicknames, never the e-mail addresses: other members see each other by name
		private Task<Dictionary<string, string>> NamesAsync(IEnumerable<string> ids) => PublicNames.LoadAsync(_context, ids);

		//	A link code that is hard to guess (72 random bits, URL safe)
		private static string NewCode() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(9)).Replace('+', '-').Replace('/', '_');

		private ActionResult? Validate(SaveCampaignDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Trim().Length > 100)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The campaign needs a name (at most 100 characters).");
			}
			if ((dto.Description?.Length ?? 0) > 8000)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The description is too long.");
			}
			if (dto.Ruleset is { } ruleset && !Enum.IsDefined(ruleset))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown edition.");
			}
			return null;
		}

		private async Task<CampaignDetailDto?> DetailAsync(Guid id, LanguageCode lang)
		{
			var campaign = await _context.Campaigns.AsNoTracking()
				.Include(c => c.Members)
				.Include(c => c.Invites)
				.Include(c => c.Contents)
				.AsSplitQuery()
				.FirstOrDefaultAsync(c => c.Id == id);
			var me = campaign?.Members.FirstOrDefault(m => m.UserId == UserId);
			if (campaign is null || me is null)
			{
				return null;
			}
			var runs = CampaignRules.RunsTheTable(me.Role);

			var characters = await _context.Characters.AsNoTracking()
				.Where(c => _context.CampaignCharacters.Any(cc => cc.CampaignId == id && cc.CharacterId == c.Id))
				.Include(c => c.Species).ThenInclude(s => s.Translations)
				.Include(c => c.Background).ThenInclude(b => b.Translations)
				.OrderBy(c => c.Name)
				.ToListAsync();
			var summaries = await CharactersController.SummariesAsync(_context, characters, lang);

			var roles = campaign.Members.ToDictionary(m => m.UserId, m => m.Role);
			var emails = await NamesAsync(campaign.Members.Select(m => m.UserId)
				.Concat(campaign.Invites.SelectMany(i => new[] { i.UserId, i.InvitedById }))
				.Concat(campaign.Contents.Select(c => c.SharedById))
				.Concat(characters.Select(c => c.OwnerId)));

			//	Players see the approved entries and their own pending ones; masters and co-masters see everything
			var visible = campaign.Contents.Where(c => c.Status == CampaignContentStatus.Approved || runs || c.SharedById == UserId).ToList();
			var entries = await _homebrew.FindAsync(visible.Select(c => c.EntityId).ToList(), lang);

			return new CampaignDetailDto(
				campaign.Id,
				campaign.Name,
				campaign.Description,
				campaign.Ruleset,
				me.Role,
				CampaignRules.CanManageInviteLink(me.Role) ? campaign.InviteCode : null,
				campaign.Members
					.OrderBy(m => m.Role).ThenBy(m => emails.GetValueOrDefault(m.UserId, string.Empty))
					.Select(m => new CampaignMemberDto(m.UserId, emails.GetValueOrDefault(m.UserId, string.Empty), m.Role, m.UserId == UserId, m.JoinedAt))
					.ToList(),
				runs
					? campaign.Invites.OrderBy(i => i.CreatedAt)
						.Select(i => new CampaignPendingInviteDto(i.Id, emails.GetValueOrDefault(i.UserId, string.Empty), i.Role, emails.GetValueOrDefault(i.InvitedById, string.Empty), i.CreatedAt))
						.ToList()
					: new List<CampaignPendingInviteDto>(),
				characters.Select((c, i) =>
				{
					var mine = c.OwnerId == UserId;
					return new CampaignCharacterDto(summaries[i], c.OwnerId, emails.GetValueOrDefault(c.OwnerId, string.Empty), mine,
						mine || runs, CampaignRules.CanEditCharacter(me.Role, mine), CampaignRules.CanRemoveCharacter(me.Role, mine));
				}).ToList(),
				visible
					.Where(c => entries.ContainsKey(c.EntityId))
					.OrderBy(c => c.Status).ThenBy(c => entries[c.EntityId].Kind).ThenBy(c => entries[c.EntityId].Name)
					.Select(c =>
					{
						var entry = entries[c.EntityId];
						var sharerRole = roles.TryGetValue(c.SharedById, out var role) ? role : (CampaignRole?)null;
						return new CampaignContentDto(entry.Id, entry.Kind, entry.Name, entry.Link, c.Status, c.SharedById,
							emails.GetValueOrDefault(c.SharedById, string.Empty), sharerRole, c.CreatedAt,
							CampaignRules.CanRemoveContent(me.Role, c.SharedById == UserId, sharerRole),
							c.Status == CampaignContentStatus.Pending && CampaignRules.CanReview(me.Role));
					}).ToList(),
				campaign.CreatedAt,
				campaign.UpdatedAt);
		}
	}
}
