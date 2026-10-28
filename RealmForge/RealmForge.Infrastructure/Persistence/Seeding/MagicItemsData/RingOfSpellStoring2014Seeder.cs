using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Spell Storing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfSpellStoring2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-spell-storing", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello accumula incantesimi", "Anello, raro (richiede sintonia)",
			"Questo anello accumula gli incantesimi lanciati su di esso, finché un possessore in sintonia con esso non decide di usarli. L'anello può contenere fino a 5 livelli di incantesimo per volta. Quando viene trovato, contiene 1d6 – 1 livelli di incantesimi accumulati scelti dal GM.\n\nQualsiasi creatura può lanciare nell'anello un incantesimo di livello compreso tra il 1° e il 5° toccandolo al momento del lancio dell'incantesimo. L'incantesimo non ha alcun effetto, a parte quello di essere immagazzinato nell'anello. Se l'anello non può contenere altri incantesimi, quello lanciato viene sprecato senza provocare alcun effetto. Il livello dello slot usato per lanciare l'incantesimo determina lo spazio che occupa.\n\nFinché il personaggio indossa l'anello, può lanciare qualsiasi incantesimo conservato al suo interno. L'incantesimo usa il livello di slot, la CD del tiro salvezza sull'incantesimo, il bonus all'attacco con incantesimo e la caratteristica da incantatore di chi l'ha lanciato in origine, ma sotto ogni altro aspetto si considera che sia stato il personaggio a lanciarlo. L'incantesimo lanciato dall'anello non è più conservato al suo interno, liberando il relativo spazio.", null),
			("Ring of Spell Storing", "Ring, rare (requires attunement)",
			"This ring stores spells cast into it, holding them until the attuned wearer uses them. The ring can store up to 5 levels worth of spells at a time. When found, it contains 1d6 - 1 levels of stored spells chosen by the GM.\n\nAny creature can cast a spell of 1st through 5th level into the ring by touching the ring as the spell is cast. The spell has no effect, other than to be stored in the ring. If the ring can't hold the spell, the spell is expended without effect. The level of the slot used to cast the spell determines how much space it uses.\n\nWhile wearing this ring, you can cast any spell stored in it. The spell uses the slot level, spell save DC, spell attack bonus, and spellcasting ability of the original caster, but is otherwise treated as if you cast the spell. The spell cast from the ring is no longer stored in it, freeing up space.", null));
	}
}
