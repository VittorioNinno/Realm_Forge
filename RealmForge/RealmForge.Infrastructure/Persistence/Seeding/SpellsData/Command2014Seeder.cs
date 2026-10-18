using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Command (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Command2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "command");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "command", "en"),
					Language = LanguageCode.En,
					Name = "Command",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "You speak a one-word command to a creature you can see within range. The target must succeed on a Wisdom saving throw or follow the command on its next turn. The spell has no effect if the target is undead, if it doesn't understand your language, or if your command is directly harmful to it.\n\nSome typical commands and their effects follow. You might issue a command other than one described here. If you do so, the GM determines how the target behaves. If the target can't follow your command, the spell ends.\n\n***Approach.*** The target moves toward you by the shortest and most direct route, ending its turn if it moves within 5 feet of you.\n\n***Drop.*** The target drops whatever it is holding and then ends its turn.\n\n***Flee.*** The target spends its turn moving away from you by the fastest available means.\n\n***Grovel.*** The target falls prone and then ends its turn.\n\n***Halt.*** The target doesn't move and takes no actions. A flying creature stays aloft, provided that it is able to do so. If it must move to stay aloft, it flies the minimum distance needed to remain in the air.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, you can affect one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "command", "it"),
					Language = LanguageCode.It,
					Name = "Comando",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia un comando di una sola parola rivolto a una creatura entro gittata che sia in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti esegue il comando nel suo turno successivo. L'incantesimo non ha alcun effetto se il bersaglio è un non morto, se non comprende il linguaggio dell'incantatore o se il comando gli arrecherebbe direttamente danno.\n\nSeguono alcuni comandi tipici e i relativi effetti. L'incantatore può impartire un comando diverso da quelli descritti; in tal caso, è il DM a stabilire come si comporta il bersaglio. Se il bersaglio non può eseguire il comando, l'incantesimo termina.\n\n***Avvicinati.*** Il bersaglio si muove verso l'incantatore seguendo il percorso più breve e diretto, e termina il proprio turno se arriva entro 1,5 metri da lui.\n\n***Lascia.*** Il bersaglio lascia cadere qualsiasi cosa stia impugnando e poi termina il proprio turno.\n\n***Fuggi.*** Il bersaglio trascorre il proprio turno allontanandosi dall'incantatore con il mezzo più rapido a disposizione.\n\n***Striscia.*** Il bersaglio cade prono e poi termina il proprio turno.\n\n***Fermo.*** Il bersaglio non si muove e non compie alcuna azione. Una creatura volante resta in volo, purché ne sia in grado. Se deve muoversi per restare in volo, vola per la distanza minima necessaria a rimanere in aria.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, può influenzare una creatura aggiuntiva per ogni livello dello slot superiore al 1°. Quando l'incantatore le bersaglia, le creature devono trovarsi entro 9 metri l'una dall'altra."
				}
			}
		};
	}
}
