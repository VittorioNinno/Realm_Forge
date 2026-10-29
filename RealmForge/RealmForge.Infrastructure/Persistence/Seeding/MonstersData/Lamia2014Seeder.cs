using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lamia (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lamia2014Seeder
{
	public static Monster Build() => Create("lamia", null, CreatureSize.Large, CreatureType.Monstrosity,
		13, 97, "13d10 + 26", 30, new[] { 16, 13, 15, 14, 15, 16 }, 4m, 1100, 2, 12,
		new Text(
			"Lamia",
			null,
			"Mostruosità Grande, caotico malvagio",
			"13 (armatura naturale)",
			"9 m",
			"",
			"Furtività +3, Inganno +7, Intuizione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m",
			"Abissale, Comune",
			"***Incantesimi innati.*** La caratteristica innata da incantatore del lamia è Carisma (CD del tiro salvezza sull'incantesimo 13). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *camuffare se stesso* (qualsiasi forma umanoide), *immagine maggiore*\n- 3/giorno ciascuno: *charme su persone, immagine speculare, scrutare, suggestione*\n- 1/giorno: *costrizione*",
			"***Multiattacco.*** Il lamia effettua due attacchi: uno con gli artigli e uno con il pugnale o con il tocco intossicante.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d10 + 3) danni taglienti.\n\n***Pugnale.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti.\n\n***Tocco intossicante.*** *Attacco in mischia con incantesimo:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* Il bersaglio è magicamente maledetto per 1 ora. Finché la maledizione non termina, il bersaglio subisce svantaggio ai tiri salvezza su Saggezza e a tutte le prove di caratteristica.",
			"",
			""),
		new Text(
			"Lamia",
			null,
			"Large monstrosity, chaotic evil",
			"13 (natural armor)",
			"30 ft.",
			"",
			"Deception +7, Insight +4, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 12",
			"Abyssal, Common",
			"***Innate Spellcasting.*** The lamia's innate spellcasting ability is Charisma (spell save DC 13). It can innately cast the following spells, requiring no material components. At will: disguise self (any humanoid form), major image 3/day each: charm person, mirror image, scrying, suggestion 1/day: geas",
			"***Multiattack.*** The lamia makes two attacks: one with its claws and one with its dagger or Intoxicating Touch.\n\n***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 14 (2d10 + 3) slashing damage.\n\n***Dagger.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage.\n\n***Intoxicating Touch.*** *Melee Spell Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* The target is magically cursed for 1 hour. Until the curse ends, the target has disadvantage on Wisdom saving throws and all ability checks.",
			"",
			""));
}
