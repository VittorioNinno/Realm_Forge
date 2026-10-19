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

		public static string SchoolName(SpellSchool school, LanguageCode lang) => (school, lang == LanguageCode.It) switch
		{
			//	Italian manuals: "Evocazione" is conjuration, "Invocazione" is evocation
			(SpellSchool.Abjuration, true) => "Abiurazione",
			(SpellSchool.Conjuration, true) => "Evocazione",
			(SpellSchool.Divination, true) => "Divinazione",
			(SpellSchool.Enchantment, true) => "Ammaliamento",
			(SpellSchool.Evocation, true) => "Invocazione",
			(SpellSchool.Illusion, true) => "Illusione",
			(SpellSchool.Necromancy, true) => "Necromanzia",
			(SpellSchool.Transmutation, true) => "Trasmutazione",
			_ => school.ToString()
		};

		public static string ClassName(SpellcastingClass spellClass, LanguageCode lang) => (spellClass, lang == LanguageCode.It) switch
		{
			(SpellcastingClass.Bard, true) => "Bardo",
			(SpellcastingClass.Cleric, true) => "Chierico",
			(SpellcastingClass.Druid, true) => "Druido",
			(SpellcastingClass.Paladin, true) => "Paladino",
			(SpellcastingClass.Ranger, true) => "Ranger",
			(SpellcastingClass.Sorcerer, true) => "Stregone",
			(SpellcastingClass.Warlock, true) => "Warlock",
			(SpellcastingClass.Wizard, true) => "Mago",
			_ => spellClass.ToString()
		};

		public static string CasterProgressionName(CasterProgression progression, LanguageCode lang) => (progression, lang == LanguageCode.It) switch
		{
			(CasterProgression.None, true) => "Nessun incantesimo",
			(CasterProgression.Full, true) => "Incantatore completo",
			(CasterProgression.Half, true) => "Mezzo incantatore",
			(CasterProgression.Third, true) => "Incantatore parziale (1/3)",
			(CasterProgression.Pact, true) => "Magia del patto",
			(CasterProgression.None, false) => "No spellcasting",
			(CasterProgression.Full, false) => "Full caster",
			(CasterProgression.Half, false) => "Half caster",
			(CasterProgression.Third, false) => "Third caster",
			(CasterProgression.Pact, false) => "Pact Magic",
			_ => progression.ToString()
		};

		///	<summary>
		///	Short level label for filters and badges: "Trucchetto" / "Cantrip", "1° livello" / "1st level".
		///	</summary>
		public static string SpellLevel(int level, LanguageCode lang)
		{
			if (level == 0)
			{
				return lang == LanguageCode.It ? "Trucchetto" : "Cantrip";
			}

			if (lang == LanguageCode.It)
			{
				return $"{level}° livello";
			}

			var suffix = level switch { 1 => "st", 2 => "nd", 3 => "rd", _ => "th" };
			return $"{level}{suffix} level";
		}

		///	<summary>
		///	Stat block subtitle as in the manuals: "Invocazione di 3° livello (rituale)", "Trucchetto di invocazione";
		///	in English "3rd-level evocation (ritual)" / "Evocation cantrip" for 2014 and "Level 3 Evocation" / "Evocation Cantrip" for 2024.
		///	</summary>
		public static string SpellSubtitle(int level, SpellSchool school, bool ritual, LanguageCode lang, RulesetVersion ruleset = RulesetVersion.Dnd5e_2014)
		{
			var schoolName = SchoolName(school, lang);
			string text;

			if (lang == LanguageCode.It)
			{
				text = level == 0 ? $"Trucchetto di {schoolName.ToLowerInvariant()}" : $"{schoolName} di {level}° livello";
				return ritual ? $"{text} (rituale)" : text;
			}

			if (ruleset == RulesetVersion.Dnd5e_2024)
			{
				text = level == 0 ? $"{schoolName} Cantrip" : $"Level {level} {schoolName}";
				return ritual ? $"{text} (Ritual)" : text;
			}

			text = level == 0 ? $"{schoolName} cantrip" : $"{SpellLevel(level, lang).Replace(" level", "-level")} {schoolName.ToLowerInvariant()}";
			return ritual ? $"{text} (ritual)" : text;
		}

		///	<summary>
		///	Heading of the "higher levels" part of a spell: 2014 "Ai livelli superiori" / "At Higher Levels";
		///	2024 "Utilizzo di uno slot incantesimo di livello superiore" / "Using a Higher-Level Spell Slot",
		///	and "Trucchetto potenziato" / "Cantrip Upgrade" for 2024 cantrips.
		///	</summary>
		public static string SpellHigherLevelsHeading(int level, LanguageCode lang, RulesetVersion ruleset)
		{
			var it = lang == LanguageCode.It;

			if (ruleset != RulesetVersion.Dnd5e_2024)
			{
				return it ? "Ai livelli superiori" : "At higher levels";
			}

			if (level == 0)
			{
				return it ? "Trucchetto potenziato" : "Cantrip upgrade";
			}

			return it ? "Utilizzo di uno slot di livello superiore" : "Using a higher-level spell slot";
		}
	}
}
