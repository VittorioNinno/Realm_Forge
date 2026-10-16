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
using RealmForge.Shared.Localization;

namespace RealmForge.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FeatsController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;

		public FeatsController(RealmForgeDbContext context, ContentAccess access)
		{
			_context = context;
			_access = access;
		}

		//	GET: api/feats?lang=2&category=1&ruleset=2&isOfficial=true
		[HttpGet]
		public async Task<ActionResult<List<FeatResponseDto>>> GetFeats(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] FeatCategory? category = null,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = _context.Feats
				.Include(f => f.Translations)
				.AsSplitQuery()
				.AsNoTracking();

			if (category.HasValue)
			{
				query = query.Where(f => f.Category == category.Value);
			}

			if (ruleset.HasValue)
			{
				query = query.Where(f => f.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(f => f.IsOfficialSRD == isOfficial.Value);
			}

			//	Private Homebrew of other users and link-only entries are not listed
			query = ContentAccess.ListedFor(query, User);

			var feats = await query.ToListAsync();

			var dtos = feats.Select(f =>
			{
				var tr = f.Translations.Localize(lang);
				//	Card preview: plain text without Markdown marks, cut on a word boundary
				var shortDesc = MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength);

				return new FeatResponseDto(
					f.Id,
					tr?.Name ?? "Unknown",
					f.Category,
					FormatPrerequisite(f, tr, lang),
					f.Ruleset,
					f.IsOfficialSRD,
					shortDesc,
					_access.CanModify(f, User),
					f.Source,
					f.Visibility
				);
			}).OrderBy(f => f.Name).ToList();

			return Ok(dtos);
		}

		//	GET: api/feats/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<FeatDetailResponseDto>> GetFeatDetail(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var feat = await _context.Feats
				.Include(f => f.Translations)
				.AsNoTracking()
				.FirstOrDefaultAsync(f => f.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (feat == null || !_access.CanView(feat, User))
			{
				return NotFound();
			}

			return Ok(ToDetailDto(feat, lang, _access.CanModify(feat, User)));
		}

		//	POST: api/feats
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<FeatDetailResponseDto>> CreateFeat([FromBody] CreateFeatDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = Validate(dto.Prerequisites, dto.Translations.Select(t => (t.Language, t.Name)));
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var feat = new Feat
			{
				Category = dto.Category,
				Ruleset = dto.Ruleset,

				//	Content created through the API is always Homebrew; SRD data comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
				Visibility = dto.Visibility,

				Translations = dto.Translations.Select(t => new FeatTranslation
				{
					Language = t.Language,
					Name = t.Name.Trim(),
					Description = t.Description?.Trim() ?? string.Empty,
					PrerequisiteNote = NormalizeNote(t.PrerequisiteNote)
				}).ToList()
			};

			ApplyPrerequisites(feat, dto.Prerequisites);

			_context.Feats.Add(feat);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetFeatDetail), new { id = feat.Id }, ToDetailDto(feat, lang, canEdit: true));
		}

		//	PUT: api/feats/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateFeat(Guid id, [FromBody] UpdateFeatDto dto)
		{
			if (id != dto.Id)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "ID mismatch between route and payload.");
			}

			var error = Validate(dto.Prerequisites, dto.Translations.Select(t => (t.Language, t.Name)));
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var feat = await _context.Feats
				.Include(f => f.Translations)
				.FirstOrDefaultAsync(f => f.Id == id);

			if (feat == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, feat);
			if (denied != null)
			{
				return denied;
			}

			feat.Category = dto.Category;
			feat.Ruleset = dto.Ruleset;
			feat.Visibility = dto.Visibility;
			ApplyPrerequisites(feat, dto.Prerequisites);

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();

			//	Remove translations omitted from the payload
			foreach (var tr in feat.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				feat.Translations.Remove(tr);
			}

			//	Update existing translations or add new ones
			foreach (var tDto in dto.Translations)
			{
				var existing = feat.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					existing.Name = tDto.Name.Trim();
					existing.Description = tDto.Description?.Trim() ?? string.Empty;
					existing.PrerequisiteNote = NormalizeNote(tDto.PrerequisiteNote);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.FeatTranslations.Add(new FeatTranslation
					{
						FeatId = feat.Id,
						Language = tDto.Language,
						Name = tDto.Name.Trim(),
						Description = tDto.Description?.Trim() ?? string.Empty,
						PrerequisiteNote = NormalizeNote(tDto.PrerequisiteNote)
					});
				}
			}

			await _context.SaveChangesAsync();

			return NoContent();
		}

		//	DELETE: api/feats/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteFeat(Guid id)
		{
			var feat = await _context.Feats.FindAsync(id);

			if (feat == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, feat);
			if (denied != null)
			{
				return denied;
			}

			_context.Feats.Remove(feat);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		#region Mapping & validation

		private static FeatDetailResponseDto ToDetailDto(Feat feat, LanguageCode lang, bool canEdit)
		{
			var tr = feat.Translations.Localize(lang);

			return new FeatDetailResponseDto(
				feat.Id,
				tr?.Name ?? "Unknown",
				feat.Category,
				FormatPrerequisite(feat, tr, lang),
				feat.Ruleset,
				feat.IsOfficialSRD,
				tr?.Description ?? string.Empty,
				ToPrerequisiteDto(feat),
				tr?.PrerequisiteNote,
				canEdit,
				feat.Source,
				feat.Visibility
			);
		}

		private static FeatPrerequisiteDto ToPrerequisiteDto(Feat feat) => new()
		{
			MinimumLevel = feat.PrerequisiteMinimumLevel,
			Abilities = feat.PrerequisiteAbilities.ToList(),
			MinimumScore = feat.PrerequisiteMinimumScore,
			Feature = feat.PrerequisiteFeature
		};

		private static string? FormatPrerequisite(Feat feat, FeatTranslation? tr, LanguageCode lang) =>
			FeatPrerequisiteFormatter.Format(ToPrerequisiteDto(feat), tr?.PrerequisiteNote, feat.Ruleset, lang);

		private static void ApplyPrerequisites(Feat feat, FeatPrerequisiteDto? p)
		{
			p ??= new FeatPrerequisiteDto();
			var hasAbilities = p.Abilities.Count > 0 && p.MinimumScore.HasValue;

			feat.PrerequisiteMinimumLevel = p.MinimumLevel;
			feat.PrerequisiteAbilities = hasAbilities ? p.Abilities.Distinct().OrderBy(a => a).ToList() : new List<AbilityScore>();
			feat.PrerequisiteMinimumScore = hasAbilities ? p.MinimumScore : null;
			feat.PrerequisiteFeature = p.Feature;
		}

		private static string? NormalizeNote(string? note) =>
			string.IsNullOrWhiteSpace(note) ? null : note.Trim();

		private static string? Validate(FeatPrerequisiteDto? p, IEnumerable<(LanguageCode Language, string Name)> translations)
		{
			var list = translations.ToList();

			if (list.Count == 0 || list.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (list.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (p?.MinimumLevel is < 1 or > 20)
			{
				return "Minimum level must be between 1 and 20.";
			}

			if (p?.MinimumScore is < 1 or > 30)
			{
				return "Minimum ability score must be between 1 and 30.";
			}

			return null;
		}

		#endregion
	}
}
