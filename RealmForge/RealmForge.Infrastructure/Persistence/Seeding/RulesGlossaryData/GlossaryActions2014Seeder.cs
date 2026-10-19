using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.RulesGlossaryData;

///	<summary>
///	Actions of the 2014 rules. English text from the SRD 5.1 (CC BY 4.0); the Italian texts are RealmForge
///	translations that use the official names of the Italian Player's Handbook.
///	</summary>
public static class GlossaryActions2014Seeder
{
	public static IEnumerable<RuleEntry> Build()
	{
		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "attack", RuleCategory.Action,
			related: Array.Empty<string>(),
			en: ("Attack", "The most common action to take in combat is the Attack action, whether you are swinging a sword, firing an arrow from a bow, or brawling with your fists.\n\nWith this action, you make one melee or ranged attack.\n\nCertain features, such as the Extra Attack feature of the fighter, allow you to make more than one attack with this action.",
				new[] { "Attack action" }),
			it: ("Attacco", "L'azione più comune in combattimento è l'azione di Attacco, che si tratti di menare un fendente con la spada, scoccare una freccia con l'arco o fare a pugni.\n\nCon questa azione il personaggio effettua un attacco in mischia o a distanza.\n\nAlcuni privilegi, come Attacco Extra del guerriero, permettono di effettuare più di un attacco con questa azione.",
				new[] { "azione di Attacco", "azione Attacco" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "cast-a-spell", RuleCategory.Action,
			related: new[] { "components", "concentration" },
			en: ("Cast a Spell", "Spellcasters such as wizards and clerics, as well as many monsters, have access to spells and can use them to great effect in combat. Each spell has a casting time, which specifies whether the caster must use an action, a reaction, minutes, or even hours to cast the spell. Casting a spell is, therefore, not necessarily an action. Most spells do have a casting time of 1 action, so a spellcaster often uses his or her action in combat to cast such a spell.",
				new[] { "Cast a Spell action" }),
			it: ("Lanciare un incantesimo", "Gli incantatori come i maghi e i chierici, così come molti mostri, hanno accesso agli incantesimi e possono usarli con grande efficacia in combattimento. Ogni incantesimo ha un tempo di lancio, che indica se l'incantatore deve usare un'azione, una reazione, alcuni minuti o persino alcune ore per lanciarlo: lanciare un incantesimo, quindi, non è necessariamente un'azione. La maggior parte degli incantesimi ha però un tempo di lancio di 1 azione, perciò in combattimento un incantatore usa spesso la sua azione per lanciarne uno.",
				new[] { "azione di Lanciare un Incantesimo", "azione Lanciare un Incantesimo" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "dash", RuleCategory.Action,
			related: Array.Empty<string>(),
			en: ("Dash", "When you take the Dash action, you gain extra movement for the current turn. The increase equals your speed, after applying any modifiers. With a speed of 30 feet, for example, you can move up to 60 feet on your turn if you dash.\n\nAny increase or decrease to your speed changes this additional movement by the same amount. If your speed of 30 feet is reduced to 15 feet, for instance, you can move up to 30 feet this turn if you dash.",
				new[] { "Dash action" }),
			it: ("Scatto", "Quando effettua l'azione di Scatto, il personaggio ottiene movimento aggiuntivo per il turno in corso, pari alla sua velocità dopo aver applicato gli eventuali modificatori. Con una velocità di 9 metri, per esempio, può muoversi fino a 18 metri nel suo turno se scatta.\n\nQualsiasi aumento o riduzione della velocità modifica della stessa misura anche questo movimento aggiuntivo. Se la sua velocità di 9 metri è ridotta a 4,5 metri, per esempio, scattando può muoversi fino a 9 metri in quel turno.",
				new[] { "azione di Scatto", "azione Scatto" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "disengage", RuleCategory.Action,
			related: new[] { "opportunity-attacks" },
			en: ("Disengage", "If you take the Disengage action, your movement doesn't provoke opportunity attacks for the rest of the turn.",
				new[] { "Disengage action" }),
			it: ("Disimpegno", "Se il personaggio effettua l'azione di Disimpegno, il suo movimento non provoca attacchi di opportunità per il resto del turno.",
				new[] { "azione di Disimpegno", "azione Disimpegno" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "dodge", RuleCategory.Action,
			related: new[] { "incapacitated" },
			en: ("Dodge", "When you take the Dodge action, you focus entirely on avoiding attacks. Until the start of your next turn, any attack roll made against you has disadvantage if you can see the attacker, and you make Dexterity saving throws with advantage. You lose this benefit if you are incapacitated or if your speed drops to 0.",
				new[] { "Dodge action" }),
			it: ("Schivata", "Quando effettua l'azione di Schivata, il personaggio si concentra soltanto sull'evitare gli attacchi. Fino all'inizio del suo turno successivo, i tiri per colpire contro di lui subiscono svantaggio se può vedere l'attaccante, e i suoi tiri salvezza su Destrezza dispongono di vantaggio. Perde questo beneficio se è incapacitato o se la sua velocità scende a 0.",
				new[] { "azione di Schivata", "azione Schivata" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "help", RuleCategory.Action,
			related: new[] { "working-together" },
			en: ("Help", "You can lend your aid to another creature in the completion of a task. When you take the Help action, the creature you aid gains advantage on the next ability check it makes to perform the task you are helping with, provided that it makes the check before the start of your next turn.\n\nAlternatively, you can aid a friendly creature in attacking a creature within 5 feet of you. You feint, distract the target, or in some other way team up to make your ally's attack more effective. If your ally attacks the target before your next turn, the first attack roll is made with advantage.",
				new[] { "Help action" }),
			it: ("Aiuto", "Il personaggio può prestare il suo aiuto a un'altra creatura nello svolgimento di un compito. Quando effettua l'azione di Aiuto, la creatura che aiuta dispone di vantaggio alla prossima prova di caratteristica che effettua per svolgere quel compito, a patto che la effettui prima dell'inizio del turno successivo del personaggio.\n\nIn alternativa, il personaggio può aiutare una creatura amica ad attaccare una creatura entro 1,5 metri da lui: finge un colpo, distrae il bersaglio o collabora in qualche altro modo per rendere più efficace l'attacco dell'alleato. Se l'alleato attacca il bersaglio prima del turno successivo del personaggio, il suo primo tiro per colpire dispone di vantaggio.",
				new[] { "azione di Aiuto", "azione Aiuto" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "hide", RuleCategory.Action,
			related: new[] { "unseen-attackers-and-targets" },
			en: ("Hide", "When you take the Hide action, you make a Dexterity (Stealth) check in an attempt to hide, following the rules for hiding. If you succeed, you gain certain benefits, as described in \"Unseen Attackers and Targets\".",
				new[] { "Hide action" }),
			it: ("Nascondersi", "Quando effettua l'azione di Nascondersi, il personaggio effettua una prova di Destrezza (Furtività) per cercare di nascondersi, seguendo le regole per nascondersi. Se ci riesce, ottiene alcuni benefici, descritti in \"Attaccanti e bersagli non visibili\".",
				new[] { "azione di Nascondersi", "azione Nascondersi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "ready", RuleCategory.Action,
			related: new[] { "reactions", "concentration" },
			en: ("Ready", "Sometimes you want to get the jump on a foe or wait for a particular circumstance before you act. To do so, you can take the Ready action on your turn, which lets you act using your reaction before the start of your next turn.\n\nFirst, you decide what perceivable circumstance will trigger your reaction. Then, you choose the action you will take in response to that trigger, or you choose to move up to your speed in response to it. Examples include \"If the cultist steps on the trapdoor, I'll pull the lever that opens it,\" and \"If the goblin steps next to me, I move away.\"\n\nWhen the trigger occurs, you can either take your reaction right after the trigger finishes or ignore the trigger. Remember that you can take only one reaction per round.\n\nWhen you ready a spell, you cast it as normal but hold its energy, which you release with your reaction when the trigger occurs. To be readied, a spell must have a casting time of 1 action, and holding onto the spell's magic requires concentration. If your concentration is broken, the spell dissipates without taking effect. For example, if you are concentrating on the _web_ spell and ready _magic missile_, your _web_ spell ends, and if you take damage before you release _magic missile_ with your reaction, your concentration might be broken.",
				new[] { "Ready action" }),
			it: ("Preparare", "A volte il personaggio vuole cogliere di sorpresa un avversario o attendere una circostanza specifica prima di agire. Per farlo, può effettuare l'azione di Preparare nel suo turno, che gli permette di agire usando la sua reazione prima dell'inizio del suo turno successivo.\n\nPer prima cosa decide quale circostanza percepibile farà scattare la sua reazione; poi sceglie l'azione con cui risponderà, oppure decide di muoversi fino alla sua velocità in risposta. Per esempio: \"Se il cultista mette piede sulla botola, tiro la leva che la apre\" oppure \"Se il goblin mi arriva accanto, mi allontano\".\n\nQuando la circostanza si verifica, il personaggio può effettuare la sua reazione subito dopo che è terminata, oppure ignorarla. Va ricordato che si può effettuare una sola reazione per round.\n\nQuando prepara un incantesimo, il personaggio lo lancia normalmente ma ne trattiene l'energia, che libera con la sua reazione quando si verifica la circostanza. Per essere preparato, l'incantesimo deve avere un tempo di lancio di 1 azione, e trattenerne la magia richiede concentrazione. Se la concentrazione si interrompe, l'incantesimo si dissolve senza alcun effetto. Per esempio, se il personaggio è concentrato sull'incantesimo _Ragnatela_ e prepara _Dardo Incantato_, _Ragnatela_ termina; e se subisce danni prima di liberare _Dardo Incantato_ con la sua reazione, potrebbe perdere la concentrazione.",
				new[] { "azione di Preparare", "azione Preparare", "azione di Prepararsi", "azione Prepararsi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "search", RuleCategory.Action,
			related: Array.Empty<string>(),
			en: ("Search", "When you take the Search action, you devote your attention to finding something. Depending on the nature of your search, the GM might have you make a Wisdom (Perception) check or an Intelligence (Investigation) check.",
				new[] { "Search action" }),
			it: ("Cercare", "Quando effettua l'azione di Cercare, il personaggio dedica la sua attenzione a trovare qualcosa. A seconda della natura della ricerca, il DM può chiedergli una prova di Saggezza (Percezione) o di Intelligenza (Indagare).",
				new[] { "azione di Cercare", "azione Cercare" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2014, ContentSource.Srd51, "use-an-object", RuleCategory.Action,
			related: Array.Empty<string>(),
			en: ("Use an Object", "You normally interact with an object while doing something else, such as when you draw a sword as part of an attack. When an object requires your action for its use, you take the Use an Object action. This action is also useful when you want to interact with more than one object on your turn.",
				new[] { "Use an Object action" }),
			it: ("Usare un oggetto", "Di solito il personaggio interagisce con un oggetto mentre fa qualcos'altro, come quando estrae una spada nell'ambito di un attacco. Quando un oggetto richiede la sua azione per essere usato, il personaggio effettua l'azione di Usare un Oggetto. Questa azione è utile anche quando vuole interagire con più di un oggetto nel suo turno.",
				new[] { "azione di Usare un Oggetto", "azione Usare un Oggetto" }));
	}
}
