using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shadow Touched feat (2024 ruleset).
///	</summary>
public static class ShadowTouched2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555585");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551351");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551352");

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
					Name = "Shadow Touched",
					Description = "Contact with the magic of the Shadowfell has left its mark on you.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20. This is your spellcasting ability for this feat.\n- **Shadow Gifts.** You always have Invisibility prepared, plus one level 1 Illusion or Necromancy spell of your choice. You can cast each of them once without a spell slot, regaining that free casting when you finish a Long Rest, and you can also cast them with spell slots of the right level."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Contaminazione Oscura",
					Description = "Il contatto con la magia della Coltre Oscura ha lasciato il segno sul personaggio.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20. È la sua caratteristica da incantatore per questo talento.\n- **Doni dell'ombra.** Ha sempre preparati Invisibilità e un incantesimo di 1° livello di Illusione o di Necromanzia a sua scelta. Può lanciare ciascuno dei due una volta senza spendere uno slot, recuperando questo lancio gratuito quando termina un riposo lungo, e può lanciarli anche usando slot incantesimo del livello adeguato."
				}
			}
		};
	}
}