using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Pipes of Haunting (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PipesOfHaunting2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("pipes-of-haunting", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Flauto incantatore", "Oggetto meraviglioso, non comune",
			"Per usare questo flauto, il personaggio deve essere competente negli strumenti a fiato. L'oggetto possiede 3 cariche. Il personaggio può usare un'azione per suonarlo e consumare 1 carica per creare una melodia strana e ipnotica. Ogni creatura entro un raggio di 9 metri da lui che sente tale melodia deve superare un tiro salvezza su Saggezza con CD 15, altrimenti rimane spaventata da lui per 1 minuto. Se il personaggio lo desidera, tutte le creature nell'area e non ostili nei suoi confronti superano automaticamente il tiro salvezza. Se una creatura fallisce il tiro salvezza può ripeterlo alla fine di ogni suo turno e, se lo supera, l'effetto per lei svanisce. Se una creatura supera il tiro salvezza, diventa immune all'effetto del flauto per 24 ore. Il flauto recupera 1d3 cariche consumate all'all'alba di ogni giorno."),
			("Pipes of Haunting", "Wondrous item, uncommon",
			"You must be proficient with wind instruments to use these pipes. They have 3 charges. You can use an action to play them and expend 1 charge to create an eerie, spellbinding tune. Each creature within 30 feet of you that hears you play must succeed on a DC 15 Wisdom saving throw or become frightened of you for 1 minute. If you wish, all creatures in the area that aren't hostile toward you automatically succeed on the saving throw. A creature that fails the saving throw can repeat it at the end of each of its turns, ending the effect on itself on a success. A creature that succeeds on its saving throw is immune to the effect of these pipes for 24 hours. The pipes regain 1d3 expended charges daily at dawn.", null));
	}
}
