using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Steed (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindSteed2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-steed");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-steed", "en"),
					Language = LanguageCode.En,
					Name = "Find Steed",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You summon an otherworldly being that appears as a loyal steed in an unoccupied space of your choice within range. This creature uses the **Otherworldly Steed** stat block. If you already have a steed from this spell, the steed is replaced by the new one.\n\nThe steed resembles a Large, rideable animal of your choice, such as a horse, a camel, a dire wolf, or an elk. Whenever you cast the spell, choose the steed's creature type—Celestial, Fey, or Fiend—which determines certain traits in the stat block.\n\n***Combat.*** The steed is an ally to you and your allies. In combat, it shares your Initiative count, and it functions as a controlled mount while you ride it (as defined in the rules on mounted combat). If you have the Incapacitated condition, the steed takes its turn immediately after yours and acts independently, focusing on protecting you.\n\n***Disappearance of the Steed.*** The steed disappears if it drops to 0 Hit Points or if you die. When it disappears, it leaves behind anything it was wearing or carrying. If you cast this spell again, you decide whether you summon the steed that disappeared or a different one.\n\n#### Otherworldly Steed\n\n*Large Celestial, Fey, or Fiend (Your Choice), Neutral*\n\n**AC** 10 + 1 per spell level\n\n**HP** 5 + 10 per spell level (the steed has a number of Hit Dice [d10s] equal to the spell's level)\n\n**Speed** 60 ft., Fly 60 ft. (requires level 4+ spell)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 18 | +4 | +4 |\n| DEX | 12 | +1 | +1 |\n| CON | 14 | +2 | +2 |\n| INT | 6 | −2 | −2 |\n| WIS | 12 | +1 | +1 |\n| CHA | 8 | −1 | −1 |\n\n**Senses** Passive Perception 11\n\n**Languages** Telepathy 1 mile (works only with you)\n\n**CR** None (XP 0; PB equals your Proficiency Bonus)\n\n***Traits***\n\n***Life Bond.*** When you regain Hit Points from a level 1+ spell, the steed regains the same number of Hit Points if you're within 5 feet of it.\n\n***Actions***\n\n***Otherworldly Slam.*** *Melee Attack Roll:* Bonus equals your spell attack modifier, reach 5 ft. *Hit:* 1d8 plus the spell's level of Radiant (Celestial), Psychic (Fey), or Necrotic (Fiend) damage.\n\n***Bonus Actions***\n\n***Fell Glare (Fiend Only; Recharges after a Long Rest).*** *Wisdom Saving Throw:* DC equals your spell save DC, one creature within 60 feet the steed can see. *Failure:* The target has the Frightened condition until the end of your next turn.\n\n***Fey Step (Fey Only; Recharges after a Long Rest).*** The steed teleports, along with its rider, to an unoccupied space of your choice up to 60 feet away from itself.\n\n***Healing Touch (Celestial Only; Recharges after a Long Rest).*** One creature within 5 feet of the steed regains a number of Hit Points equal to 2d8 plus the spell's level.",
					HigherLevels = "Use the spell slot's level for the spell's level in the stat block."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-steed", "it"),
					Language = LanguageCode.It,
					Name = "Trova Cavalcatura",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore evoca un essere ultraterreno che appare come una cavalcatura fedele in uno spazio libero entro gittata a sua scelta. Questa creatura usa la scheda delle statistiche del **destriero ultraterreno**. Se l'incantatore ha già una cavalcatura ottenuta con questo incantesimo, la cavalcatura viene sostituita da quella nuova.\n\nLa cavalcatura ha l'aspetto di un animale Grande cavalcabile a scelta dell'incantatore, come un cavallo, un cammello, un lupo crudele o un alce. Ogni volta che lancia l'incantesimo, l'incantatore sceglie il tipo di creatura della cavalcatura (celestiale, folletto o immondo), che determina alcuni tratti nella scheda delle statistiche.\n\n***Combattimento.*** La cavalcatura è un'alleata dell'incantatore e dei suoi alleati. In combattimento condivide il conteggio di Iniziativa dell'incantatore e funziona come una cavalcatura controllata mentre l'incantatore la cavalca (secondo le regole del combattimento in sella). Se l'incantatore è incapacitato, la cavalcatura svolge il proprio turno subito dopo il suo e agisce in modo indipendente, concentrandosi sulla sua protezione.\n\n***Scomparsa della Cavalcatura.*** La cavalcatura scompare se scende a 0 punti ferita o se l'incantatore muore. Quando scompare, lascia dietro di sé tutto ciò che indossava o trasportava. Se l'incantatore lancia di nuovo questo incantesimo, decide se evocare la cavalcatura scomparsa o una diversa.\n\n#### Destriero Ultraterreno\n\n*Celestiale, folletto o immondo (a scelta dell'incantatore) Grande, neutrale*\n\n**CA** 10 + 1 per livello dell'incantesimo\n\n**PF** 5 + 10 per livello dell'incantesimo (la cavalcatura ha un numero di Dadi Vita [d10] pari al livello dell'incantesimo)\n\n**Velocità** 18 m, volare 18 m (richiede un incantesimo di 4° livello o superiore)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 18 | +4 | +4 |\n| DES | 12 | +1 | +1 |\n| COS | 14 | +2 | +2 |\n| INT | 6 | −2 | −2 |\n| SAG | 12 | +1 | +1 |\n| CAR | 8 | −1 | −1 |\n\n**Sensi** Percezione passiva 11\n\n**Linguaggi** telepatia 1,5 km (funziona soltanto con l'incantatore)\n\n**GS** nessuno (PE 0; BC pari al bonus di competenza dell'incantatore)\n\n***Tratti***\n\n***Legame Vitale.*** Quando l'incantatore recupera punti ferita grazie a un incantesimo di 1° livello o superiore, la cavalcatura recupera lo stesso numero di punti ferita, se l'incantatore si trova entro 1,5 metri da essa.\n\n***Azioni***\n\n***Schianto Ultraterreno.*** *Tiro per colpire in mischia:* bonus pari al modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. *Colpito:* 1d8 più il livello dell'incantesimo danni radiosi (celestiale), psichici (folletto) o necrotici (immondo).\n\n***Azioni Bonus***\n\n***Sguardo Funesto (solo immondo; si ricarica dopo un riposo lungo).*** *Tiro salvezza su Saggezza:* CD pari alla CD del tiro salvezza degli incantesimi dell'incantatore, una creatura entro 18 metri che la cavalcatura è in grado di vedere. *Fallimento:* il bersaglio è spaventato fino alla fine del turno successivo dell'incantatore.\n\n***Passo Fatato (solo folletto; si ricarica dopo un riposo lungo).*** La cavalcatura si teletrasporta, insieme al suo cavaliere, in uno spazio libero a scelta dell'incantatore entro 18 metri da sé.\n\n***Tocco Guaritore (solo celestiale; si ricarica dopo un riposo lungo).*** Una creatura entro 1,5 metri dalla cavalcatura recupera un numero di punti ferita pari a 2d8 più il livello dell'incantesimo.",
					HigherLevels = "Si usa il livello dello slot incantesimo come livello dell'incantesimo nella scheda delle statistiche."
				}
			}
		};
	}
}
