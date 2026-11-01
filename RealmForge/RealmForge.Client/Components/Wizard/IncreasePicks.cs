using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;

namespace RealmForge.Client.Components.Wizard
{
	///	<summary>
	///	The +1 picks of an Ability Score Improvement over the six abilities and the ones added by rule modules: a pick is
	///	"1".."6" (an AbilityScore) or "x:key" (an added ability); the six go to Increases, the others to ExtraIncreases.
	///	</summary>
	public static class IncreasePicks
	{
		public static List<string> Combined(List<AbilityScore> increases, List<string> extra) =>
			increases.Select(a => ((int)a).ToString()).Concat(extra.Select(k => "x:" + k)).ToList();

		public static string? Get(List<AbilityScore> increases, List<string> extra, int pick)
		{
			var all = Combined(increases, extra);
			return pick < all.Count ? all[pick] : null;
		}

		public static void Set(List<AbilityScore> increases, List<string> extra, int pick, string? value)
		{
			var all = Combined(increases, extra);
			if (value is null)
			{
				if (pick < all.Count)
				{
					all.RemoveAt(pick);
				}
			}
			else if (pick < all.Count)
			{
				all[pick] = value;
			}
			else
			{
				all.Add(value);
			}
			increases.Clear();
			extra.Clear();
			foreach (var v in all)
			{
				if (v.StartsWith("x:"))
				{
					extra.Add(v[2..]);
				}
				else if (int.TryParse(v, out var n) && Enum.IsDefined((AbilityScore)n))
				{
					increases.Add((AbilityScore)n);
				}
			}
		}

		public static List<ForgeSelector<string?>.Option> Options(IEnumerable<AbilityScore> abilities, ComputedCharacter computed, LanguageCode lang) => abilities
			.Select(a => new ForgeSelector<string?>.Option(((int)a).ToString(), FeatPrerequisiteFormatter.AbilityName(a, lang)))
			.Concat(computed.ExtraAbilities.Select(e => new ForgeSelector<string?>.Option("x:" + e.Key, e.Definition.Name(lang))))
			.ToList();
	}
}
