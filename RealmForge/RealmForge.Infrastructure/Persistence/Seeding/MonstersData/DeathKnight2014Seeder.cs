using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Death Knight (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DeathKnight2014Seeder
{
	public static Monster Build() => Create("death-knight", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Undead,
		20, 180, "19d8 + 95", 30, new[] { 20, 11, 20, 12, 16, 18 }, 17m, 18000, 6, 13,
		new Text(
			"Cavaliere della morte",
			null,
			"Non morto Medio, caotico malvagio",
			"20 (armatura completa, scudo)",
			"9 m",
			"Car +10, Des +6, Sag +9",
			"",
			"",
			"",
			"necrotici, veleno",
			"avvelenato, indebolimento, spaventato",
			"Percezione passiva 13, scurovisione 36 m",
			"Abissale, Comune",
			"***Resistenza alla magia.*** Il cavaliere della morte dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Comandante dei non morti.*** Finché non è incapacitato, il cavaliere della morte e i non morti a sua scelta entro 18 metri da lui dispongono di vantaggio ai tiri salvezza contro i privilegi che scacciano i non morti.\n\n***Incantesimi.*** Il cavaliere della morte lancia incantesimi come un incantatore di 19° livello, usando il Carisma (CD del tiro salvezza sull'incantesimo 18, +10 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da paladino:\n\n- 1° livello (4 slot): *comando*, *duello obbligato*, *punizione rovente*\n- 2° livello (3 slot): *blocca persone*, *arma magica*\n- 3° livello (3 slot): *dissolvi magie*, *arma elementale*\n- 4° livello (3 slot): *esilio*, *punizione barcollante*\n- 5° livello (2 slot): *onda distruttiva* (necrotici)",
			"***Multiattacco.*** Il cavaliere della morte effettua tre attacchi con la spada lunga.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d8 + 5) danni taglienti, o 10 (1d10 + 5) danni taglienti se impugnata a due mani. In entrambi i casi il colpo infligge anche 18 (4d8) danni necrotici.\n\n***Globo di fuoco infernale (1/giorno).*** Il cavaliere della morte scaglia una sfera di fuoco magica che esplode in un punto che è in grado di vedere entro 36 metri da lui, riempiendo una sfera di 6 metri di raggio che si propaga oltre gli angoli. Ogni creatura nella sfera effettua un tiro salvezza su Destrezza con CD 18 e subisce 35 (10d6) danni da fuoco e 35 (10d6) danni necrotici se lo fallisce, o la metà se lo supera.",
			"",
			"***Parata.*** Quando un attacco in mischia sta per colpirlo, il cavaliere della morte può aggiungere 6 alla sua CA contro quell'attacco, purché veda l'attaccante e impugni un'arma da mischia.",
			"",
			""),
		new Text(
			"Death Knight",
			null,
			"Medium undead, chaotic evil",
			"20 (plate, shield)",
			"30 ft.",
			"Dex +6, Wis +9, Cha +10",
			"",
			"",
			"",
			"necrotic, poison",
			"exhaustion, frightened, poisoned",
			"darkvision 120 ft., passive Perception 13",
			"Abyssal, Common",
			"***Magic Resistance.*** The death knight has advantage on saving throws against spells and other magical effects.\n\n***Marshal Undead.*** While it isn't incapacitated, the death knight and any undead of its choice within 60 feet of it have advantage on saving throws against features that turn undead.\n\n***Spellcasting.*** The death knight casts spells as a 19th-level spellcaster, using Charisma (spell save DC 18, +10 to hit with spell attacks). It has these paladin spells prepared:\n\n- 1st level (4 slots): *command*, *compelled duel*, *searing smite*\n- 2nd level (3 slots): *hold person*, *magic weapon*\n- 3rd level (3 slots): *dispel magic*, *elemental weapon*\n- 4th level (3 slots): *banishment*, *staggering smite*\n- 5th level (2 slots): *destructive wave* (necrotic)",
			"***Multiattack.*** The death knight makes three longsword attacks.\n\n***Longsword.*** *Melee Weapon Attack:* +11 to hit, reach 5 ft., one target. *Hit:* 9 (1d8 + 5) slashing damage, or 10 (1d10 + 5) slashing damage if used with two hands. Either way, the hit also deals 18 (4d8) necrotic damage.\n\n***Hellfire Orb (1/Day).*** The death knight throws a magical ball of fire that bursts at a point it can see within 120 feet of it, filling a 20-foot-radius sphere that spreads around corners. Each creature in the sphere makes a DC 18 Dexterity saving throw, taking 35 (10d6) fire damage and 35 (10d6) necrotic damage on a failure, or half as much on a success.",
			"",
			"***Parry.*** When a melee attack would hit it, the death knight can add 6 to its AC against that attack, provided it can see the attacker and holds a melee weapon.",
			"",
			""));
}
