using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Enemy Detection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfEnemyDetection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-enemy-detection", null, 0, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta di individuazione dei nemici", "Bacchetta, rara (richiede sintonia)",
			"Questa bacchetta possiede 7 cariche. Mentre il personaggio la impugna, può usare un'azione e spendere 1 carica per pronunciarne la parola d'ordine. Durante il minuto successivo, il personaggio conosce la direzione della creatura ostile a lui più vicina e situata entro 18 metri da lui, ma non la sua distanza precisa. La bacchetta può percepire la presenza di creature ostili eteree, invisibili, camuffate o nascoste, oltre a quelle in piena vista. L'effetto termina se il personaggio smette di impugnare la bacchetta.\n\nAll'alba di ogni giorno, la bacchetta recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta."),
			("Wand of Enemy Detection", "Wand, rare (requires attunement)",
			"This wand has 7 charges. While holding it, you can use an action and expend 1 charge to speak its command word. For the next minute, you know the direction of the nearest creature hostile to you within 60 feet, but not its distance from you. The wand can sense the presence of hostile creatures that are ethereal, invisible, disguised, or hidden, as well as those in plain sight. The effect ends if you stop holding the wand.\n\nThe wand regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.", null));
	}
}
