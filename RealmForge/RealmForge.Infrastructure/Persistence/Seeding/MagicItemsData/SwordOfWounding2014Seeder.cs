using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sword of Wounding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SwordOfWounding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sword-of-wounding", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Spada del ferimento", "Arma (qualsiasi spada), rara (richiede sintonia)",
			"I punti ferita persi a causa dei danni inferti da questa spada possono essere recuperati solo tramite un riposo breve o lungo, e non tramite rigenerazione, magia o qualsiasi altro metodo.\n\nUna volta per turno, quando colpisce una creatura con un attacco sferrato con quest'arma magica, il personaggio può decidere di ferire il bersaglio. All'inizio di ogni turno della creatura ferita, essa subisce 1d4 danni necrotici per ogni volta in cui il personaggio l'ha ferita; può poi effettuare un tiro salvezza su Costituzione con CD 15 per porre fine all'effetto di tutte le ferite che ha ricevuto in caso di successo. In alternativa, la creatura ferita o un'altra creatura entro 1,5 metri da essa può usare un'azione per effettuare una prova di Saggezza (Medicina) con CD 15, terminando l'effetto delle ferite in caso di successo."),
			("Sword of Wounding", "Weapon (any sword), rare (requires attunement)",
			"Hit points lost to this weapon's damage can be regained only through a short or long rest, rather than by regeneration, magic, or any other means.\n\nOnce per turn, when you hit a creature with an attack using this magic weapon, you can wound the target. At the start of each of the wounded creature's turns, it takes 1d4 necrotic damage for each time you've wounded it, and it can then make a DC 15 Constitution saving throw, ending the effect of all such wounds on itself on a success. Alternatively, the wounded creature, or a creature within 5 feet of it, can use an action to make a DC 15 Wisdom (Medicine) check, ending the effect of such wounds on it on a success.", null));
	}
}
