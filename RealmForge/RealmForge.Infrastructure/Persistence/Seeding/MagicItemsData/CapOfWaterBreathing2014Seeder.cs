using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cap of Water Breathing (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class CapOfWaterBreathing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cap-of-water-breathing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Copricapo del respirare sott'acqua", "Oggetto meraviglioso, non comune",
			"Mentre si trova sott'acqua e indossa questo berretto, il personaggio può usare un'azione per pronunciarne la parola di comando: attorno alla sua testa si forma una bolla d'aria che gli permette di respirare normalmente. La bolla resta finché il personaggio non ripete la parola di comando, non si toglie il berretto o non esce dall'acqua.", null),
			("Cap of Water Breathing", "Wondrous item, uncommon",
			"While you are underwater and wearing this cap, you can use an action to speak its command word: a bubble of air forms around your head and lets you breathe normally. The bubble lasts until you speak the command word again, take the cap off, or leave the water.", null));
	}
}
