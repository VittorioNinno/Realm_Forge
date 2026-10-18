using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcanist's Magic Aura (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcanistsMagicAura2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcanists-magic-aura");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcanists-magic-aura", "en"),
					Language = LanguageCode.En,
					Name = "Arcanist's Magic Aura",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = "a small square of silk",
					Description = "You place an illusion on a creature or an object you touch so that divination spells reveal false information about it. The target can be a willing creature or an object that isn't being carried or worn by another creature.\n\nWhen you cast the spell, choose one or both of the following effects. The effect lasts for the duration. If you cast this spell on the same creature or object every day for 30 days, placing the same effect on it each time, the illusion lasts until it is dispelled.\n\n***False Aura.*** You change the way the target appears to spells and magical effects, such as detect magic, that detect magical auras. You can make a nonmagical object appear magical, a magical object appear nonmagical, or change the object's magical aura so that it appears to belong to a specific school of magic that you choose. When you use this effect on an object, you can make the false magic apparent to any creature that handles the item.\n\n***Mask.*** You change the way the target appears to spells and magical effects that detect creature types, such as a paladin's Divine Sense or the trigger of a symbol spell. You choose a creature type and other spells and magical effects treat the target as if it were a creature of that type or of that alignment.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcanists-magic-aura", "it"),
					Language = LanguageCode.It,
					Name = "Aura Magica dell'Arcanista",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = "un piccolo quadrato di seta",
					Description = "L'incantatore pone un'illusione su una creatura o un oggetto che tocca, in modo che gli incantesimi di divinazione rivelino informazioni false sul suo conto. Il bersaglio può essere una creatura consenziente o un oggetto che non sia trasportato o indossato da un'altra creatura.\n\nQuando lancia l'incantesimo, l'incantatore sceglie uno degli effetti seguenti o entrambi. L'effetto dura per la durata dell'incantesimo. Se l'incantatore lancia questo incantesimo sulla stessa creatura o sullo stesso oggetto ogni giorno per 30 giorni, applicando ogni volta lo stesso effetto, l'illusione dura finché non viene dissolta.\n\n***Aura Falsa.*** L'incantatore modifica il modo in cui il bersaglio appare agli incantesimi e agli effetti magici che individuano le aure magiche, come individuazione del magico. Può far apparire magico un oggetto non magico, far apparire non magico un oggetto magico, oppure modificare l'aura magica dell'oggetto in modo che sembri appartenere a una scuola di magia a sua scelta. Quando usa questo effetto su un oggetto, l'incantatore può rendere la falsa magia evidente a qualsiasi creatura che maneggi l'oggetto.\n\n***Maschera.*** L'incantatore modifica il modo in cui il bersaglio appare agli incantesimi e agli effetti magici che individuano i tipi di creatura, come il Senso Divino di un paladino o l'innesco di un incantesimo simbolo. Sceglie un tipo di creatura, e gli altri incantesimi ed effetti magici trattano il bersaglio come se fosse una creatura di quel tipo o di quell'allineamento.",
					HigherLevels = null
				}
			}
		};
	}
}
