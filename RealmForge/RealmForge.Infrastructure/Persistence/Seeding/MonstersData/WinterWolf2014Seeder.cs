using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Winter Wolf (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class WinterWolf2014Seeder
{
	public static Monster Build() => Create("winter-wolf", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		13, 75, "10d10 + 20", 50, new[] { 18, 13, 14, 7, 12, 8 }, 3m, 700, 2, 15,
		new Text(
			"Lupo invernale",
			null,
			"Mostruosità Grande, neutrale malvagio",
			"13 (armatura naturale)",
			"15 m",
			"",
			"Furtività +3, Percezione +5",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 15",
			"Comune, Gigante, Lupo Invernale",
			"***Mimetismo sulla neve.*** Il lupo dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni innevati.\n\n***Tattiche del branco.*** Il lupo dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Udito e olfatto acuti.*** Il lupo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 14, altrimenti cade a terra prono.\n\n***Soffio di freddo (ricarica 5–6).*** Il lupo esala una folata di vento gelido in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 12, subendo 18 (4d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Winter Wolf",
			null,
			"Large monstrosity, neutral evil",
			"13 (natural armor)",
			"50 ft.",
			"",
			"Perception +5, Stealth +3",
			"",
			"",
			"cold",
			"",
			"passive Perception 15",
			"Common, Giant, Winter Wolf",
			"***Keen Hearing and Smell.*** The wolf has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The wolf has advantage on an attack roll against a creature if at least one of the wolf's allies is within 5 ft. of the creature and the ally isn't incapacitated.\n\n***Snow Camouflage.*** The wolf has advantage on Dexterity (Stealth) checks made to hide in snowy terrain.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be knocked prone.\n\n***Cold Breath (Recharge 5–6).*** The wolf exhales a blast of freezing wind in a 15-foot cone. Each creature in that area must make a DC 12 Dexterity saving throw, taking 18 (4d8) cold damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
