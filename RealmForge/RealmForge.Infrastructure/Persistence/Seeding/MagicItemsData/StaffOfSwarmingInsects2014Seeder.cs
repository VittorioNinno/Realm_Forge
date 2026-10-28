using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Swarming Insects (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfSwarmingInsects2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-swarming-insects", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Charges(10, ItemRecharge.LongRest, "1d6+4"),
			("Bastone dello sciame di insetti", "Bastone, raro (richiede sintonia con un bardo, un chierico, un druido, un mago, uno stregone o un warlock)",
			"Questo bastone possiede 10 cariche e, all'alba di ogni giorno, recupera 1d6 + 4 delle cariche spese. Se il personaggio consuma l'ultima carica, deve tirare un d20; se ottiene 1, uno sciame di insetti consuma e distrugge il bastone, poi si disperde.\n\n***Incantesimi.*** Mentre il personaggio impugna il bastone, può usare un'azione per consumare 1 o più delle sue cariche e lanciare uno dei seguenti incantesimi usando la CD del tiro salvezza sull'incantesimo: *insetto gigante* (4 cariche) o *piaga degli insetti* (5 cariche).\n\n***Nube di insetti.*** Mentre il personaggio impugna il bastone, può usare un'azione per consumare 1 carica e generare uno sciame di insetti volanti innocui che si diffonde in un raggio di 9 metri da lui. Gli insetti permangono per 10 minuti, rendendo l'area pesantemente oscurata per ogni altra creatura a eccezione del personaggio. Lo sciame si muove con il personaggio e rimane centrato su di lui. Un vento di intensità pari o superiore a 15 km orari disperde lo sciame e pone fine all'effetto."),
			("Staff of Swarming Insects", "Staff, very rare (requires attunement by a bard, cleric, druid, sorcerer, warlock, or wizard)",
			"This staff has 10 charges and regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, a swarm of insects consumes and destroys the staff, then disperses.\n\n***Spells.*** While holding the staff, you can use an action to expend some of its charges to cast one of the following spells from it, using your spell save DC: giant insect (4 charges) or insect plague (5 charges).\n\n***Insect Cloud.*** While holding the staff, you can use an action and expend 1 charge to cause a swarm of harmless flying insects to spread out in a 30-foot radius from you. The insects remain for 10 minutes, making the area heavily obscured for creatures other than you. The swarm moves with you, remaining centered on you. A wind of at least 10 miles per hour disperses the swarm and ends the effect.", null));
	}
}
