using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of Security (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RodOfSecurity2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-security", null, 0, MagicItemType.Rod, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Verga della sicurezza", "Verga, molto rara",
			"Mentre il personaggio impugna questa verga, può usare un'azione per attivarla. La verga trasporta istantaneamente il personaggio e un massimo di altre 199 creature consenzienti e che è in grado di vedere in un paradiso situato in uno spazio extraplanare. È il personaggio a scegliere la forma che il paradiso assume. Potrebbe trattarsi di un giardino tranquillo, un'incantevole radura, un'allegra taverna, un palazzo immenso, un'isola tropicale, una fantastica fiera o qualsiasi altra cosa possa immaginare. A prescindere dalla sua natura, il paradiso contiene acqua e cibo sufficienti per soddisfare i bisogni dei visitatori. Ogni altra cosa con cui è possibile interagire in questo spazio extraplanare può esistere solamente al suo interno. Per esempio, un fiore colto in un giardino del paradiso scompare se portato fuori dallo spazio extraplanare.\n\nPer ogni ora passata nel paradiso, un visitatore recupera punti ferita come se avesse speso 1 Dado Vita. Inoltre, le creature non invecchiano mentre si trovano in tale luogo, sebbene il tempo scorra normalmente. I visitatori possono rimanere nel paradiso fino a un massimo di 200 giorni suddivisi per il numero delle creature presenti (arrotondato per difetto).\n\nQuando il tempo si esaurisce o il personaggio usa un'azione per terminare l'effetto, tutti i visitatori ricompaiono nello spazio che occupavano quando il personaggio ha attivato la verga o nello spazio libero più vicino. La verga non può essere riutilizzata finché non sono trascorsi 10 giorni."),
			("Rod of Security", "Rod, very rare",
			"While holding this rod, you can use an action to activate it. The rod then instantly transports you and up to 199 other willing creatures you can see to a paradise that exists in an extraplanar space. You choose the form that the paradise takes. It could be a tranquil garden, lovely glade, cheery tavern, immense palace, tropical island, fantastic carnival, or whatever else you can imagine. Regardless of its nature, the paradise contains enough water and food to sustain its visitors. Everything else that can be interacted with inside the extraplanar space can exist only there. For example, a flower picked from a garden in the paradise disappears if it is taken outside the extraplanar space.\n\nFor each hour spent in the paradise, a visitor regains hit points as if it had spent 1 Hit Die. Also, creatures don't age while in the paradise, although time passes normally. Visitors can remain in the paradise for up to 200 days divided by the number of creatures present (round down).\n\nWhen the time runs out or you use an action to end it, all visitors reappear in the location they occupied when you activated the rod, or an unoccupied space nearest that location. The rod can't be used again until ten days have passed.", null));
	}
}
