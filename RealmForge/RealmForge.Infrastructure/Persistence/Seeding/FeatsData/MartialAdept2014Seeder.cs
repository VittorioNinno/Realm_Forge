using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Martial Adept feat (2014 ruleset).
///	</summary>
public static class MartialAdept2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555524");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555741");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555742");

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
					Name = "Martial Adept",
					Description = "You have learned some of the tricks of seasoned battle masters.\n- **Maneuvers.** You learn two maneuvers of your choice from those available to the fighter's Battle Master archetype. When a maneuver calls for a saving throw, the DC is 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice).\n- **Superiority Die.** You gain one superiority die, a d6 (or one extra die, if you already have some). You expend a die each time you use a maneuver, and you regain all expended dice when you finish a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Marziale",
					Description = "Il personaggio ha appreso alcuni trucchi dei veterani del campo di battaglia.\n- **Manovre.** Impara due manovre a sua scelta tra quelle disponibili all'archetipo Maestro di Battaglia del guerriero. Quando una manovra richiede un tiro salvezza, la CD è 8 + il suo bonus di competenza + il suo modificatore di Forza o di Destrezza (a sua scelta).\n- **Dado di superiorità.** Ottiene un dado di superiorità, un d6 (o un dado aggiuntivo, se ne possiede già). Spende un dado ogni volta che usa una manovra e recupera tutti i dadi spesi quando termina un riposo breve o lungo."
				}
			}
		};
	}
}