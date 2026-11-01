using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Search
{
	///	<summary>
	///	Global search by name across every section of the compendium and the glossary, in both languages: the base
	///	content, the public Homebrew, the user's own and the entries shared with the user (the rule of the lists).
	///	Names that start with the text come first.
	///	</summary>
	public class CompendiumSearch
	{
		public const int MaxResults = 60;
		private const int PerSection = 40;

		private readonly RealmForgeDbContext _context;

		public CompendiumSearch(RealmForgeDbContext context)
		{
			_context = context;
		}

		private sealed record Hit(Guid Id, string Kind, string Link, RulesetVersion Ruleset, bool IsBase, string? AuthorId, Dictionary<LanguageCode, string> Names);

		public async Task<List<SearchResultDto>> SearchAsync(string text, LanguageCode lang, ClaimsPrincipal user, IReadOnlySet<Guid> shared)
		{
			var query = text.Trim();
			var pattern = "%" + query.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_") + "%";
			var hits = new List<Hit>();

			//	Sequential: a DbContext does not run queries in parallel
			hits.AddRange(await SectionAsync<Species, SpeciesTranslation>(_context.Species, "SpeciesId", "species", e => $"species?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Subspecies, SubspeciesTranslation>(_context.Subspecies, "SubspeciesId", "subspecies", e => $"subspecies?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<CharacterClass, CharacterClassTranslation>(_context.Classes, "CharacterClassId", "class", e => $"classes?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Subclass, SubclassTranslation>(_context.Subclasses, "SubclassId", "subclass", e => $"classes?id={e.CharacterClassId}&subclass={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Background, BackgroundTranslation>(_context.Backgrounds, "BackgroundId", "background", e => $"backgrounds?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Feat, FeatTranslation>(_context.Feats, "FeatId", "feat", e => $"feats?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Spell, SpellTranslation>(_context.Spells, "SpellId", "spell", e => $"spells?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Equipment, EquipmentTranslation>(_context.Equipment, "EquipmentId", "equipment", e => $"equipment?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<MagicItem, MagicItemTranslation>(_context.MagicItems, "MagicItemId", "magic-item", e => $"magic-items?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<Monster, MonsterTranslation>(_context.Monsters, "MonsterId", "monster", e => $"monsters?id={e.Id}", pattern, user, shared));
			hits.AddRange(await SectionAsync<RuleEntry, RuleEntryTranslation>(_context.RuleEntries, "RuleEntryId", "rule", e => $"rules?id={e.Id}", pattern, user, shared));

			var userId = user.Identity?.IsAuthenticated == true ? ContentAccess.GetUserId(user) : null;
			var other = lang == LanguageCode.It ? LanguageCode.En : LanguageCode.It;
			return hits
				.Select(h =>
				{
					var name = h.Names.GetValueOrDefault(lang) ?? h.Names.GetValueOrDefault(other) ?? "?";
					var otherName = h.Names.GetValueOrDefault(other);
					return new
					{
						Dto = new SearchResultDto(h.Id, h.Kind, name, otherName is not null && !string.Equals(otherName, name, StringComparison.OrdinalIgnoreCase) ? otherName : null,
							h.Link, h.Ruleset, h.IsBase, userId is not null && h.AuthorId == userId),
						Rank = h.Names.Values.Any(n => n.Equals(query, StringComparison.OrdinalIgnoreCase)) ? 0
							: h.Names.Values.Any(n => n.StartsWith(query, StringComparison.OrdinalIgnoreCase)) ? 1
							: h.Names.Values.Any(n => n.Contains(" " + query, StringComparison.OrdinalIgnoreCase)) ? 2 : 3
					};
				})
				.OrderBy(x => x.Rank)
				.ThenBy(x => x.Dto.Name.Length)
				.ThenBy(x => x.Dto.Name, StringComparer.CurrentCultureIgnoreCase)
				.Take(MaxResults)
				.Select(x => x.Dto)
				.ToList();
		}

		//	One section: the translations whose name matches, then the entries the user may see, then all their names
		private async Task<List<Hit>> SectionAsync<T, TT>(IQueryable<T> entities, string foreignKey, string kind, Func<T, string> link, string pattern,
			ClaimsPrincipal user, IReadOnlySet<Guid> shared) where T : GameEntity where TT : class, ITranslation
		{
			var ids = await _context.Set<TT>().AsNoTracking()
				.Where(t => EF.Functions.ILike(EF.Property<string>(t, "Name"), pattern))
				.Select(t => EF.Property<Guid>(t, foreignKey))
				.Distinct()
				.Take(200)
				.ToListAsync();
			if (ids.Count == 0)
			{
				return new List<Hit>();
			}
			var rows = await ContentAccess.ListedFor(entities.AsNoTracking().Where(e => ids.Contains(e.Id)), user, shared)
				.Take(PerSection)
				.ToListAsync();
			var found = rows.Select(r => r.Id).ToList();
			var names = await _context.Set<TT>().AsNoTracking()
				.Where(t => found.Contains(EF.Property<Guid>(t, foreignKey)))
				.Select(t => new { Id = EF.Property<Guid>(t, foreignKey), Language = EF.Property<LanguageCode>(t, "Language"), Name = EF.Property<string>(t, "Name") })
				.ToListAsync();
			return rows.Select(r => new Hit(r.Id, kind, link(r), r.Ruleset, r.IsOfficialSRD, r.AuthorId,
					names.Where(n => n.Id == r.Id).GroupBy(n => n.Language).ToDictionary(g => g.Key, g => g.First().Name)))
				.ToList();
		}
	}
}
