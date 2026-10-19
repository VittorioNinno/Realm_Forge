using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.RulesGlossaryData;

///	<summary>
///	Conditions of the 2024 rules. English text from the SRD 5.2.1 (CC BY 4.0); the Italian texts are RealmForge
///	translations that use the official names of the Italian Player's Handbook.
///	</summary>
public static class GlossaryConditions2024Seeder
{
	public static IEnumerable<RuleEntry> Build()
	{
		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "blinded", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Blinded", "While you have the Blinded condition, you experience the following effects.\n\n**Can't See.** You can't see and automatically fail any ability check that requires sight.\n\n**Attacks Affected.** Attack rolls against you have Advantage, and your attack rolls have Disadvantage.",
				new[] { "Blinded" }),
			it: ("Accecato", "Mentre ha la condizione di accecato, il personaggio subisce questi effetti.\n\n**Non vede.** Il personaggio non è in grado di vedere e fallisce automaticamente le prove di caratteristica che richiedono la vista.\n\n**Attacchi influenzati.** I tiri per colpire contro il personaggio hanno vantaggio, mentre i suoi tiri per colpire subiscono svantaggio.",
				new[] { "accecato", "accecata", "accecati", "accecate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "charmed", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Charmed", "While you have the Charmed condition, you experience the following effects.\n\n**Can't Harm the Charmer.** You can't attack the charmer or target the charmer with damaging abilities or magical effects.\n\n**Social Advantage.** The charmer has Advantage on any ability check to interact with you socially.",
				new[] { "Charmed" }),
			it: ("Affascinato", "Mentre ha la condizione di affascinato, il personaggio subisce questi effetti.\n\n**Non può nuocere a chi lo ha affascinato.** Il personaggio non può attaccare chi lo ha affascinato, né sceglierlo come bersaglio di capacità dannose o di effetti magici.\n\n**Vantaggio sociale.** Chi lo ha affascinato ha vantaggio a qualsiasi prova di caratteristica effettuata per interagire socialmente con il personaggio.",
				new[] { "affascinato", "affascinata", "affascinati", "affascinate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "deafened", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Deafened", "While you have the Deafened condition, you experience the following effect.\n\n**Can't Hear.** You can't hear and automatically fail any ability check that requires hearing.",
				new[] { "Deafened" }),
			it: ("Assordato", "Mentre ha la condizione di assordato, il personaggio subisce questo effetto.\n\n**Non sente.** Il personaggio non è in grado di sentire e fallisce automaticamente le prove di caratteristica che richiedono l'udito.",
				new[] { "assordato", "assordata", "assordati", "assordate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "exhaustion", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Exhaustion", "While you have the Exhaustion condition, you experience the following effects.\n\n**Exhaustion Levels.** This condition is cumulative. Each time you receive it, you gain 1 Exhaustion level. You die if your Exhaustion level is 6.\n\n**D20 Tests Affected.** When you make a D20 Test, the roll is reduced by 2 times your Exhaustion level.\n\n**Speed Reduced.** Your Speed is reduced by a number of feet equal to 5 times your Exhaustion level.\n\n**Removing Exhaustion Levels.** Finishing a Long Rest removes 1 of your Exhaustion levels. When your Exhaustion level reaches 0, the condition ends.",
				new[] { "Exhaustion" }),
			it: ("Indebolimento", "Mentre ha la condizione di indebolimento, il personaggio subisce questi effetti.\n\n**Livelli di indebolimento.** Questa condizione è cumulativa: ogni volta che la riceve, il personaggio ottiene 1 livello di indebolimento. Muore se il suo livello di indebolimento arriva a 6.\n\n**Prove con d20 influenzate.** Quando effettua una prova con d20, il risultato viene ridotto del doppio del suo livello di indebolimento.\n\n**Velocità ridotta.** La sua velocità si riduce di 1,5 metri per ogni livello di indebolimento.\n\n**Rimuovere i livelli di indebolimento.** Ogni riposo lungo completato rimuove 1 livello di indebolimento. Quando il livello arriva a 0, la condizione termina.",
				new[] { "indebolimento" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "frightened", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Frightened", "While you have the Frightened condition, you experience the following effects.\n\n**Ability Checks and Attacks Affected.** You have Disadvantage on ability checks and attack rolls while the source of fear is within line of sight.\n\n**Can't Approach.** You can't willingly move closer to the source of fear.",
				new[] { "Frightened" }),
			it: ("Spaventato", "Mentre ha la condizione di spaventato, il personaggio subisce questi effetti.\n\n**Prove di caratteristica e attacchi influenzati.** Il personaggio subisce svantaggio alle prove di caratteristica e ai tiri per colpire finché la fonte della sua paura è nella sua linea di vista.\n\n**Non può avvicinarsi.** Il personaggio non può avvicinarsi volontariamente alla fonte della sua paura.",
				new[] { "spaventato", "spaventata", "spaventati", "spaventate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "grappled", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Grappled", "While you have the Grappled condition, you experience the following effects.\n\n**Speed 0.** Your Speed is 0 and can't increase.\n\n**Attacks Affected.** You have Disadvantage on attack rolls against any target other than the grappler.\n\n**Movable.** The grappler can drag or carry you when it moves, but every foot of movement costs it 1 extra foot unless you are Tiny or two or more sizes smaller than it.",
				new[] { "Grappled" }),
			it: ("Afferrato", "Mentre ha la condizione di afferrato, il personaggio subisce questi effetti.\n\n**Velocità 0.** La sua velocità è 0 e non può aumentare.\n\n**Attacchi influenzati.** Subisce svantaggio ai tiri per colpire contro qualsiasi bersaglio diverso da chi lo ha afferrato.\n\n**Trasportabile.** Chi lo ha afferrato può trascinarlo o portarlo con sé quando si muove, ma ogni metro di movimento gli costa 1 metro in più, a meno che il personaggio non sia Minuscolo o di due o più taglie più piccolo di lui.",
				new[] { "afferrato", "afferrata", "afferrati", "afferrate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "incapacitated", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Incapacitated", "While you have the Incapacitated condition, you experience the following effects.\n\n**Inactive.** You can't take any action, Bonus Action, or Reaction.\n\n**No Concentration.** Your Concentration is broken.\n\n**Speechless.** You can't speak.\n\n**Surprised.** If you're Incapacitated when you roll Initiative, you have Disadvantage on the roll.",
				new[] { "Incapacitated" }),
			it: ("Incapacitato", "Mentre ha la condizione di incapacitato, il personaggio subisce questi effetti.\n\n**Inattivo.** Non può effettuare azioni, azioni bonus o reazioni.\n\n**Niente concentrazione.** La sua concentrazione si interrompe.\n\n**Senza parola.** Non è in grado di parlare.\n\n**Sorpreso.** Se è incapacitato quando tira per l'iniziativa, subisce svantaggio al tiro.",
				new[] { "incapacitato", "incapacitata", "incapacitati", "incapacitate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "invisible", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Invisible", "While you have the Invisible condition, you experience the following effects.\n\n**Surprise.** If you're Invisible when you roll Initiative, you have Advantage on the roll.\n\n**Concealed.** You aren't affected by any effect that requires its target to be seen unless the effect's creator can somehow see you. Any equipment you are wearing or carrying is also concealed.\n\n**Attacks Affected.** Attack rolls against you have Disadvantage, and your attack rolls have Advantage. If a creature can somehow see you, you don't gain this benefit against that creature.",
				new[] { "Invisible" }),
			it: ("Invisibile", "Mentre ha la condizione di invisibile, il personaggio subisce questi effetti.\n\n**Sorpresa.** Se è invisibile quando tira per l'iniziativa, ha vantaggio al tiro.\n\n**Celato.** Non è influenzato dagli effetti che richiedono di vedere il bersaglio, a meno che il creatore dell'effetto non riesca in qualche modo a vederlo. Anche l'equipaggiamento che indossa o trasporta è celato.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui subiscono svantaggio, mentre i suoi tiri per colpire hanno vantaggio. Se una creatura riesce in qualche modo a vederlo, il personaggio non ottiene questo beneficio nei confronti di quella creatura.",
				new[] { "invisibile", "invisibili" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "paralyzed", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Paralyzed", "While you have the Paralyzed condition, you experience the following effects.\n\n**Incapacitated.** You have the Incapacitated condition.\n\n**Speed 0.** Your Speed is 0 and can't increase.\n\n**Saving Throws Affected.** You automatically fail Strength and Dexterity saving throws.\n\n**Attacks Affected.** Attack rolls against you have Advantage.\n\n**Automatic Critical Hits.** Any attack roll that hits you is a Critical Hit if the attacker is within 5 feet of you.",
				new[] { "Paralyzed" }),
			it: ("Paralizzato", "Mentre ha la condizione di paralizzato, il personaggio subisce questi effetti.\n\n**Incapacitato.** Ha la condizione di incapacitato.\n\n**Velocità 0.** La sua velocità è 0 e non può aumentare.\n\n**Tiri salvezza influenzati.** Fallisce automaticamente i tiri salvezza su Forza e Destrezza.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui hanno vantaggio.\n\n**Colpi critici automatici.** Qualsiasi tiro per colpire che lo colpisce è un colpo critico se l'attaccante si trova entro 1,5 metri da lui.",
				new[] { "paralizzato", "paralizzata", "paralizzati", "paralizzate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "petrified", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Petrified", "While you have the Petrified condition, you experience the following effects.\n\n**Turned to Inanimate Substance.** You are transformed, along with any nonmagical objects you are wearing and carrying, into a solid inanimate substance (usually stone). Your weight increases by a factor of ten, and you cease aging.\n\n**Incapacitated.** You have the Incapacitated condition.\n\n**Speed 0.** Your Speed is 0 and can't increase.\n\n**Attacks Affected.** Attack rolls against you have Advantage.\n\n**Saving Throws Affected.** You automatically fail Strength and Dexterity saving throws.\n\n**Resist Damage.** You have Resistance to all damage.\n\n**Poison Immunity.** You have Immunity to the Poisoned condition.",
				new[] { "Petrified" }),
			it: ("Pietrificato", "Mentre ha la condizione di pietrificato, il personaggio subisce questi effetti.\n\n**Trasformato in materia inanimata.** Il personaggio, insieme agli oggetti non magici che indossa e trasporta, viene trasformato in una sostanza solida e inanimata (di solito pietra). Il suo peso aumenta di dieci volte e smette di invecchiare.\n\n**Incapacitato.** Ha la condizione di incapacitato.\n\n**Velocità 0.** La sua velocità è 0 e non può aumentare.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui hanno vantaggio.\n\n**Tiri salvezza influenzati.** Fallisce automaticamente i tiri salvezza su Forza e Destrezza.\n\n**Resistenza ai danni.** Ha resistenza a tutti i danni.\n\n**Immunità al veleno.** Ha immunità alla condizione di avvelenato.",
				new[] { "pietrificato", "pietrificata", "pietrificati", "pietrificate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "poisoned", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Poisoned", "While you have the Poisoned condition, you experience the following effect.\n\n**Ability Checks and Attacks Affected.** You have Disadvantage on attack rolls and ability checks.",
				new[] { "Poisoned" }),
			it: ("Avvelenato", "Mentre ha la condizione di avvelenato, il personaggio subisce questo effetto.\n\n**Prove di caratteristica e attacchi influenzati.** Subisce svantaggio ai tiri per colpire e alle prove di caratteristica.",
				new[] { "avvelenato", "avvelenata", "avvelenati", "avvelenate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "prone", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Prone", "While you have the Prone condition, you experience the following effects.\n\n**Restricted Movement.** Your only movement options are to crawl or to spend an amount of movement equal to half your Speed (round down) to right yourself and thereby end the condition. If your Speed is 0, you can't right yourself.\n\n**Attacks Affected.** You have Disadvantage on attack rolls. An attack roll against you has Advantage if the attacker is within 5 feet of you. Otherwise, that attack roll has Disadvantage.",
				new[] { "Prone" }),
			it: ("Prono", "Mentre ha la condizione di prono, il personaggio subisce questi effetti.\n\n**Movimento limitato.** Le sue uniche opzioni di movimento sono strisciare oppure spendere una quantità di movimento pari a metà della sua velocità (arrotondata per difetto) per rialzarsi, ponendo così fine alla condizione. Se la sua velocità è 0, non può rialzarsi.\n\n**Attacchi influenzati.** Subisce svantaggio ai tiri per colpire. Un tiro per colpire contro di lui ha vantaggio se l'attaccante si trova entro 1,5 metri; altrimenti subisce svantaggio.",
				new[] { "prono", "prona", "proni", "prone" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "restrained", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Restrained", "While you have the Restrained condition, you experience the following effects.\n\n**Speed 0.** Your Speed is 0 and can't increase.\n\n**Attacks Affected.** Attack rolls against you have Advantage, and your attack rolls have Disadvantage.\n\n**Saving Throws Affected.** You have Disadvantage on Dexterity saving throws.",
				new[] { "Restrained" }),
			it: ("Trattenuto", "Mentre ha la condizione di trattenuto, il personaggio subisce questi effetti.\n\n**Velocità 0.** La sua velocità è 0 e non può aumentare.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui hanno vantaggio, mentre i suoi tiri per colpire subiscono svantaggio.\n\n**Tiri salvezza influenzati.** Subisce svantaggio ai tiri salvezza su Destrezza.",
				new[] { "trattenuto", "trattenuta", "trattenuti", "trattenute" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "stunned", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Stunned", "While you have the Stunned condition, you experience the following effects.\n\n**Incapacitated.** You have the Incapacitated condition.\n\n**Saving Throws Affected.** You automatically fail Strength and Dexterity saving throws.\n\n**Attacks Affected.** Attack rolls against you have Advantage.",
				new[] { "Stunned" }),
			it: ("Stordito", "Mentre ha la condizione di stordito, il personaggio subisce questi effetti.\n\n**Incapacitato.** Ha la condizione di incapacitato.\n\n**Tiri salvezza influenzati.** Fallisce automaticamente i tiri salvezza su Forza e Destrezza.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui hanno vantaggio.",
				new[] { "stordito", "stordita", "storditi", "stordite" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "unconscious", RuleCategory.Condition,
			related: Array.Empty<string>(),
			en: ("Unconscious", "While you have the Unconscious condition, you experience the following effects.\n\n**Inert.** You have the Incapacitated and Prone conditions, and you drop whatever you're holding. When this condition ends, you remain Prone.\n\n**Speed 0.** Your Speed is 0 and can't increase.\n\n**Attacks Affected.** Attack rolls against you have Advantage.\n\n**Saving Throws Affected.** You automatically fail Strength and Dexterity saving throws.\n\n**Automatic Critical Hits.** Any attack roll that hits you is a Critical Hit if the attacker is within 5 feet of you.\n\n**Unaware.** You're unaware of your surroundings.",
				new[] { "Unconscious" }),
			it: ("Privo di sensi", "Mentre ha la condizione di privo di sensi, il personaggio subisce questi effetti.\n\n**Inerte.** Ha le condizioni di incapacitato e di prono e lascia cadere ciò che tiene in mano. Quando questa condizione termina, resta prono.\n\n**Velocità 0.** La sua velocità è 0 e non può aumentare.\n\n**Attacchi influenzati.** I tiri per colpire contro di lui hanno vantaggio.\n\n**Tiri salvezza influenzati.** Fallisce automaticamente i tiri salvezza su Forza e Destrezza.\n\n**Colpi critici automatici.** Qualsiasi tiro per colpire che lo colpisce è un colpo critico se l'attaccante si trova entro 1,5 metri da lui.\n\n**Inconsapevole.** Non è consapevole di ciò che lo circonda.",
				new[] { "privo di sensi", "priva di sensi", "privi di sensi", "prive di sensi" }));
	}
}
