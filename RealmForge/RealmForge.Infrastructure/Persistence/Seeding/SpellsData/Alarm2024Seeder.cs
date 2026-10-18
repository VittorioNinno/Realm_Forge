using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Alarm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Alarm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alarm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alarm", "en"),
					Language = LanguageCode.En,
					Name = "Alarm",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a bell and silver wire",
					Description = "You set an alarm against intrusion. Choose a door, a window, or an area within range that is no larger than a 20-foot Cube. Until the spell ends, an alarm alerts you whenever a creature touches or enters the warded area. When you cast the spell, you can designate creatures that won't set off the alarm. You also choose whether the alarm is audible or mental:\n\n**Audible Alarm.** The alarm produces the sound of a handbell for 10 seconds within 60 feet of the warded area.\n\n**Mental Alarm.** You are alerted by a mental ping if you are within 1 mile of the warded area. This ping awakens you if you're asleep.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alarm", "it"),
					Language = LanguageCode.It,
					Name = "Allarme",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "una campanella e del filo d'argento",
					Description = "L'incantatore predispone un allarme contro le intrusioni. Sceglie una porta, una finestra o un'area entro gittata non più grande di un cubo con spigolo di 6 metri. Finché l'incantesimo non termina, un allarme avverte l'incantatore ogni volta che una creatura tocca l'area protetta o vi entra. Quando lancia l'incantesimo, l'incantatore può designare le creature che non faranno scattare l'allarme. Sceglie inoltre se l'allarme è udibile o mentale:\n\n**Allarme Udibile.** L'allarme produce il suono di una campanella per 10 secondi, udibile entro 18 metri dall'area protetta.\n\n**Allarme Mentale.** L'incantatore viene avvertito da un segnale mentale, purché si trovi entro 1,5 km dall'area protetta. Il segnale lo sveglia, se sta dormendo.",
					HigherLevels = null
				}
			}
		};
	}
}
