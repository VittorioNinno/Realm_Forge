using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Spell Turning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfSpellTurning2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-spell-turning", null, 0, MagicItemType.Ring, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Anello rifletti incantesimo", "Anello, leggendario (richiede sintonia)",
			"Finché il personaggio indossa questo anello, dispone di vantaggio ai tiri salvezza contro qualsiasi incantesimo che bersagli soltanto lui (non in un'area di effetto). Inoltre, se il personaggio ottiene 20 al tiro salvezza e l'incantesimo è di livello pari o inferiore al 7°, esso non ha alcun effetto sul personaggio e viene invece riflesso contro l'incantatore, usando il livello di slot, la CD del tiro salvezza sull'incantesimo, il bonus di attacco e la caratteristica da incantatore di chi ha lanciato l'incantesimo.", null),
			("Ring of Spell Turning", "Ring, legendary (requires attunement)",
			"While wearing this ring, you have advantage on saving throws against any spell that targets only you (not in an area of effect). In addition, if you roll a 20 for the save and the spell is 7th level or lower, the spell has no effect on you and instead targets the caster, using the slot level, spell save DC, attack bonus, and spellcasting ability of the caster.", null));
	}
}
