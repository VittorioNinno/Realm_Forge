using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Turns the chosen starting equipment into the inventory: compendium items (the first body armor and a shield worn,
///	weapons ready), the items picked for the generic lines, free entries and the coins in the purse. The wizard uses it
///	for the preview, the API when the character is created, so both show the same Armor Class and attacks.
///	</summary>
public static class StartingEquipment
{
	public static (List<InventoryItem> Items, CoinPurse Coins) Build(CharacterBuild build, CharacterContextDto context, Guid backgroundId)
	{
		var items = context.Items.ToDictionary(i => i.Id);
		var picks = build.EquipmentPicks.GroupBy(p => p.Slot).ToDictionary(g => g.Key, g => g.First().Items);
		var background = context.Backgrounds.FirstOrDefault(b => b.Id == backgroundId);
		var cls = build.Levels.Count > 0 ? context.Classes.FirstOrDefault(c => c.Id == build.Levels[0].ClassId) : null;

		var chosen = CharacterCalculator.ChosenOptions("background", background?.Equipment ?? ContextLoadout.Empty,
				build.BackgroundEquipment is null ? new List<string>() : new List<string> { build.BackgroundEquipment })
			.Concat(CharacterCalculator.ChosenOptions("class", cls?.Equipment ?? ContextLoadout.Empty, build.ClassEquipment));

		var inventory = new List<InventoryItem>();
		var coins = new CoinPurse();
		var bodyArmorWorn = false;

		void Add(Guid? equipmentId, string? name, int quantity)
		{
			var item = equipmentId is { } id && items.TryGetValue(id, out var it) ? it : null;
			var existing = item is not null
				? inventory.FirstOrDefault(i => i.EquipmentId == item.Id)
				: inventory.FirstOrDefault(i => i.EquipmentId is null && i.Name == name);
			if (existing is not null)
			{
				existing.Quantity += quantity;
				return;
			}

			var equipped = false;
			if (item?.ArmorCategory is ArmorCategory.Shield)
			{
				equipped = inventory.All(i => i.EquipmentId is not { } other || items[other].ArmorCategory != ArmorCategory.Shield || !i.Equipped);
			}
			else if (item?.ArmorCategory is not null && !bodyArmorWorn)
			{
				equipped = bodyArmorWorn = true;
			}
			else if (item?.Category == EquipmentCategory.Weapon)
			{
				equipped = true;
			}

			inventory.Add(new InventoryItem { EquipmentId = item?.Id, Name = item is null ? name : null, Quantity = quantity, Equipped = equipped });
		}

		foreach (var (slot, entry) in chosen)
		{
			if (entry.CoinAmount is { } amount)
			{
				switch (entry.CoinType)
				{
					case CoinType.Cp: coins.Cp += amount; break;
					case CoinType.Sp: coins.Sp += amount; break;
					case CoinType.Ep: coins.Ep += amount; break;
					case CoinType.Pp: coins.Pp += amount; break;
					default: coins.Gp += amount; break;
				}
			}

			if (entry.Pick is not null)
			{
				foreach (var pickId in (picks.GetValueOrDefault(slot) ?? new List<Guid>()).Where(items.ContainsKey))
				{
					Add(pickId, null, 1);
				}
			}
			else if (entry.EquipmentId is not null)
			{
				Add(entry.EquipmentId, null, entry.Quantity);
			}
			else if (entry.CoinAmount is null && !string.IsNullOrWhiteSpace(entry.Label))
			{
				Add(null, entry.Label, entry.Quantity);
			}
		}

		return (inventory, coins);
	}
}
