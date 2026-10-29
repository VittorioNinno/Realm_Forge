using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Poltergeist (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Poltergeist2014Seeder
{
	public static Monster Build() => Create("poltergeist", "specter", ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Undead,
		12, 22, "5d8", 0, new[] { 1, 14, 11, 10, 10, 11 }, 2m, 450, 2, 10,
		new Text(
			"Poltergeist",
			null,
			"Non morto Medio, caotico malvagio",
			"12",
			"0 m, volare 15 m (fluttuare)",
			"",
			"",
			"",
			"acido, freddo, fuoco, fulmine, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"necrotici, veleno",
			"affascinato, afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"capisce tutti i linguaggi che conosceva in vita ma non li parla",
			"***Movimento incorporeo.*** Il poltergeist può attraversare creature e oggetti come se fossero terreno difficile. Se termina il turno all'interno di un oggetto, subisce 5 (1d10) danni da forza.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il poltergeist subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Invisibilità.*** Il poltergeist è invisibile.",
			"***Schianto di forza.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (3d6) danni da forza.\n\n***Spinta telecinetica.*** Il poltergeist bersaglia una creatura o un oggetto incustodito entro 9 metri da lui; questa magia funziona solo su creature di taglia Media o inferiore e su oggetti fino a 75 kg.\n\nContro una creatura, il poltergeist effettua una prova di Carisma contrapposta alla prova di Forza del bersaglio; se vince, scaglia il bersaglio fino a 9 metri in qualsiasi direzione, verso l'alto compreso, e un bersaglio che urta una superficie dura o un oggetto pesante subisce 1d6 danni per ogni 3 metri di spostamento.\n\nUn oggetto che nessuno indossa o trasporta viene scagliato fino a 9 metri in qualsiasi direzione, e può essere usato come arma a distanza contro una creatura sul suo percorso (+4 al tiro per colpire, 5 (2d4) danni contundenti se colpisce).",
			"",
			"",
			"",
			"Un poltergeist è lo spirito confuso e invisibile di qualcuno che non sa come è morto; sfoga la sua rabbia scagliando creature e oggetti. Usa le statistiche dello spettro, con Schianto di forza e Spinta telecinetica al posto di Risucchio vitale."),
		new Text(
			"Poltergeist",
			null,
			"Medium undead, chaotic evil",
			"12",
			"0 ft., fly 50 ft. (hover)",
			"",
			"",
			"",
			"acid, cold, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical attacks",
			"necrotic, poison",
			"charmed, exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 10",
			"understands all languages it knew in life but can't speak",
			"***Incorporeal Movement.*** The poltergeist can pass through creatures and objects as if they were difficult terrain. If it ends its turn inside an object, it takes 5 (1d10) force damage.\n\n***Sunlight Sensitivity.*** While in sunlight, the poltergeist has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.\n\n***Invisibility.*** The poltergeist is invisible.",
			"***Forceful Slam.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 10 (3d6) force damage.\n\n***Telekinetic Thrust.*** The poltergeist targets a creature or an unattended object within 30 feet of it; this magic works only on Medium or smaller creatures and on objects up to 150 pounds.\n\nAgainst a creature, the poltergeist makes a Charisma check contested by the target's Strength check; if it wins, it hurls the target up to 30 feet in any direction, upward included, and a target that strikes a hard surface or a heavy object takes 1d6 damage for every 10 feet it was moved.\n\nAn object nobody is wearing or carrying is hurled up to 30 feet in any direction, and can be used as a ranged weapon against one creature in its path (+4 to hit, 5 (2d4) bludgeoning damage on a hit).",
			"",
			"",
			"",
			"A poltergeist is the confused, invisible spirit of someone who doesn't know how they died; it vents its rage by throwing creatures and objects around. It uses the specter's statistics, with Forceful Slam and Telekinetic Thrust instead of Life Drain."));
}
