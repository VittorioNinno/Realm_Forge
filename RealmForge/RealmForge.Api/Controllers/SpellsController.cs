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
	///	Spells: localized list (with server-side filters on ruleset, origin, level, school and class) and detail,
	///	and Homebrew create/update/delete. Same access rules as the other content modules (<see cref="ContentAccess"/>).
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class SpellsController : ControllerBase
	{
		private const int ShortDescriptionLength = 160;
		private const int MaxTextLength = 20000;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public SpellsController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/spells?lang=2&ruleset=1&isOfficial=true&level=3&school=5&spellClass=8
		[HttpGet]
		public async Task<ActionResult<List<SpellResponseDto>>> GetSpells(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null,
			[FromQuery] int? level = null,
			[FromQuery] SpellSchool? school = null,
			[FromQuery] SpellcastingClass? spellClass = null)
		{
			var query = _context.Spells.AsNoTracking().Include(s => s.Translations).AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(s => s.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(s => s.IsOfficialSRD == isOfficial.Value);
			}

			if (level.HasValue)
			{
				query = query.Where(s => s.Level == level.Value);
			}

			if (school.HasValue)
			{
				query = query.Where(s => s.School == school.Value);
			}

			if (spellClass.HasValue)
			{
				//	integer[] column: translated to the PostgreSQL array containment operator
				query = query.Where(s => s.Classes.Contains(spellClass.Value));
			}

			query = ContentAccess.ListedFor(query, User, await _shares.SharedWithAsync(User));

			var spells = await query.ToListAsync();

			var dtos = spells.Select(s =>
			{
				var tr = s.Translations.Localize(lang);
				return new SpellResponseDto(
					s.Id,
					tr?.Name ?? "Unknown",
					s.Ruleset,
					s.IsOfficialSRD,
					s.Level,
					s.School,
					s.Classes.OrderBy(c => c).ToList(),
					s.Ritual,
					s.Concentration,
					tr?.CastingTime ?? string.Empty,
					tr?.Range ?? string.Empty,
					MarkdownPreview.ToPlainText(tr?.Description, ShortDescriptionLength),
					_access.CanModify(s, User),
					s.Source,
					s.Visibility);
			})
			.OrderBy(s => s.Level)
			.ThenBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase)
			.ToList();

			return Ok(dtos);
		}

		//	GET: api/spells/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SpellDetailResponseDto>> GetSpell(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var spell = await _context.Spells.AsNoTracking().Include(s => s.Translations).FirstOrDefaultAsync(s => s.Id == id);

			//	Private entries of other users answer 404, as if they did not exist
			if (spell == null || !_access.CanView(spell, User, await _shares.SharedWithAsync(User)))
			{
				return NotFound();
			}

			return Ok(ToDetailDto(spell, lang, _access.CanModify(spell, User)));
		}

		//	POST: api/spells
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<SpellDetailResponseDto>> CreateSpell([FromBody] SaveSpellDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = Validate(dto);
			if (error != null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var spell = new Spell
			{
				Ruleset = dto.Ruleset,

				//	Content created through the API is always Homebrew; SRD data comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = ContentAccess.GetUserId(User),
				Translations = dto.Translations.Select(t => ApplyTranslation(new SpellTranslation { Language = t.Language }, t)).ToList()
			};

			ApplyMechanics(spell, dto);

			_context.Spells.Add(spell);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetSpell), new { id = spell.Id }, ToDetailDto(spell, lang, canEdit: true));
		}

		//	PUT: api/spells/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateSpell(Guid id, [FromBody] SaveSpellDto dto)
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

			var spell = await _context.Spells.Include(s => s.Translations).FirstOrDefaultAsync(s => s.Id == id);

			if (spell == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, spell);
			if (denied != null)
			{
				return denied;
			}

			spell.Ruleset = dto.Ruleset;
			ApplyMechanics(spell, dto);

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var stale in spell.Translations.Where(t => !dtoLanguages.Contains(t.Language)).ToList())
			{
				spell.Translations.Remove(stale);
			}

			foreach (var tDto in dto.Translations)
			{
				var existing = spell.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existing != null)
				{
					ApplyTranslation(existing, tDto);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.SpellTranslations.Add(ApplyTranslation(new SpellTranslation { SpellId = spell.Id, Language = tDto.Language }, tDto));
				}
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/spells/{id}
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteSpell(Guid id)
		{
			var spell = await _context.Spells.FindAsync(id);

			if (spell == null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, spell);
			if (denied != null)
			{
				return denied;
			}

			_context.Spells.Remove(spell);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		private static SpellDetailResponseDto ToDetailDto(Spell s, LanguageCode lang, bool canEdit)
		{
			var tr = s.Translations.Localize(lang);

			return new SpellDetailResponseDto(
				s.Id,
				tr?.Name ?? "Unknown",
				s.Ruleset,
				s.IsOfficialSRD,
				s.Level,
				s.School,
				s.Classes.OrderBy(c => c).ToList(),
				s.Ritual,
				s.Concentration,
				s.Verbal,
				s.Somatic,
				s.Material,
				tr?.CastingTime ?? string.Empty,
				tr?.Range ?? string.Empty,
				tr?.Duration ?? string.Empty,
				s.Material ? tr?.MaterialComponent : null,
				tr?.Description ?? string.Empty,
				tr?.HigherLevels,
				canEdit,
				s.Source,
				s.Visibility);
		}

		private static void ApplyMechanics(Spell spell, SaveSpellDto dto)
		{
			spell.Level = dto.Level;
			spell.School = dto.School;
			spell.Classes = dto.Classes.Distinct().OrderBy(c => c).ToList();
			spell.Ritual = dto.Ritual;
			spell.Concentration = dto.Concentration;
			spell.Verbal = dto.Verbal;
			spell.Somatic = dto.Somatic;
			spell.Material = dto.Material;
			spell.Visibility = dto.Visibility;
		}

		private static SpellTranslation ApplyTranslation(SpellTranslation target, SpellTranslationDto source)
		{
			target.Name = source.Name.Trim();
			target.Description = source.Description?.Trim() ?? string.Empty;
			target.HigherLevels = Normalize(source.HigherLevels);
			target.CastingTime = source.CastingTime.Trim();
			target.Range = source.Range.Trim();
			target.Duration = source.Duration.Trim();
			target.MaterialComponent = Normalize(source.MaterialComponent);
			return target;
		}

		private static string? Normalize(string? value) =>
			string.IsNullOrWhiteSpace(value) ? null : value.Trim();

		private static string? Validate(SaveSpellDto dto)
		{
			if (dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}

			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}

			if (dto.Level is < 0 or > 9)
			{
				return "The spell level must be between 0 (cantrip) and 9.";
			}

			if (!Enum.IsDefined(dto.School) || dto.Classes.Any(c => !Enum.IsDefined(c)))
			{
				return "Unknown school or class.";
			}

			if (dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.CastingTime) || string.IsNullOrWhiteSpace(t.Range) || string.IsNullOrWhiteSpace(t.Duration)))
			{
				return "Casting time, range and duration are required in every translation.";
			}

			if (dto.Translations.Any(t => t.Name.Length > 150 || t.CastingTime.Length > 300 || t.Range.Length > 150 || t.Duration.Length > 150
				|| (t.MaterialComponent?.Length ?? 0) > 500 || (t.Description?.Length ?? 0) > MaxTextLength || (t.HigherLevels?.Length ?? 0) > MaxTextLength))
			{
				return "A text is too long.";
			}

			return null;
		}

		#endregion
	}
}
