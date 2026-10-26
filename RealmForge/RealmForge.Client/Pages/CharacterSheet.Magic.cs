using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Magic items on the sheet: the editor, attunement, charges and their recharge, potions that heal.
	///	</summary>
	public partial class CharacterSheet
	{
		private bool magicEditorOpen;
		private InventoryItem? magicTarget;
		private string? attuneError;

		private void OpenMagic(InventoryItem item)
		{
			magicTarget = item;
			magicEditorOpen = true;
		}

		private void OpenNewMagic()
		{
			magicTarget = null;
			magicEditorOpen = true;
		}

		private MagicTemplateKind? MagicKindOf(InventoryItem? item) => item is null ? null : ItemOf(item) switch
		{
			{ Category: EquipmentCategory.Weapon } => MagicTemplateKind.Weapon,
			{ ArmorCategory: ArmorCategory.Shield } => MagicTemplateKind.Shield,
			{ ArmorCategory: not null } => MagicTemplateKind.Armor,
			_ => null
		};

		private void SaveMagic((string? Name, MagicItemProperties? Magic) result)
		{
			if (magicTarget is null)
			{
				if (result.Magic is not null && !string.IsNullOrWhiteSpace(result.Name))
				{
					Sheet.Inventory.Add(new InventoryItem { Name = result.Name, Magic = result.Magic, Quantity = 1 });
				}
			}
			else
			{
				magicTarget.Magic = result.Magic;
				if (result.Magic?.RequiresAttunement != true)
				{
					magicTarget.Attuned = false;
				}
			}
			magicEditorOpen = false;
			magicTarget = null;
			Changed();
		}

		private string MagicLine(MagicItemProperties magic) => string.Join(" · ", magic.Effects.Select(e => UiText.MagicEffectText(e, Lang))
			.Concat(magic.HealDice is { } heal ? new[] { UiText.MagicHeals(heal, Lang) } : Array.Empty<string>()));

		// ===== Charges =====

		private void ToggleCharge(InventoryItem item, int index)
		{
			if (item.Magic is not { } magic)
			{
				return;
			}
			magic.ChargesUsed = index < magic.ChargesUsed ? index : index + 1;
			Changed();
		}

		private void UseCharge(InventoryItem item)
		{
			if (item.Magic is { } magic && magic.ChargesUsed < magic.Charges)
			{
				magic.ChargesUsed++;
				Changed();
			}
		}

		//	Charges back with a rest: the dice of the item ("1d6+1" each dawn) or all of them
		private void RechargeItems(bool longRest)
		{
			foreach (var item in Sheet.Inventory.Where(i => i.Magic is { Charges: > 0, ChargesUsed: > 0 }))
			{
				var magic = item.Magic!;
				if (magic.Recharge == ItemRecharge.None || (!longRest && magic.Recharge != ItemRecharge.ShortRest))
				{
					continue;
				}
				if (magic.RechargeDice is { } dice && RollFormula(dice) is { } roll)
				{
					magic.ChargesUsed = Math.Max(0, magic.ChargesUsed - roll.Total);
					ShowRoll(roll with { Label = $"{UiText.MagicRecharged(Lang)} · {ItemName(item)}" });
				}
				else
				{
					magic.ChargesUsed = 0;
				}
			}
		}

		// ===== Potions =====

		private void Drink(InventoryItem item)
		{
			if (item.Magic?.HealDice is not { } dice || item.Quantity <= 0 || RollFormula(dice) is not { } roll)
			{
				return;
			}
			ShowRoll(roll with { Label = ItemName(item) });
			var wasDown = CurrentHp == 0;
			Sheet.CurrentHitPoints = Math.Min(MaxHp, CurrentHp + roll.Total);
			if (wasDown && Sheet.CurrentHitPoints > 0)
			{
				Sheet.DeathSaveSuccesses = 0;
				Sheet.DeathSaveFailures = 0;
				deathNote = null;
			}
			item.Quantity--;
			if (item.Quantity <= 0)
			{
				Sheet.Inventory.Remove(item);
			}
			Changed();
		}

		//	"2d4+2" rolled for the tray
		private static DiceRollResult? RollFormula(string formula)
		{
			var match = System.Text.RegularExpressions.Regex.Match(formula.Replace('−', '-'), @"^(\d+)d(\d+)\s*([+-]\s*\d+)?$");
			if (!match.Success)
			{
				return null;
			}
			var count = Math.Min(20, int.Parse(match.Groups[1].Value));
			var size = int.Parse(match.Groups[2].Value);
			var bonus = match.Groups[3].Success ? int.Parse(match.Groups[3].Value.Replace(" ", string.Empty)) : 0;
			var rolls = Enumerable.Range(0, count).Select(_ => Random.Shared.Next(1, size + 1)).ToList();
			return new DiceRollResult(formula, rolls.Select(r => new DieFace(size, r)).ToList(), bonus, Math.Max(0, rolls.Sum() + bonus));
		}
	}
}
