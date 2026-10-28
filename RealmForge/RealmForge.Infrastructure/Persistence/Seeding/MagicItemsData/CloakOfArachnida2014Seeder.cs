using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of Arachnida (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfArachnida2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-arachnida", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Poison)),
			("Mantello dell'aracnide", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"Questo raffinato indumento di seta nera è intessuto con sottilissimi fili argentati. Il personaggio che lo indossa riceve i benefici seguenti:\n\n- Resistenza ai danni da veleno.\n\n- Velocità di scalare pari alla propria velocità base sul terreno.\n\n- Può muoversi in alto, in basso e lateralmente sulle superfici verticali e a testa in giù sui soffitti mantenendo le mani libere.\n\n- Non può essere bloccato da alcun tipo di ragnatela e può muoversi attraverso di esse come se fossero terreno difficile.\n\n- Può usare un'azione per lanciare l'incantesimo *ragnatela* (CD del tiro salvezza 13). La ragnatela creata dall'incantesimo riempie un'area doppia rispetto al normale. Una volta usata, la proprietà del mantello non può essere riutilizzata fino all'alba successiva.", null),
			("Cloak of Arachnida", "Wondrous item, very rare (requires attunement)",
			"This fine garment is made of black silk interwoven with faint silvery threads. While wearing it, you gain the following benefits:\n\n* You have resistance to poison damage.\n\n* You have a climbing speed equal to your walking speed.\n\n* You can move up, down, and across vertical surfaces and upside down along ceilings, while leaving your hands free.\n\n* You can't be caught in webs of any sort and can move through webs as if they were difficult terrain.\n\n* You can use an action to cast the web spell (save DC 13). The web created by the spell fills twice its normal area. Once used, this property of the cloak can't be used again until the next dawn.", null));
	}
}
