using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Hand (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneHand2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-hand");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-hand", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Hand",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "an eggshell and a glove",
					Description = "You create a Large hand of shimmering magical energy in an unoccupied space that you can see within range. The hand lasts for the duration, and it moves at your command, mimicking the movements of your own hand.\n\nThe hand is an object that has AC 20 and Hit Points equal to your Hit Point maximum. If it drops to 0 Hit Points, the spell ends. The hand doesn't occupy its space.\n\nWhen you cast the spell and as a Bonus Action on your later turns, you can move the hand up to 60 feet and then cause one of the following effects:\n\n**Clenched Fist.** The hand strikes a target within 5 feet of it. Make a melee spell attack. On a hit, the target takes 5d8 Force damage.\n\n**Forceful Hand.** The hand attempts to push a Huge or smaller creature within 5 feet of it. The target must succeed on a Strength saving throw, or the hand pushes the target up to 5 feet plus a number of feet equal to five times your spellcasting ability modifier. The hand moves with the target, remaining within 5 feet of it.\n\n**Grasping Hand.** The hand attempts to grapple a Huge or smaller creature within 5 feet of it. The target must succeed on a Dexterity saving throw, or the target has the Grappled condition, with an escape DC equal to your spell save DC. While the hand grapples the target, you can take a Bonus Action to cause the hand to crush it, dealing Bludgeoning damage to the target equal to 4d6 plus your spellcasting ability modifier.\n\n**Interposing Hand.** The hand grants you Half Cover against attacks and other effects that originate from its space or that pass through it. In addition, its space counts as Difficult Terrain for your enemies.",
					HigherLevels = "The damage of the Clenched Fist increases by 2d8 and the damage of the Grasping Hand increases by 2d6 for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-hand", "it"),
					Language = LanguageCode.It,
					Name = "Mano Arcana",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un guscio d'uovo e un guanto",
					Description = "L'incantatore crea una mano Grande di scintillante energia magica in uno spazio libero entro gittata che è in grado di vedere. La mano permane per la durata e si muove al comando dell'incantatore, imitando i movimenti della sua mano.\n\nLa mano è un oggetto con CA 20 e punti ferita pari al massimo dei punti ferita dell'incantatore. Se scende a 0 punti ferita, l'incantesimo termina. La mano non occupa il proprio spazio.\n\nQuando lancia l'incantesimo e, nei turni successivi, come azione bonus, l'incantatore può spostare la mano fino a 18 metri e poi produrre uno degli effetti seguenti:\n\n**Pugno Serrato.** La mano colpisce un bersaglio entro 1,5 metri da sé. L'incantatore effettua un attacco con incantesimo in mischia. Se colpisce, il bersaglio subisce 5d8 danni da forza.\n\n**Mano Possente.** La mano tenta di spingere una creatura di taglia Enorme o inferiore entro 1,5 metri da sé. Il bersaglio deve superare un tiro salvezza su Forza, altrimenti la mano lo spinge di 1,5 metri più un numero di metri pari a 1,5 volte il modificatore di caratteristica da incantatore dell'incantatore. La mano si muove insieme al bersaglio, rimanendo entro 1,5 metri da esso.\n\n**Mano Stritolatrice.** La mano tenta di afferrare una creatura di taglia Enorme o inferiore entro 1,5 metri da sé. Il bersaglio deve superare un tiro salvezza su Destrezza, altrimenti è afferrato, con una CD di fuga pari alla CD del tiro salvezza degli incantesimi dell'incantatore. Finché la mano afferra il bersaglio, l'incantatore può effettuare un'azione bonus per far sì che la mano lo stritoli, infliggendogli danni contundenti pari a 4d6 più il modificatore di caratteristica da incantatore dell'incantatore.\n\n**Mano Interposta.** La mano conferisce all'incantatore mezza copertura contro gli attacchi e gli altri effetti che hanno origine dal suo spazio o che lo attraversano. Inoltre, il suo spazio conta come terreno difficile per i nemici dell'incantatore.",
					HigherLevels = "I danni del Pugno Serrato aumentano di 2d8 e i danni della Mano Stritolatrice aumentano di 2d6 per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
