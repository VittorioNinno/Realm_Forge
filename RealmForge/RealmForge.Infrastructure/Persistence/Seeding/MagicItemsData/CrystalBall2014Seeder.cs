using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Crystal Ball (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CrystalBall2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("crystal-ball", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Sfera di cristallo", "Oggetto meraviglioso, molto raro o leggendario (richiede sintonia)",
			"Una tipica *sfera di cristallo,* un oggetto molto raro, ha un diametro di circa 15 cm. Mentre il personaggio tocca la sfera, può lanciare l'incantesimo *scrutare* (CD del tiro salvezza 17).\n\nLe seguenti varianti della *sfera di cristallo* sono oggetti leggendari e hanno proprietà aggiuntive.\n\n***Sfera di cristallo della lettura del pensiero.*** Mentre il personaggio scruta con la *sfera di cristallo,* può usare un'azione per lanciare l'incantesimo *individuazione dei pensieri* (CD del tiro salvezza 17) su creature che è in grado di vedere situate entro 9 metri dal sensore dell'incantesimo. Non è obbligato a concentrarsi su *individuazione dei pensieri* per mantenerlo per la sua durata, ma se *scrutare* viene interrotto, anche l'incantesimo si interrompe.\n\n***Sfera di cristallo della telepatia.*** Mentre il personaggio scruta con la *sfera di cristallo,* può comunicare telepaticamente con le creature che è in grado di vedere situate entro 9 metri dal sensore dell'incantesimo. Può anche usare un'azione per lanciare su una di quelle creature l'incantesimo *suggestione* (CD del tiro salvezza 17) attraverso il sensore. Non è obbligato a concentrarsi su *suggestione* per mantenerlo per la sua durata, ma se *scrutare* viene interrotto, anche l'incantesimo si interrompe. Una volta usato, il potere di *suggestione* della *sfera di cristallo* non può essere riutilizzato fino all'alba successiva.\n\n***Sfera di cristallo della visione del vero.*** Mentre il personaggio scruta con la *sfera di cristallo,* ottiene vista pura entro un raggio di 36 metri centrato sul sensore dell'incantesimo."),
			("Crystal Ball", "Wondrous item, very rare or legendary (requires attunement)",
			"The typical crystal ball, a very rare item, is about 6 inches in diameter. While touching it, you can cast the scrying spell (save DC 17) with it.\n\nThe following crystal ball variants are legendary items and have additional properties.\n\n***Crystal Ball of Mind Reading.*** You can use an action to cast the detect thoughts spell (save DC 17) while you are scrying with the crystal ball, targeting creatures you can see within 30 feet of the spell's sensor. You don't need to concentrate on this detect thoughts to maintain it during its duration, but it ends if scrying ends.\n\n***Crystal Ball of Telepathy.*** While scrying with the crystal ball, you can communicate telepathically with creatures you can see within 30 feet of the spell's sensor. You can also use an action to cast the suggestion spell (save DC 17) through the sensor on one of those creatures. You don't need to concentrate on this suggestion to maintain it during its duration, but it ends if scrying ends. Once used, the suggestion power of the crystal ball can't be used again until the next dawn.\n\n***Crystal Ball of True Seeing.*** While scrying with the crystal ball, you have truesight with a radius of 120 feet centered on the spell's sensor.", null));
		yield return Item("crystal-ball-of-mind-reading", "crystal-ball", 1, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Sfera di cristallo della lettura del pensiero", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			""),
			("Crystal Ball of Mind Reading", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("crystal-ball-of-telepathy", "crystal-ball", 2, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Sfera di cristallo della telepatia", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			""),
			("Crystal Ball of Telepathy", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("crystal-ball-of-true-seeing", "crystal-ball", 3, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Sfera di cristallo della visione del vero", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			""),
			("Crystal Ball of True Seeing", "Wondrous item, legendary (requires attunement)",
			"", null));
	}
}
