using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Luck Blade (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class LuckBlade2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("luck-blade", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1), Effect(MagicEffectKind.SavingThrows, 1)),
			("Lama della fortuna", "Arma (qualsiasi spada), leggendaria (richiede sintonia)",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Finché porta la spada sulla sua persona, ottiene anche un bonus di +1 ai tiri salvezza.\n\n***Desiderio.*** La spada possiede 1d4 – 1 cariche. Mentre il personaggio la impugna, può usare un'azione per consumare 1 carica e lanciare con essa l'incantesimo *desiderio.* Questa proprietà non può essere riutilizzata fino all'alba successiva. Quando finisce le cariche, la spada perde questa proprietà.\n\n***Fortuna.*** Se il personaggio porta la spada sulla sua persona, può appellarsi alla sua fortuna (nessuna azione richiesta) e ripetere un tiro per colpire, una prova di caratteristica o un tiro salvezza il cui risultato non è di suo gradimento. Deve usare il risultato del secondo tiro. Questa proprietà non può essere riutilizzata fino all'alba successiva.", null),
			("Luck Blade", "Weapon (any sword), legendary (requires attunement)",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon. While the sword is on your person, you also gain a +1 bonus to saving throws.\n\n***Luck.*** If the sword is on your person, you can call on its luck (no action required) to reroll one attack roll, ability check, or saving throw you dislike. You must use the second roll. This property can't be used again until the next dawn.\n\n***Wish.*** The sword has 1d4 - 1 charges. While holding it, you can use an action to expend 1 charge and cast the wish spell from it. This property can't be used again until the next dawn. The sword loses this property if it has no charges.", null));
	}
}
