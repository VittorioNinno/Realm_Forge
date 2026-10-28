using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Oil of Sharpness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class OilOfSharpness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("oil-of-sharpness", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Olio dell'affilatura", "Pozione, molto rara",
			"Quest'olio trasparente e gelatinoso luccica a causa di minuscoli e sottilissimi frammenti d'argento. L'olio può ricoprire un'arma tagliente o perforante, oppure fino a 5 munizioni taglienti o perforanti. L'applicazione dell'olio richiede 1 minuto. Per 1 ora, l'oggetto ricoperto è magico e conferisce un bonus di +3 ai tiri per colpire e ai tiri per i danni.", null),
			("Oil of Sharpness", "Potion, very rare",
			"This clear, gelatinous oil sparkles with tiny, ultrathin silver shards. The oil can coat one slashing or piercing weapon or up to 5 pieces of slashing or piercing ammunition. Applying the oil takes 1 minute. For 1 hour, the coated item is magical and has a +3 bonus to attack and damage rolls.", null));
	}
}
