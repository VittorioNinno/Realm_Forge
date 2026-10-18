using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Freedom of Movement (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FreedomOfMovement2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freedom-of-movement");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freedom-of-movement", "en"),
					Language = LanguageCode.En,
					Name = "Freedom of Movement",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a leather strap, bound around the arm or a similar appendage",
					Description = "You touch a willing creature. For the duration, the target's movement is unaffected by difficult terrain, and spells and other magical effects can neither reduce the target's speed nor cause the target to be paralyzed or restrained.\n\nThe target can also spend 5 feet of movement to automatically escape from nonmagical restraints, such as manacles or a creature that has it grappled. Finally, being underwater imposes no penalties on the target's movement or attacks.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "freedom-of-movement", "it"),
					Language = LanguageCode.It,
					Name = "Libertà di Movimento",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una cinghia di cuoio, legata attorno al braccio o a un'appendice simile",
					Description = "L'incantatore tocca una creatura consenziente. Per la durata, il movimento del bersaglio non è influenzato dal terreno difficile, e gli incantesimi e gli altri effetti magici non possono né ridurre la velocità del bersaglio né renderlo paralizzato o trattenuto.\n\nIl bersaglio può inoltre spendere 1,5 metri di movimento per liberarsi automaticamente da costrizioni non magiche, come delle manette o una creatura che lo tiene afferrato. Infine, trovarsi sott'acqua non impone alcuna penalità al movimento o agli attacchi del bersaglio.",
					HigherLevels = null
				}
			}
		};
	}
}
