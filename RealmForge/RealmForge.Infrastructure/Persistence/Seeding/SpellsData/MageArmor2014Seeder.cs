using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mage Armor (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MageArmor2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-armor");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-armor", "en"),
					Language = LanguageCode.En,
					Name = "Mage Armor",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a piece of cured leather",
					Description = "You touch a willing creature who isn't wearing armor, and a protective magical force surrounds it until the spell ends. The target's base AC becomes 13 + its Dexterity modifier. The spell ends if the target dons armor or if you dismiss the spell as an action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-armor", "it"),
					Language = LanguageCode.It,
					Name = "Armatura Magica",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un pezzo di cuoio conciato",
					Description = "L'incantatore tocca una creatura consenziente che non indossa un'armatura, e una forza magica protettiva la circonda finché l'incantesimo non termina. La CA base del bersaglio diventa 13 + il suo modificatore di Destrezza. L'incantesimo termina se il bersaglio indossa un'armatura o se l'incantatore congeda l'incantesimo come azione.",
					HigherLevels = null
				}
			}
		};
	}
}
