using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Fey Touched feat (2024 ruleset).
///	</summary>
public static class FeyTouched2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555565");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551151");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551152");

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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Fey Touched",
					Description = "Contact with the magic of the Feywild has left its mark on you.\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20. This is your spellcasting ability for this feat.\n- **Fey Magic.** You always have Misty Step prepared, plus one level 1 Divination or Enchantment spell of your choice. You can cast each of them once without a spell slot, regaining that free casting when you finish a Long Rest, and you can also cast them with spell slots of the right level."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Contaminazione Fatata",
					Description = "Il contatto con la magia della Selva Fatata ha lasciato il segno sul personaggio.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20. È la sua caratteristica da incantatore per questo talento.\n- **Magia Fatata.** Ha sempre preparati Passo Velato e un incantesimo di 1° livello di Divinazione o di Ammaliamento a sua scelta. Può lanciare ciascuno dei due una volta senza spendere uno slot, recuperando questo lancio gratuito quando termina un Riposo Lungo, e può lanciarli anche usando slot incantesimo del livello adeguato."
				}
			}
		};
	}
}