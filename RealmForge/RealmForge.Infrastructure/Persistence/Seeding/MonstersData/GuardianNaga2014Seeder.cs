using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Guardian Naga (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GuardianNaga2014Seeder
{
	public static Monster Build() => Create("guardian-naga", null, CreatureSize.Large, CreatureType.Monstrosity,
		18, 127, "15d10 + 45", 40, new[] { 19, 18, 16, 16, 19, 18 }, 10m, 5900, 4, 14,
		new Text(
			"Naga guardiana",
			null,
			"Mostruosità Grande, legale buona",
			"18 (armatura naturale)",
			"12 m",
			"Des +8, Cos +7, Int +7, Sag +8, Car +8",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato",
			"Percezione passiva 14, scurovisione 18 m",
			"Celestiale, Comune",
			"***Incantesimi.*** La naga è un incantatore di 11° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 16, +8 al tiro per colpire con attacco con incantesimo) e necessita solo di componenti verbali per lanciare i suoi incantesimi. Ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, riparare, taumaturgia*\n- 1° livello (4 slot): *comando, cura ferite, scudo della fede*\n- 2° livello (3 slot): *blocca persone, calmare emozioni*\n- 3° livello (3 slot): *chiaroveggenza, scagliare maledizione*\n- 4° livello (3 slot): *esilio, libertà di movimento*\n- 5° livello (2 slot): *colpo infuocato, costrizione*\n- 6° livello (1 slot): *visione del vero*\n\n***Rigenerazione.*** Se la naga muore, torna in vita 1d6 giorni dopo e recupera tutti i suoi punti ferita. Solo un incantesimo *desiderio* può impedire a questo tratto di funzionare.",
			"***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 8 (1d8 + 4) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 45 (10d8) danni da veleno in caso di fallimento, o la metà in caso di successo.\n\n***Sputo velenoso.*** *Attacco con arma a distanza:* +8 al tiro per colpire, gittata 4,5/9 m, una creatura. *Colpito:* il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 45 (10d8) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Guardian Naga",
			null,
			"Large monstrosity, lawful good",
			"18 (natural armor)",
			"40 ft.",
			"Dex +8, Con +7, Int +7, Wis +8, Cha +8",
			"",
			"",
			"",
			"poison",
			"charmed, poisoned",
			"darkvision 60 ft., passive Perception 14",
			"Celestial, Common",
			"***Rejuvenation.*** If it dies, the naga returns to life in 1d6 days and regains all its hit points. Only a wish spell can prevent this trait from functioning.\n\n***Spellcasting.*** The naga is an 11th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 16, +8 to hit with spell attacks), and it needs only verbal components to cast its spells. It has the following cleric spells prepared:\n\n- Cantrips (at will): *mending, sacred flame, thaumaturgy*\n- 1st level (4 slots): *command, cure wounds, shield of faith*\n- 2nd level (3 slots): *calm emotions, hold person*\n- 3rd level (3 slots): *bestow curse, clairvoyance*\n- 4th level (3 slots): *banishment, freedom of movement*\n- 5th level (2 slots): *flame strike, geas*\n- 6th level (1 slot): *true seeing*",
			"***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one creature. *Hit:* 8 (1d8 + 4) piercing damage, and the target must make a DC 15 Constitution saving throw, taking 45 (10d8) poison damage on a failed save, or half as much damage on a successful one.\n\n***Spit Poison.*** *Ranged Weapon Attack:* +8 to hit, range 15/30 ft., one creature. *Hit:* The target must make a DC 15 Constitution saving throw, taking 45 (10d8) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
