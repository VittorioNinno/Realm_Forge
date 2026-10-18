using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Hand (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneHand2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-hand");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-hand", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Hand",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "an eggshell and a snakeskin glove",
					Description = "You create a Large hand of shimmering, translucent force in an unoccupied space that you can see within range. The hand lasts for the spell's duration, and it moves at your command, mimicking the movements of your own hand.\n\nThe hand is an object that has AC 20 and hit points equal to your hit point maximum. If it drops to 0 hit points, the spell ends. It has a Strength of 26 (+8) and a Dexterity of 10 (+0). The hand doesn't fill its space.\n\nWhen you cast the spell and as a bonus action on your subsequent turns, you can move the hand up to 60 feet and then cause one of the following effects with it.\n\n***Clenched Fist.*** The hand strikes one creature or object within 5 feet of it. Make a melee spell attack for the hand using your game statistics. On a hit, the target takes 4d8 force damage.\n\n***Forceful Hand.*** The hand attempts to push a creature within 5 feet of it in a direction you choose. Make a check with the hand's Strength contested by the Strength (Athletics) check of the target. If the target is Medium or smaller, you have advantage on the check. If you succeed, the hand pushes the target up to 5 feet plus a number of feet equal to five times your spellcasting ability modifier. The hand moves with the target to remain within 5 feet of it.\n\n***Grasping Hand.*** The hand attempts to grapple a Huge or smaller creature within 5 feet of it. You use the hand's Strength score to resolve the grapple. If the target is Medium or smaller, you have advantage on the check. While the hand is grappling the target, you can use a bonus action to have the hand crush it. When you do so, the target takes bludgeoning damage equal to 2d6 + your spellcasting ability modifier.\n\n***Interposing Hand.*** The hand interposes itself between you and a creature you choose until you give the hand a different command. The hand moves to stay between you and the target, providing you with half cover against the target. The target can't move through the hand's space if its Strength score is less than or equal to the hand's Strength score. If its Strength score is higher than the hand's Strength score, the target can move toward you through the hand's space, but that space is difficult terrain for the target.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the damage from the clenched fist option increases by 2d8 and the damage from the grasping hand increases by 2d6 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-hand", "it"),
					Language = LanguageCode.It,
					Name = "Mano Arcana",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un guscio d'uovo e un guanto di pelle di serpente",
					Description = "L'incantatore crea una mano di forza scintillante e traslucida di taglia Grande in uno spazio libero entro gittata che sia in grado di vedere. La mano dura per la durata dell'incantesimo e si muove al comando dell'incantatore, imitando i movimenti della sua mano.\n\nLa mano è un oggetto con CA 20 e punti ferita pari al massimo dei punti ferita dell'incantatore. Se scende a 0 punti ferita, l'incantesimo termina. Ha Forza 26 (+8) e Destrezza 10 (+0). La mano non riempie lo spazio che occupa.\n\nQuando lancia l'incantesimo e, nei turni successivi, come azione bonus, l'incantatore può spostare la mano di un massimo di 18 metri e poi usarla per produrre uno degli effetti seguenti.\n\n***Pugno Serrato.*** La mano colpisce una creatura o un oggetto entro 1,5 metri da essa. L'incantatore effettua un attacco con incantesimo in mischia per la mano usando le proprie statistiche di gioco. Se colpisce, il bersaglio subisce 4d8 danni da forza.\n\n***Mano Possente.*** La mano tenta di spingere una creatura entro 1,5 metri da essa in una direzione a scelta dell'incantatore. L'incantatore effettua una prova con la Forza della mano, contrapposta a una prova di Forza (Atletica) del bersaglio. Se il bersaglio è di taglia Media o inferiore, l'incantatore dispone di vantaggio alla prova. Se ha successo, la mano spinge il bersaglio di un massimo di 1,5 metri più un numero di metri pari a 1,5 volte il modificatore di caratteristica da incantatore dell'incantatore. La mano si sposta insieme al bersaglio per rimanere entro 1,5 metri da esso.\n\n***Mano Stringente.*** La mano tenta di afferrare una creatura di taglia Enorme o inferiore entro 1,5 metri da essa. L'incantatore usa il punteggio di Forza della mano per risolvere la lotta. Se il bersaglio è di taglia Media o inferiore, l'incantatore dispone di vantaggio alla prova. Finché la mano tiene afferrato il bersaglio, l'incantatore può usare un'azione bonus per farglielo stritolare. Quando lo fa, il bersaglio subisce danni contundenti pari a 2d6 + il modificatore di caratteristica da incantatore dell'incantatore.\n\n***Mano Interposta.*** La mano si interpone tra l'incantatore e una creatura a sua scelta, finché l'incantatore non le impartisce un comando diverso. La mano si muove per restare tra l'incantatore e il bersaglio, fornendogli mezza copertura contro il bersaglio. Il bersaglio non può attraversare lo spazio della mano se il suo punteggio di Forza è pari o inferiore a quello della mano. Se il suo punteggio di Forza è superiore a quello della mano, il bersaglio può avvicinarsi all'incantatore attraversando lo spazio della mano, ma per lui quello spazio è terreno difficile.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, i danni dell'opzione pugno serrato aumentano di 2d8 e quelli della mano stringente aumentano di 2d6 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
