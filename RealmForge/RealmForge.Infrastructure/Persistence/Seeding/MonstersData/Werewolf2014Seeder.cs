using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Werewolf (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Werewolf2014Seeder
{
	public static Monster Build() => Create("werewolf", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		11, 58, "9d8 + 18", 30, new[] { 15, 13, 14, 10, 11, 10 }, 3m, 700, 2, 14,
		new Text(
			"Lupo mannaro",
			null,
			"Umanoide Medio (umano, mutaforma), caotico malvagio",
			"11 in forma umanoide, 12 (armatura naturale) in forma di lupo o ibrida",
			"9 m (12 m in forma di lupo)",
			"",
			"Furtività +3, Percezione +4",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 14",
			"Comune (non può parlare in forma di lupo)",
			"***Mutaforma.*** Il lupo mannaro può usare la sua azione per trasformarsi in un ibrido umanoide-lupo o in un lupo, o per tornare alla sua forma naturale, che è umanoide. Le sue statistiche, a eccezione della CA, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Udito e olfatto acuti.*** Il lupo mannaro dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Multiattacco (solo in forma umanoide o ibrida).*** Il lupo mannaro effettua due attacchi: uno con il morso e uno con gli artigli o la lancia.\n\n***Artigli (solo in forma ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (2d4 + 2) danni taglienti.\n\n***Morso (solo in forma di lupo o ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti. Se il bersaglio è un umanoide, deve superare un tiro salvezza su Costituzione con CD 12, altrimenti è costretto a trasformarsi in un lupo mannaro.\n\n***Lancia (solo in forma umanoide).*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 6/18 m, una creatura. *Colpito:* 5 (1d6 + 2) danni perforanti o 6 (1d8 + 2) danni perforanti se impugnata con due mani per effettuare un attacco in mischia.",
			"",
			"",
			"",
			""),
		new Text(
			"Werewolf",
			null,
			"Medium humanoid (human), chaotic evil",
			"11 in humanoid form, 12 (natural armor) in wolf or hybrid form",
			"30 ft. (40 ft. in wolf form)",
			"",
			"Perception +4, Stealth +3",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"passive Perception 14",
			"Common (can't speak in wolf form)",
			"***Shapechanger.*** The werewolf can use its action to polymorph into a wolf-humanoid hybrid or into a wolf, or back into its true form, which is humanoid. Its statistics, other than its AC, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Keen Hearing and Smell.*** The werewolf has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Multiattack (Humanoid or Hybrid Form Only).*** The werewolf makes two attacks: two with its spear (humanoid form) or one with its bite and one with its claws (hybrid form).\n\n***Spear (Humanoid Form Only).*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 20/60 ft., one creature. *Hit:* 5 (1d6 + 2) piercing damage, or 6 (1d8 + 2) piercing damage if used with two hands to make a melee attack.\n\n***Bite (Wolf or Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage. If the target is a humanoid, it must succeed on a DC 12 Constitution saving throw or be cursed with werewolf lycanthropy.\n\n***Claws (Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 7 (2d4 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
