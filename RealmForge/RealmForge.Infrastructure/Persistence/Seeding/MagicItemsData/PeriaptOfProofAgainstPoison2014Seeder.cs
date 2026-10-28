using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Periapt of Proof against Poison (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PeriaptOfProofAgainstPoison2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("periapt-of-proof-against-poison", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Talismano di prova contro il veleno", "Oggetto meraviglioso, raro",
			"Questa delicata catenella d'argento ha come pendente una gemma nera con taglio a brillante. Finché il personaggio la indossa, i veleni non hanno alcun effetto su di lui. Il personaggio è inoltre immune alla condizione avvelenato e ottiene immunità ai danni da veleno."),
			("Periapt of Proof against Poison", "Wondrous item, rare",
			"This delicate silver chain has a brilliant-cut black gem pendant. While you wear it, poisons have no effect on you. You are immune to the poisoned condition and have immunity to poison damage.", null));
	}
}
