using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Elemental Adept feat (2024 ruleset).
///	</summary>
public static class ElementalAdept2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555564");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551141");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551142");

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
					Name = "Elemental Adept",
					Description = "You bend one element to your will.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20.\n- **Chosen Element.** Pick acid, cold, fire, lightning, or thunder. Your spells ignore Resistance to damage of that type, and when you roll damage for a spell you cast that deals it, any 1 on a damage die can be treated as a 2.\n- **Repeatable.** You can take this feat more than once, choosing a different element each time."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Elementale",
					Description = "Il personaggio piega un elemento al proprio volere.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20.\n- **Elemento prescelto.** Sceglie acido, freddo, fuoco, fulmine o tuono. I suoi incantesimi ignorano la Resistenza ai danni di quel tipo e, quando tira i danni di un incantesimo che lancia e che li infligge, può considerare ogni 1 su un dado di danno come un 2.\n- **Ripetibile.** Può ottenere questo talento più volte, scegliendo ogni volta un elemento diverso."
				}
			}
		};
	}
}