using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Empyrean (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Empyrean2014Seeder
{
	public static Monster Build() => Create("empyrean", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Celestial,
		22, 313, "19d12 + 190", 50, new[] { 30, 21, 30, 21, 22, 27 }, 23m, 50000, 7, 16,
		new Text(
			"Empireo",
			null,
			"Celestiale Enorme (titano), caotico buono (75%) o neutrale malvagio (25%)",
			"22 (armatura naturale)",
			"15 m, volare 15 m, nuotare 15 m",
			"Car +15, For +17, Int +12, Sag +13",
			"Intuizione +13, Persuasione +15",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"Percezione passiva 16, vista pura 36 m",
			"tutti",
			"***Incantesimi innati.*** L'empireo lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 23, +15 al tiro per colpire con attacco con incantesimo), senza bisogno di componenti materiali:\n\n- A volontà: *ristorare superiore*, *passare senza tracce*, *respirare sott'acqua*, *camminare sull'acqua*\n- 1/giorno ciascuno: *comunione*, *dissolvi il bene e il male*, *terremoto*, *tempesta di fuoco*, *spostamento planare* (solo su se stesso)\n\n***Resistenza leggendaria (3/giorno).*** Se l'empireo fallisce un tiro salvezza, può scegliere di superarlo comunque.\n\n***Resistenza alla magia.*** L'empireo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma dell'empireo sono considerati magici.",
			"***Maglio.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 31 (6d6 + 10) danni contundenti. Una creatura colpita deve superare un tiro salvezza su Costituzione con CD 15, altrimenti è stordita fino alla fine del turno successivo dell'empireo.\n\n***Dardo.*** *Attacco con incantesimo a distanza:* +15 al tiro per colpire, gittata 180 m, un bersaglio. *Colpito:* 24 (7d6) danni di un tipo a scelta dell'empireo: acido, forza, freddo, fulmine, fuoco, radiosi o tuono.",
			"",
			"",
			"L'empireo può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, l'empireo recupera le azioni leggendarie effettuate.\n\n***Attacco.*** L'empireo effettua un attacco.\n\n***Rincuorare.*** Fino alla fine del turno successivo dell'empireo, ogni creatura non ostile entro 36 metri da lui non può essere affascinata o spaventata e dispone di vantaggio alle prove di caratteristica e ai tiri salvezza.\n\n***Colpo tellurico (costa 2 azioni).*** L'empireo abbatte il maglio sul terreno e provoca una scossa: ogni altra creatura sul terreno entro 18 metri da lui effettua un tiro salvezza su Forza con CD 25, altrimenti cade prona.",
			""),
		new Text(
			"Empyrean",
			null,
			"Huge celestial (titan), chaotic good (75%) or neutral evil (25%)",
			"22 (natural armor)",
			"50 ft., fly 50 ft., swim 50 ft.",
			"Str +17, Int +12, Wis +13, Cha +15",
			"Insight +13, Persuasion +15",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"",
			"truesight 120 ft., passive Perception 16",
			"all",
			"***Innate Spellcasting.*** The empyrean casts the following spells innately, using Charisma (spell save DC 23, +15 to hit with spell attacks) and needing no material components:\n\n- At will: *greater restoration*, *pass without trace*, *water breathing*, *water walk*\n- 1/day each: *commune*, *dispel evil and good*, *earthquake*, *fire storm*, *plane shift* (self only)\n\n***Legendary Resistance (3/Day).*** If the empyrean fails a saving throw, it can choose to succeed instead.\n\n***Magic Resistance.*** The empyrean has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The empyrean's weapon attacks count as magical.",
			"***Maul.*** *Melee Weapon Attack:* +17 to hit, reach 10 ft., one target. *Hit:* 31 (6d6 + 10) bludgeoning damage. A creature hit must succeed on a DC 15 Constitution saving throw or be stunned until the end of the empyrean's next turn.\n\n***Bolt.*** *Ranged Spell Attack:* +15 to hit, range 600 ft., one target. *Hit:* 24 (7d6) damage of a type the empyrean chooses: acid, cold, fire, force, lightning, radiant or thunder.",
			"",
			"",
			"The empyrean can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The empyrean regains spent legendary actions at the start of its turn.\n\n***Attack.*** The empyrean makes one attack.\n\n***Bolster.*** Until the end of the empyrean's next turn, every creature within 120 feet of it that isn't hostile to it can't be charmed or frightened and has advantage on ability checks and saving throws.\n\n***Trembling Strike (Costs 2 Actions).*** The empyrean smashes its maul into the ground and sets off a tremor: every other creature on the ground within 60 feet of it makes a DC 25 Strength saving throw or is knocked prone.",
			""));
}
