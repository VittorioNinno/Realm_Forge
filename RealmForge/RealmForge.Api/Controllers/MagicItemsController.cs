using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Magic items: localized list (items and their variants, with server-side filters on ruleset and category) and
	///	detail. Same access rules as the other content modules (<see cref="ContentAccess"/>); for now only Base content.
	///	</summary>
	[ApiController]
	[Route("api/magic-items")]
	public class MagicItemsController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;

		private static readonly JsonSerializerOptions MechanicsJson = new(JsonSerializerDefaults.Web);

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public MagicItemsController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/magic-items?lang=2&ruleset=1&type=9
		[HttpGet]
		public async Task<ActionResult<List<MagicItemResponseDto>>> GetMagicItems(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] MagicItemType? type = null)
		{
			var query = _context.MagicItems.AsNoTracking().Include(e => e.Translations).AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(e => e.Ruleset == ruleset.Value);
			}

			if (type.HasValue)
			{
				query = query.Where(e => e.Type == type.Value);
			}

			query = ContentAccess.ListedFor(query, User, await _shares.SharedWithAsync(User));

			var items = await query.AsSplitQuery().ToListAsync();
			var listed = items.Select(e => e.Id).ToHashSet();

			var dtos = items
				//	A variant is listed with its item
				.Where(e => e.ParentId is null || listed.Contains(e.ParentId.Value))
				.Select(e =>
				{
					var tr = e.Translations.Localize(lang);
					return new MagicItemResponseDto(
						e.Id,
						tr?.Name ?? "Unknown",
						e.Ruleset,
						e.IsOfficialSRD,
						e.Type,
						e.Rarity,
						e.RequiresAttunement,
						tr?.Subtitle ?? string.Empty,
						MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength),
						e.ParentId,
						ReadMechanics(e.Mechanics),
						tr?.Alias,
						e.Source,
						e.Visibility);
				})
				.OrderBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase)
				.ToList();

			return Ok(dtos);
		}

		//	GET: api/magic-items/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<MagicItemDetailResponseDto>> GetMagicItem(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var item = await _context.MagicItems.AsNoTracking()
				.Include(e => e.Translations)
				.Include(e => e.Parent).ThenInclude(p => p!.Translations)
				.Include(e => e.Variants).ThenInclude(v => v.Translations)
				.AsSplitQuery()
				.FirstOrDefaultAsync(e => e.Id == id);

			var shared = await _shares.SharedWithAsync(User);

			//	Private entries of other users answer 404, as if they did not exist
			if (item == null || !_access.CanView(item, User, shared) || (item.Parent is { } parent && !_access.CanView(parent, User, shared)))
			{
				return NotFound();
			}

			var tr = item.Translations.Localize(lang);
			var parentText = item.Parent?.Translations.Localize(lang);
			var description = string.IsNullOrWhiteSpace(tr?.Description) ? parentText?.Description ?? string.Empty : tr!.Description;

			var variants = item.Variants
				.OrderBy(v => v.SortOrder)
				.Select(v =>
				{
					var vt = v.Translations.Localize(lang);
					return new MagicItemVariantDto(v.Id, vt?.Name ?? "Unknown", v.Rarity, v.RequiresAttunement, vt?.Subtitle ?? string.Empty, ReadMechanics(v.Mechanics));
				})
				.ToList();

			return Ok(new MagicItemDetailResponseDto(
				item.Id,
				tr?.Name ?? "Unknown",
				item.Ruleset,
				item.IsOfficialSRD,
				item.Type,
				item.Rarity,
				item.RequiresAttunement,
				tr?.Subtitle ?? string.Empty,
				description,
				ReadMechanics(item.Mechanics),
				item.ParentId,
				parentText?.Name,
				variants,
				tr?.Alias ?? parentText?.Alias,
				_access.CanModify(item, User),
				item.Source,
				item.Visibility));
		}

		private static MagicItemProperties? ReadMechanics(string? json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return null;
			}
			try
			{
				return JsonSerializer.Deserialize<MagicItemProperties>(json, MechanicsJson);
			}
			catch (JsonException)
			{
				return null;
			}
		}
	}
}
