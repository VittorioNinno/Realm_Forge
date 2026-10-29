using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Monsters;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Monsters: localized list (filters on ruleset, type and challenge), statblock, and Homebrew create/update/delete.
	///	A variant ("Crea variante") is a Homebrew copy of any monster the user can see, with the original's id in
	///	VariantOfId: the original stays untouched.
	///	</summary>
	[ApiController]
	[Route("api/monsters")]
	public class MonstersController : ControllerBase
	{
		public const int MaxHomebrewPerUser = 500;
		private const int MaxMarkdownLength = 20000;
		private const int MaxLineLength = 300;
		private const int MaxLongLineLength = 500;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public MonstersController(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		//	GET: api/monsters?lang=2&ruleset=1&type=8&minCr=1&maxCr=5
		[HttpGet]
		public async Task<ActionResult<List<MonsterResponseDto>>> GetMonsters(
			[FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] CreatureType? type = null,
			[FromQuery] decimal? minCr = null,
			[FromQuery] decimal? maxCr = null)
		{
			var query = _context.Monsters.AsNoTracking().Include(m => m.Translations).AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(m => m.Ruleset == ruleset.Value);
			}
			if (type.HasValue)
			{
				query = query.Where(m => m.Type == type.Value);
			}
			if (minCr.HasValue)
			{
				query = query.Where(m => m.ChallengeRating >= minCr.Value);
			}
			if (maxCr.HasValue)
			{
				query = query.Where(m => m.ChallengeRating <= maxCr.Value);
			}

			query = ContentAccess.ListedFor(query, User, await _shares.SharedWithAsync(User));

			var monsters = await query.AsSplitQuery().ToListAsync();
			return Ok(monsters
				.Select(m =>
				{
					var tr = m.Translations.Localize(lang);
					return new MonsterResponseDto(m.Id, tr?.Name ?? "Unknown", tr?.Alias, m.Ruleset, m.IsOfficialSRD, m.Size, m.Type,
						tr?.Subtitle ?? string.Empty, m.ArmorClass, m.HitPoints, m.HitDice, Plain(m.ChallengeRating), m.Xp, m.Dexterity,
						m.VariantOfId, _access.CanModify(m, User), m.Source, m.Visibility);
				})
				.OrderBy(m => m.Name, StringComparer.CurrentCultureIgnoreCase)
				.ToList());
		}

		//	GET: api/monsters/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<MonsterDetailDto>> GetMonster(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var monster = await _context.Monsters.AsNoTracking()
				.Include(m => m.Translations)
				.Include(m => m.VariantOf).ThenInclude(v => v!.Translations)
				.AsSplitQuery()
				.FirstOrDefaultAsync(m => m.Id == id);

			var shared = await _shares.SharedWithAsync(User);

			//	Private entries of other users answer 404, as if they did not exist
			if (monster is null || !_access.CanView(monster, User, shared))
			{
				return NotFound();
			}

			//	The original is named only when the user can see it
			var original = monster.VariantOf is { } v && _access.CanView(v, User, shared) ? v.Translations.Localize(lang)?.Name : null;
			var author = monster.AuthorId is { } authorId && !monster.IsOfficialSRD
				? (await PublicNames.LoadAsync(_context, new[] { authorId })).GetValueOrDefault(authorId)
				: null;

			return Ok(ToDetail(monster, lang, original, author));
		}

		//	POST: api/monsters
		[HttpPost]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<ActionResult<MonsterDetailDto>> CreateMonster([FromBody] SaveMonsterDto dto, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var userId = ContentAccess.GetUserId(User);
			if (await _context.Monsters.CountAsync(m => m.AuthorId == userId) >= MaxHomebrewPerUser)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: $"At most {MaxHomebrewPerUser} Homebrew monsters per account.");
			}

			var variantError = await CheckVariantAsync(dto.VariantOfId, null);
			if (variantError is not null)
			{
				return variantError;
			}

			var monster = new Monster
			{
				//	Content created through the API is always Homebrew; Base content comes only from the seeders
				IsOfficialSRD = false,
				AuthorId = userId,
				VariantOfId = dto.VariantOfId
			};
			Apply(monster, dto);
			monster.Translations = dto.Translations.Select(t => Translation(new MonsterTranslation(), t)).ToList();

			_context.Monsters.Add(monster);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMonster), new { id = monster.Id }, ToDetail(monster, lang, null, null));
		}

		//	PUT: api/monsters/{id}
		[HttpPut("{id:guid}")]
		[RequireConfirmedEmail]
		[Authorize]
		public async Task<IActionResult> UpdateMonster(Guid id, [FromBody] SaveMonsterDto dto)
		{
			var error = Validate(dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			var monster = await _context.Monsters.Include(m => m.Translations).FirstOrDefaultAsync(m => m.Id == id);
			if (monster is null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, monster);
			if (denied is not null)
			{
				return denied;
			}

			var variantError = await CheckVariantAsync(dto.VariantOfId, monster.Id);
			if (variantError is not null)
			{
				return variantError;
			}

			Apply(monster, dto);
			monster.VariantOfId = dto.VariantOfId;

			var languages = dto.Translations.Select(t => t.Language).ToHashSet();
			foreach (var tr in monster.Translations.Where(t => !languages.Contains(t.Language)).ToList())
			{
				monster.Translations.Remove(tr);
			}
			foreach (var text in dto.Translations)
			{
				var existing = monster.Translations.FirstOrDefault(t => t.Language == text.Language);
				if (existing is not null)
				{
					Translation(existing, text);
				}
				else
				{
					//	Added through the context so EF inserts it (a preset Guid key would otherwise be treated as an existing row)
					_context.MonsterTranslations.Add(Translation(new MonsterTranslation { MonsterId = monster.Id }, text));
				}
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	DELETE: api/monsters/{id} — the variants made from it stay, without the link
		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteMonster(Guid id)
		{
			var monster = await _context.Monsters.FindAsync(id);
			if (monster is null)
			{
				return NotFound();
			}

			var denied = this.EnsureCanModify(_access, monster);
			if (denied is not null)
			{
				return denied;
			}

			_context.Monsters.Remove(monster);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		#region Mapping & validation

		//	0.250 read from the database answers 0.25 (no trailing zeros of the column scale)
		private static decimal Plain(decimal value) => value / 1.000000000000000000000000000000000m;

		internal static MonsterTextDto ToText(MonsterTranslation? tr, LanguageCode lang) => new()
		{
			Language = tr?.Language ?? lang,
			Name = tr?.Name ?? "Unknown",
			Alias = tr?.Alias,
			Subtitle = tr?.Subtitle ?? string.Empty,
			ArmorClass = tr?.ArmorClass ?? string.Empty,
			Speed = tr?.Speed ?? string.Empty,
			SavingThrows = tr?.SavingThrows ?? string.Empty,
			Skills = tr?.Skills ?? string.Empty,
			DamageVulnerabilities = tr?.DamageVulnerabilities ?? string.Empty,
			DamageResistances = tr?.DamageResistances ?? string.Empty,
			DamageImmunities = tr?.DamageImmunities ?? string.Empty,
			ConditionImmunities = tr?.ConditionImmunities ?? string.Empty,
			Senses = tr?.Senses ?? string.Empty,
			Languages = tr?.Languages ?? string.Empty,
			Traits = tr?.Traits ?? string.Empty,
			Actions = tr?.Actions ?? string.Empty,
			BonusActions = tr?.BonusActions ?? string.Empty,
			Reactions = tr?.Reactions ?? string.Empty,
			LegendaryActions = tr?.LegendaryActions ?? string.Empty,
			Description = tr?.Description ?? string.Empty
		};

		private MonsterDetailDto ToDetail(Monster m, LanguageCode lang, string? original, string? author) => new(
			m.Id, m.Ruleset, m.IsOfficialSRD, m.Size, m.Type, m.ArmorClass, m.HitPoints, m.HitDice, m.Speed,
			new List<int> { m.Strength, m.Dexterity, m.Constitution, m.Intelligence, m.Wisdom, m.Charisma },
			Plain(m.ChallengeRating), m.Xp, m.ProficiencyBonus, m.PassivePerception, m.VariantOfId, original,
			ToText(m.Translations.Localize(lang), lang), _access.CanModify(m, User), m.Source, m.Visibility, author);

		private static void Apply(Monster m, SaveMonsterDto dto)
		{
			m.Ruleset = dto.Ruleset;
			m.Visibility = dto.Visibility;
			m.Size = dto.Size;
			m.Type = dto.Type;
			m.ArmorClass = dto.ArmorClass;
			m.HitPoints = dto.HitPoints;
			m.HitDice = (dto.HitDice ?? string.Empty).Trim();
			m.Speed = dto.Speed;
			m.Strength = dto.Abilities[0];
			m.Dexterity = dto.Abilities[1];
			m.Constitution = dto.Abilities[2];
			m.Intelligence = dto.Abilities[3];
			m.Wisdom = dto.Abilities[4];
			m.Charisma = dto.Abilities[5];
			m.ChallengeRating = dto.ChallengeRating;

			//	The experience follows the challenge unless it was set on purpose
			m.Xp = dto.Xp > 0 ? dto.Xp : MonsterMath.XpFor(dto.ChallengeRating);
			m.ProficiencyBonus = dto.ProficiencyBonus;
			m.PassivePerception = dto.PassivePerception;
		}

		private static MonsterTranslation Translation(MonsterTranslation target, MonsterTextDto t)
		{
			static string Clean(string? value) => value?.Trim() ?? string.Empty;
			target.Language = t.Language;
			target.Name = Clean(t.Name);
			target.Alias = string.IsNullOrWhiteSpace(t.Alias) ? null : t.Alias.Trim();
			target.Subtitle = Clean(t.Subtitle);
			target.ArmorClass = Clean(t.ArmorClass);
			target.Speed = Clean(t.Speed);
			target.SavingThrows = Clean(t.SavingThrows);
			target.Skills = Clean(t.Skills);
			target.DamageVulnerabilities = Clean(t.DamageVulnerabilities);
			target.DamageResistances = Clean(t.DamageResistances);
			target.DamageImmunities = Clean(t.DamageImmunities);
			target.ConditionImmunities = Clean(t.ConditionImmunities);
			target.Senses = Clean(t.Senses);
			target.Languages = Clean(t.Languages);
			target.Traits = Clean(t.Traits);
			target.Actions = Clean(t.Actions);
			target.BonusActions = Clean(t.BonusActions);
			target.Reactions = Clean(t.Reactions);
			target.LegendaryActions = Clean(t.LegendaryActions);
			target.Description = Clean(t.Description);
			return target;
		}

		//	A variant must come from a monster the user can see (and not from itself)
		private async Task<ActionResult?> CheckVariantAsync(Guid? variantOfId, Guid? self)
		{
			if (variantOfId is not { } originalId)
			{
				return null;
			}
			if (originalId == self)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A monster cannot be a variant of itself.");
			}
			var original = await _context.Monsters.AsNoTracking().FirstOrDefaultAsync(m => m.Id == originalId);
			if (original is null || !_access.CanView(original, User, await _shares.SharedWithAsync(User)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The original monster does not exist.");
			}
			return null;
		}

		internal static string? Validate(SaveMonsterDto dto)
		{
			if (dto.Translations is null || dto.Translations.Count == 0 || dto.Translations.Any(t => string.IsNullOrWhiteSpace(t.Name)))
			{
				return "Every translation must have a name.";
			}
			if (dto.Translations.GroupBy(t => t.Language).Any(g => g.Count() > 1))
			{
				return "Only one translation per language is allowed.";
			}
			if (!Enum.IsDefined(dto.Ruleset) || !Enum.IsDefined(dto.Visibility) || !Enum.IsDefined(dto.Size) || !Enum.IsDefined(dto.Type))
			{
				return "Unknown ruleset, visibility, size or type.";
			}
			if (dto.Abilities is not { Count: 6 } || dto.Abilities.Any(a => a is < 1 or > 30))
			{
				return "Six ability scores between 1 and 30 are required.";
			}
			if (dto.ArmorClass is < 1 or > 40 || dto.HitPoints is < 1 or > 5000 || dto.Speed is < 0 or > 500)
			{
				return "Armor class (1-40), hit points (1-5000) or speed (0-500) out of range.";
			}
			if (!MonsterMath.IsChallenge(dto.ChallengeRating) || dto.Xp is < 0 or > 1000000)
			{
				return "Unknown challenge rating or experience out of range.";
			}
			if (dto.ProficiencyBonus is < 0 or > 12 || dto.PassivePerception is < 0 or > 50)
			{
				return "Proficiency bonus (0-12) or passive Perception (0-50) out of range.";
			}
			if ((dto.HitDice ?? string.Empty).Trim().Length > 40)
			{
				return "Hit dice: at most 40 characters.";
			}
			foreach (var t in dto.Translations)
			{
				if (t.Name.Trim().Length > 150 || (t.Alias?.Trim().Length ?? 0) > 150)
				{
					return "Names: at most 150 characters.";
				}
				var lines = new[] { t.Subtitle, t.ArmorClass, t.Speed, t.SavingThrows };
				var longLines = new[] { t.Skills, t.DamageVulnerabilities, t.DamageResistances, t.DamageImmunities, t.ConditionImmunities, t.Senses, t.Languages };
				var blocks = new[] { t.Traits, t.Actions, t.BonusActions, t.Reactions, t.LegendaryActions, t.Description };
				if (lines.Any(l => (l?.Trim().Length ?? 0) > MaxLineLength) || longLines.Any(l => (l?.Trim().Length ?? 0) > MaxLongLineLength)
					|| blocks.Any(b => (b?.Trim().Length ?? 0) > MaxMarkdownLength))
				{
					return "A text of the statblock is too long.";
				}
			}
			return null;
		}

		#endregion
	}
}
