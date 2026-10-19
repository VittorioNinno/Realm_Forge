using System.Text.RegularExpressions;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Tests;

public class RulesGlossarySeedDataTests
{
	private static readonly IReadOnlyList<RuleEntry> Entries = RulesGlossarySeeder.GetDefinitions();

	private static RuleEntry Entry(RulesetVersion ruleset, string key) =>
		Assert.Single(Entries, e => e.Id == DeterministicGuid.ForSrd(ruleset, RuleEntryFactory.Kind, key));

	private static RuleEntryTranslation Text(RuleEntry entry, LanguageCode language) =>
		entry.Translations.Single(t => t.Language == language);

	private static GlossaryLinker Linker(RulesetVersion ruleset, LanguageCode language) =>
		new(Entries.Where(e => e.Ruleset == ruleset).Select(e =>
		{
			var text = Text(e, language);
			return new GlossaryTerm(e.Id, text.Name, e.Category.ToString(), MarkdownPreview.ToPlainText(text.Description, 320), text.Aliases);
		}));

	[Fact]
	public void Both_editions_are_seeded_from_the_SRD()
	{
		var entries2014 = Entries.Where(e => e.Ruleset == RulesetVersion.Dnd5e_2014).ToList();
		var entries2024 = Entries.Where(e => e.Ruleset == RulesetVersion.Dnd5e_2024).ToList();

		//	2024: the whole Rules Glossary of the SRD 5.2.1 (the same entries as appendix C of the Player's Handbook)
		Assert.Equal(155, entries2024.Count);
		Assert.Equal(88, entries2014.Count);
		Assert.All(entries2014, e => Assert.Equal(ContentSource.Srd51, e.Source));
		Assert.All(entries2024, e => Assert.Equal(ContentSource.Srd52, e.Source));
		Assert.All(Entries, e => Assert.True(e.IsOfficialSRD));

		Assert.Equal((15, 10, 5), (entries2014.Count(e => e.Category == RuleCategory.Condition), entries2014.Count(e => e.Category == RuleCategory.Action), entries2014.Count(e => e.Category == RuleCategory.AreaOfEffect)));
		Assert.Equal((15, 12, 6, 3, 5), (entries2024.Count(e => e.Category == RuleCategory.Condition), entries2024.Count(e => e.Category == RuleCategory.Action),
			entries2024.Count(e => e.Category == RuleCategory.AreaOfEffect), entries2024.Count(e => e.Category == RuleCategory.Attitude), entries2024.Count(e => e.Category == RuleCategory.Hazard)));
	}

	[Fact]
	public void Conditions_use_the_official_Italian_names()
	{
		var expected = new[] { "Accecato", "Affascinato", "Afferrato", "Assordato", "Avvelenato", "Incapacitato", "Indebolimento", "Invisibile",
			"Paralizzato", "Pietrificato", "Privo di sensi", "Prono", "Spaventato", "Stordito", "Trattenuto" };

		foreach (var ruleset in new[] { RulesetVersion.Dnd5e_2014, RulesetVersion.Dnd5e_2024 })
		{
			var names = Entries.Where(e => e.Ruleset == ruleset && e.Category == RuleCategory.Condition)
				.Select(e => Text(e, LanguageCode.It).Name).OrderBy(n => n, StringComparer.Ordinal).ToArray();
			Assert.Equal(expected, names);
		}

		Assert.Equal("Prone", Text(Entry(RulesetVersion.Dnd5e_2024, "prone"), LanguageCode.En).Name);
		Assert.Equal("Attacchi di opportunità", Text(Entry(RulesetVersion.Dnd5e_2024, "opportunity-attacks"), LanguageCode.It).Name);
		Assert.Equal("Scatto", Text(Entry(RulesetVersion.Dnd5e_2014, "dash"), LanguageCode.It).Name);
	}

