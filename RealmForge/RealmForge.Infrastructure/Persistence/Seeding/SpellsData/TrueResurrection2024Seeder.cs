using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Resurrection (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TrueResurrection2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-resurrection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-resurrection", "en"),
					Language = LanguageCode.En,
					Name = "True Resurrection",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "diamonds worth 25,000+ GP, which the spell consumes",
					Description = "You touch a creature that has been dead for no longer than 200 years and that died for any reason except old age. The creature is revived with all its Hit Points.\n\nThis spell closes all wounds, neutralizes any poison, cures all magical contagions, and lifts any curses affecting the creature when it died. The spell replaces damaged or missing organs and limbs. If the creature was Undead, it is restored to its non-Undead form.\n\nThe spell can provide a new body if the original no longer exists, in which case you must speak the creature's name. The creature then appears in an unoccupied space you choose within 10 feet of you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-resurrection", "it"),
					Language = LanguageCode.It,
					Name = "Resurrezione Pura",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "diamanti del valore di almeno 25.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una creatura morta da non più di 200 anni e per qualsiasi causa tranne la vecchiaia. La creatura torna in vita con tutti i suoi punti ferita.\n\nQuesto incantesimo chiude tutte le ferite, neutralizza qualsiasi veleno, cura tutti i contagi magici e spezza tutte le maledizioni che affliggevano la creatura al momento della morte. L'incantesimo sostituisce gli organi e gli arti danneggiati o mancanti. Se la creatura era un non morto, viene riportata alla forma che aveva prima di diventare un non morto.\n\nL'incantesimo può fornire un nuovo corpo se quello originale non esiste più; in tal caso, l'incantatore deve pronunciare il nome della creatura. La creatura compare poi in uno spazio libero a scelta dell'incantatore entro 3 metri da lui.",
					HigherLevels = null
				}
			}
		};
	}
}
