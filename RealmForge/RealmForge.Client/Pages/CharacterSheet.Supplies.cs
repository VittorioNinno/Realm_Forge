using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	The supplies of the journey (rations, torches, ammunition) at a glance, half the ammunition shot picked up after
	///	the fight, and the spells that last on the clock of the campaign (they end when the master moves the time on).
	///	</summary>
	public partial class CharacterSheet
	{
		private sealed record SupplyEntry(InventoryItem Item, InventoryRules.Supply Kind, string Name);

		private string? suppliesNote;

		private List<SupplyEntry> SupplyEntries => Sheet.Inventory
			.Select(i => (Item: i, Kind: InventoryRules.SupplyOf(i, ItemOf(i)?.EnglishName)))
			.Where(x => x.Kind is not null)
			.Select(x => new SupplyEntry(x.Item, x.Kind!.Value, ItemName(x.Item)))
			.OrderBy(x => x.Kind).ThenBy(x => x.Name)
			.ToList();

		private static string SupplyIcon(InventoryRules.Supply kind) => kind switch
		{
			InventoryRules.Supply.Rations => "basket",
			InventoryRules.Supply.Torches => "fire",
			_ => "bullseye"
		};

		private void StepSupply(InventoryItem item, int step)
		{
			suppliesNote = null;
			if (step < 0)
			{
				InventoryRules.Spend(item, Sheet.Inventory);
			}
			else
			{
				item.Quantity = Math.Min(99999, item.Quantity + step);
			}
			Changed();
		}

		private void RecoverAmmunition()
		{
			var back = InventoryRules.RecoverAmmunition(Sheet);
			suppliesNote = UiText.SuppliesRecovered(back, Lang);
			Changed();
		}

		//	A spell cast from the sheet that lasts at least ten minutes runs on the clock of the campaign
		private void StartTimedEffect(ContextSpell spell)
		{
			if (spell.Minutes is not { } minutes || character?.ClockCampaignId is not { } campaignId || character.GameMinutes is not { } now)
			{
				return;
			}
			Sheet.TimedEffects.RemoveAll(e => e.SpellId == spell.Id && e.CampaignId == campaignId);
			Sheet.TimedEffects.Add(new TimedEffect { Name = spell.Name, SpellId = spell.Id, CampaignId = campaignId, Until = now + minutes });
		}

		private void EndTimedEffect(TimedEffect effect)
		{
			Sheet.TimedEffects.Remove(effect);
			if (effect.SpellId is { } spell && Sheet.Concentration == spell)
			{
				Sheet.Concentration = null;
			}
			Changed();
		}

		//	The inventory and the purse changed at the table (a shop, the rations of a journey, loot)
		private void ApplyStore(SheetVitalsDto vitals)
		{
			vitals.ApplyStoreTo(Sheet);
			vitalsNote = UiText.SheetStoreChanged(Lang);
			Recompute();
		}
	}
}
