using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Regeneration (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfRegeneration2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-regeneration", null, 0, MagicItemType.Ring, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Anello di rigenerazione", "Anello, molto raro (richiede sintonia)",
			"Finché il personaggio indossa questo anello, recupera 1d6 punti ferita ogni 10 minuti, purché possieda almeno 1 punto ferita. Se il personaggio perde una parte del corpo, l'anello fa ricrescere la parte mancante facendola tornare alla piena funzionalità dopo 1d6 + 1 giorni, purché il personaggio abbia almeno 1 punto ferita in tutto questo periodo di tempo."),
			("Ring of Regeneration", "Ring, very rare (requires attunement)",
			"While wearing this ring, you regain 1d6 hit points every 10 minutes, provided that you have at least 1 hit point. If you lose a body part, the ring causes the missing part to regrow and return to full functionality after 1d6 + 1 days if you have at least 1 hit point the whole time.", null));
	}
}
