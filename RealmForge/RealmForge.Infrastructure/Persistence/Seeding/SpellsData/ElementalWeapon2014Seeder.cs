using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Elemental Weapon (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ElementalWeapon2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "elemental-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "elemental-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Elemental Weapon",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You touch a nonmagical weapon and infuse it with elemental power, turning it into a magic weapon. Choose acid, cold, fire, lightning, or thunder. For the duration, the weapon has a +1 bonus to attack rolls and deals an extra 1d4 damage of the chosen type when it hits.",
					HigherLevels = "When you cast this spell using a spell slot of 5th or 6th level, the attack bonus becomes +2 and the extra damage becomes 2d4. When you use a spell slot of 7th level or higher, the bonus becomes +3 and the extra damage becomes 3d4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "elemental-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Elementale",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca un'arma non magica e la infonde di potere elementale, trasformandola in un'arma magica. Sceglie acido, freddo, fuoco, fulmine o tuono. Per la durata, l'arma conferisce un bonus di +1 ai tiri per colpire e, quando colpisce, infligge 1d4 danni extra del tipo scelto.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° o di 6° livello, il bonus ai tiri per colpire diventa +2 e i danni extra diventano 2d4. Quando usa uno slot incantesimo di 7° livello o superiore, il bonus diventa +3 e i danni extra diventano 3d4."
				}
			}
		};
	}
}
