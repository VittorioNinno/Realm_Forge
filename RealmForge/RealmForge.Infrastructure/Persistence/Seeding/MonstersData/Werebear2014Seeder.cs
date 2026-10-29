using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Werebear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Werebear2014Seeder
{
	public static Monster Build() => Create("werebear", null, CreatureSize.Medium, CreatureType.Humanoid,
		10, 135, "18d8 + 54", 30, new[] { 19, 10, 17, 11, 12, 12 }, 5m, 1800, 3, 17,
		new Text(
			"Orso mannaro",
			null,
			"Umanoide Medio (umano, mutaforma), neutrale buono",
			"10 in forma umanoide, 11 (armatura naturale) in forma di orso e ibrida",
			"9 m (12 m, scalare 9 m in forma di orso o ibrida)",
			"",
			"Percezione +7",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 17",
			"Comune (non può parlare in forma di orso)",
			"***Mutaforma.*** L'orso mannaro può usare la sua azione per trasformarsi in un ibrido umanoide-orso o in un orso Grande, o per tornare alla sua forma naturale, che è umanoide. Le sue statistiche, a eccezione della taglia e della CA, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Olfatto acuto.*** L'orso mannaro dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** In forma di orso, l'orso mannaro effettua due attacchi con gli artigli. In forma umanoide, effettua due attacchi con l'ascia bipenne. In forma ibrida, può attaccare come orso o come umanoide.\n\n***Artiglio (solo in forma di orso o ibrida).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.\n\n***Ascia bipenne (solo in forma umanoide o ibrida).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (1d12 + 4) danni taglienti.\n\n***Morso (solo in forma di orso o ibrida).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti. Se il bersaglio è un umanoide, deve superare un tiro salvezza su Costituzione con CD 14, altrimenti è costretto a trasformarsi in un orso mannaro.",
			"",
			""),
		new Text(
			"Werebear",
			null,
			"Medium humanoid (human), neutral good",
			"10 in humanoid form, 11 (natural armor) in bear and hybrid form",
			"30 ft. (40 ft., climb 30 ft. in bear or hybrid form)",
			"",
			"Perception +7",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"passive Perception 17",
			"Common (can't speak in bear form)",
			"***Shapechanger.*** The werebear can use its action to polymorph into a Large bear-humanoid hybrid or into a Large bear, or back into its true form, which is humanoid. Its statistics, other than its size and AC, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Keen Smell.*** The werebear has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** In bear form, the werebear makes two claw attacks. In humanoid form, it makes two greataxe attacks. In hybrid form, it can attack like a bear or a humanoid.\n\n***Greataxe (Humanoid or Hybrid Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 10 (1d12 + 4) slashing damage.\n\n***Bite (Bear or Hybrid Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage. If the target is a humanoid, it must succeed on a DC 14 Constitution saving throw or be cursed with werebear lycanthropy.\n\n***Claw (Bear or Hybrid Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.",
			"",
			""));
}
