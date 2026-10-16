using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Healer feat (2024 ruleset).
///	</summary>
public static class Healer2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555546");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555961");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555962");

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
					Name = "Healer",
					Description = "Your field medicine keeps your companions on their feet.\n- **Field Medic.** If you have a Healer's Kit, you can take the Utilize action to spend one use of it and treat a creature within 5 feet of you. That creature can spend one of its Hit Point Dice; you roll it, and the creature regains Hit Points equal to the roll + your Proficiency Bonus.\n- **Reliable Healing.** When you roll a die to determine Hit Points restored by a spell or by Field Medic, you can reroll a 1, but you must keep the new result."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Guaritore",
					Description = "Le cure da campo del personaggio tengono in piedi i suoi compagni.\n- **Medico da campo.** Se possiede una borsa del guaritore, può effettuare l'azione Utilizzare per spenderne un utilizzo e curare una creatura entro 1,5 metri. Quella creatura può spendere uno dei suoi Dadi Vita; il personaggio lo tira e la creatura recupera punti ferita pari al risultato + il bonus di competenza del personaggio.\n- **Cure affidabili.** Quando tira un dado per determinare i punti ferita ripristinati da un incantesimo o da Medico da campo, può ritirare un 1, ma deve tenere il nuovo risultato."
				}
			}
		};
	}
}