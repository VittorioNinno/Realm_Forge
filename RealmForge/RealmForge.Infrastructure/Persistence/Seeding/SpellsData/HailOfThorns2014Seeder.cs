using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hail of Thorns (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class HailOfThorns2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hail-of-thorns");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hail-of-thorns", "en"),
					Language = LanguageCode.En,
					Name = "Hail of Thorns",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a ranged weapon attack before this spell ends, your weapon or ammunition bursts into a shower of thorns. Besides the attack's normal effect, the target and every creature within 5 feet of it make a Dexterity saving throw, taking 1d10 piercing damage on a failure or half as much on a success.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d10 for each slot level above 1st, up to a maximum of 6d10."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hail-of-thorns", "it"),
					Language = LanguageCode.It,
					Name = "Raffica di Spine",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma a distanza prima che questo incantesimo termini, la sua arma o la sua munizione esplode in una pioggia di spine. Oltre al normale effetto dell'attacco, il bersaglio e ogni creatura entro 1,5 metri da esso effettuano un tiro salvezza su Destrezza; subiscono 1d10 danni perforanti se lo falliscono, o la metà di quei danni se lo superano.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d10 per ogni livello dello slot superiore al 1°, fino a un massimo di 6d10."
				}
			}
		};
	}
}
