using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	When a magic item works and what its effects add up to. An item works while it is worn or wielded (equipped) and,
///	if it needs attunement, attuned; a creature can be attuned to at most three items (both editions).
///	</summary>
public static class MagicItemRules
{
	public const int MaxAttuned = 3;

	public static bool Works(InventoryItem item) =>
		item.Magic is { } magic && item.Equipped && item.Quantity > 0 && (!magic.RequiresAttunement || item.Attuned);

	//	Effects of every working item, except the bonus of a weapon, which only counts for that weapon
	public static IEnumerable<MagicEffect> ActiveEffects(CharacterSheetState sheet) => sheet.Inventory
		.Where(Works)
		.SelectMany(i => i.Magic!.Effects)
		.Where(e => e.Kind != MagicEffectKind.AttackAndDamage);

	public static int Sum(CharacterSheetState sheet, MagicEffectKind kind) =>
		ActiveEffects(sheet).Where(e => e.Kind == kind).Sum(e => e.Value);

	public static int WeaponBonus(InventoryItem item) => Works(item)
		? item.Magic!.Effects.Where(e => e.Kind == MagicEffectKind.AttackAndDamage).Sum(e => e.Value)
		: 0;

	public static int AttunedCount(CharacterSheetState sheet) =>
		sheet.Inventory.Count(i => i.Attuned && i.Magic?.RequiresAttunement == true);

	///	<summary>
	///	Ability scores with the items that set a score (Gauntlets of Ogre Power: 19, it never lowers it) and then
	///	the ones that add to it.
	///	</summary>
	public static void ApplyToScores(CharacterSheetState sheet, int[] scores)
	{
		var effects = ActiveEffects(sheet).Where(e => e.Ability is not null).ToList();
		foreach (var effect in effects.Where(e => e.Kind == MagicEffectKind.SetAbilityScore))
		{
			var index = (int)effect.Ability!.Value - 1;
			scores[index] = Math.Max(scores[index], effect.Value);
		}
		foreach (var effect in effects.Where(e => e.Kind == MagicEffectKind.AbilityScoreBonus))
		{
			scores[(int)effect.Ability!.Value - 1] += effect.Value;
		}
	}
}
