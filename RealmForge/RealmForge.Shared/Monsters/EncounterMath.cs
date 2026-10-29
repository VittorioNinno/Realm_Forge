using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Monsters;

///	<summary>
///	How hard an encounter is for the party, with the experience budgets of each edition:
///	- 2014: thresholds easy / medium / hard / deadly per character level; the monsters' XP is multiplied by a factor
///	  that grows with their number (one step more for parties under three characters, one less from six up);
///	- 2024: budgets low / moderate / high per character level, compared with the plain total of the monsters' XP.
///	</summary>
public static class EncounterMath
{
	//	2014: easy, medium, hard, deadly for levels 1-20
	private static readonly int[,] Thresholds2014 =
	{
		{ 25, 50, 75, 100 }, { 50, 100, 150, 200 }, { 75, 150, 225, 400 }, { 125, 250, 375, 500 }, { 250, 500, 750, 1100 },
		{ 300, 600, 900, 1400 }, { 350, 750, 1100, 1700 }, { 450, 900, 1400, 2100 }, { 550, 1100, 1600, 2400 }, { 600, 1200, 1900, 2800 },
		{ 800, 1600, 2400, 3600 }, { 1000, 2000, 3000, 4500 }, { 1100, 2200, 3400, 5100 }, { 1250, 2500, 3800, 5700 }, { 1400, 2800, 4300, 6400 },
		{ 1600, 3200, 4800, 7200 }, { 2000, 3900, 5900, 8800 }, { 2100, 4200, 6300, 9500 }, { 2400, 4900, 7300, 10900 }, { 2800, 5700, 8500, 12700 }
	};

	//	2024: low, moderate, high for levels 1-20
	private static readonly int[,] Budgets2024 =
	{
		{ 50, 75, 100 }, { 100, 150, 200 }, { 150, 225, 400 }, { 250, 375, 500 }, { 500, 750, 1100 },
		{ 600, 1000, 1400 }, { 750, 1300, 1700 }, { 1000, 1700, 2100 }, { 1300, 2000, 2600 }, { 1600, 2300, 3100 },
		{ 1900, 2900, 4100 }, { 2200, 3700, 4700 }, { 2600, 4200, 5400 }, { 2900, 4900, 6200 }, { 3300, 5400, 7800 },
		{ 3800, 6100, 9800 }, { 4500, 7200, 11700 }, { 5000, 8700, 14200 }, { 5500, 10700, 17200 }, { 6400, 13200, 22000 }
	};

	private static readonly double[] Multipliers = { 0.5, 1, 1.5, 2, 2.5, 3, 4, 5 };

	///	<summary>
	///	The 2014 multiplier for this many monsters and characters.
	///	</summary>
	public static double Multiplier(int monsters, int characters)
	{
		if (monsters <= 0)
		{
			return 1;
		}
		var step = monsters switch
		{
			1 => 1,
			2 => 2,
			<= 6 => 3,
			<= 10 => 4,
			<= 14 => 5,
			_ => 6
		};
		if (characters is > 0 and < 3)
		{
			step++;
		}
		else if (characters >= 6)
		{
			step--;
		}
		return Multipliers[Math.Clamp(step, 0, Multipliers.Length - 1)];
	}

	///	<summary>
	///	Thresholds of the party (2014: easy, medium, hard, deadly; 2024: low, moderate, high).
	///	</summary>
	public static int[] Thresholds(RulesetVersion ruleset, IEnumerable<int> levels)
	{
		var table = ruleset == RulesetVersion.Dnd5e_2014 ? Thresholds2014 : Budgets2024;
		var columns = table.GetLength(1);
		var sums = new int[columns];
		foreach (var level in levels)
		{
			var row = Math.Clamp(level, 1, 20) - 1;
			for (var c = 0; c < columns; c++)
			{
				sums[c] += table[row, c];
			}
		}
		return sums;
	}

	///	<summary>
	///	The rating of an encounter for the party.
	///	</summary>
	public static EncounterBudget Evaluate(RulesetVersion ruleset, IReadOnlyCollection<int> partyLevels, IReadOnlyCollection<int> monsterXp)
	{
		var total = monsterXp.Sum();
		var multiplier = ruleset == RulesetVersion.Dnd5e_2014 ? Multiplier(monsterXp.Count, partyLevels.Count) : 1;
		var adjusted = (int)Math.Round(total * multiplier);
		var thresholds = partyLevels.Count == 0 ? Array.Empty<int>() : Thresholds(ruleset, partyLevels);
		var rating = thresholds.Count(t => adjusted >= t);
		return new EncounterBudget(ruleset, total, multiplier, adjusted, thresholds, rating);
	}
}

///	<summary>
///	Result of <see cref="EncounterMath.Evaluate"/>. Rating counts the thresholds reached: in 2014 0 = trivial,
///	1 = easy, 2 = medium, 3 = hard, 4 = deadly; in 2024 0 = under the low budget, 1 = low, 2 = moderate, 3 = high.
///	</summary>
public sealed record EncounterBudget(RulesetVersion Ruleset, int TotalXp, double Multiplier, int AdjustedXp, int[] Thresholds, int Rating)
{
	//	XP each character earns when the encounter is won (the plain total, split evenly)
	public int XpPerCharacter(int characters) => characters <= 0 ? 0 : TotalXp / characters;
}
