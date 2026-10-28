using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mariner's Armor (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class MarinersArmor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mariners-armor", null, 0, MagicItemType.Armor, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Armatura del marinaio", "Armatura (leggera, media o pesante), non comune",
			"Mentre indossa questa armatura, il personaggio ha una velocità di nuotare pari alla sua velocità base sul terreno. Inoltre, se inizia il suo turno sott'acqua con 0 punti ferita, l'armatura lo fa risalire di 18 metri verso la superficie. È decorata con motivi di pesci e conchiglie.", null),
			("Mariner's Armor", "Armor (light, medium, or heavy), uncommon",
			"While wearing this armor, you have a swimming speed equal to your walking speed. In addition, whenever you start your turn underwater with 0 hit points, the armor lifts you 60 feet toward the surface. It is decorated with fish and shell motifs.", null));
	}
}
