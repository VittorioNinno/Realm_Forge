using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Smoke Mephit (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class SmokeMephit2014Seeder
{
	public static Monster Build() => Create("smoke-mephit", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Elemental,
		12, 22, "5d6 + 5", 30, new[] { 6, 14, 12, 10, 10, 11 }, 0.25m, 50, 2, 12,
		new Text(
			"Mephit del fumo",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"12",
			"9 m, volare 9 m",
			"",
			"Furtività +4, Percezione +2",
			"",
			"",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 18 m",
			"Auran, Ignan",
			"***Esplosione mortale.*** Quando muore, il mephit lascia una nube di fumo che riempie una sfera di 1,5 metri di raggio centrata sul suo spazio. L'area è pesantemente oscurata; la nube dura 1 minuto, a meno che il vento non la disperda.\n\n***Incantesimi innati (1/giorno).*** Usando il Carisma, il mephit può lanciare per natura *luci danzanti*, senza componenti materiali.",
			"***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni taglienti.\n\n***Soffio di cenere (ricarica 6).*** Il mephit esala cenere ardente in un cono di 4,5 metri. Ogni creatura nel cono effettua un tiro salvezza su Destrezza con CD 10, altrimenti è accecata fino alla fine del turno successivo del mephit.",
			"",
			"",
			"",
			""),
		new Text(
			"Smoke Mephit",
			null,
			"Small elemental, neutral evil",
			"12",
			"30 ft., fly 30 ft.",
			"",
			"Perception +2, Stealth +4",
			"",
			"",
			"fire, poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Auran, Ignan",
			"***Death Burst.*** When the mephit dies, it leaves a cloud of smoke filling a 5-foot-radius sphere centered on its space. The area is heavily obscured; the cloud lasts 1 minute unless the wind blows it away.\n\n***Innate Spellcasting (1/Day).*** Using Charisma, the mephit can cast dancing lights innately, without material components.",
			"***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) slashing damage.\n\n***Cinder Breath (Recharge 6).*** The mephit breathes smoldering ash in a 15-foot cone. Each creature in the cone makes a DC 10 Dexterity saving throw or is blinded until the end of the mephit's next turn.",
			"",
			"",
			"",
			""));
}
