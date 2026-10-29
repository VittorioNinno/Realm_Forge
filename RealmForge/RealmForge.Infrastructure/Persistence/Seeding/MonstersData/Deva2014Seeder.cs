using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Deva (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Deva2014Seeder
{
	public static Monster Build() => Create("deva", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Celestial,
		17, 136, "16d8 + 64", 30, new[] { 18, 18, 18, 17, 20, 20 }, 10m, 5900, 4, 19,
		new Text(
			"Deva",
			null,
			"Celestiale Medio, legale buono",
			"17 (armatura naturale)",
			"9 m, volare 27 m",
			"Car +9, Sag +9",
			"Intuizione +9, Percezione +9",
			"",
			"radiosi, contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"affascinato, indebolimento, spaventato",
			"Percezione passiva 19, scurovisione 36 m",
			"tutti, telepatia 36 m",
			"***Armi angeliche.*** Gli attacchi con arma del deva sono magici. Quando il deva colpisce con qualsiasi arma, la sua arma infligge 4d8 danni radiosi extra (già inclusi nell'attacco).\n\n***Incantesimi innati.*** La caratteristica da incantatore del deva è Carisma (CD del tiro salvezza sull'incantesimo 17). Il deva può lanciare i seguenti incantesimi innati, che richiedono solo componenti verbali:\n\n- A volontà: *individuazione del bene e del male*\n- 1/giorno ciascuno: *comunione, rianimare morti*\n\n***Resistenza alla magia.*** Il deva dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il deva effettua due attacchi in mischia.\n\n***Mazza.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni contundenti più 18 (4d8) danni radiosi.\n\n***Cambiare forma.*** Il deva si trasforma magicamente in una bestia o in un umanoide con grado di sfida pari o inferiore al proprio, o ritorna alla sua vera forma. Se muore, torna alla sua forma naturale. Ogni oggetto che indossava o trasportava viene assorbito o trasportato dalla sua nuova forma (a scelta del deva). In una nuova forma, il deva conserva le sue statistiche di gioco e la capacità di parlare, ma CA, modalità di movimento, Forza, Destrezza e sensi speciali sono sostituiti da quelli della nuova forma. Inoltre, il deva ottiene le eventuali statistiche e capacità (eccetto i privilegi di classe, le azioni leggendarie e le azioni di tana) che la nuova forma possiede, ma di cui egli è privo.\n\n***Tocco Guaritore (3/giorno).*** Il deva tocca un'altra creatura. Il bersaglio recupera magicamente 20 (4d8 + 2) punti ferita ed è liberato da qualsiasi maledizione, malattia, veleno, cecità o sordità.",
			"",
			"",
			"",
			""),
		new Text(
			"Deva",
			null,
			"Medium celestial, lawful good",
			"17 (natural armor)",
			"30 ft., fly 90 ft.",
			"Wis +9, Cha +9",
			"Insight +9, Perception +9",
			"",
			"radiant; bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"charmed, exhaustion, frightened",
			"darkvision 120 ft., passive Perception 19",
			"all, telepathy 120 ft.",
			"***Angelic Weapons.*** The deva's weapon attacks are magical. When the deva hits with any weapon, the weapon deals an extra 4d8 radiant damage (included in the attack).\n\n***Innate Spellcasting.*** The deva's spellcasting ability is Charisma (spell save DC 17). The deva can innately cast the following spells, requiring only verbal components:\n\n- At will: *detect evil and good*\n- 1/day each: *commune, raise dead*\n\n***Magic Resistance.*** The deva has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The deva makes two melee attacks.\n\n***Mace.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 7 (1d6 + 4) bludgeoning damage plus 18 (4d8) radiant damage.\n\n***Healing Touch (3/Day).*** The deva touches another creature. The target magically regains 20 (4d8 + 2) hit points and is freed from any curse, disease, poison, blindness, or deafness.\n\n***Change Shape.*** The deva magically polymorphs into a humanoid or beast that has a challenge rating equal to or less than its own, or back into its true form. It reverts to its true form if it dies. Any equipment it is wearing or carrying is absorbed or borne by the new form (the deva's choice).\n\nIn a new form, the deva retains its game statistics and ability to speak, but its AC, movement modes, Strength, Dexterity, and special senses are replaced by those of the new form, and it gains any statistics and capabilities (except class features, legendary actions, and lair actions) that the new form has but that it lacks.",
			"",
			"",
			"",
			""));
}
