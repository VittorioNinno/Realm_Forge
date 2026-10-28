using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Instant Fortress (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class InstantFortress2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("instant-fortress", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Fortezza istantanea", "Oggetto meraviglioso, raro",
			"Il personaggio può usare un'azione per posare a terra questo cubo metallico con spigolo di 2,5 cm e pronunciarne la parola d'ordine. Il cubo cresce rapidamente fino a trasformarsi in una fortezza che permane fino a quando il personaggio, usando un'azione, non pronuncia la parola d'ordine che la disattiva. La fortezza si disattiva solo se è vuota.\n\nLa fortezza è una torre con base quadrata di 6 metri di lato, alta 9 metri e fornita di feritoie su i lati e parapetti sulla sommità. All'interno è divisa in due piani, collegati da una scala a pioli che corre lungo una delle pareti. La scala termina in corrispondenza di una botola che conduce al tetto. Quando viene attivata, la torre rivela una piccola porta d'ingresso che si apre sul lato posizionato di fronte al personaggio. La porta si apre solo su ordine del personaggio, che può pronunciare tale ordine come azione bonus. La porta è immune all'incantesimo *scassinare* e altre magie simili, come quelle di una *campana dell'apertura.*\n\nOgni creatura situata nell'area in cui la fortezza compare deve effettuare un tiro salvezza su Destrezza con CD 15: subisce 10d10 danni contundenti in caso di fallimento, o la metà dei danni in caso di successo. In entrambi i casi, la creatura viene spinta in uno spazio libero esterno accanto alla fortezza. Gli oggetti presenti nell'area che non sono indossati o trasportati subiscono questi danni e vengono spinti via automaticamente.\n\nLa torre è fatta di adamantio e la sua magia le impedisce di venire rovesciata. Il tetto, la porta e le pareti hanno 100 punti ferita ciascuno, immunità ai danni inflitti da armi non magiche, con l'eccezione delle armi d'assedio, e resistenza a tutti gli altri danni. La fortezza può essere riparata solo tramite un incantesimo *desiderio* (quest'uso dell'incantesimo conta come riproduzione di un incantesimo di 8° livello o inferiore). Ogni lancio dell'incantesimo *desiderio* fa recuperare 50 punti ferita al tetto, alla porta o a una delle pareti."),
			("Instant Fortress", "Wondrous item, rare",
			"You can use an action to place this 1-inch metal cube on the ground and speak its command word. The cube rapidly grows into a fortress that remains until you use an action to speak the command word that dismisses it, which works only if the fortress is empty.\n\nThe fortress is a square tower, 20 feet on a side and 30 feet high, with arrow slits on all sides and a battlement atop it. Its interior is divided into two floors, with a ladder running along one wall to connect them. The ladder ends at a trapdoor leading to the roof. When activated, the tower has a small door on the side facing you. The door opens only at your command, which you can speak as a bonus action. It is immune to the knock spell and similar magic, such as that of a chime of opening.\n\nEach creature in the area where the fortress appears must make a DC 15 Dexterity saving throw, taking 10d10 bludgeoning damage on a failed save, or half as much damage on a successful one. In either case, the creature is pushed to an unoccupied space outside but next to the fortress. Objects in the area that aren't being worn or carried take this damage and are pushed automatically.\n\nThe tower is made of adamantine, and its magic prevents it from being tipped over. The roof, the door, and the walls each have 100 hit points,\n\nimmunity to damage from nonmagical weapons excluding siege weapons, and resistance to all other damage. Only a wish spell can repair the fortress (this use of the spell counts as replicating a spell of 8th level or lower). Each casting of wish causes the roof, the door, or one wall to regain 50 hit points.", "Daern's Instant Fortress"));
	}
}
