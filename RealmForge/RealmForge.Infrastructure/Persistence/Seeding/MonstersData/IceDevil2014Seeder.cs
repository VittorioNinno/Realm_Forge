using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ice Devil (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class IceDevil2014Seeder
{
	public static Monster Build() => Create("ice-devil", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Fiend,
		18, 180, "19d10 + 76", 40, new[] { 21, 14, 18, 18, 15, 18 }, 14m, 11500, 5, 12,
		new Text(
			"Diavolo del ghiaccio",
			null,
			"Immondo Grande (diavolo), legale malvagio",
			"18 (armatura naturale)",
			"12 m",
			"Car +9, Cos +9, Des +7, Sag +7",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici non argentati",
			"freddo, fuoco, veleno",
			"avvelenato",
			"Percezione passiva 12, scurovisione 36 m, vista cieca 18 m",
			"Infernale, telepatia 36 m",
			"***Resistenza alla magia.*** Il diavolo dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Vista del diavolo.*** L'oscurità magica non ostacola la scurovisione del diavolo.",
			"***Multiattacco.*** Il diavolo effettua tre attacchi: uno con il morso, uno con gli artigli e uno con la coda.\n\n***Artigli.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d4 + 5) danni taglienti più 10 (3d6) danni da freddo.\n\n***Coda.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni perforanti più 10 (3d6) danni da freddo.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni perforanti più 10 (3d6) danni da freddo.\n\n***Muro di ghiaccio (ricarica 6).*** Il diavolo genera magicamente un muro di ghiaccio opaco su una superficie visibile entro 18 metri. Il muro è spesso 30 centimetri, lungo al massimo 9 metri e alto 3 metri, oppure è una cupola semisferica del diametro massimo di 6 metri. Quando il muro compare, ogni creatura nel suo spazio viene spinta fuori lungo il percorso più breve. La creatura sceglie su quale lato del muro finire, purché non sia incapacitata. La creatura effettua poi un tiro salvezza su Destrezza con CD 17, subendo 35 (10d6) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo. Il muro permane per 1 minuto o finché il diavolo non è incapacitato o non muore. Il muro può essere danneggiato e sfondato; ogni sezione di 3 metri ha CA 5, 30 punti ferita, vulnerabilità ai danni da fuoco e immunità ai danni da acido, da freddo, necrotici, psichici e da veleno. Se una sezione viene distrutta, una cortina di aria gelida rimane nello spazio occupato in precedenza dal muro. Ogni volta che una creatura finisce di muoversi attraverso l'aria gelida in un turno, volontariamente o meno, deve effettuare un tiro salvezza su Costituzione con CD 17, subendo 17 (5d6) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo. L'aria gelida si dissipa quando il resto del muro scompare.",
			"",
			"",
			"",
			""),
		new Text(
			"Ice Devil",
			null,
			"Large fiend (devil), lawful evil",
			"18 (natural armor)",
			"40 ft.",
			"Dex +7, Con +9, Wis +7, Cha +9",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"fire, poison",
			"poisoned",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 12",
			"Infernal, telepathy 120 ft.",
			"***Devil's Sight.*** Magical darkness doesn't impede the devil's darkvision.\n\n***Magic Resistance.*** The devil has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The devil makes three attacks: one with its bite, one with its claws, and one with its tail.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) piercing damage plus 10 (3d6) cold damage.\n\n***Claws.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 10 (2d4 + 5) slashing damage plus 10 (3d6) cold damage.\n\n***Tail.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 12 (2d6 + 5) bludgeoning damage plus 10 (3d6) cold damage.\n\n***Wall of Ice.*** The devil magically forms an opaque wall of ice on a solid surface it can see within 60 feet of it. The wall is 1 foot thick and up to 30 feet long and 10 feet high, or it's a hemispherical dome up to 20 feet in diameter.\n\nWhen the wall appears, each creature in its space is pushed out of it by the shortest route. The creature chooses which side of the wall to end up on, unless the creature is incapacitated. The creature then makes a DC 17 Dexterity saving throw, taking 35 (10d6) cold damage on a failed save, or half as much damage on a successful one.\nThe wall lasts for 1 minute or until the devil is incapacitated or dies. The wall can be damaged and breached; each 10-foot section has AC 5, 30 hit points, vulnerability to fire damage, and immunity to acid, cold, necrotic, poison, and psychic damage. If a section is destroyed, it leaves behind a sheet of frigid air in the space the wall occupied. Whenever a creature finishes moving through the frigid air on a turn, willingly or otherwise, the creature must make a DC 17 Constitution saving throw, taking 17 (5d6) cold damage on a failed save, or half as much damage on a successful one. The frigid air dissipates when the rest of the wall vanishes.",
			"",
			"",
			"",
			""));
}
