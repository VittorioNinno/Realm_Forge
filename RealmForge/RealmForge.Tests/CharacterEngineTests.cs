using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Pdf;
using RealmForge.Shared.Text;

namespace RealmForge.Tests;

///	<summary>
///	The character rules engine shared by the wizard, the sheet and the API: equipment that means the same in both
///	languages, the content keys the rules rely on, multiclassing, levels, spell slots, languages and the PDF.
///	</summary>
public class CharacterEngineTests
{
	private static readonly IReadOnlyList<CharacterClass> Classes = ClassSeeder.GetClassDefinitions();
	private static readonly IReadOnlyList<Background> Backgrounds = BackgroundSeeder.GetDefinitions();
	private static readonly IReadOnlyList<Feat> Feats = FeatSeeder.GetDefinitions();

	// ===== Starting equipment in both languages =====

	[Fact]
	public void Every_class_loadout_has_the_same_choices_in_English_and_Italian()
	{
		foreach (var cls in Classes)
		{
			var en = EquipmentLoadout.FromClassText(cls.Translations.Single(t => t.Language == LanguageCode.En).StartingEquipment);
			var it = EquipmentLoadout.FromClassText(cls.Translations.Single(t => t.Language == LanguageCode.It).StartingEquipment);
			Assert.False(en.IsEmpty, $"{cls.Ruleset} {BaseClassKeys.Of(cls.Id, cls.Ruleset)} has no starting equipment");
			Assert.True(CharacterTextRules.SameShape(en, it), $"{cls.Ruleset} {BaseClassKeys.Of(cls.Id, cls.Ruleset)}: the Italian equipment does not match the English one");
		}
	}

	[Fact]
	public void Every_background_loadout_has_the_same_items_in_English_and_Italian()
	{
		foreach (var background in Backgrounds)
		{
			var gold = background.EquipmentGoldAlternative;
			var en = EquipmentLoadout.FromBackground(background.Translations.Single(t => t.Language == LanguageCode.En).Equipment, gold is null ? null : $"{gold} GP");
			var it = EquipmentLoadout.FromBackground(background.Translations.Single(t => t.Language == LanguageCode.It).Equipment, gold is null ? null : $"{gold} mo");
			Assert.True(CharacterTextRules.SameShape(en, it), $"{background.Ruleset} {BaseContentKeys.Of(background.Id)}: the Italian equipment does not match the English one");
		}
	}

	[Fact]
	public void Loadout_choices_follow_the_English_structure_with_localized_labels()
	{
		var fighter = Classes.Single(c => c.Ruleset == RulesetVersion.Dnd5e_2014 && BaseClassKeys.Of(c.Id, c.Ruleset) == "fighter");
		var en = fighter.Translations.Single(t => t.Language == LanguageCode.En).StartingEquipment;
		var it = fighter.Translations.Single(t => t.Language == LanguageCode.It).StartingEquipment;
		var loadout = CharacterTextRules.Loadout(en, it, false, null, LanguageCode.It, _ => null);

		Assert.Equal(4, loadout.Rows.Count);
		Assert.All(loadout.Rows, r => Assert.Equal(new[] { "a", "b" }, r.Options.Select(o => o.Letter)));

		//	"(b) two martial weapons" is a generic pick of two martial weapons
		var picks = loadout.Rows.SelectMany(r => r.Options).SelectMany(o => o.Items).Where(i => i.Pick is not null).ToList();
		Assert.Contains(picks, p => p.Pick!.Kind == LoadoutPickKind.MartialWeapon && p.Pick.Count == 2);
		Assert.DoesNotContain(loadout.Rows.SelectMany(r => r.Options).SelectMany(o => o.Items), i => i.Label.Contains("martial", StringComparison.OrdinalIgnoreCase));
	}

	[Fact]
	public void Background_coins_become_an_amount_of_gold()
	{
		var sage = Backgrounds.Single(b => b.Ruleset == RulesetVersion.Dnd5e_2024 && BaseContentKeys.Of(b.Id) == "sage");
		var loadout = CharacterTextRules.Loadout(sage.Translations.Single(t => t.Language == LanguageCode.En).Equipment, null, true, sage.EquipmentGoldAlternative, LanguageCode.En, _ => null);

		Assert.Equal(new[] { "A", "B" }, loadout.Kits.Select(k => k.Letter));
		Assert.Equal(sage.EquipmentGoldAlternative, loadout.Kits[1].Items.Single().CoinAmount);
		Assert.Contains(loadout.Kits[0].Items, i => i.CoinAmount is > 0 && i.CoinType == CoinType.Gp);
	}

