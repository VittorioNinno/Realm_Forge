using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thunderous Smite (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ThunderousSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderous-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderous-smite", "en"),
					Language = LanguageCode.En,
					Name = "Thunderous Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a target with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Thunder booms from the point of impact, loud enough to be heard up to 300 feet from you. Along with the attack's usual damage, the target suffers 2d6 extra Thunder damage. If the target is a creature, it then attempts a Strength saving throw; on a failure, the blast hurls it 10 feet straight away from you and leaves it Prone.",
					HigherLevels = "Add 1d6 to the damage for each slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderous-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Tonante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito un bersaglio con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Dal punto d'impatto rimbomba un tuono, abbastanza forte da essere udito fino a 90 metri dall'incantatore. Oltre ai normali danni dell'attacco, il bersaglio subisce 2d6 danni da tuono extra. Se il bersaglio è una creatura, tenta poi un tiro salvezza su Forza; se fallisce, l'esplosione lo scaglia di 3 metri in direzione opposta all'incantatore e lo lascia prono.",
					HigherLevels = "Aggiungere 1d6 ai danni per ogni livello dello slot oltre il 1°."
				}
			}
		};
	}
}
