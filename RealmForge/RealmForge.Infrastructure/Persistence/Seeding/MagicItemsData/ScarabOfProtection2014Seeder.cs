using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Scarab of Protection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ScarabOfProtection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("scarab-of-protection", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			Charges(12, ItemRecharge.None, null),
			("Scarabeo di protezione", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"Se il personaggio impugna questo medaglione a forma di scarabeo per 1 round, sulla superficie dell'oggetto compare una scritta che ne rivela la natura magica. Mentre il personaggio porta sulla sua persona lo scarabeo, questo fornisce due benefici:\n\n- Il personaggio dispone di vantaggio ai tiri salvezza contro gli incantesimi.\n\n- Lo scarabeo possiede 12 cariche. Se il personaggio fallisce un tiro salvezza contro un incantesimo di necromanzia o un effetto nocivo proveniente da una creatura non morta, può usare la sua reazione e consumare 1 carica per trasformare il tiro salvezza fallito in un successo. Una volta consumata l'ultima carica, lo scarabeo si sbriciola ed è distrutto.", null),
			("Scarab of Protection", "Wondrous item, legendary (requires attunement)",
			"If you hold this beetle-shaped medallion in your hand for 1 round, an inscription appears on its surface revealing its magical nature. It provides two benefits while it is on your person:\n\nYou have advantage on saving throws against spells.\n\nThe scarab has 12 charges. If you fail a saving throw against a necromancy spell or a harmful effect originating from an undead creature, you can use your reaction to expend 1 charge and turn the failed save into a successful one. The scarab crumbles into powder and is destroyed when its last charge is expended.", null));
	}
}
