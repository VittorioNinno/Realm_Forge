using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Demon Armor (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DemonArmor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("demon-armor", null, 0, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Armatura demoniaca", "Armatura (armatura a piastre), molto rara (richiede sintonia)",
			"Mentre il personaggio indossa questa armatura, ottiene un bonus di +1 alla CA ed è in grado di comprendere e parlare l'Abissale. Inoltre, i guanti d'arme artigliati dell'armatura trasformano i colpi senz'armi effettuati con le mani in armi magiche che infliggono 1d8 danni taglienti, con un bonus di +1 ai tiri per colpire e ai tiri per i danni.\n\n***Maledizione.*** Una volta indossata quest'armatura maledetta, il personaggio non può togliersela a meno che non sia bersagliato da un incantesimo *rimuovi maledizione* o una magia analoga. Mentre l'indossa, il personaggio subisce svantaggio ai tiri per colpire contro i demoni e ai tiri salvezza contro i loro incantesimi e le loro abilità speciali.", null),
			("Demon Armor", "Armor (plate), very rare (requires attunement)",
			"While wearing this armor, you gain a +1 bonus to AC, and you can understand and speak Abyssal. In addition, the armor's clawed gauntlets turn unarmed strikes with your hands into magic weapons that deal slashing damage, with a +1 bonus to attack rolls and damage rolls and a damage die of 1d8.\n\n***Curse.*** Once you don this cursed armor, you can't doff it unless you are targeted by the remove curse spell or similar magic. While wearing the armor, you have disadvantage on attack rolls against demons and on saving throws against their spells and special abilities.", null));
	}
}
