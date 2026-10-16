using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mage Slayer feat (2014 ruleset).
///	</summary>
public static class MageSlayer2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555522");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555721");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555722");

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
					Name = "Mage Slayer",
					Description = "You have trained to hunt down spellcasters.\n- **Punish the Caster.** When a creature within 5 feet of you casts a spell, you can use your reaction to make a melee weapon attack against it.\n- **Break Concentration.** A creature you damage while it is concentrating on a spell has disadvantage on the saving throw to keep its concentration.\n- **Close-Range Ward.** You have advantage on saving throws against spells cast by creatures within 5 feet of you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sterminatore di Maghi",
					Description = "Il personaggio si è addestrato a dare la caccia agli incantatori.\n- **Punire l'incantatore.** Quando una creatura entro 1,5 metri da lui lancia un incantesimo, può usare la reazione per effettuare un attacco con un'arma da mischia contro di essa.\n- **Spezzare la concentrazione.** Una creatura a cui infligge danni mentre si concentra su un incantesimo ha svantaggio al tiro salvezza per mantenere la concentrazione.\n- **Difesa ravvicinata.** Ha vantaggio ai tiri salvezza contro gli incantesimi lanciati da creature entro 1,5 metri da lui."
				}
			}
		};
	}
}