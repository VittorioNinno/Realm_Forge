using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Animated Armor (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AnimatedArmor2014Seeder
{
	public static Monster Build() => Create("animated-armor", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Construct,
		18, 33, "6d8 + 6", 25, new[] { 14, 11, 13, 1, 3, 1 }, 1m, 200, 2, 6,
		new Text(
			"Armatura animata",
			null,
			"Costrutto Medio, senza allineamento",
			"18 (armatura naturale)",
			"7,5 m",
			"",
			"",
			"",
			"",
			"psichici, veleno",
			"accecato, affascinato, assordato, avvelenato, indebolimento, paralizzato, pietrificato, spaventato",
			"Percezione passiva 6, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Falso aspetto.*** Finché l'armatura rimane immobile, non è distinguibile da un'armatura normale.\n\n***Suscettibilità all'anti-magia.*** L'armatura è incapacitata finché si trova nell'area di un *campo anti-magia.* Se bersagliata da un incantesimo *dissolvi magie,* l'armatura deve superare un tiro salvezza su Costituzione contro la CD del tiro salvezza sull'incantesimo di chi lo lancia, altrimenti è priva di sensi per 1 minuto.",
			"***Multiattacco.*** L'armatura effettua due attacchi in mischia.\n\n***Schianto.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Animated Armor",
			null,
			"Medium construct, unaligned",
			"18 (natural armor)",
			"25 ft.",
			"",
			"",
			"",
			"",
			"poison, psychic",
			"blinded, charmed, deafened, exhaustion, frightened, paralyzed, petrified, poisoned",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 6",
			"—",
			"***Antimagic Susceptibility.*** The armor is incapacitated while in the area of an antimagic field. If targeted by dispel magic, the armor must succeed on a Constitution saving throw against the caster's spell save DC or fall unconscious for 1 minute.\n\n***False Appearance.*** While the armor remains motionless, it is indistinguishable from a normal suit of armor.",
			"***Multiattack.*** The armor makes two melee attacks.\n\n***Slam.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
