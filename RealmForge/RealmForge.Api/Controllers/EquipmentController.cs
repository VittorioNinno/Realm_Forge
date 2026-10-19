using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Equipment: localized list (with server-side filters on ruleset, origin and category) and detail,
	///	and Homebrew create/update/delete. Same access rules as the other content modules (<see cref="ContentAccess"/>).
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public partial class EquipmentController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;
		private const int MaxTextLength = 20000;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;

		public EquipmentController(RealmForgeDbContext context, ContentAccess access)
		{
			_context = context;
			_access = access;
		}

		//	GET: api/equipment?lang=2&ruleset=2&isOfficial=true&category=1
		[HttpGet]
		public async Task<ActionResult<List<EquipmentResponseDto>>> GetEquipment(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null,
			[FromQuery] EquipmentCategory? category = null)
		{
			var query = _context.Equipment.AsNoTracking().Include(e => e.Translations).AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(e => e.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(e => e.IsOfficialSRD == isOfficial.Value);
			}

			if (category.HasValue)
			{
				query = query.Where(e => e.Category == category.Value);
			}

			query = ContentAccess.ListedFor(query, User);

			var items = await query.ToListAsync();

			var dtos = items.Select(e =>
			{
				var tr = e.Translations.Localize(lang);
				return new EquipmentResponseDto(
					e.Id,
					tr?.Name ?? "Unknown",
					e.Ruleset,
					e.IsOfficialSRD,
					ToStats(e),
					MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength),
					_access.CanModify(e, User),
					e.Source,
					e.Visibility);
			})
			.OrderBy(e => e.Stats.Category)
			.ThenBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase)
			.ToList();

			return Ok(dtos);
		}

		//	GET: api/equipment/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<EquipmentDetailResponseDto>> GetItem(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var item = await _context.Equipment.AsNoTracking().Include(e => e.Translations).FirstOrDefaultAsync(e => e.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (item == null || !_access.CanView(item, User))
			{
				return NotFound();
			}

			return Ok(ToDetailDto(item, lang, _access.CanModify(item, User)));
		}

		//	POST: api/equipment
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<EquipmentDetailResponseDto>> CreateItem([FromBody] SaveEquipmentDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var item = new Equipment
			{
				Ruleset = dto.Ruleset,

				//	Content created through the API is always Homebrew; Base data comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
				Visibility = dto.Visibility,
				Translations = dto.Translations.Select(t => ApplyTranslation(new EquipmentTranslation { Language = t.Language }, t)).ToList()
			};

			ApplyStats(item, dto.Stats);

			_context.Equipment.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetItem), new { id = item.Id }, ToDetailDto(item, lang, canEdit: true));
		}

		//	PUT: api/equipment/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateItem(Guid id, [FromBody] SaveEquipmentDto dto)
		{
			if (id != dto.Id)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "ID mismatch between route and payload.");
			}

			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var item = await _context.Equipment.Include(e => e.Translations).FirstOrDefaultAsync(e => e.Id == id);

			if (item == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, item);
			if (denied != null)
			{
				return denied;
			}

			item.Ruleset = dto.Ruleset;
			item.Visibility = dto.Visibility;
			ApplyStats(item, dto.Stats);

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var stale in item.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				item.Translations.Remove(stale);
			}

			foreach (var tDto in dto.Translations)
			{
				var existing = item.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					ApplyTranslation(existing, tDto);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.EquipmentTranslations.Add(ApplyTranslation(new EquipmentTranslation { EquipmentId = item.Id, Language = tDto.Language }, tDto));
				}
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/equipment/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteItem(Guid id)
		{
			var item = await _context.Equipment.FindAsync(id);

			if (item == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, item);
			if (denied != null)
			{
				return denied;
			}

			_context.Equipment.Remove(item);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		public static EquipmentStatsDto ToStats(Equipment e) => new()
		{
			Category = e.Category,
			CostInCopper = e.CostInCopper,
			WeightInPounds = Trim(e.WeightInPounds),
			Quantity = e.Quantity,
			WeaponCategory = e.WeaponCategory,
			WeaponRange = e.WeaponRange,
			DamageDice = e.DamageDice,
			DamageType = e.DamageType,
			VersatileDamageDice = e.VersatileDamageDice,
			WeaponProperties = e.WeaponProperties.OrderBy(p => p).ToList(),
			NormalRange = e.NormalRange,
			LongRange = e.LongRange,
			Mastery = e.Mastery,
			ArmorCategory = e.ArmorCategory,
			ArmorClass = e.ArmorClass,
			ArmorAddsDexterity = e.ArmorAddsDexterity,
			ArmorMaxDexterityBonus = e.ArmorMaxDexterityBonus,
			StrengthRequirement = e.StrengthRequirement,
			StealthDisadvantage = e.StealthDisadvantage,
			ToolCategory = e.ToolCategory,
			ToolAbility = e.ToolAbility,
			FocusType = e.FocusType,
			SpeedInFeet = e.SpeedInFeet,
			SpeedInMilesPerHour = Trim(e.SpeedInMilesPerHour),
			CarryingCapacityInPounds = e.CarryingCapacityInPounds
		};

		//	numeric(9,3) columns come back as 3.000: drop the trailing zeros so the JSON reads 3
		private static decimal? Trim(decimal? value) => value / 1.000000000000000000000000000000000m;

		private static EquipmentDetailResponseDto ToDetailDto(Equipment e, LanguageCode lang, bool canEdit)
		{
			var tr = e.Translations.Localize(lang);
			return new EquipmentDetailResponseDto(e.Id, tr?.Name ?? "Unknown", e.Ruleset, e.IsOfficialSRD, ToStats(e),
				tr?.Description ?? string.Empty, canEdit, e.Source, e.Visibility);
		}

		///	<summary>
		///	Copies the statistics, keeping only the fields that belong to the item's category.
		///	</summary>
		private static void ApplyStats(Equipment item, EquipmentStatsDto s)
		{
			var weapon = s.Category == EquipmentCategory.Weapon;
			var armor = s.Category == EquipmentCategory.Armor;

			item.Category = s.Category;
			item.CostInCopper = s.CostInCopper;
			item.WeightInPounds = s.WeightInPounds;
			item.Quantity = s.Quantity;

			item.WeaponCategory = weapon ? s.WeaponCategory : null;
			item.WeaponRange = weapon ? s.WeaponRange : null;
			item.DamageDice = weapon ? Normalize(s.DamageDice) : null;
			item.DamageType = weapon ? s.DamageType : null;
			item.VersatileDamageDice = weapon && s.WeaponProperties.Contains(WeaponProperty.Versatile) ? Normalize(s.VersatileDamageDice) : null;
			item.WeaponProperties = weapon ? s.WeaponProperties.Distinct().OrderBy(p => p).ToList() : new List<WeaponProperty>();
			item.NormalRange = weapon ? s.NormalRange : null;
			item.LongRange = weapon ? s.LongRange : null;
			item.Mastery = weapon ? s.Mastery : null;

			item.ArmorCategory = armor ? s.ArmorCategory : null;
			item.ArmorClass = armor ? s.ArmorClass : null;
			item.ArmorAddsDexterity = armor && s.ArmorAddsDexterity;
			item.ArmorMaxDexterityBonus = armor && s.ArmorAddsDexterity ? s.ArmorMaxDexterityBonus : null;
			item.StrengthRequirement = armor ? s.StrengthRequirement : null;
			item.StealthDisadvantage = armor && s.StealthDisadvantage;

			item.ToolCategory = s.Category == EquipmentCategory.Tool ? s.ToolCategory : null;
			item.ToolAbility = s.Category == EquipmentCategory.Tool ? s.ToolAbility : null;
			item.FocusType = s.Category == EquipmentCategory.SpellcastingFocus ? s.FocusType : null;

			item.SpeedInFeet = s.Category == EquipmentCategory.Mount ? s.SpeedInFeet : null;
			item.CarryingCapacityInPounds = s.Category == EquipmentCategory.Mount ? s.CarryingCapacityInPounds : null;
			item.SpeedInMilesPerHour = s.Category == EquipmentCategory.Ship ? s.SpeedInMilesPerHour : null;
		}

		private static EquipmentTranslation ApplyTranslation(EquipmentTranslation target, EquipmentTranslationDto source)
		{
			target.Name = source.Name.Trim();
			target.Description = source.Description?.Trim() ?? string.Empty;
			return target;
		}

		private static string? Normalize(string? value) =>
			string.IsNullOrWhiteSpace(value) ? null : value.Trim();

		[GeneratedRegex(@"^\d{1,2}(d\d{1,3})?$")]
		private static partial Regex DiceRegex();

		private static string? Validate(SaveEquipmentDto dto)
		{
			var s = dto.Stats;

			if (dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (dto.Translations.Any(t => t.Name.Length > 150 || (t.Description?.Length ?? 0) > MaxTextLength))
			{
				return "A text is too long.";
			}

			if (!Enum.IsDefined(s.Category) || !Enum.IsDefined(dto.Ruleset))
			{
				return "Unknown category or ruleset.";
			}

			if (s.CostInCopper is < 0 || s.WeightInPounds is < 0 || s.Quantity < 1 || s.Quantity > 10000)
			{
				return "Cost, weight and quantity cannot be negative.";
			}

			if (s.Category == EquipmentCategory.Weapon)
			{
				//	Only a weapon with the Special property (such as the 2014 net) can deal no damage
				var noDamage = string.IsNullOrWhiteSpace(s.DamageDice) && s.DamageType is null && s.WeaponProperties.Contains(WeaponProperty.Special);
				if (s.WeaponCategory is null || s.WeaponRange is null
					|| (!noDamage && (s.DamageType is null || !Enum.IsDefined(s.DamageType.Value) || string.IsNullOrWhiteSpace(s.DamageDice) || !DiceRegex().IsMatch(s.DamageDice.Trim()))))
				{
					return "A weapon needs a category, melee or ranged, damage dice (e.g. 1d8) and a damage type.";
				}

				if (s.WeaponProperties.Any(p => !Enum.IsDefined(p)) || (s.Mastery.HasValue && !Enum.IsDefined(s.Mastery.Value)))
				{
					return "Unknown weapon property or mastery.";
				}

				if (s.WeaponProperties.Contains(WeaponProperty.Versatile) && (string.IsNullOrWhiteSpace(s.VersatileDamageDice) || !DiceRegex().IsMatch(s.VersatileDamageDice.Trim())))
				{
					return "A versatile weapon needs its two-handed damage dice.";
				}

				var ranged = s.WeaponRange == WeaponRange.Ranged || s.WeaponProperties.Contains(WeaponProperty.Thrown);
				if (ranged && (s.NormalRange is null or < 1 || s.LongRange is null || s.LongRange < s.NormalRange))
				{
					return "Ranged and thrown weapons need a normal and a long range.";
				}
			}

			if (s.Category == EquipmentCategory.Armor)
			{
				if (s.ArmorCategory is null || !Enum.IsDefined(s.ArmorCategory.Value) || s.ArmorClass is null or < 0 or > 30)
				{
					return "Armor needs a category and an Armor Class between 0 and 30.";
				}

				if (s.ArmorMaxDexterityBonus is < 0 || s.StrengthRequirement is < 1 or > 30)
				{
					return "Invalid Dexterity cap or Strength requirement.";
				}
			}

			if (s.Category == EquipmentCategory.Tool && (s.ToolCategory is null || !Enum.IsDefined(s.ToolCategory.Value)))
			{
				return "A tool needs its kind.";
			}

			if (s.Category == EquipmentCategory.SpellcastingFocus && (s.FocusType is null || !Enum.IsDefined(s.FocusType.Value)))
			{
				return "A spellcasting focus needs its kind.";
			}

			return null;
		}

		#endregion
	}
}
