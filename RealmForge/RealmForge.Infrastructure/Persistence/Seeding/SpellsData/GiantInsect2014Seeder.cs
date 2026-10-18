using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Giant Insect (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GiantInsect2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "giant-insect");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "giant-insect", "en"),
					Language = LanguageCode.En,
					Name = "Giant Insect",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You transform up to ten centipedes, three spiders, five wasps, or one scorpion within range into giant versions of their natural forms for the duration. A centipede becomes a giant centipede, a spider becomes a giant spider, a wasp becomes a giant wasp, and a scorpion becomes a giant scorpion.\n\nEach creature obeys your verbal commands, and in combat, they act on your turn each round. The GM has the statistics for these creatures and resolves their actions and movement.\n\nA creature remains in its giant size for the duration, until it drops to 0 hit points, or until you use an action to dismiss the effect on it.\n\nThe GM might allow you to choose different targets. For example, if you transform a bee, its giant version might have the same statistics as a giant wasp.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "giant-insect", "it"),
					Language = LanguageCode.It,
					Name = "Insetto Gigante",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Per la durata, l'incantatore trasforma fino a dieci millepiedi, tre ragni, cinque vespe o uno scorpione entro gittata in versioni giganti delle loro forme naturali. Un millepiedi diventa un millepiedi gigante, un ragno diventa un ragno gigante, una vespa diventa una vespa gigante e uno scorpione diventa uno scorpione gigante.\n\nOgni creatura obbedisce ai comandi verbali dell'incantatore e, in combattimento, agisce nel turno dell'incantatore a ogni round. Il DM possiede le statistiche di queste creature e ne risolve le azioni e i movimenti.\n\nUna creatura mantiene la sua taglia gigante per la durata, finché non scende a 0 punti ferita o finché l'incantatore non usa un'azione per congedare l'effetto su di essa.\n\nIl DM può permettere all'incantatore di scegliere bersagli diversi. Per esempio, se l'incantatore trasforma un'ape, la sua versione gigante potrebbe avere le stesse statistiche di una vespa gigante.",
					HigherLevels = null
				}
			}
		};
	}
}
