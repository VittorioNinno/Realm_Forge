using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Spell Sniper feat (2024 ruleset).
///	</summary>
public static class SpellSniper2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555592");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551421");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551422");

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
			PrerequisiteFeature = FeatFeatureRequirement.SpellcastingOrPactMagic,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Spell Sniper",
					Description = "You have refined the spells you hurl at distant targets.\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Bypass Cover.** Your spell attack rolls ignore Half Cover and Three-Quarters Cover.\n- **Casting in Melee.** Having an enemy within 5 feet of you doesn't give you Disadvantage on spell attack rolls.\n- **Increased Range.** When you cast a spell with a range of at least 10 feet that requires an attack roll, you can increase its range by 60 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cecchino Magico",
					Description = "Il personaggio ha affinato gli incantesimi che scaglia contro bersagli lontani.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Ignora Copertura.** I suoi tiri per colpire con incantesimi ignorano la Mezza Copertura e la Copertura Tre Quarti.\n- **Lancio in Mischia.** Avere un nemico entro 1,5 metri non gli impone Svantaggio ai tiri per colpire con incantesimi.\n- **Gittata Aumentata.** Quando lancia un incantesimo con gittata di almeno 3 metri che richiede un tiro per colpire, può aumentarne la gittata di 18 metri."
				}
			}
		};
	}
}