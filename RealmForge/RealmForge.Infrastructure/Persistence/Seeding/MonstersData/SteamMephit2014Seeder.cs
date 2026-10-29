using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Steam Mephit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SteamMephit2014Seeder
{
	public static Monster Build() => Create("steam-mephit", null, CreatureSize.Small, CreatureType.Elemental,
		10, 21, "6d6", 30, new[] { 5, 11, 10, 11, 10, 12 }, 0.25m, 50, 2, 10,
		new Text(
			"Mephit del vapore",
			null,
			"Elementale Piccolo, neutrale malvagio",
			"10",
			"9 m, volare 9 m",
			"",
			"",
			"",
			"",
			"fuoco, veleno",
			"avvelenato",
			"Percezione passiva 10, scurovisione 18 m",
			"Aquan, Ignan",
			"***Esplosione della morte.*** Quando il mephit muore, esplode in una nube di vapore. Ogni creatura situata entro 1,5 metri dal mephit deve superare un tiro salvezza su Destrezza con CD 10, altrimenti subisce 4 (1d8) danni da fuoco.\n\n***Incantesimi innati (1/giorno).*** Il mephit può lanciare *sfocatura* come incantesimo innato senza aver bisogno di componenti materiali. La sua caratteristica innata da incantatore è Carisma.",
			"***Artigli.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 2 (1d4) danni taglienti più 2 (1d4) danni da fuoco.\n\n***Soffio di vapore (ricarica 6).*** Il mephit esala vapore ustionante in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 10, subendo 4 (1d8) danni da fuoco in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Steam Mephit",
			null,
			"Small elemental, neutral evil",
			"10",
			"30 ft., fly 30 ft.",
			"",
			"",
			"",
			"",
			"fire, poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 10",
			"Aquan, Ignan",
			"***Death Burst.*** When the mephit dies, it explodes in a cloud of steam. Each creature within 5 ft. of the mephit must succeed on a DC 10 Dexterity saving throw or take 4 (1d8) fire damage.\n\n***Innate Spellcasting.*** The mephit can innately cast blur, requiring no material components. Its innate spellcasting ability is Charisma.",
			"***Claws.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one creature. *Hit:* 2 (1d4) slashing damage plus 2 (1d4) fire damage.\n\n***Steam Breath (Recharge 6).*** The mephit exhales a 15-foot cone of scalding steam. Each creature in that area must succeed on a DC 10 Dexterity saving throw, taking 4 (1d8) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
