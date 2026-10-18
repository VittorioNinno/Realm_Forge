using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telekinesis (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Telekinesis2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telekinesis");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telekinesis", "en"),
					Language = LanguageCode.En,
					Name = "Telekinesis",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You gain the ability to move or manipulate creatures or objects by thought. When you cast the spell, and as your action each round for the duration, you can exert your will on one creature or object that you can see within range, causing the appropriate effect below. You can affect the same target round after round, or choose a new one at any time. If you switch targets, the prior target is no longer affected by the spell.\n\n***Creature.*** You can try to move a Huge or smaller creature. Make an ability check with your spellcasting ability contested by the creature's Strength check. If you win the contest, you move the creature up to 30 feet in any direction, including upward but not beyond the range of this spell. Until the end of your next turn, the creature is restrained in your telekinetic grip. A creature lifted upward is suspended in mid-air.\n\nOn subsequent rounds, you can use your action to attempt to maintain your telekinetic grip on the creature by repeating the contest.\n\n***Object.*** You can try to move an object that weighs up to 1,000 pounds. If the object isn't being worn or carried, you automatically move it up to 30 feet in any direction, but not beyond the range of this spell.\n\nIf the object is worn or carried by a creature, you must make an ability check with your spellcasting ability contested by that creature's Strength check. If you succeed, you pull the object away from that creature and can move it up to 30 feet in any direction but not beyond the range of this spell.\n\nYou can exert fine control on objects with your telekinetic grip, such as manipulating a simple tool, opening a door or a container, stowing or retrieving an item from an open container, or pouring the contents from a vial.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telekinesis", "it"),
					Language = LanguageCode.It,
					Name = "Telecinesi",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore ottiene la capacità di muovere o manipolare creature e oggetti con il pensiero. Quando lancia l'incantesimo, e come sua azione a ogni round per la durata, può esercitare la propria volontà su una creatura o un oggetto entro gittata che sia in grado di vedere, producendo l'effetto appropriato tra quelli seguenti. Può influenzare lo stesso bersaglio round dopo round, oppure sceglierne uno nuovo in qualsiasi momento. Se cambia bersaglio, il bersaglio precedente non è più influenzato dall'incantesimo.\n\n***Creatura.*** L'incantatore può tentare di spostare una creatura di taglia Enorme o inferiore. Effettua una prova di caratteristica usando la propria caratteristica da incantatore, contrapposta a una prova di Forza della creatura. Se vince la contesa, sposta la creatura di un massimo di 9 metri in qualsiasi direzione, anche verso l'alto ma non oltre la gittata di questo incantesimo. Fino alla fine del turno successivo dell'incantatore, la creatura è trattenuta nella sua presa telecinetica. Una creatura sollevata verso l'alto resta sospesa a mezz'aria.\n\nNei round successivi, l'incantatore può usare la sua azione per tentare di mantenere la presa telecinetica sulla creatura ripetendo la contesa.\n\n***Oggetto.*** L'incantatore può tentare di spostare un oggetto che pesa fino a 500 kg. Se l'oggetto non è indossato o trasportato, lo sposta automaticamente di un massimo di 9 metri in qualsiasi direzione, ma non oltre la gittata di questo incantesimo.\n\nSe l'oggetto è indossato o trasportato da una creatura, l'incantatore deve effettuare una prova di caratteristica usando la propria caratteristica da incantatore, contrapposta a una prova di Forza di quella creatura. Se ha successo, strappa l'oggetto alla creatura e può spostarlo di un massimo di 9 metri in qualsiasi direzione, ma non oltre la gittata di questo incantesimo.\n\nL'incantatore può esercitare un controllo preciso sugli oggetti con la sua presa telecinetica, per esempio manipolando un semplice attrezzo, aprendo una porta o un contenitore, riponendo un oggetto in un contenitore aperto o estraendolo da esso, oppure versando il contenuto di una fiala.",
					HigherLevels = null
				}
			}
		};
	}
}
