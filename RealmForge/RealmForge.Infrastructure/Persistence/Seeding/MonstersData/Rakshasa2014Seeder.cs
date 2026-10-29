using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rakshasa (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Rakshasa2014Seeder
{
	public static Monster Build() => Create("rakshasa", null, CreatureSize.Medium, CreatureType.Fiend,
		16, 110, "13d8 + 52", 40, new[] { 14, 17, 18, 13, 16, 20 }, 13m, 10000, 5, 13,
		new Text(
			"Rakshasa",
			null,
			"Immondo Medio, legale malvagio",
			"16 (armatura naturale)",
			"12 m",
			"",
			"Inganno +10, Intuizione +8",
			"perforanti da armi magiche impugnate da creature buone",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"Comune, Infernale",
			"***Immunità alla magia limitata.*** Il rakshasa non può essere influenzato o individuato dagli incantesimi di\n\n- 6° livello o inferiori se non lo desidera. Dispone di vantaggio ai tiri salvezza contro tutti gli altri incantesimi ed effetti magici.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore del rakshasa è Carisma (CD del tiro salvezza sull'incantesimo 18, +10 al tiro per colpire con attacco con incantesimo). Per sua natura, il rakshasa è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *camuffare se stesso, illusione minore, individuazione dei pensieri, mano magica*\n- 3/giorno ciascuno: *charme su persone, immagine maggiore, individuazione del magico, invisibilità, suggestione*\n- 1/giorno ciascuno: *dominare persone, spostamento planare, visione del vero, volare*",
			"***Multiattacco.*** Il rakshasa effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni taglienti e il bersaglio è maledetto se è una creatura. La maledizione magica ha effetto ogni volta che il bersaglio inizia un riposo breve o lungo, e provoca immagini e incubi orribili nella mente della vittima. Il bersaglio maledetto non ottiene alcun beneficio quando completa un riposo breve o lungo. La maledizione permane finché non viene rimossa da un incantesimo *rimuovi maledizione* o da una magia analoga.",
			"",
			""),
		new Text(
			"Rakshasa",
			null,
			"Medium fiend, lawful evil",
			"16 (natural armor)",
			"40 ft.",
			"",
			"Deception +10, Insight +8",
			"piercing from magic weapons wielded by good creatures",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"darkvision 60 ft., passive Perception 13",
			"Common, Infernal",
			"***Limited Magic Immunity.*** The rakshasa can't be affected or detected by spells of 6th level or lower unless it wishes to be. It has advantage on saving throws against all other spells and magical effects.\n\n***Innate Spellcasting.*** The rakshasa's innate spellcasting ability is Charisma (spell save DC 18, +10 to hit with spell attacks). The rakshasa can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect thoughts, disguise self, mage hand, minor illusion*\n- 3/day each: *charm person, detect magic, invisibility, major image, suggestion*\n- 1/day each: *dominate person, fly, plane shift, true seeing*",
			"***Multiattack.*** The rakshasa makes two claw attacks\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (2d6 + 2) slashing damage, and the target is cursed if it is a creature. The magical curse takes effect whenever the target takes a short or long rest, filling the target's thoughts with horrible images and dreams. The cursed target gains no benefit from finishing a short or long rest. The curse lasts until it is lifted by a remove curse spell or similar magic.",
			"",
			""));
}
