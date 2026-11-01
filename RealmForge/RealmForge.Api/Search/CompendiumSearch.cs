using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

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

		private sealed record Hit(Guid Id, string Kind, string Link, RulesetVersion Ruleset, bool IsBase, string? AuthorId, Dictionary<LanguageCode, string> Names,
			SearchDetailDto? Detail);

		//	One section of the compendium: its kind (the client's words for it), the table, its translations and the page link
		private abstract record Section(string Kind)
		{
			public abstract Task<List<Hit>> SearchAsync(CompendiumSearch search, string pattern, ClaimsPrincipal user, IReadOnlySet<Guid> shared);
			public abstract Task<Hit?> RandomAsync(CompendiumSearch search);
			public abstract Task<(int Edition2024, int Edition2014)> CountAsync(CompendiumSearch search);
		}

		private sealed record Section<T, TT>(string Kind, Func<RealmForgeDbContext, IQueryable<T>> Set, string ForeignKey, Func<T, string> Link,
			Func<T, SearchDetailDto?> Detail) : Section(Kind) where T : GameEntity where TT : class, ITranslation
		{
			public override Task<List<Hit>> SearchAsync(CompendiumSearch search, string pattern, ClaimsPrincipal user, IReadOnlySet<Guid> shared) =>
				search.SectionAsync<T, TT>(Set(search._context), ForeignKey, Kind, Link, Detail, pattern, user, shared);

			//	A base entry of this section, at random
			public override async Task<Hit?> RandomAsync(CompendiumSearch search)
			{
				var row = await Set(search._context).AsNoTracking().Where(e => e.IsOfficialSRD).OrderBy(e => EF.Functions.Random()).FirstOrDefaultAsync();
				return row is null ? null : (await search.HitsAsync<T, TT>(new List<T> { row }, ForeignKey, Kind, Link, Detail)).FirstOrDefault();
			}

			public override async Task<(int Edition2024, int Edition2014)> CountAsync(CompendiumSearch search)
			{
				var counts = await Set(search._context).AsNoTracking().Where(e => e.IsOfficialSRD).GroupBy(e => e.Ruleset)
					.Select(g => new { g.Key, Count = g.Count() }).ToListAsync();
				return (counts.FirstOrDefault(c => c.Key == RulesetVersion.Dnd5e_2024)?.Count ?? 0, counts.FirstOrDefault(c => c.Key == RulesetVersion.Dnd5e_2014)?.Count ?? 0);
			}
		}

		//	The sections in the order of the menu (glossary last); magic items without their variants for the random entry
		private static readonly Section[] Sections =
		[
			new Section<Species, SpeciesTranslation>("species", c => c.Species, "SpeciesId", e => $"species?id={e.Id}", _ => null),
			new Section<Subspecies, SubspeciesTranslation>("subspecies", c => c.Subspecies, "SubspeciesId", e => $"subspecies?id={e.Id}", _ => null),
			new Section<CharacterClass, CharacterClassTranslation>("class", c => c.Classes, "CharacterClassId", e => $"classes?id={e.Id}", _ => null),
			new Section<Subclass, SubclassTranslation>("subclass", c => c.Subclasses, "SubclassId", e => $"classes?id={e.CharacterClassId}&subclass={e.Id}", _ => null),
			new Section<Background, BackgroundTranslation>("background", c => c.Backgrounds, "BackgroundId", e => $"backgrounds?id={e.Id}", _ => null),
			new Section<Feat, FeatTranslation>("feat", c => c.Feats, "FeatId", e => $"feats?id={e.Id}", e => new SearchDetailDto(Feat: e.Category)),
			new Section<Spell, SpellTranslation>("spell", c => c.Spells, "SpellId", e => $"spells?id={e.Id}", e => new SearchDetailDto(SpellLevel: e.Level, School: e.School)),
			new Section<Equipment, EquipmentTranslation>("equipment", c => c.Equipment, "EquipmentId", e => $"equipment?id={e.Id}", e => new SearchDetailDto(Equipment: e.Category)),
			new Section<MagicItem, MagicItemTranslation>("magic-item", c => c.MagicItems, "MagicItemId", e => $"magic-items?id={e.Id}", e => new SearchDetailDto(Rarity: e.Rarity)),
			new Section<Monster, MonsterTranslation>("monster", c => c.Monsters.Where(m => !m.IsNpc), "MonsterId", e => $"monsters?id={e.Id}", e => new SearchDetailDto(Challenge: e.ChallengeRating, Creature: e.Type)),
			new Section<Monster, MonsterTranslation>("npc", c => c.Monsters.Where(m => m.IsNpc), "MonsterId", e => $"npcs?id={e.Id}", e => new SearchDetailDto(Challenge: e.ChallengeRating, Creature: e.Type)),
			new Section<RuleEntry, RuleEntryTranslation>("rule", c => c.RuleEntries, "RuleEntryId", e => $"rules?id={e.Id}", e => new SearchDetailDto(Rule: e.Category))
		];

		public static IReadOnlyList<string> Kinds { get; } = Sections.Select(s => s.Kind).ToList();

		///	<summary>
		///	A base entry of the compendium at random (of the given kinds, any when none): the section first, weighted by
		///	its size so that every entry has the same chance, then the entry.
		///	</summary>
		public async Task<SearchResultDto?> RandomAsync(LanguageCode lang, IReadOnlySet<string>? kinds = null)
		{
			var sections = Sections.Where(sec => kinds is null || kinds.Count == 0 || kinds.Contains(sec.Kind)).ToList();
			var sizes = new List<int>();
			foreach (var section in sections)
			{
				var (a, b) = await section.CountAsync(this);
				sizes.Add(a + b);
			}
			var total = sizes.Sum();
			if (total == 0)
			{
				return null;
			}
			var pick = Random.Shared.Next(total);
			var index = 0;
			while (pick >= sizes[index])
			{
				pick -= sizes[index];
				index++;
			}
			var hit = await sections[index].RandomAsync(this);
			return hit is null ? null : ToDto(hit, lang, null, null);
		}

		///	<summary>
		///	Base entries of each section per edition.
		///	</summary>
		public async Task<List<CompendiumSectionCountDto>> CountsAsync()
		{
			var list = new List<CompendiumSectionCountDto>();
			foreach (var section in Sections)
			{
				var (a, b) = await section.CountAsync(this);
				list.Add(new CompendiumSectionCountDto(section.Kind, a, b));
			}
			return list;
		}

		public async Task<List<SearchResultDto>> SearchAsync(string text, LanguageCode lang, ClaimsPrincipal user, IReadOnlySet<Guid> shared,
			IReadOnlySet<string>? kinds = null)
		{
			var query = text.Trim();
			var pattern = "%" + query.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_") + "%";
			var hits = new List<Hit>();

			//	Sequential: a DbContext does not run queries in parallel; kinds narrows the sections (the chips of the page)
			foreach (var section in Sections.Where(sec => kinds is null || kinds.Count == 0 || kinds.Contains(sec.Kind)))
			{
				hits.AddRange(await section.SearchAsync(this, pattern, user, shared));
			}

			var userId = user.Identity?.IsAuthenticated == true ? ContentAccess.GetUserId(user) : null;
			return hits
				.Select(h => new
				{
					Dto = ToDto(h, lang, userId, query),
					Rank = SearchRank.Of(query, h.Names.Values.FirstOrDefault() ?? string.Empty, h.Names.Values.Skip(1))
				})
				.OrderBy(x => x.Rank)
				.ThenBy(x => x.Dto.Name.Length)
				.ThenBy(x => x.Dto.Name, StringComparer.CurrentCultureIgnoreCase)
				.Take(MaxResults)
				.Select(x => x.Dto)
				.ToList();
		}

		private static SearchResultDto ToDto(Hit h, LanguageCode lang, string? userId, string? query)
		{
			var other = lang == LanguageCode.It ? LanguageCode.En : LanguageCode.It;
			var name = h.Names.GetValueOrDefault(lang) ?? h.Names.GetValueOrDefault(other) ?? "?";
			var otherName = h.Names.GetValueOrDefault(other);
			return new SearchResultDto(h.Id, h.Kind, name, otherName is not null && !string.Equals(otherName, name, StringComparison.OrdinalIgnoreCase) ? otherName : null,
				h.Link, h.Ruleset, h.IsBase, userId is not null && h.AuthorId == userId, h.Detail);
		}

		//	One section: the translations whose name matches, then the entries the user may see, then all their names
		private async Task<List<Hit>> SectionAsync<T, TT>(IQueryable<T> entities, string foreignKey, string kind, Func<T, string> link,
			Func<T, SearchDetailDto?> detail, string pattern, ClaimsPrincipal user, IReadOnlySet<Guid> shared) where T : GameEntity where TT : class, ITranslation
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
			return await HitsAsync<T, TT>(rows, foreignKey, kind, link, detail);
		}

		private async Task<List<Hit>> HitsAsync<T, TT>(List<T> rows, string foreignKey, string kind, Func<T, string> link, Func<T, SearchDetailDto?> detail)
			where T : GameEntity where TT : class, ITranslation
		{
			var found = rows.Select(r => r.Id).ToList();
			var names = await _context.Set<TT>().AsNoTracking()
				.Where(t => found.Contains(EF.Property<Guid>(t, foreignKey)))
				.Select(t => new { Id = EF.Property<Guid>(t, foreignKey), Language = EF.Property<LanguageCode>(t, "Language"), Name = EF.Property<string>(t, "Name") })
				.ToListAsync();
			return rows.Select(r => new Hit(r.Id, kind, link(r), r.Ruleset, r.IsOfficialSRD, r.AuthorId,
					names.Where(n => n.Id == r.Id).GroupBy(n => n.Language).ToDictionary(g => g.Key, g => g.First().Name), detail(r)))
				.ToList();
		}
	}
}
