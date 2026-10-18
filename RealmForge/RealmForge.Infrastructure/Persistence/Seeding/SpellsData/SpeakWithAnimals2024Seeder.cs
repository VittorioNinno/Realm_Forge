using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Speak with Animals (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpeakWithAnimals2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-animals");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Warlock },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-animals", "en"),
					Language = LanguageCode.En,
					Name = "Speak with Animals",
					CastingTime = "Action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "For the duration, you can comprehend and verbally communicate with Beasts, and you can use any of the Influence action's skill options with them.\n\nMost Beasts have little to say about topics that don't pertain to survival or companionship, but at minimum, a Beast can give you information about nearby locations and monsters, including whatever it has perceived within the past day.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "speak-with-animals", "it"),
					Language = LanguageCode.It,
					Name = "Parlare con gli Animali",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Per la durata, l'incantatore può comprendere le bestie e comunicare verbalmente con loro, e può usare con esse qualsiasi opzione di abilità dell'azione di Influenzare.\n\nLa maggior parte delle bestie ha poco da dire su argomenti che non riguardano la sopravvivenza o la compagnia, ma come minimo una bestia può fornire all'incantatore informazioni sui luoghi e sui mostri nelle vicinanze, inclusa qualsiasi cosa abbia percepito nell'ultimo giorno.",
					HigherLevels = null
				}
			}
		};
	}
}
