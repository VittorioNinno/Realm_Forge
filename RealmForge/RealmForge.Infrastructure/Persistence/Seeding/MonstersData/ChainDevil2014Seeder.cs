using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Chain Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ChainDevil2014Seeder
{
	public static Monster Build() => Create("chain-devil", null, CreatureSize.Medium, CreatureType.Fiend,
		16, 85, "10d8 + 40", 30, new[] { 18, 15, 18, 11, 12, 14 }, 8m, 3900, 3, 11,
		new Text(
			"Diavolo delle catene",
			null,
			"Immondo Medio (diavolo), legale malvagio",
			"16 (armatura naturale)",
			"9 m",
			"Car +5, Cos +7, Sag +4",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua due attacchi con le catene.\n\n***Catena.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti. Il bersaglio è afferrato (CD 14 per sfuggire) se il diavolo non sta già afferrando una creatura. Finché la presa perdura, il bersaglio è trattenuto e subisce 7 (2d6) danni perforanti all'inizio di ogni suo turno.\n\n***Catene animate (ricarica dopo un riposo lungo o breve).*** Da un massimo di quattro catene entro 18 metri nel campo visivo del diavolo crescono magicamente degli spuntoni affilati come lame; le catene si animano sotto il suo controllo, purché non siano indossate o trasportate. Ogni catena animata è un oggetto con CA 20, 20 punti ferita, resistenza ai danni perforanti e immunità ai danni psichici e ai danni da tuono. Quando il diavolo usa Multiattacco nel suo turno, può usare ogni catena animata per effettuare un attacco aggiuntivo con una catena. Una catena animata può afferrare una creatura di sua spontanea volontà, ma non può effettuare attacchi finché è impegnata in questa lotta. Torna nel suo stato inanimato se ridotta a 0 punti ferita oppure se il diavolo è incapacitato o muore.",
			"***Maschera snervante.*** Quando una creatura che il diavolo è in grado di vedere inizia il proprio turno entro 9 metri da quest'ultimo, il diavolo può creare un'illusione che lo fa apparire come una persona scomparsa cara alla creatura o come un suo acerrimo nemico. Se la creatura può vedere il diavolo, deve superare un tiro salvezza su Saggezza con CD 14, altrimenti è spaventata fino alla fine del proprio turno.",
			""),
		new Text(
			"Chain Devil",
			null,
			"Medium fiend (devil), lawful evil",
			"16 (natural armor)",
			"30 ft.",
			"Con +7, Wis +4, Cha +5",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes two attacks with its chains.\n\n***Chain.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage. The target is grappled (escape DC 14) if the devil isn't already grappling a creature. Until this grapple ends, the target is restrained and takes 7 (2d6) piercing damage at the start of each of its turns.\n\n***Animate Chains (Recharges after a Short or Long Rest).*** Up to four chains the devil can see within 60 feet of it magically sprout razor-edged barbs and animate under the devil's control, provided that the chains aren't being worn or carried.\n\nEach animated chain is an object with AC 20, 20 hit points, resistance to piercing damage, and immunity to psychic and thunder damage. When the devil uses Multiattack on its turn, it can use each animated chain to make one additional chain attack. An animated chain can grapple one creature of its own but can't make attacks while grappling. An animated chain reverts to its inanimate state if reduced to 0 hit points or if the devil is incapacitated or dies.",
			"***Unnerving Mask.*** When a creature the devil can see starts its turn within 30 feet of the devil, the devil can create the illusion that it looks like one of the creature's departed loved ones or bitter enemies. If the creature can see the devil, it must succeed on a DC 14 Wisdom saving throw or be frightened until the end of its turn.",
			""));
}
