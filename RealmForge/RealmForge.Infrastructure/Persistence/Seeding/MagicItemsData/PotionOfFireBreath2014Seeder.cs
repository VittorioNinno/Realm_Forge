using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Fire Breath (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class PotionOfFireBreath2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-fire-breath", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Pozione del soffio di fuoco", "Pozione, non comune",
			"Dopo aver bevuto questa pozione, il personaggio può usare un'azione bonus per soffiare fuoco contro un bersaglio entro 9 metri da lui. Il bersaglio deve effettuare un tiro salvezza su Destrezza con CD 13: se lo fallisce subisce 4d6 danni da fuoco, se lo supera la metà. L'effetto termina dopo tre soffi o dopo 1 ora.\n\nIl liquido arancione della pozione tremola come una fiamma e, ogni volta che il contenitore viene aperto, ne esce del fumo."),
			("Potion of Fire Breath", "Potion, uncommon",
			"After drinking this potion, you can use a bonus action to breathe fire at a target within 30 feet of you. The target makes a DC 13 Dexterity saving throw, taking 4d6 fire damage on a failure or half as much on a success. The effect ends after three breaths or when 1 hour has passed.\n\nThe orange liquid flickers like a flame, and smoke drifts out whenever the container is opened.", null));
	}
}
