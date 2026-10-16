using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Magic Initiate feat (2014 ruleset).
///	</summary>
public static class MagicInitiate2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555523");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555731");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555732");

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
					Name = "Magic Initiate",
					Description = "You have picked up the basics of one tradition of magic.\n- **Chosen Tradition.** Choose bard, cleric, druid, sorcerer, warlock, or wizard. Your spellcasting ability for this feat is Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; Intelligence for wizard.\n- **Cantrips.** You learn two cantrips of your choice from that class's spell list.\n- **1st-Level Spell.** You also learn one 1st-level spell from the same list. You can cast it at its lowest level once, and then you must finish a long rest before casting it this way again."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Iniziato alla Magia",
					Description = "Il personaggio ha appreso le basi di una tradizione magica.\n- **Tradizione prescelta.** Sceglie bardo, chierico, druido, mago, stregone o warlock. La caratteristica da incantatore per questo talento è Carisma per bardo, stregone o warlock; Saggezza per chierico o druido; Intelligenza per mago.\n- **Trucchetti.** Impara due trucchetti a sua scelta dalla lista degli incantesimi di quella classe.\n- **Incantesimo di 1° livello.** Impara anche un incantesimo di 1° livello dalla stessa lista. Può lanciarlo al livello più basso una volta, poi deve terminare un riposo lungo prima di poterlo lanciare di nuovo in questo modo."
				}
			}
		};
	}
}