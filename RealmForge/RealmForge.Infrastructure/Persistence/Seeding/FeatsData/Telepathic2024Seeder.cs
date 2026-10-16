using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Telepathic feat (2024 ruleset).
///	</summary>
public static class Telepathic2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555594");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551441");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551442");

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
					Name = "Telepathic",
					Description = "Your thoughts can reach the minds of others.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20. This is your spellcasting ability for this feat.\n- **Mind Speech.** You can speak telepathically to any creature you can see within 60 feet of you, in a language you know; it understands only if it knows that language. This doesn't let the creature answer telepathically.\n- **Read Thoughts.** You always have Detect Thoughts prepared. You can cast it once without a spell slot or components, regaining that free casting when you finish a Long Rest, and you can also cast it with spell slots of the right level."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Telepatia",
					Description = "I pensieri del personaggio possono raggiungere la mente altrui.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20. È la sua caratteristica da incantatore per questo talento.\n- **Voce mentale.** Può parlare telepaticamente a qualsiasi creatura che può vedere entro 18 metri, in un linguaggio che conosce; la creatura lo capisce solo se conosce quel linguaggio. Questo non le permette di rispondere telepaticamente.\n- **Leggere i pensieri.** Ha sempre preparato Individuazione dei Pensieri. Può lanciarlo una volta senza slot né componenti, recuperando questo lancio gratuito quando termina un riposo lungo, e può lanciarlo anche usando slot incantesimo del livello adeguato."
				}
			}
		};
	}
}