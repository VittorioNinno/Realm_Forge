using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Vrock (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Vrock2014Seeder
{
	public static Monster Build() => Create("vrock", null, CreatureSize.Large, CreatureType.Fiend,
		15, 104, "11d10 + 44", 40, new[] { 17, 15, 18, 8, 13, 8 }, 6m, 2300, 3, 11,
		new Text(
			"Vrock",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"15 (armatura naturale)",
			"12 m, volare 18 m",
			"Car +2, Des +5, Sag +4",
			"",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Abissale, telepatia 36 m",
			"***Resistenza alla magia.*** Il vrock dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il vrock effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d10 + 3) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti.\n\n***Spore (ricarica 6).*** Il vrock diffonde una nube di spore tossiche in un raggio di 4,5 metri. Le spore si diffondono nell'ambiente. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 14, altrimenti viene avvelenata. Finché è avvelenato in questo modo, il bersaglio subisce 5 (1d10) danni da veleno all'inizio di ogni suo turno, ma può ripetere il tiro salvezza alla fine di ogni turno e, se lo supera, l'effetto svanisce. Anche svuotando una fiala d'acqua santa sul bersaglio si pone termine all'effetto su di lui.\n\n***Stridio stordente (1/giorno).*** Il vrock emette un orrendo stridio. Ogni creatura situata entro 6 metri da esso che sia in grado di udirlo e che non sia un demone deve superare un tiro salvezza su Costituzione con CD 14, altrimenti è stordita fino alla fine del turno successivo del vrock.",
			"",
			""),
		new Text(
			"Vrock",
			null,
			"Large fiend (demon), chaotic evil",
			"15 (natural armor)",
			"40 ft., fly 60 ft.",
			"Dex +5, Wis +4, Cha +2",
			"",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Abyssal, telepathy 120 ft.",
			"***Magic Resistance.*** The vrock has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The vrock makes two attacks: one with its beak and one with its talons.\n\n***Beak.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage.\n\n***Talons.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 14 (2d10 + 3) slashing damage.\n\n***Spores (Recharge 6).*** A 15-foot-radius cloud of toxic spores extends out from the vrock. The spores spread around corners. Each creature in that area must succeed on a DC 14 Constitution saving throw or become poisoned. While poisoned in this way, a target takes 5 (1d10) poison damage at the start of each of its turns. A target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. Emptying a vial of holy water on the target also ends the effect on it.\n\n***Stunning Screech (1/Day).*** The vrock emits a horrific screech. Each creature within 20 feet of it that can hear it and that isn't a demon must succeed on a DC 14 Constitution saving throw or be stunned until the end of the vrock's next turn .",
			"",
			""));
}
