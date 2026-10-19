using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Player characters of the signed-in user: list, sheet, creation (with every choice checked against the rules
	///	and the compendium) and deletion. Characters are private: only their owner reads them.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class CharactersController : ControllerBase
	{
		public const int MaxCharactersPerUser = 50;

		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;

		public CharactersController(RealmForgeDbContext context, ContentAccess access)
		{
			_context = context;
			_access = access;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/characters?lang=2
		[HttpGet]
		public async Task<ActionResult<List<CharacterSummaryDto>>> GetCharacters([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var characters = await WithReferences(_context.Characters.AsNoTracking())
				.Where(c => c.OwnerId == UserId)
				.OrderByDescending(c => c.UpdatedAt)
				.ToListAsync();

			return Ok(characters.Select(c => new CharacterSummaryDto(
				c.Id, c.Name, c.Ruleset, c.Level,
				c.Species.Translations.Localize(lang)?.Name ?? string.Empty,
				c.Class.Translations.Localize(lang)?.Name ?? string.Empty,
				c.Subclass?.Translations.Localize(lang)?.Name,
				c.Background.Translations.Localize(lang)?.Name ?? string.Empty,
				c.MaxHitPoints, c.ArmorClass, c.UpdatedAt)).ToList());
		}

		//	GET: api/characters/{id}?lang=2
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CharacterDetailDto>> GetCharacter(Guid id, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var character = await WithReferences(_context.Characters.AsNoTracking()).FirstOrDefaultAsync(c => c.Id == id);
			if (character is null || (character.OwnerId != UserId && !_access.IsAdmin(User)))
			{
				return NotFound();
			}

			var spells = await _context.Spells.AsNoTracking().Include(s => s.Translations)
				.Where(s => character.SpellIds.Contains(s.Id)).ToListAsync();
			var feat = character.Background.OriginFeatId is { } featId
				? await _context.Feats.AsNoTracking().Include(f => f.Translations).FirstOrDefaultAsync(f => f.Id == featId)
				: null;

			var final = CharacterMath.FinalScores(character.BaseScores, character.AbilityBonuses);
			var background = character.Background.Translations.Localize(lang);
			var cls = character.Class.Translations.Localize(lang);

			return Ok(new CharacterDetailDto(
				character.Id, character.Name, character.Ruleset, character.Level, character.Alignment,
				Ref(character.Species.Id, character.Species.Translations.Localize(lang)?.Name),
				character.Subspecies is { } sub ? Ref(sub.Id, sub.Translations.Localize(lang)?.Name) : null,
				character.Size,
				character.Subspecies?.BaseSpeedOverrideInFeet ?? character.Species.BaseSpeedInFeet,
				Ref(character.Background.Id, background?.Name),
				feat is null ? null : Ref(feat.Id, feat.Translations.Localize(lang)?.Name),
				Ref(character.Class.Id, cls?.Name),
				character.Subclass is { } subclass ? Ref(subclass.Id, subclass.Translations.Localize(lang)?.Name) : null,
				character.Class.HitDie,
				character.Languages,
				character.AbilityMethod, character.BaseScores, character.BonusMode, character.AbilityBonuses, final.ToList(),
				character.Class.SavingThrows,
				character.Background.SkillProficiencies.Concat(character.ClassSkills).Distinct().OrderBy(s => s).ToList(),
				CharacterMath.ProficiencyBonus(character.Level),
				character.MaxHitPoints, character.ArmorClass,
				EquipmentLines(character, background?.Equipment, cls?.StartingEquipment, lang),
				spells.Select(s => new CharacterSpellDto(s.Id, s.Translations.Localize(lang)?.Name ?? string.Empty, s.Level))
					.OrderBy(s => s.Level).ThenBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase).ToList(),
				character.Subclass?.SpellcastingAbility ?? character.Class.SpellcastingAbility,
				character.CreatedAt, character.UpdatedAt));
		}

		//	POST: api/characters
		[HttpPost]
		public async Task<ActionResult<CharacterSummaryDto>> CreateCharacter([FromBody] SaveCharacterDto dto)
		{
			if (await _context.Characters.CountAsync(c => c.OwnerId == UserId) >= MaxCharactersPerUser)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCharactersPerUser} characters per account.");
			}

			var character = new Character { OwnerId = UserId };
			var error = await ApplyAsync(character, dto);
			if (error is not null)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: error);
			}

			_context.Characters.Add(character);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, new CharacterSummaryDto(
				character.Id, character.Name, character.Ruleset, character.Level, string.Empty, string.Empty, null, string.Empty,
				character.MaxHitPoints, character.ArmorClass, character.UpdatedAt));
		}

		//	DELETE: api/characters/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteCharacter(Guid id)
		{
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
			if (character is null || character.OwnerId != UserId)
			{
				return NotFound();
			}

			_context.Characters.Remove(character);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private static IQueryable<Character> WithReferences(IQueryable<Character> query) => query
			.Include(c => c.Species).ThenInclude(s => s.Translations)
			.Include(c => c.Subspecies).ThenInclude(s => s!.Translations)
			.Include(c => c.Background).ThenInclude(b => b.Translations)
			.Include(c => c.Class).ThenInclude(c => c.Translations)
			.Include(c => c.Subclass).ThenInclude(s => s!.Translations)
			.AsSplitQuery();

		private static CharacterRefDto Ref(Guid id, string? name) => new(id, name ?? string.Empty);

		///	<summary>
		///	Checks every choice against the rules and the compendium and copies it to the character, with the derived values.
		///	Returns the reason of the first problem, or null.
		///	</summary>
		private async Task<string?> ApplyAsync(Character character, SaveCharacterDto dto)
		{
			var name = dto.Name?.Trim() ?? string.Empty;
			if (name.Length is 0 or > 100)
			{
				return "The name is required (at most 100 characters).";
			}
			if (dto.Level is < 1 or > 20)
			{
				return "The level must be between 1 and 20.";
			}
			if (!Enum.IsDefined(dto.Alignment) || !Enum.IsDefined(dto.Size) || !Enum.IsDefined(dto.AbilityMethod) || !Enum.IsDefined(dto.BonusMode))
			{
				return "Unknown alignment, size or ability method.";
			}

			var species = await _context.Species.Include(s => s.Subspecies).FirstOrDefaultAsync(s => s.Id == dto.SpeciesId);
			if (species is null || species.Ruleset != dto.Ruleset || !_access.CanView(species, User))
			{
				return "Unknown species for this edition.";
			}
			if (!species.AllowedSizes.Contains(dto.Size))
			{
				return "The species does not allow this size.";
			}

			Subspecies? subspecies = null;
			if (dto.SubspeciesId is { } subId)
			{
				subspecies = species.Subspecies.FirstOrDefault(s => s.Id == subId);
				if (subspecies is null || !_access.CanView(subspecies, User))
				{
					return "The subspecies does not belong to the species.";
				}
			}

			var background = await _context.Backgrounds.Include(b => b.Translations).FirstOrDefaultAsync(b => b.Id == dto.BackgroundId);
			if (background is null || background.Ruleset != dto.Ruleset || !_access.CanView(background, User))
			{
				return "Unknown background for this edition.";
			}

			var cls = await _context.Classes.Include(c => c.Translations).Include(c => c.Subclasses).FirstOrDefaultAsync(c => c.Id == dto.ClassId);
			if (cls is null || cls.Ruleset != dto.Ruleset || !_access.CanView(cls, User))
			{
				return "Unknown class for this edition.";
			}

			Subclass? subclass = null;
			if (dto.SubclassId is { } subclassId)
			{
				subclass = cls.Subclasses.FirstOrDefault(s => s.Id == subclassId);
				if (subclass is null || !_access.CanView(subclass, User) || dto.Level < cls.SubclassLevel)
				{
					return "The subclass does not belong to the class or the level is too low.";
				}
			}

			var languages = dto.Languages.Select(l => l?.Trim() ?? string.Empty).Where(l => l.Length > 0).Distinct().ToList();
			if (languages.Count > 6 || languages.Any(l => l.Length > 50))
			{
				return "Too many languages.";
			}

			var skills = dto.ClassSkills.Distinct().ToList();
			if (skills.Count != dto.ClassSkills.Count || skills.Count > cls.SkillChoiceCount || skills.Any(s => !cls.SkillOptions.Contains(s)))
			{
				return "The class skills are not among the options of the class.";
			}

			if (!CharacterMath.AreValidBaseScores(dto.AbilityMethod, dto.BaseScores))
			{
				return "The ability scores do not match the chosen method.";
			}

			var allowed = dto.Ruleset == RulesetVersion.Dnd5e_2024 ? background.AbilityOptions : new List<AbilityScore>();
			if ((dto.BonusMode == AbilityBonusMode.AllOnes && dto.Ruleset == RulesetVersion.Dnd5e_2024) || !CharacterMath.AreValidBonuses(dto.BonusMode, dto.AbilityBonuses, allowed))
			{
				return "The ability score increases do not match the rules of the origin.";
			}

			var final = CharacterMath.FinalScores(dto.BaseScores, dto.AbilityBonuses);

			//	Equipment: option A/B of the background, one choice per line (or kit) of the class
			var hasGold = background.EquipmentGoldAlternative is not null;
			if (hasGold ? dto.BackgroundEquipment is not ("A" or "B") : dto.BackgroundEquipment is not null)
			{
				return "Invalid background equipment option.";
			}

			var classText = cls.Translations.Localize(LanguageCode.En)?.StartingEquipment;
			var loadout = EquipmentLoadout.FromClassText(classText);
			if (!IsValidClassChoice(loadout, dto.ClassEquipment))
			{
				return "Invalid class equipment choices.";
			}

			//	Spells: from the class list, within the allowance of the level
			var key = BaseClassKeys.Of(cls.Id, cls.Ruleset);
			var abilityModifier = (subclass?.SpellcastingAbility ?? cls.SpellcastingAbility) is { } spellAbility
				? CharacterMath.Modifier(CharacterMath.Score(final, spellAbility))
				: 0;
			var allowance = CharacterMath.Spells(cls.Translations.Localize(LanguageCode.En)?.ProgressionTable, dto.Level, abilityModifier, key == "paladin");
			var spellIds = dto.SpellIds.Distinct().ToList();
			var spells = await _context.Spells.Where(s => spellIds.Contains(s.Id)).ToListAsync();
			var list = BaseClassKeys.SpellList(key);
			if (spells.Count != spellIds.Count || spells.Any(s => s.Ruleset != dto.Ruleset || !_access.CanView(s, User))
				|| (list is { } spellList && spells.Any(s => !s.Classes.Contains(spellList)))
				|| spells.Count(s => s.Level == 0) > allowance.Cantrips
				|| spells.Count(s => s.Level > 0) > allowance.Spells
				|| spells.Any(s => s.Level > allowance.MaxSpellLevel && s.Level > 0))
			{
				return "The spells are not available to this class at this level.";
			}

			character.Name = name;
			character.Ruleset = dto.Ruleset;
			character.Level = dto.Level;
			character.Alignment = dto.Alignment;
			character.SpeciesId = species.Id;
			character.SubspeciesId = subspecies?.Id;
			character.Size = dto.Size;
			character.BackgroundId = background.Id;
			character.Languages = languages;
			character.ClassId = cls.Id;
			character.SubclassId = subclass?.Id;
			character.ClassSkills = skills;
			character.AbilityMethod = dto.AbilityMethod;
			character.BaseScores = dto.BaseScores.ToList();
			character.BonusMode = dto.BonusMode;
			character.AbilityBonuses = dto.AbilityBonuses.ToList();
			character.BackgroundEquipment = dto.BackgroundEquipment;
			character.ClassEquipment = dto.ClassEquipment.ToList();
			character.SpellIds = spellIds;
			character.MaxHitPoints = CharacterMath.MaxHitPoints(cls.HitDie, dto.Level, CharacterMath.Modifier(CharacterMath.Score(final, AbilityScore.Constitution)));
			character.ArmorClass = await ArmorClassAsync(character, final, key, background.Translations.Localize(LanguageCode.En)?.Equipment, classText);
			character.UpdatedAt = DateTimeOffset.UtcNow;
			return null;
		}

		private static bool IsValidClassChoice(EquipmentLoadout loadout, IReadOnlyList<string> choice)
		{
			if (loadout.IsEmpty)
			{
				return choice.Count == 0;
			}
			if (loadout.Kits.Count > 0)
			{
				return choice.Count == 1 && loadout.Kits.Any(k => k.Letter == choice[0]);
			}

			return choice.Count == loadout.Rows.Count && loadout.Rows.Select((row, i) =>
				row.Options.Count == 1 ? choice[i] == string.Empty : row.Options.Any(o => o.Letter == choice[i])).All(ok => ok);
		}

		///	<summary>
		///	Items the character starts with: the chosen background option and class kit or lines.
		///	</summary>
		private static IEnumerable<LoadoutItem> ChosenItems(string? backgroundText, int? gold, string? backgroundChoice, string? classText, IReadOnlyList<string> classChoice, LanguageCode lang = LanguageCode.En)
		{
			var background = EquipmentLoadout.FromBackground(backgroundText, gold is null ? null : lang == LanguageCode.It ? $"{gold} mo" : $"{gold} GP");
			var backgroundItems = background.Kits.Count > 0
				? background.Kits.FirstOrDefault(k => k.Letter == backgroundChoice)?.Items ?? Array.Empty<LoadoutItem>()
				: background.Rows.SelectMany(r => r.Options[0].Items);

			var cls = EquipmentLoadout.FromClassText(classText);
			var classItems = cls.Kits.Count > 0
				? cls.Kits.FirstOrDefault(k => classChoice.Count > 0 && k.Letter == classChoice[0])?.Items ?? Array.Empty<LoadoutItem>()
				: cls.Rows.SelectMany((row, i) => row.Options.Count == 1
					? row.Options[0].Items
					: row.Options.FirstOrDefault(o => i < classChoice.Count && o.Letter == classChoice[i])?.Items ?? Array.Empty<LoadoutItem>());

			return backgroundItems.Concat(classItems);
		}

		private List<string> EquipmentLines(Character character, string? backgroundText, string? classText, LanguageCode lang) =>
			ChosenItems(backgroundText, character.Background.EquipmentGoldAlternative is int gold ? gold : null, character.BackgroundEquipment, classText, character.ClassEquipment, lang)
				.Select(i => string.Join(" ", new[] { i.Quantity is > 1 ? $"{i.Quantity}" : null, i.Text, i.Coins }.Where(p => !string.IsNullOrWhiteSpace(p))))
				.Where(l => l.Length > 0)
				.ToList();

		//	Armor and shields among the starting items (English names matched against the Base equipment of the edition)
		private async Task<int> ArmorClassAsync(Character character, int[] final, string? classKey, string? backgroundText, string? classText)
		{
			var armor = await _context.Equipment.AsNoTracking().Include(e => e.Translations)
				.Where(e => e.Ruleset == character.Ruleset && e.IsOfficialSRD && e.Category == EquipmentCategory.Armor)
				.ToListAsync();
			var matcher = new EquipmentNameMatcher(armor.Select(a => (a.Translations.Localize(LanguageCode.En)?.Name ?? string.Empty, a.Id)));
			var gold = await _context.Backgrounds.Where(b => b.Id == character.BackgroundId).Select(b => b.EquipmentGoldAlternative).FirstOrDefaultAsync();

			var worn = ChosenItems(backgroundText, gold, character.BackgroundEquipment, classText, character.ClassEquipment)
				.Select(i => matcher.Find(i.Text))
				.Where(id => id is not null)
				.Select(id => armor.First(a => a.Id == id))
				.Where(a => a.ArmorCategory is not null && a.ArmorClass is not null)
				.Select(a => new WornArmor(a.ArmorCategory!.Value, a.ArmorClass!.Value, a.ArmorAddsDexterity, a.ArmorMaxDexterityBonus));

			return CharacterMath.ArmorClass(worn,
				CharacterMath.Score(final, AbilityScore.Dexterity), CharacterMath.Score(final, AbilityScore.Constitution),
				CharacterMath.Score(final, AbilityScore.Wisdom), classKey);
		}
	}
}
