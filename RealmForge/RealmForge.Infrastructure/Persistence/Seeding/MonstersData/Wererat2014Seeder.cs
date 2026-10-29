using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wererat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wererat2014Seeder
{
	public static Monster Build() => Create("wererat", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 33, "6d8 + 6", 30, new[] { 10, 15, 12, 11, 10, 8 }, 2m, 450, 2, 12,
		new Text(
			"Topo mannaro",
			null,
			"Umanoide Medio (umano, mutaforma), legale malvagio",
			"12",
			"9 m",
			"",
			"Furtività +4, Percezione +2",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 12, scurovisione 18 m (solo in forma di topo)",
			"Comune (non può parlare in forma di topo)",
			"***Mutaforma.*** Il topo mannaro può usare la sua azione per trasformarsi in un ibrido umanoide-topo o in un topo gigante, o per tornare alla sua forma naturale, che è umanoide. Le sue statistiche, a eccezione della taglia, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Olfatto acuto.*** Il topo mannaro dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco (solo in forma umanoide o ibrida).*** Il topo mannaro effettua due attacchi, di cui solo uno può essere un morso.\n\n***Morso (Solo in forma di topo o ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti. Se il bersaglio è un umanoide, deve superare un tiro salvezza su Costituzione con CD 11, altrimenti è costretto a trasformarsi in un topo mannaro.\n\n***Spada corta (solo in forma umanoide o ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Balestra a mano (solo in forma umanoide o ibrida).*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Wererat",
			null,
			"Medium humanoid (human), lawful evil",
			"12",
			"30 ft.",
			"",
			"Perception +2, Stealth +4",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"darkvision 60 ft. (rat form only), passive Perception 12",
			"Common (can't speak in rat form)",
			"***Shapechanger.*** The wererat can use its action to polymorph into a rat-humanoid hybrid or into a giant rat, or back into its true form, which is humanoid. Its statistics, other than its size, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Keen Smell.*** The wererat has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack (Humanoid or Hybrid Form Only).*** The wererat makes two attacks, only one of which can be a bite.\n\n***Shortsword (Humanoid or Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Hand Crossbow (Humanoid or Hybrid Form Only).*** *Ranged Weapon Attack:* +4 to hit, range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Bite (Rat or Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage. If the target is a humanoid, it must succeed on a DC 11 Constitution saving throw or be cursed with wererat lycanthropy.",
			"",
			""));
}
