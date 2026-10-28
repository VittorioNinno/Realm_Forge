using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Oil of Etherealness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class OilOfEtherealness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("oil-of-etherealness", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Olio della forma eterea", "Pozione, rara",
			"All'esterno del contenitore di questo torbido olio grigiastro si formano in continuazione delle bolle che evaporano velocemente. L'olio può coprire una creatura di taglia Media o inferiore, nonché ogni oggetto che indossa e trasporta (per ogni categoria di taglia superiore, è necessario usare una fiala aggiuntiva). L'applicazione dell'olio richiede 10 minuti. La creatura cosparsa d'olio ottiene gli effetti dell'incantesimo *forma eterea* per 1 ora.", null),
			("Oil of Etherealness", "Potion, rare",
			"Beads of this cloudy gray oil form on the outside of its container and quickly evaporate. The oil can cover a Medium or smaller creature, along with the equipment it's wearing and carrying (one additional vial is required for each size category above Medium). Applying the oil takes 10 minutes. The affected creature then gains the effect of the etherealness spell for 1 hour.", null));
	}
}
