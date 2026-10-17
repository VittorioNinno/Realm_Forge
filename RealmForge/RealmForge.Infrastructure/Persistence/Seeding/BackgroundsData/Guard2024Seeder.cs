using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Guard (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Alert origin feat.
///	</summary>
public static class Guard2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guard");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.Athletics, Skill.Perception },
			OriginFeatId = Alert2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guard", "en"),
					Language = LanguageCode.En,
					Name = "Guard",
					Description = "Just thinking about the endless hours you spent standing watch in the tower makes your feet ache. You were taught to keep one eye beyond the wall, alert for raiders bursting out of the nearby forest, and the other inside it, on the lookout for pickpockets and troublemakers.",
					ToolProficiencies = "One kind of Gaming Set of your choice",
					Equipment = "Spear\nLight Crossbow\n20 Bolts\nGaming Set (the one chosen above)\nHooded Lantern\nManacles\nQuiver\nTraveler's Clothes\n12 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guard", "it"),
					Language = LanguageCode.It,
					Name = "Guardia",
					Description = "Basta che il personaggio ripensi alle interminabili ore passate di vedetta sulla torre perché gli facciano male i piedi. Gli hanno insegnato a tenere un occhio oltre le mura, pronto a scorgere i predoni che sbucano dalla foresta vicina, e l'altro al loro interno, a caccia di borseggiatori e attaccabrighe.",
					ToolProficiencies = "Un tipo di set da gioco a scelta",
					Equipment = "Lancia\nBalestra leggera\n20 quadrelli\nSet da gioco (lo stesso scelto sopra)\nLanterna schermabile\nManette\nFaretra\nAbiti da viaggiatore\n12 mo"
				}
			}
		};
	}
}
