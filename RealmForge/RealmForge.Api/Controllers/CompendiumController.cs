using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
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

		public CompendiumController(RealmForgeDbContext context)
		{
			_context = context;
		}

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
