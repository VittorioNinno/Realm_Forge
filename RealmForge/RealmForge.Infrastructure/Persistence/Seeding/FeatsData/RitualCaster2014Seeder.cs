using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Ritual Caster feat (2014 ruleset).
///	</summary>
public static class RitualCaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555532");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555821");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555822");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Ritual Caster",
					Description = "You keep a book of rituals that you can perform with time and care.\n- **Ritual Book.** You gain a ritual book containing two 1st-level spells of your choice that have the ritual tag, taken from the spell list of one class: bard, cleric, druid, sorcerer, warlock, or wizard. You must hold the book to cast these spells, and you can cast them only as rituals.\n- **Spellcasting Ability.** Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; Intelligence for wizard.\n- **Expanding the Book.** When you find a written spell (such as a spell scroll or a spellbook) that is on your chosen class's list, has the ritual tag, and is of a level no higher than half your level (rounded up), you can copy it into the book. Copying takes 2 hours and 50 gp per spell level, spent on fine inks and on the experiments needed to master the spell."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore Rituale",
					Description = "Il personaggio custodisce un libro di rituali che può celebrare con tempo e attenzione.\n- **Libro dei rituali.** Ottiene un libro dei rituali con due incantesimi di 1° livello a sua scelta con il descrittore rituale, presi dalla lista degli incantesimi di una classe: bardo, chierico, druido, mago, stregone o warlock. Per lanciare questi incantesimi deve tenere il libro in mano e può lanciarli solo come rituali.\n- **Caratteristica da incantatore.** Carisma per bardo, stregone o warlock; Saggezza per chierico o druido; Intelligenza per mago.\n- **Ampliare il libro.** Quando trova un incantesimo scritto (come una pergamena magica o un libro degli incantesimi) che appartiene alla lista della classe scelta, ha il descrittore rituale ed è di livello non superiore alla metà del suo livello (arrotondato per eccesso), può copiarlo nel libro. La copia richiede 2 ore e 50 mo per livello dell'incantesimo, spese in inchiostri pregiati e negli esperimenti necessari a padroneggiarlo."
				}
			}
		};
	}
}