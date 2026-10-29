using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bearded Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BeardedDevil2014Seeder
{
	public static Monster Build() => Create("bearded-devil", null, CreatureSize.Medium, CreatureType.Fiend,
		13, 52, "8d8 + 16", 30, new[] { 16, 15, 15, 9, 11, 11 }, 3m, 700, 2, 10,
		new Text(
			"Diavolo barbuto",
			null,
			"Immondo Medio (diavolo), legale malvagio",
			"13 (armatura naturale)",
			"9 m",
			"Cos +4, For +5, Sag +2",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 10, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Nervi saldi.*** Il diavolo non può essere spaventato finché vede una creatura alleata entro 9 metri da sé.\n\n***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua due attacchi: uno con la barba e uno con il falcione.\n\n***Barba.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 6 (1d8 + 2) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 12, altrimenti è avvelenato per 1 minuto. Finché è avvelenato in questo modo, il bersaglio non può recuperare punti ferita. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Falcione.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni taglienti. Se il bersaglio è una creatura diversa da un non morto o da un costrutto, deve superare un tiro salvezza su Costituzione con CD 12, altrimenti perde 5 (1d10) punti ferita all'inizio di ogni suo turno a causa di una ferita infernale. Ogni volta che il diavolo colpisce il bersaglio ferito con questo attacco, i danni inflitti dalla ferita aumentano di 5 (1d10). Una creatura qualsiasi può effettuare un'azione per tamponare la ferita superando una prova di Saggezza (Medicina) con CD 12. La ferita si richiude anche se il bersaglio riceve una qualsiasi forma di guarigione magica.",
			"",
			""),
		new Text(
			"Bearded Devil",
			null,
			"Medium fiend (devil), lawful evil",
			"13 (natural armor)",
			"30 ft.",
			"Str +5, Con +4, Wis +2",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 10",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.\n\n***Steadfast.*** The devil can't be frightened while it can see an allied creature within 30 feet of it.",
			"***Multiattack.*** The devil makes two attacks: one with its beard and one with its glaive.\n\n***Beard.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 6 (1d8 + 2) piercing damage, and the target must succeed on a DC 12 Constitution saving throw or be poisoned for 1 minute. While poisoned in this way, the target can't regain hit points. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\n***Glaive.*** *Melee Weapon Attack:* +5 to hit, reach 10 ft., one target. *Hit:* 8 (1d10 + 3) slashing damage. If the target is a creature other than an undead or a construct, it must succeed on a DC 12 Constitution saving throw or lose 5 (1d10) hit points at the start of each of its turns due to an infernal wound. Each time the devil hits the wounded target with this attack, the damage dealt by the wound increases by 5 (1d10). Any creature can take an action to stanch the wound with a successful DC 12 Wisdom (Medicine) check. The wound also closes if the target receives magical healing.",
			"",
			""));
}
