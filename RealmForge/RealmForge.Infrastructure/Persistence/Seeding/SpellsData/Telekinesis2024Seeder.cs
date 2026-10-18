using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telekinesis (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Telekinesis2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telekinesis");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telekinesis", "en"),
					Language = LanguageCode.En,
					Name = "Telekinesis",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You gain the ability to move or manipulate creatures or objects by thought. When you cast the spell and as a Magic action on your later turns before the spell ends, you can exert your will on one creature or object that you can see within range, causing the appropriate effect below. You can affect the same target round after round or choose a new one at any time. If you switch targets, the prior target is no longer affected by the spell.\n\n***Creature.*** You can try to move a Huge or smaller creature. The target must succeed on a Strength saving throw, or you move it up to 30 feet in any direction within the spell's range. Until the end of your next turn, the creature has the Restrained condition, and if you lift it into the air, it is suspended there. It falls at the end of your next turn unless you use this option on it again and it fails the save.\n\n***Object.*** You can try to move a Huge or smaller object. If the object isn't being worn or carried, you automatically move it up to 30 feet in any direction within the spell's range. If the object is worn or carried by a creature, that creature must succeed on a Strength saving throw, or you pull the object away and move it up to 30 feet in any direction within the spell's range.\n\nYou can exert fine control on objects with your telekinetic grip, such as manipulating a simple tool, opening a door or a container, stowing or retrieving an item from an open container, or pouring the contents from a vial.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telekinesis", "it"),
					Language = LanguageCode.It,
					Name = "Telecinesi",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore ottiene la capacità di muovere o manipolare creature od oggetti con il pensiero. Quando lancia l'incantesimo e, come azione di Magia, nei turni successivi prima che l'incantesimo termini, può esercitare la propria volontà su una creatura o un oggetto entro gittata che è in grado di vedere, producendo l'effetto appropriato descritto sotto. Può influenzare lo stesso bersaglio round dopo round o sceglierne uno nuovo in qualsiasi momento. Se cambia bersaglio, il bersaglio precedente non è più influenzato dall'incantesimo.\n\n***Creatura.*** L'incantatore può tentare di spostare una creatura di taglia Enorme o inferiore. Il bersaglio deve superare un tiro salvezza su Forza, altrimenti l'incantatore lo sposta fino a 9 metri in qualsiasi direzione entro la gittata dell'incantesimo. Fino alla fine del turno successivo dell'incantatore, la creatura è trattenuta e, se l'incantatore la solleva in aria, vi rimane sospesa. Cade alla fine del turno successivo dell'incantatore, a meno che questi non usi di nuovo questa opzione su di essa e la creatura non fallisca il tiro salvezza.\n\n***Oggetto.*** L'incantatore può tentare di spostare un oggetto di taglia Enorme o inferiore. Se l'oggetto non è indossato o trasportato, l'incantatore lo sposta automaticamente fino a 9 metri in qualsiasi direzione entro la gittata dell'incantesimo. Se l'oggetto è indossato o trasportato da una creatura, quella creatura deve superare un tiro salvezza su Forza, altrimenti l'incantatore le strappa l'oggetto e lo sposta fino a 9 metri in qualsiasi direzione entro la gittata dell'incantesimo.\n\nCon la sua presa telecinetica, l'incantatore può esercitare un controllo preciso sugli oggetti, come manipolare un semplice attrezzo, aprire una porta o un contenitore, riporre un oggetto in un contenitore aperto o estrarlo da esso, oppure versare il contenuto di una fiala.",
					HigherLevels = null
				}
			}
		};
	}
}
