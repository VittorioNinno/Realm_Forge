using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Localization;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Characters
{
	///	<summary>
	///	Builds the <see cref="CharacterContextDto"/> of an edition for a user: the content they can list (Base, public,
	///	their own), with the rules numbers, the keys of the Base content and the starting equipment as language-safe
	///	choices. The wizard reads it, and the API checks the characters against it.
	///	</summary>
	public class CharacterContextBuilder
	{
		private readonly RealmForgeDbContext _context;
		private readonly ContentAccess _access;
		private readonly ShareService _shares;

		public CharacterContextBuilder(RealmForgeDbContext context, ContentAccess access, ShareService shares)
		{
			_context = context;
			_access = access;
			_shares = shares;
		}

		///	<param name="campaignModules">Rule modules active in the campaigns of the character: read even when the user does
		///	not list them (a master's module shared with the table)</param>
		public async Task<CharacterContextDto> BuildAsync(RulesetVersion ruleset, LanguageCode lang, ClaimsPrincipal user, IReadOnlyCollection<Guid>? campaignModules = null)
		{
			var shared = await _shares.SharedWithAsync(user);
			var equipment = await ContentAccess.ListedFor(_context.Equipment.AsNoTracking().Include(e => e.Translations), user, shared)
				.Where(e => e.Ruleset == ruleset).ToListAsync();
			var matcher = new EquipmentNameMatcher(equipment
				.OrderByDescending(e => e.IsOfficialSRD)
				.Select(e => (e.Translations.Localize(LanguageCode.En)?.Name ?? string.Empty, e.Id)));

			var classes = await ContentAccess.ListedFor(_context.Classes.AsNoTracking()
					.Include(c => c.Translations)
					.Include(c => c.Subclasses).ThenInclude(s => s.Translations), user, shared)
				.Where(c => c.Ruleset == ruleset).ToListAsync();

			var species = await ContentAccess.ListedFor(_context.Species.AsNoTracking()
					.Include(s => s.Translations)
					.Include(s => s.Subspecies).ThenInclude(s => s.Translations), user, shared)
				.Where(s => s.Ruleset == ruleset).ToListAsync();

			var backgrounds = await ContentAccess.ListedFor(_context.Backgrounds.AsNoTracking().Include(b => b.Translations), user, shared)
				.Where(b => b.Ruleset == ruleset).ToListAsync();

			var feats = await ContentAccess.ListedFor(_context.Feats.AsNoTracking().Include(f => f.Translations), user, shared)
				.Where(f => f.Ruleset == ruleset).ToListAsync();

			var spells = await ContentAccess.ListedFor(_context.Spells.AsNoTracking().Include(s => s.Translations), user, shared)
				.Where(s => s.Ruleset == ruleset).ToListAsync();

			//	Modules hold for both editions
			var extra = campaignModules ?? Array.Empty<Guid>();
			var listed = ContentAccess.ListedFor(_context.RuleModules.AsNoTracking(), user, shared).Select(m => m.Id);
			var modules = await _context.RuleModules.AsNoTracking().Include(m => m.Translations)
				.Where(m => listed.Contains(m.Id) || extra.Contains(m.Id))
				.ToListAsync();
			var contextModules = modules
				.Select(m => new ContextModule(m.Id, m.Translations.Localize(lang)?.Name ?? string.Empty, RuleEffectJson.Read(m.Effects)))
				.OrderBy(m => m.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			//	Rule effects of the Homebrew class and subclass features, from the level of the feature (class level)
			var classIds = classes.Select(c => c.Id).Concat(classes.SelectMany(c => c.Subclasses).Select(x => x.Id)).ToList();
			var featureEffects = (await _context.ClassFeatures.AsNoTracking()
					.Where(f => !f.IsOfficialSRD && ((f.CharacterClassId != null && classIds.Contains(f.CharacterClassId.Value)) || (f.SubclassId != null && classIds.Contains(f.SubclassId.Value))))
					.Select(f => new { f.CharacterClassId, f.SubclassId, f.Level, f.Effects })
					.ToListAsync())
				.Select(f => (Owner: f.SubclassId ?? f.CharacterClassId!.Value, Effects: RuleEffectJson.Read(f.Effects).Select(e => { e.Level = Math.Max(e.Level, f.Level); return e; }).ToList()))
				.GroupBy(f => f.Owner)
				.ToDictionary(g => g.Key, g => g.SelectMany(f => f.Effects).ToList());
			List<RuleEffect>? FeatureEffects(Guid id) => featureEffects.TryGetValue(id, out var list) && list.Count > 0 ? list : null;
			static List<RuleEffect>? Effects(string json, bool isBase) => isBase ? null : RuleEffectJson.Read(json) is { Count: > 0 } list ? list : null;

			string? Key(Guid id, bool isBase) => isBase ? BaseContentKeys.Of(id) : null;

			var contextClasses = classes.Select(c =>
			{
				var en = c.Translations.Localize(LanguageCode.En);
				var local = c.Translations.Localize(lang);
				var key = c.IsOfficialSRD ? BaseClassKeys.Of(c.Id, ruleset) : null;
				return new ContextClass(
					c.Id, local?.Name ?? string.Empty, key, c.HitDie, c.PrimaryAbilities, c.SavingThrows, c.SkillChoiceCount, c.SkillOptions,
					c.CasterProgression, c.SpellcastingAbility, BaseClassKeys.SpellList(key), c.SubclassLevel, en?.ProgressionTable,
					c.Subclasses.Where(s => _access.IsListed(s, user, shared, c))
						.Select(s => new ContextSubclass(s.Id, s.Translations.Localize(lang)?.Name ?? string.Empty, Key(s.Id, s.IsOfficialSRD), s.CasterProgression, s.SpellcastingAbility, FeatureEffects(s.Id)))
						.OrderBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase)
						.ToList(),
					CharacterTextRules.Loadout(en?.StartingEquipment, local?.StartingEquipment, false, null, lang, matcher.Find),
					FeatureEffects(c.Id));
			}).OrderBy(c => c.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			var contextSpecies = species.Select(s => new ContextSpecies(
				s.Id, s.Translations.Localize(lang)?.Name ?? string.Empty, Key(s.Id, s.IsOfficialSRD), s.AllowedSizes, s.BaseSpeedInFeet,
				s.Subspecies.Where(x => _access.IsListed(x, user, shared, s))
					.Select(x => new ContextSubspecies(x.Id, x.Translations.Localize(lang)?.Name ?? string.Empty, Key(x.Id, x.IsOfficialSRD), x.BaseSpeedOverrideInFeet, Effects(x.Effects, x.IsOfficialSRD)))
					.OrderBy(x => x.Name, StringComparer.CurrentCultureIgnoreCase)
					.ToList(),
				Effects(s.Effects, s.IsOfficialSRD)))
				.OrderBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			var contextBackgrounds = backgrounds.Select(b =>
			{
				var en = b.Translations.Localize(LanguageCode.En);
				var local = b.Translations.Localize(lang);
				return new ContextBackground(
					b.Id, local?.Name ?? string.Empty, Key(b.Id, b.IsOfficialSRD), b.AbilityOptions, b.SkillProficiencies, b.OriginFeatId,
					CharacterTextRules.LanguageChoices(en?.Languages),
					CharacterTextRules.Loadout(en?.Equipment, local?.Equipment, true, b.EquipmentGoldAlternative, lang, matcher.Find));
			}).OrderBy(b => b.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			var contextFeats = feats.Select(f =>
			{
				var (increases, maximum) = CharacterTextRules.FeatIncreases(f.Translations.Localize(LanguageCode.En)?.Description);
				return new ContextFeat(
					f.Id, f.Translations.Localize(lang)?.Name ?? string.Empty, Key(f.Id, f.IsOfficialSRD), f.Category, f.PrerequisiteMinimumLevel,
					f.PrerequisiteAbilities, f.PrerequisiteMinimumScore, f.PrerequisiteFeature, increases, maximum, Effects(f.Effects, f.IsOfficialSRD));
			}).OrderBy(f => f.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			var contextSpells = spells
				.Select(s => new ContextSpell(s.Id, s.Translations.Localize(lang)?.Name ?? string.Empty, s.Level, s.School, s.Classes, s.Ritual, s.Concentration, Key(s.Id, s.IsOfficialSRD)))
				.OrderBy(s => s.Level).ThenBy(s => s.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			var contextItems = equipment.Select(e => new ContextItem(
					e.Id, e.Translations.Localize(lang)?.Name ?? string.Empty, e.Translations.Localize(LanguageCode.En)?.Name ?? string.Empty,
					e.Category, e.WeaponCategory, e.WeaponRange, e.WeaponProperties, e.DamageDice, e.DamageType, e.VersatileDamageDice,
					e.NormalRange, e.LongRange, e.Mastery, e.ArmorCategory, e.ArmorClass, e.ArmorAddsDexterity, e.ArmorMaxDexterityBonus,
					e.StrengthRequirement, e.StealthDisadvantage, e.ToolCategory, e.WeightInPounds, e.CostInCopper))
				.OrderBy(e => e.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

			return new CharacterContextDto(ruleset, contextClasses, contextSpecies, contextBackgrounds, contextFeats, contextSpells, contextItems, contextModules);
		}
	}
}
