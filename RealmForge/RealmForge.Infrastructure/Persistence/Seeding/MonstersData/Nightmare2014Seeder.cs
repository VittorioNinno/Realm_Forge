using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Nightmare (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Nightmare2014Seeder
{
	public static Monster Build() => Create("nightmare", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Fiend,
		13, 68, "8d10 + 24", 60, new[] { 18, 15, 16, 10, 13, 15 }, 3m, 700, 2, 11,
		new Text(
			"Cavallo degli incubi",
			null,
			"Immondo Grande, neutrale malvagio",
			"13 (armatura naturale)",
			"18 m, volare 27 m",
			"",
			"",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 11",
			"capisce Abissale, Comune e Infernale ma non li parla",
			"***Conferire resistenza al fuoco.*** Il cavallo degli incubi può conferire resistenza ai danni da fuoco a chiunque lo cavalchi.\n\n***Illuminazione.*** Il cavallo degli incubi emana luce intensa in un raggio di 3 metri e luce fioca per ulteriori 3 metri.",
			"***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti più 7 (2d6) danni da fuoco.\n\n***Passo etereo.*** Il cavallo degli incubi e un massimo di tre creature consenzienti situate entro 1,5 metri da esso passano magicamente dal Piano Materiale al Piano Etereo o viceversa.",
			"",
			"",
			"",
			""),
		new Text(
			"Nightmare",
			null,
			"Large fiend, neutral evil",
			"13 (natural armor)",
			"60 ft., fly 90 ft.",
			"",
			"",
			"",
			"",
			"fire",
			"",
			"passive Perception 11",
			"understands Abyssal, Common, and Infernal but can't speak",
			"***Confer Fire Resistance.*** The nightmare can grant resistance to fire damage to anyone riding it.\n\n***Illumination.*** The nightmare sheds bright light in a 10-foot radius and dim light for an additional 10 feet.",
			"***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage plus 7 (2d6) fire damage.\n\n***Ethereal Stride.*** The nightmare and up to three willing creatures within 5 feet of it magically enter the Ethereal Plane from the Material Plane, or vice versa.",
			"",
			"",
			"",
			""));
}
