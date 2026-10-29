using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	My bin: what I deleted in the last days, to restore it or to delete it for good.
	///	</summary>
	[ApiController]
	[Route("api/trash")]
	[Authorize]
	public class TrashController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly TrashBin _bin;
		private readonly HomebrewLookup _homebrew;

		public TrashController(RealmForgeDbContext context, TrashBin bin, HomebrewLookup homebrew)
		{
			_context = context;
			_bin = bin;
			_homebrew = homebrew;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/trash?lang=2
		[HttpGet]
		public async Task<ActionResult<List<TrashEntryDto>>> GetTrash([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var now = DateTimeOffset.UtcNow;
			var entries = await _context.TrashEntries.AsNoTracking()
				.Where(t => t.UserId == UserId && t.ExpiresAt > now)
				.OrderByDescending(t => t.DeletedAt)
				.Select(t => new { t.Id, t.Kind, t.EntityId, t.NameIt, t.NameEn, t.DeletedAt, t.ExpiresAt })
				.ToListAsync();
			return Ok(entries.Select(t => new TrashEntryDto(t.Id, t.Kind, t.EntityId, lang == LanguageCode.En ? t.NameEn : t.NameIt, t.DeletedAt, t.ExpiresAt)).ToList());
		}

		//	POST: api/trash/{id}/restore — 409 with the kind of the missing entry in "detail" when it depends on
		//	something deleted in the meantime
		[HttpPost("{id:guid}/restore")]
		public async Task<ActionResult<TrashRestoredDto>> Restore(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var now = DateTimeOffset.UtcNow;
			var entry = await _context.TrashEntries.FirstOrDefaultAsync(t => t.Id == id && t.UserId == UserId && t.ExpiresAt > now);
			if (entry is null)
			{
				return NotFound();
			}

			var result = await _bin.RestoreAsync(entry);
			if (!result.Ok)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "The entry cannot be restored.", detail: result.MissingKind);
			}

			_context.TrashEntries.Remove(entry);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "The entry cannot be restored.");
			}

			var link = entry.Kind switch
			{
				"character" => $"characters/{entry.EntityId}",
				"campaign" => $"campaigns/{entry.EntityId}",
				_ => (await _homebrew.FindAsync(new[] { entry.EntityId }, lang)).GetValueOrDefault(entry.EntityId)?.Link ?? string.Empty
			};
			return Ok(new TrashRestoredDto(entry.Kind, entry.EntityId, link));
		}

		//	DELETE: api/trash/{id} — gone for good, now
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Purge(Guid id)
		{
			var entry = await _context.TrashEntries.FirstOrDefaultAsync(t => t.Id == id && t.UserId == UserId);
			if (entry is null)
			{
				return NotFound();
			}
			_context.TrashEntries.Remove(entry);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
