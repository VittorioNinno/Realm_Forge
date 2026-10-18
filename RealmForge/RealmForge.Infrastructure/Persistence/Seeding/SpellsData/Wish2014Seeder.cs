using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wish (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Wish2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wish");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wish", "en"),
					Language = LanguageCode.En,
					Name = "Wish",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Wish is the mightiest spell a mortal creature can cast. By simply speaking aloud, you can alter the very foundations of reality in accord with your desires.\n\nThe basic use of this spell is to duplicate any other spell of 8th level or lower. You don't need to meet any requirements in that spell, including costly components. The spell simply takes effect.\n\nAlternatively, you can create one of the following effects of your choice:\n\n- You create one object of up to 25,000 gp in value that isn't a magic item. The object can be no more than 300 feet in any dimension, and it appears in an unoccupied space you can see on the ground.\n\n- You allow up to twenty creatures that you can see to regain all hit points, and you end all effects on them described in the greater restoration spell.\n\n- You grant up to ten creatures that you can see resistance to a damage type you choose.\n\n- You grant up to ten creatures you can see immunity to a single spell or other magical effect for 8 hours. For instance, you could make yourself and all your companions immune to a lich's life drain attack.\n\n- You undo a single recent event by forcing a reroll of any roll made within the last round (including your last turn). Reality reshapes itself to accommodate the new result. For example, a wish spell could undo an opponent's successful save, a foe's critical hit, or a friend's failed save. You can force the reroll to be made with advantage or disadvantage, and you can choose whether to use the reroll or the original roll.\n\nYou might be able to achieve something beyond the scope of the above examples. State your wish to the GM as precisely as possible. The GM has great latitude in ruling what occurs in such an instance; the greater the wish, the greater the likelihood that something goes wrong. This spell might simply fail, the effect you desire might only be partly achieved, or you might suffer some unforeseen consequence as a result of how you worded the wish. For example, wishing that a villain were dead might propel you forward in time to a period when that villain is no longer alive, effectively removing you from the game. Similarly, wishing for a legendary magic item or artifact might instantly transport you to the presence of the item's current owner.\n\nThe stress of casting this spell to produce any effect other than duplicating another spell weakens you. After enduring that stress, each time you cast a spell until you finish a long rest, you take 1d10 necrotic damage per level of that spell. This damage can't be reduced or prevented in any way. In addition, your Strength drops to 3, if it isn't 3 or lower already, for 2d4 days. For each of those days that you spend resting and doing nothing more than light activity, your remaining recovery time decreases by 2 days. Finally, there is a 33 percent chance that you are unable to cast wish ever again if you suffer this stress.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wish", "it"),
					Language = LanguageCode.It,
					Name = "Desiderio",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Desiderio è l'incantesimo più potente che una creatura mortale possa lanciare. Semplicemente parlando ad alta voce, l'incantatore può alterare le fondamenta stesse della realtà secondo i propri desideri.\n\nL'uso base di questo incantesimo consiste nel replicare qualsiasi altro incantesimo di 8° livello o inferiore. L'incantatore non deve soddisfare alcun requisito di quell'incantesimo, comprese le componenti costose. L'incantesimo ha semplicemente effetto.\n\nIn alternativa, l'incantatore può creare uno degli effetti seguenti, a sua scelta:\n\n- Crea un oggetto del valore massimo di 25.000 mo che non sia un oggetto magico. Le dimensioni dell'oggetto non possono superare i 90 metri in nessuna direzione, e l'oggetto compare in uno spazio libero sul terreno che l'incantatore è in grado di vedere.\n\n- Permette a un massimo di venti creature che è in grado di vedere di recuperare tutti i punti ferita, e pone fine a tutti gli effetti su di esse descritti nell'incantesimo ristorare superiore.\n\n- Conferisce a un massimo di dieci creature che è in grado di vedere resistenza a un tipo di danno a sua scelta.\n\n- Conferisce a un massimo di dieci creature che è in grado di vedere l'immunità a un singolo incantesimo o a un altro effetto magico per 8 ore. Per esempio, potrebbe rendere sé stesso e tutti i suoi compagni immuni all'attacco risucchio vitale di un lich.\n\n- Annulla un singolo evento recente, imponendo di ripetere qualsiasi tiro effettuato nell'ultimo round (compreso il suo ultimo turno). La realtà si rimodella per adattarsi al nuovo risultato. Per esempio, un incantesimo desiderio potrebbe annullare il tiro salvezza riuscito di un avversario, il colpo critico di un nemico o il tiro salvezza fallito di un amico. L'incantatore può imporre che il nuovo tiro sia effettuato con vantaggio o con svantaggio, e può scegliere se usare il nuovo tiro o quello originale.\n\nL'incantatore potrebbe riuscire a ottenere qualcosa che va oltre la portata degli esempi precedenti. Deve formulare il suo desiderio al DM nel modo più preciso possibile. Il DM ha ampia libertà nello stabilire cosa accade in un caso simile; più grande è il desiderio, maggiore è la probabilità che qualcosa vada storto. L'incantesimo potrebbe semplicemente fallire, l'effetto desiderato potrebbe realizzarsi solo in parte, oppure l'incantatore potrebbe subire qualche conseguenza imprevista a causa del modo in cui ha formulato il desiderio. Per esempio, desiderare la morte di un malvagio potrebbe proiettare l'incantatore in avanti nel tempo, fino a un'epoca in cui quel malvagio non è più in vita, rimuovendolo di fatto dal gioco. Allo stesso modo, desiderare un oggetto magico leggendario o un artefatto potrebbe trasportare istantaneamente l'incantatore al cospetto dell'attuale proprietario dell'oggetto.\n\nLo sforzo di lanciare questo incantesimo per produrre un effetto diverso dalla replica di un altro incantesimo indebolisce l'incantatore. Dopo aver sopportato quello sforzo, ogni volta che lancia un incantesimo prima di terminare un riposo lungo, subisce 1d10 danni necrotici per ogni livello di quell'incantesimo. Questi danni non possono essere ridotti o prevenuti in alcun modo. Inoltre, la sua Forza scende a 3, se non è già pari o inferiore a 3, per 2d4 giorni. Per ognuno di quei giorni trascorso a riposare e a svolgere soltanto attività leggere, il tempo di recupero rimanente si riduce di 2 giorni. Infine, se subisce questo sforzo, c'è una probabilità del 33 per cento che l'incantatore non sia più in grado di lanciare desiderio.",
					HigherLevels = null
				}
			}
		};
	}
}
