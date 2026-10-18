using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Command (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Command2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "command");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "command", "en"),
					Language = LanguageCode.En,
					Name = "Command",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You speak a one-word command to a creature you can see within range. The target must succeed on a Wisdom saving throw or follow the command on its next turn. Choose the command from these options:\n\n**Approach.** The target moves toward you by the shortest and most direct route, ending its turn if it moves within 5 feet of you.\n\n**Drop.** The target drops whatever it is holding and then ends its turn.\n\n**Flee.** The target spends its turn moving away from you by the fastest available means.\n\n**Grovel.** The target has the Prone condition and then ends its turn.\n\n**Halt.** On its turn, the target doesn't move and takes no action or Bonus Action.",
					HigherLevels = "You can affect one additional creature for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "command", "it"),
					Language = LanguageCode.It,
					Name = "Comando",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia un comando di una sola parola rivolto a una creatura entro gittata che è in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti esegue il comando nel suo turno successivo. L'incantatore sceglie il comando tra queste opzioni:\n\n**Avvicinati.** Il bersaglio si muove verso l'incantatore seguendo il percorso più breve e diretto e termina il proprio turno se arriva entro 1,5 metri da lui.\n\n**Lascia.** Il bersaglio lascia cadere qualsiasi cosa stia impugnando, poi termina il proprio turno.\n\n**Fuggi.** Il bersaglio trascorre il proprio turno allontanandosi dall'incantatore con il mezzo più rapido a sua disposizione.\n\n**Prostrati.** Il bersaglio cade prono, poi termina il proprio turno.\n\n**Fermo.** Nel suo turno, il bersaglio non si muove e non effettua alcuna azione né azione bonus.",
					HigherLevels = "L'incantatore può influenzare una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
