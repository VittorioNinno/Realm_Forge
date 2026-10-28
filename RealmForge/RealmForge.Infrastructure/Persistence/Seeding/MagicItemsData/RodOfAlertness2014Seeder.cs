using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of Alertness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RodOfAlertness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-alertness", null, 0, MagicItemType.Rod, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Verga dell'allerta", "Verga, molto rara (richiede sintonia)",
			"Questa verga ha una testa flangiata e possiede le seguenti proprietà:\n\n***Allerta.*** Mentre il personaggio impugna la verga, dispone di vantaggio alle prove di Saggezza (Percezione) e ai tiri per l'iniziativa.\n\n***Incantesimi.*** Mentre il personaggio impugna la verga, può usare un'azione per lanciare con essa uno degli incantesimi seguenti: *individuazione del bene e del male, individuazione del magico, individuazione delle malattie e dei veleni* o *vedere invisibilità.*\n\n***Aura protettiva.*** Con un'azione, il personaggio può piantare l'asta della verga nel terreno; quando lo fa, l'estremità superiore della verga proietta luce intensa in un raggio di 18 metri e luce fioca per altri 18 metri. Finché il personaggio e ogni creatura amichevole nei suoi confronti si trovano entro il raggio di quella luce intensa, ottengono un bonus di +1 alla CA e ai tiri salvezza, e possono percepire la presenza di eventuali creature ostili invisibili che si trovano a loro volta entro la luce intensa.\n\nLa punta della verga smette di brillare e l'effetto termina dopo 10 minuti o quando una creatura usa un'azione per estrarre la verga dal terreno. Questa proprietà non può essere riutilizzata fino all'alba successiva.", null),
			("Rod of Alertness", "Rod, very rare (requires attunement)",
			"This rod has a flanged head and the following properties.\n\n***Alertness.*** While holding the rod, you have advantage on Wisdom (Perception) checks and on rolls for initiative.\n\n***Spells.*** While holding the rod, you can use an action to cast one of the following spells from it: detect evil and good, detect magic, detect poison and disease, or see invisibility.\n\n***Protective Aura.*** As an action, you can plant the haft end of the rod in the ground, whereupon the rod's head sheds bright light in a 60-foot radius and dim light for an additional 60 feet. While in that bright light, you and any creature that is friendly to you gain a +1 bonus to AC and saving throws and can sense the location of any invisible hostile creature that is also in the bright light.\n\nThe rod's head stops glowing and the effect ends after 10 minutes, or when a creature uses an action to pull the rod from the ground. This property can't be used again until the next dawn.", null));
	}
}
