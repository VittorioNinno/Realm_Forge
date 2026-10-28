using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of Binding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfBinding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-binding", null, 0, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(7, ItemRecharge.LongRest, "1d6+1"),
			("Bacchetta del legame", "Bacchetta, rara (richiede sintonia con un incantatore)",
			"Questa bacchetta possiede 7 cariche per le seguenti proprietà. All'alba di ogni giorno, recupera 1d6 + 1 cariche consumate. Se il personaggio consuma l'ultima carica, deve tirare un d20: se ottiene 1, la bacchetta diventa cenere e viene distrutta.\n\n***Incantesimi.*** Mentre il personaggio impugna la bacchetta, può usare un'azione e consumare alcune cariche per lanciare uno degli incantesimi seguenti (CD del tiro salvezza 17): *blocca mostri* (5 cariche) o *blocca persone* (2 cariche).\n\n***Fuga assistita.*** Mentre il personaggio impugna la bacchetta, può usare la sua reazione per consumare 1 carica e ottenere vantaggio a un tiro salvezza che effettua per evitare di diventare paralizzato o trattenuto; in alternativa, può consumare 1 carica e ottenere vantaggio a una qualsiasi prova effettuata per sfuggire a una lotta."),
			("Wand of Binding", "Wand, rare (requires attunement by a spellcaster)",
			"This wand has 7 charges for the following properties. It regains 1d6 + 1 expended charges daily at dawn. If you expend the wand's last charge, roll a d20. On a 1, the wand crumbles into ashes and is destroyed.\n\n***Spells.*** While holding the wand, you can use an action to expend some of its charges to cast one of the following spells (save DC 17): hold monster (5 charges) or hold person (2 charges).\n\n***Assisted Escape.*** While holding the wand, you can use your reaction to expend 1 charge and gain advantage on a saving throw you make to avoid being paralyzed or restrained, or you can expend 1 charge and gain advantage on any check you make to escape a grapple.", null));
	}
}