	// ===== Keys of the Base content =====

	[Theory]
	[InlineData("dwarf")]
	[InlineData("hill-dwarf")]
	[InlineData("mountain-dwarf")]
	[InlineData("high-elf")]
	[InlineData("half-elf")]
	[InlineData("half-orc")]
	[InlineData("variant-human")]
	[InlineData("standard-human")]
	[InlineData("lightfoot")]
	[InlineData("stout")]
	[InlineData("rock-gnome")]
	[InlineData("sage")]
	[InlineData("ability-score-improvement")]
	[InlineData("magic-initiate")]
	[InlineData("skill-expert")]
	[InlineData("keen-mind")]
	[InlineData("resilient")]
	[InlineData("tough")]
	[InlineData("alert")]
	[InlineData("linguist")]
	[InlineData("defense")]
	[InlineData("archery")]
	[InlineData("eldritch-knight")]
	[InlineData("arcane-trickster")]
	[InlineData("draconic-bloodline")]
	[InlineData("draconic-sorcery")]
	public void The_rules_find_the_Base_content_they_apply_to(string key) =>
		Assert.Contains(key, BaseContentKeys.All.Values);

	[Fact]
	public void Feat_increases_are_read_from_the_English_texts()
	{
		var general2024 = Feats.Where(f => f.Ruleset == RulesetVersion.Dnd5e_2024 && f.Category is FeatCategory.General or FeatCategory.EpicBoon).ToList();
		Assert.NotEmpty(general2024);
		foreach (var feat in general2024)
		{
			var (abilities, maximum) = CharacterTextRules.FeatIncreases(feat.Translations.Single(t => t.Language == LanguageCode.En).Description);
			Assert.True(abilities.Count > 0, $"{BaseContentKeys.Of(feat.Id)}: no ability increase found");
			Assert.Equal(feat.Category == FeatCategory.EpicBoon ? 30 : 20, maximum);
		}

		var (none, _) = CharacterTextRules.FeatIncreases(Feats.Single(f => f.Ruleset == RulesetVersion.Dnd5e_2014 && BaseContentKeys.Of(f.Id) == "alert").Translations.Single(t => t.Language == LanguageCode.En).Description);
		Assert.Empty(none);
	}

	[Theory]
	[InlineData("Two of your choice", 2)]
	[InlineData("One of your choice", 1)]
	[InlineData("Common, Elvish", 0)]
	[InlineData(null, 0)]
	public void Background_languages_of_choice_are_counted(string? text, int expected) =>
		Assert.Equal(expected, CharacterTextRules.LanguageChoices(text));

	// ===== Languages =====

	[Fact]
	public void Language_tables_follow_each_Players_Handbook()
	{
		var l2014 = CharacterLanguages.All(RulesetVersion.Dnd5e_2014);
		var l2024 = CharacterLanguages.All(RulesetVersion.Dnd5e_2024);
		Assert.Equal(8, l2014.Count(l => l.Group == LanguageGroup.Standard));
		Assert.Equal(8, l2014.Count(l => l.Group == LanguageGroup.Exotic));
		Assert.Equal(10, l2024.Count(l => l.Group == LanguageGroup.Standard));
		Assert.Equal(9, l2024.Count(l => l.Group == LanguageGroup.Exotic));
		Assert.DoesNotContain(CharacterLanguages.Choosable(RulesetVersion.Dnd5e_2014), l => l.Key is "druidic" or "thieves-cant" or "common");
		Assert.Equal("Sottocomune", CharacterLanguages.Name(RulesetVersion.Dnd5e_2024, "undercommon", LanguageCode.It));
		Assert.Equal("Lingua dei Segni Comune", CharacterLanguages.Name(RulesetVersion.Dnd5e_2024, "common-sign-language", LanguageCode.It));
	}

	// ===== Calculator =====

