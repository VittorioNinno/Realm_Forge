using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of Rulership (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RodOfRulership2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-rulership", null, 0, MagicItemType.Rod, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Verga della sovranità", "Verga, rara (richiede sintonia)",
			"Il personaggio può usare un'azione per mostrare la verga e costringere all'obbedienza ogni creatura a sua scelta che è in grado di vedere situata entro 36 metri da lui. Ogni bersaglio deve superare un tiro salvezza su Saggezza con CD 15, altrimenti rimane affascinato dal personaggio per 8 ore. Finché è affascinata in questo modo, una creatura considera il personaggio come un capo in cui ha piena fiducia. Se il personaggio o i suoi compagni le fanno del male o se riceve l'ordine di agire in modo contrario alla sua natura, la creatura smette di essere affascinata in questo modo. La verga non può essere riutilizzata fino all'alba successiva."),
			("Rod of Rulership", "Rod, rare (requires attunement)",
			"You can use an action to present the rod and command obedience from each creature of your choice that you can see within 120 feet of you. Each target must succeed on a DC 15 Wisdom saving throw or be charmed by you for 8 hours. While charmed in this way, the creature regards you as its trusted leader. If harmed by you or your companions, or commanded to do something contrary to its nature, a target ceases to be charmed in this way. The rod can't be used again until the next dawn.", null));
	}
}
