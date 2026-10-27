using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Text;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Backgrounds (2014 and 2024): localized list and detail, and Homebrew create/update/delete.
	///	Reads follow the visibility rules of <see cref="ContentAccess"/>; writes need a confirmed e-mail and ownership.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class BackgroundsController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;
		private const int MaxAbilityOptions = 3;
		private const int MaxSkills = 4;
		private const int MaxGoldAlternative = 10000;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public BackgroundsController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/backgrounds?lang=2&ruleset=2&isOfficial=true
		[HttpGet]
		public async Task<ActionResult<List<BackgroundResponseDto>>> GetBackgrounds(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = WithDetails(_context.Backgrounds.AsNoTracking());

			if (ruleset.HasValue)
			{
				query = query.Where(b => b.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(b => b.IsOfficialSRD == isOfficial.Value);
			}

			//	Private Homebrew of other users and link-only entries are not listed
			query = ContentAccess.ListedFor(query, User, await _shares.SharedWithAsync(User));

			var backgrounds = await query.ToListAsync();

			var dtos = backgrounds.Select(b =>
			{
				var tr = b.Translations.Localize(lang);
				//	Card preview: plain text without Markdown marks, cut on a word boundary
				var shortDesc = MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength);

				return new BackgroundResponseDto(
					b.Id,
					tr?.Name ?? "Unknown",
					b.Ruleset,
					b.IsOfficialSRD,
					shortDesc,
					b.AbilityOptions.ToList(),
					b.SkillProficiencies.ToList(),
					b.OriginFeatId,
					b.OriginFeat?.Translations.Localize(lang)?.Name,
					_access.CanModify(b, User),
					b.Source,
					b.Visibility);
			}).OrderBy(b => b.Name).ToList();

			return Ok(dtos);
		}

		//	GET: api/backgrounds/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<BackgroundDetailResponseDto>> GetBackground(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var background = await WithDetails(_context.Backgrounds.AsNoTracking()).FirstOrDefaultAsync(b => b.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (background == null || !_access.CanView(background, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}

			return Ok(ToDetailDto(background, lang, _access.CanModify(background, User)));
		}

		//	POST: api/backgrounds
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<BackgroundDetailResponseDto>> CreateBackground([FromBody] SaveBackgroundDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = await ValidateAsync(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var background = new Background
			{
				Ruleset = dto.Ruleset,

				//	Content created through the API is always Homebrew; SRD data comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
				Translations = dto.Translations.Select(t => ApplyTranslation(new BackgroundTranslation { Language = t.Language }, t)).ToList()
			};

			ApplyMechanics(background, dto);

			_context.Backgrounds.Add(background);
			await _context.SaveChangesAsync();

			var created = await WithDetails(_context.Backgrounds.AsNoTracking()).FirstAsync(b => b.Id == background.Id);
			return CreatedAtAction(nameof(GetBackground), new { id = background.Id }, ToDetailDto(created, lang, canEdit: true));
		}

		//	PUT: api/backgrounds/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateBackground(Guid id, [FromBody] SaveBackgroundDto dto)
		{
			if (id != dto.Id)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "ID mismatch between route and payload.");
			}

			var error = await ValidateAsync(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var background = await _context.Backgrounds
				.Include(b => b.Translations)
				.FirstOrDefaultAsync(b => b.Id == id);

			if (background == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, background);
			if (denied != null)
			{
				return denied;
			}

			background.Ruleset = dto.Ruleset;
			ApplyMechanics(background, dto);

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var stale in background.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				background.Translations.Remove(stale);
			}

			foreach (var tDto in dto.Translations)
			{
				var existing = background.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					ApplyTranslation(existing, tDto);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.BackgroundTranslations.Add(ApplyTranslation(new BackgroundTranslation { BackgroundId = background.Id, Language = tDto.Language }, tDto));
				}
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/backgrounds/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteBackground(Guid id)
		{
			var background = await _context.Backgrounds.FindAsync(id);

			if (background == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, background);
			if (denied != null)
			{
				return denied;
			}

			_context.Backgrounds.Remove(background);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		private static IQueryable<Background> WithDetails(IQueryable<Background> query) =>
			query
				.Include(b => b.Translations)
				.Include(b => b.OriginFeat).ThenInclude(f => f!.Translations)
				.AsSplitQuery();

		private static BackgroundDetailResponseDto ToDetailDto(Background b, LanguageCode lang, bool canEdit)
		{
			var tr = b.Translations.Localize(lang);

			return new BackgroundDetailResponseDto(
				b.Id,
				tr?.Name ?? "Unknown",
				b.Ruleset,
				b.IsOfficialSRD,
				tr?.Description ?? string.Empty,
				b.AbilityOptions.ToList(),
				b.SkillProficiencies.ToList(),
				b.OriginFeatId,
				b.OriginFeat?.Translations.Localize(lang)?.Name,
				tr?.OriginFeatNote,
				tr?.ToolProficiencies,
				tr?.Languages,
				tr?.Equipment,
				b.EquipmentGoldAlternative,
				tr?.FeatureName,
				tr?.FeatureDescription,
				tr?.CharacteristicsIntro,
				tr?.PersonalityTraits.ToList() ?? new List<string>(),
				tr?.Ideals.ToList() ?? new List<string>(),
				tr?.Bonds.ToList() ?? new List<string>(),
				tr?.Flaws.ToList() ?? new List<string>(),
				canEdit,
				b.Source,
				b.Visibility);
		}

		private static void ApplyMechanics(Background background, SaveBackgroundDto dto)
		{
			background.AbilityOptions = dto.AbilityOptions.Distinct().OrderBy(a => a).ToList();
			background.SkillProficiencies = dto.SkillProficiencies.Distinct().OrderBy(s => s).ToList();
			background.OriginFeatId = dto.OriginFeatId;
			background.EquipmentGoldAlternative = dto.EquipmentGoldAlternative;
			background.Visibility = dto.Visibility;
		}

		private static BackgroundTranslation ApplyTranslation(BackgroundTranslation target, BackgroundTranslationDto source)
		{
			target.Name = source.Name.Trim();
			target.Description = source.Description?.Trim() ?? string.Empty;
			target.ToolProficiencies = Normalize(source.ToolProficiencies);
			target.Languages = Normalize(source.Languages);
			target.Equipment = Normalize(source.Equipment);
			target.OriginFeatNote = Normalize(source.OriginFeatNote);
			target.FeatureName = Normalize(source.FeatureName);
			target.FeatureDescription = Normalize(source.FeatureDescription);
			target.CharacteristicsIntro = Normalize(source.CharacteristicsIntro);
			target.PersonalityTraits = CleanList(source.PersonalityTraits);
			target.Ideals = CleanList(source.Ideals);
			target.Bonds = CleanList(source.Bonds);
			target.Flaws = CleanList(source.Flaws);
			return target;
		}

		private static List<string> CleanList(IEnumerable<string>? values) =>
			(values ?? Enumerable.Empty<string>()).Where(v => !string.IsNullOrWhiteSpace(v)).Select(v => v.Trim()).Take(20).ToList();

		private static string? Normalize(string? value) =>
			string.IsNullOrWhiteSpace(value) ? null : value.Trim();

		private async Task<string?> ValidateAsync(SaveBackgroundDto dto)
		{
			if (dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (dto.AbilityOptions.Distinct().Count() > MaxAbilityOptions)
			{
				return $"A background can offer at most {MaxAbilityOptions} abilities.";
			}

			if (dto.SkillProficiencies.Distinct().Count() > MaxSkills)
			{
				return $"A background can grant at most {MaxSkills} skill proficiencies.";
			}

			if (dto.EquipmentGoldAlternative is < 0 or > MaxGoldAlternative)
			{
				return $"The gold alternative must be between 0 and {MaxGoldAlternative} gp.";
			}

			if (dto.OriginFeatId is Guid featId && !await _context.Feats.AnyAsync(f => f.Id == featId))
			{
				return "The selected origin feat does not exist.";
			}

			return null;
		}

		#endregion
	}
}
