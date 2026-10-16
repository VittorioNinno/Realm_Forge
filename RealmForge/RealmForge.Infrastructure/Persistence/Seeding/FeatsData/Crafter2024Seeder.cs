using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crafter feat (2024 ruleset) with Markdown tables.
///	</summary>
public static class Crafter2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555545");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555951");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555952");

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
					Name = "Crafter",
					Description = "Your skilled hands save you money and produce useful gear in no time.\n- **Artisan Training.** You gain proficiency with three different Artisan's Tools of your choice from the table below.\n- **Good Deal.** You pay 20 percent less for any nonmagical item you buy.\n- **Overnight Work.** When you finish a Long Rest, you can make one item from the table below, as long as you have the matching Artisan's Tools and are proficient with them. The item holds together until the end of your next Long Rest, then falls apart.\n\n### Quick Crafting\n| Tools | Items you can make |\n|---|---|\n| Carpenter's Tools | Ladder, Torch |\n| Leatherworker's Tools | Crossbow Bolt Case, Map or Scroll Case, Pouch |\n| Mason's Tools | Block and Tackle |\n| Potter's Tools | Jug, Lamp |\n| Smith's Tools | Ball Bearings, Bucket, Caltrops, Grappling Hook, Iron Pot |\n| Tinker's Tools | Bell, Shovel, Tinderbox |\n| Weaver's Tools | Basket, Rope, Net, Tent |\n| Woodcarver's Tools | Club, Greatclub, Quarterstaff |"
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lavoro Manuale",
					Description = "Le mani esperte del personaggio gli fanno risparmiare denaro e producono in poco tempo attrezzature utili.\n- **Addestramento artigiano.** Ottiene competenza in tre diversi strumenti da artigiano a sua scelta tra quelli della tabella seguente.\n- **Buon affare.** Paga il 20 per cento in meno qualsiasi oggetto non magico che acquista.\n- **Lavoro notturno.** Quando termina un riposo lungo, può realizzare un oggetto della tabella seguente, purché disponga degli strumenti da artigiano corrispondenti e ne abbia la competenza. L'oggetto regge fino al termine del riposo lungo successivo, poi va in pezzi.\n\n### Lavorazione rapida\n| Strumenti | Oggetti realizzabili |\n|---|---|\n| Strumenti da falegname | Scala a pioli, torcia |\n| Strumenti da conciatore | Custodia per quadrelli, custodia per mappe o pergamene, borsa |\n| Strumenti da muratore | Carrucola |\n| Strumenti da vasaio | Brocca, lampada |\n| Strumenti da fabbro | Biglie, secchio, triboli, rampino, pentola di ferro |\n| Strumenti da inventore | Campanella, pala, acciarino |\n| Strumenti da tessitore | Cesto, corda, rete, tenda |\n| Strumenti da intagliatore | Randello, randello pesante, bastone ferrato |"
				}
			}
		};
	}
}