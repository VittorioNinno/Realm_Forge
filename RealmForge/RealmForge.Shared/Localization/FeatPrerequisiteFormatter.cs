using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Localization
{
	///	<summary>
	///	Turns structured feat prerequisites into localized, ruleset-aware text,
	///	e.g. "Level 4+, Strength or Dexterity 13+" / "Livello 4+, Forza o Destrezza 13+".
	///	</summary>
	public static class FeatPrerequisiteFormatter
	{
		public static string? Format(FeatPrerequisiteDto prerequisites, string? note, RulesetVersion ruleset, LanguageCode lang)
		{
			var parts = new List<string>();
			var it = lang == LanguageCode.It;

			if (prerequisites.MinimumLevel is int level)
			{
				parts.Add(it ? $"Livello {level}+" : $"Level {level}+");
			}

			if (prerequisites.Abilities.Count > 0 && prerequisites.MinimumScore is int score)
			{
				var names = prerequisites.Abilities.Distinct().Select(a => AbilityName(a, lang)).ToList();
				parts.Add($"{JoinAlternatives(names, lang)} {score}+");
			}

			if (prerequisites.Feature is FeatFeatureRequirement feature)
			{
				parts.Add(FeatureName(feature, ruleset, lang));
			}

			if (!string.IsNullOrWhiteSpace(note))
			{
				parts.Add(note.Trim());
			}

			if (parts.Count == 0)
			{
				return null;
			}

			//	Use a semicolon when a part already contains commas (2024 style: "Level 4+; Intelligence, Wisdom, or Charisma 13+")
			var separator = parts.Any(p => p.Contains(',')) ? "; " : ", ";
			return string.Join(separator, parts);
		}

		public static string AbilityName(AbilityScore ability, LanguageCode lang) => (ability, lang == LanguageCode.It) switch
		{
			(AbilityScore.Strength, true) => "Forza",
			(AbilityScore.Dexterity, true) => "Destrezza",
			(AbilityScore.Constitution, true) => "Costituzione",
			(AbilityScore.Intelligence, true) => "Intelligenza",
			(AbilityScore.Wisdom, true) => "Saggezza",
			(AbilityScore.Charisma, true) => "Carisma",
			(AbilityScore.Strength, false) => "Strength",
			(AbilityScore.Dexterity, false) => "Dexterity",
			(AbilityScore.Constitution, false) => "Constitution",
			(AbilityScore.Intelligence, false) => "Intelligence",
			(AbilityScore.Wisdom, false) => "Wisdom",
			(AbilityScore.Charisma, false) => "Charisma",
			_ => ability.ToString()
		};

		public static string FeatureName(FeatFeatureRequirement feature, RulesetVersion ruleset, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			var modern = ruleset == RulesetVersion.Dnd5e_2024;

			return feature switch
			{
				FeatFeatureRequirement.FightingStyle =>
					it ? "Privilegio Stile di Combattimento" : "Fighting Style Feature",

				FeatFeatureRequirement.Spellcasting => modern
					? (it ? "Privilegio Incantesimi" : "Spellcasting Feature")
					: (it ? "Capacità di lanciare almeno un incantesimo" : "The ability to cast at least one spell"),

				FeatFeatureRequirement.SpellcastingOrPactMagic =>
					it ? "Privilegio Incantesimi o Magia del Patto" : "Spellcasting or Pact Magic Feature",

				FeatFeatureRequirement.LightArmor => modern
					? (it ? "Addestramento nelle armature leggere" : "Light Armor Training")
					: (it ? "Competenza nelle armature leggere" : "Proficiency with light armor"),

				FeatFeatureRequirement.MediumArmor => modern
					? (it ? "Addestramento nelle armature medie" : "Medium Armor Training")
					: (it ? "Competenza nelle armature medie" : "Proficiency with medium armor"),

				FeatFeatureRequirement.HeavyArmor => modern
					? (it ? "Addestramento nelle armature pesanti" : "Heavy Armor Training")
					: (it ? "Competenza nelle armature pesanti" : "Proficiency with heavy armor"),

				FeatFeatureRequirement.Shield => modern
					? (it ? "Addestramento negli scudi" : "Shield Training")
					: (it ? "Competenza negli scudi" : "Proficiency with shields"),

				_ => feature.ToString()
			};
		}

		//	"A", "A or B", "A, B or C" (IT) / "A, B, or C" (EN, serial comma)
		private static string JoinAlternatives(IReadOnlyList<string> items, LanguageCode lang)
		{
			var or = lang == LanguageCode.It ? "o" : "or";

			return items.Count switch
			{
				0 => string.Empty,
				1 => items[0],
				2 => $"{items[0]} {or} {items[1]}",
				_ => lang == LanguageCode.It
					? $"{string.Join(", ", items.Take(items.Count - 1))} {or} {items[^1]}"
					: $"{string.Join(", ", items.Take(items.Count - 1))}, {or} {items[^1]}"
			};
		}
	}
}
