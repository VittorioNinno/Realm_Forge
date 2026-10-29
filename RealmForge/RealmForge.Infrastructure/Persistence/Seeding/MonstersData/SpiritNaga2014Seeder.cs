using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Spirit Naga (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SpiritNaga2014Seeder
{
	public static Monster Build() => Create("spirit-naga", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		15, 75, "10d10 + 20", 40, new[] { 18, 17, 14, 16, 15, 16 }, 8m, 3900, 3, 12,
		new Text(
			"Naga spirituale",
			null,
			"Mostruosità Grande, caotica malvagia",
			"15 (armatura naturale)",
			"12 m",
			"Car +6, Cos +5, Des +6, Sag +5",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato",
			"Percezione passiva 12, scurovisione 18 m",
			"Abissale, Comune",
			"***Incantesimi.*** La naga è un incantatore di 10° livello: la sua caratteristica da incantatore è Intelligenza (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo) e necessita solo di componenti verbali per lanciare i suoi incantesimi. Ha a disposizione gli incantesimi da mago seguenti:\n\n- Trucchetti (a volontà): *illusione minore, mano magica, raggio di gelo*\n- 1° livello (4 slot): *charme su persone, individuazione del magico, sonno*\n- 2° livello (3 slot): *blocca persone, individuazione dei pensieri*\n- 3° livello (3 slot): *fulmine, respirare sott'acqua*\n- 4° livello (3 slot): *inaridire, porta dimensionale*\n- 5° livello (2 slot): *dominare persone*\n\n***Rigenerazione.*** Se la naga muore, torna in vita 1d6 giorni dopo e recupera tutti i suoi punti ferita. Solo un incantesimo *desiderio* può impedire a questo tratto di funzionare.",
			"***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 7 (1d6 + 4) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 13, subendo 31 (7d8) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Spirit Naga",
			null,
			"Large monstrosity, chaotic evil",
			"15 (natural armor)",
			"40 ft.",
			"Dex +6, Con +5, Wis +5, Cha +6",
			"",
			"",
			"",
			"poison",
			"charmed, poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Abyssal, Common",
			"***Rejuvenation.*** If it dies, the naga returns to life in 1d6 days and regains all its hit points. Only a wish spell can prevent this trait from functioning.\n\n***Spellcasting.*** The naga is a 10th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 14, +6 to hit with spell attacks), and it needs only verbal components to cast its spells. It has the following wizard spells prepared:\n\n- Cantrips (at will): *mage hand, minor illusion, ray of frost*\n- 1st level (4 slots): *charm person, detect magic, sleep*\n- 2nd level (3 slots): *detect thoughts, hold person*\n- 3rd level (3 slots): *lightning bolt, water breathing*\n- 4th level (3 slots): *blight, dimension door*\n- 5th level (2 slots): *dominate person*",
			"***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one creature. *Hit:* 7 (1d6 + 4) piercing damage, and the target must make a DC 13 Constitution saving throw, taking 31 (7d8) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
