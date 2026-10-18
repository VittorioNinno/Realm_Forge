using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Alarm (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Alarm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alarm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alarm", "en"),
					Language = LanguageCode.En,
					Name = "Alarm",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a tiny bell and a piece of fine silver wire",
					Description = "You set an alarm against unwanted intrusion. Choose a door, a window, or an area within range that is no larger than a 20-foot cube. Until the spell ends, an alarm alerts you whenever a Tiny or larger creature touches or enters the warded area. When you cast the spell, you can designate creatures that won't set off the alarm. You also choose whether the alarm is mental or audible.\n\nA mental alarm alerts you with a ping in your mind if you are within 1 mile of the warded area. This ping awakens you if you are sleeping.\n\nAn audible alarm produces the sound of a hand bell for 10 seconds within 60 feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alarm", "it"),
					Language = LanguageCode.It,
					Name = "Allarme",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "una minuscola campanella e un pezzo di filo d'argento sottile",
					Description = "L'incantatore predispone un allarme contro le intrusioni indesiderate. Sceglie una porta, una finestra o un'area entro gittata non più grande di un cubo con spigolo di 6 metri. Finché l'incantesimo non termina, un allarme avverte l'incantatore ogni volta che una creatura di taglia Minuscola o superiore tocca l'area protetta o vi entra. Quando lancia l'incantesimo, l'incantatore può designare le creature che non faranno scattare l'allarme. Sceglie inoltre se l'allarme è mentale o udibile.\n\nUn allarme mentale avverte l'incantatore con un segnale nella sua mente, se si trova entro 1,5 km dall'area protetta. Il segnale lo sveglia, se sta dormendo.\n\nUn allarme udibile produce il suono di una campanella per 10 secondi, udibile entro 18 metri.",
					HigherLevels = null
				}
			}
		};
	}
}
