using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Tentacle Rod (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class TentacleRod2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("tentacle-rod", null, 0, MagicItemType.Rod, ItemRarity.Rare, true, ContentSource.RealmForge,
			null,
			("Verga tentacolare", "Verga, rara (richiede sintonia)",
			"Creata dai drow, questa verga è un'arma magica che termina con tre tentacoli gommosi. Mentre la impugna, il personaggio può usare un'azione per far attaccare a ogni tentacolo una creatura che è in grado di vedere entro 4,5 metri da lui. Ogni tentacolo effettua un tiro per colpire in mischia con bonus di +9 e, se colpisce, infligge 1d6 danni contundenti.\n\nSe tutti e tre i tentacoli colpiscono lo stesso bersaglio, questo deve effettuare un tiro salvezza su Costituzione con CD 15. Se lo fallisce, per 1 minuto la sua velocità è dimezzata, subisce svantaggio ai tiri salvezza su Destrezza, non può usare reazioni e in ogni suo turno può effettuare un'azione o un'azione bonus, ma non entrambe. Alla fine di ogni suo turno può ripetere il tiro salvezza, terminando l'effetto se lo supera."),
			("Tentacle Rod", "Rod, rare (requires attunement)",
			"Made by the drow, this rod is a magic weapon ending in three rubbery tentacles. While holding it, you can use an action to have each tentacle attack a creature you can see within 15 feet of you. Each tentacle makes a melee attack roll with a +9 bonus and deals 1d6 bludgeoning damage on a hit.\n\nIf all three tentacles hit the same target, it must make a DC 15 Constitution saving throw. On a failure, for 1 minute its speed is halved, it has disadvantage on Dexterity saving throws, it can't take reactions, and on each of its turns it can take either an action or a bonus action, not both. It repeats the save at the end of each of its turns, ending the effect on a success.", null));
	}
}
