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
		Assert.Equal(Spells.Count, Spells.Select(s => Tr(s, LanguageCode.En).Name).Distinct().Count());
		Assert.Equal(Spells.Count, Spells.Select(s => Tr(s, LanguageCode.It).Name).Distinct().Count());
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
	public void Spell_subtitles_follow_the_manuals()
	{
		Assert.Equal("Invocazione di 3° livello", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.It));
		Assert.Equal("3rd-level evocation", GameTerms.SpellSubtitle(3, SpellSchool.Evocation, false, LanguageCode.En));
		Assert.Equal("Trucchetto di evocazione", GameTerms.SpellSubtitle(0, SpellSchool.Conjuration, false, LanguageCode.It));
		Assert.Equal("Conjuration cantrip", GameTerms.SpellSubtitle(0, SpellSchool.Conjuration, false, LanguageCode.En));
		Assert.Equal("1st-level divination (ritual)", GameTerms.SpellSubtitle(1, SpellSchool.Divination, true, LanguageCode.En));
		Assert.Equal("Divinazione di 1° livello (rituale)", GameTerms.SpellSubtitle(1, SpellSchool.Divination, true, LanguageCode.It));
	}
}
