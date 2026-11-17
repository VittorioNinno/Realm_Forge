using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Content;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	The entry of the other edition that corresponds to one (2014 ↔ 2024): the Base entry of the same section with
	///	the same English name, or the same name without the owner of a named spell ("Melf's Acid Arrow" ↔ "Acid
	///	Arrow"). Suggested in the detail pages to move from one edition to the other.
	///	</summary>
	[ApiController]
	[Route("api/content")]
	[AllowAnonymous]
	public class EquivalentsController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;
		private readonly HomebrewLookup _homebrew;

		public EquivalentsController(RealmForgeDbContext context, ContentAccess access, ShareService shares, HomebrewLookup homebrew)
		{
			_context = context;
			_access = access;
			_shares = shares;
			_homebrew = homebrew;
		}

		//	GET: api/content/{kind}/{id}/equivalent?lang=2 — 204 when there is none
		[HttpGet("{kind}/{id:guid}/equivalent")]
		public async Task<ActionResult<ContentEquivalentDto>> Equivalent(string kind, Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (kind == "module" || !ContentCopier.Kinds.TryGetValue(kind, out var type) || await _context.FindAsync(type, id) is not GameEntity entity
				|| !_access.CanView(entity, User, await _shares.SharedWithAsync(User)))
			{
				return NoContent();
			}
			await _context.Entry(entity).Collection("Translations").LoadAsync();
			var name = EnglishName(entity);
			if (name is null)
			{
				return NoContent();
			}
			var other = entity.Ruleset == RulesetVersion.Dnd5e_2014 ? RulesetVersion.Dnd5e_2024 : RulesetVersion.Dnd5e_2014;
			var candidates = await (Task<List<GameEntity>>)typeof(EquivalentsController).GetMethod(nameof(BaseOfAsync), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
				.MakeGenericMethod(type).Invoke(this, new object[] { other })!;
			var key = Key(name);
			var match = candidates.FirstOrDefault(c => EnglishName(c) is { } n && string.Equals(n.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase))
				?? candidates.FirstOrDefault(c => EnglishName(c) is { } n && Key(n) == key);
			if (match is null)
			{
				return NoContent();
			}
			var entry = (await _homebrew.FindAsync(new[] { match.Id }, lang)).GetValueOrDefault(match.Id);
			return entry is null ? NoContent() : Ok(new ContentEquivalentDto(entry.Kind, entry.Id, entry.Name, entry.Link, other));
		}

		//	The Base entries of a section in one edition, with their texts
		private async Task<List<GameEntity>> BaseOfAsync<T>(RulesetVersion ruleset) where T : GameEntity =>
			(await _context.Set<T>().AsNoTracking().Include("Translations").Where(e => e.IsOfficialSRD && e.Ruleset == ruleset).ToListAsync()).Cast<GameEntity>().ToList();

		private static string? EnglishName(GameEntity entity) =>
			(entity.GetType().GetProperty("Translations")?.GetValue(entity) as IEnumerable<ITranslation>)?
				.FirstOrDefault(t => t.Language == LanguageCode.En && !string.IsNullOrWhiteSpace(t.Name))?.Name;

		//	The name to compare: lower case, letters and digits only, without the owner of a named spell
		private static string Key(string name)
		{
			var text = name.Trim().ToLowerInvariant().Replace('’', '\'');
			var owner = text.IndexOf("'s ", StringComparison.Ordinal);
			if (owner > 0 && owner < 20)
			{
				text = text[(owner + 3)..];
			}
			return new string(text.Where(char.IsLetterOrDigit).ToArray());
		}
	}
}
