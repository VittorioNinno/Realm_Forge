using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Elemental Weapon (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ElementalWeapon2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elemental-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elemental-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Elemental Weapon",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You touch a weapon that isn't magical and charge it with one element: Acid, Cold, Fire, Lightning, or Thunder. For the duration the weapon counts as magical, attack rolls made with it gain a +1 bonus, and each hit with it adds 1d4 damage of the element you picked.",
					HigherLevels = "Using a slot of level 5 or 6 raises the bonus to +2 and the extra damage to 2d4. Using a slot of level 7 or higher raises them to +3 and 3d4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elemental-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Elementale",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca un'arma non magica e la carica con un elemento: acido, freddo, fuoco, fulmine o tuono. Per la durata l'arma è considerata magica, i tiri per colpire effettuati con essa ottengono un bonus di +1 e ogni colpo andato a segno aggiunge 1d4 danni dell'elemento scelto.",
					HigherLevels = "Con uno slot di 5° o 6° livello il bonus sale a +2 e i danni extra a 2d4. Con uno slot di 7° livello o superiore salgono a +3 e 3d4."
				}
			}
		};
	}
}
