using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Damage, healing and death saves on a character's sheet, the same wherever they happen (the sheet, the table, an
///	enemy's hit): temporary hit points first; dropping to 0 makes the character unconscious and prone, ends concentration
///	and starts the death saves; a hit at 0 is a failed save (two on a critical hit); damage of at least the maximum is
///	instant death; healing from 0 wakes the character (still prone) and clears the saves.
///	</summary>
public static class CharacterVitals
{
	public const string Unconscious = "unconscious";
	public const string Prone = "prone";

	public sealed record DamageOutcome(bool Dropped, bool HitWhileDown, bool InstantDeath, int? ConcentrationDc);

	public static int Current(CharacterSheetState sheet, int max) => Math.Clamp(sheet.CurrentHitPoints ?? max, 0, Math.Max(0, max));

	public static bool Down(CharacterSheetState sheet, int max) => max > 0 && Current(sheet, max) == 0;

	public static DamageOutcome Damage(CharacterSheetState sheet, int max, int value, bool critical, RulesetVersion? ruleset)
	{
		value = Math.Max(0, value);
		if (value == 0 || max <= 0)
		{
			return new DamageOutcome(false, false, false, null);
		}
		var wasDown = Down(sheet, max);
		var current = Current(sheet, max);
		var fromTemp = Math.Min(sheet.TemporaryHitPoints, value);
		sheet.TemporaryHitPoints -= fromTemp;
		var rest = value - fromTemp;
		if (rest == 0)
		{
			return new DamageOutcome(false, false, false, null);
		}
		if (wasDown)
		{
			if (rest >= max)
			{
				sheet.DeathSaveFailures = 3;
				return new DamageOutcome(false, true, true, null);
			}
			//	A stable character is no longer stable
			if (sheet.DeathSaveSuccesses >= 3)
			{
				sheet.DeathSaveSuccesses = 0;
			}
			sheet.DeathSaveFailures = Math.Min(3, sheet.DeathSaveFailures + (critical ? 2 : 1));
			return new DamageOutcome(false, true, false, null);
		}
		var left = current - rest;
		sheet.CurrentHitPoints = Math.Max(0, left) >= max ? null : Math.Max(0, left);
		if (left > 0)
		{
			if (sheet.Concentration is null)
			{
				return new DamageOutcome(false, false, false, null);
			}
			//	Constitution save to keep concentrating: half the damage, at least 10 (2024: at most 30)
			var dc = Math.Max(10, value / 2);
			return new DamageOutcome(false, false, false, ruleset == RulesetVersion.Dnd5e_2024 ? Math.Min(30, dc) : dc);
		}
		sheet.Concentration = null;
		sheet.DeathSaveSuccesses = 0;
		sheet.DeathSaveFailures = -left >= max ? 3 : 0;
		Fall(sheet);
		return new DamageOutcome(true, false, -left >= max, null);
	}

	public static void Heal(CharacterSheetState sheet, int max, int amount)
	{
		if (amount <= 0 || max <= 0 || sheet.DeathSaveFailures >= 3)
		{
			return;
		}
		var wasDown = Down(sheet, max);
		var hp = Math.Min(max, Current(sheet, max) + amount);
		sheet.CurrentHitPoints = hp >= max ? null : hp;
		if (wasDown)
		{
			Wake(sheet);
		}
	}

	//	Down at 0: unconscious and prone
	public static void Fall(CharacterSheetState sheet)
	{
		foreach (var key in new[] { Unconscious, Prone })
		{
			if (!sheet.Conditions.Contains(key))
			{
				sheet.Conditions.Add(key);
			}
		}
	}

	//	Back over 0: awake, the saves cleared (still prone until standing up)
	public static void Wake(CharacterSheetState sheet)
	{
		sheet.Conditions.Remove(Unconscious);
		sheet.DeathSaveSuccesses = 0;
		sheet.DeathSaveFailures = 0;
	}

	public sealed record DeathSaveOutcome(int Die, bool Success, bool Twenty, bool One, bool Stable, bool Dead);

	///	<summary>
	///	A death save rolled (the d20 given): 10 or more a success, a 20 wakes with 1 hit point, a 1 two failures; three
	///	successes stable, three failures dead.
	///	</summary>
	public static DeathSaveOutcome DeathSave(CharacterSheetState sheet, int max, int die)
	{
		if (die == 20)
		{
			sheet.CurrentHitPoints = Math.Min(1, max);
			Wake(sheet);
			return new DeathSaveOutcome(die, true, true, false, false, false);
		}
		if (die >= 10)
		{
			sheet.DeathSaveSuccesses = Math.Min(3, sheet.DeathSaveSuccesses + 1);
		}
		else
		{
			sheet.DeathSaveFailures = Math.Min(3, sheet.DeathSaveFailures + (die == 1 ? 2 : 1));
		}
		return new DeathSaveOutcome(die, die >= 10, false, die == 1, sheet.DeathSaveSuccesses >= 3, sheet.DeathSaveFailures >= 3);
	}
}