	private static ContextClass Class(string key, int hitDie, CasterProgression caster = CasterProgression.None, AbilityScore? ability = null,
		SpellcastingClass? list = null, string? table = null, params AbilityScore[] primary) =>
		new(Guid.NewGuid(), key, key, hitDie, primary.ToList(), new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution }, 2,
			Enum.GetValues<Skill>().ToList(), caster, ability, list, 3, table, new List<ContextSubclass>(), ContextLoadout.Empty);

	private static CharacterContextDto Context(RulesetVersion ruleset, IEnumerable<ContextClass> classes, IEnumerable<ContextSpecies>? species = null) => new(
		ruleset,
		classes.ToList(),
		(species ?? new[] { new ContextSpecies(Guid.Parse("00000000-0000-0000-0000-0000000000a1"), "Human", null, new List<CreatureSize> { CreatureSize.Medium }, 30, new List<ContextSubspecies>()) }).ToList(),
		new List<ContextBackground> { new(Guid.Parse("00000000-0000-0000-0000-0000000000b1"), "Sage", "sage", new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Intelligence, AbilityScore.Wisdom }, new List<Skill> { Skill.Arcana, Skill.History }, null, 0, ContextLoadout.Empty) },
		new List<ContextFeat>(),
		new List<ContextSpell>(),
		new List<ContextItem>());

	private static CharacterInput Input(RulesetVersion ruleset, CharacterContextDto context, params (ContextClass Class, int Levels)[] levels)
	{
		var input = new CharacterInput
		{
			Name = "Test",
			Ruleset = ruleset,
			SpeciesId = context.Species[0].Id,
			SubspeciesId = context.Species[0].Subspecies.FirstOrDefault()?.Id,
			BackgroundId = context.Backgrounds[0].Id,
			Build = new CharacterBuild
			{
				BaseScores = new List<int> { 15, 14, 13, 12, 10, 8 },
				BonusMode = AbilityBonusMode.TwoAndOne,
				BonusChoices = ruleset == RulesetVersion.Dnd5e_2024 ? new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Constitution } : new List<AbilityScore>()
			}
		};
		foreach (var (cls, count) in levels)
		{
			input.Build.Classes.Add(new CharacterClassBuild { ClassId = cls.Id });
			for (var i = 0; i < count; i++)
			{
				input.Build.Levels.Add(new CharacterLevelBuild { ClassId = cls.Id });
			}
		}
		return input;
	}

	[Fact]
	public void Multiclassing_needs_13_in_the_primary_abilities_of_both_classes()
	{
		var fighter = Class("fighter", 10, primary: new[] { AbilityScore.Strength });
		var wizard = Class("wizard", 6, CasterProgression.Full, AbilityScore.Intelligence, SpellcastingClass.Wizard, primary: new[] { AbilityScore.Intelligence });
		var context = Context(RulesetVersion.Dnd5e_2024, new[] { fighter, wizard });

		//	Str 15, Int 12 + 2 = 14: both at least 13
		var allowed = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, (fighter, 1), (wizard, 1)), context);
		Assert.DoesNotContain(allowed.Issues, i => i.Code == IssueCodes.Multiclass);

		var input = Input(RulesetVersion.Dnd5e_2024, context, (fighter, 1), (wizard, 1));
		input.Build.BonusChoices = new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Constitution };
		var refused = CharacterCalculator.Compute(input, context);
		Assert.Contains(refused.Issues, i => i.Code == IssueCodes.Multiclass && i.Blocking);
	}

	[Fact]
	public void Hit_points_add_the_full_first_die_then_fixed_or_rolled_values()
	{
		var fighter = Class("fighter", 10, primary: new[] { AbilityScore.Strength });
		var context = Context(RulesetVersion.Dnd5e_2024, new[] { fighter });
		var input = Input(RulesetVersion.Dnd5e_2024, context, (fighter, 3));
		input.Build.Levels[2].HitPointRoll = 2;

		//	Con 13 + 1 = 14 (+2): 10 + 2, then 6 + 2 fixed, then 2 + 2 rolled
		var computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(12 + 8 + 4, computed.MaxHitPoints);
		Assert.Equal(new[] { (10, 3) }, computed.HitDice);

		input.Build.Levels[1].HitPointRoll = 11;
		Assert.Contains(CharacterCalculator.Compute(input, context).Issues, i => i.Code == IssueCodes.HitPointRoll);
	}

	[Fact]
	public void Ability_Score_Improvement_levels_open_a_choice_and_raise_the_scores()
	{
		var fighter = Class("fighter", 10, primary: new[] { AbilityScore.Strength });
		var context = Context(RulesetVersion.Dnd5e_2014, new[] { fighter });
		var input = Input(RulesetVersion.Dnd5e_2014, context, (fighter, 6));

		var computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(new[] { 4, 6 }, computed.Plan.Where(p => p.Improvement).Select(p => p.ClassLevel));
		Assert.Contains(computed.Issues, i => i.Code == IssueCodes.ImprovementMissing && !i.Blocking);

		input.Build.Levels[3].Increases = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Strength };
		input.Build.Levels[5].Increases = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution };
		computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(18, computed.Score(AbilityScore.Strength));
		Assert.Equal(14, computed.Score(AbilityScore.Constitution));
		Assert.DoesNotContain(computed.Issues, i => i.Code is IssueCodes.ImprovementMissing or IssueCodes.Improvement);
	}

	[Fact]
	public void Multiclass_spellcasters_share_the_slots_of_the_combined_caster_level()
	{
		var wizard = Class("wizard", 6, CasterProgression.Full, AbilityScore.Intelligence, SpellcastingClass.Wizard, primary: new[] { AbilityScore.Intelligence });
		var paladin = Class("paladin", 10, CasterProgression.Half, AbilityScore.Charisma, SpellcastingClass.Paladin, primary: new[] { AbilityScore.Strength, AbilityScore.Charisma });

		//	Wizard 3 + paladin 3: 2024 rounds the half caster up (3 + 2 = 5), 2014 down (3 + 1 = 4)
		var context2024 = Context(RulesetVersion.Dnd5e_2024, new[] { wizard, paladin });
		var c2024 = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context2024, (wizard, 3), (paladin, 3)), context2024);
		Assert.Equal(new[] { 4, 3, 2, 0, 0, 0, 0, 0, 0 }, c2024.SpellSlots);

		var context2014 = Context(RulesetVersion.Dnd5e_2014, new[] { wizard, paladin });
		var c2014 = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2014, context2014, (wizard, 3), (paladin, 3)), context2014);
		Assert.Equal(new[] { 4, 3, 0, 0, 0, 0, 0, 0, 0 }, c2014.SpellSlots);

		//	A single class uses its own progression: paladin 5 alone has the slots of a level 3 caster
		var alone = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context2024, (paladin, 5)), context2024);
		Assert.Equal(new[] { 4, 2, 0, 0, 0, 0, 0, 0, 0 }, alone.SpellSlots);
	}

	[Fact]
	public void Warlock_pact_slots_are_separate()
	{
		Assert.Equal((2, 3), CharacterRules.PactSlots(5));
		Assert.Equal((4, 5), CharacterRules.PactSlots(17));
		Assert.Equal((1, 1), CharacterRules.PactSlots(1));
	}

	[Fact]
	public void Races_of_2014_give_their_increases_and_languages()
	{
		var elfId = Guid.Parse("00000000-0000-0000-0000-0000000000e1");
		var highElf = new ContextSubspecies(Guid.Parse("00000000-0000-0000-0000-0000000000e2"), "High elf", "high-elf", null);
		var elf = new ContextSpecies(elfId, "Elf", "elf", new List<CreatureSize> { CreatureSize.Medium }, 30, new List<ContextSubspecies> { highElf });
		var wizard = Class("wizard", 6, CasterProgression.Full, AbilityScore.Intelligence, SpellcastingClass.Wizard, primary: new[] { AbilityScore.Intelligence });
		var context = Context(RulesetVersion.Dnd5e_2014, new[] { wizard }, new[] { elf });

		var computed = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2014, context, (wizard, 1)), context);
		Assert.Equal(new[] { 0, 2, 0, 1, 0, 0 }, computed.OriginBonuses);
		Assert.Equal(new[] { "common", "elvish" }, computed.FixedLanguages);
		Assert.Equal(1, computed.LanguageChoices);
		Assert.Contains(Skill.Perception, computed.SkillProficiencies);
		Assert.Contains(computed.Spellcasting, s => s.Source == "species" && s.Cantrips == 1);
	}

	[Fact]
	public void Armor_from_the_inventory_sets_the_Armor_Class()
	{
		var fighter = Class("fighter", 10, primary: new[] { AbilityScore.Strength });
		var chain = new ContextItem(Guid.NewGuid(), "Chain Mail", "Chain Mail", EquipmentCategory.Armor, null, null, new List<WeaponProperty>(), null, null, null, null, null, null,
			ArmorCategory.Heavy, 16, false, null, 13, true, null, 55, 7500);
		var shield = new ContextItem(Guid.NewGuid(), "Shield", "Shield", EquipmentCategory.Armor, null, null, new List<WeaponProperty>(), null, null, null, null, null, null,
			ArmorCategory.Shield, 2, false, null, null, false, null, 6, 1000);
		var context = Context(RulesetVersion.Dnd5e_2024, new[] { fighter }) with { Items = new List<ContextItem> { chain, shield } };
		var input = Input(RulesetVersion.Dnd5e_2024, context, (fighter, 1));
		input.Sheet.Inventory.Add(new InventoryItem { EquipmentId = chain.Id, Equipped = true });
		input.Sheet.Inventory.Add(new InventoryItem { EquipmentId = shield.Id, Equipped = true });

		var computed = CharacterCalculator.Compute(input, context);
		Assert.Equal(18, computed.ArmorClass);
		Assert.Equal(30, computed.Speed);

		input.Sheet.Inventory[0].Equipped = false;
		Assert.Equal(10 + 2 + 2, CharacterCalculator.Compute(input, context).ArmorClass);
	}

	// ===== PDF =====

	[Fact]
	public void The_character_PDF_is_a_valid_document_with_Italian_text()
	{
		var data = new CharacterPdfData
		{
			Name = "Brünhilde l'Intrepida",
			LevelBadge = "Livello 5",
			Origin = "Nana delle colline",
			Classes = "Guerriera 5 (Campionessa)",
			Meta = { new PdfField("Background", "Soldato"), new PdfField("Allineamento", "Legale buono"), new PdfField("Taglia", "Media") },
			Vitals = { new PdfField("Classe Armatura", "18"), new PdfField("Punti ferita", "44 / 44") },
			Abilities = { new PdfAbility("Forza", 18, "+4", "TS +7", true) },
			Status = "Condizioni: Prono",
			SkillsTitle = "Abilità",
			Skills = { new PdfSkill("Atletica", "FOR", "+7", true), new PdfSkill("Storia", "INT", "+0", false) },
			AttacksTitle = "Attacchi",
			AttackHeaders = { "Arma", "Bonus attacco", "Danni e tipo" },
			Attacks = { new PdfAttack("Spadone", "+7", "2d6+4 taglienti") },
			SpellsTitle = "Incantesimi",
			Proficiencies = new PdfInfoBox("Competenze e lingue", new() { new PdfLine("Lingue", "Comune, Nanico") }),
			Features = new PdfInfoBox("Privilegi e talenti", new() { new PdfLine("Guerriera 5", "Stile di combattimento, Recuperare energie") }),
			InventoryTitle = "Inventario",
			CoinsPill = "Monete: 25 mo",
			Items = Enumerable.Range(0, 120).Select(i => new PdfItem($"Oggetto {i}", i % 3 == 0 ? "Indossato" : null)).ToList(),
			NotesSubtitle = "Note, background e caratterizzazione",
			Personality = { new PdfNote("Tratti caratteriali", "Parla poco."), new PdfNote("Ideali", "Onore.") },
			Notes = { new PdfNote("Storia", string.Join("\n", Enumerable.Range(0, 120).Select(i => $"Riga {i}: è già più facile così"))) },
			Footer = "Scheda generata da RealmForge",
			PageFormat = "Pagina {0} / {1}"
		};

		var bytes = CharacterPdf.Create(data);
		var text = System.Text.Encoding.Latin1.GetString(bytes);
		Assert.StartsWith("%PDF-1.4", text);
		Assert.EndsWith("%%EOF\n", text);
		//	The inventory goes on to a second page, the long story takes more than one
		var pages = int.Parse(System.Text.RegularExpressions.Regex.Match(text, @"/Count (\d+)").Groups[1].Value);
		Assert.InRange(pages, 4, 8);
		Assert.Contains($"Pagina {pages} / {pages}", text);
		Assert.Contains("BRÜNHILDE L'INTREPIDA", text);
		Assert.Contains("/WinAnsiEncoding", text);
	}
	// ===== Magic items =====

	private static InventoryItem Magic(bool attunement, bool attuned, params MagicEffect[] effects) => new()
	{
		Name = "Item",
		Equipped = true,
		Attuned = attuned,
		Magic = new MagicItemProperties { RequiresAttunement = attunement, Effects = effects.ToList() }
	};

	[Fact]
	public void Magic_items_work_only_when_worn_and_attuned()
	{
		var fighter = Class("fighter", 10, primary: new[] { AbilityScore.Strength });
		var context = Context(RulesetVersion.Dnd5e_2024, new[] { fighter });
		var plain = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, (fighter, 1)), context);

		var ring = Magic(true, true, new MagicEffect { Kind = MagicEffectKind.ArmorClass, Value = 1 }, new MagicEffect { Kind = MagicEffectKind.SavingThrows, Value = 1 });
		var gauntlets = Magic(true, true, new MagicEffect { Kind = MagicEffectKind.SetAbilityScore, Value = 19, Ability = AbilityScore.Strength });
		var input = Input(RulesetVersion.Dnd5e_2024, context, (fighter, 1));
		input.Sheet.Inventory.AddRange(new[] { ring, gauntlets });
		var magic = CharacterCalculator.Compute(input, context);

		Assert.Equal(plain.ArmorClass + 1, magic.ArmorClass);
		Assert.Equal(plain.SaveBonus(AbilityScore.Wisdom) + 1, magic.SaveBonus(AbilityScore.Wisdom));
		Assert.Equal(19, magic.Score(AbilityScore.Strength));

		//	Not attuned or not worn: nothing
		ring.Attuned = false;
		gauntlets.Equipped = false;
		var off = CharacterCalculator.Compute(input, context);
		Assert.Equal(plain.ArmorClass, off.ArmorClass);
		Assert.Equal(plain.Score(AbilityScore.Strength), off.Score(AbilityScore.Strength));
	}

	// ===== Spellbook and spell changes =====

	[Fact]
	public void The_wizard_prepares_spells_from_a_spellbook_of_six_free_spells_plus_the_copied_ones()
	{
		var wizard = Class("wizard", 6, CasterProgression.Full, AbilityScore.Intelligence, SpellcastingClass.Wizard, primary: new[] { AbilityScore.Intelligence });
		var spells = Enumerable.Range(1, 9)
			.Select(i => new ContextSpell(Guid.NewGuid(), $"Spell {i}", 1, SpellSchool.Evocation, new List<SpellcastingClass> { SpellcastingClass.Wizard }, false, false))
			.ToList();
		var context = Context(RulesetVersion.Dnd5e_2024, new[] { wizard }) with { Spells = spells };
		CharacterInput Wizard(IEnumerable<ContextSpell> book, IEnumerable<ContextSpell> prepared, IEnumerable<ContextSpell>? copied = null)
		{
			var input = Input(RulesetVersion.Dnd5e_2024, context, (wizard, 1));
			input.Build.Classes[0].Spellbook = book.Select(s => s.Id).ToList();
			input.Build.Classes[0].Spells = prepared.Select(s => s.Id).ToList();
			input.Build.Classes[0].SpellbookCopied = (copied ?? Array.Empty<ContextSpell>()).Select(s => s.Id).ToList();
			return input;
		}
		bool SpellError(CharacterInput input) => CharacterCalculator.Compute(input, context).Issues.Any(i => i.Code == IssueCodes.Spells);

		Assert.False(SpellError(Wizard(spells.Take(6), spells.Take(2))));
		Assert.True(SpellError(Wizard(spells.Take(6), new[] { spells[7] })));
		Assert.True(SpellError(Wizard(spells.Take(7), spells.Take(2))));
		Assert.False(SpellError(Wizard(spells.Take(8), spells.Take(2), spells.Skip(6).Take(2))));
	}

	[Theory]
	[InlineData(RulesetVersion.Dnd5e_2014, "cleric", SpellChangeKind.All, false, false)]
	[InlineData(RulesetVersion.Dnd5e_2014, "sorcerer", null, true, false)]
	[InlineData(RulesetVersion.Dnd5e_2024, "paladin", SpellChangeKind.Spell, false, false)]
	[InlineData(RulesetVersion.Dnd5e_2024, "bard", null, true, true)]
	[InlineData(RulesetVersion.Dnd5e_2024, "druid", SpellChangeKind.All, false, true)]
	public void Classes_change_their_spells_as_the_rules_say(RulesetVersion ruleset, string key, SpellChangeKind? longRest, bool levelSpell, bool levelCantrip)
	{
		var rule = SpellChangeRules.For(ruleset, key, false);
		Assert.Equal(longRest, rule.LongRest);
		Assert.Equal(levelSpell, rule.LevelUpSpell);
		Assert.Equal(levelCantrip, rule.LevelUpCantrip);
		Assert.True(SpellChangeRules.For(RulesetVersion.Dnd5e_2024, "wizard", false) is { Spellbook: true, LongRestCantrip: true });
		Assert.Equal(12, SpellChangeRules.FreeSpellbookSpells(4));
	}
}
