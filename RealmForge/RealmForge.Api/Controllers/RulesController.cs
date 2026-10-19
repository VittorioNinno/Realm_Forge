using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Rules glossary (read only): localized list, with the forms of each term used to link it in the other modules,
	///	and detail with the related entries.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class RulesController : ControllerBase
	{
		//	Long enough for the effects of a condition, short enough for a tooltip
		public const int SummaryLength = 320;

		private readonly RealmForgeDbContext _context;

		public RulesController(RealmForgeDbContext context)
		{
			_context = context;
		}

		//	GET: api/rules?lang=2&ruleset=2&category=2
		[HttpGet]
		public async Task<ActionResult<List<RuleEntryResponseDto>>> GetEntries(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] RuleCategory? category = null)
		{
			var query = _context.RuleEntries.AsNoTracking().Include(e => e.Translations).AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(e => e.Ruleset == ruleset.Value);
			}

			if (category.HasValue)
			{
				query = query.Where(e => e.Category == category.Value);
			}

			var entries = await query.ToListAsync();

			var dtos = entries.Select(e =>
			{
				var tr = e.Translations.Localize(lang);
				return new RuleEntryResponseDto(
					e.Id,
					e.Key,
					tr?.Name ?? e.Key,
					e.Ruleset,
					e.Category,
					MarkdownPreview.ToPlainText(tr?.Description, SummaryLength),
					tr?.Aliases.ToList() ?? new List<string>(),
					e.Source);
			})
			.OrderBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase)
			.ThenBy(e => e.Ruleset)
			.ToList();

			return Ok(dtos);
		}

		//	GET: api/rules/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<RuleEntryDetailResponseDto>> GetEntry(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var entry = await _context.RuleEntries.AsNoTracking().Include(e => e.Translations).FirstOrDefaultAsync(e => e.Id == id);
			if (entry == null)
			{
				return NotFound();
			}

			var related = new List<RuleEntryLinkDto>();
			if (entry.RelatedKeys.Count > 0)
			{
				var keys = entry.RelatedKeys;
				var others = await _context.RuleEntries.AsNoTracking().Include(e => e.Translations)
					.Where(e => e.Ruleset == entry.Ruleset && keys.Contains(e.Key))
					.ToListAsync();

				//	In the order of the "See also" list
				related = keys
					.Select(k => others.FirstOrDefault(o => o.Key == k))
					.Where(o => o != null)
					.Select(o => new RuleEntryLinkDto(o!.Id, o.Key, o.Translations.Localize(lang)?.Name ?? o.Key, o.Category))
					.ToList();
			}

			var tr = entry.Translations.Localize(lang);
			return Ok(new RuleEntryDetailResponseDto(
				entry.Id,
				entry.Key,
				tr?.Name ?? entry.Key,
				entry.Ruleset,
				entry.Category,
				tr?.Description ?? string.Empty,
				related,
				entry.Source));
		}
	}
}
