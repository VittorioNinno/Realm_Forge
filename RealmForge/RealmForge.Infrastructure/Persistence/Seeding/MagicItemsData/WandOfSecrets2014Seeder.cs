using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Secrets (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfSecrets2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-secrets", null, 0, MagicItemType.Wand, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Bacchetta dei segreti", "Bacchetta, non comune",
			"Questa bacchetta possiede 3 cariche. Finché il personaggio la impugna, può usare un'azione e spendere 1 carica: se entro 9 metri da lui si trovano porte segrete o trappole, la bacchetta inizia a pulsare e indica quella a lui più vicina. La bacchetta recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Wand of Secrets", "Wand, uncommon",
			"The wand has 3 charges. While holding it, you can use an action to expend 1 of its charges, and if a secret door or trap is within 30 feet of you, the wand pulses and points at the one nearest to you. The wand regains 1d3 expended charges daily at dawn.", null));
	}
}
