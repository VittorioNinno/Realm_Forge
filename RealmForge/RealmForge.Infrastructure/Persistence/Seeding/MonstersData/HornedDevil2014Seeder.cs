using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Horned Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class HornedDevil2014Seeder
{
	public static Monster Build() => Create("horned-devil", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Fiend,
		18, 178, "17d10 + 85", 20, new[] { 22, 17, 21, 12, 16, 17 }, 11m, 7200, 4, 13,
		new Text(
			"Diavolo cornuto",
			null,
			"Immondo Grande (diavolo), legale malvagio",
			"18 (armatura naturale)",
			"6 m, volare 18 m",
			"Car +7, Des +7, For +10, Sag +7",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 13, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua tre attacchi in mischia: due con il forcone e uno con la coda. Può usare Scagliare fiamma al posto di qualsiasi attacco in mischia.\n\n***Forcone.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d8 + 6) danni perforanti.\n\n***Coda.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 10 (1d8 + 6) danni perforanti. Se il bersaglio è una creatura diversa da un non morto o da un costrutto, deve superare un tiro salvezza su Costituzione con CD 17, altrimenti perde 10 (3d6) punti ferita all'inizio di ogni suo turno a causa di una ferita infernale. Ogni volta che il diavolo colpisce il bersaglio ferito con questo attacco, i danni inflitti dalla ferita aumentano di 10 (3d6). Una creatura qualsiasi può effettuare un'azione per tamponare la ferita superando una prova di Saggezza (Medicina) con CD 12. La ferita si richiude anche se il bersaglio riceve una qualsiasi forma di guarigione magica.\n\n***Scagliare fiamma.*** *Attacco a distanza con incantesimo:* +7 al tiro per colpire, gittata 45 m, un bersaglio. *Colpito:* 14 (4d6) danni da fuoco. Se il bersaglio è un oggetto infiammabile che non è indossato o trasportato, prende anche fuoco.",
			"",
			"",
			"",
			""),
		new Text(
			"Horned Devil",
			null,
			"Large fiend (devil), lawful evil",
			"18 (natural armor)",
			"20 ft., fly 60 ft.",
			"Str +10, Dex +7, Wis +7, Cha +7",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 13",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes three melee attacks: two with its fork and one with its tail. It can use Hurl Flame in place of any melee attack.\n\n***Fork.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 15 (2d8 + 6) piercing damage.\n\n***Tail.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 10 (1d8 + 6) piercing damage. If the target is a creature other than an undead or a construct, it must succeed on a DC 17 Constitution saving throw or lose 10 (3d6) hit points at the start of each of its turns due to an infernal wound. Each time the devil hits the wounded target with this attack, the damage dealt by the wound increases by 10 (3d6). Any creature can take an action to stanch the wound with a successful DC 12 Wisdom (Medicine) check. The wound also closes if the target receives magical healing.\n\n***Hurl Flame.*** *Ranged Spell Attack:* +7 to hit, range 150 ft., one target. *Hit:* 14 (4d6) fire damage. If the target is a flammable object that isn't being worn or carried, it also catches fire.",
			"",
			"",
			"",
			""));
}
