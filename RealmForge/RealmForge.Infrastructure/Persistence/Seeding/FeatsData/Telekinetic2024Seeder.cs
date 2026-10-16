using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Telekinetic feat (2024 ruleset).
///	</summary>
public static class Telekinetic2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555593");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551431");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551432");

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
					Name = "Telekinetic",
					Description = "Your mind can move objects and creatures.\n- **Intelligence, Wisdom, or Charisma +1.** Increase one of these scores by 1, to a maximum of 20. This is your spellcasting ability for this feat.\n- **Unseen Hand.** You learn Mage Hand. You can cast it without Verbal or Somatic components, you can make the hand Invisible, and its range and the distance it can move away from you each increase by 30 feet.\n- **Mental Push.** As a Bonus Action, you choose a creature you can see within 30 feet of you. It makes a Strength saving throw (DC 8 + the modifier of the ability increased by this feat + your Proficiency Bonus); on a failure, you move it 5 feet toward you or away from you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Telecinesi",
					Description = "La mente del personaggio può spostare oggetti e creature.\n- **Intelligenza, Saggezza o Carisma +1.** Uno di questi punteggi aumenta di 1, fino a un massimo di 20. È la sua caratteristica da incantatore per questo talento.\n- **Mano invisibile.** Impara Mano Magica. Può lanciarlo senza componenti verbali o somatiche, può rendere la mano invisibile, e la sua gittata e la distanza a cui può allontanarsi da lui aumentano ciascuna di 9 metri.\n- **Spinta mentale.** Come azione bonus, sceglie una creatura che può vedere entro 9 metri. Quella creatura effettua un tiro salvezza su Forza (CD 8 + il modificatore della caratteristica aumentata con questo talento + il bonus di competenza del personaggio); se lo fallisce, il personaggio la sposta di 1,5 metri verso di sé o lontano da sé."
				}
			}
		};
	}
}