using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Entertainer (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. Grants the Musician origin feat.
///	</summary>
public static class Entertainer2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "entertainer");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.Acrobatics, Skill.Performance },
			OriginFeatId = Musician2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "entertainer", "en"),
					Language = LanguageCode.En,
					Name = "Entertainer",
					Description = "You spent most of your youth trailing traveling fairs and carnivals, doing odd jobs for musicians and acrobats in return for lessons. Perhaps you learned to walk a tightrope, to play the lute in a style all your own, or to recite poetry with flawless diction. Even now, applause is what you live for, and the stage is never far from your thoughts.",
					ToolProficiencies = "One kind of Musical Instrument of your choice",
					Equipment = "Musical Instrument (the one chosen above)\n2 Costumes\nMirror\nPerfume\nTraveler's Clothes\n11 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "entertainer", "it"),
					Language = LanguageCode.It,
					Name = "Intrattenitore",
					Description = "Il personaggio ha passato gran parte della giovinezza al seguito di fiere e carnevali itineranti, facendo lavoretti per musicisti e acrobati in cambio di lezioni. Forse ha imparato a camminare sulla corda tesa, a suonare il liuto con uno stile tutto suo o a recitare poesie con una dizione impeccabile. Ancora oggi vive per gli applausi, e il palcoscenico non è mai lontano dai suoi pensieri.",
					ToolProficiencies = "Un tipo di strumento musicale a scelta",
					Equipment = "Strumento musicale (lo stesso scelto sopra)\n2 costumi\nSpecchio\nProfumo\nAbiti da viaggiatore\n11 mo"
				}
			}
		};
	}
}
