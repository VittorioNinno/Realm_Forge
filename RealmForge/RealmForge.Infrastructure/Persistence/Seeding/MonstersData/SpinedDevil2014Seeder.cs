using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Spined Devil (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class SpinedDevil2014Seeder
{
	public static Monster Build() => Create("spined-devil", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Fiend,
		13, 22, "5d6 + 5", 20, new[] { 10, 15, 12, 11, 14, 8 }, 2m, 450, 2, 12,
		new Text(
			"Diavolo spinato",
			null,
			"Immondo Piccolo (diavolo), legale malvagio",
			"13 (armatura naturale)",
			"6 m, volare 12 m",
			"",
			"",
			"",
			"freddo; contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 36 m",
			"Infernale, telepatia 36 m",
			"***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.\n\n***Volo radente.*** Il diavolo non provoca attacchi di opportunità quando esce in volo dalla portata di un nemico.\n\n***Spine limitate.*** Il diavolo ha dodici spine nella coda; quelle usate ricrescono entro la fine del suo riposo lungo successivo.\n\n***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il diavolo effettua due attacchi: uno con il morso e uno con il forcone, oppure due con le spine della coda.\n\n***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (2d4) danni taglienti.\n\n***Forcone.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d6) danni perforanti.\n\n***Spina della coda.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 6/24 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti più 3 (1d6) danni da fuoco.",
			"",
			"",
			"",
			""),
		new Text(
			"Spined Devil",
			null,
			"Small fiend (devil), lawful evil",
			"13 (natural armor)",
			"20 ft., fly 40 ft.",
			"",
			"",
			"",
			"cold; bludgeoning, piercing, and slashing from nonmagical attacks that aren't silvered",
			"fire, poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 12",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't hinder the devil's darkvision.\n\n***Flyby.*** The devil doesn't provoke opportunity attacks when it flies out of an enemy's reach.\n\n***Limited Spines.*** The devil has twelve spines in its tail; the ones it uses grow back by the end of its next long rest.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes two attacks: a bite and a fork attack, or two tail spine attacks.\n\n***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 5 (2d4) slashing damage.\n\n***Fork.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 3 (1d6) piercing damage.\n\n***Tail Spine.*** *Ranged Weapon Attack:* +4 to hit, range 20/80 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage plus 3 (1d6) fire damage.",
			"",
			"",
			"",
			""));
}
