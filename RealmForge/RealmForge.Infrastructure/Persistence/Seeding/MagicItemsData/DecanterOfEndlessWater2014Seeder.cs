using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Decanter of Endless Water (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DecanterOfEndlessWater2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("decanter-of-endless-water", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Caraffa dell'acqua eterna", "Oggetto meraviglioso, non comune",
			"Quando si scuote quest'ampolla chiusa da un tappo di sughero, si sente uno sciabordio, come se contenesse dell'acqua. Quest'oggetto pesa 2,5 kg.\n\nCon un'azione, il personaggio può rimuovere il tappo e pronunciare una delle tre possibili parole d'ordine, nel qual caso dall'ampolla esce una certa quantità di acqua potabile o salata (a scelta del personaggio). L'acqua smette di uscire all'inizio del turno successivo del personaggio. Scegli tra una delle seguenti opzioni:\n\n- \"Ruscello\" produce 4 litri d'acqua.\n\n- \"Fontana\" produce 20 litri d'acqua.\n\n- \"Geyser\" produce 120 litri d'acqua che scaturiscono in un getto lungo 9 metri e largo 30 cm. Come azione bonus, mentre tiene in mano la caraffa, il personaggio può orientare il getto verso una creatura che è in grado di vedere situata entro 9 metri da lui. Il bersaglio deve superare un tiro salvezza su Forza con CD 13, altrimenti subisce 1d4 danni contundenti e cade a terra prono. In alternativa, il personaggio può dirigere il getto contro un oggetto che non sia indossato o trasportato e che non pesi più di 100 kg.\n\nL'oggetto viene rovesciato o spinto fino a 4,5 metri\n\ndal personaggio."),
			("Decanter of Endless Water", "Wondrous item, uncommon",
			"This stoppered flask sloshes when shaken, as if it contains water. The decanter weighs 2 pounds.\n\nYou can use an action to remove the stopper and speak one of three command words, whereupon an amount of fresh water or salt water (your choice) pours out of the flask. The water stops pouring out at the start of your next turn. Choose from the following options:\n\n\"Stream\" produces 1 gallon of water.\n\n\"Fountain\" produces 5 gallons of water.\n\n\"Geyser\" produces 30 gallons of water that gushes forth in a geyser 30 feet long and 1 foot wide. As a bonus action while holding the decanter, you can aim the geyser at a creature you can see within 30 feet of you. The target must succeed on a DC 13 Strength saving throw or take 1d4 bludgeoning damage and fall prone. Instead of a creature, you can target an object that isn't being worn or carried and that weighs no more than 200 pounds. The object is either knocked over or pushed up to 15 feet away from you.", null));
	}
}
