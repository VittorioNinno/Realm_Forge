using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lemure (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lemure2014Seeder
{
	public static Monster Build() => Create("lemure", null, CreatureSize.Medium, CreatureType.Fiend,
		7, 13, "3d8", 15, new[] { 10, 5, 11, 1, 11, 3 }, 0m, 10, 2, 10,
		new Text(
			"Lemure",
			null,
			"Immondo Medio (diavolo), legale malvagio",
			"7",
			"4,5 m",
			"",
			"",
			"",
			"freddo",
			"fuoco, veleno",
			"affascinato, avvelenato, spaventato",
			"Percezione passiva 10, scurovisione 36 m",
			"capisce l'Infernale ma non lo parla",
			"***Ringiovanimento infernale.*** Se un lemure muore nei Nove Inferi, torna in vita con tutti i suoi punti ferita dopo 1d10 giorni, a meno che non sia ucciso da una creatura di allineamento buono su cui sia stato lanciato un incantesimo *benedizione* o che sui suoi resti non venga spruzzata dell'acqua santa.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del lemure.",
			"***Pugno.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti.",
			"",
			""),
		new Text(
			"Lemure",
			null,
			"Medium fiend (devil), lawful evil",
			"7",
			"15 ft.",
			"",
			"",
			"",
			"cold",
			"fire, poison",
			"charmed, frightened, poisoned",
			"darkvision 120 ft., passive Perception 10",
			"understands infernal but can't speak",
			"***Devil's Sight.*** Magical darkness doesn't impede the lemure's darkvision.\n\n***Hellish Rejuvenation.*** A lemure that dies in the Nine Hells comes back to life with all its hit points in 1d10 days unless it is killed by a good-aligned creature with a bless spell cast on that creature or its remains are sprinkled with holy water.",
			"***Fist.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage.",
			"",
			""));
}
