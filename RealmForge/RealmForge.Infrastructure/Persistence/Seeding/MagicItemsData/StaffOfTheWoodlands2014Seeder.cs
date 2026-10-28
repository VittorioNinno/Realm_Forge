using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of the Woodlands (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfTheWoodlands2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-the-woodlands", null, 0, MagicItemType.Staff, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4", Effect(MagicEffectKind.AttackAndDamage, 2), Effect(MagicEffectKind.SpellAttack, 2)),
			("Bastone dei boschi", "Bastone, raro (richiede sintonia con un druido)",
			"Questo bastone può essere impugnato come un bastone ferrato magico che garantisce un bonus di +2 ai tiri per colpire e ai tiri per i danni effettuati con esso. Mentre il personaggio lo impugna, ottiene un bonus di +2 ai tiri per colpire con incantesimo.\n\nIl bastone possiede 10 cariche per le proprietà descritte di seguito. All'alba di ogni giorno, recupera 1d6 + 4 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20; se ottiene 1, il bastone diventa un bastone ferrato non magico.\n\n***Incantesimi.*** Il personaggio può usare un'azione e consumare 1 o più cariche per lanciare con esso uno degli incantesimi seguenti, usando la sua CD del tiro salvezza sull'incantesimo: *amicizia con gli animali* (1 carica), *localizza animali o vegetali* (2 cariche), *muro di spine* (6 cariche), *parlare con gli animali* (1 carica), *parlare con i vegetali* (3 cariche), *pelle coriacea* (2 cariche) o *risveglio* (5 cariche).\n\nIl personaggio può anche usare un'azione per lanciare con il bastone l'incantesimo *passare senza tracce* senza consumare alcuna carica.\n\n***Forma arborea.*** Il personaggio può usare un'azione per piantare un'estremità del bastone in un tratto di terra fertile e consumare 1 carica per trasformare il bastone in un albero rigoglioso. L'albero è alto 18 metri, ha un tronco del diametro di 1,5 metri e i rami sulla cima si estendono in un raggio di 6 metri. Sembra un normale albero, ma se su di lui viene lanciato un incantesimo *individuazione del magico,* emana una debole aura di magia di trasmutazione. Toccando l'albero e usando un'altra azione per pronunciare la parola d'ordine, il personaggio può riportare il bastone alla sua forma normale, facendo cadere ogni creatura che si trova su di esso."),
			("Staff of the Woodlands", "Staff, rare (requires attunement by a druid)",
			"This staff can be wielded as a magic quarterstaff that grants a +2 bonus to attack and damage rolls made with it. While holding it, you have a +2 bonus to spell attack rolls.\n\nThe staff has 10 charges for the following properties. It regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, the staff loses its properties and becomes a nonmagical quarterstaff.\n\n***Spells.*** You can use an action to expend 1 or more of the staff's charges to cast one of the following spells from it, using your spell save DC: animal friendship (1 charge), awaken (5 charges), barkskin (2 charges), locate animals or plants (2 charges), speak with animals (1 charge), speak with plants (3 charges), or wall of thorns (6 charges).\n\nYou can also use an action to cast the pass without trace spell from the staff without using any charges. Tree Form. You can use an action to plant one end of the staff in fertile earth and expend 1 charge to transform the staff into a healthy tree. The tree is 60 feet tall and has a 5-foot-diameter trunk, and its branches at the top spread out in a 20-foot radius.\n\nThe tree appears ordinary but radiates a faint aura of transmutation magic if targeted by detect magic. While touching the tree and using another action to speak its command word, you return the staff to its normal form. Any creature in the tree falls when it reverts to a staff.", null));
	}
}
