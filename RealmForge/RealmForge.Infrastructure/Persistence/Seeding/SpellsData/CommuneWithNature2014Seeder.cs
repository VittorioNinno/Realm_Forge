using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Commune With Nature (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CommuneWithNature2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune-with-nature");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune-with-nature", "en"),
					Language = LanguageCode.En,
					Name = "Commune With Nature",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You briefly become one with nature and gain knowledge of the surrounding territory. In the outdoors, the spell gives you knowledge of the land within 3 miles of you. In caves and other natural underground settings, the radius is limited to 300 feet. The spell doesn't function where nature has been replaced by construction, such as in dungeons and towns.\n\nYou instantly gain knowledge of up to three facts of your choice about any of the following subjects as they relate to the area:\n\n- terrain and bodies of water\n\n- prevalent plants, minerals, animals, or peoples\n\n- powerful celestials, fey, fiends, elementals, or undead\n\n- influence from other planes of existence\n\n- buildings\n\nFor example, you could determine the location of powerful undead in the area, the location of major sources of safe drinking water, and the location of any nearby towns.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune-with-nature", "it"),
					Language = LanguageCode.It,
					Name = "Comunione con la Natura",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore diventa per un breve istante tutt'uno con la natura e ottiene conoscenze sul territorio circostante. All'aperto, l'incantesimo gli conferisce la conoscenza del territorio entro 4,5 km da lui. Nelle caverne e in altri ambienti naturali sotterranei, il raggio è limitato a 90 metri. L'incantesimo non funziona nei luoghi in cui la natura è stata sostituita da costruzioni, come i dungeon e le città.\n\nL'incantatore ottiene istantaneamente la conoscenza di un massimo di tre fatti a sua scelta riguardanti uno qualsiasi degli argomenti seguenti, in relazione all'area:\n\n- terreno e specchi d'acqua\n\n- vegetali, minerali, animali o popoli prevalenti\n\n- celestiali, folletti, immondi, elementali o non morti potenti\n\n- influenze di altri piani di esistenza\n\n- edifici\n\nPer esempio, l'incantatore potrebbe determinare la posizione di potenti non morti nell'area, quella delle principali fonti di acqua potabile sicura e quella di eventuali città vicine.",
					HigherLevels = null
				}
			}
		};
	}
}
