using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Oni (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Oni2014Seeder
{
	public static Monster Build() => Create("oni", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Giant,
		16, 110, "13d10 + 39", 30, new[] { 19, 11, 16, 14, 12, 15 }, 7m, 2900, 3, 14,
		new Text(
			"Oni",
			null,
			"Gigante Grande, legale malvagio",
			"16 (cotta di maglia)",
			"9 m, volare 9 m",
			"Car +5, Cos +6, Des +3, Sag +4",
			"Arcano +5, Inganno +8, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Comune, Gigante",
			"***Armi magiche.*** Gli attacchi con arma dell'oni sono magici.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore dell'oni è Carisma (CD del tiro salvezza sull'incantesimo 13). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *invisibilità, oscurità*\n- 1/giorno ciascuno: *charme su persone, cono di freddo, forma gassosa, sonno*\n\n***Rigenerazione.*** L'oni recupera 10 punti ferita all'inizio del suo turno, se ha almeno 1 punto ferita.",
			"***Multiattacco.*** L'oni effettua due attacchi e può scegliere se con gli artigli o con il falcione.\n\n***Artiglio (solo in forma di oni).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni taglienti.\n\n***Falcione.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni taglienti o 9 (1d10 + 4) danni taglienti in forma Piccola o Media.\n\n***Cambiare forma.*** L'oni si trasforma magicamente in un umanoide Piccolo o Medio, in un gigante Grande, o ritorna alla sua vera forma. A eccezione della taglia, le sue statistiche restano le stesse in ogni forma. L'unico oggetto del suo equipaggiamento che viene trasformato è il suo falcione, che si riduce in modo da poter essere impugnato in forma umanoide. Se l'oni muore, torna alla sua vera forma e il falcione torna alla sua taglia normale.",
			"",
			"",
			"",
			""),
		new Text(
			"Oni",
			null,
			"Large giant, lawful evil",
			"16 (chain mail)",
			"30 ft., fly 30 ft.",
			"Dex +3, Con +6, Wis +4, Cha +5",
			"Arcana +5, Deception +8, Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Common, Giant",
			"***Innate Spellcasting.*** The oni's innate spellcasting ability is Charisma (spell save DC 13). The oni can innately cast the following spells, requiring no material components:\n\n\n- At will: *darkness, invisibility*\n- 1/day each: *charm person, cone of cold, gaseous form, sleep*\n\n***Magic Weapons.*** The oni's weapon attacks are magical.\n\n***Regeneration.*** The oni regains 10 hit points at the start of its turn if it has at least 1 hit point.",
			"***Multiattack.*** The oni makes two attacks, either with its claws or its glaive.\n\n***Claw (Oni Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) slashing damage.\n\n***Glaive.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) slashing damage, or 9 (1d10 + 4) slashing damage in Small or Medium form.\n\n***Change Shape.*** The oni magically polymorphs into a Small or Medium humanoid, into a Large giant, or back into its true form. Other than its size, its statistics are the same in each form. The only equipment that is transformed is its glaive, which shrinks so that it can be wielded in humanoid form. If the oni dies, it reverts to its true form, and its glaive reverts to its normal size.",
			"",
			"",
			"",
			""));
}
