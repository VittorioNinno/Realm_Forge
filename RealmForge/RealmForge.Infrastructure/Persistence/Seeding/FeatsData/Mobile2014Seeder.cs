using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mobile feat (2014 ruleset).
///	</summary>
public static class Mobile2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555526");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555761");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555762");

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
					Name = "Mobile",
					Description = "You are fast and hard to pin down.\n- **Swift.** Your speed increases by 10 feet.\n- **Sure-Footed Dash.** On a turn in which you take the Dash action, difficult terrain costs you no extra movement.\n- **Hit and Run.** After you make a melee attack against a creature, that creature can't make opportunity attacks against you for the rest of your turn, whether you hit or missed."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Mobilità",
					Description = "Il personaggio è veloce e difficile da bloccare.\n- **Rapido.** La sua velocità aumenta di 3 metri.\n- **Scatto sicuro.** Nel turno in cui usa l'azione Scatto, il terreno difficile non gli costa movimento aggiuntivo.\n- **Colpisci e fuggi.** Dopo aver effettuato un attacco in mischia contro una creatura, quella creatura non può effettuare attacchi di opportunità contro di lui per il resto del turno, che l'attacco sia andato a segno o meno."
				}
			}
		};
	}
}