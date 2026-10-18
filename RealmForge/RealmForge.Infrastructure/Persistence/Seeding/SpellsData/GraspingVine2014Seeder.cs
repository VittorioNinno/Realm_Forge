using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Grasping Vine (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class GraspingVine2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "grasping-vine");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "grasping-vine", "en"),
					Language = LanguageCode.En,
					Name = "Grasping Vine",
					CastingTime = "1 bonus action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A vine springs from the ground in an unoccupied space of your choice that you can see within range. When you cast the spell, you can have the vine lash out at a creature within 30 feet of it that you can see. That creature must succeed on a Dexterity saving throw or be dragged 20 feet straight toward the vine.\n\nUntil the spell ends, you can use a bonus action on each of your turns to have the vine lash out again, at the same creature or a different one.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "grasping-vine", "it"),
					Language = LanguageCode.It,
					Name = "Rampicante Afferrante",
					CastingTime = "1 azione bonus",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un rampicante spunta dal terreno in uno spazio libero entro gittata, scelto dall'incantatore e che egli sia in grado di vedere. Quando lancia l'incantesimo, l'incantatore può far sferzare il rampicante contro una creatura entro 9 metri da esso che sia in grado di vedere. Quella creatura deve superare un tiro salvezza su Destrezza, altrimenti viene trascinata di 6 metri in linea retta verso il rampicante.\n\nFinché l'incantesimo non termina, in ognuno dei suoi turni l'incantatore può usare un'azione bonus per far sferzare di nuovo il rampicante, contro la stessa creatura o contro una diversa.",
					HigherLevels = null
				}
			}
		};
	}
}
