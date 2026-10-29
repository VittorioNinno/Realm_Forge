using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Domain.Common;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Campaigns
{
	///	<summary>
	///	A Homebrew entry of any kind, as the campaign pages show it: kind, name in one language, the client page that
	///	opens it, its author and edition.
	///	</summary>
	public sealed record HomebrewEntry(Guid Id, string Kind, string Name, string Link, string? AuthorId, RulesetVersion Ruleset, bool IsBase,
		ContentVisibility Visibility = ContentVisibility.Public, Guid? ParentId = null);

	///	<summary>
	///	Finds Homebrew entries by id across every content table (species, subspecies, classes, subclasses, backgrounds,
	///	feats, spells, equipment, monsters) and lists the entries an account wrote.
	///	</summary>
	public class HomebrewLookup
	{
		private readonly RealmForgeDbContext _context;

		public HomebrewLookup(RealmForgeDbContext context)
		{
			_context = context;
		}

		public async Task<Dictionary<Guid, HomebrewEntry>> FindAsync(IReadOnlyCollection<Guid> ids, LanguageCode lang)
		{
			var found = new Dictionary<Guid, HomebrewEntry>();
			if (ids.Count == 0)
			{
				return found;
			}
			await foreach (var entry in QueryAsync(lang, e => ids.Contains(e.Id)))
			{
				found[entry.Id] = entry;
			}
			return found;
		}

		//	The Homebrew entries this account wrote
		public async Task<List<HomebrewEntry>> ByAuthorAsync(string userId, LanguageCode lang)
		{
			var list = new List<HomebrewEntry>();
			await foreach (var entry in QueryAsync(lang, e => !e.IsOfficialSRD && e.AuthorId == userId))
			{
				list.Add(entry);
			}
			return list.OrderBy(e => e.Kind).ThenBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase).ToList();
		}

		private async IAsyncEnumerable<HomebrewEntry> QueryAsync(LanguageCode lang, System.Linq.Expressions.Expression<Func<GameEntity, bool>> filter)
		{
			HomebrewEntry Entry(GameEntity e, string kind, string? name, string link, Guid? parent = null) =>
				new(e.Id, kind, name ?? "?", link, e.AuthorId, e.Ruleset, e.IsOfficialSRD, e.Visibility, parent);

			foreach (var e in await _context.Species.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Species>(filter)).ToListAsync())
			{
				yield return Entry(e, "species", e.Translations.Localize(lang)?.Name, $"species?id={e.Id}");
			}
			foreach (var e in await _context.Subspecies.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Subspecies>(filter)).ToListAsync())
			{
				yield return Entry(e, "subspecies", e.Translations.Localize(lang)?.Name, $"subspecies?id={e.Id}", e.SpeciesId);
			}
			foreach (var e in await _context.Classes.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.CharacterClass>(filter)).ToListAsync())
			{
				yield return Entry(e, "class", e.Translations.Localize(lang)?.Name, $"classes?id={e.Id}");
			}
			foreach (var e in await _context.Subclasses.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Subclass>(filter)).ToListAsync())
			{
				yield return Entry(e, "subclass", e.Translations.Localize(lang)?.Name, $"classes?id={e.CharacterClassId}&subclass={e.Id}", e.CharacterClassId);
			}
			foreach (var e in await _context.Backgrounds.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Background>(filter)).ToListAsync())
			{
				yield return Entry(e, "background", e.Translations.Localize(lang)?.Name, $"backgrounds?id={e.Id}");
			}
			foreach (var e in await _context.Feats.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Feat>(filter)).ToListAsync())
			{
				yield return Entry(e, "feat", e.Translations.Localize(lang)?.Name, $"feats?id={e.Id}");
			}
			foreach (var e in await _context.Spells.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Spell>(filter)).ToListAsync())
			{
				yield return Entry(e, "spell", e.Translations.Localize(lang)?.Name, $"spells?id={e.Id}");
			}
			foreach (var e in await _context.Equipment.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Equipment>(filter)).ToListAsync())
			{
				yield return Entry(e, "equipment", e.Translations.Localize(lang)?.Name, $"equipment?id={e.Id}");
			}
			foreach (var e in await _context.Monsters.AsNoTracking().Include(x => x.Translations).Where(Cast<RealmForge.Domain.Entities.Monster>(filter)).ToListAsync())
			{
				yield return Entry(e, "monster", e.Translations.Localize(lang)?.Name, $"monsters?id={e.Id}");
			}
		}

		//	The same filter on a concrete entity type (EF translates it like the original)
		private static System.Linq.Expressions.Expression<Func<T, bool>> Cast<T>(System.Linq.Expressions.Expression<Func<GameEntity, bool>> filter) where T : GameEntity
		{
			var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T), "e");
			var body = new ParameterSwap(filter.Parameters[0], parameter).Visit(filter.Body)!;
			return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, parameter);
		}

		private sealed class ParameterSwap : System.Linq.Expressions.ExpressionVisitor
		{
			private readonly System.Linq.Expressions.ParameterExpression _from;
			private readonly System.Linq.Expressions.ParameterExpression _to;

			public ParameterSwap(System.Linq.Expressions.ParameterExpression from, System.Linq.Expressions.ParameterExpression to)
			{
				_from = from;
				_to = to;
			}

			protected override System.Linq.Expressions.Expression VisitParameter(System.Linq.Expressions.ParameterExpression node) =>
				node == _from ? _to : base.VisitParameter(node);
		}
	}
}
