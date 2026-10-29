using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rug of Smothering (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class RugOfSmothering2014Seeder
{
	public static Monster Build() => Create("rug-of-smothering", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Construct,
		12, 33, "6d10", 10, new[] { 17, 14, 10, 1, 3, 1 }, 2m, 450, 2, 6,
		new Text(
			"Tappeto soffocante",
			null,
			"Costrutto Grande, senza allineamento",
			"12",
			"3 m",
			"",
			"",
			"",
			"",
			"psichici, veleno",
			"accecato, affascinato, assordato, avvelenato, paralizzato, pietrificato, spaventato",
			"Percezione passiva 6, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Falso aspetto.*** Finché il tappeto rimane immobile, non è distinguibile da un tappeto normale.\n\n***Suscettibilità all'anti-magia.*** Il tappeto è incapacitato finché si trova nell'area di un *campo anti-magia.* Se bersagliato da un incantesimo *dissolvi magie,* il tappeto deve superare un tiro salvezza su Costituzione contro la CD del tiro salvezza sull'incantesimo di chi lo lancia, altrimenti è privo di sensi per 1 minuto.\n\n***Trasferire danni.*** Mentre lotta con una creatura, il tappeto subisce solo metà dei danni che gli vengono inflitti e la creatura con cui lotta subisce l'altra metà.",
			"***Soffocare.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura di taglia Media o inferiore. *Colpito:* la creatura è afferrata (CD 13 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto, accecato e rischia di soffocare, ma il tappeto non può soffocare un altro bersaglio. Inoltre, all'inizio di ogni suo turno, il bersaglio subisce 10 (2d6 + 3) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Rug of Smothering",
			null,
			"Large construct, unaligned",
			"12",
			"10 ft.",
			"",
			"",
			"",
			"",
			"poison, psychic",
			"blinded, charmed, blinded, frightened, paralyzed, petrified, poisoned",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 6",
			"—",
			"***Antimagic Susceptibility.*** The rug is incapacitated while in the area of an antimagic field. If targeted by dispel magic, the rug must succeed on a Constitution saving throw against the caster's spell save DC or fall unconscious for 1 minute.\n\n***Damage Transfer.*** While it is grappling a creature, the rug takes only half the damage dealt to it, and the creature grappled by the rug takes the other half.\n\n***False Appearance.*** While the rug remains motionless, it is indistinguishable from a normal rug.",
			"***Smother.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one Medium or smaller creature. *Hit:* The creature is grappled (escape DC 13). Until this grapple ends, the target is restrained, blinded, and at risk of suffocating, and the rug can't smother another target. In addition, at the start of each of the target's turns, the target takes 10 (2d6 + 3) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
