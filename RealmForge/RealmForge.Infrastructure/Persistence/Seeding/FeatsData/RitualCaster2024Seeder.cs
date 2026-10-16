using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Ritual Caster feat (2024 ruleset).
///	</summary>
public static class RitualCaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555583");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551331");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551332");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Ritual Caster",
					Description = "You have studied the patient art of rituals.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20. This is your spellcasting ability for these spells.\n- **Known Rituals.** You always have prepared a number of level 1 spells with the Ritual tag equal to your Proficiency Bonus, and you can cast them with any spell slots you have. Each time your Proficiency Bonus increases, add one more level 1 Ritual spell to them.\n- **Swift Ritual.** Once per Long Rest, you can cast one of your prepared Ritual spells with its normal casting time instead of the longer ritual time, without spending a spell slot."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore Rituale",
					Description = "Il personaggio ha studiato la paziente arte dei rituali.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20. È la sua caratteristica da incantatore per questi incantesimi.\n- **Rituali conosciuti.** Ha sempre preparati un numero di incantesimi di 1° livello con il descrittore rituale pari al suo bonus di competenza e può lanciarli con qualsiasi slot incantesimo di cui dispone. Ogni volta che il suo bonus di competenza aumenta, ne aggiunge un altro di 1° livello con il descrittore rituale.\n- **Rituale rapido.** Una volta per riposo lungo, può lanciare uno dei suoi incantesimi rituali preparati con il normale tempo di lancio invece del tempo più lungo del rituale, senza spendere uno slot incantesimo."
				}
			}
		};
	}
}