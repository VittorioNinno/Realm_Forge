using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cape of the Mountebank (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CapeOfTheMountebank2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cape-of-the-mountebank", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Cappa del saltimbanco", "Oggetto meraviglioso, raro",
			"Questa cappa emana un leggero odore di zolfo. Quando il personaggio la indossa, può usare un'azione per lanciare l'incantesimo *porta dimensionale.* Questa proprietà non può essere riutilizzata fino all'alba successiva.\n\nQuando scompare, il personaggio lascia dietro di sé una nuvola di fumo, che si materializza anche nel luogo in cui ricompare. Il fumo rende leggermente oscurati i due luoghi e si disperde alla fine del turno successivo del personaggio. Un vento leggero o più forte disperde il fumo."),
			("Cape of the Mountebank", "Wondrous item, rare",
			"This cape smells faintly of brimstone. While wearing it, you can use it to cast the dimension door spell as an action. This property of the cape can't be used again until the next dawn.\n\nWhen you disappear, you leave behind a cloud of smoke, and you appear in a similar cloud of smoke at your destination. The smoke lightly obscures the space you left and the space you appear in, and it dissipates at the end of your next turn. A light or stronger wind disperses the smoke.", null));
	}
}
