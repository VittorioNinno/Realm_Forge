using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hail of Thorns (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class HailOfThorns2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hail-of-thorns");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hail-of-thorns", "en"),
					Language = LanguageCode.En,
					Name = "Hail of Thorns",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a Ranged weapon",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "As your shot strikes home, the ammunition (or the weapon itself) shatters into a shower of thorns. The creature you hit, along with every creature within 5 feet of it, attempts a Dexterity saving throw, suffering 1d10 Piercing damage if it fails or half that much if it succeeds.",
					HigherLevels = "Add 1d10 to the damage for each slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hail-of-thorns", "it"),
					Language = LanguageCode.It,
					Name = "Raffica di Spine",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma a distanza",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Mentre il colpo va a segno, la munizione (o l'arma stessa) si frantuma in una pioggia di spine. La creatura colpita, insieme a ogni creatura entro 1,5 metri da essa, tenta un tiro salvezza su Destrezza e subisce 1d10 danni perforanti se fallisce, o metà di quei danni se riesce.",
					HigherLevels = "Aggiungere 1d10 ai danni per ogni livello dello slot oltre il 1°."
				}
			}
		};
	}
}
