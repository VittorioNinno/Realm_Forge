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
	///	Classes with their features and subclasses: localized list and detail, and Homebrew create/update/delete.
	///	Subclasses (also for Base classes) are managed by <see cref="SubclassesController"/>.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class ClassesController : ControllerBase
	{
		private const int ShortDescriptionLength = 180;
		internal const int MaxTextLength = 40000;
		internal const int MaxFeatures = 100;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;

		public ClassesController(RealmForgeDbContext context, ContentAccess access)
		{
			_context = context;
			_access = access;
		}

		//	GET: api/classes?lang=2&ruleset=1&isOfficial=true
		[HttpGet]
		public async Task<ActionResult<List<ClassResponseDto>>> GetClasses(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = _context.Classes
				.AsNoTracking()
				.Include(c => c.Translations)
				.Include(c => c.Subclasses).ThenInclude(s => s.Translations)
				.AsSplitQuery()
				.AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(c => c.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(c => c.IsOfficialSRD == isOfficial.Value);
			}

			query = ContentAccess.ListedFor(query, User);

			var classes = await query.ToListAsync();

			var dtos = classes.Select(c =>
			{
				var tr = c.Translations.Localize(lang);
				var subclassNames = c.Subclasses
					.Where(s => _access.IsListed(s, User))
					.Select(s => s.Translations.Localize(lang)?.Name ?? "Unknown")
					.OrderBy(n => n, StringComparer.CurrentCultureIgnoreCase)
					.ToList();

				return new ClassResponseDto(
					c.Id,
					tr?.Name ?? "Unknown",
					c.Ruleset,
					c.IsOfficialSRD,
					c.HitDie,
					c.PrimaryAbilities,
					c.SavingThrows,
					c.CasterProgression,
					c.SpellcastingAbility,
					tr?.SubclassTitle,
					subclassNames,
					MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength),
					_access.CanModify(c, User),
					c.Source,
					c.Visibility);
			})
			.OrderBy(c => c.Name, StringComparer.CurrentCultureIgnoreCase)
			.ToList();

			return Ok(dtos);
		}

		//	GET: api/classes/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ClassDetailResponseDto>> GetClass(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var characterClass = await _context.Classes
				.AsNoTracking()
				.Include(c => c.Translations)
				.Include(c => c.Features).ThenInclude(f => f.Translations)
				.Include(c => c.Subclasses).ThenInclude(s => s.Translations)
				.Include(c => c.Subclasses).ThenInclude(s => s.Features).ThenInclude(f => f.Translations)
				.AsSplitQuery()
				.FirstOrDefaultAsync(c => c.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (characterClass == null || !_access.CanView(characterClass, User))
			{
				return NotFound();
			}

			var tr = characterClass.Translations.Localize(lang);
			var className = tr?.Name ?? "Unknown";

			//	Subclasses follow the list rule: other users' private or link-only subclasses are left out
			var subclasses = characterClass.Subclasses
				.Where(s => _access.IsListed(s, User))
				.Select(s => ToSubclassDto(s, className, lang, _access.CanModify(s, User)))
				.OrderBy(s => s.IsOfficialSRD ? 0 : 1)
				.ThenBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase)
				.ToList();

			return Ok(new ClassDetailResponseDto(
				characterClass.Id,
				className,
				tr?.Description ?? string.Empty,
				characterClass.Ruleset,
				characterClass.IsOfficialSRD,
				characterClass.HitDie,
				characterClass.PrimaryAbilities,
				characterClass.SavingThrows,
				characterClass.SkillChoiceCount,
				characterClass.SkillOptions,
				characterClass.CasterProgression,
				characterClass.SpellcastingAbility,
				characterClass.SubclassLevel,
				tr?.SubclassTitle,
				tr?.ArmorProficiencies,
				tr?.WeaponProficiencies,
				tr?.ToolProficiencies,
				tr?.StartingEquipment,
				tr?.ProgressionTable,
				ToFeatureDtos(characterClass.Features, lang),
				subclasses,
				_access.CanModify(characterClass, User),
				characterClass.Source,
				characterClass.Visibility));
		}

		//	POST: api/classes
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<ClassResponseDto>> CreateClass([FromBody] SaveClassDto dto)
		{
			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var authorId = ContentAccess.GetUserId(User);
			var characterClass = new CharacterClass
			{
				Ruleset = dto.Ruleset,

				//	Content created through the API is always Homebrew; Base data comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = authorId,
				Translations = dto.Translations.Select(t => ApplyTranslation(new CharacterClassTranslation { Language = t.Language }, t)).ToList()
			};

			ApplyMechanics(characterClass, dto);
			characterClass.Features = BuildFeatures(dto.Features, dto.Ruleset, authorId, dto.Visibility);

			_context.Classes.Add(characterClass);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetClass), new { id = characterClass.Id }, new { characterClass.Id });
		}

		//	PUT: api/classes/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateClass(Guid id, [FromBody] SaveClassDto dto)
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

			var characterClass = await _context.Classes
				.Include(c => c.Translations)
				.Include(c => c.Features)
				.AsSplitQuery()
				.FirstOrDefaultAsync(c => c.Id == id);

			if (characterClass == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, characterClass);
			if (denied != null)
			{
				return denied;
			}

			characterClass.Ruleset = dto.Ruleset;
			ApplyMechanics(characterClass, dto);

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var stale in characterClass.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				characterClass.Translations.Remove(stale);
			}

			foreach (var tDto in dto.Translations)
			{
				var existing = characterClass.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					ApplyTranslation(existing, tDto);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.ClassTranslations.Add(ApplyTranslation(new CharacterClassTranslation { CharacterClassId = characterClass.Id, Language = tDto.Language }, tDto));
				}
			}

			//	Features are replaced as a whole (explicit delete: the owner keys are nullable)
			_context.ClassFeatures.RemoveRange(characterClass.Features);
			foreach (var feature in BuildFeatures(dto.Features, dto.Ruleset, characterClass.AuthorId, dto.Visibility))
			{
				feature.CharacterClassId = characterClass.Id;
				_context.ClassFeatures.Add(feature);
			}

			//	Visibility of the class applies to its own features
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/classes/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteClass(Guid id)
		{
			var characterClass = await _context.Classes
				.Include(c => c.Features)
				.Include(c => c.Subclasses).ThenInclude(s => s.Features)
				.AsSplitQuery()
				.FirstOrDefaultAsync(c => c.Id == id);

			if (characterClass == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, characterClass);
			if (denied != null)
			{
				return denied;
			}

			_context.ClassFeatures.RemoveRange(characterClass.Features.Concat(characterClass.Subclasses.SelectMany(s => s.Features)));
			_context.Classes.Remove(characterClass);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		internal static SubclassResponseDto ToSubclassDto(Subclass s, string className, LanguageCode lang, bool canEdit)
		{
			var tr = s.Translations.Localize(lang);

			return new SubclassResponseDto(
				s.Id,
				s.CharacterClassId,
				className,
				tr?.Name ?? "Unknown",
				tr?.Description ?? string.Empty,
				s.Ruleset,
				s.IsOfficialSRD,
				s.CasterProgression,
				s.SpellcastingAbility,
				ToFeatureDtos(s.Features, lang),
				canEdit,
				s.Source,
				s.Visibility);
		}

		internal static List<ClassFeatureDto> ToFeatureDtos(IEnumerable<ClassFeature> features, LanguageCode lang) =>
			features
				.OrderBy(f => f.Level)
				.ThenBy(f => f.SortOrder)
				.Select(f =>
				{
					var ftr = f.Translations.Localize(lang);
					return new ClassFeatureDto(f.Id, f.Level, f.SortOrder, ftr?.Name ?? "Unknown", ftr?.Description ?? string.Empty);
				})
				.ToList();

		internal static List<ClassFeature> BuildFeatures(IEnumerable<SaveClassFeatureDto> features, RulesetVersion ruleset, string? authorId, ContentVisibility visibility) =>
			features.Select((f, index) => new ClassFeature
			{
				Level = f.Level,
				SortOrder = index,
				Ruleset = ruleset,
				IsOfficialSRD = false,
				AuthorId = authorId,
				Visibility = visibility,
				Translations = f.Translations.Select(t => new ClassFeatureTranslation
				{
					Language = t.Language,
					Name = t.Name.Trim(),
					Description = t.Description?.Trim() ?? string.Empty
				}).ToList()
			}).ToList();

		private static void ApplyMechanics(CharacterClass c, SaveClassDto dto)
		{
			c.HitDie = dto.HitDie;
			c.PrimaryAbilities = dto.PrimaryAbilities.Distinct().OrderBy(a => a).ToList();
			c.SavingThrows = dto.SavingThrows.Distinct().OrderBy(a => a).ToList();
			c.SkillChoiceCount = dto.SkillChoiceCount;
			c.SkillOptions = dto.SkillOptions.Distinct().OrderBy(s => s).ToList();
			c.CasterProgression = dto.CasterProgression;
			c.SpellcastingAbility = dto.CasterProgression == CasterProgression.None ? null : dto.SpellcastingAbility;
			c.SubclassLevel = dto.SubclassLevel;
			c.Visibility = dto.Visibility;
		}

		private static CharacterClassTranslation ApplyTranslation(CharacterClassTranslation target, ClassTranslationDto source)
		{
			target.Name = source.Name.Trim();
			target.Description = source.Description?.Trim() ?? string.Empty;
			target.SubclassTitle = Normalize(source.SubclassTitle);
			target.ArmorProficiencies = Normalize(source.ArmorProficiencies);
			target.WeaponProficiencies = Normalize(source.WeaponProficiencies);
			target.ToolProficiencies = Normalize(source.ToolProficiencies);
			target.StartingEquipment = Normalize(source.StartingEquipment);
			target.ProgressionTable = Normalize(source.ProgressionTable);
			return target;
		}

		private static string? Normalize(string? value) =>
			string.IsNullOrWhiteSpace(value) ? null : value.Trim();

		internal static string? ValidateFeatures(List<SaveClassFeatureDto> features)
		{
			if (features.Count > MaxFeatures)
			{
				return "Too many features.";
			}

			if (features.Any(f => f.Level is < 1 or > 20))
			{
				return "Feature levels must be between 1 and 20.";
			}

			if (features.Any(f => f.Translations.Count == 0 || f.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name))
				|| f.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1)))
			{
				return "Every feature needs a name in each of its languages.";
			}

			if (features.Any(f => f.Translations.Any(t => t.Name.Length > 150 || (t.Description?.Length ?? 0) > MaxTextLength)))
			{
				return "A feature text is too long.";
			}

			return null;
		}

		private static string? Validate(SaveClassDto dto)
		{
			if (dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (dto.HitDie is not (6 or 8 or 10 or 12))
			{
				return "The hit die must be d6, d8, d10 or d12.";
			}

			if (dto.SubclassLevel is < 1 or > 20 || dto.SkillChoiceCount is < 0 or > 18)
			{
				return "Invalid subclass level or number of skills.";
			}

			if (!Enum.IsDefined(dto.Ruleset) || !Enum.IsDefined(dto.CasterProgression)
				|| dto.PrimaryAbilities.Concat(dto.SavingThrows).Any(a => !Enum.IsDefined(a))
				|| dto.SkillOptions.Any(s => !Enum.IsDefined(s))
				|| (dto.SpellcastingAbility is { } ability && !Enum.IsDefined(ability)))
			{
				return "Unknown ruleset, ability, skill or caster progression.";
			}

			if (dto.CasterProgression != CasterProgression.None && dto.SpellcastingAbility is null)
			{
				return "A spellcasting class needs a spellcasting ability.";
			}

			if (dto.Translations.Any(t => t.Name.Length > 150 || (t.Description?.Length ?? 0) > MaxTextLength
				|| (t.SubclassTitle?.Length ?? 0) > 150 || (t.ArmorProficiencies?.Length ?? 0) > 500 || (t.WeaponProficiencies?.Length ?? 0) > 500
				|| (t.ToolProficiencies?.Length ?? 0) > 500 || (t.StartingEquipment?.Length ?? 0) > 4000 || (t.ProgressionTable?.Length ?? 0) > MaxTextLength))
			{
				return "A text is too long.";
			}

			return ValidateFeatures(dto.Features);
		}

		#endregion
	}
}
