using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Content;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Homebrew to a file and back: entries the account can read written as JSON (each with what belongs to it), and a
	///	file read back as new private entries of the account, on this RealmForge or on another one.
	///	</summary>
	[ApiController]
	[Route("api/content")]
	[Authorize]
	public class ContentTransferController : ControllerBase
	{
		public const int MaxEntries = 100;

		private readonly RealmForgeDbContext _context;
		private readonly ContentCopier _copier;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;
		private readonly HomebrewLookup _homebrew;

		public ContentTransferController(RealmForgeDbContext context, ContentCopier copier, ContentAccess access, ShareService shares, HomebrewLookup homebrew)
		{
			_context = context;
			_copier = copier;
			_access = access;
			_shares = shares;
			_homebrew = homebrew;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/content/mine?lang=2 — the Homebrew the account wrote, with the languages of its texts
		[HttpGet("mine")]
		public async Task<ActionResult<List<MyHomebrewDto>>> Mine([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var mine = await _homebrew.ByAuthorAsync(UserId, lang);
			return Ok(mine.Select(e => new MyHomebrewDto(e.Kind, e.Id, e.Name, e.Link, e.Ruleset, e.Visibility, e.Languages?.ToList() ?? new())).ToList());
		}

		//	POST: api/content/export?lang=2 — the Homebrew entries asked for, the ones the account can read
		[HttpPost("export")]
		public async Task<ActionResult<HomebrewExportDto>> Export([FromBody] HomebrewExportRequestDto request, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (request.Entries is not { Count: > 0 and <= MaxEntries })
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"From 1 to {MaxEntries} entries.");
			}
			var shared = await _shares.SharedWithAsync(User);
			var file = new HomebrewExportDto();
			foreach (var (kind, id) in request.Entries.Select(e => (e.Kind, e.Id)).Distinct())
			{
				if (!ContentCopier.Kinds.TryGetValue(kind, out var type) || await _context.FindAsync(type, id) is not GameEntity entity
					|| entity.IsOfficialSRD || !_access.CanView(entity, User, shared))
				{
					continue;
				}
				var rows = await _copier.SnapshotAsync(entity);
				file.Items.Add(new HomebrewExportItemDto
				{
					Kind = kind,
					Name = ContentCopier.NameOf(entity, lang),
					Rows = rows.Select(r => JsonSerializer.SerializeToElement(r, ContentCopier.Json)).ToList()
				});
			}
			if (file.Items.Count == 0)
			{
				return NotFound();
			}
			return Ok(file);
		}

		//	POST: api/content/import?lang=2 — every entry of a file as a new private entry of the account
		[HttpPost("import")]
		[RequireConfirmedEmail]
		[RequestSizeLimit(8_000_000)]
		public async Task<ActionResult<List<HomebrewImportedDto>>> Import([FromBody] HomebrewExportDto file, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (file.Format != HomebrewExportDto.FormatName || file.Version is < 1 or > HomebrewExportDto.CurrentVersion)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Not a RealmForge Homebrew file.", detail: "format");
			}
			if (file.Items is not { Count: > 0 and <= MaxEntries } || file.Items.Sum(i => i.Rows?.Count ?? 0) > ContentCopier.MaxRows)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The file is empty or too big.", detail: "size");
			}
			var results = new List<(HomebrewExportItemDto Item, object? Entity, string? Missing)>();
			foreach (var item in file.Items)
			{
				List<ContentRow> rows;
				try
				{
					rows = (item.Rows ?? new()).Select(r => r.Deserialize<ContentRow>(ContentCopier.Json)!).Where(r => r is not null).ToList();
				}
				catch (JsonException)
				{
					results.Add((item, null, "format"));
					continue;
				}
				if (!ContentCopier.Kinds.TryGetValue(item.Kind ?? string.Empty, out var type) || rows.Count == 0 || rows[0].Type != type.Name)
				{
					results.Add((item, null, "type"));
					continue;
				}
				var (entity, missing) = await _copier.InsertAsync(rows, UserId);
				results.Add((item, entity, missing));
			}
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: "The file could not be imported.", detail: "conflict");
			}
			var ids = results.Select(r => (r.Entity as GameEntity)?.Id).OfType<Guid>().ToList();
			var links = await _homebrew.FindAsync(ids, lang);
			return Ok(results.Select(r =>
			{
				var id = (r.Entity as GameEntity)?.Id;
				var name = r.Entity is { } e ? ContentCopier.NameOf(e, lang) : r.Item.Name ?? "?";
				return new HomebrewImportedDto(r.Item.Kind ?? "?", name, id, id is { } i ? links.GetValueOrDefault(i)?.Link : null, r.Missing);
			}).ToList());
		}
	}
}
