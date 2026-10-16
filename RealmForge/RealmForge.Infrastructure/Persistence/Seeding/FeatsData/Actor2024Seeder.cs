using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Actor feat (2024 ruleset).
///	</summary>
public static class Actor2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555555");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551051");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551052");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Actor",
					Description = "Stage training lets you become someone else in voice and manner.\n- **Ability Score Increase.** Increase your Charisma score by 1, to a maximum of 20.\n- **Impersonation.** While disguised as a real or invented person, you have Advantage on Charisma (Deception or Performance) checks made to pass yourself off as that person.\n- **Mimicry.** You can imitate the sounds other creatures make, speech included. A listener realizes the sound is an imitation only by succeeding on a Wisdom (Insight) check against DC 8 + your Charisma modifier + your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Attore",
					Description = "L'esperienza sul palco permette al personaggio di diventare qualcun altro nella voce e nei modi.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Carisma aumenta di 1, fino a un massimo di 20.\n- **Impersonificazione.** Mentre è travestito da una persona reale o inventata, ha Vantaggio alle prove di Carisma (Inganno o Intrattenere) effettuate per spacciarsi per quella persona.\n- **Imitare.** Può imitare i suoni emessi da altre creature, voce compresa. Chi ascolta capisce che si tratta di un'imitazione solo se supera una prova di Saggezza (Intuizione) con CD 8 + il modificatore di Carisma del personaggio + il suo Bonus di Competenza."
				}
			}
		};
	}
}