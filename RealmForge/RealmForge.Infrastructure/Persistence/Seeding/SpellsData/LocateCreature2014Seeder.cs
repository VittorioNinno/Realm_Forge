using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Locate Creature (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LocateCreature2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-creature");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-creature", "en"),
					Language = LanguageCode.En,
					Name = "Locate Creature",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of fur from a bloodhound",
					Description = "Describe or name a creature that is familiar to you. You sense the direction to the creature's location, as long as that creature is within 1,000 feet of you. If the creature is moving, you know the direction of its movement.\n\nThe spell can locate a specific creature known to you, or the nearest creature of a specific kind (such as a human or a unicorn), so long as you have seen such a creature up close—within 30 feet—at least once. If the creature you described or named is in a different form, such as being under the effects of a polymorph spell, this spell doesn't locate the creature.\n\nThis spell can't locate a creature if running water at least 10 feet wide blocks a direct path between you and the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-creature", "it"),
					Language = LanguageCode.It,
					Name = "Localizza Creatura",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un po' di pelo di segugio",
					Description = "L'incantatore descrive o nomina una creatura a lui familiare. Percepisce la direzione in cui si trova la creatura, purché sia entro 300 metri da lui. Se la creatura si sta muovendo, conosce la direzione del suo movimento.\n\nL'incantesimo può localizzare una specifica creatura conosciuta dall'incantatore, oppure la creatura più vicina di un tipo specifico (come un umano o un unicorno), purché l'incantatore abbia visto da vicino (entro 9 metri) una creatura simile almeno una volta. Se la creatura descritta o nominata ha una forma diversa, per esempio perché è sotto l'effetto di un incantesimo metamorfosi, questo incantesimo non la localizza.\n\nQuesto incantesimo non può localizzare una creatura se un corso d'acqua corrente largo almeno 3 metri blocca il percorso diretto tra l'incantatore e la creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
