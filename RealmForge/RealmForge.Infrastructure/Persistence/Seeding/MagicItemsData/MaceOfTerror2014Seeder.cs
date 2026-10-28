using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mace of Terror (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MaceOfTerror2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mace-of-terror", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Mazza del terrore", "Arma (mazza), rara (richiede sintonia)",
			"Quest'arma magica possiede 3 cariche. Mentre la impugna, il personaggio può usare un'azione e consumare 1 carica per sprigionare un'ondata di terrore. Tutte le creature scelte dal personaggio e situate in un raggio di 9 metri da lui devono superare un tiro salvezza su Saggezza con CD 15, altrimenti diventano spaventate da lui per 1 minuto. Una creatura spaventata deve spendere i suoi turni tentando di allontanarsi il più possibile dal personaggio e non può volontariamente muoversi in uno spazio entro 9 metri da lui. Inoltre, non può effettuare reazioni. Come azione, può usare solo l'azione di Scatto o tentare di fuggire da un effetto che le impedisce di muoversi. Se non può muoversi in alcuno spazio, la creatura può usare l'azione Schivata. Alla fine di ogni suo turno, la creatura può ripetere un tiro salvezza e, se lo supera, l'effetto per lei svanisce.\n\nLa mazza recupera 1d3 cariche consumate all'alba di ogni giorno.", null),
			("Mace of Terror", "Weapon (mace), rare (requires attunement)",
			"This magic weapon has 3 charges. While holding it, you can use an action and expend 1 charge to release a wave of terror. Each creature of your choice in a 30-foot radius extending from you must succeed on a DC 15 Wisdom saving throw or become frightened of you for 1 minute. While it is frightened in this way, a creature must spend its turns trying to move as far away from you as it can, and it can't willingly move to a space within 30 feet of you. It also can't take reactions. For its action, it can use only the Dash action or try to escape from an effect that prevents it from moving. If it has nowhere it can move, the creature can use the Dodge action. At the end of each of its turns, a creature can repeat the saving throw, ending the effect on itself on a success.\n\nThe mace regains 1d3 expended charges daily at dawn.", null));
	}
}
