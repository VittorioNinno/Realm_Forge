using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mage Armor (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MageArmor2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-armor");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-armor", "en"),
					Language = LanguageCode.En,
					Name = "Mage Armor",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a piece of cured leather",
					Description = "You touch a willing creature who isn't wearing armor. Until the spell ends, the target's base AC becomes 13 plus its Dexterity modifier. The spell ends early if the target dons armor.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-armor", "it"),
					Language = LanguageCode.It,
					Name = "Armatura Magica",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un pezzo di cuoio conciato",
					Description = "L'incantatore tocca una creatura consenziente che non indossa un'armatura. Finché l'incantesimo non termina, la CA base del bersaglio diventa 13 più il suo modificatore di Destrezza. L'incantesimo termina prima del tempo se il bersaglio indossa un'armatura.",
					HigherLevels = null
				}
			}
		};
	}
}
