using System.Text.RegularExpressions;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;

namespace RealmForge.Tests;

public class EquipmentSeedDataTests
{
	private static readonly IReadOnlyList<Equipment> Items = EquipmentSeeder.GetDefinitions();

	private static Equipment Item(RulesetVersion ruleset, string key) =>
		Assert.Single(Items, e => e.Id == DeterministicGuid.ForSrd(ruleset, "equipment", key));

	[Fact]
	public void Both_editions_are_seeded_from_the_SRD()
	{
		var items2014 = Items.Where(e => e.Ruleset == RulesetVersion.Dnd5e_2014).ToList();
		var items2024 = Items.Where(e => e.Ruleset == RulesetVersion.Dnd5e_2024).ToList();

		Assert.Equal(242, items2014.Count);
		Assert.Equal(208, items2024.Count);
		Assert.All(items2014, e => Assert.Equal(ContentSource.Srd51, e.Source));
		Assert.All(items2024, e => Assert.Equal(ContentSource.Srd52, e.Source));
		Assert.All(Items, e => Assert.True(e.IsOfficialSRD));

		//	Weapons and armor tables of the Player's Handbooks
		Assert.Equal(37, items2014.Count(e => e.Category == EquipmentCategory.Weapon));
		Assert.Equal(38, items2024.Count(e => e.Category == EquipmentCategory.Weapon));
		Assert.Equal(13, items2014.Count(e => e.Category == EquipmentCategory.Armor));
		Assert.Equal(13, items2024.Count(e => e.Category == EquipmentCategory.Armor));
		Assert.Equal(37, items2024.Count(e => e.Category == EquipmentCategory.Tool));
	}

