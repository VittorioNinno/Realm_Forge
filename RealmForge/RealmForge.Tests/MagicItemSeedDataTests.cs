using System.Text.Json;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class MagicItemSeedDataTests
{
	private static readonly IReadOnlyList<MagicItem> Items = MagicItemSeeder.GetDefinitions();

	private static MagicItemTranslation Tr(MagicItem item, LanguageCode lang) => item.Translations.Single(t => t.Language == lang);

	private static MagicItem ByEnglishName(string name) => Items.Single(i => Tr(i, LanguageCode.En).Name == name);

	private static MagicItemProperties? Mechanics(MagicItem item) =>
		item.Mechanics is null ? null : JsonSerializer.Deserialize<MagicItemProperties>(item.Mechanics, MagicItemSeeder.MechanicsJson);

	[Fact]
	public void The_2014_items_are_the_SRD_ones_plus_the_DMG_ones_outside_it()
	{
		//	SRD 5.1: 240 items (the 5e-database list, the Shield +1/+2/+3 and the Orb of Dragonkind) with 126 variants;
		//	2014 Dungeon Master's Guide outside the SRD: 36 items with 10 variants, RealmForge texts
		Assert.Equal(412, Items.Count);
		Assert.Equal(276, Items.Count(i => i.ParentId is null));
		Assert.Equal(366, Items.Count(i => i.Source == ContentSource.Srd51));
		Assert.Equal(46, Items.Count(i => i.Source == ContentSource.RealmForge));
		Assert.All(Items, i => Assert.True(i.IsOfficialSRD));
		Assert.All(Items, i => Assert.Equal(RulesetVersion.Dnd5e_2014, i.Ruleset));
	}

	[Fact]
	public void Every_item_has_both_languages_and_variants_point_to_an_item()
	{
		var ids = Items.Select(i => i.Id).ToHashSet();
		foreach (var item in Items)
		{
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, item.Translations.Select(t => t.Language).OrderBy(l => l));
			Assert.True(Enum.IsDefined(item.Type), item.Id.ToString());
			foreach (var tr in item.Translations)
			{
				var label = $"{tr.Name} ({tr.Language})";
				Assert.False(string.IsNullOrWhiteSpace(tr.Name), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Subtitle), label);
				Assert.InRange(tr.Name.Length, 1, 150);
				Assert.InRange(tr.Subtitle.Length, 1, 300);

				//	Variants take the text of their item
				Assert.Equal(item.ParentId is null, tr.Description.Length > 0);
			}
			if (item.ParentId is { } parent)
			{
				Assert.Contains(parent, ids);
				Assert.NotNull(item.Rarity);
			}
		}
	}

	[Fact]
	public void Italian_names_follow_the_official_SRD()
	{
		Assert.Equal("Anello di protezione", Tr(ByEnglishName("Ring of Protection"), LanguageCode.It).Name);
		Assert.Equal("Mantello della protezione", Tr(ByEnglishName("Cloak of Protection"), LanguageCode.It).Name);
		Assert.Equal("Guanti del potere orchesco", Tr(ByEnglishName("Gauntlets of Ogre Power"), LanguageCode.It).Name);
		Assert.Equal("Bacchetta di missili magici", Tr(ByEnglishName("Wand of Magic Missiles"), LanguageCode.It).Name);

		//	The Italian SRD prints "Armastura demoniaca": fixed
		Assert.Equal("Armatura demoniaca", Tr(ByEnglishName("Demon Armor"), LanguageCode.It).Name);
		Assert.DoesNotContain(Items.SelectMany(i => i.Translations), t => t.Name.Contains("Armastura"));
	}

	[Fact]
	public void The_healing_potions_heal_as_their_table_says()
	{
		var healing = Items.Single(i => i.ParentId is null && Tr(i, LanguageCode.En).Name == "Potion of Healing");
		var variants = Items.Where(i => i.ParentId == healing.Id).OrderBy(i => i.SortOrder).ToList();
		Assert.Equal(new[] { "Pozione di guarigione", "Pozione di guarigione maggiore", "Pozione di guarigione superiore", "Pozione di guarigione suprema" },
			variants.Select(v => Tr(v, LanguageCode.It).Name));
		Assert.Equal(new[] { "2d4+2", "4d4+4", "8d4+8", "10d4+20" }, variants.Select(v => Mechanics(v)!.HealDice));
		Assert.Equal(new ItemRarity?[] { ItemRarity.Common, ItemRarity.Uncommon, ItemRarity.Rare, ItemRarity.VeryRare }, variants.Select(v => v.Rarity));
	}

	[Fact]
	public void The_sheet_rules_are_set_for_the_common_items()
	{
		var ring = Mechanics(ByEnglishName("Ring of Protection"))!;
		Assert.Equal(new[] { (MagicEffectKind.ArmorClass, 1), (MagicEffectKind.SavingThrows, 1) }, ring.Effects.Select(e => (e.Kind, e.Value)));

		var belt = Mechanics(ByEnglishName("Belt of Storm Giant Strength"))!;
		Assert.Equal((MagicEffectKind.SetAbilityScore, 29, AbilityScore.Strength), (belt.Effects[0].Kind, belt.Effects[0].Value, belt.Effects[0].Ability!.Value));

		var wand = Mechanics(ByEnglishName("Wand of Fireballs"))!;
		Assert.Equal((7, ItemRecharge.LongRest, "1d6+1"), (wand.Charges, wand.Recharge, wand.RechargeDice));

		var resistance = Mechanics(ByEnglishName("Ring of Fire Resistance"))!;
		Assert.Equal(DamageType.Fire, resistance.Effects.Single().DamageType);

		var pact = Mechanics(ByEnglishName("Rod of the Pact Keeper, +2"))!;
		Assert.Equal(new[] { (MagicEffectKind.SpellAttack, 2), (MagicEffectKind.SpellSaveDc, 2) }, pact.Effects.Select(e => (e.Kind, e.Value)));

		//	Every die the sheet rolls is a valid formula, every effect is known
		foreach (var magic in Items.Select(Mechanics).Where(m => m is not null))
		{
			Assert.All(new[] { magic!.RechargeDice, magic.HealDice }.Where(d => d is not null),
				d => Assert.Matches(@"^\d{1,2}d\d{1,3}([+-]\d{1,3})?$", d));
			Assert.All(magic.Effects, e => Assert.True(Enum.IsDefined(e.Kind)));
			Assert.InRange(magic.Charges, 0, 99);
		}
	}

	[Fact]
	public void The_DMG_items_outside_the_SRD_have_RealmForge_names()
	{
		var dmg = Items.Where(i => i.Source == ContentSource.RealmForge && i.ParentId is null).ToList();
		Assert.Equal(36, dmg.Count);
		Assert.Equal("Lama nera", Tr(ByEnglishName("Blackrazor"), LanguageCode.It).Name);
		Assert.Equal("Pietre parlanti", Tr(ByEnglishName("Sending Stones"), LanguageCode.It).Name);
		Assert.Equal(7, Items.Count(i => i.ParentId == ByEnglishName("Instrument of the Bards").Id));

		//	The DMG names of SRD items are kept as aliases
		Assert.Equal("Heward's Handy Haversack", Tr(ByEnglishName("Handy Haversack"), LanguageCode.En).Alias);

		//	and so are the Italian names of the Manuale del Dungeon Master that differ from the Italian SRD
		Assert.Equal("Bacchetta dei dardi incantati", Tr(ByEnglishName("Wand of Magic Missiles"), LanguageCode.It).Alias);
		Assert.Equal("Zainetto pratico di Heward", Tr(ByEnglishName("Handy Haversack"), LanguageCode.It).Alias);
		Assert.Equal(15, Items.Count(i => Tr(i, LanguageCode.It).Alias is not null));
	}
}
