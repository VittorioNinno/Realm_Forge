using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Charger feat (2024 ruleset).
///	</summary>
public static class Charger2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555557");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551071");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551072");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			PrerequisiteMinimumLevel = 4,
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Charger",
					Description = "You turn a running start into a devastating blow.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Faster Dash.** When you take the Dash action, your Speed increases by 10 feet for that action.\n- **Charging Hit.** If you move at least 10 feet in a straight line toward a target right before hitting it with a melee attack roll during the Attack action, choose one: the attack deals an extra 1d8 damage, or you push the target up to 10 feet away (only if it is no more than one size larger than you). You can use this benefit only once per turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Carica",
					Description = "Il personaggio trasforma una rincorsa in un colpo devastante.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Scatto più rapido.** Quando effettua l'azione Scatto, la sua velocità aumenta di 3 metri per quell'azione.\n- **Colpo in carica.** Se si muove di almeno 3 metri in linea retta verso un bersaglio subito prima di colpirlo con un tiro per colpire in mischia durante l'azione Attacco, sceglie un effetto: l'attacco infligge 1d8 danni aggiuntivi, oppure spinge il bersaglio fino a 3 metri di distanza (solo se non è più di una taglia più grande di lui). Può usare questo beneficio solo una volta per turno."
				}
			}
		};
	}
}