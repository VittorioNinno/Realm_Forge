using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sword of Answering (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class SwordOfAnswering2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sword-of-answering", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Spada della risposta", "Arma (spada lunga), leggendaria (richiede sintonia con una creatura dello stesso allineamento della spada)",
			"Nel mondo di Greyhawk se ne conoscono solo nove, tutte forgiate sul modello della leggendaria spada Fragarach, il cui nome viene reso come \"Ultima Parola\". Ognuna ha un nome, un allineamento e una gemma diversa incastonata nel pomolo.\n\nIl personaggio ottiene un bonus di +3 ai tiri per colpire e ai danni effettuati con questa spada. Inoltre, mentre la impugna, può usare la sua reazione per effettuare un attacco in mischia con essa contro una creatura entro la sua portata che gli infligge danni. Il personaggio dispone di vantaggio a questo tiro per colpire, e i danni di questo attacco speciale ignorano qualsiasi immunità o resistenza del bersaglio.\n\n| Nome | Allineamento | Gemma |\n|---|---|---|\n| Ribattitrice (Answerer) | Caotico buono | Smeraldo |\n| Linguacciuta (Back Talker) | Caotico malvagio | Giaietto |\n| Conclusiva (Concluder) | Legale neutrale | Ametista |\n| Ultima Battuta (Last Quip) | Caotico neutrale | Tormalina |\n| Confutatrice (Rebutter) | Neutrale buono | Topazio |\n| Replicante (Replier) | Neutrale | Peridoto |\n| Rimbeccatrice (Retorter) | Legale buono | Acquamarina |\n| Sferzante (Scather) | Legale malvagio | Granato |\n| Zittitrice (Squelcher) | Neutrale malvagio | Spinello |"),
			("Sword of Answering", "Weapon (longsword), legendary (requires attunement by a creature with the same alignment as the sword)",
			"Only nine of these blades are known in the world of Greyhawk, all modeled on the legendary sword Fragarach, whose name is rendered as \"Final Word\". Each has its own name, alignment and a different gem set in its pommel.\n\nYou gain a +3 bonus to attack and damage rolls made with this sword. In addition, while you hold it, you can use your reaction to make one melee attack with it against a creature within your reach that deals damage to you. You have advantage on that attack roll, and its damage ignores any immunity or resistance the target has.\n\n| Name | Alignment | Gem |\n|---|---|---|\n| Answerer | Chaotic good | Emerald |\n| Back Talker | Chaotic evil | Jet |\n| Concluder | Lawful neutral | Amethyst |\n| Last Quip | Chaotic neutral | Tourmaline |\n| Rebutter | Neutral good | Topaz |\n| Replier | Neutral | Peridot |\n| Retorter | Lawful good | Aquamarine |\n| Scather | Lawful evil | Garnet |\n| Squelcher | Neutral evil | Spinel |", null));
	}
}
