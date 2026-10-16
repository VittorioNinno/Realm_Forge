using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tavern Brawler feat (2024 ruleset).
///	</summary>
public static class TavernBrawler2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555552");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551021");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551022");

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
					Name = "Tavern Brawler",
					Description = "Fists, chairs, and bottles are all weapons in your hands.\n- **Heavy Fists.** When your Unarmed Strike hits and deals damage, you can deal Bludgeoning damage equal to 1d4 + your Strength modifier instead of the normal damage.\n- **Steady Punches.** When you roll a damage die for your Unarmed Strike and get a 1, you can reroll it, but you must use the new result.\n- **Improvised Weapons.** You are proficient with improvised weapons.\n- **Shove Back.** Once per turn, when you hit a creature with an Unarmed Strike as part of the Attack action, you can both damage it and push it 5 feet away from you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore da Taverna",
					Description = "Pugni, sedie e bottiglie sono tutte armi nelle mani del personaggio.\n- **Pugni pesanti.** Quando il suo colpo senz'armi colpisce e infligge danni, può infliggere danni contundenti pari a 1d4 + il suo modificatore di Forza invece dei danni normali.\n- **Pugni costanti.** Quando tira un dado di danno per il suo colpo senz'armi e ottiene 1, può ritirarlo, ma deve usare il nuovo risultato.\n- **Armi improvvisate.** Ha competenza nelle armi improvvisate.\n- **Respingere.** Una volta per turno, quando colpisce una creatura con un colpo senz'armi durante l'azione Attacco, può sia infliggerle danni sia spingerla di 1,5 metri lontano da sé."
				}
			}
		};
	}
}