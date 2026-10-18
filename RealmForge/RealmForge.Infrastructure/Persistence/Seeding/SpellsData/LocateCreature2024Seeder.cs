using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Locate Creature (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LocateCreature2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-creature");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-creature", "en"),
					Language = LanguageCode.En,
					Name = "Locate Creature",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "fur from a bloodhound",
					Description = "Describe or name a creature that is familiar to you. You sense the direction to the creature's location if that creature is within 1,000 feet of you. If the creature is moving, you know the direction of its movement.\n\nThe spell can locate a specific creature known to you or the nearest creature of a specific kind (such as a human or a unicorn) if you have seen such a creature up close—within 30 feet—at least once. If the creature you described or named is in a different form, such as under the effects of a *Flesh to Stone* or *Polymorph* spell, this spell doesn't locate the creature.\n\nThis spell can't locate a creature if any thickness of lead blocks a direct path between you and the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-creature", "it"),
					Language = LanguageCode.It,
					Name = "Localizza Creatura",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "pelo di un segugio",
					Description = "L'incantatore descrive o nomina una creatura a lui familiare. Percepisce la direzione in cui si trova la creatura, se questa si trova entro 300 metri da lui. Se la creatura si sta muovendo, l'incantatore conosce la direzione del suo movimento.\n\nL'incantesimo può localizzare una creatura specifica conosciuta dall'incantatore, oppure la creatura più vicina di un tipo specifico (come un umano o un unicorno), se l'incantatore ha visto una creatura del genere da vicino (entro 9 metri) almeno una volta. Se la creatura descritta o nominata si trova in una forma diversa, per esempio sotto gli effetti di un incantesimo *carne in pietra* o *metamorfosi*, questo incantesimo non la localizza.\n\nQuesto incantesimo non può localizzare una creatura se uno strato di piombo, di qualsiasi spessore, blocca il percorso diretto tra l'incantatore e la creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
