using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Candle of Invocation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CandleOfInvocation2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("candle-of-invocation", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Candela dell'invocazione", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"Questa candela lunga e sottile è dedicata a una divinità, di cui condivide l'allineamento. L'allineamento della candela può essere determinato con l'incantesimo *individuazione del bene e del male.* Il GM può scegliere liberamente la divinità e il relativo allineamento della candela o determinare quest'ultimo casualmente.\n\n| d20 | Allineamento |\n|---|---|\n| 1–2 | Caotico malvagio |\n| 3–4 | Caotico neutrale |\n| 5–7 | Caotico buono |\n| 8–9 | Neutrale malvagio |\n| 10–11 | Neutrale |\n| 12–13 | Neutrale buono |\n| 14–15 | Legale malvagio |\n| 16–17 | Legale neutrale |\n| 18–20 | Legale buono |\n\nLa magia della candela si attiva quando la candela viene accesa; l'accensione richiede un'azione. La candela può ardere per 4 ore, dopodiché viene distrutta. Il personaggio può spegnerla prima che si esaurisca per usarla successivamente. Il tempo di utilizzo va sottratto in frazioni da 1 minuto dal tempo totale per cui la candela può ardere.\n\nMentre è accesa, la candela proietta luce fioca entro un raggio di 9 metri. Tutte le creature illuminate dalla luce e il cui allineamento corrisponde a quello della candela dispongono di vantaggio ai tiri per colpire, ai tiri salvezza e alle prove di caratteristica. Inoltre, chierici e druidi nell'area illuminata con allineamento corrispondente a quello della candela possono lanciare gli incantesimi preparati di 1° livello senza consumare slot incantesimo, anche se i loro effetti saranno considerati pari a quelli lanciati con uno slot di 1° livello.\n\nIn alternativa, quando un personaggio accende la candela per la prima volta, può usarla per lanciare l'incantesimo *portale.* In questo modo la candela viene distrutta."),
			("Candle of Invocation", "Wondrous item, very rare (requires attunement)",
			"This slender taper is dedicated to a deity and shares that deity's alignment. The candle's alignment can be detected with the detect evil and good spell. The GM chooses the god and associated alignment or determines the alignment randomly.\n\n| d20 | Alignment |\n|---|---|\n| 1-2 | Chaotic evil |\n| 3-4 | Chaotic neutral |\n| 5-7 | Chaotic good |\n| 8-9 | Neutral evil |\n| 10-11 | Neutral |\n| 12-13 | Neutral good |\n| 14-15 | Lawful evil |\n| 16-17 | Lawful neutral |\n| 18-20 | Lawful good |\n\nThe candle's magic is activated when the candle is lit, which requires an action. After burning for 4 hours, the candle is destroyed. You can snuff it out early for use at a later time. Deduct the time it burned in increments of 1 minute from the candle's total burn time.\n\nWhile lit, the candle sheds dim light in a 30-foot radius. Any creature within that light whose alignment matches that of the candle makes attack rolls, saving throws, and ability checks with advantage. In addition, a cleric or druid in the light whose alignment matches the candle's can cast 1stlevel spells he or she has prepared without expending spell slots, though the spell's effect is as if cast with a 1st-level slot.\n\nAlternatively, when you light the candle for the first time, you can cast the gate spell with it. Doing so destroys the candle.", null));
	}
}
