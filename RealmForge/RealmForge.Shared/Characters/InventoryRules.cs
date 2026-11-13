using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What the inventory does on its own: the ammunition a ranged weapon spends, the consumables that are used up, paying a
///	price from the purse (with change in smaller coins).
///	</summary>
public static class InventoryRules
{
	//	Below this many pieces of ammunition the sheet warns
	public const int LowAmmunition = 5;

	///	<summary>
	///	The kind of ammunition a weapon fires (by its English name: arrows, bolts, sling or firearm bullets, needles), or
	///	null for a weapon that needs none.
	///	</summary>
	public static string[]? AmmunitionOf(ContextItem? weapon)
	{
		if (weapon is null || !weapon.WeaponProperties.Contains(WeaponProperty.Ammunition))
		{
			return null;
		}
		var name = weapon.EnglishName.ToLowerInvariant();
		return name switch
		{
			_ when name.Contains("crossbow") => new[] { "bolt" },
			_ when name.Contains("bow") => new[] { "arrow" },
			_ when name.Contains("sling") => new[] { "sling bullet", "bullets, sling" },
			_ when name.Contains("blowgun") => new[] { "needle" },
			_ when name.Contains("pistol") || name.Contains("musket") || name.Contains("rifle") => new[] { "firearm", "bullets, firearm" },
			_ => null
		};
	}

	///	<summary>
	///	The inventory entry holding the ammunition of <paramref name="weapon"/> (the one with most pieces), if any.
	///	</summary>
	public static InventoryItem? AmmunitionFor(ContextItem? weapon, IEnumerable<InventoryItem> inventory, Func<InventoryItem, ContextItem?> lookup)
	{
		if (AmmunitionOf(weapon) is not { } kinds)
		{
			return null;
		}
		return inventory
			.Where(i => lookup(i) is { } info && info.Category != EquipmentCategory.Weapon
				&& kinds.Any(k => info.EnglishName.ToLowerInvariant().Contains(k)))
			.OrderByDescending(i => i.Quantity)
			.FirstOrDefault();
	}

	//	Things that are gone once used (by their English name)
	private static readonly string[] ConsumableWords =
	{
		"potion", "ration", "torch", "oil", "acid", "alchemist", "holy water", "antitoxin", "candle", "poison", "caltrops",
		"ball bearings", "chalk", "paper", "parchment", "ink", "soap", "perfume", "rope"
	};

	public static bool IsConsumable(ContextItem? item) => item is not null && item.Category != EquipmentCategory.Weapon && item.ArmorCategory is null
		&& ConsumableWords.Any(w => item.EnglishName.ToLowerInvariant().Contains(w)) && !item.EnglishName.ToLowerInvariant().Contains("case")
		&& !item.EnglishName.ToLowerInvariant().Contains("kit");

	///	<summary>
	///	One piece (or <paramref name="count"/>) used: the entry goes when nothing is left. The pieces left.
	///	</summary>
	public static int Spend(InventoryItem item, List<InventoryItem> inventory, int count = 1)
	{
		item.Quantity = Math.Max(0, item.Quantity - count);
		if (item.Quantity == 0)
		{
			inventory.Remove(item);
		}
		return item.Quantity;
	}

	private static readonly (CoinType Type, int Copper)[] Coins =
	{
		(CoinType.Cp, 1), (CoinType.Sp, 10), (CoinType.Ep, 50), (CoinType.Gp, 100), (CoinType.Pp, 1000)
	};

	private static int Get(CoinPurse purse, CoinType type) => type switch
	{
		CoinType.Cp => purse.Cp, CoinType.Sp => purse.Sp, CoinType.Ep => purse.Ep, CoinType.Pp => purse.Pp, _ => purse.Gp
	};

	private static void Set(CoinPurse purse, CoinType type, int value)
	{
		switch (type)
		{
			case CoinType.Cp: purse.Cp = value; break;
			case CoinType.Sp: purse.Sp = value; break;
			case CoinType.Ep: purse.Ep = value; break;
			case CoinType.Pp: purse.Pp = value; break;
			default: purse.Gp = value; break;
		}
	}

	public static int Total(CoinPurse purse) => Coins.Sum(c => Get(purse, c.Type) * c.Copper);

	///	<summary>
	///	Pays <paramref name="copper"/> from the purse, the small coins first; a bigger coin is broken when needed and the
	///	change comes back in gold, silver and copper. False (purse untouched) when it is not enough.
	///	</summary>
	public static bool Pay(CoinPurse purse, int copper)
	{
		if (copper <= 0)
		{
			return true;
		}
		if (Total(purse) < copper)
		{
			return false;
		}
		var left = copper;
		foreach (var (type, value) in Coins)
		{
			var take = Math.Min(Get(purse, type), left / value);
			Set(purse, type, Get(purse, type) - take);
			left -= take * value;
		}
		if (left > 0)
		{
			//	Break the smallest coin bigger than what is left
			var (type, value) = Coins.First(c => c.Copper > left && Get(purse, c.Type) > 0);
			Set(purse, type, Get(purse, type) - 1);
			var change = value - left;
			foreach (var (smaller, worth) in Coins.Where(c => c.Copper < value && c.Type != CoinType.Ep).Reverse())
			{
				Set(purse, smaller, Get(purse, smaller) + change / worth);
				change %= worth;
			}
		}
		return true;
	}
}
