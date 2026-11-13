using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	The dice of the limited-use features that roll some (Second Wind, Bardic Inspiration, Superiority Dice, Healing Hands,
///	Breath Weapon): rolled by the sheet when the feature is used, the healing ones applied to the hit points.
///	</summary>
public static class FeatureDice
{
	public sealed record Roll(string Dice, bool Heals);

	public static Roll? Of(ClassResource resource, ComputedCharacter c)
	{
		static string Die(int level, params (int From, int Size)[] steps) => $"1d{steps.Where(s => level >= s.From).Select(s => s.Size).DefaultIfEmpty(6).Last()}";
		return resource.Key switch
		{
			"fighter-second-wind" => new Roll($"1d10+{Math.Max(1, c.ClassLevel("fighter"))}", true),
			"bard-inspiration" => new Roll(Die(c.ClassLevel("bard"), (1, 6), (5, 8), (10, 10), (15, 12)), false),
			"battle-master-dice" => new Roll(Die(c.ClassLevel("fighter"), (1, 8), (10, 10), (18, 12)), false),
			"species-healing-hands" => c.Ruleset == RulesetVersion.Dnd5e_2024
				? new Roll($"{c.ProficiencyBonus}d4", true)
				: new Roll($"{Math.Max(1, c.Level)}", true),
			"species-breath" when c.Breath is { } breath => new Roll(breath.Damage, false),
			_ => null
		};
	}
}
