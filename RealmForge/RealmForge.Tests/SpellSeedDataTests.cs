using System.Text.RegularExpressions;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Infrastructure.Persistence.Seeding.SpellsData;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;

namespace RealmForge.Tests;

public class SpellSeedDataTests
{
	private static readonly IReadOnlyList<Spell> Spells = SpellSeeder.GetDefinitions();

	private static SpellTranslation Tr(Spell spell, LanguageCode lang) => spell.Translations.Single(t => t.Language == lang);

	[Fact]
	public void All_2014_spells_are_seeded_with_the_SRD_ones_labelled()
	{
		//	Player's Handbook 2014: 361 spells, 319 of them in SRD 5.1; the others carry RealmForge text
		var spells2014 = Spells.Where(s => s.Ruleset == RulesetVersion.Dnd5e_2014).ToList();
		Assert.Equal(361, spells2014.Count);
		Assert.Equal(319, spells2014.Count(s => s.Source == ContentSource.Srd51));
		Assert.Equal(42, spells2014.Count(s => s.Source == ContentSource.RealmForge));
		Assert.All(Spells, s => Assert.True(s.IsOfficialSRD));
	}

	[Fact]
	public void All_2024_spells_are_seeded_with_the_SRD_ones_labelled()
	{
		//	Player's Handbook 2024: 391 spells, 339 of them in SRD 5.2; the others carry RealmForge text
		var spells2024 = Spells.Where(s => s.Ruleset == RulesetVersion.Dnd5e_2024).ToList();
		Assert.Equal(391, spells2024.Count);
		Assert.Equal(339, spells2024.Count(s => s.Source == ContentSource.Srd52));
		Assert.Equal(52, spells2024.Count(s => s.Source == ContentSource.RealmForge));
		Assert.Equal(34, spells2024.Count(s => s.Level == 0));
		Assert.Equal(new[] { RulesetVersion.Dnd5e_2014, RulesetVersion.Dnd5e_2024 }, Spells.Select(s => s.Ruleset).Distinct().OrderBy(r => r));
		//	SRD 5.1 text only on 2014 spells, SRD 5.2 text only on 2024 spells
		Assert.DoesNotContain(Spells, s => s.Source == ContentSource.Srd51 && s.Ruleset != RulesetVersion.Dnd5e_2014);
		Assert.DoesNotContain(Spells, s => s.Source == ContentSource.Srd52 && s.Ruleset != RulesetVersion.Dnd5e_2024);
	}

	[Fact]
	public void Spell_names_leave_out_the_named_wizards()
	{
		//	As in the SRDs: "Acid Arrow" / "Freccia Acida", not the version with the wizard's name
		var wizards = new[] { "Melf", "Bigby", "Tasha", "Otiluke", "Mordenkainen", "Leomund", "Tenser", "Evard", "Drawmij", "Otto", "Rary", "Nystul", "Jallarzi", "Yolande" };
		foreach (var tr in Spells.SelectMany(s => s.Translations))
		{
			Assert.DoesNotContain(wizards, w => tr.Name.Contains(w, StringComparison.Ordinal));
		}
	}

	[Fact]
	public void Rituals_2024_keep_the_flag_out_of_the_casting_time()
	{
		//	The 2024 stat line reads "Action or Ritual": the "or Ritual" part is the Ritual flag, shown by the subtitle
		foreach (var spell in Spells.Where(s => s.Ruleset == RulesetVersion.Dnd5e_2024))
		{
			Assert.DoesNotContain("Ritual", Tr(spell, LanguageCode.En).CastingTime, StringComparison.OrdinalIgnoreCase);
			Assert.DoesNotContain("rituale", Tr(spell, LanguageCode.It).CastingTime, StringComparison.OrdinalIgnoreCase);
		}
		Assert.Equal(31, Spells.Count(s => s.Ruleset == RulesetVersion.Dnd5e_2024 && s.Ritual));
	}

