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
					Description = "You have refined the spells you hurl at distant targets.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20.\n- **Around Cover.** Your spell attack rolls ignore Half Cover and Three-Quarters Cover.\n- **Close-Quarters Casting.** Having an enemy within 5 feet of you doesn't give you Disadvantage on spell attack rolls.\n- **Extended Reach.** When you cast a spell with a range of at least 10 feet that requires an attack roll, you can increase its range by 60 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cecchino Magico",
					Description = "Il personaggio ha affinato gli incantesimi che scaglia contro bersagli lontani.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20.\n- **Oltre la copertura.** I suoi tiri per colpire con incantesimi ignorano la mezza copertura e la copertura tre quarti.\n- **Incantesimi ravvicinati.** Avere un nemico entro 1,5 metri non gli impone Svantaggio ai tiri per colpire con incantesimi.\n- **Portata estesa.** Quando lancia un incantesimo con gittata di almeno 3 metri che richiede un tiro per colpire, può aumentarne la gittata di 18 metri."
				}
			}
		};
	}
}