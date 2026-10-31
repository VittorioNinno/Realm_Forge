using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Characters;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Identity;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Player characters of the signed-in user. Every save is checked by <see cref="CharacterCalculator"/> against the
	///	compendium of the edition (the same rules the wizard runs); the play state of the sheet is saved on its own.
	///	The owner changes them, and so do the masters and co-masters of the campaigns the character takes part in (the
	///	change goes to the character itself); the owner can also share a character with other accounts, who read the
	///	sheet without changing it. The rules are always checked with the compendium the owner sees.
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
		private readonly UserManager<ApplicationUser> _users;

		public const int MaxSharesPerCharacter = 20;

		public CharactersController(RealmForgeDbContext context, CharacterContextBuilder builder, UserManager<ApplicationUser> users)
		{
			_context = context;
			_builder = builder;
			_users = users;
		}

		private string UserId => ContentAccess.GetUserId(User) ?? string.Empty;

		//	Characters of the campaigns I run as master or co-master
		private IQueryable<Guid> RunByMe => _context.CampaignCharacters
			.Where(cc => _context.CampaignMembers.Any(m => m.CampaignId == cc.CampaignId && m.UserId == UserId
				&& (m.Role == CampaignRole.Master || m.Role == CampaignRole.CoMaster)))
			.Select(cc => cc.CharacterId);

		//	The owner of a character as a principal: its rules are checked with the compendium they see
		private static ClaimsPrincipal Owner(string ownerId) =>
			new(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, ownerId) }, "character-owner"));

		//	GET: api/characters/context?ruleset=2&lang=2 — the rules data of an edition (also for visitors)
		[HttpGet("context")]
		[AllowAnonymous]
		public async Task<ActionResult<CharacterContextDto>> GetContext([FromQuery] RulesetVersion ruleset = RulesetVersion.Dnd5e_2024, [FromQuery] LanguageCode lang = LanguageCode.It,
			[FromQuery] Guid? character = null)
		{
			if (!Enum.IsDefined(ruleset))
			{
				return BadRequest();
			}

			//	A shared character is read with the compendium its owner sees (their Homebrew included)
			if (character is { } characterId)
			{
				var owner = await _context.Characters.AsNoTracking()
					.Where(c => c.Id == characterId && (c.OwnerId == UserId || _context.CharacterShares.Any(s => s.CharacterId == c.Id && s.UserId == UserId)
						|| RunByMe.Contains(c.Id)))
					.Select(c => c.OwnerId)
					.FirstOrDefaultAsync();
				if (owner is null || UserId.Length == 0)
				{
					return NotFound();
				}
				return Ok(await _builder.BuildAsync(ruleset, lang, Owner(owner)));
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
			var summaries = await SummariesAsync(characters, lang);

			//	The campaigns of each character, so that the list can take it out of one
			var ids = characters.Select(c => c.Id).ToList();
			var tables = await _context.CampaignCharacters.AsNoTracking()
				.Where(cc => ids.Contains(cc.CharacterId))
				.Select(cc => new { cc.CharacterId, cc.CampaignId, cc.Campaign.Name })
				.ToListAsync();
			return Ok(summaries.Select(s => s with
			{
				Campaigns = tables.Where(t => t.CharacterId == s.Id).OrderBy(t => t.Name).Select(t => new CharacterCampaignRefDto(t.CampaignId, t.Name)).ToList()
			}).ToList());
		}

		//	GET: api/characters/shared?lang=2 — characters other players shared with me
		[HttpGet("shared")]
		public async Task<ActionResult<List<SharedCharacterDto>>> GetShared([FromQuery] LanguageCode lang = LanguageCode.It)
		{
			var characters = await _context.Characters.AsNoTracking()
				.Include(c => c.Species).ThenInclude(s => s.Translations)
				.Include(c => c.Background).ThenInclude(b => b.Translations)
				.Where(c => _context.CharacterShares.Any(s => s.CharacterId == c.Id && s.UserId == UserId))
				.OrderByDescending(c => c.UpdatedAt)
				.ToListAsync();
			var ownerIds = characters.Select(c => c.OwnerId).Distinct().ToList();
			var owners = await PublicNames.LoadAsync(_context, ownerIds);
			var summaries = await SummariesAsync(characters, lang);
			return Ok(summaries.Select((summary, i) => new SharedCharacterDto(summary, owners.GetValueOrDefault(characters[i].OwnerId, string.Empty))).ToList());
		}

		//	GET: api/characters/{id}/shares — the accounts the owner shared the character with
		[HttpGet("{id:guid}/shares")]
		public async Task<ActionResult<List<ShareUserDto>>> GetShares(Guid id)
		{
			if (!await _context.Characters.AnyAsync(c => c.Id == id && c.OwnerId == UserId))
			{
				return NotFound();
			}
			var ids = await _context.CharacterShares.AsNoTracking().Where(s => s.CharacterId == id).Select(s => s.UserId).ToListAsync();
			var users = await _context.Users.AsNoTracking().Where(u => ids.Contains(u.Id)).Select(u => new { u.Id, u.Email }).ToListAsync();
			return Ok(users.Select(u => new ShareUserDto(u.Id, u.Email ?? string.Empty)).OrderBy(u => u.Email).ToList());
		}

		//	POST: api/characters/{id}/shares — share the sheet (read-only) with an account by e-mail
		[HttpPost("{id:guid}/shares")]
		public async Task<ActionResult<ShareUserDto>> Share(Guid id, [FromBody] ShareRequestDto request)
		{
			if (!await _context.Characters.AnyAsync(c => c.Id == id && c.OwnerId == UserId))
			{
				return NotFound();
			}
			var address = request.Email?.Trim();
			if (string.IsNullOrEmpty(address) || address.Length > 256 || !address.Contains('@'))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid e-mail address.");
			}
			var target = await _users.FindByEmailAsync(address);
			if (target is null)
			{
				return Problem(statusCode: StatusCodes.Status404NotFound, title: "No account with this e-mail address.");
			}
			if (target.Id == UserId)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "You cannot share with yourself.");
			}
			if (!await _context.CharacterShares.AnyAsync(s => s.CharacterId == id && s.UserId == target.Id))
			{
				if (await _context.CharacterShares.CountAsync(s => s.CharacterId == id) >= MaxSharesPerCharacter)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxSharesPerCharacter} people per character.");
				}
				_context.CharacterShares.Add(new CharacterShare { CharacterId = id, UserId = target.Id });
				await _context.SaveChangesAsync();
			}
			return Ok(new ShareUserDto(target.Id, target.Email ?? string.Empty));
		}

		//	DELETE: api/characters/{id}/shares/{userId} — the owner removes a person, or a person stops following ("me")
		[HttpDelete("{id:guid}/shares/{userId}")]
		public async Task<IActionResult> Unshare(Guid id, string userId)
		{
			var target = userId == "me" ? UserId : userId;
			var share = await _context.CharacterShares.FirstOrDefaultAsync(s => s.CharacterId == id && s.UserId == target);
			if (share is null || (target != UserId && !await _context.Characters.AnyAsync(c => c.Id == id && c.OwnerId == UserId)))
			{
				return NotFound();
			}
			_context.CharacterShares.Remove(share);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private Task<List<CharacterSummaryDto>> SummariesAsync(List<Character> characters, LanguageCode lang) => SummariesAsync(_context, characters, lang);

		//	Characters loaded with their species and background translations
		internal static async Task<List<CharacterSummaryDto>> SummariesAsync(RealmForgeDbContext db, List<Character> characters, LanguageCode lang)
		{
			var builds = characters.ToDictionary(c => c.Id, c => ReadBuild(c.Build));
			var classIds = builds.Values.SelectMany(b => b.Levels.Select(l => l.ClassId)).Distinct().ToList();
			var classNames = await db.ClassTranslations.AsNoTracking()
				.Where(t => classIds.Contains(t.CharacterClassId))
				.ToListAsync();

			//	One class: its name (the level is shown apart); more classes: each with its levels
			string ClassLine(CharacterBuild build)
			{
				var groups = build.Levels.GroupBy(l => l.ClassId).ToList();
				string Name(Guid id) => classNames.Where(t => t.CharacterClassId == id).Localize(lang)?.Name ?? string.Empty;
				return groups.Count == 1
					? Name(groups[0].Key)
					: string.Join(" / ", groups.Select(g => $"{Name(g.Key)} {g.Count()}"));
			}

			return characters.Select(c =>
			{
				var sheet = ReadSheet(c.Sheet);
				return new CharacterSummaryDto(
					c.Id, c.Name, c.Ruleset, c.Level,
					c.Species.Translations.Localize(lang)?.Name ?? string.Empty,
					ClassLine(builds[c.Id]),
					c.Background.Translations.Localize(lang)?.Name ?? string.Empty,
					c.MaxHitPoints, Math.Clamp(sheet.CurrentHitPoints ?? c.MaxHitPoints, 0, c.MaxHitPoints), c.ArmorClass, c.UpdatedAt)
				{
					Portrait = sheet.Portrait,
					PortraitX = sheet.PortraitX,
					PortraitY = sheet.PortraitY,
					BackgroundId = c.BackgroundId
				};
			}).ToList();
		}

		//	GET: api/characters/{id}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<CharacterDto>> GetCharacter(Guid id)
		{
			var character = await _context.Characters.AsNoTracking()
				.FirstOrDefaultAsync(c => c.Id == id && (c.OwnerId == UserId || _context.CharacterShares.Any(s => s.CharacterId == c.Id && s.UserId == UserId)
					|| RunByMe.Contains(c.Id)));
			if (character is null)
			{
				return NotFound();
			}
			var isOwner = character.OwnerId == UserId;
			var canEdit = isOwner || await RunByMe.ContainsAsync(character.Id);
			var people = new[] { character.OwnerId, character.UpdatedById }.OfType<string>().Distinct().ToList();
			var names = await PublicNames.LoadAsync(_context, people);
			var campaigns = canEdit
				? await _context.CampaignCharacters.AsNoTracking().Where(cc => cc.CharacterId == character.Id).Select(cc => cc.CampaignId).ToListAsync()
				: null;
			return Ok(ToDto(character) with
			{
				ReadOnly = !canEdit,
				IsOwner = isOwner,
				OwnerName = isOwner ? null : names.GetValueOrDefault(character.OwnerId),
				//	Shown when the last change was made by someone else (the owner after a master, a master after the owner)
				LastEditedBy = character.UpdatedById is { } editor && editor != UserId ? names.GetValueOrDefault(editor) : null,
				Campaigns = campaigns
			});
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

			var character = new Character { OwnerId = UserId, UpdatedById = UserId };
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
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && (c.OwnerId == UserId || RunByMe.Contains(c.Id)));
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
			var context = await _builder.BuildAsync(dto.Ruleset, LanguageCode.En, Owner(character.OwnerId));
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
			character.UpdatedById = UserId;
			await _context.SaveChangesAsync();
			return Ok(ToDto(character) with { IsOwner = character.OwnerId == UserId });
		}

		//	PUT: api/characters/{id}/sheet — the play state (hit points, resources, inventory, notes)
		[HttpPut("{id:guid}/sheet")]
		public async Task<ActionResult<CharacterSavedDto>> UpdateSheet(Guid id, [FromBody] CharacterSheetState sheet)
		{
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && (c.OwnerId == UserId || RunByMe.Contains(c.Id)));
			if (character is null)
			{
				return NotFound();
			}

			sheet = Sanitize(sheet);

			//	A master changed hit points or conditions from an encounter after this copy of the sheet was read:
			//	those values win, and go back to the client with the answer
			var stored = ReadSheet(character.Sheet);
			var fromEncounter = sheet.VitalsStamp != stored.VitalsStamp;
			if (fromEncounter)
			{
				SheetVitalsDto.From(stored, character.MaxHitPoints, character.UpdatedAt).ApplyTo(sheet);
			}

			var build = ReadBuild(character.Build);
			var context = await _builder.BuildAsync(character.Ruleset, LanguageCode.En, Owner(character.OwnerId));
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
			character.UpdatedById = UserId;
			await _context.SaveChangesAsync();

			return Ok(new CharacterSavedDto(character.Id, character.MaxHitPoints, character.ArmorClass, character.UpdatedAt,
				fromEncounter ? SheetVitalsDto.From(sheet, character.MaxHitPoints, character.UpdatedAt) : null));
		}

		//	GET: api/characters/{id}/vitals — hit points and conditions, read often by an open sheet to follow the encounters
		[HttpGet("{id:guid}/vitals")]
		public async Task<ActionResult<SheetVitalsDto>> GetVitals(Guid id)
		{
			var character = await _context.Characters.AsNoTracking()
				.Where(c => c.Id == id && (c.OwnerId == UserId || _context.CharacterShares.Any(s => s.CharacterId == c.Id && s.UserId == UserId)
					|| RunByMe.Contains(c.Id)))
				.Select(c => new { c.Sheet, c.MaxHitPoints, c.UpdatedAt, c.UpdatedById })
				.FirstOrDefaultAsync();
			if (character is null)
			{
				return NotFound();
			}
			var names = character.UpdatedById is { } by ? await PublicNames.LoadAsync(_context, new[] { by }) : new Dictionary<string, string>();
			return Ok(SheetVitalsDto.From(ReadSheet(character.Sheet), character.MaxHitPoints, character.UpdatedAt,
				character.UpdatedById is { } who ? names.GetValueOrDefault(who) : null));
		}

		//	DELETE: api/characters/{id}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteCharacter(Guid id, [FromServices] TrashBin bin)
		{
			var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == UserId);
			if (character is null)
			{
				return NotFound();
			}

			//	Kept in the bin for a few days, to be restored
			await bin.AddAsync(character, "character", ContentAccess.GetUserId(User) ?? string.Empty, character.Id);
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
			sheet.PortraitX = sheet.PortraitX is { } px ? Math.Clamp(px, 0, 100) : null;
			sheet.PortraitY = sheet.PortraitY is { } py ? Math.Clamp(py, 0, 100) : null;
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
