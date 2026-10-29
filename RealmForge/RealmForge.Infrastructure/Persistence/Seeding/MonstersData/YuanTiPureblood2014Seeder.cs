using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Yuan-ti Pureblood (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class YuanTiPureblood2014Seeder
{
	public static Monster Build() => Create("yuan-ti-pureblood", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		11, 40, "9d8", 30, new[] { 11, 12, 11, 13, 12, 14 }, 1m, 200, 2, 13,
		new Text(
			"Yuan-ti sanguepuro",
			null,
			"Umanoide Medio (yuan-ti), neutrale malvagio",
			"11",
			"9 m",
			"",
			"Furtività +3, Inganno +6, Percezione +3",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 13, scurovisione 18 m",
			"Abissale, Comune, Draconico",
			"***Incantesimi innati.*** Lo yuan-ti lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 12), senza bisogno di componenti materiali:\n\n- A volontà: *amicizia con gli animali* (solo serpenti)\n- 3/giorno ciascuno: *spruzzo velenoso*, *suggestione*\n\n***Resistenza alla magia.*** Lo yuan-ti dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Lo yuan-ti effettua due attacchi in mischia.\n\n***Scimitarra.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni taglienti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti più 7 (2d6) danni da veleno.",
			"",
			"",
			"",
			"I sanguepuro, la casta più bassa degli yuan-ti, sembrano quasi umani; a un esame attento rivelano sempre qualche tratto del serpente, come pelle squamosa, pupille verticali o lingua biforcuta."),
		new Text(
			"Yuan-ti Pureblood",
			null,
			"Medium humanoid (yuan-ti), neutral evil",
			"11",
			"30 ft.",
			"",
			"Deception +6, Perception +3, Stealth +3",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 13",
			"Abyssal, Common, Draconic",
			"***Innate Spellcasting.*** The yuan-ti casts the following spells innately, using Charisma (spell save DC 12) and needing no material components:\n\n- At will: *animal friendship* (snakes only)\n- 3/day each: *poison spray*, *suggestion*\n\n***Magic Resistance.*** The yuan-ti has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The yuan-ti makes two melee attacks.\n\n***Scimitar.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) slashing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +3 to hit, range 80/320 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage plus 7 (2d6) poison damage.",
			"",
			"",
			"",
			"Purebloods, the lowest yuan-ti caste, look almost human; a close look always reveals some trace of the serpent, such as scaly skin, slit pupils or a forked tongue."));
}
