using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Battle Master (fighter, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class BattleMaster2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "battle-master");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "battle-master", "en"), Language = LanguageCode.En, Name = "Battle Master", Description = "Battle Masters treat combat as a discipline to be studied, drawing on techniques handed down through generations of warriors. Their training often reaches beyond fighting itself into history, strategy and crafts such as smithing or calligraphy. The result is a versatile, thoughtful fighter who controls the flow of battle with precise maneuvers." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "battle-master", "it"), Language = LanguageCode.It, Name = "Maestro di Battaglia", Description = "I Maestri di Battaglia considerano il combattimento una disciplina da studiare, attingendo a tecniche tramandate da generazioni di guerrieri. Il loro addestramento si spinge spesso oltre la lotta vera e propria, toccando storia, strategia e mestieri come la forgiatura o la calligrafia. Il risultato è un guerriero versatile e riflessivo che controlla l'andamento della battaglia con manovre precise." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/combat-superiority"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/combat-superiority", "en"), Language = LanguageCode.En, Name = "Combat Superiority", Description = "When you choose this archetype at 3rd level, you learn maneuvers powered by special dice called superiority dice.\n\n**Maneuvers.** You learn three maneuvers of your choice from the list below, and two more at 7th, 10th, and 15th level. Each time you learn new maneuvers, you can also swap one maneuver you know for a different one. You can use only one maneuver per attack.\n\n**Superiority Dice.** You have four superiority dice, which are d8s; you gain a fifth at 7th level and a sixth at 15th level. A die is spent when you use it, and you regain all spent superiority dice when you finish a short or long rest.\n\n**Saving Throws.** When a maneuver calls for a saving throw, the DC is 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice).\n\n**Maneuvers list**\n\n***Commander's Strike.*** When you take the Attack action, you can give up one of your attacks and use a bonus action to spend a superiority die and send a friendly creature that can see or hear you into the fight. That creature can immediately use its reaction to make one weapon attack, adding the superiority die to the damage.\n\n***Disarming Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. The target makes a Strength saving throw; on a failure, it drops one object of your choice that it is holding, which lands at its feet.\n\n***Distracting Strike.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. Before the start of your next turn, the next attack roll against that target made by someone other than you has advantage.\n\n***Evasive Footwork.*** When you move, you can spend a superiority die, roll it and add the result to your AC until you stop moving.\n\n***Feinting Attack.*** As a bonus action on your turn, you can spend a superiority die to feint at a creature within 5 feet of you. Your next attack roll against it on this turn has advantage, and if that attack hits, you add the superiority die to the damage.\n\n***Goading Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. The target makes a Wisdom saving throw; on a failure, it has disadvantage on attack rolls against anyone other than you until the end of your next turn.\n\n***Lunging Attack.*** When you make a melee weapon attack on your turn, you can spend a superiority die to extend your reach for that attack by 5 feet. On a hit, you add the die to the damage.\n\n***Maneuvering Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. Choose a friendly creature that can see or hear you: it can use its reaction to move up to half its speed without provoking opportunity attacks from your target.\n\n***Menacing Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. The target makes a Wisdom saving throw; on a failure, it is frightened of you until the end of your next turn.\n\n***Parry.*** When another creature damages you with a melee attack, you can use your reaction and spend a superiority die to reduce that damage by the die result + your Dexterity modifier.\n\n***Precision Attack.*** When you make a weapon attack roll against a creature, you can spend a superiority die and add it to the roll, before or after rolling but before any of the attack's effects are applied.\n\n***Pushing Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. If the target is Large or smaller, it makes a Strength saving throw; on a failure, you push it up to 15 feet away from you.\n\n***Rally.*** As a bonus action on your turn, you can spend a superiority die to steady a friendly creature that can see or hear you. It gains temporary hit points equal to the die roll + your Charisma modifier.\n\n***Riposte.*** When a creature misses you with a melee attack, you can use your reaction and spend a superiority die to make a melee weapon attack against it. On a hit, you add the die to the damage.\n\n***Sweeping Attack.*** When you hit a creature with a melee weapon attack, you can spend a superiority die to strike a second creature within 5 feet of the first one and within your reach. If your original attack roll would hit the second creature, it takes damage equal to the die result, of the same type as the original attack.\n\n***Trip Attack.*** When you hit a creature with a weapon attack, you can spend a superiority die and add it to the damage. If the target is Large or smaller, it makes a Strength saving throw; on a failure, you knock it prone." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/combat-superiority", "it"), Language = LanguageCode.It, Name = "Superiorità in Combattimento", Description = "Quando sceglie questo archetipo al 3° livello, il guerriero apprende delle manovre alimentate da dadi speciali chiamati dadi di superiorità.\n\n**Manovre.** Il guerriero apprende tre manovre a sua scelta dalla lista seguente, e altre due al 7°, al 10° e al 15° livello. Ogni volta che apprende nuove manovre, può anche sostituire una manovra che conosce con un'altra. Può usare una sola manovra per attacco.\n\n**Dadi di superiorità.** Il guerriero ha quattro dadi di superiorità, che sono d8; ne ottiene un quinto al 7° livello e un sesto al 15° livello. Un dado viene speso quando lo usa, e il guerriero recupera tutti i dadi di superiorità spesi quando completa un riposo breve o lungo.\n\n**Tiri salvezza.** Quando una manovra richiede un tiro salvezza, la CD è pari a 8 + il bonus di competenza del guerriero + il suo modificatore di Forza o di Destrezza (a sua scelta).\n\n**Lista delle manovre**\n\n***Colpo del Comandante.*** Quando effettua l'azione di Attacco, il guerriero può rinunciare a uno dei suoi attacchi e usare un'azione bonus per spendere un dado di superiorità e mandare all'assalto una creatura amica in grado di vederlo o di sentirlo. Quella creatura può usare immediatamente la sua reazione per effettuare un attacco con un'arma, aggiungendo il dado di superiorità ai danni.\n\n***Attacco Disarmante.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Il bersaglio effettua un tiro salvezza su Forza; se lo fallisce, lascia cadere un oggetto a scelta del guerriero che sta impugnando, e l'oggetto finisce ai suoi piedi.\n\n***Colpo Distraente.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Prima dell'inizio del suo turno successivo, il successivo tiro per colpire contro quel bersaglio effettuato da qualcuno diverso da lui ha vantaggio.\n\n***Gioco di Gambe Evasivo.*** Quando si muove, il guerriero può spendere un dado di superiorità, tirarlo e aggiungerne il risultato alla propria CA finché non smette di muoversi.\n\n***Attacco con Finta.*** Come azione bonus nel suo turno, il guerriero può spendere un dado di superiorità per fingere un attacco contro una creatura entro 1,5 metri da lui. Il suo successivo tiro per colpire contro di essa in quel turno ha vantaggio e, se quell'attacco va a segno, aggiunge il dado di superiorità ai danni.\n\n***Attacco Adescante.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Il bersaglio effettua un tiro salvezza su Saggezza; se lo fallisce, subisce svantaggio ai tiri per colpire contro chiunque non sia il guerriero fino alla fine del turno successivo di quest'ultimo.\n\n***Attacco con Affondo.*** Quando effettua un attacco con un'arma da mischia nel suo turno, il guerriero può spendere un dado di superiorità per aumentare la propria portata di 1,5 metri per quell'attacco. Se colpisce, aggiunge il dado ai danni.\n\n***Attacco con Manovra.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Sceglie una creatura amica in grado di vederlo o di sentirlo: quella creatura può usare la sua reazione per muoversi fino a metà della sua velocità senza provocare attacchi di opportunità dal bersaglio del guerriero.\n\n***Attacco Minaccioso.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Il bersaglio effettua un tiro salvezza su Saggezza; se lo fallisce, è spaventato dal guerriero fino alla fine del turno successivo di quest'ultimo.\n\n***Parata.*** Quando un'altra creatura gli infligge danni con un attacco in mischia, il guerriero può usare la sua reazione e spendere un dado di superiorità per ridurre quei danni del risultato del dado + il suo modificatore di Destrezza.\n\n***Attacco Preciso.*** Quando effettua un tiro per colpire con un'arma contro una creatura, il guerriero può spendere un dado di superiorità e aggiungerlo al tiro, prima o dopo averlo effettuato ma prima che si applichi qualsiasi effetto dell'attacco.\n\n***Attacco con Spinta.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Se il bersaglio è di taglia Grande o inferiore, effettua un tiro salvezza su Forza; se lo fallisce, il guerriero lo spinge fino a 4,5 metri lontano da sé.\n\n***Incoraggiamento.*** Come azione bonus nel suo turno, il guerriero può spendere un dado di superiorità per rinsaldare una creatura amica in grado di vederlo o di sentirlo. Quella creatura ottiene punti ferita temporanei pari al risultato del dado + il modificatore di Carisma del guerriero.\n\n***Replica.*** Quando una creatura lo manca con un attacco in mischia, il guerriero può usare la sua reazione e spendere un dado di superiorità per effettuare un attacco con un'arma da mischia contro di essa. Se colpisce, aggiunge il dado ai danni.\n\n***Attacco con Spazzata.*** Quando colpisce una creatura con un attacco con un'arma da mischia, il guerriero può spendere un dado di superiorità per colpire una seconda creatura entro 1,5 metri dalla prima ed entro la propria portata. Se il tiro per colpire originale colpirebbe la seconda creatura, questa subisce danni pari al risultato del dado, dello stesso tipo di quelli dell'attacco originale.\n\n***Attacco Sbilanciante.*** Quando colpisce una creatura con un attacco con un'arma, il guerriero può spendere un dado di superiorità e aggiungerlo ai danni. Se il bersaglio è di taglia Grande o inferiore, effettua un tiro salvezza su Forza; se lo fallisce, il guerriero lo butta a terra prono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/student-of-war"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/student-of-war", "en"), Language = LanguageCode.En, Name = "Student of War", Description = "At 3rd level, you become proficient with one type of artisan's tools of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/student-of-war", "it"), Language = LanguageCode.It, Name = "Studioso di Guerra", Description = "Al 3° livello il guerriero ottiene competenza in un tipo di strumenti da artigiano a sua scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/know-your-enemy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/know-your-enemy", "en"), Language = LanguageCode.En, Name = "Know Your Enemy", Description = "From 7th level, if you spend at least 1 minute watching or dealing with a creature outside combat, you can size it up. The DM tells you whether the creature is your equal, superior, or inferior in two of these characteristics of your choice:\n- Strength score\n- Dexterity score\n- Constitution score\n- Armor Class\n- Current hit points\n- Total class levels (if any)\n- Fighter class levels (if any)" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/know-your-enemy", "it"), Language = LanguageCode.It, Name = "Conosci il Tuo Nemico", Description = "Dal 7° livello, se passa almeno 1 minuto a osservare una creatura o a interagire con essa fuori dal combattimento, il guerriero può valutarla. Il DM gli dice se la creatura gli è pari, superiore o inferiore in due tra queste caratteristiche a sua scelta:\n- Punteggio di Forza\n- Punteggio di Destrezza\n- Punteggio di Costituzione\n- Classe Armatura\n- Punti ferita attuali\n- Livelli di classe totali (se ne ha)\n- Livelli da guerriero (se ne ha)" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/improved-combat-superiority"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/improved-combat-superiority", "en"), Language = LanguageCode.En, Name = "Improved Combat Superiority", Description = "At 10th level, your superiority dice become d10s. At 18th level, they become d12s." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/improved-combat-superiority", "it"), Language = LanguageCode.It, Name = "Superiorità in Combattimento Migliorata", Description = "Al 10° livello i dadi di superiorità del guerriero diventano d10. Al 18° livello diventano d12." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/relentless"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/relentless", "en"), Language = LanguageCode.En, Name = "Relentless", Description = "From 15th level, when you roll initiative with no superiority dice left, you regain one superiority die." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "battle-master/relentless", "it"), Language = LanguageCode.It, Name = "Implacabile", Description = "Dal 15° livello, quando tira per l'iniziativa e non gli resta alcun dado di superiorità, il guerriero ne recupera uno." }
					}
				}
			}
		};
	}
}
