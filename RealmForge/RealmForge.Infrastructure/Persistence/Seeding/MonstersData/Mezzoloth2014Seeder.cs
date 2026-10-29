using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mezzoloth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Mezzoloth2014Seeder
{
	public static Monster Build() => Create("mezzoloth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		18, 75, "10d8 + 30", 40, new[] { 18, 11, 16, 7, 10, 11 }, 5m, 1800, 3, 13,
		new Text(
			"Mezzoloth",
			null,
			"Immondo Medio (yugoloth), neutrale malvagio",
			"18 (armatura naturale)",
			"12 m",
			"",
			"Percezione +3",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da armi non magiche",
			"acido, veleno",
			"avvelenato",
			"Percezione passiva 13, scurovisione 18 m, vista cieca 18 m",
			"Abissale, Infernale, telepatia 18 m",
			"***Incantesimi innati.*** Il mezzoloth lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 11), senza bisogno di componenti materiali:\n\n- 2/giorno ciascuno: *oscurità*, *dissolvi magie*\n- 1/giorno: *nube mortale*\n\n***Resistenza alla magia.*** Il mezzoloth dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma del mezzoloth sono considerati magici.",
			"***Multiattacco.*** Il mezzoloth effettua due attacchi: uno con gli artigli e uno con il tridente.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d4 + 4) danni taglienti.\n\n***Tridente.*** *Attacco con arma da mischia o a distanza:* +7 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti, o 8 (1d8 + 4) danni perforanti in mischia se impugnato con due artigli.\n\n***Teletrasporto.*** Il mezzoloth si teletrasporta magicamente fino a 18 metri in uno spazio libero che è in grado di vedere, insieme a ciò che indossa o trasporta.",
			"",
			"",
			"",
			"I mezzoloth sono i soldati semplici, dall'aspetto di insetti, delle schiere mercenarie degli yugoloth."),
		new Text(
			"Mezzoloth",
			null,
			"Medium fiend (yugoloth), neutral evil",
			"18 (natural armor)",
			"40 ft.",
			"",
			"Perception +3",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"acid, poison",
			"poisoned",
			"blindsight 60 ft., darkvision 60 ft., passive Perception 13",
			"Abyssal, Infernal, telepathy 60 ft.",
			"***Innate Spellcasting.*** The mezzoloth casts the following spells innately, using Charisma (spell save DC 11) and needing no material components:\n\n- 2/day each: *darkness*, *dispel magic*\n- 1/day: *cloudkill*\n\n***Magic Resistance.*** The mezzoloth has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The mezzoloth's weapon attacks count as magical.",
			"***Multiattack.*** The mezzoloth makes two attacks: one with its claws and one with its trident.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (2d4 + 4) slashing damage.\n\n***Trident.*** *Melee or Ranged Weapon Attack:* +7 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage, or 8 (1d8 + 4) piercing damage in melee when held with two claws.\n\n***Teleport.*** The mezzoloth magically teleports up to 60 feet to an unoccupied space it can see, together with whatever it is wearing or carrying.",
			"",
			"",
			"",
			"Mezzoloths are the insect-like foot soldiers of the yugoloth mercenary hosts."));
}
