using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Speak with Plants (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpeakWithPlants2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-plants", "en"),
					Language = LanguageCode.En,
					Name = "Speak with Plants",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "You imbue plants within 30 feet of you with limited sentience and animation, giving them the ability to communicate with you and follow your simple commands. You can question plants about events in the spell's area within the past day, gaining information about creatures that have passed, weather, and other circumstances.\n\nYou can also turn difficult terrain caused by plant growth (such as thickets and undergrowth) into ordinary terrain that lasts for the duration. Or you can turn ordinary terrain where plants are present into difficult terrain that lasts for the duration, causing vines and branches to hinder pursuers, for example.\n\nPlants might be able to perform other tasks on your behalf, at the GM's discretion. The spell doesn't enable plants to uproot themselves and move about, but they can freely move branches, tendrils, and stalks.\n\nIf a plant creature is in the area, you can communicate with it as if you shared a common language, but you gain no magical ability to influence it.\n\nThis spell can cause the plants created by the entangle spell to release a restrained creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-plants", "it"),
					Language = LanguageCode.It,
					Name = "Parlare con i Vegetali",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore infonde nei vegetali entro 9 metri da sé una limitata capacità di senziente e di movimento, conferendo loro la capacità di comunicare con lui e di eseguire i suoi comandi semplici. Può interrogare i vegetali sugli eventi accaduti nell'area dell'incantesimo nell'ultimo giorno, ottenendo informazioni sulle creature che sono passate di lì, sul clima e su altre circostanze.\n\nPuò anche trasformare il terreno difficile causato dalla vegetazione (come boscaglia e sottobosco) in terreno normale per la durata. Oppure può trasformare il terreno normale in cui è presente vegetazione in terreno difficile per la durata, facendo sì, per esempio, che rampicanti e rami ostacolino gli inseguitori.\n\nA discrezione del DM, i vegetali potrebbero essere in grado di svolgere altri compiti per conto dell'incantatore. L'incantesimo non permette ai vegetali di sradicarsi e di spostarsi, ma possono muovere liberamente rami, viticci e steli.\n\nSe nell'area si trova una creatura vegetale, l'incantatore può comunicare con essa come se condividessero un linguaggio comune, ma non ottiene alcuna capacità magica di influenzarla.\n\nQuesto incantesimo può far sì che i vegetali creati dall'incantesimo intralciare liberino una creatura trattenuta.",
					HigherLevels = null
				}
			}
		};
	}
}
