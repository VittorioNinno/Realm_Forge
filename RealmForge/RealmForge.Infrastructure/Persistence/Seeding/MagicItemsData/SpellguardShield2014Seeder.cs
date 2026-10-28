using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Spellguard Shield (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SpellguardShield2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("spellguard-shield", null, 0, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Scudo anti-incantesimi", "Armatura (scudo), molto raro (richiede sintonia)",
			"Mentre il personaggio impugna questo scudo, dispone di vantaggio ai tiri salvezza contro gli incantesimi e altri effetti magici. Inoltre, gli attacchi con incantesimo contro di lui subiscono svantaggio."),
			("Spellguard Shield", "Armor (shield), very rare (requires attunement)",
			"While holding this shield, you have advantage on saving throws against spells and other magical effects, and spell attacks have disadvantage against you.", null));
	}
}
