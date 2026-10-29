using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Barbed Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BarbedDevil2014Seeder
{
	public static Monster Build() => Create("barbed-devil", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fiend,
		15, 110, "13d8 + 52", 30, new[] { 16, 17, 18, 12, 14, 14 }, 5m, 1800, 3, 18,
		new Text(
			"Diavolo uncinato",
			null,
			"Immondo Medio (diavolo), legale malvagio",
			"15 (armatura naturale)",
			"9 m",
			"Car +5, Cos +7, For +6, Sag +5",
			"Inganno +5, Intuizione +5, Percezione +8",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 18, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Pelle uncinata.*** All'inizio di ogni suo turno, il diavolo uncinato infligge 5 (1d10) danni perforanti a ogni creatura con cui lotta.\n\n***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua tre attacchi in mischia: uno con la coda e due con gli artigli. In alternativa, può usare Scagliare fiamma due volte.\n\n***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Coda.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti.\n\n***Scagliare fiamma.*** *Attacco a distanza con incantesimo:* +5 al tiro per colpire, gittata 45 m, un bersaglio. *Colpito:* 10 (3d6) danni da fuoco. Se il bersaglio è un oggetto infiammabile che non è indossato o trasportato, prende anche fuoco.",
			"",
			"",
			"",
			""),
		new Text(
			"Barbed Devil",
			null,
			"Medium fiend (devil), lawful evil",
			"15 (natural armor)",
			"30 ft.",
			"Str +6, Con +7, Wis +5, Cha +5",
			"Deception +5, Insight +5, Perception +8",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 18",
			"Infernal, telepathy 120 ft.",
			"***Barbed Hide.*** At the start of each of its turns, the barbed devil deals 5 (1d10) piercing damage to any creature grappling it.\n\n***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes three melee attacks: one with its tail and two with its claws. Alternatively, it can use Hurl Flame twice.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Tail.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage.\n\n***Hurl Flame.*** *Ranged Spell Attack:* +5 to hit, range 150 ft., one target. *Hit:* 10 (3d6) fire damage. If the target is a flammable object that isn't being worn or carried, it also catches fire.",
			"",
			"",
			"",
			""));
}
