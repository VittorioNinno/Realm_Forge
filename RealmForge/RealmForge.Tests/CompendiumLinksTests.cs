using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Tests;

public class CompendiumLinksTests
{
	private static string ClassEquipment(string englishName, RulesetVersion ruleset, LanguageCode language) =>
		ClassSeeder.GetClassDefinitions()
			.Single(c => c.Ruleset == ruleset && c.Translations.Any(t => t.Language == LanguageCode.En && t.Name == englishName))
			.Translations.Single(t => t.Language == language).StartingEquipment ?? string.Empty;

	private static EquipmentNameMatcher Matcher(RulesetVersion ruleset, LanguageCode language) =>
		new(EquipmentSeeder.GetDefinitions().Where(e => e.Ruleset == ruleset)
			.Select(e => (e.Translations.Single(t => t.Language == language).Name, e.Id)));

	private static Guid Item(RulesetVersion ruleset, string key) => DeterministicGuid.ForSrd(ruleset, "equipment", key);

	[Fact]
	public void Kits_of_the_2024_classes_become_options_A_and_B()
	{
		var wizard = EquipmentLoadout.FromClassText(ClassEquipment("Wizard", RulesetVersion.Dnd5e_2024, LanguageCode.It));

		Assert.Empty(wizard.Rows);
		Assert.Equal(new[] { "A", "B" }, wizard.Kits.Select(k => k.Letter));
		Assert.Equal(6, wizard.Kits[0].Items.Count);
		Assert.Equal(("Pugnali", (int?)2), (wizard.Kits[0].Items[0].Text, wizard.Kits[0].Items[0].Quantity));
		Assert.Equal("5 mo", wizard.Kits[0].Items[^1].Coins);
		Assert.Equal("55 mo", Assert.Single(wizard.Kits[1].Items).Coins);

		//	Commas inside parentheses do not split, "and" before the last item does
		var fighter = EquipmentLoadout.FromClassText("Choose A or B:\n- (A) Focus (sprig, mistletoe), Shield and 9 GP\n- (B) 150 GP");
		Assert.Equal(new[] { "Focus (sprig, mistletoe)", "Shield", "" }, fighter.Kits[0].Items.Select(i => i.Text));
	}

	[Fact]
	public void Choices_of_the_2014_classes_become_lines_with_options()
	{
		var cleric = EquipmentLoadout.FromClassText(ClassEquipment("Cleric", RulesetVersion.Dnd5e_2014, LanguageCode.En));

		Assert.Empty(cleric.Kits);
		Assert.Equal(new[] { 2, 3, 2, 2, 1 }, cleric.Rows.Select(r => r.Options.Count));
		Assert.Equal(new[] { "scale mail", "leather armor", "chain mail (if proficient)" }, cleric.Rows[1].Options.Select(o => string.Join("|", o.Items.Select(i => i.Text))));
		Assert.Equal(new[] { "a light crossbow", "20 bolts" }, cleric.Rows[2].Options[0].Items.Select(i => i.Text));
	}

	[Fact]
	public void Every_class_and_background_equipment_is_parsed()
	{
		foreach (var cls in ClassSeeder.GetClassDefinitions())
		{
			foreach (var tr in cls.Translations.Where(t => !string.IsNullOrWhiteSpace(t.StartingEquipment)))
			{
				var loadout = EquipmentLoadout.FromClassText(tr.StartingEquipment);
				Assert.False(loadout.IsEmpty, tr.Name);
				Assert.True(loadout.Kits.Count == 0 || loadout.Rows.Count == 0, tr.Name);
				Assert.All(loadout.Kits.Concat(loadout.Rows.SelectMany(r => r.Options)), o => Assert.NotEmpty(o.Items));

				//	2024 kits always end with the coins
				if (cls.Ruleset == RulesetVersion.Dnd5e_2024)
				{
					Assert.All(loadout.Kits, k => Assert.NotNull(k.Items[^1].Coins));
				}
			}
		}

		var acolyte = EquipmentLoadout.FromBackground("A holy symbol\nVestments\nA belt pouch containing 15 gp", null);
		Assert.Equal(3, acolyte.Rows.Count);
		Assert.Equal(("A belt pouch containing", "15 gp"), (acolyte.Rows[2].Options[0].Items[0].Text, acolyte.Rows[2].Options[0].Items[0].Coins));

		var acolyte2024 = EquipmentLoadout.FromBackground("Holy Symbol\nRobe\n8 GP", "50 mo");
		Assert.Equal(new[] { 3, 1 }, acolyte2024.Kits.Select(k => k.Items.Count));
	}

	[Fact]
	public void Items_are_found_in_the_equipment_compendium()
	{
		var it = Matcher(RulesetVersion.Dnd5e_2024, LanguageCode.It);
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "greataxe"), it.Find("un'ascia bipenne"));
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "handaxe"), it.Find("4 asce"));
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "dagger"), it.Find("2 pugnali"));
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "spellbook"), it.Find("un libro degli incantesimi"));
		Assert.Null(it.Find("una qualsiasi arma semplice"));

		var en = Matcher(RulesetVersion.Dnd5e_2024, LanguageCode.En);
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "handaxe"), en.Find("4 Handaxes"));
		Assert.Equal(Item(RulesetVersion.Dnd5e_2024, "greataxe"), en.Find("a greataxe"));
	}

	[Fact]
	public void Italic_spell_names_link_to_the_spell()
	{
		var fireball = Guid.NewGuid();
		var linker = new GlossaryLinker(Array.Empty<GlossaryTerm>(), new[] { ("Palla di Fuoco", fireball) });

		var html = linker.Link("<p>Lancia <em>palla di fuoco</em> e poi <em>Palla di Fuoco</em>; <em>altro</em>.</p>");

		Assert.Single(System.Text.RegularExpressions.Regex.Matches(html, $"spells\\?id={fireball}"));
		Assert.Contains("<em><a class=\"rf-spell-link\"", html);
		Assert.Contains("<em>altro</em>", html);
	}
}
