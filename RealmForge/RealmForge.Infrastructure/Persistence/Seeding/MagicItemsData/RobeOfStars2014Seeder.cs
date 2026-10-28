using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Robe of Stars (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RobeOfStars2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("robe-of-stars", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.SavingThrows, 1)),
			("Tunica delle stelle", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"Su questa tunica, di colore nero o blu scuro, sono ricamate minuscole stelle bianche o argentate. Quando il personaggio la indossa, ottiene un bonus di +1 ai tiri salvezza.\n\nSei stelle nella parte anteriore della tunica, in alto, sono particolarmente grandi. Mentre il personaggio indossa questa tunica, può usare un'azione per staccare una delle stelle e usarla per lanciare *dardo incantato* come incantesimo di 5° livello. Ogni giorno al tramonto, 1d6 stelle rimosse ricompaiono sulla tunica.\n\nMentre il personaggio indossa la tunica può usare un'azione per entrare nel Piano Astrale insieme a tutto ciò che indossa e trasporta, e vi rimane finché non usa un'azione per tornare sul piano in cui si trovava prima. Il personaggio ricompare nell'ultimo spazio che occupava o, se è occupato, nello spazio libero più vicino."),
			("Robe of Stars", "Wondrous item, very rare (requires attunement)",
			"This black or dark blue robe is embroidered with small white or silver stars. You gain a +1 bonus to saving throws while you wear it.\n\nSix stars, located on the robe's upper front portion, are particularly large. While wearing this robe, you can use an action to pull off one of the stars and use it to cast magic missile as a 5th-level spell. Daily at dusk, 1d6 removed stars reappear on the robe.\n\nWhile you wear the robe, you can use an action to enter the Astral Plane along with everything you are wearing and carrying. You remain there until you use an action to return to the plane you were on. You reappear in the last space you occupied, or if that space is occupied, the nearest unoccupied space.", null));
	}
}
