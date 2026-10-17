using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Noble (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Skilled origin feat.
///	</summary>
public static class Noble2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "noble");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Intelligence, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.History, Skill.Persuasion },
			OriginFeatId = Skilled2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "noble", "en"),
					Language = LanguageCode.En,
					Name = "Noble",
					Description = "You grew up in a castle, surrounded by wealth, power, and privilege. Your family, minor aristocrats, made sure you had a first-class education, parts of which you valued and parts of which you resented. Life in the castle, and above all the long hours spent watching your family at court, also taught you a great deal about leading others.",
					ToolProficiencies = "One kind of Gaming Set of your choice",
					Equipment = "Gaming Set (the one chosen above)\nFine Clothes\nPerfume\n29 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "noble", "it"),
					Language = LanguageCode.It,
					Name = "Nobile",
					Description = "Il personaggio è cresciuto in un castello, circondato da ricchezza, potere e privilegi. La sua famiglia, appartenente alla piccola nobiltà, gli ha garantito un'istruzione di prim'ordine, che in parte ha apprezzato e in parte ha sopportato a fatica. La vita al castello, e soprattutto le lunghe ore passate a osservare la sua famiglia a corte, gli hanno anche insegnato molto su come guidare gli altri.",
					ToolProficiencies = "Un tipo di set da gioco a scelta",
					Equipment = "Set da gioco (lo stesso scelto sopra)\nAbiti eleganti\nProfumo\n29 mo"
				}
			}
		};
	}
}
