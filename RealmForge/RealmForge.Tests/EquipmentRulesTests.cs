using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

///	<summary>
///	What a character can wear and hold together: one body armor, one shield, two hands, two weapons only if Light.
///	</summary>
public class EquipmentRulesTests
{
	private static ContextItem Weapon(string name, params WeaponProperty[] properties) => new(
		Guid.NewGuid(), name, name, EquipmentCategory.Weapon, WeaponCategory.Martial, WeaponRange.Melee, properties.ToList(), "1d8", DamageType.Slashing,
		null, null, null, null, null, null, false, null, null, false, null, 3m, 1500);

	private static ContextItem Armor(string name, ArmorCategory category) => new(
		Guid.NewGuid(), name, name, EquipmentCategory.Armor, null, null, new List<WeaponProperty>(), null, null, null, null, null, null,
		category, category == ArmorCategory.Shield ? 2 : 14, true, 2, null, false, null, 20m, 5000);

	private static (List<InventoryItem> Inventory, Func<InventoryItem, ContextItem?> Lookup) Setup(params (ContextItem Item, bool Equipped)[] items)
	{
		var map = new Dictionary<Guid, ContextItem>();
		var inventory = new List<InventoryItem>();
		foreach (var (item, equipped) in items)
		{
			map[item.Id] = item;
			inventory.Add(new InventoryItem { EquipmentId = item.Id, Equipped = equipped });
		}
		return (inventory, i => i.EquipmentId is { } id ? map.GetValueOrDefault(id) : null);
	}

	private static EquipmentRules.Check Try(List<InventoryItem> inventory, Func<InventoryItem, ContextItem?> lookup, int index, bool dualWielder = false) =>
		EquipmentRules.CanEquip(inventory[index], inventory, lookup, i => lookup(i)?.Name ?? string.Empty, dualWielder);

	[Fact]
	public void A_second_body_armor_is_refused_and_names_the_one_worn()
	{
		var (inventory, lookup) = Setup((Armor("Chain Mail", ArmorCategory.Heavy), true), (Armor("Leather", ArmorCategory.Light), false));
		var check = Try(inventory, lookup, 1);
		Assert.Equal(EquipmentRules.Problem.SecondArmor, check.Problem);
		Assert.Equal("Chain Mail", check.Other);
	}

	[Fact]
	public void A_second_shield_is_refused()
	{
		var (inventory, lookup) = Setup((Armor("Shield", ArmorCategory.Shield), true), (Armor("Tower", ArmorCategory.Shield), false));
		Assert.Equal(EquipmentRules.Problem.SecondShield, Try(inventory, lookup, 1).Problem);
	}

	[Fact]
	public void A_two_handed_weapon_needs_both_hands()
	{
		var (inventory, lookup) = Setup((Weapon("Longsword", WeaponProperty.Versatile), true), (Weapon("Greatsword", WeaponProperty.Heavy, WeaponProperty.TwoHanded), false));
		Assert.Equal(EquipmentRules.Problem.HandsFull, Try(inventory, lookup, 1).Problem);
	}

	[Fact]
	public void Nothing_more_in_the_hands_next_to_a_two_handed_weapon()
	{
		var (inventory, lookup) = Setup((Weapon("Greatsword", WeaponProperty.TwoHanded), true), (Armor("Shield", ArmorCategory.Shield), false), (Weapon("Dagger", WeaponProperty.Light), false));
		Assert.Equal(EquipmentRules.Problem.HandsFull, Try(inventory, lookup, 1).Problem);
		Assert.Equal(EquipmentRules.Problem.HandsFull, Try(inventory, lookup, 2).Problem);
	}

	[Fact]
	public void Sword_and_shield_fit_and_a_third_item_does_not()
	{
		var (inventory, lookup) = Setup((Weapon("Longsword", WeaponProperty.Versatile), true), (Armor("Shield", ArmorCategory.Shield), false), (Weapon("Dagger", WeaponProperty.Light), false));
		Assert.True(Try(inventory, lookup, 1).Ok);
		inventory[1].Equipped = true;
		Assert.Equal(EquipmentRules.Problem.HandsFull, Try(inventory, lookup, 2).Problem);
	}

	[Fact]
	public void Two_weapons_must_both_be_light_unless_dual_wielder()
	{
		var (inventory, lookup) = Setup((Weapon("Longsword", WeaponProperty.Versatile), true), (Weapon("Dagger", WeaponProperty.Light), false));
		Assert.Equal(EquipmentRules.Problem.NotLight, Try(inventory, lookup, 1).Problem);
		Assert.True(Try(inventory, lookup, 1, dualWielder: true).Ok);

		var (light, lightLookup) = Setup((Weapon("Shortsword", WeaponProperty.Light), true), (Weapon("Dagger", WeaponProperty.Light), false));
		Assert.True(Try(light, lightLookup, 1).Ok);
	}

	[Fact]
	public void Armor_and_weapons_do_not_compete_for_hands()
	{
		var (inventory, lookup) = Setup((Weapon("Greatsword", WeaponProperty.TwoHanded), true), (Armor("Chain Mail", ArmorCategory.Heavy), false));
		Assert.True(Try(inventory, lookup, 1).Ok);
	}
}
