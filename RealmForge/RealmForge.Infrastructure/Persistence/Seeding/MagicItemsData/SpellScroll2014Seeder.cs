using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Spell Scroll (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SpellScroll2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("spell-scroll", null, 0, MagicItemType.Scroll, null, false, ContentSource.Srd51,
			null,
			("Pergamena magica", "Pergamena, rarità variabile",
			"Una *pergamena magica* contiene le parole di un unico incantesimo, scritto in un linguaggio mistico. Se l'incantesimo è nella lista degli incantesimi della classe del personaggio, quest'ultimo può leggere la pergamena e lanciare l'incantesimo senza fornire componenti materiali. In caso contrario, la pergamena è incomprensibile. Lanciare l'incantesimo leggendo la pergamena richiede il normale tempo di lancio dell'incantesimo. Una volta lanciato l'incantesimo, le parole svaniscono e la pergamena si polverizza. Se il lancio viene interrotto, la pergamena non viene perduta.\n\nSe l'incantesimo si trova sulla lista degli incantesimi della classe del personaggio, ma è di un livello più alto rispetto a quelli che può lanciare normalmente, il personaggio deve effettuare una prova di caratteristica usando la sua caratteristica da incantatore per determinare se riesce a lanciarlo. La CD è pari a 10 + il livello dell'incantesimo. In caso di fallimento, l'incantesimo scompare dalla pergamena senza alcun altro effetto.\n\nIl livello dell'incantesimo sulla pergamena determina la CD del tiro salvezza dell'incantesimo e il bonus di attacco, così come la rarità della pergamena, come illustrato nella tabella Pergamena magica.\n\n**Pergamena magica**\n\n| Livello dell'incantesimo | Rarità | CD Tiro Salvezza | Bonus di Attacco |\n|---|---|---|---|\n| Trucchetto | Comune | 13 | +5 |\n| 1° | Comune | 13 | +5 |\n| 2° | Non comune | 13 | +5 |\n| 3° | Non comune | 15 | +7 |\n| 4° | Rara | 15 | +7 |\n| 5° | Rara | 17 | +9 |\n| 6° | Molto rara | 17 | +9 |\n| 7° | Molto rara | 18 | +10 |\n| 8° | Molto rara | 18 | +10 |\n| 9° | Leggendaria | 19 | +11 |\n\nUn incantesimo da mago su una *pergamena magica* può essere copiato allo stesso modo di quelli contenuti in un libro degli incantesimi. Per copiare un incantesimo da una *pergamena magica,* chi lo copia deve superare una prova di Intelligenza (Arcano) con CD pari a 10 + il livello dell'incantesimo. Se supera la prova, copia l'incantesimo con successo. A prescindere dal risultato della prova, la *pergamena magica* viene distrutta."),
			("Spell Scroll", "Scroll, varies",
			"A spell scroll bears the words of a single spell, written in a mystical cipher. If the spell is on your class's spell list, you can read the scroll and cast its spell without providing any material components. Otherwise, the scroll is unintelligible. Casting the spell by reading the scroll requires the spell's normal casting time. Once the spell is cast, the words on the scroll fade, and it crumbles to dust. If the casting is uninterrupted, the scroll is not lost.\n\nIf the spell is on your class's spell list but of a higher level than you can normally cast, you must make an ability check using your spellcasting ability to determine whether you cast it successfully. The DC equals 10 + the spell's level. On a failed check, the spell disappears from the scroll with no other effect.\n\nThe level of the spell on the scroll determines the spell's saving throw DC and attack bonus, as well as the scroll's rarity, as shown in the Spell Scroll table.\n\n**Spell Scroll**\n\n| Spell Level | Rarity | Save DC | Attack Bonus |\n|---|---|---|---|\n| Cantrip | Common | 13 | +5 |\n| 1st | Common | 13 | +5 |\n| 2nd | Uncommon | 13 | +5 |\n| 3rd | Uncommon | 15 | +7 |\n| 4th | Rare | 15 | +7 |\n| 5th | Rare | 17 | +9 |\n| 6th | Very rare | 17 | +9 |\n| 7th | Very rare | 18 | +10 |\n| 8th | Very rare | 18 | +10 |\n| 9th | Legendary | 19 | +11 |\n\nA wizard spell on a spell scroll can be copied just as spells in spellbooks can be copied. When a spell is copied from a spell scroll, the copier must succeed on an Intelligence (Arcana) check with a DC equal to 10 + the spell's level. If the check succeeds, the spell is successfully copied. Whether the check succeeds or fails, the spell scroll is destroyed.", null));
		yield return Item("spell-scroll-cantrip", "spell-scroll", 1, MagicItemType.Scroll, ItemRarity.Common, false, ContentSource.Srd51,
			null,
			("Pergamena magica (trucchetto)", "Pergamena, comune",
			""),
			("Spell Scroll (Cantrip)", "Scroll, common",
			"", null));
		yield return Item("spell-scroll-1st", "spell-scroll", 2, MagicItemType.Scroll, ItemRarity.Common, false, ContentSource.Srd51,
			null,
			("Pergamena magica (1° livello)", "Pergamena, comune",
			""),
			("Spell Scroll (1st)", "Scroll, common",
			"", null));
		yield return Item("spell-scroll-2nd", "spell-scroll", 3, MagicItemType.Scroll, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pergamena magica (2° livello)", "Pergamena, non comune",
			""),
			("Spell Scroll (2nd)", "Scroll, uncommon",
			"", null));
		yield return Item("spell-scroll-3rd", "spell-scroll", 4, MagicItemType.Scroll, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pergamena magica (3° livello)", "Pergamena, non comune",
			""),
			("Spell Scroll (3rd)", "Scroll, uncommon",
			"", null));
		yield return Item("spell-scroll-4th", "spell-scroll", 5, MagicItemType.Scroll, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pergamena magica (4° livello)", "Pergamena, rara",
			""),
			("Spell Scroll (4th)", "Scroll, rare",
			"", null));
		yield return Item("spell-scroll-5th", "spell-scroll", 6, MagicItemType.Scroll, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pergamena magica (5° livello)", "Pergamena, rara",
			""),
			("Spell Scroll (5th)", "Scroll, rare",
			"", null));
		yield return Item("spell-scroll-6th", "spell-scroll", 7, MagicItemType.Scroll, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pergamena magica (6° livello)", "Pergamena, molto rara",
			""),
			("Spell Scroll (6th)", "Scroll, very rare",
			"", null));
		yield return Item("spell-scroll-7th", "spell-scroll", 8, MagicItemType.Scroll, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pergamena magica (7° livello)", "Pergamena, molto rara",
			""),
			("Spell Scroll (7th)", "Scroll, very rare",
			"", null));
		yield return Item("spell-scroll-8th", "spell-scroll", 9, MagicItemType.Scroll, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pergamena magica (8° livello)", "Pergamena, molto rara",
			""),
			("Spell Scroll (8th)", "Scroll, very rare",
			"", null));
		yield return Item("spell-scroll-9th", "spell-scroll", 10, MagicItemType.Scroll, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Pergamena magica (9° livello)", "Pergamena, leggendaria",
			""),
			("Spell Scroll (9th)", "Scroll, legendary",
			"", null));
	}
}
