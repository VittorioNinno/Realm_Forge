using System.Text.RegularExpressions;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Rules
{
	///	<summary>
	///	Spells a character of a class can pick at a level: cantrips, leveled spells and the highest spell level available.
	///	</summary>
	public sealed record SpellAllowance(int Cantrips, int Spells, int MaxSpellLevel)
	{
		public static readonly SpellAllowance None = new(0, 0, 0);
		public bool IsNone => Cantrips == 0 && Spells == 0;
	}

	///	<summary>
	///	Armor worn by a character: category, base AC, Dexterity cap (null = no cap, 0 = no Dexterity).
	///	</summary>
	public sealed record WornArmor(ArmorCategory Category, int ArmorClass, bool AddsDexterity, int? MaxDexterity);

	///	<summary>
	///	Rules arithmetic of a character, shared by the creation wizard, the sheet and the API (which checks what it stores).
	///	</summary>
	public static partial class CharacterMath
	{
		public const int PointBuyBudget = 27;
		public static readonly IReadOnlyList<int> StandardArray = new[] { 15, 14, 13, 12, 10, 8 };
		public static readonly IReadOnlyList<AbilityScore> Abilities = new[]
		{
			AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Constitution,
			AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma
		};

		public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

		public static string FormatModifier(int modifier) => modifier >= 0 ? $"+{modifier}" : $"−{-modifier}";

		public static int ProficiencyBonus(int level) => 2 + (Math.Clamp(level, 1, 20) - 1) / 4;

		///	<summary>
		///	Point buy cost of a score from 8 to 15 (8 → 0, 13 → 5, 14 → 7, 15 → 9); null outside the range.
		///	</summary>
		public static int? PointBuyCost(int score) => score switch
		{
			8 => 0, 9 => 1, 10 => 2, 11 => 3, 12 => 4, 13 => 5, 14 => 7, 15 => 9, _ => null
		};

		///	<summary>
		///	Checks the six base scores against the method: the standard array in any order, a point buy that spends
		///	at most 27 points, or rolled scores between 3 and 18.
		///	</summary>
		public static bool AreValidBaseScores(AbilityMethod method, IReadOnlyList<int> scores)
		{
			if (scores.Count != 6)
			{
				return false;
			}

			return method switch
			{
				AbilityMethod.StandardArray => scores.OrderByDescending(s => s).SequenceEqual(StandardArray),
				AbilityMethod.PointBuy => scores.All(s => PointBuyCost(s) is not null) && scores.Sum(s => PointBuyCost(s)!.Value) <= PointBuyBudget,
				AbilityMethod.Roll => scores.All(s => s is >= 3 and <= 18),
				_ => false
			};
		}

		///	<summary>
		///	Checks the origin increases: +2/+1 or +1/+1/+1 (2024, only on the background's abilities when it lists any),
		///	or +1 to every score (2014). Bonuses are in the order of <see cref="Abilities"/>.
		///	</summary>
		public static bool AreValidBonuses(AbilityBonusMode mode, IReadOnlyList<int> bonuses, IReadOnlyCollection<AbilityScore> allowed)
		{
			if (bonuses.Count != 6 || bonuses.Any(b => b < 0))
			{
				return false;
			}

			var given = Abilities.Where((a, i) => bonuses[i] > 0).ToList();
			if (allowed.Count > 0 && mode != AbilityBonusMode.AllOnes && given.Any(a => !allowed.Contains(a)))
			{
				return false;
			}

			var sorted = bonuses.Where(b => b > 0).OrderByDescending(b => b).ToList();
			return mode switch
			{
				AbilityBonusMode.TwoAndOne => sorted.SequenceEqual(new[] { 2, 1 }),
				AbilityBonusMode.ThreeOnes => sorted.SequenceEqual(new[] { 1, 1, 1 }),
				AbilityBonusMode.AllOnes => bonuses.All(b => b == 1),
				_ => false
			};
		}

		///	<summary>
		///	Final scores: base plus origin bonuses, capped at 20.
		///	</summary>
		public static int[] FinalScores(IReadOnlyList<int> scores, IReadOnlyList<int> bonuses) =>
			Enumerable.Range(0, 6).Select(i => Math.Min(20, scores[i] + (i < bonuses.Count ? bonuses[i] : 0))).ToArray();

		public static int Score(IReadOnlyList<int> scores, AbilityScore ability) => scores[(int)ability - 1];

		///	<summary>
		///	Hit point maximum: the full hit die at level 1, then the fixed value (half the die + 1) for every other level,
		///	plus the Constitution modifier each level (at least 1 per level).
		///	</summary>
		public static int MaxHitPoints(int hitDie, int level, int constitutionModifier)
		{
			var total = Math.Max(1, hitDie + constitutionModifier);
			for (var l = 2; l <= level; l++)
			{
				total += Math.Max(1, hitDie / 2 + 1 + constitutionModifier);
			}

			return total;
		}

		///	<summary>
		///	Armor Class: the best worn body armor (light: + Dex, medium: + Dex up to the cap, heavy: no Dex) plus a shield;
		///	without body armor, 10 + Dex, or the Unarmored Defense of the barbarian (+ Con) and of the monk (+ Wis, no shield).
		///	</summary>
		public static int ArmorClass(IEnumerable<WornArmor> armor, int dexterity, int constitution, int wisdom, string? classKey)
		{
			var list = armor.ToList();
			var dex = Modifier(dexterity);
			var shield = list.Where(a => a.Category == ArmorCategory.Shield).Select(a => a.ArmorClass).DefaultIfEmpty(0).Max();
			var bodies = list.Where(a => a.Category != ArmorCategory.Shield).ToList();

			if (bodies.Count > 0)
			{
				return bodies.Max(a => a.ArmorClass + (a.AddsDexterity ? Math.Min(dex, a.MaxDexterity ?? dex) : 0)) + shield;
			}

			return classKey switch
			{
				"barbarian" => 10 + dex + Modifier(constitution) + shield,
				"monk" when shield == 0 => 10 + dex + Modifier(wisdom),
				_ => 10 + dex + shield
			};
		}

		///	<summary>
		///	Reads the spells of a level from the progression table of a class (English or Italian headers): the cantrips and
		///	prepared/known spells columns, and the highest spell slot column with a value (or the warlock's slot level).
		///	Classes that prepare spells without a column (2014 cleric, druid, paladin, wizard) prepare
		///	their spellcasting modifier + level (half the level for the paladin), at least 1.
		///	</summary>
		public static SpellAllowance Spells(string? progressionTable, int level, int spellcastingModifier, bool halfCaster)
		{
			var rows = (progressionTable ?? string.Empty).Replace("\r", string.Empty).Split('\n')
				.Select(l => l.Trim())
				.Where(l => l.StartsWith('|'))
				.Select(l => l.Trim('|').Split('|').Select(c => c.Trim()).ToArray())
				.Where(r => !r.All(c => c.Length == 0 || c.All(ch => ch == '-' || ch == ':')))
				.ToList();
			if (rows.Count < 2)
			{
				return SpellAllowance.None;
			}

			var header = rows[0];
			var row = rows.Skip(1).FirstOrDefault(r => LeadingNumber(r[0]) == level);
			if (row is null)
			{
				return SpellAllowance.None;
			}

			int Column(Func<string, bool> match) => Array.FindIndex(header, h => match(h.ToLowerInvariant()));
			int Value(int index) => index >= 0 && index < row.Length ? LeadingNumber(row[index]) ?? 0 : 0;

			var cantrips = Value(Column(h => h.StartsWith("cantrips") || h.StartsWith("trucchetti")));
			var spellsColumn = Column(h => h.Contains("prepared spells") || h.Contains("spells known") || h.Contains("incantesimi preparati") || h.Contains("incantesimi conosciuti"));

			var maxLevel = 0;
			var slotLevelColumn = Column(h => h == "slot level" || h == "livello degli slot");
			if (slotLevelColumn >= 0)
			{
				maxLevel = Value(slotLevelColumn);
			}
			else
			{
				for (var i = 0; i < header.Length && i < row.Length; i++)
				{
					if (SlotHeader().Match(header[i]) is { Success: true } m && (LeadingNumber(row[i]) ?? 0) > 0)
					{
						maxLevel = Math.Max(maxLevel, int.Parse(m.Groups[1].Value));
					}
				}
			}

			if (maxLevel == 0)
			{
				return new SpellAllowance(cantrips, 0, 0);
			}

			var spells = spellsColumn >= 0
				? Value(spellsColumn)
				: Math.Max(1, spellcastingModifier + (halfCaster ? level / 2 : level));

			return new SpellAllowance(cantrips, spells, maxLevel);
		}

		private static int? LeadingNumber(string text)
		{
			var m = Number().Match(text);
			return m.Success ? int.Parse(m.Value) : null;
		}

		[GeneratedRegex(@"^\d+")]
		private static partial Regex Number();

		//	"1", "1st", "2nd", "3°"…: one column per spell level, up to 9
		[GeneratedRegex(@"^([1-9])(?:st|nd|rd|th|°)?$")]
		private static partial Regex SlotHeader();
	}
}
