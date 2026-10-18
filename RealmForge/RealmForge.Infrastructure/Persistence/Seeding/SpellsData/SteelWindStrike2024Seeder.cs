using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Steel Wind Strike (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SteelWindStrike2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "steel-wind-strike");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "steel-wind-strike", "en"),
					Language = LanguageCode.En,
					Name = "Steel Wind Strike",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a Melee weapon worth 1+ SP",
					Description = "Spinning the weapon used to cast the spell, you dissolve into a whirlwind of blades that tears across the fight. Pick up to five creatures you can see within range and make a separate melee spell attack against each one; every hit deals 6d10 Force damage.\n\nWhen the attacks are done, you reappear by teleporting to an unoccupied space you can see within 5 feet of any one of the creatures you targeted.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "steel-wind-strike", "it"),
					Language = LanguageCode.It,
					Name = "Turbine Implacabile",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "un'arma da mischia del valore di almeno 1 ma",
					Description = "Facendo roteare l'arma usata per lanciare l'incantesimo, l'incantatore si dissolve in un turbine di lame che attraversa la mischia. Sceglie fino a cinque creature entro gittata che è in grado di vedere ed effettua un attacco con incantesimo in mischia separato contro ciascuna; ogni colpo a segno infligge 6d10 danni da forza.\n\nConclusi gli attacchi, l'incantatore ricompare teletrasportandosi in uno spazio libero che è in grado di vedere entro 1,5 metri da una qualsiasi delle creature prese di mira.",
					HigherLevels = null
				}
			}
		};
	}
}
