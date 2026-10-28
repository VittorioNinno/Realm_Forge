using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Paralysis (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfParalysis2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-paralysis", null, 0, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta della paralisi", "Bacchetta, rara (richiede sintonia con un incantatore)",
			"Questa bacchetta possiede 7 cariche. Mentre il personaggio la impugna, può usare un'azione per consumare 1 carica e lanciare dalla punta della bacchetta un sottile raggio blu contro una creatura che è in grado di vedere situata entro 18 metri da lui. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 15, altrimenti rimane paralizzato per 1 minuto. Alla fine di ogni suo turno, la creatura può ripetere il tiro salvezza e, se lo supera, l'effetto svanisce.\n\nAll'alba di ogni giorno, la bacchetta recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta.", null),
			("Wand of Paralysis", "Wand, rare (requires attunement by a spellcaster)",
			"This wand has 7 charges. While holding it, you can use an action to expend 1 of its charges to cause a thin blue ray to streak from the tip toward a creature you can see within 60 feet of you. The target must succeed on a DC 15 Constitution saving throw or be paralyzed for 1 minute. At the end of each of the target's turns, it can repeat the saving throw, ending the effect on itself on a success.\n\nThe wand regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.", null));
	}
}
