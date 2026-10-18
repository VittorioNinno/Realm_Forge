using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mislead (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Mislead2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mislead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mislead", "en"),
					Language = LanguageCode.En,
					Name = "Mislead",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You become invisible at the same time that an illusory double of you appears where you are standing. The double lasts for the duration, but the invisibility ends if you attack or cast a spell.\n\nYou can use your action to move your illusory double up to twice your speed and make it gesture, speak, and behave in whatever way you choose.\n\nYou can see through its eyes and hear through its ears as if you were located where it is. On each of your turns as a bonus action, you can switch from using its senses to using your own, or back again. While you are using its senses, you are blinded and deafened in regard to your own surroundings.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mislead", "it"),
					Language = LanguageCode.It,
					Name = "Fuorviare",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore diventa invisibile nello stesso istante in cui un suo doppio illusorio compare nel punto in cui si trova. Il doppio dura per la durata, ma l'invisibilità termina se l'incantatore attacca o lancia un incantesimo.\n\nL'incantatore può usare la sua azione per spostare il proprio doppio illusorio fino al doppio della propria velocità e fargli fare gesti, parlare e comportarsi nel modo che preferisce.\n\nL'incantatore può vedere attraverso gli occhi del doppio e sentire attraverso le sue orecchie come se si trovasse nel punto in cui si trova il doppio. In ognuno dei suoi turni, come azione bonus, può passare dall'uso dei sensi del doppio all'uso dei propri, o viceversa. Mentre usa i sensi del doppio, l'incantatore è accecato e assordato per quanto riguarda ciò che lo circonda.",
					HigherLevels = null
				}
			}
		};
	}
}
