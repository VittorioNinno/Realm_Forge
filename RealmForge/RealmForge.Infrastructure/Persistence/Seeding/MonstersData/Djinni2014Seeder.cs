using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Djinni (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Djinni2014Seeder
{
	public static Monster Build() => Create("djinni", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Elemental,
		17, 161, "14d10 + 84", 30, new[] { 21, 15, 22, 15, 16, 20 }, 11m, 7200, 4, 13,
		new Text(
			"Djinni",
			null,
			"Elementale Grande, caotico buono",
			"17 (armatura naturale)",
			"9 m, volare 27 m",
			"Car +9, Des +6, Sag +7",
			"",
			"",
			"",
			"fulmine, tuono",
			"",
			"Percezione passiva 13, scurovisione 36 m",
			"Auran",
			"***Dipartita elementale.*** Se il djinni muore, il suo corpo si disintegra in una calda brezza, lasciando dietro di sé solo gli oggetti che la creatura indossava o trasportava.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore del djinni è Carisma (CD del tiro salvezza sull'incantesimo 17, +9 al tiro per colpire con attacco con incantesimo). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del bene e del male, individuazione del magico, onda tonante*\n- 3/giorno ciascuno: *camminare nel vento, creare cibo e bevande* (può creare vino anziché acqua), *linguaggi*\n- 1/giorno ciascuno: *creazione, evoca elementale* (solo elementale dell'aria), *forma gassosa, immagine maggiore, invisibilità, spostamento planare*",
			"***Multiattacco.*** Il djinni effettua tre attacchi con la scimitarra.\n\n***Scimitarra.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti più 3 (1d6) danni da fulmine o da tuono (a scelta del djinni).\n\n***Creare vortice.*** Un cilindro di aria turbinante del raggio di 1,5 metri e alto 9 metri si forma magicamente in un punto che il djinni può vedere entro 36 metri. Il vortice permane finché il djinni mantiene la concentrazione (come se si concentrasse su un incantesimo). Ogni creatura a eccezione del djinni che entri nel vortice deve superare un tiro salvezza su Forza con CD 18, altrimenti è trattenuta dal vortice. Il djinni può muovere il vortice di un massimo di 18 metri con un'azione e le creature trattenute dal vortice si muovono insieme a esso. Il vortice termina se il djinni lo perde di vista. Una creatura può usare la sua azione per liberare una creatura trattenuta dal vortice, inclusa se stessa, effettuando una prova di Forza con CD 18. In caso di successo, la creatura non è più trattenuta e si muove nello spazio più vicino al di fuori del vortice.",
			"",
			"",
			"",
			""),
		new Text(
			"Djinni",
			null,
			"Large elemental, chaotic good",
			"17 (natural armor)",
			"30 ft., fly 90 ft.",
			"Dex +6, Wis +7, Cha +9",
			"",
			"",
			"",
			"lightning, thunder",
			"",
			"darkvision 120 ft., passive Perception 13",
			"Auran",
			"***Elemental Demise.*** If the djinni dies, its body disintegrates into a warm breeze, leaving behind only equipment the djinni was wearing or carrying.\n\n***Innate Spellcasting.*** The djinni's innate spellcasting ability is Charisma (spell save DC 17, +9 to hit with spell attacks). It can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect evil and good, detect magic, thunderwave*\n- 3/day each: *create food and water (can create wine instead of water), tongues, wind walk*\n- 1/day each: *conjure elemental (air elemental only), creation, gaseous form, invisibility, major image, plane shift*",
			"***Multiattack.*** The djinni makes three scimitar attacks.\n\n***Scimitar.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage plus 3 (1d6) lightning or thunder damage (djinni's choice).\n\n***Create Whirlwind.*** A 5-foot-radius, 30-foot-tall cylinder of swirling air magically forms on a point the djinni can see within 120 feet of it. The whirlwind lasts as long as the djinni maintains concentration (as if concentrating on a spell). Any creature but the djinni that enters the whirlwind must succeed on a DC 18 Strength saving throw or be restrained by it. The djinni can move the whirlwind up to 60 feet as an action, and creatures restrained by the whirlwind move with it. The whirlwind ends if the djinni loses sight of it.\n\nA creature can use its action to free a creature restrained by the whirlwind, including itself, by succeeding on a DC 18 Strength check. If the check succeeds, the creature is no longer restrained and moves to the nearest space outside the whirlwind.",
			"",
			"",
			"",
			""));
}
