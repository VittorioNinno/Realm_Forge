using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dragon Turtle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DragonTurtle2014Seeder
{
	public static Monster Build() => Create("dragon-turtle", null, ContentSource.Srd51, CreatureSize.Gargantuan, CreatureType.Dragon,
		20, 341, "22d20 + 110", 20, new[] { 25, 10, 20, 10, 12, 12 }, 17m, 18000, 6, 11,
		new Text(
			"Testuggine dragona",
			null,
			"Drago Mastodontico, neutrale",
			"20 (armatura naturale)",
			"6 m, nuotare 12 m",
			"Cos +11, Des +6, Sag +7",
			"",
			"",
			"fuoco",
			"",
			"",
			"Percezione passiva 11, scurovisione 36 m",
			"Aquan, Draconico",
			"***Anfibio.*** La testuggine dragona può respirare in aria e in acqua.",
			"***Multiattacco.*** La testuggine dragona effettua tre attacchi: uno con il morso e due con gli artigli. Può effettuare un attacco con la coda al posto dei due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 16 (2d8 + 7) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 26 (3d12 + 7) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 20, altrimenti è scagliato a 3 metri dalla testuggine dragona e buttato a terra prono.\n\n***Morso.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 26 (3d12 + 7) danni perforanti.\n\n***Soffio di vapore (ricarica 5–6).*** La testuggine dragona esala vapore ustionante in un cono di 18 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 18, subendo 52 (15d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo. Trovarsi sott'acqua non conferisce resistenza a tali danni.",
			"",
			"",
			"",
			""),
		new Text(
			"Dragon Turtle",
			null,
			"Gargantuan dragon, neutral",
			"20 (natural armor)",
			"20 ft., swim 40 ft.",
			"Dex +6, Con +11, Wis +7",
			"",
			"",
			"fire",
			"",
			"",
			"darkvision 120 ft., passive Perception 11",
			"Aquan, Draconic",
			"***Amphibious.*** The dragon turtle can breathe air and water.",
			"***Multiattack.*** The dragon turtle makes three attacks: one with its bite and two with its claws. It can make one tail attack in place of its two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +13 to hit, reach 15 ft., one target. *Hit:* 26 (3d12 + 7) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 16 (2d8 + 7) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +13 to hit, reach 15 ft., one target. *Hit:* 26 (3d12 + 7) bludgeoning damage. If the target is a creature, it must succeed on a DC 20 Strength saving throw or be pushed up to 10 feet away from the dragon turtle and knocked prone.\n\n***Steam Breath (Recharge 5–6).*** The dragon turtle exhales scalding steam in a 60-foot cone. Each creature in that area must make a DC 18 Constitution saving throw, taking 52 (15d6) fire damage on a failed save, or half as much damage on a successful one. Being underwater doesn't grant resistance against this damage.",
			"",
			"",
			"",
			""));
}
