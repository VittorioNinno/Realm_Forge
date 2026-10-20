using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Keys of the Base classes, recovered from their deterministic ids (ForSrd(ruleset, "class", key)): rules that depend
///	on a specific class (Unarmored Defense, half casters, spell lists) use them. Homebrew classes have no key.
///	</summary>
public static class BaseClassKeys
{
	public static readonly IReadOnlyList<string> All = new[]
	{
		"barbarian", "bard", "cleric", "druid", "fighter", "monk", "paladin", "ranger", "rogue", "sorcerer", "warlock", "wizard"
	};

	public static string? Of(Guid classId, RulesetVersion ruleset) =>
		All.FirstOrDefault(key => DeterministicGuid.ForSrd(ruleset, "class", key) == classId);

	public static SpellcastingClass? SpellList(string? key) =>
		Enum.TryParse<SpellcastingClass>(key, ignoreCase: true, out var list) ? list : null;
}
