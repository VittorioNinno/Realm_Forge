using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Search;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Index of the Base content (names and ids only): the client uses it to link spells, equipment and classes
	///	mentioned in the texts of the other modules.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class CompendiumController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly CompendiumSearch _search;
		private readonly ShareService _shares;

		public CompendiumController(RealmForgeDbContext context, CompendiumSearch search, ShareService shares)
		{
			_context = context;
			_search = search;
			_shares = shares;
		}

		//	GET: api/compendium/search?q=palla&lang=2 — every section and the glossary, at least 2 characters
		[HttpGet("search")]
		public async Task<ActionResult<List<SearchResultDto>>> Search([FromQuery] string? q, [FromQuery] string? kinds, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var text = q?.Trim() ?? string.Empty;
			if (text.Length < 2 || text.Length > 60)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Search for 2 to 60 characters.");
			}
			return Ok(await _search.SearchAsync(text, lang, User, await _shares.SharedWithAsync(User), Kinds(kinds)));
		}

		//	GET: api/compendium/random?kinds=spell,monster&lang=2 — a base entry at random (the "random entry" button)
		[HttpGet("random")]
		public async Task<ActionResult<SearchResultDto>> Random([FromQuery] string? kinds, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var hit = await _search.RandomAsync(lang, Kinds(kinds));
			return hit is null ? NotFound() : Ok(hit);
		}

		//	GET: api/compendium/counts — base entries of each section per edition
		[HttpGet("counts")]
		public async Task<ActionResult<List<CompendiumSectionCountDto>>> Counts() => Ok(await _search.CountsAsync());

		//	"spell,monster" → the known kinds among them (unknown words are ignored; none = every section)
		private static HashSet<string>? Kinds(string? kinds) => string.IsNullOrWhiteSpace(kinds)
			? null
			: kinds.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
				.Where(k => CompendiumSearch.Kinds.Contains(k)).ToHashSet();

		//	GET: api/compendium/index?lang=2
		[HttpGet("index")]
		public async Task<ActionResult<CompendiumIndexDto>> GetIndex([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var spells = await _context.Spells.AsNoTracking().Include(s => s.Translations)
				.Where(s => s.IsOfficialSRD).ToListAsync();
			var equipment = await _context.Equipment.AsNoTracking().Include(e => e.Translations)
				.Where(e => e.IsOfficialSRD).ToListAsync();
			var classes = await _context.Classes.AsNoTracking().Include(c => c.Translations)
				.Where(c => c.IsOfficialSRD).ToListAsync();

			return Ok(new CompendiumIndexDto(
				spells.Select(s => new CompendiumIndexEntryDto(s.Id, s.Translations.Localize(lang)?.Name ?? string.Empty, s.Ruleset)).ToList(),
				equipment.Select(e => new CompendiumIndexEntryDto(e.Id, e.Translations.Localize(lang)?.Name ?? string.Empty, e.Ruleset)).ToList(),
				classes.Select(c => new CompendiumClassDto(c.Id, c.Translations.Localize(lang)?.Name ?? string.Empty, c.Ruleset,
					BaseClassKeys.SpellList(BaseClassKeys.Of(c.Id, c.Ruleset)), BaseClassKeys.Of(c.Id, c.Ruleset))).ToList()));
		}

	}
}
