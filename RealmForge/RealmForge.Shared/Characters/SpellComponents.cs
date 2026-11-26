using System.Text.RegularExpressions;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What casting a spell asks of the caster's hands and pack: a free hand for the somatic components (War Caster does
///	without; the hand holding a focus or a component pouch does them for a spell with a material component, so does a
///	shield with a holy emblem), a focus or a component pouch for the material components without a price, the
///	material itself for those with one (a focus cannot replace it), spent when the spell consumes it. Subtle Spell
///	does without the verbal and the somatic components.
///	</summary>
public static partial class SpellComponents
{
	public enum Problem
	{
		None = 0,
		NoHand = 1,
		NoFocus = 2
	}

	///	<summary>What the caster has at hand for the components.</summary>
	public sealed record Kit(int FreeHands, bool Focus, bool Pouch, bool ShieldEmblem, bool WarCaster);

	//	The price in gold pieces a material component names ("a diamond worth 300 gp", "un diamante da 300 mo"); null:
	//	none (a focus or a component pouch replaces it)
	public static int? Price(string? material)
	{
		var m = PriceRegex().Match(material ?? string.Empty);
		return m.Success && int.TryParse(m.Groups[1].Value.Replace(".", string.Empty).Replace(",", string.Empty), out var gold) ? gold : null;
	}

	//	The spell consumes its material component
	public static bool Consumed(string? material) => ConsumedRegex().IsMatch(material ?? string.Empty);

	///	<summary>What stops the casting, if anything.</summary>
	public static Problem Check(bool somatic, bool material, string? materialText, bool subtle, Kit kit)
	{
		var priced = material && Price(materialText) is not null;
		//	A hand that holds the focus (or the pouch, or the emblem on the shield) serves a spell with a material component
		var focusHand = material && (kit.Focus || kit.Pouch || kit.ShieldEmblem);
		if (somatic && !subtle && kit.FreeHands < 1 && !kit.WarCaster && !focusHand)
		{
			return Problem.NoHand;
		}
		if (material && !priced && !kit.Focus && !kit.Pouch && !kit.ShieldEmblem)
		{
			return Problem.NoFocus;
		}
		if (material && kit.FreeHands < 1 && !focusHand && !kit.WarCaster)
		{
			return Problem.NoHand;
		}
		return Problem.None;
	}

	///	<summary>The kit of a character: its equipped weapons and shield fill its hands, its pack holds the rest.</summary>
	public static Kit KitOf(ComputedCharacter c, IEnumerable<InventoryItem> inventory, Func<InventoryItem, ContextItem?> lookup)
	{
		var items = inventory.Select(i => (Item: i, Context: lookup(i))).ToList();
		var used = items.Where(x => x.Item.Equipped).Sum(x => EquipmentRules.Hands(x.Context));
		string Name(InventoryItem i, ContextItem? ctx) => $"{ctx?.EnglishName} {ctx?.Name} {i.Name}";
		var focus = items.Any(x => x.Context?.Category == EquipmentCategory.SpellcastingFocus);
		var pouch = items.Any(x => PouchRegex().IsMatch(Name(x.Item, x.Context)));
		var shield = items.Any(x => x.Item.Equipped && x.Context?.ArmorCategory == ArmorCategory.Shield);
		var emblem = shield && items.Any(x => x.Context?.Category == EquipmentCategory.SpellcastingFocus && EmblemRegex().IsMatch(Name(x.Item, x.Context)));
		var warCaster = c.Feats.Any(f => f.Feat.Key is "war-caster" || f.Feat.Name.Contains("war caster", StringComparison.OrdinalIgnoreCase)
			|| f.Feat.Name.Contains("incantatore da guerra", StringComparison.OrdinalIgnoreCase) || f.Feat.Name.Contains("incantatore guerriero", StringComparison.OrdinalIgnoreCase));
		return new Kit(Math.Max(0, 2 - used), focus, pouch, emblem, warCaster);
	}

	[GeneratedRegex(@"(\d[\d\.,]*)\s*(?:mo|gp|monete d'oro|pezzi d'oro|gold)\b", RegexOptions.IgnoreCase)]
	private static partial Regex PriceRegex();

	[GeneratedRegex(@"consum|che l'incantesimo distrugge|which the spell destroys", RegexOptions.IgnoreCase)]
	private static partial Regex ConsumedRegex();

	[GeneratedRegex(@"component pouch|borsa (?:per|delle|di) componenti", RegexOptions.IgnoreCase)]
	private static partial Regex PouchRegex();

	[GeneratedRegex(@"emblem|emblema", RegexOptions.IgnoreCase)]
	private static partial Regex EmblemRegex();
}
