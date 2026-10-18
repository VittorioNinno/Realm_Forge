using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcanist's Magic Aura (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcanistsMagicAura2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcanists-magic-aura");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcanists-magic-aura", "en"),
					Language = LanguageCode.En,
					Name = "Arcanist's Magic Aura",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = "a small square of silk",
					Description = "With a touch, you place an illusion on a willing creature or an object that isn't being worn or carried. A creature gains the Mask effect below, and an object gains the False Aura effect below. The effect lasts for the duration. If you cast the spell on the same target every day for 30 days, the illusion lasts until dispelled.\n\n***Mask (Creature).*** Choose a creature type other than the target's actual type. Spells and other magical effects treat the target as if it were a creature of the chosen type.\n\n***False Aura (Object).*** You change the way the target appears to spells and magical effects that detect magical auras, such as *Detect Magic*. You can make a nonmagical object appear magical, make a magic item appear nonmagical, or change the object's aura so that it appears to belong to a school of magic you choose.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcanists-magic-aura", "it"),
					Language = LanguageCode.It,
					Name = "Aura Magica dell'Arcanista",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = "un quadratino di seta",
					Description = "Con un tocco, l'incantatore pone un'illusione su una creatura consenziente o su un oggetto che non sia indossato o trasportato. Una creatura ottiene l'effetto Maschera descritto sotto, mentre un oggetto ottiene l'effetto Falsa Aura descritto sotto. L'effetto dura per la durata. Se l'incantatore lancia l'incantesimo sullo stesso bersaglio ogni giorno per 30 giorni, l'illusione dura finché non viene dissolta.\n\n***Maschera (Creatura).*** L'incantatore sceglie un tipo di creatura diverso dal tipo effettivo del bersaglio. Gli incantesimi e gli altri effetti magici trattano il bersaglio come se fosse una creatura del tipo scelto.\n\n***Falsa Aura (Oggetto).*** L'incantatore cambia il modo in cui il bersaglio appare agli incantesimi e agli effetti magici che individuano le aure magiche, come *individuazione del magico*. Può far apparire magico un oggetto non magico, far apparire non magico un oggetto magico, oppure cambiare l'aura dell'oggetto in modo che sembri appartenere a una scuola di magia a sua scelta.",
					HigherLevels = null
				}
			}
		};
	}
}
