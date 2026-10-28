using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Necklace of Fireballs (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class NecklaceOfFireballs2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("necklace-of-fireballs", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Collana delle palle di fuoco", "Oggetto meraviglioso, raro",
			"Da questa collana pendono 1d6 + 3 perle. Il personaggio può usare un'azione per staccare una delle perle e lanciarla fino a 18 metri di distanza. Alla fine della sua traiettoria, la perla esplode in una *palla di fuoco* di 3° livello (CD del tiro salvezza 15).\n\nCon un'unica azione, è possibile lanciare un numero maggiore di perle o perfino l'intera collana. In questi casi, il livello della *palla di fuoco* aumenta di 1 per ogni perla lanciata oltre alla prima.", null),
			("Necklace of Fireballs", "Wondrous item, rare",
			"This necklace has 1d6 + 3 beads hanging from it. You can use an action to detach a bead and throw it up to 60 feet away. When it reaches the end of its trajectory, the bead detonates as a 3rd-level fireball spell (save DC 15).\n\nYou can hurl multiple beads, or even the whole necklace, as one action. When you do so, increase the level of the fireball by 1 for each bead beyond the first.", null));
	}
}
