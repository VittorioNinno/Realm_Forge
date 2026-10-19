using System.Text.RegularExpressions;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Infrastructure.Persistence.Seeding.ClassesData;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class ClassSeedDataTests
{
	private static readonly IReadOnlyList<CharacterClass> Classes = ClassSeeder.GetClassDefinitions();
	private static readonly IReadOnlyList<Subclass> Subclasses = ClassSeeder.GetSubclassDefinitions();

	private static IEnumerable<ClassFeature> AllFeatures =>
		Classes.SelectMany(c => c.Features).Concat(Subclasses.SelectMany(s => s.Features));

	[Fact]
	public void All_2014_classes_and_subclasses_are_seeded_with_the_SRD_ones_labelled()
	{
		//	Player's Handbook 2014: 12 classes (all in SRD 5.1) and 40 subclasses, one per class in SRD 5.1
		var classes2014 = Classes.Where(c => c.Ruleset == RulesetVersion.Dnd5e_2014).ToList();
		var subclasses2014 = Subclasses.Where(s => s.Ruleset == RulesetVersion.Dnd5e_2014).ToList();
		Assert.Equal(12, classes2014.Count);
		Assert.All(classes2014, c => Assert.Equal(ContentSource.Srd51, c.Source));
		Assert.Equal(40, subclasses2014.Count);
		Assert.Equal(12, subclasses2014.Count(s => s.Source == ContentSource.Srd51));
		Assert.Equal(28, subclasses2014.Count(s => s.Source == ContentSource.RealmForge));
		Assert.All(Classes, c => Assert.True(c.IsOfficialSRD));
		Assert.All(Subclasses, s => Assert.True(s.IsOfficialSRD));

		//	Every class has exactly one SRD subclass and every subclass belongs to a seeded class of the same edition
		foreach (var cls in classes2014)
		{
			Assert.Single(subclasses2014, s => s.CharacterClassId == cls.Id && s.Source == ContentSource.Srd51);
		}
		Assert.All(Subclasses, s => Assert.Contains(Classes, c => c.Id == s.CharacterClassId && c.Ruleset == s.Ruleset));
	}

	[Fact]
	public void Every_class_has_both_languages_and_a_complete_sheet()
	{
		foreach (var cls in Classes)
		{
			Assert.Contains(cls.HitDie, new[] { 6, 8, 10, 12 });
			Assert.InRange(cls.SubclassLevel, 1, 3);
			Assert.Equal(2, cls.SavingThrows.Count);
			Assert.InRange(cls.SkillChoiceCount, 2, 4);
			Assert.NotEmpty(cls.PrimaryAbilities);
			Assert.Equal(cls.CasterProgression == CasterProgression.None, cls.SpellcastingAbility is null);
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, cls.Translations.Select(t => t.Language).OrderBy(l => l));

			foreach (var tr in cls.Translations)
			{
				var label = $"{tr.Name} ({tr.Language})";
				Assert.False(string.IsNullOrWhiteSpace(tr.Description), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.SubclassTitle), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.StartingEquipment), label);
				Assert.DoesNotContain("TODO", tr.Description, StringComparison.Ordinal);
				//	Progression table: one header, one separator and 20 level rows
				var rows = tr.ProgressionTable.Split('\n').Count(l => l.StartsWith('|'));
				Assert.True(rows == 22, $"{label}: {rows} table rows");
			}

			//	Features cover levels 1–20 in order, with the same keys in both languages
			Assert.Contains(cls.Features, f => f.Level == 1);
			Assert.All(cls.Features, f => Assert.InRange(f.Level, 1, 20));
		}
	}

	[Fact]
	public void Every_feature_has_both_languages()
	{
		foreach (var feature in AllFeatures)
		{
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, feature.Translations.Select(t => t.Language).OrderBy(l => l));
			Assert.All(feature.Translations, t =>
			{
				Assert.False(string.IsNullOrWhiteSpace(t.Name), feature.Id.ToString());
				Assert.False(string.IsNullOrWhiteSpace(t.Description), t.Name);
				Assert.True(t.Name.Length <= 150, t.Name);
			});
		}
		foreach (var sub in Subclasses)
		{
			Assert.NotEmpty(sub.Features);
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, sub.Translations.Select(t => t.Language).OrderBy(l => l));
		}
	}

	[Fact]
	public void Translations_keep_the_same_dice_and_tables()
	{
		static List<string> Dice(string text) => Regex.Matches(text, @"\d+d\d+").Select(m => m.Value).OrderBy(v => v).ToList();

		foreach (var feature in AllFeatures)
		{
			var en = feature.Translations.Single(t => t.Language == LanguageCode.En);
			var it = feature.Translations.Single(t => t.Language == LanguageCode.It);
			Assert.True(Dice(en.Description).SequenceEqual(Dice(it.Description)), en.Name);
			Assert.True(en.Description.Count(c => c == '|') == it.Description.Count(c => c == '|'), en.Name);
		}
	}

	[Fact]
	public void Italian_texts_use_metres_and_the_third_person()
	{
		var italian = AllFeatures.SelectMany(f => f.Translations).Where(t => t.Language == LanguageCode.It).Select(t => t.Description)
			.Concat(Classes.SelectMany(c => c.Translations).Where(t => t.Language == LanguageCode.It).Select(t => t.Description + " " + t.StartingEquipment))
			.Concat(Subclasses.SelectMany(s => s.Translations).Where(t => t.Language == LanguageCode.It).Select(t => t.Description));

		foreach (var text in italian)
		{
			Assert.DoesNotMatch(@"\d[\d.,]*\s*(piedi|feet|foot|miglia|libbre|pollici)\b", text);
			Assert.DoesNotMatch(@"\b(you|your)\b", text);
		}
	}

	[Fact]
	public void Ids_are_unique_and_deterministic()
	{
		ClassSeeder.EnsureUniqueIds(Classes, Subclasses);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "wizard"), Wizard2014Seeder.ClassId);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-evocation"), SchoolOfEvocation2014Seeder.SubclassId);
	}

	[Fact]
	public void Spellcasting_matches_the_rules()
	{
		static CharacterClass Cls(Guid id) => Assert.Single(Classes, c => c.Id == id);

		Assert.Equal((CasterProgression.Full, AbilityScore.Intelligence, 6), (Cls(Wizard2014Seeder.ClassId).CasterProgression, Cls(Wizard2014Seeder.ClassId).SpellcastingAbility, Cls(Wizard2014Seeder.ClassId).HitDie));
		Assert.Equal((CasterProgression.Pact, AbilityScore.Charisma), (Cls(Warlock2014Seeder.ClassId).CasterProgression, Cls(Warlock2014Seeder.ClassId).SpellcastingAbility));
		Assert.Equal(CasterProgression.Half, Cls(Paladin2014Seeder.ClassId).CasterProgression);
		Assert.Equal((CasterProgression.None, 12), (Cls(Barbarian2014Seeder.ClassId).CasterProgression, Cls(Barbarian2014Seeder.ClassId).HitDie));

		//	Eldritch Knight and Arcane Trickster cast as third casters with Intelligence
		var trickster = ArcaneTrickster2014Seeder.Build();
		Assert.Equal((CasterProgression.Third, AbilityScore.Intelligence, ContentSource.RealmForge), (trickster.CasterProgression, trickster.SpellcastingAbility, trickster.Source));
		Assert.Equal(Rogue2014Seeder.ClassId, trickster.CharacterClassId);
		Assert.Equal("Mistificatore Arcano", trickster.Translations.Single(t => t.Language == LanguageCode.It).Name);
		Assert.Equal(CasterProgression.Third, EldritchKnight2014Seeder.Build().CasterProgression);
	}
}
