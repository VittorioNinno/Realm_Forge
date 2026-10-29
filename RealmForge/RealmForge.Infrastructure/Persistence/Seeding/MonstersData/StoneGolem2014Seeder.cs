using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Stone Golem (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class StoneGolem2014Seeder
{
	public static Monster Build() => Create("stone-golem", null, CreatureSize.Large, CreatureType.Construct,
		17, 178, "17d10 + 85", 30, new[] { 22, 9, 20, 3, 11, 1 }, 10m, 5900, 4, 10,
		new Text(
			"Golem di pietra",
			null,
			"Costrutto Grande, senza allineamento",
			"17 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"psichici, veleno; contundenti, perforanti e taglienti da attacchi non magici non adamantini",
			"affascinato, avvelenato, indebolimento, paralizzato, pietrificato, spaventato",
			"Percezione passiva 10, scurovisione 36 m",
			"comprende i linguaggi del suo creatore ma non li sa parlare",
			"***Armi magiche.*** Gli attacchi con arma del golem sono magici.\n\n***Forma immutabile.*** Il golem è immune a qualsiasi incantesimo o effetto che ne altererebbe la forma.\n\n***Resistenza alla magia.*** Il golem dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il golem effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 19 (3d8 + 6) danni contundenti.\n\n***Lentezza (ricarica 5–6).*** Il golem prende di mira una o più creature visibili entro 3 metri da lui. Ogni bersaglio deve effettuare un tiro salvezza su Saggezza con CD 17 contro questa magia; se lo fallisce, non può usare reazioni, la sua velocità è dimezzata e non può effettuare più di un attacco nel suo turno. Inoltre, nel suo turno il bersaglio può effettuare un'azione o un'azione bonus, ma non entrambe. Questi effetti durano 1 minuto. Un bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Stone Golem",
			null,
			"Large construct, unaligned",
			"17 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"poison, psychic; bludgeoning, piercing, and slashing from nonmagical weapons that aren't adamantine",
			"charmed, exhaustion, frightened, paralyzed, petrified, poisoned",
			"darkvision 120 ft., passive Perception 10",
			"understands the languages of its creator but can't speak",
			"***Immutable Form.*** The golem is immune to any spell or effect that would alter its form.\n\n***Magic Resistance.*** The golem has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The golem's weapon attacks are magical.",
			"***Multiattack.*** The golem makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 19 (3d8 + 6) bludgeoning damage.\n\n***Slow (Recharge 5–6).*** The golem targets one or more creatures it can see within 10 ft. of it. Each target must make a DC 17 Wisdom saving throw against this magic. On a failed save, a target can't use reactions, its speed is halved, and it can't make more than one attack on its turn. In addition, the target can take either an action or a bonus action on its turn, not both. These effects last for 1 minute. A target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
