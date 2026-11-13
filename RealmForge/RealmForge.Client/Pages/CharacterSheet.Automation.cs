using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	What the sheet does on its own: the conditions on the d20 tests, the weapon set in hand, the ammunition spent, the
	///	consumables used up, the dice of the features, buying from the purse.
	///	</summary>
	public partial class CharacterSheet
	{
		// ===== d20 tests with the conditions =====

		//	A check, save, attack or initiative: advantage and disadvantage from the conditions (both cancel out, with the
		//	mode chosen by hand too), the 2024 exhaustion penalty, the saves failed on their own
		private void RollTest(string label, int modifier, ConditionRules.Test test, AbilityScore? ability = null)
		{
			var effect = ConditionRules.For(Ruleset, Sheet, test, ability);
			var causes = effect.Causes.Count == 0 ? null : string.Join(", ", effect.Causes.Select(k => UiText.ConditionName(k, Lang)));
			if (effect.AutoFail)
			{
				ShowRoll(new DiceRollResult(label, new List<DieFace>(), 0, 0, UiText.RollAutoFail(causes ?? string.Empty, Lang)));
				return;
			}
			var (die, dice) = RollD20(ModeWith(effect));
			var total = modifier - effect.Penalty;
			var note = die == 20 ? UiText.RollCritical(Lang) : die == 1 ? UiText.RollFumble(Lang) : null;
			if (causes is not null)
			{
				note = string.Join(" · ", new[] { note, UiText.RollConditions(causes, effect.Penalty, Lang) }.Where(x => x is not null));
			}
			ShowRoll(new DiceRollResult(label, dice, total, die + total, note));
		}

		private RollMode ModeWith(ConditionRules.TestEffect effect)
		{
			var advantage = rollMode == RollMode.Advantage || effect.Advantage;
			var disadvantage = rollMode == RollMode.Disadvantage || effect.Disadvantage;
			return advantage == disadvantage ? RollMode.Normal : advantage ? RollMode.Advantage : RollMode.Disadvantage;
		}

		private (int Die, List<DieFace> Dice) RollD20(RollMode mode)
		{
			var first = Random.Shared.Next(1, 21);
			if (mode == RollMode.Normal)
			{
				return (first, new List<DieFace> { new(20, first) });
			}
			var second = Random.Shared.Next(1, 21);
			var keepFirst = mode == RollMode.Advantage ? first >= second : first <= second;
			return (keepFirst ? first : second, new List<DieFace> { new(20, first, !keepFirst), new(20, second, keepFirst) });
		}

		// ===== Weapons in hand and carried ready =====

		private bool InHand(InventoryItem item) => !item.Equipped || EquipmentRules.InHand(ItemOf(item),
			Sheet.Inventory.Where(i => i.Equipped).Select(ItemOf), Sheet.RangedReady);

		//	The other set to hand: a bonus action
		private void SwapWeapons()
		{
			Sheet.RangedReady = !Sheet.RangedReady;
			lastRoll = UiText.SwapDone(Lang);
			Changed();
		}

		// ===== Ammunition =====

		//	A warning about the ammunition after the last shot (few left, none)
		private string? ammoNote;

		//	A shot spends a piece of the weapon's ammunition; without any the attack does not start
		private bool SpendAmmunition(ContextItem? weapon)
		{
			ammoNote = null;
			if (InventoryRules.AmmunitionOf(weapon) is null)
			{
				return true;
			}
			if (InventoryRules.AmmunitionFor(weapon, Sheet.Inventory, ItemOf) is not { } ammo || ammo.Quantity <= 0)
			{
				ammoNote = UiText.AmmoNone(weapon!.Name, Lang);
				return false;
			}
			var name = ItemName(ammo);
			var left = InventoryRules.Spend(ammo, Sheet.Inventory);
			ammoNote = left == 0 ? UiText.AmmoLast(name, Lang) : left <= InventoryRules.LowAmmunition ? UiText.AmmoLow(name, left, Lang) : null;
			Changed();
			return true;
		}

		// ===== Consumables =====

		private bool IsConsumable(InventoryItem item) => item.Magic?.HealDice is null && InventoryRules.IsConsumable(ItemOf(item));

		private void UseItem(InventoryItem item)
		{
			var name = ItemName(item);
			var left = InventoryRules.Spend(item, Sheet.Inventory);
			lastRoll = UiText.ItemUsed(name, left, Lang);
			Changed();
		}

		// ===== The dice of the features =====

		//	"Use" spends one and rolls the feature's dice (healing goes on the hit points)
		private void UseFeature(ClassResource resource)
		{
			var left = ResourceLeft(resource);
			if (left <= 0)
			{
				return;
			}
			SetResourceLeft(resource, left - 1);
			if (computed is null || FeatureDice.Of(resource, computed) is not { } feature)
			{
				return;
			}
			var roll = RollFormula(feature.Dice) ?? (int.TryParse(feature.Dice, out var flat)
				? new DiceRollResult(resource.Name, new List<DieFace>(), flat, flat)
				: null);
			if (roll is null)
			{
				return;
			}
			roll = roll with { Label = resource.Name };
			if (feature.Heals)
			{
				var wasDown = CurrentHp == 0;
				Sheet.CurrentHitPoints = Math.Min(MaxHp, CurrentHp + roll.Total);
				if (wasDown && Sheet.CurrentHitPoints > 0)
				{
					Sheet.DeathSaveSuccesses = 0;
					Sheet.DeathSaveFailures = 0;
					deathNote = null;
				}
				roll = roll with { Note = UiText.FeatureHealed(roll.Total, Lang) };
				Changed();
			}
			ShowRoll(roll);
		}

		// ===== Buying =====

		private sealed class Purchase
		{
			public required ContextItem Item { get; init; }
			public int Quantity { get; set; } = 1;
			public bool Buy { get; set; } = true;

			//	Price in gold pieces (decimal), filled from the compendium and changed by hand (a markup, a discount)
			public decimal Price { get; set; }
			public bool PriceTouched { get; set; }
		}

		private Purchase? purchase;
		private string? purchaseError;

		private static decimal ListPrice(ContextItem item, int quantity) => (item.CostInCopper ?? 0) * quantity / 100m;

		private void StartPurchase(ContextItem item)
		{
			purchaseError = null;
			purchase = new Purchase { Item = item, Price = ListPrice(item, 1), Buy = (item.CostInCopper ?? 0) > 0 };
			itemSearch = string.Empty;
		}

		private void SetPurchaseQuantity(int quantity)
		{
			if (purchase is null)
			{
				return;
			}
			purchase.Quantity = Math.Clamp(quantity, 1, 999);
			if (!purchase.PriceTouched)
			{
				purchase.Price = ListPrice(purchase.Item, purchase.Quantity);
			}
		}

		private void SetPurchasePrice(string? text)
		{
			if (purchase is not null && decimal.TryParse((text ?? string.Empty).Replace(',', '.'), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var price))
			{
				purchase.Price = Math.Clamp(Math.Round(price, 2), 0, 1_000_000);
				purchase.PriceTouched = true;
			}
		}

		private void ConfirmPurchase()
		{
			if (purchase is not { } p)
			{
				return;
			}
			purchaseError = null;
			if (p.Buy && !InventoryRules.Pay(Sheet.Coins, (int)Math.Round(p.Price * 100)))
			{
				purchaseError = UiText.PurchaseNoMoney(Lang);
				return;
			}
			var existing = Sheet.Inventory.FirstOrDefault(i => i.EquipmentId == p.Item.Id && i.Magic is null);
			if (existing is not null)
			{
				existing.Quantity += p.Quantity;
			}
			else
			{
				Sheet.Inventory.Add(new InventoryItem { EquipmentId = p.Item.Id, Quantity = p.Quantity });
			}
			lastRoll = p.Buy ? UiText.PurchaseDone(p.Item.Name, p.Quantity, p.Price.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), Lang) : null;
			purchase = null;
			Changed();
		}
	}
}
