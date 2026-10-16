using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Actor feat (2014 ruleset).
///	</summary>
public static class Actor2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555504");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555541");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555542");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Actor",
					Description = "Stage training lets you slip convincingly into other identities.\n- **Charisma +1.** Increase your Charisma score by 1, to a maximum of 20.\n- **Convincing Disguise.** You have advantage on Charisma (Deception) and Charisma (Performance) checks made to pose as someone else.\n- **Voice Mimicry.** After hearing a person speak, or a creature make a sound, for at least 1 minute, you can reproduce that voice or sound. A listener can tell the imitation is fake by winning a Wisdom (Insight) check against your Charisma (Deception) check."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Attore",
					Description = "L'esperienza sul palco permette al personaggio di calarsi in modo credibile in altre identità.\n- **Carisma +1.** Il punteggio di Carisma aumenta di 1, fino a un massimo di 20.\n- **Travestimento convincente.** Ha vantaggio alle prove di Carisma (Inganno) e Carisma (Intrattenere) effettuate per spacciarsi per qualcun altro.\n- **Imitazione vocale.** Dopo aver ascoltato una persona parlare, o una creatura emettere un suono, per almeno 1 minuto, può riprodurne la voce o il suono. Chi ascolta capisce che si tratta di un'imitazione se vince una prova di Saggezza (Intuizione) contro la prova di Carisma (Inganno) del personaggio."
				}
			}
		};
	}
}