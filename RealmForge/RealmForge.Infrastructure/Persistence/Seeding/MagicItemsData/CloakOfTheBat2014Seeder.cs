using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of the Bat (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfTheBat2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-the-bat", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Mantello del pipistrello", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il personaggio che indossa questo mantello dispone di vantaggio alle prove di Destrezza (Furtività). In un'area di luce fioca o di oscurità, può afferrare i lembi del mantello con entrambe le mani e usarlo per volare a una velocità di 12 metri. Se per qualunque motivo il personaggio lascia un lembo del mantello o esce dalla zona di luce fioca o di oscurità, perde questa velocità di volare.\n\nFintantoché il personaggio indossa il mantello in un'area di luce fioca o di oscurità, può usare un'azione per lanciare l'incantesimo *metamorfosi* su se stesso per trasformarsi in un pipistrello. In forma di pipistrello mantiene i suoi punteggi di Intelligenza, Saggezza e Carisma. Il mantello non può essere riutilizzato in questo modo fino all'alba successiva."),
			("Cloak of the Bat", "Wondrous item, rare (requires attunement)",
			"While wearing this cloak, you have advantage on Dexterity (Stealth) checks. In an area of dim light or darkness, you can grip the edges of the cloak with both hands and use it to fly at a speed of 40 feet. If you ever fail to grip the cloak's edges while flying in this way, or if you are no longer in dim light or darkness, you lose this flying speed.\n\nWhile wearing the cloak in an area of dim light or darkness, you can use your action to cast polymorph on yourself, transforming into a bat. While you are in the form of the bat, you retain your Intelligence, Wisdom, and Charisma scores. The cloak can't be used this way again until the next dawn.", null));
	}
}
