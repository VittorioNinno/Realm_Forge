using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What can join an attack besides the weapon itself: features that add damage only when a condition holds (Sneak
///	Attack with advantage or an ally next to the target, Rage, Divine Smite with a spell slot, Hunter's Mark…) and the
///	ones that always apply (Improved Divine Smite). The sheet asks before rolling which of the conditional ones to use.
///	</summary>
public static class AttackRiders
{
	public enum Kind
	{
		//	Extra damage dice ("3d6")
		Dice = 1,

		//	A flat bonus to the damage ("+2")
		Flat = 2,

		//	A spell slot spent for extra dice (Divine Smite): Dice is the dice of the lowest level
		SlotDice = 3,

		//	A penalty to the attack roll for a bonus to the damage (Great Weapon Master, Sharpshooter 2014)
		PowerAttack = 4
	}

	///	<summary>
	///	One option: its key, the dice or the bonus, whether the sheet applies it without asking, and whether it works once
	///	per turn. Name and condition texts come from the client (by key).
	///	</summary>
	public sealed record Rider(string Key, Kind Kind, string? Dice, int Flat, bool Automatic, bool OncePerTurn);

	private static int ClassLevel(ComputedCharacter c, string key) => c.Classes.Where(x => x.Class.Key == key).Sum(x => x.Level);

	private static bool HasSubclass(ComputedCharacter c, string key) => c.Classes.Any(x => x.Subclass?.Key == key);

	private static bool HasFeat(ComputedCharacter c, string key) => c.Feats.Any(f => f.Feat.Key == key);

	private static bool Ranged(ContextItem item) => item.WeaponRange == WeaponRange.Ranged;

	private static bool Melee(ContextItem item) => item.WeaponRange != WeaponRange.Ranged;

	///	<summary>
	///	The riders that fit an attack with <paramref name="item"/> (null: an unarmed strike), given the spell the
	///	character concentrates on (its key).
	///	</summary>
	public static List<Rider> For(ComputedCharacter c, ContextItem? item, string? concentrationKey)
	{
		var riders = new List<Rider>();
		var weapon = item is not null && item.Category == EquipmentCategory.Weapon;

		//	Sneak Attack: finesse or ranged weapon, with advantage or an ally within 5 feet of the target, once per turn
		var rogue = ClassLevel(c, "rogue");
		if (rogue > 0 && weapon && (item!.WeaponProperties.Contains(WeaponProperty.Finesse) || Ranged(item)))
		{
			riders.Add(new Rider("sneak-attack", Kind.Dice, $"{(rogue + 1) / 2}d6", 0, false, true));
		}

		//	Rage: melee attacks with Strength while raging
		var barbarian = ClassLevel(c, "barbarian");
		if (barbarian > 0 && (item is null || (weapon && Melee(item))) && (item is null || !item.WeaponProperties.Contains(WeaponProperty.Finesse)
			|| c.Score(AbilityScore.Strength) >= c.Score(AbilityScore.Dexterity)))
		{
			riders.Add(new Rider("rage", Kind.Flat, null, barbarian >= 16 ? 4 : barbarian >= 9 ? 3 : 2, false, false));
		}

		//	Divine Smite: a melee weapon hit, a spell slot for 2d8 (+1d8 per level above the 1st, at most 5d8; +1d8 against
		//	undead and fiends); from the 11th level every melee hit deals 1d8 radiant damage more
		var paladin = ClassLevel(c, "paladin");
		if (paladin >= 2 && weapon && Melee(item!))
		{
			riders.Add(new Rider("divine-smite", Kind.SlotDice, "2d8", 0, false, false));
		}
		if (paladin >= 11 && weapon && Melee(item!))
		{
			riders.Add(new Rider("improved-smite", Kind.Dice, "1d8", 0, true, false));
		}

		//	Colossus Slayer (Hunter): 1d8 once per turn against a creature below its hit point maximum
		if (HasSubclass(c, "hunter") && weapon)
		{
			riders.Add(new Rider("colossus-slayer", Kind.Dice, "1d8", 0, false, true));
		}

		//	Hunter's Mark and Hex while concentrating on them: 1d6 against the marked target
		if (concentrationKey is "hunters-mark" or "hex" && (weapon || concentrationKey == "hex"))
		{
			riders.Add(new Rider(concentrationKey, Kind.Dice, "1d6", 0, false, false));
		}

		//	Great Weapon Master and Sharpshooter: 2014 −5 to hit for +10 damage; 2024 Great Weapon Master adds the
		//	proficiency bonus to the damage of a heavy weapon hit (part of the Attack action)
		if (weapon && item!.WeaponProperties.Contains(WeaponProperty.Heavy) && Melee(item) && HasFeat(c, "great-weapon-master"))
		{
			riders.Add(c.Ruleset == RulesetVersion.Dnd5e_2014
				? new Rider("great-weapon-master", Kind.PowerAttack, null, 10, false, false)
				: new Rider("great-weapon-master", Kind.Flat, null, c.ProficiencyBonus, false, false));
		}
		if (weapon && Ranged(item!) && HasFeat(c, "sharpshooter") && c.Ruleset == RulesetVersion.Dnd5e_2014)
		{
			riders.Add(new Rider("sharpshooter", Kind.PowerAttack, null, 10, false, false));
		}
		return riders;
	}

	///	<summary>
	///	Dice of Divine Smite with a slot of <paramref name="slotLevel"/>: 2d8 at the 1st level, 1d8 more per level above,
	///	at most 5d8; one more against undead and fiends.
	///	</summary>
	public static string SmiteDice(int slotLevel, bool undeadOrFiend) =>
		$"{Math.Min(5, 1 + slotLevel) + (undeadOrFiend ? 1 : 0)}d8";
}
