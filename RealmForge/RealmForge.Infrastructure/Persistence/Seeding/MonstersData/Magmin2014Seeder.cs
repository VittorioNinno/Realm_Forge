using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Magmin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Magmin2014Seeder
{
	public static Monster Build() => Create("magmin", null, CreatureSize.Small, CreatureType.Elemental,
		14, 9, "2d6 + 2", 30, new[] { 7, 15, 12, 8, 11, 10 }, 0.5m, 100, 2, 10,
		new Text(
			"Magmin",
			null,
			"Elementale Piccolo, caotico neutrale",
			"14 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"fuoco",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Ignan",
			"***Esplosione della morte.*** Quando il magmin muore, esplode in una deflagrazione di magma e lava. Ogni creatura situata entro 3 metri da lui deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 7 (2d6) danni da fuoco in caso di fallimento, o la metà in caso di successo. Gli oggetti infiammabili non indossati o trasportati che si trovano in quell'area prendono fuoco.\n\n***Illuminazione fiammeggiante.*** Come azione bonus, il magmin può infiammarsi o estinguere le proprie fiamme. Quando si infiamma, proietta luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri.",
			"***Tocco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d6) danni da fuoco. Se il bersaglio è una creatura o un oggetto infiammabile, prende fuoco. Finché una creatura non usa un'azione per estinguere le fiamme, il bersaglio subisce 3 (1d6) danni da fuoco alla fine di ogni suo turno.",
			"",
			""),
		new Text(
			"Magmin",
			null,
			"Small elemental, chaotic neutral",
			"14 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"fire",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Ignan",
			"***Death Burst.*** When the magmin dies, it explodes in a burst of fire and magma. Each creature within 10 ft. of it must make a DC 11 Dexterity saving throw, taking 7 (2d6) fire damage on a failed save, or half as much damage on a successful one. Flammable objects that aren't being worn or carried in that area are ignited.\n\n***Ignited Illumination.*** As a bonus action, the magmin can set itself ablaze or extinguish its flames. While ablaze, the magmin sheds bright light in a 10-foot radius and dim light for an additional 10 ft.",
			"***Touch.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d6) fire damage. If the target is a creature or a flammable object, it ignites. Until a target takes an action to douse the fire, the target takes 3 (1d6) fire damage at the end of each of its turns.",
			"",
			""));
}
