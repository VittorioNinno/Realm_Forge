using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cordon of Arrows (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CordonOfArrows2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cordon-of-arrows");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cordon-of-arrows", "en"),
					Language = LanguageCode.En,
					Name = "Cordon of Arrows",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a decorative braided cord",
					Description = "You plant as many as four nonmagical Arrows or Bolts in the ground of your space and enchant them to stand guard; no physical force can remove them while the spell lasts. You can name any number of creatures for the guard to ignore.\n\nThe first time on a turn that another creature moves into a space within 30 feet of the planted ammunition, and whenever such a creature finishes its turn in that zone, one of the pieces launches itself at it. The creature attempts a Dexterity saving throw and suffers 2d4 Piercing damage if it fails. Either way, that piece is destroyed. Once no planted ammunition remains, the spell ends.",
					HigherLevels = "You can plant two more pieces of ammunition for each slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cordon-of-arrows", "it"),
					Language = LanguageCode.It,
					Name = "Cordone di Frecce",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un cordoncino intrecciato decorativo",
					Description = "L'incantatore pianta fino a quattro frecce o quadrelli non magici nel terreno del proprio spazio e li incanta perché facciano la guardia; finché l'incantesimo dura, nessuna forza fisica può rimuoverli. L'incantatore può indicare un qualsiasi numero di creature che la guardia ignorerà.\n\nLa prima volta in un turno in cui un'altra creatura si sposta in uno spazio entro 9 metri dalle munizioni piantate, e ogni volta che una creatura del genere conclude il proprio turno in quella zona, una delle munizioni si scaglia contro di lei. La creatura tenta un tiro salvezza su Destrezza e subisce 2d4 danni perforanti se fallisce. In ogni caso, quella munizione viene distrutta. Quando non resta più alcuna munizione piantata, l'incantesimo termina.",
					HigherLevels = "L'incantatore può piantare due munizioni in più per ogni livello dello slot oltre il 2°."
				}
			}
		};
	}
}