	[Fact]
	public void Every_entry_has_both_languages_and_metric_Italian_texts()
	{
		static List<string> Dice(string text) => Regex.Matches(text, @"\d+d\d+").Select(m => m.Value).OrderBy(v => v).ToList();

		foreach (var entry in Entries)
		{
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, entry.Translations.Select(t => t.Language).OrderBy(l => l));
			var en = Text(entry, LanguageCode.En);
			var it = Text(entry, LanguageCode.It);

			Assert.False(string.IsNullOrWhiteSpace(en.Name + en.Description), entry.Key);
			Assert.False(string.IsNullOrWhiteSpace(it.Name + it.Description), entry.Key);
			Assert.True(it.Name.Length <= 150 && en.Name.Length <= 150, entry.Key);
			Assert.True(Dice(en.Description).SequenceEqual(Dice(it.Description)), entry.Key);
			Assert.DoesNotMatch(@"\d[\d.,]*\s*(piedi|feet|foot|libbre|galloni)\b", it.Description);
			Assert.DoesNotMatch(@"\b(you|your|See also)\b", it.Description);

			//	"See also" references are data (RelatedKeys), not text
			Assert.DoesNotContain("_See also_", en.Description);
		}
	}

	[Fact]
	public void See_also_links_point_to_entries_of_the_same_edition()
	{
		Assert.Equal(new[] { "unarmed-strike", "grappled" }, Entry(RulesetVersion.Dnd5e_2024, "grappling").RelatedKeys);
		Assert.Equal(new[] { "creature", "nonplayer-character" }, Entry(RulesetVersion.Dnd5e_2024, "monster").RelatedKeys);
		Assert.Contains("food-and-water", Entry(RulesetVersion.Dnd5e_2014, "exhaustion").RelatedKeys);

		//	GetDefinitions already throws on unknown keys; this documents the rule
		RulesGlossarySeeder.EnsureConsistency(Entries.ToList());
	}

	[Fact]
	public void Italian_terms_are_linked_once_and_never_inside_links_or_headings()
	{
		var linker = Linker(RulesetVersion.Dnd5e_2024, LanguageCode.It);
		var prone = Entry(RulesetVersion.Dnd5e_2024, "prone").Id;
		var bonusAction = Entry(RulesetVersion.Dnd5e_2024, "bonus-action").Id;

		var html = linker.Link("<h3>Prono</h3><p>Il bersaglio cade prono e non può effettuare un'azione bonus. Resta prono.</p><p><a href=\"x\">prona</a></p>");

		Assert.Equal(1, Regex.Matches(html, $"rules\\?id={prone}").Count);
		Assert.Contains($"href=\"rules?id={bonusAction}\"", html);
		Assert.Contains("<h3>Prono</h3>", html);
		Assert.Contains(">azione bonus</a>", html);
		Assert.Contains("data-term-name=\"Azione bonus\"", html);

		//	The entry being shown is not linked to itself, "svantaggio" is not read as "vantaggio"
		var self = linker.Link("<p>Mentre è prono subisce svantaggio.</p>", prone);
		Assert.DoesNotContain($"id={prone}", self);
		Assert.Contains($"id={Entry(RulesetVersion.Dnd5e_2024, "disadvantage").Id}", self);
		Assert.DoesNotContain($"id={Entry(RulesetVersion.Dnd5e_2024, "advantage").Id}", self);
	}

	[Fact]
	public void Special_forms_respect_case_and_exclusions()
	{
		var en = Linker(RulesetVersion.Dnd5e_2024, LanguageCode.En);
		var cone = Entry(RulesetVersion.Dnd5e_2024, "cone").Id;
		Assert.Contains($"id={cone}", en.Link("<p>a 15-foot Cone of fire</p>"));
		Assert.DoesNotContain($"id={cone}", en.Link("<p>an ice cream cone</p>"));

		//	Expertise is "Maestria", but "Maestria negli Incantesimi" (Spell Mastery) is another feature
		var it = Linker(RulesetVersion.Dnd5e_2024, LanguageCode.It);
		var expertise = Entry(RulesetVersion.Dnd5e_2024, "expertise").Id;
		Assert.Contains($"id={expertise}", it.Link("<p>Ottiene Maestria in due abilità.</p>"));
		Assert.DoesNotContain($"id={expertise}", it.Link("<p>Ottiene Maestria negli Incantesimi.</p>"));

		//	Typographic and straight apostrophes are the same
		var unarmed = Entry(RulesetVersion.Dnd5e_2024, "unarmed-strike").Id;
		Assert.Contains($"id={unarmed}", it.Link("<p>Effettua un colpo senz’armi.</p>"));
	}

	[Fact]
	public void Seeded_spell_texts_link_the_rules_terms()
	{
		var command = SpellSeeder.GetDefinitions().Single(s => s.Ruleset == RulesetVersion.Dnd5e_2024 && s.Translations.Any(t => t.Name == "Command"));
		var it = command.Translations.Single(t => t.Language == LanguageCode.It).Description;
		var html = Linker(RulesetVersion.Dnd5e_2024, LanguageCode.It).Link(it);

		var linked = Regex.Matches(html, "<a class=\"rf-term\"[^>]*>([^<]+)</a>").Select(m => m.Groups[1].Value).ToList();
		Assert.Equal(new[] { "prono", "azione bonus" }, linked);
	}

	[Fact]
	public void Ids_are_deterministic()
	{
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "rule", "prone"), Entry(RulesetVersion.Dnd5e_2024, "prone").Id);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "rule", "prone", "it"), Text(Entry(RulesetVersion.Dnd5e_2024, "prone"), LanguageCode.It).Id);
	}
}
