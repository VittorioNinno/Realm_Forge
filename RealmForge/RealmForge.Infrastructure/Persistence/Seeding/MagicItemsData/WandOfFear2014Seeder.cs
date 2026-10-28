using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Fear (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfFear2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-fear", null, 0, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta della paura", "Bacchetta, rara (richiede sintonia)",
			"Questa bacchetta possiede 7 cariche per le seguenti proprietà. All'alba di ogni giorno, recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta.\n\n***Comando.*** Mentre il personaggio impugna la bacchetta, può usare un'azione e consumare 1 carica per ordinare a un'altra creatura di fuggire o di supplicare, come se avesse lanciato l'incantesimo *comando* (CD del tiro salvezza 15).\n\n***Cono di paura.*** Mentre il personaggio impugna la bacchetta, può usare un'azione e consumare 2 cariche e proiettare dalla punta della bacchetta un cono di 18 metri di luce ambrata. Ogni creatura entro il cono deve superare un tiro salvezza su Saggezza con CD 15, altrimenti diventa spaventata dal personaggio per 1 minuto. Una creatura spaventata deve spendere i suoi turni tentando di allontanarsi il più possibile dal personaggio e non può volontariamente muoversi in uno spazio entro 9 metri da lui. Inoltre, non può effettuare reazioni. Come azione, può usare solo l'azione di Scatto o tentare di fuggire da un effetto che le impedisce di muoversi. Se non può muoversi in alcuno spazio, la creatura può usare l'azione Schivata. Alla fine di ogni suo turno, la creatura può ripetere un tiro salvezza e, se lo supera, l'effetto per lei svanisce."),
			("Wand of Fear", "Wand, rare (requires attunement)",
			"This wand has 7 charges for the following properties. It regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.\n\n***Command.*** While holding the wand, you can use an action to expend 1 charge and command another creature to flee or grovel, as with the command spell (save DC 15).\n\n***Cone of Fear.*** While holding the wand, you can use an action to expend 2 charges, causing the wand's tip to emit a 60-foot cone of amber light. Each creature in the cone must succeed on a DC 15 Wisdom saving throw or become frightened of you for 1 minute. While it is frightened in this way, a creature must spend its turns trying to move as far away from you as it can, and it can't willingly move to a space within 30 feet of you. It also can't take reactions. For its action, it can use only the Dash action or try to escape from an effect that prevents it from moving. If it has nowhere it can move, the creature can use the Dodge action. At the end of each of its turns, a creature can repeat the saving throw, ending the effect on itself on a success.", null));
	}
}
