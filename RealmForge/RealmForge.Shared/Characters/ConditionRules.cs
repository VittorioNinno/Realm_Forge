using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What the conditions and the exhaustion do to a character's numbers and rolls, as the rules of each edition say:
///	advantage and disadvantage on d20 tests, saves failed on their own, the speed, the hit point maximum.
///	</summary>
public static class ConditionRules
{
	public enum Test
	{
		Check = 1,
		Save = 2,
		Attack = 3,
		Initiative = 4
	}

	///	<summary>
	///	The effect on one d20 test: advantage / disadvantage (both cancel out), a penalty, an automatic failure, and the
	///	conditions that cause them (for the label of the roll).
	///	</summary>
	public sealed record TestEffect(bool Advantage, bool Disadvantage, int Penalty, bool AutoFail, IReadOnlyList<string> Causes)
	{
		public static readonly TestEffect None = new(false, false, 0, false, Array.Empty<string>());
	}

	private static bool Has(CharacterSheetState sheet, string key) => sheet.Conditions.Contains(key);

	public static TestEffect For(RulesetVersion ruleset, CharacterSheetState sheet, Test test, AbilityScore? ability = null)
	{
		var advantage = false;
		var disadvantage = false;
		var autoFail = false;
		var causes = new List<string>();
		void Dis(string key)
		{
			disadvantage = true;
			causes.Add(key);
		}

		var exhaustion = Math.Clamp(sheet.Exhaustion, 0, 6);
		switch (test)
		{
			case Test.Attack:
				foreach (var key in new[] { "blinded", "frightened", "poisoned", "prone", "restrained" }.Where(k => Has(sheet, k)))
				{
					Dis(key);
				}
				if (Has(sheet, "invisible"))
				{
					advantage = true;
					causes.Add("invisible");
				}
				break;
			case Test.Check or Test.Initiative:
				foreach (var key in new[] { "frightened", "poisoned" }.Where(k => Has(sheet, k)))
				{
					Dis(key);
				}
				if (test == Test.Initiative && ruleset == RulesetVersion.Dnd5e_2024 && Has(sheet, "invisible"))
				{
					advantage = true;
					causes.Add("invisible");
				}
				if (test == Test.Initiative && ruleset == RulesetVersion.Dnd5e_2024 && Has(sheet, "incapacitated"))
				{
					Dis("incapacitated");
				}
				break;
			case Test.Save:
				if (ability == AbilityScore.Dexterity && Has(sheet, "restrained"))
				{
					Dis("restrained");
				}
				if (ability is AbilityScore.Strength or AbilityScore.Dexterity
					&& new[] { "paralyzed", "petrified", "stunned", "unconscious" }.FirstOrDefault(k => Has(sheet, k)) is { } failing)
				{
					autoFail = true;
					causes.Add(failing);
				}
				break;
		}

		var penalty = 0;
		if (exhaustion > 0)
		{
			if (ruleset == RulesetVersion.Dnd5e_2024)
			{
				//	2024: every d20 test −2 per level
				penalty = 2 * exhaustion;
				causes.Add("exhaustion");
			}
			else if (test is Test.Check or Test.Initiative || (exhaustion >= 3 && test is Test.Attack or Test.Save))
			{
				//	2014: level 1 checks with disadvantage, level 3 attacks and saves too
				Dis("exhaustion");
			}
		}
		return new TestEffect(advantage, disadvantage, penalty, autoFail, causes.Distinct().ToList());
	}

	///	<summary>
	///	The speed with the conditions: 0 when grappled, restrained, paralyzed, petrified, stunned, unconscious (or 2014
	///	exhaustion 5); halved by 2014 exhaustion 2; 2024 exhaustion −5 feet per level.
	///	</summary>
	public static int Speed(RulesetVersion ruleset, CharacterSheetState sheet, int speed)
	{
		if (new[] { "grappled", "restrained", "paralyzed", "petrified", "stunned", "unconscious" }.Any(k => Has(sheet, k)))
		{
			return 0;
		}
		var exhaustion = Math.Clamp(sheet.Exhaustion, 0, 6);
		if (ruleset == RulesetVersion.Dnd5e_2024)
		{
			return Math.Max(0, speed - 5 * exhaustion);
		}
		return exhaustion >= 5 ? 0 : exhaustion >= 2 ? speed / 2 : speed;
	}

	///	<summary>
	///	The hit point maximum: halved by 2014 exhaustion 4.
	///	</summary>
	public static int MaxHitPoints(RulesetVersion ruleset, CharacterSheetState sheet, int max) =>
		ruleset == RulesetVersion.Dnd5e_2014 && sheet.Exhaustion >= 4 ? Math.Max(1, max / 2) : max;
}
