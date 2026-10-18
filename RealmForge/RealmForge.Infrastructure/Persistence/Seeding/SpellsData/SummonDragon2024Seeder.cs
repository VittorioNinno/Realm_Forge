using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Dragon (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SummonDragon2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-dragon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-dragon", "en"),
					Language = LanguageCode.En,
					Name = "Summon Dragon",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "an object with the image of a dragon engraved on it worth 500+ GP",
					Description = "You call forth a Dragon spirit. It manifests in an unoccupied space that you can see within range and uses the Draconic Spirit stat block. The creature disappears when it drops to 0 Hit Points or when the spell ends.\n\nThe creature is an ally to you and your allies. In combat, the creature shares your Initiative count, but it takes its turn immediately after yours. It obeys your verbal commands (no action required by you). If you don't issue any, it takes the Dodge action and uses its movement to avoid danger.\n\n#### Draconic Spirit\n\n*Large Dragon, Neutral*\n\n**AC** 14 + the spell's level\n\n**HP** 50 + 10 for each spell level above 5\n\n**Speed** 30 ft., Fly 60 ft., Swim 30 ft.\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 19 | +4 | +4 |\n| DEX | 14 | +2 | +2 |\n| CON | 17 | +3 | +3 |\n| INT | 10 | +0 | +0 |\n| WIS | 14 | +2 | +2 |\n| CHA | 14 | +2 | +2 |\n\n**Resistances** Acid, Cold, Fire, Lightning, Poison\n\n**Immunities** Charmed, Frightened, Poisoned\n\n**Senses** Blindsight 30 ft., Darkvision 60 ft.; Passive Perception 12\n\n**Languages** Draconic, understands the languages you know\n\n**CR** None (XP 0; PB equals your Proficiency Bonus)\n\n***Traits***\n\n***Shared Resistances.*** When you summon the spirit, choose one of its Resistances. You have Resistance to the chosen damage type until the spell ends.\n\n***Actions***\n\n***Multiattack.*** The spirit makes a number of Rend attacks equal to half the spell's level (round down), and it uses Breath Weapon.\n\n***Rend.*** *Melee Attack Roll:* Bonus equals your spell attack modifier, reach 10 feet. *Hit:* 1d6 + 4 + the spell's level Piercing damage.\n\n***Breath Weapon.*** *Dexterity Saving Throw:* DC equals your spell save DC, each creature in a 30-foot Cone. *Failure:* 2d6 damage of a type this spirit has Resistance to (your choice when you cast the spell). *Success:* Half damage.",
					HigherLevels = "Use the spell slot's level for the spell's level in the stat block."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-dragon", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Drago",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un oggetto con l'immagine di un drago incisa sopra, del valore di almeno 500 mo",
					Description = "L'incantatore richiama uno spirito di drago. Lo spirito si manifesta in uno spazio libero entro gittata che l'incantatore è in grado di vedere e usa la scheda delle statistiche dello spirito draconico. La creatura scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nLa creatura è un'alleata dell'incantatore e dei suoi alleati. In combattimento condivide il conteggio di Iniziativa dell'incantatore, ma svolge il proprio turno subito dopo il suo. Obbedisce ai suoi comandi verbali (non è richiesta alcuna azione da parte dell'incantatore). Se l'incantatore non impartisce alcun comando, la creatura effettua l'azione di Schivata e usa il proprio movimento per evitare pericoli.\n\n#### Spirito Draconico\n\n*Drago Grande, neutrale*\n\n**CA** 14 + il livello dell'incantesimo\n\n**PF** 50 + 10 per ogni livello dell'incantesimo superiore al 5°\n\n**Velocità** 9 m, volare 18 m, nuotare 9 m\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 19 | +4 | +4 |\n| DES | 14 | +2 | +2 |\n| COS | 17 | +3 | +3 |\n| INT | 10 | +0 | +0 |\n| SAG | 14 | +2 | +2 |\n| CAR | 14 | +2 | +2 |\n\n**Resistenze** acido, freddo, fuoco, fulmine, veleno\n\n**Immunità** affascinato, avvelenato, spaventato\n\n**Sensi** vista cieca 9 m, scurovisione 18 m; Percezione passiva 12\n\n**Linguaggi** Draconico, comprende i linguaggi conosciuti dall'incantatore\n\n**GS** nessuno (PE 0; BC pari al bonus di competenza dell'incantatore)\n\n***Tratti***\n\n***Resistenze Condivise.*** Quando richiama lo spirito, l'incantatore sceglie una delle sue resistenze. L'incantatore ha resistenza al tipo di danni scelto finché l'incantesimo non termina.\n\n***Azioni***\n\n***Multiattacco.*** Lo spirito effettua un numero di attacchi di Squarcio pari alla metà del livello dell'incantesimo (arrotondato per difetto) e usa Arma a Soffio.\n\n***Squarcio.*** *Tiro per colpire in mischia:* bonus pari al modificatore di attacco con incantesimo dell'incantatore, portata 3 metri. *Colpito:* 1d6 + 4 + il livello dell'incantesimo danni perforanti.\n\n***Arma a Soffio.*** *Tiro salvezza su Destrezza:* CD pari alla CD del tiro salvezza degli incantesimi dell'incantatore, ogni creatura in un cono di 9 metri. *Fallimento:* 2d6 danni di un tipo a cui questo spirito ha resistenza (a scelta dell'incantatore al momento del lancio). *Successo:* la metà dei danni.",
					HigherLevels = "Si usa il livello dello slot incantesimo come livello dell'incantesimo nella scheda delle statistiche."
				}
			}
		};
	}
}
