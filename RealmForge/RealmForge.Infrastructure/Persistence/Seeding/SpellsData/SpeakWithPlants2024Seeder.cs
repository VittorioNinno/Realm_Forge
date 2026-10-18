using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Speak with Plants (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpeakWithPlants2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-plants", "en"),
					Language = LanguageCode.En,
					Name = "Speak with Plants",
					CastingTime = "Action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "You imbue plants in an immobile 30-foot Emanation with limited sentience and animation, giving them the ability to communicate with you and follow your simple commands. You can question plants about events in the spell's area within the past day, gaining information about creatures that have passed, weather, and other circumstances.\n\nYou can also turn Difficult Terrain caused by plant growth (such as thickets and undergrowth) into ordinary terrain that lasts for the duration. Or you can turn ordinary terrain where plants are present into Difficult Terrain that lasts for the duration.\n\nThe spell doesn't enable plants to uproot themselves and move about, but they can move their branches, tendrils, and stalks for you.\n\nIf a Plant creature is in the area, you can communicate with it as if you shared a common language.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-plants", "it"),
					Language = LanguageCode.It,
					Name = "Parlare con i Vegetali",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore infonde nelle piante che si trovano in un'emanazione immobile di 9 metri una limitata coscienza e capacità di movimento, conferendo loro la capacità di comunicare con lui e di eseguire i suoi comandi semplici. Può interrogare le piante sugli eventi avvenuti nell'area dell'incantesimo nell'ultimo giorno, ottenendo informazioni sulle creature che sono passate, sul tempo atmosferico e su altre circostanze.\n\nL'incantatore può anche trasformare il terreno difficile causato dalla vegetazione (come boscaglie e sottobosco) in terreno normale per la durata. Oppure può trasformare il terreno normale in cui sono presenti delle piante in terreno difficile per la durata.\n\nL'incantesimo non permette alle piante di sradicarsi e spostarsi, ma esse possono muovere rami, viticci e steli per l'incantatore.\n\nSe nell'area si trova una creatura vegetale, l'incantatore può comunicare con essa come se avessero un linguaggio in comune.",
					HigherLevels = null
				}
			}
		};
	}
}
