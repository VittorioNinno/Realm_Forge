using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Localization
{
	///	<summary>
	///	Localized names of shared rules terms (skills and the ability each one uses).
	///	</summary>
	public static class GameTerms
	{
		public static AbilityScore SkillAbility(Skill skill) => skill switch
		{
			Skill.Athletics => AbilityScore.Strength,
			Skill.Acrobatics or Skill.SleightOfHand or Skill.Stealth => AbilityScore.Dexterity,
			Skill.Arcana or Skill.History or Skill.Investigation or Skill.Nature or Skill.Religion => AbilityScore.Intelligence,
			Skill.AnimalHandling or Skill.Insight or Skill.Medicine or Skill.Perception or Skill.Survival => AbilityScore.Wisdom,
			_ => AbilityScore.Charisma
		};

		public static string SkillName(Skill skill, LanguageCode lang) => (skill, lang == LanguageCode.It) switch
		{
			(Skill.Acrobatics, true) => "Acrobazia",
			(Skill.AnimalHandling, true) => "Addestrare Animali",
			(Skill.Arcana, true) => "Arcano",
			(Skill.Athletics, true) => "Atletica",
			(Skill.Deception, true) => "Inganno",
			(Skill.History, true) => "Storia",
			(Skill.Insight, true) => "Intuizione",
			(Skill.Intimidation, true) => "Intimidire",
			(Skill.Investigation, true) => "Indagare",
			(Skill.Medicine, true) => "Medicina",
			(Skill.Nature, true) => "Natura",
			(Skill.Perception, true) => "Percezione",
			(Skill.Performance, true) => "Intrattenere",
			(Skill.Persuasion, true) => "Persuasione",
			(Skill.Religion, true) => "Religione",
			(Skill.SleightOfHand, true) => "Rapidità di Mano",
			(Skill.Stealth, true) => "Furtività",
			(Skill.Survival, true) => "Sopravvivenza",
			(Skill.Acrobatics, false) => "Acrobatics",
			(Skill.AnimalHandling, false) => "Animal Handling",
			(Skill.Arcana, false) => "Arcana",
			(Skill.Athletics, false) => "Athletics",
			(Skill.Deception, false) => "Deception",
			(Skill.History, false) => "History",
			(Skill.Insight, false) => "Insight",
			(Skill.Intimidation, false) => "Intimidation",
			(Skill.Investigation, false) => "Investigation",
			(Skill.Medicine, false) => "Medicine",
			(Skill.Nature, false) => "Nature",
			(Skill.Perception, false) => "Perception",
			(Skill.Performance, false) => "Performance",
			(Skill.Persuasion, false) => "Persuasion",
			(Skill.Religion, false) => "Religion",
			(Skill.SleightOfHand, false) => "Sleight of Hand",
			(Skill.Stealth, false) => "Stealth",
			(Skill.Survival, false) => "Survival",
			_ => skill.ToString()
		};
	}
}
