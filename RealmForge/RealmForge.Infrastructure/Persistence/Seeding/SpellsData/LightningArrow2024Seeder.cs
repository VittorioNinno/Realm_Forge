using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Lightning Arrow (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class LightningArrow2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-arrow");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-arrow", "en"),
					Language = LanguageCode.En,
					Name = "Lightning Arrow",
					CastingTime = "Bonus Action, which you take immediately after hitting or missing a target with a ranged attack using a weapon",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Your shot becomes a stroke of lightning, hit or miss. The attack deals no normal damage and has none of its usual effects; instead its target suffers 4d8 Lightning damage on a hit, or half that much on a miss. The bolt then bursts, and every creature within 10 feet of the target attempts a Dexterity saving throw, suffering 2d8 Lightning damage if it fails or half that much if it succeeds.\n\nOnce the lightning fades, the weapon or ammunition is back in its ordinary form.",
					HigherLevels = "For each slot level above 3, add 1d8 to the damage of both the strike and the burst."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lightning-arrow", "it"),
					Language = LanguageCode.It,
					Name = "Freccia Folgorante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito o mancato un bersaglio con un attacco a distanza effettuato con un'arma",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Che vada a segno o meno, il colpo diventa una scarica di fulmine. L'attacco non infligge i danni normali e non ha nessuno dei suoi effetti abituali; il bersaglio subisce invece 4d8 danni da fulmine se colpito, o metà di quei danni se mancato. La scarica poi esplode, e ogni creatura entro 3 metri dal bersaglio tenta un tiro salvezza su Destrezza e subisce 2d8 danni da fulmine se fallisce, o metà di quei danni se riesce.\n\nQuando il fulmine si dissolve, l'arma o la munizione riprende la sua forma ordinaria.",
					HigherLevels = "Per ogni livello dello slot oltre il 3°, aggiungere 1d8 ai danni sia del colpo sia dell'esplosione."
				}
			}
		};
	}
}
