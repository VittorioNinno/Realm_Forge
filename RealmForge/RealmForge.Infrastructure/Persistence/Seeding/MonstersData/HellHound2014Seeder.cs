using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hell Hound (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class HellHound2014Seeder
{
	public static Monster Build() => Create("hell-hound", null, CreatureSize.Medium, CreatureType.Fiend,
		15, 45, "7d8 + 14", 50, new[] { 17, 12, 14, 6, 13, 6 }, 3m, 700, 2, 15,
		new Text(
			"Segugio infernale",
			null,
			"Immondo Medio, legale malvagio",
			"15 (armatura naturale)",
			"15 m",
			"",
			"Percezione +5",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 15, scurovisione 18 m",
			"capisce l'Infernale ma non lo parla",
			"***Tattiche del branco.*** Il segugio dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del segugio si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Udito e olfatto acuti.*** Il segugio dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti più 7 (2d6) danni da fuoco.\n\n***Soffio di fuoco (ricarica 5–6).*** Il segugio esala fuoco in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 12, subendo 21 (6d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Hell Hound",
			null,
			"Medium fiend, lawful evil",
			"15 (natural armor)",
			"50 ft.",
			"",
			"Perception +5",
			"",
			"",
			"fire",
			"",
			"darkvision 60 ft., passive Perception 15",
			"understands Infernal but can't speak it",
			"***Keen Hearing and Smell.*** The hound has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The hound has advantage on an attack roll against a creature if at least one of the hound's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage plus 7 (2d6) fire damage.\n\n***Fire Breath (Recharge 5–6).*** The hound exhales fire in a 15-foot cone. Each creature in that area must make a DC 12 Dexterity saving throw, taking 21 (6d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
