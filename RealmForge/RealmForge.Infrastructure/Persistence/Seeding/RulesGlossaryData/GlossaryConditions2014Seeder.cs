using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.RulesGlossaryData;

///	<summary>
///	Conditions of the 2014 rules. English text from the SRD 5.1 (CC BY 4.0); the Italian texts are RealmForge
///	translations that use the official names of the Italian Player's Handbook.
///	</summary>
public static class GlossaryConditions2014Seeder
{
	public static IEnumerable<RuleEntry> Build()
	{
		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "blinded", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Blinded", "- A blinded creature can't see and automatically fails any ability check that requires sight.\n- Attack rolls against the creature have advantage, and the creature's attack rolls have disadvantage.",
				new[] { "blinded" }),
			it: ("Accecato", "- Una creatura accecata non è in grado di vedere e fallisce automaticamente le prove di caratteristica che richiedono la vista.\n- I tiri per colpire contro la creatura dispongono di vantaggio, mentre i tiri per colpire della creatura subiscono svantaggio.",
				new[] { "accecato", "accecata", "accecati", "accecate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "charmed", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Charmed", "- A charmed creature can't attack the charmer or target the charmer with harmful abilities or magical effects.\n- The charmer has advantage on any ability check to interact socially with the creature.",
				new[] { "charmed" }),
			it: ("Affascinato", "- Una creatura affascinata non può attaccare chi l'ha affascinata, né sceglierlo come bersaglio di capacità dannose o di effetti magici.\n- Chi l'ha affascinata dispone di vantaggio alle prove di caratteristica effettuate per interagire socialmente con la creatura.",
				new[] { "affascinato", "affascinata", "affascinati", "affascinate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "deafened", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Deafened", "- A deafened creature can't hear and automatically fails any ability check that requires hearing.",
				new[] { "deafened" }),
			it: ("Assordato", "- Una creatura assordata non è in grado di sentire e fallisce automaticamente le prove di caratteristica che richiedono l'udito.",
				new[] { "assordato", "assordata", "assordati", "assordate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "frightened", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Frightened", "- A frightened creature has disadvantage on ability checks and attack rolls while the source of its fear is within line of sight.\n- The creature can't willingly move closer to the source of its fear.",
				new[] { "frightened" }),
			it: ("Spaventato", "- Una creatura spaventata subisce svantaggio alle prove di caratteristica e ai tiri per colpire finché la fonte della sua paura si trova nella sua linea di vista.\n- La creatura non può avvicinarsi volontariamente alla fonte della sua paura.",
				new[] { "spaventato", "spaventata", "spaventati", "spaventate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "grappled", RuleCategory.Condition,
			related: new[] { "grappling" },
			en: ("Grappled", "- A grappled creature's speed becomes 0, and it can't benefit from any bonus to its speed.\n- The condition ends if the grappler is incapacitated.\n- The condition also ends if an effect removes the grappled creature from the reach of the grappler or grappling effect, such as when a creature is hurled away by the thunderwave spell.",
				new[] { "grappled" }),
			it: ("Afferrato", "- La velocità di una creatura afferrata diventa 0 e la creatura non può beneficiare di alcun bonus alla velocità.\n- La condizione termina se chi la sta afferrando diventa incapacitato.\n- La condizione termina anche se un effetto porta la creatura afferrata fuori dalla portata di chi la afferra o dell'effetto che la trattiene, come quando una creatura viene scagliata via dall'incantesimo _Onda Tonante_.",
				new[] { "afferrato", "afferrata", "afferrati", "afferrate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "incapacitated", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Incapacitated", "- An incapacitated creature can't take actions or reactions.",
				new[] { "incapacitated" }),
			it: ("Incapacitato", "- Una creatura incapacitata non può effettuare azioni o reazioni.",
				new[] { "incapacitato", "incapacitata", "incapacitati", "incapacitate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "invisible", RuleCategory.Condition,
			related: new[] { "unseen-attackers-and-targets", "hide" },
			en: ("Invisible", "- An invisible creature is impossible to see without the aid of magic or a special sense. For the purpose of hiding, the creature is heavily obscured. The creature's location can be detected by any noise it makes or any tracks it leaves.\n- Attack rolls against the creature have disadvantage, and the creature's attack rolls have advantage.",
				new[] { "invisible" }),
			it: ("Invisibile", "- Una creatura invisibile non può essere vista senza l'aiuto della magia o di un senso speciale. Ai fini del nascondersi, la creatura è considerata in un'area pesantemente oscurata. La sua posizione può comunque essere individuata dai rumori che produce o dalle tracce che lascia.\n- I tiri per colpire contro la creatura subiscono svantaggio, mentre i tiri per colpire della creatura dispongono di vantaggio.",
				new[] { "invisibile", "invisibili" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "paralyzed", RuleCategory.Condition,
			related: new[] { "incapacitated" },
			en: ("Paralyzed", "- A paralyzed creature is incapacitated and can't move or speak.\n- The creature automatically fails Strength and Dexterity saving throws.\n- Attack rolls against the creature have advantage.\n- Any attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.",
				new[] { "paralyzed" }),
			it: ("Paralizzato", "- Una creatura paralizzata è incapacitata e non può muoversi né parlare.\n- La creatura fallisce automaticamente i tiri salvezza su Forza e su Destrezza.\n- I tiri per colpire contro la creatura dispongono di vantaggio.\n- Qualsiasi attacco che colpisce la creatura è un colpo critico se l'attaccante si trova entro 1,5 metri da essa.",
				new[] { "paralizzato", "paralizzata", "paralizzati", "paralizzate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "petrified", RuleCategory.Condition,
			related: new[] { "incapacitated" },
			en: ("Petrified", "- A petrified creature is transformed, along with any nonmagical object it is wearing or carrying, into a solid inanimate substance (usually stone). Its weight increases by a factor of ten, and it ceases aging.\n- The creature is incapacitated, can't move or speak, and is unaware of its surroundings.\n- Attack rolls against the creature have advantage.\n- The creature automatically fails Strength and Dexterity saving throws.\n- The creature has resistance to all damage.\n- The creature is immune to poison and disease, although a poison or disease already in its system is suspended, not neutralized.",
				new[] { "petrified" }),
			it: ("Pietrificato", "- Una creatura pietrificata viene trasformata, insieme agli oggetti non magici che indossa o trasporta, in una sostanza solida e inanimata (di solito pietra). Il suo peso aumenta di dieci volte e smette di invecchiare.\n- La creatura è incapacitata, non può muoversi né parlare e non è consapevole di ciò che la circonda.\n- I tiri per colpire contro la creatura dispongono di vantaggio.\n- La creatura fallisce automaticamente i tiri salvezza su Forza e su Destrezza.\n- La creatura ha resistenza a tutti i danni.\n- La creatura è immune ai veleni e alle malattie; un veleno o una malattia già presenti nel suo organismo vengono però sospesi, non neutralizzati.",
				new[] { "pietrificato", "pietrificata", "pietrificati", "pietrificate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "poisoned", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Poisoned", "- A poisoned creature has disadvantage on attack rolls and ability checks.",
				new[] { "poisoned" }),
			it: ("Avvelenato", "- Una creatura avvelenata subisce svantaggio ai tiri per colpire e alle prove di caratteristica.",
				new[] { "avvelenato", "avvelenata", "avvelenati", "avvelenate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "prone", RuleCategory.Condition,
			related: new[] { "being-prone" },
			en: ("Prone", "- A prone creature's only movement option is to crawl, unless it stands up and thereby ends the condition.\n- The creature has disadvantage on attack rolls.\n- An attack roll against the creature has advantage if the attacker is within 5 feet of the creature. Otherwise, the attack roll has disadvantage.",
				new[] { "prone" }),
			it: ("Prono", "- L'unica opzione di movimento di una creatura prona è strisciare, a meno che non si rialzi, ponendo così fine alla condizione.\n- La creatura subisce svantaggio ai tiri per colpire.\n- Un tiro per colpire contro la creatura dispone di vantaggio se l'attaccante si trova entro 1,5 metri da essa; altrimenti subisce svantaggio.",
				new[] { "prono", "prona", "proni", "prone" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "restrained", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Restrained", "- A restrained creature's speed becomes 0, and it can't benefit from any bonus to its speed.\n- Attack rolls against the creature have advantage, and the creature's attack rolls have disadvantage.\n- The creature has disadvantage on Dexterity saving throws.",
				new[] { "restrained" }),
			it: ("Trattenuto", "- La velocità di una creatura trattenuta diventa 0 e la creatura non può beneficiare di alcun bonus alla velocità.\n- I tiri per colpire contro la creatura dispongono di vantaggio, mentre i tiri per colpire della creatura subiscono svantaggio.\n- La creatura subisce svantaggio ai tiri salvezza su Destrezza.",
				new[] { "trattenuto", "trattenuta", "trattenuti", "trattenute" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "stunned", RuleCategory.Condition,
			related: new[] { "incapacitated" },
			en: ("Stunned", "- A stunned creature is incapacitated, can't move, and can speak only falteringly.\n- The creature automatically fails Strength and Dexterity saving throws.\n- Attack rolls against the creature have advantage.",
				new[] { "stunned" }),
			it: ("Stordito", "- Una creatura stordita è incapacitata, non può muoversi e riesce a parlare solo in modo stentato.\n- La creatura fallisce automaticamente i tiri salvezza su Forza e su Destrezza.\n- I tiri per colpire contro la creatura dispongono di vantaggio.",
				new[] { "stordito", "stordita", "storditi", "stordite" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "unconscious", RuleCategory.Condition,
			related: new[] { "knocking-a-creature-out" },
			en: ("Unconscious", "- An unconscious creature is incapacitated, can't move or speak, and is unaware of its surroundings.\n- The creature drops whatever it's holding and falls prone.\n- The creature automatically fails Strength and Dexterity saving throws.\n- Attack rolls against the creature have advantage.\n- Any attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.",
				new[] { "unconscious" }),
			it: ("Privo di sensi", "- Una creatura priva di sensi è incapacitata, non può muoversi né parlare e non è consapevole di ciò che la circonda.\n- La creatura lascia cadere ciò che tiene in mano e cade a terra prona.\n- La creatura fallisce automaticamente i tiri salvezza su Forza e su Destrezza.\n- I tiri per colpire contro la creatura dispongono di vantaggio.\n- Qualsiasi attacco che colpisce la creatura è un colpo critico se l'attaccante si trova entro 1,5 metri da essa.",
				new[] { "privo di sensi", "priva di sensi", "privi di sensi", "prive di sensi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "exhaustion", RuleCategory.Condition,
			related: new[] { "food-and-water" },
			en: ("Exhaustion", "Some special abilities and environmental hazards, such as starvation and the long-term effects of freezing or scorching temperatures, can lead to a special condition called exhaustion. Exhaustion is measured in six levels. An effect can give a creature one or more levels of exhaustion, as specified in the effect's description.\n\n| Level | Effect |\n|---|---|\n| 1 | Disadvantage on ability checks |\n| 2 | Speed halved |\n| 3 | Disadvantage on attack rolls and saving throws |\n| 4 | Hit point maximum halved |\n| 5 | Speed reduced to 0 |\n| 6 | Death |\n\nIf an already exhausted creature suffers another effect that causes exhaustion, its current level of exhaustion increases by the amount specified in the effect's description.\n\nA creature suffers the effect of its current level of exhaustion as well as all lower levels. For example, a creature suffering level 2 exhaustion has its speed halved and has disadvantage on ability checks.\n\nAn effect that removes exhaustion reduces its level as specified in the effect's description, with all exhaustion effects ending if a creature's exhaustion level is reduced below 1.\n\nFinishing a long rest reduces a creature's exhaustion level by 1, provided that the creature has also ingested some food and drink.",
				new[] { "exhaustion" }),
			it: ("Indebolimento", "Alcune capacità speciali e alcuni pericoli ambientali, come la fame o l'esposizione prolungata a temperature gelide o torride, possono infliggere una condizione speciale chiamata indebolimento. L'indebolimento si misura in sei livelli; un effetto può infliggere a una creatura uno o più livelli di indebolimento, come specificato nella sua descrizione.\n\n| Livello | Effetto |\n|---|---|\n| 1 | Svantaggio alle prove di caratteristica |\n| 2 | Velocità dimezzata |\n| 3 | Svantaggio ai tiri per colpire e ai tiri salvezza |\n| 4 | Punti ferita massimi dimezzati |\n| 5 | Velocità ridotta a 0 |\n| 6 | Morte |\n\nSe una creatura già indebolita subisce un altro effetto che causa indebolimento, il suo livello attuale aumenta della quantità indicata nella descrizione dell'effetto.\n\nUna creatura subisce gli effetti del suo livello attuale di indebolimento e di tutti i livelli inferiori. Per esempio, una creatura con indebolimento di livello 2 ha la velocità dimezzata e subisce svantaggio alle prove di caratteristica.\n\nUn effetto che rimuove l'indebolimento ne riduce il livello come indicato nella sua descrizione; tutti gli effetti dell'indebolimento terminano quando il livello della creatura scende sotto 1.\n\nCompletare un riposo lungo riduce di 1 il livello di indebolimento di una creatura, a patto che abbia anche mangiato e bevuto.",
				new[] { "indebolimento" }));
	}
}
