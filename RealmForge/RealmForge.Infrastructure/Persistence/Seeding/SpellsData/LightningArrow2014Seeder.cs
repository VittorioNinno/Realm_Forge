using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Lightning Arrow (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class LightningArrow2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-arrow");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-arrow", "en"),
					Language = LanguageCode.En,
					Name = "Lightning Arrow",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you make a ranged weapon attack during the spell's duration, the ammunition, or the weapon itself if it's a thrown weapon, turns into a bolt of lightning. Make the attack roll as normal. Instead of the weapon's usual damage, the target takes 4d8 lightning damage on a hit, or half as much on a miss.\n\nHit or miss, each creature within 10 feet of the target makes a Dexterity saving throw, taking 2d8 lightning damage on a failure or half as much on a success. The ammunition or weapon then returns to its normal form.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage of both effects increases by 1d8 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "lightning-arrow", "it"),
					Language = LanguageCode.It,
					Name = "Freccia Folgorante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore effettua un attacco con un'arma a distanza finché l'incantesimo dura, la munizione, o l'arma stessa se si tratta di un'arma da lancio, si trasforma in un fulmine. L'incantatore effettua normalmente il tiro per colpire. Invece dei normali danni dell'arma, il bersaglio subisce 4d8 danni da fulmine se l'attacco colpisce, o la metà di quei danni se manca.\n\nChe l'attacco colpisca o manchi, ogni creatura entro 3 metri dal bersaglio effettua un tiro salvezza su Destrezza; subisce 2d8 danni da fulmine se lo fallisce, o la metà di quei danni se lo supera. Poi la munizione o l'arma riprende la sua forma normale.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni di entrambi gli effetti aumentano di 1d8 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
