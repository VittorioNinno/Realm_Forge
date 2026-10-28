using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Invisibility (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfInvisibility2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-invisibility", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pozione dell'invisibilità", "Pozione, molto rara",
			"Il contenitore di questa pozione sembra vuoto, ma pesa come se al suo interno ci fosse un liquido. Quando il personaggio beve la pozione, diventa invisibile per 1 ora. Tutto ciò che indossa o trasporta diventa invisibile assieme a lui. L'effetto termina anticipatamente se il personaggio effettua un attacco o lancia un incantesimo."),
			("Potion of Invisibility", "Potion, very rare",
			"This potion's container looks empty but feels as though it holds liquid. When you drink it, you become invisible for 1 hour. Anything you wear or carry is invisible with you. The effect ends early if you attack or cast a spell.", null));
	}
}
