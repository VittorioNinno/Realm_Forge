using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Gate (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArcaneGate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-gate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-gate", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Gate",
					CastingTime = "1 action",
					Range = "500 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You open two linked teleportation portals for the duration. Pick two points on the ground that you can see: one within 10 feet of you and the other within 500 feet of you. A circular portal 10 feet across appears above each point. If either portal would open in a space occupied by a creature, the spell fails and the casting is lost.\n\nEach portal is a flat, glowing ring full of opaque mist, floating a few inches off the ground and standing upright at the chosen point. Only one face of each ring is active (you choose which), and only that face is visible.\n\nA creature or object that enters the active face of one portal comes out of the other as if the two were next to each other. Going through a ring from its inactive side does nothing. The mist blocks sight through the portals. On your turn, you can use a bonus action to turn the rings so that their active faces point in new directions.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-gate", "it"),
					Language = LanguageCode.It,
					Name = "Portale Arcano",
					CastingTime = "1 azione",
					Range = "150 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore apre due portali di teletrasporto collegati tra loro, che restano attivi per la durata. Sceglie due punti del terreno che è in grado di vedere: uno entro 3 metri da sé e l'altro entro 150 metri da sé. Sopra ciascun punto compare un portale circolare del diametro di 3 metri. Se uno dei portali dovesse aprirsi in uno spazio occupato da una creatura, l'incantesimo fallisce e il lancio va perduto.\n\nOgni portale è un anello piatto e luminoso pieno di una nebbia opaca, che fluttua a pochi centimetri dal suolo in posizione verticale nel punto scelto. Solo una faccia di ciascun anello è attiva (a scelta dell'incantatore), e soltanto quella faccia è visibile.\n\nUna creatura o un oggetto che entra dalla faccia attiva di un portale esce dall'altro come se i due fossero adiacenti. Attraversare un anello dalla faccia inattiva non ha alcun effetto. La nebbia impedisce di vedere attraverso i portali. Nel proprio turno, l'incantatore può usare un'azione bonus per ruotare gli anelli, in modo che le loro facce attive puntino in nuove direzioni.",
					HigherLevels = null
				}
			}
		};
	}
}
