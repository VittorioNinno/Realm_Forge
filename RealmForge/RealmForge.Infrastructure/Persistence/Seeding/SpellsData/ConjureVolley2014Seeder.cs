using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Volley (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ConjureVolley2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-volley");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-volley", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Volley",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "one piece of ammunition or one thrown weapon",
					Description = "You fire a piece of nonmagical ammunition from a ranged weapon, or throw a nonmagical weapon, toward a point within range. In midair it multiplies into hundreds of copies that fall in a cylinder with a 40-foot radius and a height of 20 feet, centered on that point. Each creature in the cylinder makes a Dexterity saving throw, taking 8d8 damage on a failure or half as much on a success. The damage type matches the weapon or ammunition used.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-volley", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Pioggia di Armi",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "una munizione o un'arma da lancio",
					Description = "L'incantatore scocca una munizione non magica con un'arma a distanza, o lancia un'arma non magica, verso un punto entro gittata. A mezz'aria il proiettile si moltiplica in centinaia di copie che ricadono in un cilindro del raggio di 12 metri e alto 6 metri, centrato su quel punto. Ogni creatura nel cilindro effettua un tiro salvezza su Destrezza; subisce 8d8 danni se lo fallisce, o la metà di quei danni se lo supera. Il tipo di danno è quello dell'arma o della munizione usata.",
					HigherLevels = null
				}
			}
		};
	}
}
