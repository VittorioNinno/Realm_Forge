using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Glamoured Studded Leather Armor (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GlamouredStuddedLeatherArmor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("glamoured-studded-leather-armor", null, 0, MagicItemType.Armor, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Armatura di cuoio borchiato incantata", "Armatura (cuoio borchiato), rara",
			"Mentre il personaggio indossa quest'armatura, ottiene un bonus di +1 alla CA. Può anche usare un'azione bonus per pronunciare la parola d'ordine dell'armatura e farle assumere l'aspetto di un normale capo di vestiario o di un altro tipo di armatura. Il personaggio può deciderne l'aspetto, inclusi il colore, lo stile e gli accessori, ma l'armatura mantiene il suo ingombro e il suo peso normali. L'aspetto illusorio permane finché la proprietà dell'armatura non viene utilizzata di nuovo o finché il personaggio non rimuove l'armatura."),
			("Glamoured Studded Leather Armor", "Armor (studded leather), rare",
			"While wearing this armor, you gain a +1 bonus to AC. You can also use a bonus action to speak the armor's command word and cause the armor to assume the appearance of a normal set of clothing or some other kind of armor. You decide what it looks like, including color, style, and accessories, but the armor retains its normal bulk and weight. The illusory appearance lasts until you use this property again or remove the armor.", null));
	}
}
