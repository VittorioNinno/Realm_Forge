using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Battle Master (fighter, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class BattleMaster2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "battle-master");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "battle-master", "en"), Language = LanguageCode.En, Name = "Battle Master", Description = "Battle Masters study war as an art, learning fighting techniques handed down across generations. The finest of them are well-rounded figures who pair their sharpened combat skills with scholarship in history, strategy and the arts." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "battle-master", "it"), Language = LanguageCode.It, Name = "Maestro di Battaglia", Description = "I maestri di battaglia studiano la guerra come un'arte e apprendono tecniche di combattimento tramandate di generazione in generazione. I migliori tra loro sono figure complete, che uniscono le loro affinate capacità in battaglia allo studio della storia, della strategia e delle arti." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/combat-superiority"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/combat-superiority", "en"), Language = LanguageCode.En, Name = "Combat Superiority", Description = "Battlefield experience has refined your technique. You learn maneuvers powered by special dice called Superiority Dice.\n\n**Maneuvers.** You learn three maneuvers of your choice from Maneuver Options. Many of them improve an attack, and you can apply only one maneuver to each attack. At Fighter levels 7, 10, and 15 you learn two more maneuvers of your choice, and each time you learn new ones you can also swap one maneuver you know for another.\n\n**Superiority Dice.** You have four Superiority Dice, which are d8s. A die is spent when you use it, and you recover all spent dice after a Short or Long Rest. You gain one more die at Fighter level 7 (five in all) and another at level 15 (six in all).\n\n**Saving Throws.** If a maneuver calls for a saving throw, the DC is 8 plus your Strength or Dexterity modifier (your choice) plus your Proficiency Bonus." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/combat-superiority", "it"), Language = LanguageCode.It, Name = "Superiorità in Combattimento", Description = "L'esperienza sul campo di battaglia ha raffinato le tecniche del guerriero, che apprende manovre alimentate da dadi speciali chiamati dadi di superiorità.\n\n**Manovre.** Il guerriero apprende tre manovre a sua scelta tra quelle descritte in Opzioni di manovra. Molte manovre potenziano un attacco; può usare una sola manovra per attacco. Al 7°, al 10° e al 15° livello da guerriero apprende altre due manovre a sua scelta e, ogni volta che ne apprende di nuove, può anche sostituire una manovra che conosce con un'altra.\n\n**Dadi di superiorità.** Il guerriero ha quattro dadi di superiorità, che sono d8. Un dado di superiorità viene speso quando lo usa, e il guerriero recupera tutti quelli spesi dopo un riposo breve o lungo. Ne ottiene uno aggiuntivo al 7° livello da guerriero (cinque in tutto) e un altro al 15° (sei in tutto).\n\n**Tiri salvezza.** Se una manovra richiede un tiro salvezza, la CD è pari a 8 + il modificatore di Forza o di Destrezza del guerriero (a sua scelta) + il suo bonus di competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/student-of-war"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/student-of-war", "en"), Language = LanguageCode.En, Name = "Student of War", Description = "You gain proficiency with one kind of Artisan's Tools of your choice and in one skill of your choice from those a Fighter can pick at level 1." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/student-of-war", "it"), Language = LanguageCode.It, Name = "Studioso di Guerra", Description = "Il guerriero ottiene competenza in un tipo di strumenti da artigiano a sua scelta e in un'abilità a sua scelta tra quelle disponibili per il guerriero al 1° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/maneuver-options"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/maneuver-options", "en"), Language = LanguageCode.En, Name = "Maneuver Options", Description = "The maneuvers are listed in alphabetical order. When a maneuver adds the Superiority Die to damage, the die is spent.\n\n**Ambush.** When you make a Dexterity (Stealth) check or an Initiative roll while not Incapacitated, you can spend a Superiority Die and add it to the roll.\n\n**Bait and Switch.** On your turn, while within 5 feet of a willing creature that isn't Incapacitated, you can spend a Superiority Die and at least 5 feet of movement to trade places with it, without provoking Opportunity Attacks. Roll the die: until the start of your next turn, you or the other creature (your choice) adds the result to its AC.\n\n**Commander's Strike.** When you take the Attack action on your turn, you can give up one of your attacks to order a companion to strike. Pick a willing creature that can see or hear you and spend a Superiority Die; that creature can immediately use its Reaction to make one attack with a weapon or an Unarmed Strike, adding the die to the damage if it hits.\n\n**Commanding Presence.** When you make a Charisma (Intimidation, Performance, or Persuasion) check, you can spend a Superiority Die and add it to the check.\n\n**Disarming Attack.** When you hit a creature with an attack roll, you can spend a Superiority Die, add it to the damage, and try to disarm the target: it must succeed on a Strength saving throw or drop one object of your choice that it holds, which falls into its space.\n\n**Distracting Strike.** When you hit a creature with an attack roll, you can spend a Superiority Die and add it to the damage to throw the target off balance: the next attack roll against it by someone other than you, made before the start of your next turn, has Advantage.\n\n**Evasive Footwork.** As a Bonus Action, you can spend a Superiority Die and take the Disengage action. You also roll the die and add the result to your AC until the start of your next turn.\n\n**Feinting Attack.** As a Bonus Action, you can spend a Superiority Die to feint at one creature within 5 feet of you: your next attack roll against it this turn has Advantage, and if that attack hits, you add the die to its damage.\n\n**Goading Attack.** When you hit a creature with an attack roll, you can spend a Superiority Die and add it to the damage to taunt the target: it must succeed on a Wisdom saving throw or have Disadvantage on attack rolls against anyone but you until the end of your next turn.\n\n**Lunging Attack.** As a Bonus Action, you can spend a Superiority Die and take the Dash action. If you move at least 5 feet in a straight line right before hitting with a melee attack as part of the Attack action this turn, you can add the die to that attack's damage.\n\n**Maneuvering Attack.** When you hit a creature with an attack roll, you can spend a Superiority Die and add it to the damage to reposition an ally: pick a willing creature that can see or hear you, which can use its Reaction to move up to half its Speed without provoking Opportunity Attacks from your target.\n\n**Menacing Attack.** When you hit a creature with an attack roll, you can spend a Superiority Die and add it to the damage to try to scare the target: it must succeed on a Wisdom saving throw or have the Frightened condition until the end of your next turn.\n\n**Parry.** When another creature damages you with a melee attack roll, you can use your Reaction and spend a Superiority Die to reduce the damage by the die's result plus your Strength or Dexterity modifier (your choice).\n\n**Precision Attack.** When you miss with an attack roll, you can spend a Superiority Die, roll it, and add it to the attack roll, which might turn the miss into a hit.\n\n**Pushing Attack.** When you hit a creature with an attack roll using a weapon or an Unarmed Strike, you can spend a Superiority Die and add it to the damage to drive the target back: if it is Large or smaller, it must succeed on a Strength saving throw or be pushed up to 15 feet straight away from you.\n\n**Rally.** As a Bonus Action, you can spend a Superiority Die to steady an ally within 30 feet of you who can see or hear you: that creature gains Temporary Hit Points equal to the die's result plus half your Fighter level (round down).\n\n**Riposte.** When a creature misses you with a melee attack roll, you can use your Reaction and spend a Superiority Die to make a melee attack roll against it with a weapon or an Unarmed Strike; on a hit, add the die to the damage.\n\n**Sweeping Attack.** When you hit a creature with a melee attack roll using a weapon or an Unarmed Strike, you can spend a Superiority Die to try to wound a second creature within 5 feet of the first target and within your reach. If your original attack roll would also hit the second creature, it takes damage equal to the die's result, of the same type as the original attack.\n\n**Tactical Assessment.** When you make an Intelligence (History or Investigation) check or a Wisdom (Insight) check, you can spend a Superiority Die and add it to the check.\n\n**Trip Attack.** When you hit a creature with an attack roll using a weapon or an Unarmed Strike, you can spend a Superiority Die and add it to the damage: if the target is Large or smaller, it must succeed on a Strength saving throw or have the Prone condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/maneuver-options", "it"), Language = LanguageCode.It, Name = "Opzioni di Manovra", Description = "Le manovre sono elencate in ordine alfabetico secondo il loro nome inglese. Quando una manovra somma il dado di superiorità ai danni, il dado viene speso.\n\n**Imboscata.** Quando effettua una prova di Destrezza (Furtività) o tira per l'iniziativa, se non è incapacitato, il guerriero può spendere un dado di superiorità e sommarlo al tiro.\n\n**Scambio.** Nel suo turno, quando si trova entro 1,5 metri da una creatura consenziente che non è incapacitata, il guerriero può spendere un dado di superiorità e almeno 1,5 metri di movimento per scambiarsi di posto con essa, senza provocare attacchi di opportunità. Tira il dado: fino all'inizio del suo turno successivo, lui o l'altra creatura (a sua scelta) ottiene un bonus alla CA pari al risultato.\n\n**Colpo del comandante.** Quando effettua l'azione di Attacco nel suo turno, il guerriero può rinunciare a uno dei suoi attacchi per ordinare a un compagno di colpire. Sceglie una creatura consenziente che può vederlo o sentirlo e spende un dado di superiorità: quella creatura può subito usare la propria reazione per effettuare un attacco con un'arma o un colpo senz'armi, sommando il dado ai danni se colpisce.\n\n**Presenza imponente.** Quando effettua una prova di Carisma (Intimidire, Intrattenere o Persuasione), il guerriero può spendere un dado di superiorità e sommarlo alla prova.\n\n**Attacco disarmante.** Quando colpisce una creatura con un tiro per colpire, il guerriero può spendere un dado di superiorità e sommarlo ai danni per tentare di disarmarla: il bersaglio deve superare un tiro salvezza su Forza, altrimenti lascia cadere nel proprio spazio un oggetto che impugna, a scelta del guerriero.\n\n**Colpo distraente.** Quando colpisce una creatura con un tiro per colpire, il guerriero può spendere un dado di superiorità e sommarlo ai danni per distrarla: il successivo tiro per colpire contro quel bersaglio effettuato da un attaccante diverso da lui, prima dell'inizio del suo turno successivo, dispone di vantaggio.\n\n**Scarto elusivo.** Come azione bonus, il guerriero può spendere un dado di superiorità ed effettuare l'azione di Disimpegno. Tira inoltre il dado e somma il risultato alla propria CA fino all'inizio del suo turno successivo.\n\n**Attacco con finta.** Come azione bonus, il guerriero può spendere un dado di superiorità per fintare contro una creatura entro 1,5 metri da lui: dispone di vantaggio al successivo tiro per colpire contro di essa in questo turno e, se quell'attacco colpisce, somma il dado ai danni.\n\n**Attacco adescante.** Quando colpisce una creatura con un tiro per colpire, il guerriero può spendere un dado di superiorità e sommarlo ai danni per provocarla: il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti subisce svantaggio ai tiri per colpire contro bersagli diversi dal guerriero fino alla fine del turno successivo di quest'ultimo.\n\n**Attacco con affondo.** Come azione bonus, il guerriero può spendere un dado di superiorità ed effettuare l'azione di Scatto. Se, subito prima di colpire con un attacco in mischia come parte dell'azione di Attacco in questo turno, si muove di almeno 1,5 metri in linea retta, può sommare il dado ai danni di quell'attacco.\n\n**Attacco con manovra.** Quando colpisce una creatura con un tiro per colpire, il guerriero può spendere un dado di superiorità e sommarlo ai danni per far riposizionare un compagno: sceglie una creatura consenziente che può vederlo o sentirlo, la quale può usare la propria reazione per muoversi fino a metà della sua velocità senza provocare attacchi di opportunità dal bersaglio.\n\n**Attacco minaccioso.** Quando colpisce una creatura con un tiro per colpire, il guerriero può spendere un dado di superiorità e sommarlo ai danni per tentare di spaventarla: il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti subisce la condizione di spaventato fino alla fine del turno successivo del guerriero.\n\n**Parata.** Quando un'altra creatura lo danneggia con un tiro per colpire in mischia, il guerriero può usare una reazione e spendere un dado di superiorità per ridurre i danni del risultato del dado + il suo modificatore di Forza o di Destrezza (a sua scelta).\n\n**Attacco preciso.** Quando manca con un tiro per colpire, il guerriero può spendere un dado di superiorità, tirarlo e sommarlo al tiro per colpire, con la possibilità di mandare a segno l'attacco.\n\n**Attacco con spinta.** Quando colpisce una creatura con un tiro per colpire usando un'arma o un colpo senz'armi, il guerriero può spendere un dado di superiorità e sommarlo ai danni per respingere il bersaglio: se è di taglia Grande o inferiore, deve superare un tiro salvezza su Forza, altrimenti viene spinto fino a 4,5 metri in linea retta lontano dal guerriero.\n\n**Incoraggiamento.** Come azione bonus, il guerriero può spendere un dado di superiorità per rinsaldare la determinazione di un alleato entro 9 metri da lui che può vederlo o sentirlo: quella creatura ottiene punti ferita temporanei pari al risultato del dado + la metà del livello da guerriero (arrotondata per difetto).\n\n**Replica.** Quando una creatura lo manca con un tiro per colpire in mischia, il guerriero può usare una reazione e spendere un dado di superiorità per effettuare contro di essa un tiro per colpire in mischia con un'arma o un colpo senz'armi; se colpisce, somma il dado ai danni.\n\n**Attacco con spazzata.** Quando colpisce una creatura con un tiro per colpire in mischia usando un'arma o un colpo senz'armi, il guerriero può spendere un dado di superiorità per tentare di ferire una seconda creatura entro 1,5 metri dal bersaglio originale e alla sua portata. Se il tiro per colpire originale sarebbe andato a segno anche contro la seconda creatura, questa subisce danni pari al risultato del dado, dello stesso tipo dell'attacco originale.\n\n**Valutazione tattica.** Quando effettua una prova di Intelligenza (Indagare o Storia) o di Saggezza (Intuizione), il guerriero può spendere un dado di superiorità e sommarlo alla prova.\n\n**Attacco sbilanciante.** Quando colpisce una creatura con un tiro per colpire usando un'arma o un colpo senz'armi, il guerriero può spendere un dado di superiorità e sommarlo ai danni: se il bersaglio è di taglia Grande o inferiore, deve superare un tiro salvezza su Forza, altrimenti subisce la condizione di prono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/know-your-enemy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/know-your-enemy", "en"), Language = LanguageCode.En, Name = "Know Your Enemy", Description = "As a Bonus Action, you can size up a creature you can see within 30 feet of you and read its strengths and weaknesses: you learn whether it has any Immunities, Resistances, or Vulnerabilities and, if so, which ones. You can use this feature once per Long Rest, and you can spend a Superiority Die (no action required) to use it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/know-your-enemy", "it"), Language = LanguageCode.It, Name = "Conosci il Tuo Nemico", Description = "Come azione bonus, il guerriero può scrutare una creatura che è in grado di vedere entro 9 metri da lui per coglierne punti di forza e debolezze: scopre se ha immunità, resistenze o vulnerabilità e, in caso affermativo, quali sono. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, ma può ripristinarne l'utilizzo spendendo un dado di superiorità (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/improved-combat-superiority"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/improved-combat-superiority", "en"), Language = LanguageCode.En, Name = "Improved Combat Superiority", Description = "Your Superiority Dice are now d10s." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/improved-combat-superiority", "it"), Language = LanguageCode.It, Name = "Superiorità in Combattimento Migliorata", Description = "I dadi di superiorità del guerriero diventano d10." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/relentless"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/relentless", "en"), Language = LanguageCode.En, Name = "Relentless", Description = "You never quite run dry: once per turn, when you perform a maneuver, you can roll 1d8 for it rather than spend one of your Superiority Dice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/relentless", "it"), Language = LanguageCode.It, Name = "Implacabile", Description = "Il guerriero non resta mai a corto di risorse: una volta per turno, quando esegue una manovra, anziché consumare un dado di superiorità può tirare 1d8 e usare quel risultato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/ultimate-combat-superiority"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/ultimate-combat-superiority", "en"), Language = LanguageCode.En, Name = "Ultimate Combat Superiority", Description = "Your Superiority Dice are now d12s." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "battle-master/ultimate-combat-superiority", "it"), Language = LanguageCode.It, Name = "Superiorità in Combattimento Suprema", Description = "I dadi di superiorità del guerriero diventano d12." }
					}
				}
			}
		};
	}
}
