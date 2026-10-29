using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quaggoth Thonot (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class QuaggothThonot2014Seeder
{
	public static Monster Build() => Create("quaggoth-thonot", "quaggoth", ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 45, "6d8 + 18", 30, new[] { 17, 12, 16, 6, 12, 7 }, 3m, 700, 2, 11,
		new Text(
			"Quaggoth thonot",
			null,
			"Umanoide Medio (quaggoth), caotico neutrale",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Atletica +5",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Sottocomune",
			"***Furia ferita.*** Finché ha 10 punti ferita o meno, il quaggoth dispone di vantaggio ai tiri per colpire e infligge 7 (2d6) danni extra con ogni colpo in mischia.\n\n***Incantesimi innati (psionici).*** Il quaggoth lancia per natura gli incantesimi seguenti usando la Saggezza (CD del tiro salvezza sull'incantesimo 11), senza bisogno di componenti:\n\n- A volontà: *caduta morbida*, *mano magica* (la mano è invisibile)\n- 1/giorno ciascuno: *cura ferite*, *ingrandire/ridurre*, *riscaldare il metallo*, *immagine speculare*",
			"***Multiattacco.*** Il quaggoth effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.",
			"",
			"",
			"",
			"Un thonot è un quaggoth nato con doti psioniche; la tribù ne fa il suo sciamano e il custode delle sue tradizioni."),
		new Text(
			"Quaggoth Thonot",
			null,
			"Medium humanoid (quaggoth), chaotic neutral",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Athletics +5",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Undercommon",
			"***Wounded Fury.*** While it has 10 hit points or fewer, the quaggoth has advantage on attack rolls and deals an extra 7 (2d6) damage with each melee hit.\n\n***Innate Spellcasting (Psionics).*** The quaggoth casts the following spells innately, using Wisdom (spell save DC 11) and needing no components:\n\n- At will: *feather fall*, *mage hand* (the hand is invisible)\n- 1/day each: *cure wounds*, *enlarge/reduce*, *heat metal*, *mirror image*",
			"***Multiattack.*** The quaggoth makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.",
			"",
			"",
			"",
			"A thonot is a quaggoth born with psionic gifts; the tribe makes it its shaman and lore keeper."));
}
