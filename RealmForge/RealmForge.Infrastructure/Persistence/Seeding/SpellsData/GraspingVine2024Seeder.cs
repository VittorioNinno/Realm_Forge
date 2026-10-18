using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Grasping Vine (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class GraspingVine2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grasping-vine");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grasping-vine", "en"),
					Language = LanguageCode.En,
					Name = "Grasping Vine",
					CastingTime = "Bonus Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You make a sturdy vine sprout from a surface in an unoccupied space within range that you can see. The vine lasts for the duration and lashes out at your command.\n\nWhen the vine appears, and again as a Bonus Action on each of your later turns, you make a melee spell attack against one creature within 30 feet of the vine. A hit deals 4d8 Bludgeoning damage and hauls the creature up to 30 feet closer to the vine; if the creature is Huge or smaller, it is also Grappled, and the escape DC equals your spell save DC.\n\nThe vine can keep hold of only one creature at a time. You can make it release a creature it holds at any moment, without using an action.",
					HigherLevels = "For each slot level above 4, the vine can hold one more creature at once."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grasping-vine", "it"),
					Language = LanguageCode.It,
					Name = "Rampicante Afferrante",
					CastingTime = "Azione bonus",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore fa germogliare un robusto rampicante da una superficie, in uno spazio libero entro gittata che è in grado di vedere. Il rampicante dura per tutta la durata e sferza al suo comando.\n\nQuando il rampicante compare, e di nuovo con un'azione bonus in ognuno dei turni successivi, l'incantatore effettua un attacco con incantesimo in mischia contro una creatura entro 9 metri dal rampicante. Un colpo a segno infligge 4d8 danni contundenti e trascina la creatura fino a 9 metri più vicino al rampicante; se la creatura è di taglia Enorme o inferiore, è anche afferrata, e la CD per liberarsi è pari alla CD del tiro salvezza degli incantesimi dell'incantatore.\n\nIl rampicante può trattenere una sola creatura alla volta. L'incantatore può fargli rilasciare la creatura trattenuta in qualsiasi momento, senza usare alcuna azione.",
					HigherLevels = "Per ogni livello dello slot oltre il 4°, il rampicante può trattenere una creatura in più contemporaneamente."
				}
			}
		};
	}
}
