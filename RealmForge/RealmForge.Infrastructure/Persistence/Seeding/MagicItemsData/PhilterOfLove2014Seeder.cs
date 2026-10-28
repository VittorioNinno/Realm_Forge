using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Philter of Love (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PhilterOfLove2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("philter-of-love", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Filtro d'amore", "Pozione, non comune",
			"La prossima volta che un personaggio vede una creatura entro 10 minuti dal momento in cui ha bevuto il filtro, diventa affascinato da essa per 1 ora. Se la creatura appartiene a una specie e a un sesso dai quali il personaggio è normalmente attratto, egli considera la creatura il suo vero amore per tutta la durata dell'effetto. Il liquido rosato ed effervescente di questa pozione contiene una bolla a forma di cuore alquanto difficile da individuare.", null),
			("Philter of Love", "Potion, uncommon",
			"The next time you see a creature within 10 minutes after drinking this philter, you become charmed by that creature for 1 hour. If the creature is of a species and gender you are normally attracted to, you regard it as your true love while you are charmed. This potion's rose-hued, effervescent liquid contains one easy-to-miss bubble shaped like a heart.", null));
	}
}
