using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Magic items: localized list (items and their variants, with server-side filters on ruleset and category) and
	///	detail, and the Homebrew items of the users (a new item, or a variant of another one: listed under it with its own
	///	name, rarity and rules). Same access rules as the other content modules (<see cref="ContentAccess"/>).
	///	</summary>
	[ApiController]
	[Route("api/magic-items")]
	public class MagicItemsController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;
		public const int MaxHomebrewPerUser = 500;
		private const int MaxMarkdownLength = 20000;
		private const int MaxEffects = 20;

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
				//	A variant is listed with its item (a Homebrew variant also on its own)
				.Where(e => e.ParentId is null || !e.IsOfficialSRD || listed.Contains(e.ParentId.Value))
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
				.Where(v => _access.CanView(v, User, shared))
				.OrderBy(v => v.IsOfficialSRD ? 0 : 1)
				.ThenBy(v => v.SortOrder)
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

		//	GET: api/magic-items/{id}/edit — the item as the editor saves it, both languages and the texts of its own
		//	(a variant without a description of its own gets the one of its item, to start from)
		[HttpGet("{id:guid}/edit")]
		public async Task<ActionResult<SaveMagicItemDto>> GetForEdit(Guid id)
		{
			var item = await _context.MagicItems.AsNoTracking()
				.Include(e => e.Translations)
				.Include(e => e.Parent).ThenInclude(p => p!.Translations)
				.AsSplitQuery()
				.FirstOrDefaultAsync(e => e.Id == id);
			if (item == null || !_access.CanView(item, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}

			return Ok(new SaveMagicItemDto
			{
				Ruleset = item.Ruleset,
				Visibility = item.Visibility,
				Type = item.Type,
				Rarity = item.Rarity,
				RequiresAttunement = item.RequiresAttunement,
				Mechanics = ReadMechanics(item.Mechanics),
				VariantOfId = item.ParentId,
				Translations = item.Translations
					.Where(t => t.Language is LanguageCode.It or LanguageCode.En)
					.Select(t => new MagicItemTextDto
					{
						Language = t.Language,
						Name = t.Name,
						Alias = t.Alias,
						Subtitle = t.Subtitle,
						Description = string.IsNullOrWhiteSpace(t.Description)
							? item.Parent?.Translations.FirstOrDefault(p => p.Language == t.Language)?.Description ?? string.Empty
							: t.Description
					})
					.ToList()
			});
		}

		//	POST: api/magic-items
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<MagicItemDetailResponseDto>> CreateMagicItem([FromBody] SaveMagicItemDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var userId = ContentAccess.GetUserId(User);
			if (await _context.MagicItems.CountAsync(e => e.AuthorId == userId) >= MaxHomebrewPerUser)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: $"At most {MaxHomebrewPerUser} Homebrew magic items per account.");
			}

			var (parentId, parentError) = await ParentOfAsync(dto.VariantOfId, null);
			if (parentError is not null)
			{
				return parentError;
			}

			var item = new MagicItem
			{
				//	Content created through the API is always Homebrew; Base content comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = userId,
				ParentId = parentId,
				SortOrder = 1000
			};
			Apply(item, dto);
			item.Translations = dto.Translations.Select(t => Translation(new MagicItemTranslation(), t)).ToList();

			_context.MagicItems.Add(item);
			await _context.SaveChangesAsync();

			var tr = item.Translations.Localize(lang);
			return CreatedAtAction(nameof(GetMagicItem), new { id = item.Id }, new MagicItemDetailResponseDto(
				item.Id, tr?.Name ?? "Unknown", item.Ruleset, false, item.Type, item.Rarity, item.RequiresAttunement,
				tr?.Subtitle ?? string.Empty, tr?.Description ?? string.Empty, ReadMechanics(item.Mechanics), item.ParentId, null,
				new List<MagicItemVariantDto>(), tr?.Alias, true, item.Source, item.Visibility));
		}

		//	PUT: api/magic-items/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateMagicItem(Guid id, [FromBody] SaveMagicItemDto dto)
		{
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var item = await _context.MagicItems.Include(e => e.Translations).FirstOrDefaultAsync(e => e.Id == id);
			if (item is null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, item);
			if (denied is not null)
			{
				return denied;
			}

			var (parentId, parentError) = await ParentOfAsync(dto.VariantOfId, item.Id);
			if (parentError is not null)
			{
				return parentError;
			}

			Apply(item, dto);
			item.ParentId = parentId;

			var languages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var tr in item.Translations.Where(t => !languages.Contains(t.Language)).ToList())
			{
				item.Translations.Remove(tr);
			}
			foreach (var text in dto.Translations)
			{
				var existing = item.Translations.FirstOrDefault(t => t.Language == text.Language);
				if (existing is not null)
				{
					Translation(existing, text);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.MagicItemTranslations.Add(Translation(new MagicItemTranslation { MagicItemId = item.Id }, text));
				}
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/magic-items/{id} — its own variants go with it, the variants of other users stay (with the text of the item)
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteMagicItem(Guid id, [FromServices] TrashBin bin)
		{
			var item = await _context.MagicItems.Include(e => e.Translations).FirstOrDefaultAsync(e => e.Id == id);
			if (item is null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, item);
			if (denied is not null)
			{
				return denied;
			}

			var others = await _context.MagicItems.Include(e => e.Translations)
				.Where(e => e.ParentId == item.Id && e.AuthorId != item.AuthorId)
				.ToListAsync();
			if (others.Count > 0)
			{
				foreach (var variant in others)
				{
					variant.ParentId = null;
					foreach (var text in variant.Translations.Where(t => string.IsNullOrWhiteSpace(t.Description)))
					{
						text.Description = item.Translations.FirstOrDefault(t => t.Language == text.Language)?.Description ?? string.Empty;
					}
				}
				await _context.SaveChangesAsync();
			}

			//	Kept in the bin for a few days, to be restored
			await bin.AddAsync(item, "magic-item", ContentAccess.GetUserId(User) ?? string.Empty, item.Id);
			_context.MagicItems.Remove(item);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		private static void Apply(MagicItem item, SaveMagicItemDto dto)
		{
			item.Ruleset = dto.Ruleset;
			item.Visibility = dto.Visibility;
			item.Type = dto.Type;
			item.Rarity = dto.Rarity;
			item.RequiresAttunement = dto.RequiresAttunement;

			//	The rules keep only what the sheet applies; rarity and attunement are the ones of the item
			var mechanics = dto.Mechanics;
			if (mechanics is null || (mechanics.Effects.Count == 0 && mechanics.Charges <= 0 && string.IsNullOrWhiteSpace(mechanics.HealDice)))
			{
				item.Mechanics = null;
				return;
			}
			mechanics.Rarity = dto.Rarity ?? ItemRarity.Uncommon;
			mechanics.RequiresAttunement = dto.RequiresAttunement;
			mechanics.ChargesUsed = 0;
			mechanics.Template = null;
			if (mechanics.Charges <= 0)
			{
				mechanics.Charges = 0;
				mechanics.Recharge = ItemRecharge.None;
				mechanics.RechargeDice = null;
			}
			mechanics.RechargeDice = string.IsNullOrWhiteSpace(mechanics.RechargeDice) ? null : mechanics.RechargeDice.Trim().ToLowerInvariant();
			mechanics.HealDice = string.IsNullOrWhiteSpace(mechanics.HealDice) ? null : mechanics.HealDice.Trim().ToLowerInvariant();
			foreach (var effect in mechanics.Effects)
			{
				if (effect.Kind is not (MagicEffectKind.SetAbilityScore or MagicEffectKind.AbilityScoreBonus))
				{
					effect.Ability = null;
				}
				if (effect.Kind != MagicEffectKind.Resistance)
				{
					effect.DamageType = null;
				}
			}
			item.Mechanics = JsonSerializer.Serialize(mechanics, MechanicsJson);
		}

		private static MagicItemTranslation Translation(MagicItemTranslation target, MagicItemTextDto t)
		{
			target.Language = t.Language;
			target.Name = t.Name?.Trim() ?? string.Empty;
			target.Alias = string.IsNullOrWhiteSpace(t.Alias) ? null : t.Alias.Trim();
			target.Subtitle = t.Subtitle?.Trim() ?? string.Empty;
			target.Description = t.Description?.Trim() ?? string.Empty;
			return target;
		}

		//	A variant hangs from an item the user can see; a variant of a variant hangs from the same item (one level only),
		//	and an item with variants of its own cannot become a variant
		private async Task<(Guid? ParentId, ActionResult? Error)> ParentOfAsync(Guid? variantOfId, Guid? self)
		{
			if (variantOfId is not { } sourceId)
			{
				return (null, null);
			}
			var source = await _context.MagicItems.AsNoTracking().FirstOrDefaultAsync(e => e.Id == sourceId);
			var shared = await _shares.SharedWithAsync(User);
			if (source is null || !_access.CanView(source, User, shared))
			{
				return (null, Problem(statusCode: StatusCodes.Status400BadRequest, title: "The original magic item does not exist."));
			}
			var parentId = source.ParentId ?? source.Id;
			if (parentId == self || (self is { } id && await _context.MagicItems.AnyAsync(e => e.ParentId == id)))
			{
				return (null, Problem(statusCode: StatusCodes.Status400BadRequest, title: "A magic item with variants cannot be a variant."));
			}
			return (parentId, null);
		}

		private static readonly Regex DicePattern = new(@"^\d{1,2}d\d{1,3}([+-]\d{1,3})?$", RegexOptions.CultureInvariant);

		internal static string? Validate(SaveMagicItemDto dto)
		{
			if (dto.Translations is null || dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}
			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1) || dto.Translations.Any(t => !Enum.IsDefined(t.Language)))
			{
				return "Only one translation per known language is allowed.";
			}
			if (!Enum.IsDefined(dto.Ruleset) || !Enum.IsDefined(dto.Visibility) || !Enum.IsDefined(dto.Type)
				|| (dto.Rarity is { } rarity && !Enum.IsDefined(rarity)))
			{
				return "Unknown ruleset, visibility, category or rarity.";
			}
			foreach (var t in dto.Translations)
			{
				if (t.Name.Trim().Length > 150 || (t.Alias?.Trim().Length ?? 0) > 150)
				{
					return "Names: at most 150 characters.";
				}
				if ((t.Subtitle?.Trim().Length ?? 0) > 300 || (t.Description?.Trim().Length ?? 0) > MaxMarkdownLength)
				{
					return "The item line or the description is too long.";
				}
			}
			if (dto.Mechanics is { } m)
			{
				if (m.Effects is null || m.Effects.Count > MaxEffects)
				{
					return $"At most {MaxEffects} effects.";
				}
				foreach (var e in m.Effects)
				{
					if (!Enum.IsDefined(e.Kind) || e.Value is < -30 or > 30
						|| (e.Ability is { } ability && !Enum.IsDefined(ability))
						|| (e.DamageType is { } damage && !Enum.IsDefined(damage))
						|| (e.Kind is MagicEffectKind.SetAbilityScore or MagicEffectKind.AbilityScoreBonus && e.Ability is null)
						|| (e.Kind == MagicEffectKind.Resistance && e.DamageType is null))
					{
						return "Unknown or incomplete effect.";
					}
				}
				if (m.Charges is < 0 or > 99 || !Enum.IsDefined(m.Recharge))
				{
					return "Charges (0-99) or recharge out of range.";
				}
				if ((!string.IsNullOrWhiteSpace(m.RechargeDice) && !DicePattern.IsMatch(m.RechargeDice.Trim().ToLowerInvariant()))
					|| (!string.IsNullOrWhiteSpace(m.HealDice) && !DicePattern.IsMatch(m.HealDice.Trim().ToLowerInvariant())))
				{
					return "Dice must be written like 2d4+2.";
				}
			}
			return null;
		}

		#endregion

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