	[Fact]
	public void Every_item_has_both_languages()
	{
		foreach (var item in Items)
		{
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, item.Translations.Select(t => t.Language).OrderBy(l => l));
			Assert.All(item.Translations, t =>
			{
				Assert.False(string.IsNullOrWhiteSpace(t.Name), item.Id.ToString());
				Assert.True(t.Name.Length <= 150, t.Name);
			});

			//	A description exists in both languages or in neither
			var en = item.Translations.Single(t => t.Language == LanguageCode.En).Description;
			var it = item.Translations.Single(t => t.Language == LanguageCode.It).Description;
			Assert.True(string.IsNullOrWhiteSpace(en) == string.IsNullOrWhiteSpace(it), item.Translations.First().Name);
		}
	}

	[Fact]
	public void Italian_texts_use_metres_and_the_third_person_and_keep_the_dice()
	{
		static List<string> Dice(string text) => Regex.Matches(text, @"\d+d\d+").Select(m => m.Value).OrderBy(v => v).ToList();

		foreach (var item in Items)
		{
			var en = item.Translations.Single(t => t.Language == LanguageCode.En);
			var it = item.Translations.Single(t => t.Language == LanguageCode.It);
			Assert.True(Dice(en.Description).SequenceEqual(Dice(it.Description)), en.Name);
			Assert.DoesNotMatch(@"\d[\d.,]*\s*(piedi|feet|foot|miglia|libbre|pollici)\b", it.Description);
			Assert.DoesNotMatch(@"\b(you|your)\b", it.Description);
		}
	}

	[Fact]
	public void Statistics_match_the_Players_Handbook_tables()
	{
		//	2024: Longsword 1d8 slashing, Versatile (1d10), Sap, 3 lb., 15 GP
		var longsword = Item(RulesetVersion.Dnd5e_2024, "longsword");
		Assert.Equal(("1d8", DamageType.Slashing, "1d10", WeaponMastery.Sap, 3m, 1500), (longsword.DamageDice, longsword.DamageType, longsword.VersatileDamageDice, longsword.Mastery, longsword.WeightInPounds, longsword.CostInCopper));

		//	2024 corrections from the book: Longbow 50 GP, Javelin 5 SP, Trident 1d8/1d10, Sling bludgeoning, Chain 5 GP and 10 lb.
		Assert.Equal(5000, Item(RulesetVersion.Dnd5e_2024, "longbow").CostInCopper);
		Assert.Equal(50, Item(RulesetVersion.Dnd5e_2024, "javelin").CostInCopper);
		Assert.Equal(("1d8", "1d10"), (Item(RulesetVersion.Dnd5e_2024, "trident").DamageDice, Item(RulesetVersion.Dnd5e_2024, "trident").VersatileDamageDice));
		Assert.Equal(DamageType.Bludgeoning, Item(RulesetVersion.Dnd5e_2024, "sling").DamageType);
		Assert.Equal((500, 10m), (Item(RulesetVersion.Dnd5e_2024, "chain").CostInCopper, Item(RulesetVersion.Dnd5e_2024, "chain").WeightInPounds));

		//	Armor: Chain Mail AC 16, Str 13, Stealth disadvantage; Breastplate 14 + Dex (max 2); Shield +2
		var chainMail = Item(RulesetVersion.Dnd5e_2024, "chain-mail");
		Assert.Equal((16, false, 13, true), (chainMail.ArmorClass, chainMail.ArmorAddsDexterity, chainMail.StrengthRequirement, chainMail.StealthDisadvantage));
		var breastplate = Item(RulesetVersion.Dnd5e_2014, "breastplate");
		Assert.Equal((14, true, (int?)2), (breastplate.ArmorClass, breastplate.ArmorAddsDexterity, breastplate.ArmorMaxDexterityBonus));
		Assert.Equal((ArmorCategory.Shield, 2), (Item(RulesetVersion.Dnd5e_2024, "shield").ArmorCategory!.Value, Item(RulesetVersion.Dnd5e_2024, "shield").ArmorClass!.Value));

		//	Every 2024 weapon has a mastery property, no 2014 weapon has one
		Assert.All(Items.Where(e => e.Category == EquipmentCategory.Weapon), e => Assert.Equal(e.Ruleset == RulesetVersion.Dnd5e_2024, e.Mastery.HasValue));

		//	2024 tools name the ability they use
		Assert.All(Items.Where(e => e.Ruleset == RulesetVersion.Dnd5e_2024 && e.Category == EquipmentCategory.Tool), e => Assert.NotNull(e.ToolAbility));
		Assert.Equal(AbilityScore.Dexterity, Item(RulesetVersion.Dnd5e_2024, "thieves-tools").ToolAbility);
	}

	[Fact]
	public void Weapons_are_consistent()
	{
		foreach (var weapon in Items.Where(e => e.Category == EquipmentCategory.Weapon))
		{
			var name = weapon.Translations.First().Name;
			Assert.NotNull(weapon.WeaponCategory);
			Assert.NotNull(weapon.WeaponRange);
			Assert.Equal(weapon.WeaponProperties.Contains(WeaponProperty.Versatile), weapon.VersatileDamageDice is not null);

			var ranged = weapon.WeaponRange == WeaponRange.Ranged || weapon.WeaponProperties.Contains(WeaponProperty.Thrown);
			Assert.True(ranged == (weapon.NormalRange is not null), name);
			if (ranged)
			{
				Assert.True(weapon.LongRange >= weapon.NormalRange, name);
			}

			//	Only the 2014 net deals no damage
			Assert.True(weapon.DamageDice is not null || weapon.WeaponProperties.Contains(WeaponProperty.Special), name);
		}
	}

	[Fact]
	public void Italian_formatting_uses_the_conversions_of_the_Italian_books()
	{
		Assert.Equal("1,5 kg", EquipmentTerms.FormatWeight(3m, LanguageCode.It));
		Assert.Equal("1/4 lb.", EquipmentTerms.FormatWeight(0.25m, LanguageCode.En));
		Assert.Equal("58½ lb.", EquipmentTerms.FormatWeight(58.5m, LanguageCode.En));
		Assert.Equal("1.500 mo", EquipmentTerms.FormatCost(150000, LanguageCode.It));
		Assert.Equal("5 SP", EquipmentTerms.FormatCost(50, LanguageCode.En));
		Assert.Equal("24/96", EquipmentTerms.FormatRange(80, 320, LanguageCode.It));
		Assert.Equal("12 km/h", EquipmentTerms.FormatShipSpeed(8m, LanguageCode.It));
		Assert.Equal("1d8 taglienti", EquipmentTerms.FormatDamage("1d8", DamageType.Slashing, LanguageCode.It));
		Assert.Equal("1 perforante", EquipmentTerms.FormatDamage("1", DamageType.Piercing, LanguageCode.It));
		Assert.Equal("14 + modificatore di Des (max 2)", EquipmentTerms.FormatArmorClass(ArmorCategory.Medium, 14, true, 2, LanguageCode.It));
		Assert.Equal("Lancio (gittata 6/18), Leggera", EquipmentTerms.FormatProperties(new[] { WeaponProperty.Light, WeaponProperty.Thrown }, 20, 60, null, LanguageCode.It));
	}

	[Fact]
	public void Ids_are_unique_and_deterministic()
	{
		EquipmentSeeder.EnsureUniqueIds(Items);
		Assert.Equal(DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longsword"), Item(RulesetVersion.Dnd5e_2024, "longsword").Id);
	}
}
