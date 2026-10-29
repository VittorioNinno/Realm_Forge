using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wereboar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wereboar2014Seeder
{
	public static Monster Build() => Create("wereboar", null, CreatureSize.Medium, CreatureType.Humanoid,
		10, 78, "12d8 + 24", 30, new[] { 17, 10, 15, 10, 11, 8 }, 4m, 1100, 2, 12,
		new Text(
			"Cinghiale mannaro",
			null,
			"Umanoide Medio (umano, mutaforma), neutrale malvagio",
			"10 in forma umanoide, 11 (armatura naturale) in forma di cinghiale o ibrida",
			"9 m (12 m in forma di cinghiale)",
			"",
			"Percezione +2",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 12",
			"Comune (non può parlare in forma di cinghiale)",
			"***Mutaforma.*** Il cinghiale mannaro può usare la sua azione per trasformarsi in un ibrido umanoide-cinghiale o in un cinghiale, o per tornare alla sua forma naturale, che è umanoide. Le sue statistiche, a eccezione della CA, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Carica (solo in forma di cinghiale o ibrida).*** Se il cinghiale mannaro si muove di almeno 4,5 metri in linea retta verso un bersaglio e poi lo colpisce con le zanne nello stesso turno, il bersaglio subisce 7 (2d6) danni taglienti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.\n\n***Implacabile (ricarica dopo un riposo breve o lungo).*** Se il cinghiale mannaro subisce 14 o meno danni che lo porterebbero a 0 punti ferita, è ridotto invece a 1 punto ferita.",
			"***Multiattacco (solo in forma umanoide o ibrida).*** Il cinghiale mannaro effettua due attacchi, di cui solo uno può essere con le zanne.\n\n***Dilaniare (solo in forma umanoide o ibrida).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni contundenti.\n\n***Zanne (solo in forma di cinghiale o ibrida).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti. Se il bersaglio è un umanoide, deve superare un tiro salvezza su Costituzione con CD 12, altrimenti è costretto a trasformarsi in un cinghiale mannaro.",
			"",
			""),
		new Text(
			"Wereboar",
			null,
			"Medium humanoid (human), neutral evil",
			"10 in humanoid form, 11 (natural armor) in boar or hybrid form",
			"30 ft. (40 ft. in boar form)",
			"",
			"Perception +2",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"passive Perception 12",
			"Common (can't speak in boar form)",
			"***Shapechanger.*** The wereboar can use its action to polymorph into a boar-humanoid hybrid or into a boar, or back into its true form, which is humanoid. Its statistics, other than its AC, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Relentless (Recharges after a Short or Long Rest).*** If the wereboar takes 14 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.\n\n***Charge (Boar or Hybrid Form Only).*** If the wereboar moves at least 15 feet straight toward a target and then hits it with its tusks on the same turn, the target takes an extra 7 (2d6) slashing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.",
			"***Multiattack (Humanoid or Hybrid Form Only).*** The wereboar makes two attacks, only one of which can be with its tusks.\n\n***Maul (Humanoid or Hybrid Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) bludgeoning damage.\n\n***Tusks (Boar or Hybrid Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage. If the target is a humanoid, it must succeed on a DC 12 Constitution saving throw or be cursed with wereboar lycanthropy.",
			"",
			""));
}
