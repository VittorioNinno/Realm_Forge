using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Volley (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ConjureVolley2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-volley");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-volley", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Volley",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a Melee or Ranged weapon worth at least 1 CP",
					Description = "You lift the weapon used to cast the spell toward a point within range, and a downpour of hundreds of spectral copies of it (or of fitting ammunition) crashes onto that spot before fading away. The strike fills a Cylinder 40 feet in radius and 20 feet tall centered on the point. Every creature you choose that you can see in the area attempts a Dexterity saving throw, suffering 8d8 Force damage if it fails or half that much if it succeeds.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-volley", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Pioggia di Armi",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "un'arma da mischia o a distanza del valore di almeno 1 mr",
					Description = "L'incantatore punta l'arma usata per lanciare l'incantesimo verso un punto entro gittata, e un diluvio di centinaia di sue copie spettrali (o di munizioni adeguate) si abbatte su quel punto prima di dissolversi. L'impatto riempie un cilindro di 12 metri di raggio e 6 metri di altezza centrato sul punto. Ogni creatura visibile scelta dall'incantatore nell'area tenta un tiro salvezza su Destrezza e subisce 8d8 danni da forza se fallisce, o metà di quei danni se riesce.",
					HigherLevels = null
				}
			}
		};
	}
}
