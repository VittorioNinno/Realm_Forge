using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bone Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BoneDevil2014Seeder
{
	public static Monster Build() => Create("bone-devil", null, CreatureSize.Large, CreatureType.Fiend,
		19, 142, "15d10 + 60", 40, new[] { 18, 16, 18, 13, 14, 16 }, 9m, 5000, 4, 12,
		new Text(
			"Diavolo d'ossa",
			null,
			"Immondo Grande (diavolo), legale malvagio",
			"19 (armatura naturale)",
			"12 m, volare 12 m",
			"Car +7, Int +5, Sag +6",
			"Inganno +7, Intuizione +6",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua tre attacchi: due con gli artigli e uno con il pungiglione.\n\n***Artiglio.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni taglienti.\n\n***Pungiglione.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni perforanti più 17 (5d6) danni da veleno e il bersaglio deve superare un tiro salvezza su Costituzione con CD 14, altrimenti è avvelenato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Bone Devil",
			null,
			"Large fiend (devil), lawful evil",
			"19 (natural armor)",
			"40 ft., fly 40 ft.",
			"Int +5, Wis +6, Cha +7",
			"Deception +7, Insight +6",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 12",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes three attacks: two with its claws and one with its sting.\n\n***Claw.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 8 (1d8 + 4) slashing damage.\n\n***Sting.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 13 (2d8 + 4) piercing damage plus 17 (5d6) poison damage, and the target must succeed on a DC 14 Constitution saving throw or become poisoned for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
