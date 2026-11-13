using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What a character can wear and hold at the same time: one body armor, one shield, two hands. A two-handed weapon takes
///	both hands; two weapons need both to be Light (any one-handed weapons with Dual Wielder); a shield takes one hand.
///	Wondrous items (rings, cloaks, wands…) take no hand.
///	</summary>
public static class EquipmentRules
{
	public enum Problem
	{
		None = 0,

		//	Already wearing a body armor (Other names it)
		SecondArmor = 1,

		//	Already holding a shield
		SecondShield = 2,

		//	Not enough free hands (Other names what fills them)
		HandsFull = 3,

		//	A second weapon that is not Light (or the first one is not), without Dual Wielder
		NotLight = 4
	}

	public sealed record Check(Problem Problem, string? Other = null)
	{
		public bool Ok => Problem == Problem.None;
	}

	///	<summary>
	///	Hands an item takes when equipped: 2 for a two-handed weapon, 1 for another weapon or a shield, 0 otherwise.
	///	</summary>
	public static int Hands(ContextItem? item) => item switch
	{
		null => 0,
		{ ArmorCategory: ArmorCategory.Shield } => 1,
		{ Category: EquipmentCategory.Weapon } when item.WeaponProperties.Contains(WeaponProperty.TwoHanded) => 2,
		{ Category: EquipmentCategory.Weapon } => 1,
		_ => 0
	};

	private static bool IsBodyArmor(ContextItem? item) => item?.ArmorCategory is ArmorCategory.Light or ArmorCategory.Medium or ArmorCategory.Heavy;

	private static bool IsWeapon(ContextItem? item) => item?.Category == EquipmentCategory.Weapon;

	///	<summary>
	///	Ranged weapons (bows, crossbows, slings: Ammunition) form a set of their own: worn ready next to the melee weapons and
	///	the shield, one set in hand at a time; swapping takes a bonus action.
	///	</summary>
	public static bool IsRangedSet(ContextItem? item) => item?.Category == EquipmentCategory.Weapon && item.WeaponRange == WeaponRange.Ranged;

	///	<summary>
	///	Whether an equipped item is in hand right now (false: carried ready, "scorta"): a ranged weapon when the ranged set is
	///	in hand, a melee weapon or a shield when it is not, or whichever set is the only one worn.
	///	</summary>
	public static bool InHand(ContextItem? item, IEnumerable<ContextItem?> equipped, bool rangedReady)
	{
		if (Hands(item) == 0)
		{
			return true;
		}
		var list = equipped.Where(i => Hands(i) > 0).ToList();
		var hasRanged = list.Any(IsRangedSet);
		var hasMelee = list.Any(i => !IsRangedSet(i));
		var ranged = rangedReady ? hasRanged || !hasMelee : !hasMelee && hasRanged;
		return IsRangedSet(item) == ranged;
	}

	///	<summary>
	///	Whether <paramref name="item"/> can be equipped next to what the character already wears and holds.
	///	</summary>
	public static Check CanEquip(InventoryItem item, IEnumerable<InventoryItem> inventory, Func<InventoryItem, ContextItem?> lookup,
		Func<InventoryItem, string> name, bool dualWielder)
	{
		var info = lookup(item);
		if (info is null)
		{
			return new Check(Problem.None);
		}
		var worn = inventory.Where(i => i != item && i.Equipped).Select(i => (Item: i, Info: lookup(i))).ToList();

		if (IsBodyArmor(info) && worn.FirstOrDefault(w => IsBodyArmor(w.Info)) is { Item: not null } armor)
		{
			return new Check(Problem.SecondArmor, name(armor.Item));
		}
		if (info.ArmorCategory == ArmorCategory.Shield && worn.FirstOrDefault(w => w.Info?.ArmorCategory == ArmorCategory.Shield) is { Item: not null } shield)
		{
			return new Check(Problem.SecondShield, name(shield.Item));
		}

		var hands = Hands(info);
		if (hands == 0)
		{
			return new Check(Problem.None);
		}
		//	The ranged set and the melee set (with the shield) each fill the two hands on their own
		var held = worn.Where(w => Hands(w.Info) > 0 && IsRangedSet(w.Info) == IsRangedSet(info)).ToList();
		if (held.Sum(w => Hands(w.Info)) + hands > 2)
		{
			return new Check(Problem.HandsFull, string.Join(", ", held.Select(w => name(w.Item))));
		}

		//	A weapon in each hand: both Light, unless Dual Wielder (then any one-handed weapons)
		if (IsWeapon(info) && held.FirstOrDefault(w => IsWeapon(w.Info)) is { Item: not null } other && !dualWielder)
		{
			var light = info.WeaponProperties.Contains(WeaponProperty.Light) && other.Info!.WeaponProperties.Contains(WeaponProperty.Light);
			if (!light)
			{
				return new Check(Problem.NotLight, name(other.Item));
			}
		}
		return new Check(Problem.None);
	}
}