	[Fact]
	public void Every_spell_has_both_languages_and_a_complete_stat_block()
	{
		foreach (var spell in Spells)
		{
			Assert.InRange(spell.Level, 0, 9);
			Assert.True(Enum.IsDefined(spell.School), spell.Id.ToString());
			Assert.NotEmpty(spell.Classes);
			Assert.Equal(spell.Classes.Count, spell.Classes.Distinct().Count());
			Assert.True(spell.Verbal || spell.Somatic || spell.Material, spell.Id.ToString());
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, spell.Translations.Select(t => t.Language).OrderBy(l => l));

			foreach (var tr in spell.Translations)
			{
				var label = $"{tr.Name} ({tr.Language})";
				Assert.False(string.IsNullOrWhiteSpace(tr.Name), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Description), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.CastingTime), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Range), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Duration), label);
				Assert.True(tr.Name.Length <= 150 && tr.CastingTime.Length <= 300 && tr.Range.Length <= 150 && tr.Duration.Length <= 150, label);
				Assert.True((tr.MaterialComponent?.Length ?? 0) <= 500, label);
				//	The material text exists exactly when the spell has a material component
				Assert.Equal(spell.Material, !string.IsNullOrWhiteSpace(tr.MaterialComponent));
			}

			//	Concentration flag and duration line agree in both languages
			Assert.Equal(spell.Concentration, Tr(spell, LanguageCode.En).Duration.StartsWith("Concentration", StringComparison.Ordinal));
			Assert.Equal(spell.Concentration, Tr(spell, LanguageCode.It).Duration.StartsWith("Concentrazione", StringComparison.Ordinal));
			//	A higher-level paragraph exists in both languages or in neither
			Assert.Equal(Tr(spell, LanguageCode.En).HigherLevels is null, Tr(spell, LanguageCode.It).HigherLevels is null);
		}
	}

	[Fact]
	public void Translations_keep_the_same_dice_and_tables()
	{
		//	Catches a die or a table row lost in translation
		static List<string> Dice(SpellTranslation t) =>
			Regex.Matches(t.Description + " " + t.HigherLevels, @"\d+d\d+").Select(m => m.Value).OrderBy(v => v).ToList();

		foreach (var spell in Spells)
		{
			var en = Tr(spell, LanguageCode.En);
			var it = Tr(spell, LanguageCode.It);
			Assert.True(Dice(en).SequenceEqual(Dice(it)), $"{en.Name}: {string.Join(",", Dice(en))} / {string.Join(",", Dice(it))}");
			Assert.True(en.Description.Count(c => c == '|') == it.Description.Count(c => c == '|'), en.Name);
		}
	}

	[Fact]
	public void Italian_texts_use_metres()
	{
		foreach (var tr in Spells.SelectMany(s => s.Translations).Where(t => t.Language == LanguageCode.It))
		{
			var text = $"{tr.Range} {tr.Description} {tr.HigherLevels} {tr.MaterialComponent}";
			//	Measures only: "in piedi" (standing) and "pollici" (thumbs) are ordinary words
			Assert.DoesNotMatch(@"\d[\d.,]*\s*(piedi|feet|foot|miglia|libbre|pollici)\b", text);
		}
	}

	[Fact]
	public void Ids_are_unique_and_deterministic()
	{
		SpellSeeder.EnsureUniqueIds(Spells);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fireball"), Fireball2014Seeder.SpellId);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball"), Fireball2024Seeder.SpellId);
		Assert.NotEqual(Fireball2014Seeder.SpellId, Fireball2024Seeder.SpellId);

		//	Names are unique within each edition (both editions have their own Fireball)
		foreach (var edition in Spells.GroupBy(s => s.Ruleset))
		{
			Assert.Equal(edition.Count(), edition.Select(s => Tr(s, LanguageCode.En).Name).Distinct().Count());
			Assert.Equal(edition.Count(), edition.Select(s => Tr(s, LanguageCode.It).Name).Distinct().Count());
		}
	}

	[Fact]
	public void Fireball_and_hex_match_the_rules()
	{
		var fireball = Assert.Single(Spells, s => s.Id == Fireball2014Seeder.SpellId);
		Assert.Equal((3, SpellSchool.Evocation, ContentSource.Srd51), (fireball.Level, fireball.School, fireball.Source));
		Assert.Equal(new[] { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard }, fireball.Classes);
		Assert.Equal("Palla di Fuoco", Tr(fireball, LanguageCode.It).Name);
		Assert.Equal("45 metri", Tr(fireball, LanguageCode.It).Range);
		Assert.Contains("8d6", Tr(fireball, LanguageCode.It).Description);

		var hex = Assert.Single(Spells, s => s.Id == Hex2014Seeder.SpellId);
		Assert.Equal((1, SpellSchool.Enchantment, ContentSource.RealmForge, true), (hex.Level, hex.School, hex.Source, hex.Concentration));
		Assert.Equal(new[] { SpellcastingClass.Warlock }, hex.Classes);
		Assert.Equal("Sortilegio", Tr(hex, LanguageCode.It).Name);
		Assert.Equal("1 azione bonus", Tr(hex, LanguageCode.It).CastingTime);
	}

	[Fact]
	public void Spells_2024_match_the_rules()
	{
		var fireball = Assert.Single(Spells, s => s.Id == Fireball2024Seeder.SpellId);
		Assert.Equal((3, SpellSchool.Evocation, ContentSource.Srd52), (fireball.Level, fireball.School, fireball.Source));
		Assert.Equal(new[] { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard }, fireball.Classes);
		Assert.Equal(("Action", "150 feet"), (Tr(fireball, LanguageCode.En).CastingTime, Tr(fireball, LanguageCode.En).Range));
		Assert.Equal(("Palla di Fuoco", "Azione", "45 metri"), (Tr(fireball, LanguageCode.It).Name, Tr(fireball, LanguageCode.It).CastingTime, Tr(fireball, LanguageCode.It).Range));
		Assert.Equal("I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 3°.", Tr(fireball, LanguageCode.It).HigherLevels);

		//	Hex is in SRD 5.2, unlike in SRD 5.1
		var hex = Assert.Single(Spells, s => s.Id == Hex2024Seeder.SpellId);
		Assert.Equal((ContentSource.Srd52, "Sortilegio", "Azione bonus"), (hex.Source, Tr(hex, LanguageCode.It).Name, Tr(hex, LanguageCode.It).CastingTime));

		//	The 2024 healing spells moved to abjuration
		var cure = Assert.Single(Spells, s => s.Id == CureWounds2024Seeder.SpellId);
		Assert.Equal((SpellSchool.Abjuration, "Cura Ferite"), (cure.School, Tr(cure, LanguageCode.It).Name));

		//	A summoning spell outside the SRD: RealmForge text with its stat block in both languages
		var fey = Assert.Single(Spells, s => s.Id == SummonFey2024Seeder.SpellId);
		Assert.Equal((3, ContentSource.RealmForge, true), (fey.Level, fey.Source, fey.Concentration));
		Assert.Contains("#### Fey Spirit", Tr(fey, LanguageCode.En).Description);
		Assert.Contains("#### Spirito Fatato", Tr(fey, LanguageCode.It).Description);
		Assert.Equal("Richiama Folletto", Tr(fey, LanguageCode.It).Name);

		//	SRD names without the wizard
		Assert.Equal(("Arcane Hand", "Mano Arcana"), (Tr(ArcaneHand2024Seeder.Build(), LanguageCode.En).Name, Tr(ArcaneHand2024Seeder.Build(), LanguageCode.It).Name));
	}

	[Fact]
	public void Spell_subtitles_follow_the_manuals()
	{
		Assert.Equal("Invocazione di 3° livello", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.It));
		Assert.Equal("3rd-level evocation", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.En));
		Assert.Equal("Trucchetto di evocazione", GameTerms.SpellSubtitle(0, SpellSchool.Conjuration, false, LanguageCode.It));
		Assert.Equal("Conjuration cantrip", GameTerms.SpellSubtitle(0, SpellSchool.Conjuration, false, LanguageCode.En));
		Assert.Equal("1st-level divination (ritual)", GameTerms.SpellSubtitle(1, SpellSchool.Divination, true, LanguageCode.En));
		Assert.Equal("Divinazione di 1° livello (rituale)", GameTerms.SpellSubtitle(1, SpellSchool.Divination, true, LanguageCode.It));

		//	2024 manuals: "Level 3 Evocation" in English, same Italian wording as 2014
		Assert.Equal("Level 3 Evocation", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.En, RulesetVersion.Dnd5e_2024));
		Assert.Equal("Evocation Cantrip", GameTerms.SpellSubtitle(0, SpellSchool.Evocation, false, LanguageCode.En, RulesetVersion.Dnd5e_2024));
		Assert.Equal("Level 1 Abjuration (Ritual)", GameTerms.SpellSubtitle(1, SpellSchool.Abjuration, true, LanguageCode.En, RulesetVersion.Dnd5e_2024));
		Assert.Equal("Invocazione di 3° livello", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.It, RulesetVersion.Dnd5e_2024));

		Assert.Equal("Ai livelli superiori", GameTerms.SpellHigherLevelsHeading(3, LanguageCode.It, RulesetVersion.Dnd5e_2014));
		Assert.Equal("Utilizzo di uno slot di livello superiore", GameTerms.SpellHigherLevelsHeading(3, LanguageCode.It, RulesetVersion.Dnd5e_2024));
		Assert.Equal("Cantrip upgrade", GameTerms.SpellHigherLevelsHeading(0, LanguageCode.En, RulesetVersion.Dnd5e_2024));
	}
}
