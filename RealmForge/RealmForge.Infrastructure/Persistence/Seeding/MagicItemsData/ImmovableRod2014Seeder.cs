using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Immovable Rod (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ImmovableRod2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("immovable-rod", null, 0, MagicItemType.Rod, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Verga inamovibile", "Verga, non comune",
			"Questa verga piatta di ferro è dotata di un tasto su un'estremità. Il personaggio può usare un'azione per premere il tasto e fare in modo che la verga si fissi magicamente nel luogo in cui si trova. Finché una creatura non usa un'azione per premere nuovamente il tasto, la verga non si sposta, sfidando anche la forza di gravità. La verga può sostenere un peso massimo di 4 tonnellate; un peso superiore fa sì che la verga si disattivi e cada. Una creatura può usare un'azione per effettuare una prova di forza con CD 30, spostando la verga per un massimo di 3 metri in caso di successo.", null),
			("Immovable Rod", "Rod, uncommon",
			"This flat iron rod has a button on one end. You can use an action to press the button, which causes the rod to become magically fixed in place. Until you or another creature uses an action to push the button again, the rod doesn't move, even if it is defying gravity. The rod can hold up to 8,000 pounds of weight. More weight causes the rod to deactivate and fall. A creature can use an action to make a DC 30 Strength check, moving the fixed rod up to 10 feet on a success.", null));
	}
}
