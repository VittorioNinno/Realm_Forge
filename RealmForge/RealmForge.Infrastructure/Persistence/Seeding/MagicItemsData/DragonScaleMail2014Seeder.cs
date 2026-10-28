using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dragon Scale Mail (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DragonScaleMail2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dragon-scale-mail", null, 0, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Corazza di scaglie di drago", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"La corazza di scaglie di drago è ricavata dalle scaglie di un tipo di drago. A volte i draghi raccolgono le loro scaglie cadute e ne fanno dono a un umanoide. Altre volte i cacciatori scuoiano accuratamente i draghi uccisi e ne conservano le pelli. In entrambi i casi, la corazza di scaglie di drago è un oggetto estremamente pregiato.\n\nQuando indossa quest'armatura, il personaggio ottiene un bonus di +1 alla CA, vantaggio ai tiri salvezza contro Presenza terrificante e il soffio dei draghi, e resistenza a un tipo di danno determinato dal tipo di scaglie da cui è composta l'armatura (vedi la tabella).\n\nCon un'azione, il personaggio può inoltre concentrare i suoi sensi e percepire magicamente la distanza e la direzione del drago più vicino dello stesso tipo dell'armatura, entro un raggio di 45 km. Una volta usata, non può essere riutilizzata fino all'alba successiva.\n\n| Drago | Resistenza | Drago | Resistenza |\n|---|---|---|---|\n| Argento | Freddo | Oro | Fuoco |\n| Bianco | Freddo | Ottone | Fuoco |\n| Blu | Fulmine | Rame | Acido |\n| Bronzo | Fulmine | Rosso | Fuoco |\n| Nero | Acido | Verde | Veleno |", null),
			("Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"Dragon scale mail is made of the scales of one kind of dragon. Sometimes dragons collect their cast-off scales and gift them to humanoids. Other times, hunters carefully skin and preserve the hide of a dead dragon. In either case, dragon scale mail is highly valued.\n\nWhile wearing this armor, you gain a +1 bonus to AC, you have advantage on saving throws against the Frightful Presence and breath weapons of dragons, and you have resistance to one damage type that is determined by the kind of dragon that provided the scales (see the table).\n\nAdditionally, you can focus your senses as an action to magically discern the distance and direction to the closest dragon within 30 miles of you that is of the same type as the armor. This special action can't be used again until the next dawn.\n\n| Dragon | Resistance |\n|---|---|\n| Black | Acid |\n| Blue | Lightning |\n| Brass | Fire |\n| Bronze | Lightning |\n| Copper | Acid |\n| Gold | Fire |\n| Green | Poison |\n| Red | Fire |\n| Silver | Cold |\n| White | Cold |", null));
		yield return Item("dragon-scale-mail-black", "dragon-scale-mail", 1, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Acid)),
			("Corazza di scaglie di drago nero", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Black Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-blue", "dragon-scale-mail", 2, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Lightning)),
			("Corazza di scaglie di drago blu", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Blue Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-brass", "dragon-scale-mail", 3, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Fire)),
			("Corazza di scaglie di drago d'ottone", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Brass Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-bronze", "dragon-scale-mail", 4, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Lightning)),
			("Corazza di scaglie di drago di bronzo", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Bronze Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-copper", "dragon-scale-mail", 5, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Acid)),
			("Corazza di scaglie di drago di rame", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Copper Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-gold", "dragon-scale-mail", 6, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Fire)),
			("Corazza di scaglie di drago d'oro", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Gold Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-green", "dragon-scale-mail", 7, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Poison)),
			("Corazza di scaglie di drago verde", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Green Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-red", "dragon-scale-mail", 8, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Fire)),
			("Corazza di scaglie di drago rosso", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Red Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-silver", "dragon-scale-mail", 9, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Cold)),
			("Corazza di scaglie di drago d'argento", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("Silver Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
		yield return Item("dragon-scale-mail-white", "dragon-scale-mail", 10, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Resist(DamageType.Cold)),
			("Corazza di scaglie di drago bianco", "Armatura (corazza a scaglie), molto rara (richiede sintonia)",
			"", null),
			("White Dragon Scale Mail", "Armor (scale mail), very rare (requires attunement)",
			"", null));
	}
}
