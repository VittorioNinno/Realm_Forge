using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Spell Sniper feat (2014 ruleset).
///	</summary>
public static class SpellSniper2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555539");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555891");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555892");

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
			PrerequisiteFeature = FeatFeatureRequirement.Spellcasting,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Spell Sniper",
					Description = "You have refined the spells you hurl at distant targets.\n- Spells you cast that require an attack roll have their range doubled.\n- Your ranged spell attacks ignore half cover and three-quarters cover.\n- You learn one cantrip that requires an attack roll, chosen from the bard, cleric, druid, sorcerer, warlock, or wizard spell list. Its spellcasting ability is Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; Intelligence for wizard."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cecchino Magico",
					Description = "Il personaggio ha affinato gli incantesimi che scaglia contro bersagli lontani.\n- La gittata degli incantesimi che lancia e che richiedono un tiro per colpire raddoppia.\n- I suoi attacchi con incantesimo a distanza ignorano la mezza copertura e la copertura tre quarti.\n- Impara un trucchetto che richiede un tiro per colpire, scelto dalla lista degli incantesimi del bardo, chierico, druido, mago, stregone o warlock. La caratteristica da incantatore è Carisma per bardo, stregone o warlock; Saggezza per chierico o druido; Intelligenza per mago."
				}
			}
		};
	}
}