using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Resilient feat (2014 ruleset).
///	</summary>
public static class Resilient2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555531");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555811");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555812");

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
					Name = "Resilient",
					Description = "You have hardened yourself against one kind of threat.\n- Choose one ability and increase that score by 1, to a maximum of 20.\n- You gain proficiency in saving throws using the chosen ability."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Resiliente",
					Description = "Il personaggio si è temprato contro un tipo di minaccia.\n- Sceglie una caratteristica e ne aumenta il punteggio di 1, fino a un massimo di 20.\n- Ottiene competenza nei tiri salvezza di quella caratteristica."
				}
			}
		};
	}
}