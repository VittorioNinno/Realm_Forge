using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cordon of Arrows (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CordonOfArrows2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cordon-of-arrows");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cordon-of-arrows", "en"),
					Language = LanguageCode.En,
					Name = "Cordon of Arrows",
					CastingTime = "1 action",
					Range = "5 feet",
					Duration = "8 hours",
					MaterialComponent = "four or more arrows or bolts",
					Description = "You plant four pieces of nonmagical ammunition (arrows or crossbow bolts) in the ground within range and set them to stand guard over the area. Until the spell ends, whenever a creature other than you comes within 30 feet of the ammunition for the first time on a turn or ends its turn there, one piece leaps up to strike it. The creature must succeed on a Dexterity saving throw or take 1d6 piercing damage, and that piece is destroyed. The spell ends when no ammunition is left.\n\nWhen you cast the spell, you can name any creatures you choose, and the spell ignores them.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the amount of ammunition that can be affected increases by two for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cordon-of-arrows", "it"),
					Language = LanguageCode.It,
					Name = "Cordone di Frecce",
					CastingTime = "1 azione",
					Range = "1,5 metri",
					Duration = "8 ore",
					MaterialComponent = "quattro o più frecce o quadrelli",
					Description = "L'incantatore pianta nel terreno entro gittata quattro munizioni non magiche (frecce o quadrelli) e le pone a guardia dell'area. Finché l'incantesimo non termina, ogni volta che una creatura diversa dall'incantatore arriva per la prima volta in un turno entro 9 metri dalle munizioni, o vi termina il proprio turno, una munizione balza in aria per colpirla. La creatura deve superare un tiro salvezza su Destrezza, altrimenti subisce 1d6 danni perforanti; in ogni caso quella munizione viene distrutta. L'incantesimo termina quando non restano più munizioni.\n\nQuando lancia l'incantesimo, l'incantatore può nominare qualsiasi creatura a sua scelta, e l'incantesimo la ignora.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, il numero di munizioni che possono essere influenzate aumenta di due per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
