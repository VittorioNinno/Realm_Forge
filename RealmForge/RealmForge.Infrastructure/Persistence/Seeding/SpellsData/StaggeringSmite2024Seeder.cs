using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Staggering Smite (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class StaggeringSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "staggering-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "staggering-smite", "en"),
					Language = LanguageCode.En,
					Name = "Staggering Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Your strike reverberates through the creature's mind as well as its body. Besides the attack's usual damage, it suffers 4d6 extra Psychic damage. It then attempts a Wisdom saving throw; if it fails, it is Stunned until your next turn ends.",
					HigherLevels = "Add 1d6 to the extra damage for each slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "staggering-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Demoralizzante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Il colpo dell'incantatore si ripercuote nella mente della creatura oltre che nel suo corpo. Oltre ai normali danni dell'attacco, la creatura subisce 4d6 danni psichici extra. Poi tenta un tiro salvezza su Saggezza; se fallisce, è stordita fino al termine del turno successivo dell'incantatore.",
					HigherLevels = "Aggiungere 1d6 ai danni extra per ogni livello dello slot oltre il 4°."
				}
			}
		};
	}
}
