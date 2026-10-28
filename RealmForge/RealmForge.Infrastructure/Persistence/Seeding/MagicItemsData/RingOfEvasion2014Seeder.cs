using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Evasion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfEvasion2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-evasion", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello di eludere", "Anello, raro (richiede sintonia)",
			"Questo anello possiede 3 cariche e recupera 1d3 cariche consumate all'alba di ogni giorno. Quando il personaggio fallisce un tiro salvezza su Destrezza mentre indossa l'anello, può usare la sua reazione per consumare 1 carica e superare quel tiro salvezza."),
			("Ring of Evasion", "Ring, rare (requires attunement)",
			"This ring has 3 charges, and it regains 1d3 expended charges daily at dawn. When you fail a Dexterity saving throw while wearing it, you can use your reaction to expend 1 of its charges to succeed on that saving throw instead.", null));
	}
}
