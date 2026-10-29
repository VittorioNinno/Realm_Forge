using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Weretiger (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Weretiger2014Seeder
{
	public static Monster Build() => Create("weretiger", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 120, "16d8 + 48", 30, new[] { 17, 15, 16, 10, 13, 11 }, 4m, 1100, 2, 15,
		new Text(
			"Tigre mannara",
			null,
			"Umanoide Medio (umano, mutaforma), neutrale",
			"12",
			"9 m (12 m in forma di tigre)",
			"",
			"Furtività +4, Percezione +5",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 15, scurovisione 18 m",
			"Comune (non può parlare in forma di tigre)",
			"***Mutaforma.*** La tigre mannara può usare la sua azione per trasformarsi in un ibrido umanoide-tigre o in una tigre, o per tornare alla sua forma naturale, che è umanoide. Le sue statistiche, a eccezione della taglia, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Balzo (solo in forma di tigre o ibrida).*** Se la tigre mannara si muove di almeno 4,5 metri in linea retta verso una creatura e poi la colpisce con un attacco con gli artigli nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 14, altrimenti cade a terra prono. Se il bersaglio è prono, la tigre mannara può effettuare un attacco con il morso contro di esso come azione bonus.\n\n***Udito e olfatto acuti.*** La tigre mannara dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Multiattacco (solo in forma umanoide o ibrida).*** In forma umanoide, la tigre mannara effettua due attacchi con la scimitarra o due con l'arco lungo. In forma ibrida, può attaccare come un umanoide o effettuare due attacchi con gli artigli.\n\n***Artiglio (solo in forma di tigre o ibrida).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti.\n\n***Morso (solo in forma di tigre o ibrida).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni perforanti. Se il bersaglio è un umanoide, deve superare un tiro salvezza su Costituzione con CD 13, altrimenti è costretto a trasformarsi in una tigre mannara.\n\n***Scimitarra (solo in forma umanoide o ibrida).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Arco lungo (solo in forma umanoide o ibrida).*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Weretiger",
			null,
			"Medium humanoid (human), neutral",
			"12",
			"30 ft. (40 ft. in tiger form)",
			"",
			"Perception +5, Stealth +4",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"darkvision 60 ft., passive Perception 15",
			"Common (can't speak in tiger form)",
			"***Shapechanger.*** The weretiger can use its action to polymorph into a tiger-humanoid hybrid or into a tiger, or back into its true form, which is humanoid. Its statistics, other than its size, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Keen Hearing and Smell.*** The weretiger has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pounce (Tiger or Hybrid Form Only).*** If the weretiger moves at least 15 feet straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the weretiger can make one bite attack against it as a bonus action.",
			"***Multiattack (Humanoid or Hybrid Form Only).*** In humanoid form, the weretiger makes two scimitar attacks or two longbow attacks. In hybrid form, it can attack like a humanoid or make two claw attacks.\n\n***Scimitar (Humanoid or Hybrid Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Longbow (Humanoid or Hybrid Form Only).*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.\n\n***Bite (Tiger or Hybrid Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (1d10 + 3) piercing damage. If the target is a humanoid, it must succeed on a DC 13 Constitution saving throw or be cursed with weretiger lycanthropy.\n\n***Claw (Tiger or Hybrid Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage.",
			"",
			""));
}
