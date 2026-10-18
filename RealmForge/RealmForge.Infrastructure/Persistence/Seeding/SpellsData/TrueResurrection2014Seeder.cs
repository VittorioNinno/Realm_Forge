using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Resurrection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TrueResurrection2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-resurrection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-resurrection", "en"),
					Language = LanguageCode.En,
					Name = "True Resurrection",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a sprinkle of holy water and diamonds worth at least 25,000 gp, which the spell consumes",
					Description = "You touch a creature that has been dead for no longer than 200 years and that died for any reason except old age. If the creature's soul is free and willing, the creature is restored to life with all its hit points.\n\nThis spell closes all wounds, neutralizes any poison, cures all diseases, and lifts any curses affecting the creature when it died. The spell replaces damaged or missing organs and limbs.\n\nThe spell can even provide a new body if the original no longer exists, in which case you must speak the creature's name. The creature then appears in an unoccupied space you choose within 10 feet of you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-resurrection", "it"),
					Language = LanguageCode.It,
					Name = "Resurrezione Pura",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "una spruzzata di acqua santa e diamanti del valore di almeno 25.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una creatura morta da non più di 200 anni e per qualsiasi causa tranne la vecchiaia. Se l'anima della creatura è libera e disposta a tornare, la creatura torna in vita con tutti i suoi punti ferita.\n\nQuesto incantesimo chiude tutte le ferite, neutralizza ogni veleno, cura tutte le malattie e rimuove tutte le maledizioni che affliggevano la creatura al momento della morte. L'incantesimo sostituisce gli organi e gli arti danneggiati o mancanti.\n\nL'incantesimo può persino fornire un nuovo corpo se quello originale non esiste più; in tal caso, l'incantatore deve pronunciare il nome della creatura. La creatura compare quindi in uno spazio libero scelto dall'incantatore entro 3 metri da lui.",
					HigherLevels = null
				}
			}
		};
	}
}
