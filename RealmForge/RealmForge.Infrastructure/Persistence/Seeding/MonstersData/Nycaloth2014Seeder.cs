using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Nycaloth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Nycaloth2014Seeder
{
	public static Monster Build() => Create("nycaloth", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Fiend,
		18, 123, "13d10 + 52", 40, new[] { 20, 11, 19, 12, 10, 15 }, 9m, 5000, 4, 14,
		new Text(
			"Nycaloth",
			null,
			"Immondo Grande (yugoloth), neutrale malvagio",
			"18 (armatura naturale)",
			"12 m, volare 18 m",
			"",
			"Furtività +4, Intimidire +6, Percezione +4",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da armi non magiche",
			"acido, veleno",
			"avvelenato",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 18 m",
			"Abissale, Infernale, telepatia 18 m",
			"***Incantesimi innati.*** Il nycaloth lancia per natura gli incantesimi seguenti usando il Carisma, senza bisogno di componenti materiali:\n\n- A volontà: *oscurità*, *individuazione del magico*, *dissolvi magie*, *invisibilità* (solo su se stesso), *immagine speculare*\n\n***Resistenza alla magia.*** Il nycaloth dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma del nycaloth sono considerati magici.",
			"***Multiattacco.*** Il nycaloth effettua due attacchi in mischia, oppure un attacco in mischia e si teletrasporta prima o dopo di esso.\n\n***Artiglio.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti. Una creatura colpita effettua un tiro salvezza su Costituzione con CD 16, altrimenti riporta una ferita immonda che le infligge 5 (2d4) danni taglienti all'inizio di ogni suo turno; ogni ulteriore colpo d'artiglio del nycaloth su quella creatura aumenta i danni della ferita di 5 (2d4). La ferita si chiude con qualsiasi guarigione magica, o quando una creatura usa un'azione per tamponarla superando una prova di Saggezza (Medicina) con CD 13.\n\n***Ascia bipenne.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 18 (2d12 + 5) danni taglienti.\n\n***Teletrasporto.*** Il nycaloth si teletrasporta magicamente fino a 18 metri in uno spazio libero che è in grado di vedere, insieme a ciò che indossa o trasporta.",
			"",
			"",
			"",
			"I nycaloth sono le truppe d'élite alate, simili a gargoyle, degli eserciti yugoloth."),
		new Text(
			"Nycaloth",
			null,
			"Large fiend (yugoloth), neutral evil",
			"18 (natural armor)",
			"40 ft., fly 60 ft.",
			"",
			"Intimidation +6, Perception +4, Stealth +4",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"acid, poison",
			"poisoned",
			"blindsight 60 ft., darkvision 60 ft., passive Perception 14",
			"Abyssal, Infernal, telepathy 60 ft.",
			"***Innate Spellcasting.*** The nycaloth casts the following spells innately, using Charisma and needing no material components:\n\n- At will: *darkness*, *detect magic*, *dispel magic*, *invisibility* (self only), *mirror image*\n\n***Magic Resistance.*** The nycaloth has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The nycaloth's weapon attacks count as magical.",
			"***Multiattack.*** The nycaloth makes two melee attacks, or one melee attack and teleports before or after it.\n\n***Claw.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage. A creature hit makes a DC 16 Constitution saving throw or suffers a fiendish wound that deals it 5 (2d4) slashing damage at the start of each of its turns; every further claw hit from the nycaloth on that creature raises the wound's damage by 5 (2d4). The wound closes with any magical healing, or when a creature uses an action to stanch it with a successful DC 13 Wisdom (Medicine) check.\n\n***Greataxe.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 18 (2d12 + 5) slashing damage.\n\n***Teleport.*** The nycaloth magically teleports up to 60 feet to an unoccupied space it can see, together with whatever it is wearing or carrying.",
			"",
			"",
			"",
			"Nycaloths are the winged, gargoyle-like heavy cavalry and elite troops of the yugoloth armies."));
}
