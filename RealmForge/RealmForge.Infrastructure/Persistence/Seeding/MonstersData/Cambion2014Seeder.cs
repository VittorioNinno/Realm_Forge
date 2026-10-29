using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cambion (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Cambion2014Seeder
{
	public static Monster Build() => Create("cambion", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		19, 82, "11d8 + 33", 30, new[] { 18, 18, 16, 14, 12, 16 }, 5m, 1800, 3, 14,
		new Text(
			"Cambion",
			null,
			"Immondo Medio, qualsiasi allineamento malvagio",
			"19 (corazza di scaglie)",
			"9 m, volare 18 m",
			"Car +6, Cos +6, For +7, Int +5",
			"Furtività +7, Inganno +6, Intimidire +6, Percezione +4",
			"",
			"freddo, fuoco, fulmine, veleno; contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Abissale, Comune, Infernale",
			"***Benedizione immonda.*** Il cambion somma il suo bonus di Carisma alla sua CA (già incluso).\n\n***Incantesimi innati.*** Il cambion lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 14), senza bisogno di componenti materiali:\n\n- 3/giorno ciascuno: *alterare se stesso*, *comando*, *individuazione del magico*\n- 1/giorno: *spostamento planare* (solo su se stesso)",
			"***Multiattacco.*** Il cambion effettua due attacchi in mischia o usa due volte Raggio di fuoco.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +7 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti, o 8 (1d8 + 4) danni perforanti se impugnata a due mani. In entrambi i casi il colpo infligge anche 3 (1d6) danni da fuoco.\n\n***Raggio di fuoco.*** *Attacco con incantesimo a distanza:* +7 al tiro per colpire, gittata 36 m, un bersaglio. *Colpito:* 10 (3d6) danni da fuoco.\n\n***Fascino immondo.*** Un umanoide che il cambion è in grado di vedere entro 9 metri da lui effettua un tiro salvezza su Saggezza con CD 14, altrimenti è magicamente affascinato per 1 giorno e obbedisce agli ordini verbali del cambion. Ogni volta che il cambion o un'altra creatura gli fa del male, o il cambion gli ordina qualcosa di suicida, ripete il tiro salvezza e l'effetto termina con un successo. Una creatura che lo supera, o per cui l'effetto termina, è immune al Fascino immondo di questo cambion per 24 ore.",
			"",
			"",
			"",
			""),
		new Text(
			"Cambion",
			null,
			"Medium fiend, any evil alignment",
			"19 (scale mail)",
			"30 ft., fly 60 ft.",
			"Str +7, Con +6, Int +5, Cha +6",
			"Deception +6, Intimidation +6, Perception +4, Stealth +7",
			"",
			"cold, fire, lightning, poison; bludgeoning, piercing, and slashing from nonmagical attacks",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Abyssal, Common, Infernal",
			"***Fiendish Blessing.*** The cambion adds its Charisma bonus to its AC (already included).\n\n***Innate Spellcasting.*** The cambion casts the following spells innately, using Charisma (spell save DC 14) and needing no material components:\n\n- 3/day each: *alter self*, *command*, *detect magic*\n- 1/day: *plane shift* (self only)",
			"***Multiattack.*** The cambion makes two melee attacks or uses Fire Ray twice.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +7 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage, or 8 (1d8 + 4) piercing damage if used with two hands. Either way, the hit also deals 3 (1d6) fire damage.\n\n***Fire Ray.*** *Ranged Spell Attack:* +7 to hit, range 120 ft., one target. *Hit:* 10 (3d6) fire damage.\n\n***Fiendish Charm.*** A humanoid the cambion can see within 30 feet of it makes a DC 14 Wisdom saving throw or is magically charmed for 1 day, obeying the cambion's spoken orders. Whenever the cambion or another creature harms it, or the cambion orders it to do something suicidal, it repeats the save, ending the effect on a success. A creature that succeeds, or whose charm ends, is immune to this cambion's Fiendish Charm for 24 hours.",
			"",
			"",
			"",
			""));
}
