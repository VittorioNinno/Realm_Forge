using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Couatl (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Couatl2014Seeder
{
	public static Monster Build() => Create("couatl", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Celestial,
		19, 97, "13d8 + 39", 30, new[] { 16, 20, 17, 18, 20, 18 }, 4m, 1100, 2, 15,
		new Text(
			"Couatl",
			null,
			"Celestiale Medio, legale buono",
			"19 (armatura naturale)",
			"9 m, volare 27 m",
			"Car +6, Cos +5, Sag +7",
			"",
			"",
			"radiosi",
			"psichici; contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"Percezione passiva 15, vista pura 36 m",
			"tutti, telepatia 36 m",
			"***Armi magiche.*** Gli attacchi con arma del couatl sono magici.\n\n***Incantesimi innati.*** La caratteristica da incantatore del couatl è Carisma (CD del tiro salvezza sull'incantesimo 14). Il couatl può lanciare i seguenti incantesimi innati, che richiedono solo componenti verbali:\n\n- A volontà: *individuazione dei pensieri, individuazione del bene e del male, individuazione del magico*\n- 3/giorno ciascuno: *benedizione, creare cibo e acqua, cura ferite, protezione dai veleni, ristorare inferiore, santuario, scudo*\n- 1/giorno ciascuno: *ristorare superiore, scrutare, sogno*\n\n***Mente schermata.*** Il couatl è immune agli scrutamenti e a qualsiasi effetto che possa percepire le sue emozioni, leggere i suoi pensieri o individuare la sua posizione.",
			"***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 8 (1d6 + 5) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 13, altrimenti viene avvelenato per 24 ore. Finché questo veleno non termina, il bersaglio è privo di sensi. Un'altra creatura può usare un'azione per scuotere il bersaglio e risvegliarlo.\n\n***Stritolare.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, una creatura di taglia Media o inferiore. *Colpito:* 10 (2d6 + 3) danni contundenti e il bersaglio è afferrato (CD 15 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e il couatl non può stritolarne un altro.\n\n***Cambiare forma.*** Il couatl si trasforma magicamente in una bestia o in un umanoide con grado di sfida pari o inferiore al proprio, o ritorna alla sua vera forma. Se muore, torna alla sua forma naturale. Ogni oggetto che indossava o trasportava è assorbito o trasportato dalla sua nuova forma (a scelta del couatl). In una nuova forma, il couatl conserva le sue statistiche di gioco e la capacità di parlare, ma CA, modalità di movimento, Forza, Destrezza e altre azioni sono sostituite da quelle della nuova forma. Inoltre, il couatl ottiene le eventuali statistiche e capacità (eccetto i privilegi di classe, le azioni leggendarie e le azioni di tana) che la nuova forma possiede, ma di cui egli è privo. Se la nuova forma ha un attacco con morso, il couatl può usare il suo morso in quella forma.",
			"",
			"",
			"",
			""),
		new Text(
			"Couatl",
			null,
			"Medium celestial, lawful good",
			"19 (natural armor)",
			"30 ft., fly 90 ft.",
			"Con +5, Wis +7, Cha +6",
			"",
			"",
			"radiant",
			"psychic; bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"truesight 120 ft., passive Perception 15",
			"all, telepathy 120 ft.",
			"***Innate Spellcasting.*** The couatl's spellcasting ability is Charisma (spell save DC 14). It can innately cast the following spells, requiring only verbal components:\n\n\n- At will: *detect evil and good, detect magic, detect thoughts*\n- 3/day each: *bless, create food and water, cure wounds, lesser restoration, protection from poison, sanctuary, shield*\n- 1/day each: *dream, greater restoration, scrying*\n\n***Magic Weapons.*** The couatl's weapon attacks are magical.\n\n***Shielded Mind.*** The couatl is immune to scrying and to any effect that would sense its emotions, read its thoughts, or detect its location.",
			"***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one creature. *Hit:* 8 (1d6 + 5) piercing damage, and the target must succeed on a DC 13 Constitution saving throw or be poisoned for 24 hours. Until this poison ends, the target is unconscious. Another creature can use an action to shake the target awake.\n\n***Constrict.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one Medium or smaller creature. *Hit:* 10 (2d6 + 3) bludgeoning damage, and the target is grappled (escape DC 15). Until this grapple ends, the target is restrained, and the couatl can't constrict another target.\n\n***Change Shape.*** The couatl magically polymorphs into a humanoid or beast that has a challenge rating equal to or less than its own, or back into its true form. It reverts to its true form if it dies. Any equipment it is wearing or carrying is absorbed or borne by the new form (the couatl's choice).\n\nIn a new form, the couatl retains its game statistics and ability to speak, but its AC, movement modes, Strength, Dexterity, and other actions are replaced by those of the new form, and it gains any statistics and capabilities (except class features, legendary actions, and lair actions) that the new form has but that it lacks. If the new form has a bite attack, the couatl can use its bite in that form.",
			"",
			"",
			"",
			""));
}
