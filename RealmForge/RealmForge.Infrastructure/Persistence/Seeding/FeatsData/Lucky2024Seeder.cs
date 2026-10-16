using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lucky feat (2024 ruleset).
///	</summary>
public static class Lucky2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555547");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555971");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555972");

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
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Lucky",
					Description = "Fortune has a habit of smiling on you.\n- **Luck Points.** You have Luck Points equal to your Proficiency Bonus, and you regain all spent points when you finish a Long Rest.\n- **Lucky Break.** When you roll a d20 for a D20 Test, you can spend 1 Luck Point to give that roll Advantage.\n- **Bad Luck for Them.** When a creature rolls a d20 to attack you, you can spend 1 Luck Point to give that roll Disadvantage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Fortunato",
					Description = "La fortuna ha l'abitudine di sorridere al personaggio.\n- **Punti fortuna.** Ha un numero di punti fortuna pari al suo bonus di competenza e recupera tutti quelli spesi quando termina un riposo lungo.\n- **Colpo di fortuna.** Quando tira un d20 per una Prova del d20, può spendere 1 punto fortuna per dare Vantaggio a quel tiro.\n- **Sfortuna altrui.** Quando una creatura tira un d20 per attaccarlo, può spendere 1 punto fortuna per imporre Svantaggio a quel tiro."
				}
			}
		};
	}
}