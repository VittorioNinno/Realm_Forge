using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Characters;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Player characters of the signed-in user. Every save is checked by <see cref="CharacterCalculator"/> against the
	///	compendium of the edition (the same rules the wizard runs); the play state of the sheet is saved on its own.
	///	Characters are private: only their owner reads and changes them.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class CharactersController : ControllerBase
	{
		public const int MaxCharactersPerUser = 50;

		//	Portrait: a small JPEG resized in the browser (about 60 KB), stored as a data URL
		public const int MaxPortraitLength = 400_000;

		public static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		private readonly RealmForgeDbContext _context;
		private readonly CharacterContextBuilder _builder;

		public CharactersController(RealmForgeDbContext context, CharacterContextBuilder builder)
		{
			_context = context;
			_builder = builder;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	GET: api/characters/context?ruleset=2&lang=2 — the rules data of an edition (also for visitors)
		[HttpGet("context")]
		[AllowAnonymous]
		public async Task<ActionResult<CharacterContextDto>> GetContext([FromQuery] RulesetVersion ruleset = RulesetVersion.Dnd5e_2024, [FromQuery] LanguageCode lang = LanguageCode.It)
		{
			if (!Enum.IsDefined(ruleset))
			{
				return BadRequest();
			}

			return Ok(await _builder.BuildAsync(ruleset, lang, User));
		}

		//	GET: api/characters?lang=2
		[HttpGet]
		public async Task<ActionResult<List<CharacterSummaryDto>>> GetCharacters([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var characters = await _context.Characters.AsNoTracking()
				.Include(c => c.Species).ThenInclude(s => s.Translations)
				.Include(c => c.Background).ThenInclude(b => b.Translations)
				.Where(c => c.OwnerId == UserId)
				.OrderByDescending(c => c.UpdatedAt)
				.ToListAsync();

			var builds = characters.ToDictionary(c => c.Id, c => ReadBuild(c.Build));
			var classIds = builds.Values.SelectMany(b => b.Levels.Select(l => l.ClassId)).Distinct().ToList();
			var classNames = await _context.ClassTranslations.AsNoTracking()
				.Where(t => classIds.Contains(t.CharacterClassId))
				.ToListAsync();

			string ClassLine(CharacterBuild build) => string.Join(" / ", build.Levels
				.GroupBy(l => l.ClassId)
				.Select(g => $"{classNames.Where(t => t.CharacterClassId == g.Key).Localize(lang)?.Name} {g.Count()}"));

			return Ok(characters.Select(c =>
			{
				var sheet = ReadSheet(c.Sheet);
				return new CharacterSummaryDto(
					c.Id, c.Name, c.Ruleset, c.Level,
					c.Species.Translations.Localize(lang)?.Name ?? string.Empty,
					ClassLine(builds[c.Id]),
					c.Background.Translations.Localize(lang)?.Name ?? string.Empty,
					c.MaxHitPoints, Math.Clamp(sheet.CurrentHitPoints ?? c.MaxHitPoints, 0, c.MaxHitPoints), c.ArmorClass, c.UpdatedAt);
			}).ToList());
		}

		//	GET: api/characters/{id}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CharacterDto>> GetCharacter(Guid id)
		{
			var character = await _context.Characters.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == UserId);
			return character is null ? NotFound() : Ok(ToDto(character));
		}

		//	POST: api/characters
		[HttpPost]
		public async Task<ActionResult<CharacterDto>> CreateCharacter([FromBody] SaveCharacterDto dto)
		{
			dto.Build ??= new CharacterBuild();
			if (await _context.Characters.CountAsync(c => c.OwnerId == UserId) >= MaxCharactersPerUser)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxCharactersPerUser} characters per account.");
			}

			var context = await _builder.BuildAsync(dto.Ruleset, Enum.IsDefined(dto.Language) ? dto.Language : LanguageCode.En, User);
			var sheet = Sanitize(dto.Sheet ?? new CharacterSheetState());
			sheet.CurrentHitPoints = null;
			ApplyAdvancement(sheet, dto.Advancement);
			(sheet.Inventory, sheet.Coins) = StartingEquipment.Build(dto.Build ?? new CharacterBuild(), context, dto.BackgroundId);

			var input = Input(dto, sheet);
			var computed = CharacterCalculator.Compute(input, context, checkEquipment: true);
			if (!computed.CanSave)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: Describe(computed));
			}

			var character = new Character { OwnerId = UserId };
			Apply(character, dto, sheet, computed);
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, ToDto(character));
		}

		//	PUT: api/characters/{id} — new rules choices (edit, level up); the inventory and the play state stay
		[HttpPut("{id:guid}")]
		public async Task<ActionResult<CharacterDto>> UpdateCharacter(Guid id, [FromBody] SaveCharacterDto dto)
		{
			dto.Build ??= new CharacterBuild();
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == UserId);
			if (character is null)
			{
				return NotFound();
			}
			if (dto.Ruleset != character.Ruleset)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The edition of a character cannot change.");
			}

			//	The starting equipment was turned into the inventory when the character was created
			var previous = ReadBuild(character.Build);
			dto.Build.BackgroundEquipment = previous.BackgroundEquipment;
			dto.Build.ClassEquipment = previous.ClassEquipment;
			dto.Build.EquipmentPicks = previous.EquipmentPicks;

			var sheet = ReadSheet(character.Sheet);
			ApplyAdvancement(sheet, dto.Advancement);
			var context = await _builder.BuildAsync(dto.Ruleset, LanguageCode.En, User);
			var computed = CharacterCalculator.Compute(Input(dto, sheet), context);
			if (!computed.CanSave)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: Describe(computed));
			}

			if (sheet.CurrentHitPoints is { } current)
			{
				//	Gaining levels raises the current hit points as much as the maximum
				sheet.CurrentHitPoints = Math.Clamp(current + computed.MaxHitPoints - character.MaxHitPoints, 0, computed.MaxHitPoints);
			}

			Apply(character, dto, sheet, computed);
			await _context.SaveChangesAsync();
			return Ok(ToDto(character));
		}

		//	PUT: api/characters/{id}/sheet — the play state (hit points, resources, inventory, notes)
		[HttpPut("{id:guid}/sheet")]
		public async Task<ActionResult<CharacterSavedDto>> UpdateSheet(Guid id, [FromBody] CharacterSheetState sheet)
		{
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == UserId);
			if (character is null)
			{
				return NotFound();
			}

			sheet = Sanitize(sheet);
			var build = ReadBuild(character.Build);
			var context = await _builder.BuildAsync(character.Ruleset, LanguageCode.En, User);
			var input = new CharacterInput
			{
				Name = character.Name,
				Ruleset = character.Ruleset,
				SpeciesId = character.SpeciesId,
				SubspeciesId = character.SubspeciesId,
				BackgroundId = character.BackgroundId,
				Build = build,
				Sheet = sheet
			};
			var computed = CharacterCalculator.Compute(input, context);
			if (sheet.CurrentHitPoints is { } current)
			{
				sheet.CurrentHitPoints = Math.Clamp(current, 0, computed.MaxHitPoints);
			}

			character.Sheet = JsonSerializer.Serialize(sheet, Json);
			character.MaxHitPoints = computed.MaxHitPoints;
			character.ArmorClass = computed.ArmorClass;
			character.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();

			return Ok(new CharacterSavedDto(character.Id, character.MaxHitPoints, character.ArmorClass, character.UpdatedAt));
		}

		//	DELETE: api/characters/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteCharacter(Guid id)
		{
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == UserId);
			if (character is null)
			{
				return NotFound();
			}

			_context.Characters.Remove(character);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Helpers =====

		private static CharacterInput Input(SaveCharacterDto dto, CharacterSheetState sheet) => new()
		{
			Name = dto.Name?.Trim() ?? string.Empty,
			Ruleset = dto.Ruleset,
			SpeciesId = dto.SpeciesId,
			SubspeciesId = dto.SubspeciesId,
			BackgroundId = dto.BackgroundId,
			Build = dto.Build ?? new CharacterBuild(),
			Sheet = sheet
		};

		private static void Apply(Character character, SaveCharacterDto dto, CharacterSheetState sheet, ComputedCharacter computed)
		{
			character.Name = dto.Name.Trim();
			character.Ruleset = dto.Ruleset;
			character.Level = computed.Level;
			character.SpeciesId = dto.SpeciesId;
			character.SubspeciesId = dto.SubspeciesId;
			character.BackgroundId = dto.BackgroundId;
			character.ClassId = dto.Build.Levels[0].ClassId;
			character.Build = JsonSerializer.Serialize(dto.Build, Json);
			character.Sheet = JsonSerializer.Serialize(sheet, Json);
			character.MaxHitPoints = computed.MaxHitPoints;
			character.ArmorClass = computed.ArmorClass;
			character.UpdatedAt = DateTimeOffset.UtcNow;
		}

		private static string Describe(ComputedCharacter computed) =>
			"The character does not follow the rules: " + string.Join("; ", computed.Issues.Where(i => i.Blocking).Select(i => i.ToString()).Distinct().Take(5));

		public static CharacterBuild ReadBuild(string json)
		{
			try
			{
				return JsonSerializer.Deserialize<CharacterBuild>(json, Json) ?? new CharacterBuild();
			}
			catch (JsonException)
			{
				return new CharacterBuild();
			}
		}

		public static CharacterSheetState ReadSheet(string json)
		{
			try
			{
				return JsonSerializer.Deserialize<CharacterSheetState>(json, Json) ?? new CharacterSheetState();
			}
			catch (JsonException)
			{
				return new CharacterSheetState();
			}
		}

		private static CharacterDto ToDto(Character c) => new(
			c.Id, c.Name, c.Ruleset, c.SpeciesId, c.SubspeciesId, c.BackgroundId, ReadBuild(c.Build), ReadSheet(c.Sheet),
			c.MaxHitPoints, c.ArmorClass, c.CreatedAt, c.UpdatedAt);

		///	<summary>
		///	Bounds for everything the client can write in the sheet.
		///	</summary>
		//	Magic properties of an item: known kinds only, small numbers, dice like "1d6+1"
		private static MagicItemProperties? SanitizeMagic(MagicItemProperties? magic)
		{
			if (magic is null)
			{
				return null;
			}
			static string? Dice(string? value) => value is not null && System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{1,2}d\d{1,3}([+-]\d{1,3})?$") ? value : null;
			magic.Rarity = Enum.IsDefined(magic.Rarity) ? magic.Rarity : ItemRarity.Uncommon;
			magic.Recharge = Enum.IsDefined(magic.Recharge) ? magic.Recharge : ItemRecharge.None;
			magic.Effects = (magic.Effects ?? new()).Where(e => Enum.IsDefined(e.Kind)).Take(12).Select(e =>
			{
				e.Value = Math.Clamp(e.Value, -30, 30);
				e.Ability = e.Ability is { } a && Enum.IsDefined(a) ? a : null;
				e.DamageType = e.DamageType is { } d && Enum.IsDefined(d) ? d : null;
				return e;
			}).ToList();
			magic.Charges = Math.Clamp(magic.Charges, 0, 99);
			magic.ChargesUsed = Math.Clamp(magic.ChargesUsed, 0, magic.Charges);
			magic.RechargeDice = Dice(magic.RechargeDice);
			magic.HealDice = Dice(magic.HealDice);
			magic.Template = magic.Template is { Length: <= 60 } template ? template : null;
			return magic;
		}

		private static void ApplyAdvancement(CharacterSheetState sheet, AdvancementType? advancement)
		{
			if (advancement is { } value && Enum.IsDefined(value))
			{
				sheet.Advancement = value;
			}
		}

		private static CharacterSheetState Sanitize(CharacterSheetState sheet)
		{
			if (!Enum.IsDefined(sheet.Advancement))
			{
				sheet.Advancement = AdvancementType.Experience;
			}
			static string? Text(string? value, int max = 8000) => value is null ? null : value.Length > max ? value[..max] : value;
			static int Clamp(int value, int min, int max) => Math.Clamp(value, min, max);

			sheet.CurrentHitPoints = sheet.CurrentHitPoints is { } hp ? Clamp(hp, 0, 9999) : null;
			sheet.TemporaryHitPoints = Clamp(sheet.TemporaryHitPoints, 0, 9999);
			sheet.MaxHitPointsAdjustment = Clamp(sheet.MaxHitPointsAdjustment, -999, 999);
			sheet.ArmorClassAdjustment = Clamp(sheet.ArmorClassAdjustment, -20, 20);
			sheet.SpeedAdjustment = Clamp(sheet.SpeedAdjustment, -100, 200);
			sheet.InitiativeAdjustment = Clamp(sheet.InitiativeAdjustment, -20, 20);
			sheet.HitDiceSpent = (sheet.HitDiceSpent ?? new()).Where(p => p.Key is 6 or 8 or 10 or 12).ToDictionary(p => p.Key, p => Clamp(p.Value, 0, 20));
			sheet.DeathSaveSuccesses = Clamp(sheet.DeathSaveSuccesses, 0, 3);
			sheet.DeathSaveFailures = Clamp(sheet.DeathSaveFailures, 0, 3);
			sheet.Conditions = (sheet.Conditions ?? new()).Where(c => !string.IsNullOrWhiteSpace(c)).Select(c => c.Length > 60 ? c[..60] : c).Distinct().Take(30).ToList();
			sheet.Exhaustion = Clamp(sheet.Exhaustion, 0, 10);
			sheet.SpentSlots = (sheet.SpentSlots ?? new()).Take(9).Select(s => Clamp(s, 0, 9)).ToList();
			sheet.SpentPactSlots = Clamp(sheet.SpentPactSlots, 0, 9);
			sheet.Inventory = (sheet.Inventory ?? new()).Take(300).Select(i =>
			{
				i.Name = Text(i.Name, 150);
				i.Notes = Text(i.Notes, 500);
				i.Quantity = Clamp(i.Quantity, 0, 99999);
				i.Magic = SanitizeMagic(i.Magic);
				if (i.Attuned && i.Magic?.RequiresAttunement != true)
				{
					i.Attuned = false;
				}
				return i;
			}).Where(i => i.EquipmentId is not null || !string.IsNullOrWhiteSpace(i.Name)).ToList();
			sheet.Coins ??= new CoinPurse();
			sheet.Coins.Cp = Clamp(sheet.Coins.Cp, 0, 9_999_999);
			sheet.Coins.Sp = Clamp(sheet.Coins.Sp, 0, 9_999_999);
			sheet.Coins.Ep = Clamp(sheet.Coins.Ep, 0, 9_999_999);
			sheet.Coins.Gp = Clamp(sheet.Coins.Gp, 0, 9_999_999);
			sheet.Coins.Pp = Clamp(sheet.Coins.Pp, 0, 9_999_999);
			sheet.Resources = (sheet.Resources ?? new()).Take(40).Select(r =>
			{
				r.Name = Text(r.Name, 80) ?? string.Empty;
				r.Maximum = Clamp(r.Maximum, 0, 999);
				r.Used = Clamp(r.Used, 0, r.Maximum);
				return r;
			}).ToList();
			sheet.ResourceUses = (sheet.ResourceUses ?? new())
				.Where(u => !string.IsNullOrWhiteSpace(u.Key) && u.Key.Length <= 40)
				.Take(40)
				.ToDictionary(u => u.Key, u => Clamp(u.Value, 0, 999));
			sheet.SpellChanges = (sheet.SpellChanges ?? new())
				.Where(g => Enum.IsDefined(g.Kind))
				.Take(40)
				.Select(g =>
				{
					g.Remaining = Clamp(g.Remaining, 0, 20);
					return g;
				}).ToList();
			sheet.ClassLevelsSeen = (sheet.ClassLevelsSeen ?? new())
				.Where(l => !string.IsNullOrWhiteSpace(l.Key) && l.Key.Length <= 40)
				.Take(20)
				.ToDictionary(l => l.Key, l => Clamp(l.Value, 0, 20));
			sheet.Experience = Clamp(sheet.Experience, 0, 10_000_000);
			sheet.Portrait = sheet.Portrait is { Length: <= MaxPortraitLength } portrait && portrait.StartsWith("data:image/", StringComparison.Ordinal) ? portrait : null;
			sheet.Age = Text(sheet.Age, 40);
			sheet.Gender = Text(sheet.Gender, 40);
			sheet.Faith = Text(sheet.Faith, 80);
			sheet.Height = Text(sheet.Height, 40);
			sheet.Weight = Text(sheet.Weight, 40);
			sheet.Traits = Text(sheet.Traits);
			sheet.Ideals = Text(sheet.Ideals);
			sheet.Bonds = Text(sheet.Bonds);
			sheet.Flaws = Text(sheet.Flaws);
			sheet.Appearance = Text(sheet.Appearance);
			sheet.Backstory = Text(sheet.Backstory, 20000);
			sheet.Allies = Text(sheet.Allies);
			sheet.Notes = Text(sheet.Notes, 20000);
			sheet.OtherProficiencies = Text(sheet.OtherProficiencies, 2000);
			sheet.FeatureNotes = Text(sheet.FeatureNotes);
			sheet.ExtraSkills = (sheet.ExtraSkills ?? new()).Where(s => Enum.IsDefined(s)).Distinct().ToList();
			sheet.ExtraExpertise = (sheet.ExtraExpertise ?? new()).Where(s => Enum.IsDefined(s)).Distinct().ToList();
			sheet.ExtraSaves = (sheet.ExtraSaves ?? new()).Where(a => Enum.IsDefined(a)).Distinct().ToList();
			return sheet;
		}
	}
}
