using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Oil of Slipperiness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class OilOfSlipperiness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("oil-of-slipperiness", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Olio della scivolosità", "Pozione, non comune",
			"All'interno del suo contenitore questo unguento nero viscoso sembra denso e pesante, ma scorre fluidamente quando viene versato. L'olio può coprire una creatura di taglia Media o inferiore, nonché ogni oggetto che indossa e trasporta (per ogni categoria di taglia superiore, è necessario usare una fiala aggiuntiva). L'applicazione dell'olio richiede 10 minuti. La creatura cosparsa d'olio ottiene gli effetti dell'incantesimo *libertà di movimento* per 8 ore.\n\nIn alternativa, è possibile usare un'azione per versare l'olio a terra, dove copre una superficie quadrata con lato di 3 metri, in cui riproduce gli effetti dell'incantesimo *unto* per 8 ore."),
			("Oil of Slipperiness", "Potion, uncommon",
			"This sticky black unguent is thick and heavy in the container, but it flows quickly when poured. The oil can cover a Medium or smaller creature, along with the equipment it's wearing and carrying (one additional vial is required for each size category above Medium). Applying the oil takes 10 minutes. The affected creature then gains the effect of a freedom of movement spell for 8 hours.\n\nAlternatively, the oil can be poured on the ground as an action, where it covers a 10-foot square, duplicating the effect of the grease spell in that area for 8 hours.", null));
	}
}
