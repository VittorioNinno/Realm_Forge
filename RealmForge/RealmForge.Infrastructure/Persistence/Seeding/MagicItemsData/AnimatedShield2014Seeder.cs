using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Animated Shield (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class AnimatedShield2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("animated-shield", null, 0, MagicItemType.Armor, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Scudo animato", "Armatura (scudo), molto raro (richiede sintonia)",
			"Il personaggio che impugna questo scudo può pronunciare la sua parola d'ordine come azione bonus per animarlo. Lo scudo si solleva in aria e fluttua nello spazio del personaggio per proteggerlo come quando quest'ultimo lo impugna normalmente, ma lasciandogli le mani libere. Lo scudo resta animato per 1 minuto, finché il personaggio non usa un'azione bonus per terminare l'effetto o finché il personaggio non diventa incapacitato o muore. In questi casi, lo scudo cade a terra o torna in mano al personaggio, se questi ha almeno una mano libera."),
			("Animated Shield", "Armor (shield), very rare (requires attunement)",
			"While holding this shield, you can speak its command word as a bonus action to cause it to animate. The shield leaps into the air and hovers in your space to protect you as if you were wielding it, leaving your hands free. The shield remains animated for 1 minute, until you use a bonus action to end this effect, or until you are incapacitated or die, at which point the shield falls to the ground or into your hand if you have one free.", null));
	}
}
