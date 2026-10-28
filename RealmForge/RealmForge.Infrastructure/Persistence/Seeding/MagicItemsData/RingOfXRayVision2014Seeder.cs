using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of X-ray Vision (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfXRayVision2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-x-ray-vision", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello della vista a raggi X", "Anello, raro (richiede sintonia)",
			"Finché il personaggio indossa questo anello, può usare un'azione per pronunciarne la parola d'ordine. Quando lo fa, può vedere all'interno della materia solida e attraverso di essa per 1 minuto. Questo tipo di vista ha un raggio di 9 metri. Gli oggetti solidi che si trovano entro il raggio d'azione appaiono al personaggio come trasparenti e non impediscono alla luce di attraversarli. La vista può penetrare 30 cm di pietra, 2,5 centimetri di metallo comune o fino a 90 cm di legno o terriccio. Le sostanze più dense, come per esempio un sottile strato di piombo, bloccano questa forma di vista.\n\nOgni volta che usa di nuovo l'anello prima di completare un riposo lungo, il personaggio deve superare un tiro salvezza su Costituzione con CD 15, altrimenti subisce un livello di indebolimento."),
			("Ring of X-ray Vision", "Ring, rare (requires attunement)",
			"While wearing this ring, you can use an action to speak its command word. When you do so, you can see into and through solid matter for 1 minute. This vision has a radius of 30 feet. To you, solid objects within that radius appear transparent and don't prevent light from passing through them. The vision can penetrate 1 foot of stone, 1 inch of common metal, or up to 3 feet of wood or dirt. Thicker substances block the vision, as does a thin sheet of lead.\n\nWhenever you use the ring again before taking a long rest, you must succeed on a DC 15 Constitution saving throw or gain one level of exhaustion.", null));
	}
}
