using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Speak with Animals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpeakWithAnimals2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-animals");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-animals", "en"),
					Language = LanguageCode.En,
					Name = "Speak with Animals",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "You gain the ability to comprehend and verbally communicate with beasts for the duration. The knowledge and awareness of many beasts is limited by their intelligence, but at a minimum, beasts can give you information about nearby locations and monsters, including whatever they can perceive or have perceived within the past day. You might be able to persuade a beast to perform a small favor for you, at the GM's discretion.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-animals", "it"),
					Language = LanguageCode.It,
					Name = "Parlare con gli Animali",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Per la durata, l'incantatore ottiene la capacità di comprendere le bestie e di comunicare verbalmente con esse. La conoscenza e la consapevolezza di molte bestie sono limitate dalla loro intelligenza, ma come minimo le bestie possono fornire all'incantatore informazioni sui luoghi e sui mostri nei dintorni, incluso tutto ciò che sono in grado di percepire o che hanno percepito nell'ultimo giorno. A discrezione del DM, l'incantatore potrebbe persuadere una bestia a fargli un piccolo favore.",
					HigherLevels = null
				}
			}
		};
	}
}
