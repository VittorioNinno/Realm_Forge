using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Collections of Homebrew: an author gathers entries of theirs under one name and one link (a setting, a book of
	///	spells and monsters). Whoever has the link reads the list, adds every entry to their own collection in one go,
	///	or switches the whole collection on in a campaign of theirs (and off again as a block).
	///	</summary>
	[ApiController]
	[Authorize]
	public class CollectionsController : ControllerBase
	{
		public const int MaxCollections = 30;
		public const int MaxEntries = 200;

		private readonly RealmForgeDbContext _context;
		private readonly HomebrewLookup _homebrew;

		public CollectionsController(RealmForgeDbContext context, HomebrewLookup homebrew)
		{
			_context = context;
			_homebrew = homebrew;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/collections — mine
		[HttpGet("api/collections")]
		public async Task<ActionResult<List<ContentCollectionSummaryDto>>> GetMine()
		{
			var rows = await _context.ContentCollections.AsNoTracking().Where(c => c.AuthorId == UserId).OrderBy(c => c.Name).ToListAsync();
			return Ok(rows.Select(Summary).ToList());
		}

		//	POST: api/collections — my entries under a name and a link
		[HttpPost("api/collections")]
		public async Task<ActionResult<ContentCollectionSummaryDto>> Create([FromBody] SaveContentCollectionDto dto)
		{
			if (await _context.ContentCollections.CountAsync(c => c.AuthorId == UserId) >= MaxCollections)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCollections} collections per account.");
			}
			var collection = new ContentCollection { AuthorId = UserId, Code = NewCode() };
			if (await ApplyAsync(collection, dto) is { } error)
			{
				return error;
			}
			_context.ContentCollections.Add(collection);
			await _context.SaveChangesAsync();
			return Ok(Summary(collection));
		}

		//	PUT: api/collections/{id}
		[HttpPut("api/collections/{id:guid}")]
		public async Task<ActionResult<ContentCollectionSummaryDto>> Update(Guid id, [FromBody] SaveContentCollectionDto dto)
		{
			var collection = await _context.ContentCollections.FirstOrDefaultAsync(c => c.Id == id && c.AuthorId == UserId);
			if (collection is null)
			{
				return NotFound();
			}
			if (await ApplyAsync(collection, dto) is { } error)
			{
				return error;
			}
			collection.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(Summary(collection));
		}

		//	DELETE: api/collections/{id} — the entries switched on in campaigns stay there, one by one
		[HttpDelete("api/collections/{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var collection = await _context.ContentCollections.FirstOrDefaultAsync(c => c.Id == id && c.AuthorId == UserId);
			if (collection is null)
			{
				return NotFound();
			}
			foreach (var content in await _context.CampaignContents.Where(c => c.CollectionId == id).ToListAsync())
			{
				content.CollectionId = null;
			}
			_context.ContentCollections.Remove(collection);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	GET: api/collections/link/{code}?lang=2 — the collection behind a link
		[HttpGet("api/collections/link/{code}")]
		public async Task<ActionResult<ContentCollectionDto>> GetByCode(string code, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var collection = await ByCodeAsync(code);
			if (collection is null)
			{
				return NotFound();
			}
			var entries = await _homebrew.FindAsync(collection.EntityIds, lang);
			var author = (await PublicNames.LoadAsync(_context, new[] { collection.AuthorId })).GetValueOrDefault(collection.AuthorId) ?? "?";
			return Ok(new ContentCollectionDto(collection.Id, collection.Name, collection.Description, collection.Code, author, collection.AuthorId == UserId,
				collection.EntityIds.Where(entries.ContainsKey).Select(i => entries[i])
					.Select(e => new ContentCollectionEntryDto(e.Id, e.Kind, e.Name, e.Link, e.Ruleset)).ToList()));
		}

		//	POST: api/collections/link/{code}/collect — every entry added to my own collection
		[HttpPost("api/collections/link/{code}/collect")]
		public async Task<ActionResult<int>> Collect(string code)
		{
			var collection = await ByCodeAsync(code);
			if (collection is null)
			{
				return NotFound();
			}
			if (collection.AuthorId == UserId)
			{
				return Ok(0);
			}
			var mine = await _context.ContentShares.Where(s => s.UserId == UserId && collection.EntityIds.Contains(s.EntityId)).Select(s => s.EntityId).ToListAsync();
			var added = 0;
			foreach (var id in collection.EntityIds.Except(mine))
			{
				_context.ContentShares.Add(new ContentShare { EntityId = id, UserId = UserId, GrantedById = UserId });
				added++;
			}
			await _context.SaveChangesAsync();
			return Ok(added);
		}

		// ===== In a campaign =====

		//	GET: api/campaigns/{campaignId}/collections — the collections switched on in the campaign
		[HttpGet("api/campaigns/{campaignId:guid}/collections")]
		public async Task<ActionResult<List<CampaignCollectionDto>>> GetCampaignCollections(Guid campaignId)
		{
			if (await RoleAsync(campaignId) is not { } role)
			{
				return NotFound();
			}
			var rows = (await _context.CampaignContents.AsNoTracking().Where(c => c.CampaignId == campaignId && c.CollectionId != null)
					.Select(c => new { Id = c.CollectionId!.Value, c.SharedById }).ToListAsync())
				.GroupBy(c => c.Id)
				.Select(g => new { Id = g.Key, Count = g.Count(), By = g.First().SharedById })
				.ToList();
			var ids = rows.Select(r => r.Id).ToList();
			var names = await _context.ContentCollections.AsNoTracking().Where(c => ids.Contains(c.Id)).ToDictionaryAsync(c => c.Id, c => c.Name);
			var people = await PublicNames.LoadAsync(_context, rows.Select(r => r.By));
			return Ok(rows.Where(r => names.ContainsKey(r.Id)).Select(r => new CampaignCollectionDto(r.Id, names[r.Id], r.Count,
					people.GetValueOrDefault(r.By) ?? "?", CampaignRules.RunsTheTable(role) || r.By == UserId))
				.OrderBy(r => r.Name).ToList());
		}

		//	POST: api/campaigns/{campaignId}/collections — the collection of a link switched on as a block (approved at once
		//	for masters and co-masters, waiting for them when a player does it); entries of another edition are left out
		[HttpPost("api/campaigns/{campaignId:guid}/collections")]
		public async Task<ActionResult<CampaignCollectionAddedDto>> Enable(Guid campaignId, [FromBody] EnableCollectionDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (await RoleAsync(campaignId) is not { } role)
			{
				return NotFound();
			}
			var collection = await ByCodeAsync(dto.Code);
			if (collection is null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Unknown collection link.");
			}
			var campaign = await _context.Campaigns.FirstAsync(c => c.Id == campaignId);
			var entries = await _homebrew.FindAsync(collection.EntityIds, lang);
			var already = await _context.CampaignContents.Where(c => c.CampaignId == campaignId).Select(c => c.EntityId).ToListAsync();
			var room = CampaignsController.MaxContents - already.Count;
			var status = CampaignRules.StatusOfNewShare(role);
			var added = 0;
			var skipped = 0;
			foreach (var entry in collection.EntityIds.Where(entries.ContainsKey).Select(i => entries[i]))
			{
				if (already.Contains(entry.Id))
				{
					continue;
				}
				if (entry.IsBase || (campaign.Ruleset is { } ruleset && entry.Ruleset != ruleset) || added >= room)
				{
					skipped++;
					continue;
				}
				_context.CampaignContents.Add(new CampaignContent
				{
					CampaignId = campaignId,
					EntityId = entry.Id,
					SharedById = UserId,
					Status = status,
					ReviewedById = status == CampaignContentStatus.Approved ? UserId : null,
					CollectionId = collection.Id
				});
				added++;
			}
			campaign.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(new CampaignCollectionAddedDto(collection.Id, collection.Name, added, skipped, status));
		}

		//	DELETE: api/campaigns/{campaignId}/collections/{collectionId} — switched off as a block (its masters, or who
		//	switched it on)
		[HttpDelete("api/campaigns/{campaignId:guid}/collections/{collectionId:guid}")]
		public async Task<IActionResult> Disable(Guid campaignId, Guid collectionId)
		{
			if (await RoleAsync(campaignId) is not { } role)
			{
				return NotFound();
			}
			var contents = await _context.CampaignContents.Where(c => c.CampaignId == campaignId && c.CollectionId == collectionId).ToListAsync();
			if (contents.Count == 0)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role) && contents.Any(c => c.SharedById != UserId))
			{
				return Forbid();
			}
			_context.CampaignContents.RemoveRange(contents);
			(await _context.Campaigns.FirstAsync(c => c.Id == campaignId)).UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Helpers =====

		private Task<CampaignRole?> RoleAsync(Guid campaignId) => CampaignAccess.RoleAsync(_context, campaignId, UserId);

		//	A link or its code ("…/collections/AbC123xyZ9")
		private Task<ContentCollection?> ByCodeAsync(string? code)
		{
			var text = (code ?? string.Empty).Trim().TrimEnd('/');
			text = text[(text.LastIndexOf('/') + 1)..];
			return text.Length is 0 or > 32 ? Task.FromResult<ContentCollection?>(null) : _context.ContentCollections.AsNoTracking().FirstOrDefaultAsync(c => c.Code == text);
		}

		private static string NewCode()
		{
			const string letters = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
			return string.Concat(Enumerable.Range(0, 12).Select(_ => letters[RandomNumberGenerator.GetInt32(letters.Length)]));
		}

		private async Task<ActionResult?> ApplyAsync(ContentCollection collection, SaveContentCollectionDto dto)
		{
			var name = (dto.Name ?? string.Empty).Trim();
			var description = (dto.Description ?? string.Empty).Trim();
			var ids = (dto.EntityIds ?? new()).Distinct().ToList();
			if (name.Length is 0 or > 100 || description.Length > 2000 || ids.Count is 0 or > MaxEntries)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"A name up to 100 characters and 1 to {MaxEntries} entries.");
			}
			var entries = await _homebrew.FindAsync(ids, LanguageCode.En);
			if (ids.Any(i => !entries.TryGetValue(i, out var e) || e.IsBase || e.AuthorId != UserId))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Only Homebrew entries of yours.");
			}
			collection.Name = name;
			collection.Description = description;
			collection.EntityIds = ids;
			return null;
		}

		private static ContentCollectionSummaryDto Summary(ContentCollection c) => new(c.Id, c.Name, c.Description, c.Code, c.EntityIds.ToList(), c.UpdatedAt);
	}
}
