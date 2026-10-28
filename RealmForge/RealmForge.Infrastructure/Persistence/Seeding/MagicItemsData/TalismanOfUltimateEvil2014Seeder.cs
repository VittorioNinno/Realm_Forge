using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Talisman of Ultimate Evil (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class TalismanOfUltimateEvil2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("talisman-of-ultimate-evil", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			Charges(6, ItemRecharge.None, null),
			("Talismano del male estremo", "Oggetto meraviglioso, leggendario (richiede sintonia con una creatura di allineamento malvagio)",
			"Quest'oggetto è un simbolo di malvagità impenitente. Se una creatura che non è di allineamento buono né malvagio tocca il talismano, subisce 6d6 danni necrotici. Una creatura buona che tocca il talismano subisce 8d6 danni necrotici. In entrambi i casi, la creatura subisce i danni ogni volta che termina il proprio turno impugnando o trasportando il talismano.\n\nSe il personaggio è un chierico o un paladino malvagio, può usare il talismano come simbolo sacro e ottiene un bonus di +2 ai tiri per colpire con incantesimo quando lo indossa o lo impugna.\n\nIl talismano possiede 6 cariche. Se il personaggio lo indossa o lo impugna, può usare un'azione e consumare 1 carica per scegliere una creatura che è in grado di vedere situata sul terreno entro 36 metri da lui. Se il bersaglio è di allineamento buono, sotto di lui si apre una fenditura infuocata. Il bersaglio deve superare un tiro salvezza su Destrezza con CD 20, altrimenti cade nella fenditura ed è distrutto, senza lasciare resti. La fenditura poi si richiude, senza lasciare alcuna traccia della sua esistenza. Quando il personaggio consuma l'ultima carica, il talismano si dissolve in melma dall'odore rivoltante ed è distrutto.", null),
			("Talisman of Ultimate Evil", "Wondrous item, legendary (requires attunement by a creature of evil alignment)",
			"This item symbolizes unrepentant evil. A creature that is neither good nor evil in alignment takes 6d6 necrotic damage upon touching the talisman. A good creature takes 8d6 necrotic damage upon touching the talisman. Either sort of creature takes the damage again each time it ends its turn holding or carrying the talisman.\n\nIf you are an evil cleric or paladin, you can use the talisman as a holy symbol, and you gain a +2 bonus to spell attack rolls while you wear or hold it.\n\nThe talisman has 6 charges. If you are wearing or holding it, you can use an action to expend 1 charge from the talisman and choose one creature you can see on the ground within 120 feet of you. If the target is of good alignment, a flaming fissure opens under it. The target must succeed on a DC 20 Dexterity saving throw or fall into the fissure and be destroyed, leaving no remains. The fissure then closes, leaving no trace of its existence. When you expend the last charge, the talisman dissolves into foul-smelling slime and is destroyed.", null));
	}
}
