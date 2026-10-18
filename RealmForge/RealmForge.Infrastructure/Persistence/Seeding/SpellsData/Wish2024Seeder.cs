using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wish (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Wish2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wish");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wish", "en"),
					Language = LanguageCode.En,
					Name = "Wish",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "*Wish* is the mightiest spell a mortal can cast. By simply speaking aloud, you can alter reality itself.\n\nThe basic use of this spell is to duplicate any other spell of level 8 or lower. If you use it this way, you don't need to meet any requirements to cast that spell, including costly components. The spell simply takes effect.\n\nAlternatively, you can create one of the following effects of your choice:\n\n**Object Creation.** You create one object of up to 25,000 GP in value that isn't a magic item. The object can be no more than 300 feet in any dimension, and it appears in an unoccupied space that you can see on the ground.\n\n**Instant Health.** You allow yourself and up to twenty creatures that you can see to regain all Hit Points, and you end all effects on them listed in the *Greater Restoration* spell.\n\n**Resistance.** You grant up to ten creatures that you can see Resistance to one damage type that you choose. This Resistance is permanent.\n\n**Spell Immunity.** You grant up to ten creatures you can see immunity to a single spell or other magical effect for 8 hours.\n\n**Sudden Learning.** You replace one of your feats with another feat for which you are eligible. You lose all the benefits of the old feat and gain the benefits of the new one. You can't replace a feat that is a prerequisite for any of your other feats or features.\n\n**Roll Redo.** You undo a single recent event by forcing a reroll of any die roll made within the last round (including your last turn). Reality reshapes itself to accommodate the new result. For example, a *Wish* spell could undo an ally's failed saving throw or a foe's Critical Hit. You can force the reroll to be made with Advantage or Disadvantage, and you choose whether to use the reroll or the original roll.\n\n**Reshape Reality.** You may wish for something not included in any of the other effects. To do so, state your wish to the GM as precisely as possible. The GM has great latitude in ruling what occurs in such an instance; the greater the wish, the greater the likelihood that something goes wrong. This spell might simply fail, the effect you desire might be achieved only in part, or you might suffer an unforeseen consequence as a result of how you worded the wish. For example, wishing that a villain were dead might propel you forward in time to a period when that villain is no longer alive, effectively removing you from the game.\n\nSimilarly, wishing for a Legendary magic item or an Artifact might instantly transport you to the presence of the item's current owner. If your wish is granted and its effects have consequences for a whole community, region, or world, you are likely to attract powerful foes. If your wish would affect a god, the god's divine servants might instantly intervene to prevent it or to encourage you to craft the wish in a particular way. If your wish would undo the multiverse itself, your wish fails.\n\nThe stress of casting *Wish* to produce any effect other than duplicating another spell weakens you. After enduring that stress, each time you cast a spell until you finish a Long Rest, you take 1d10 Necrotic damage per level of that spell. This damage can't be reduced or prevented in any way. In addition, your Strength score becomes 3 for 2d4 days. For each of those days that you spend resting and doing nothing more than light activity, your remaining recovery time decreases by 2 days. Finally, there is a 33 percent chance that you are unable to cast *Wish* ever again if you suffer this stress.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wish", "it"),
					Language = LanguageCode.It,
					Name = "Desiderio",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "*Desiderio* è l'incantesimo più potente che un mortale possa lanciare. Semplicemente parlando ad alta voce, l'incantatore può alterare la realtà stessa.\n\nL'uso base di questo incantesimo consiste nel duplicare qualsiasi altro incantesimo di 8° livello o inferiore. Se lo usa in questo modo, l'incantatore non deve soddisfare alcun requisito per lanciare quell'incantesimo, comprese le componenti costose. L'incantesimo ha semplicemente effetto.\n\nIn alternativa, l'incantatore può creare uno degli effetti seguenti, a sua scelta:\n\n**Creazione di Oggetti.** L'incantatore crea un oggetto del valore massimo di 25.000 mo che non sia un oggetto magico. L'oggetto non può superare i 90 metri in nessuna dimensione e compare in uno spazio libero sul terreno che l'incantatore è in grado di vedere.\n\n**Salute Istantanea.** L'incantatore permette a sé stesso e a un massimo di venti creature che è in grado di vedere di recuperare tutti i punti ferita, e pone fine su di esse a tutti gli effetti elencati nell'incantesimo *ristorare superiore*.\n\n**Resistenza.** L'incantatore conferisce a un massimo di dieci creature che è in grado di vedere resistenza a un tipo di danni a sua scelta. Questa resistenza è permanente.\n\n**Immunità agli Incantesimi.** L'incantatore conferisce a un massimo di dieci creature che è in grado di vedere l'immunità a un singolo incantesimo o a un altro effetto magico per 8 ore.\n\n**Apprendimento Improvviso.** L'incantatore sostituisce uno dei propri talenti con un altro talento per cui soddisfa i requisiti. Perde tutti i benefici del vecchio talento e ottiene i benefici di quello nuovo. Non può sostituire un talento che è prerequisito per uno qualsiasi dei suoi altri talenti o privilegi.\n\n**Ripetere il Tiro.** L'incantatore annulla un singolo evento recente costringendo a ripetere qualsiasi tiro di dado effettuato nell'ultimo round (incluso il suo ultimo turno). La realtà si rimodella per adattarsi al nuovo risultato. Per esempio, un incantesimo *desiderio* potrebbe annullare un tiro salvezza fallito da un alleato o un colpo critico di un nemico. L'incantatore può imporre che il nuovo tiro sia effettuato con vantaggio o con svantaggio, e sceglie se usare il nuovo tiro o quello originale.\n\n**Rimodellare la Realtà.** L'incantatore può desiderare qualcosa che non è incluso in nessuno degli altri effetti. Per farlo, espone il proprio desiderio al DM nel modo più preciso possibile. Il DM ha ampia libertà nello stabilire cosa accade in un caso del genere: più grande è il desiderio, maggiore è la probabilità che qualcosa vada storto. L'incantesimo potrebbe semplicemente fallire, l'effetto desiderato potrebbe realizzarsi solo in parte, oppure l'incantatore potrebbe subire una conseguenza imprevista a causa del modo in cui ha formulato il desiderio. Per esempio, desiderare che un malvagio sia morto potrebbe proiettare l'incantatore avanti nel tempo, in un periodo in cui quel malvagio non è più in vita, rimuovendolo di fatto dal gioco.\n\nAllo stesso modo, desiderare un oggetto magico leggendario o un artefatto potrebbe trasportare istantaneamente l'incantatore al cospetto dell'attuale proprietario dell'oggetto. Se il desiderio viene esaudito e i suoi effetti hanno conseguenze per un'intera comunità, regione o mondo, è probabile che l'incantatore attiri nemici potenti. Se il desiderio influenzasse un dio, i servitori divini del dio potrebbero intervenire immediatamente per impedirlo o per spingere l'incantatore a formularlo in un modo particolare. Se il desiderio annullasse il multiverso stesso, il desiderio fallisce.\n\nLo sforzo di lanciare *desiderio* per produrre qualsiasi effetto diverso dalla duplicazione di un altro incantesimo indebolisce l'incantatore. Dopo aver sopportato questo sforzo, ogni volta che lancia un incantesimo finché non termina un riposo lungo, l'incantatore subisce 1d10 danni necrotici per ogni livello di quell'incantesimo. Questi danni non possono essere ridotti o prevenuti in alcun modo. Inoltre, il suo punteggio di Forza diventa 3 per 2d4 giorni. Per ognuno di quei giorni trascorso riposando e svolgendo soltanto attività leggere, il tempo di recupero rimanente diminuisce di 2 giorni. Infine, se subisce questo sforzo, c'è una probabilità del 33 per cento che l'incantatore non sia più in grado di lanciare *desiderio*.",
					HigherLevels = null
				}
			}
		};
	}
}
