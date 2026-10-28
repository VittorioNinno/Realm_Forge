using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Trident of Fish Command (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class TridentOfFishCommand2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("trident-of-fish-command", null, 0, MagicItemType.Weapon, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Tridente del comando dei pesci", "Arma (tridente), non comune (richiede sintonia)",
			"Questo tridente è un'arma magica. Possiede 3 cariche. Finché il personaggio lo trasporta, può usare un'azione e spendere 1 carica per lanciare con esso l'incantesimo *dominare bestie* (CD del tiro salvezza 15) su una bestia dotata di una velocità di nuotare innata. Il tridente recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Trident of Fish Command", "Weapon (trident), uncommon (requires attunement)",
			"This trident is a magic weapon. It has 3 charges. While you carry it, you can use an action and expend 1 charge to cast dominate beast (save DC 15) from it on a beast that has an innate swimming speed. The trident regains 1d3 expended charges daily at dawn.", null));
	}
}
