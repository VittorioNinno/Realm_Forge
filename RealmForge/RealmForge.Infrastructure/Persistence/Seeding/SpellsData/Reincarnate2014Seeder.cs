using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Reincarnate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Reincarnate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reincarnate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reincarnate", "en"),
					Language = LanguageCode.En,
					Name = "Reincarnate",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "rare oils and unguents worth at least 1,000 gp, which the spell consumes",
					Description = "You touch a dead humanoid or a piece of a dead humanoid. Provided that the creature has been dead no longer than 10 days, the spell forms a new adult body for it and then calls the soul to enter that body. If the target's soul isn't free or willing to do so, the spell fails.\n\nThe magic fashions a new body for the creature to inhabit, which likely causes the creature's race to change. The GM rolls a d100 and consults the following table to determine what form the creature takes when restored to life, or the GM chooses a form.\n\n| d100 | Race |\n|---|---|\n| 01-04 | Dragonborn |\n| 05-13 | Dwarf, hill |\n| 14-21 | Dwarf, mountain |\n| 22-25 | Elf, dark |\n| 26-34 | Elf, high |\n| 35-42 | Elf, wood |\n| 43-46 | Gnome, forest |\n| 47-52 | Gnome, rock |\n| 53-56 | Half-elf |\n| 57-60 | Half-orc |\n| 61-68 | Halfling, lightfoot |\n| 69-76 | Halfling, stout |\n| 77-96 | Human |\n| 97-00 | Tiefling |\n\nThe reincarnated creature recalls its former life and experiences. It retains the capabilities it had in its original form, except it exchanges its original race for the new one and changes its racial traits accordingly.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "reincarnate", "it"),
					Language = LanguageCode.It,
					Name = "Reincarnazione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "oli e unguenti rari del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca un umanoide morto o una parte di un umanoide morto. Purché la creatura non sia morta da più di 10 giorni, l'incantesimo forma per essa un nuovo corpo adulto e poi richiama l'anima affinché vi entri. Se l'anima del bersaglio non è libera o disposta a farlo, l'incantesimo fallisce.\n\nLa magia plasma un nuovo corpo che la creatura possa abitare, e ciò probabilmente fa cambiare la razza della creatura. Il DM tira un d100 e consulta la tabella seguente per determinare la forma che la creatura assume quando torna in vita, oppure sceglie una forma.\n\n| d100 | Razza |\n|---|---|\n| 01-04 | Dragonide |\n| 05-13 | Nano delle colline |\n| 14-21 | Nano delle montagne |\n| 22-25 | Elfo oscuro |\n| 26-34 | Elfo alto |\n| 35-42 | Elfo dei boschi |\n| 43-46 | Gnomo delle foreste |\n| 47-52 | Gnomo delle rocce |\n| 53-56 | Mezzelfo |\n| 57-60 | Mezzorco |\n| 61-68 | Halfling piedelesto |\n| 69-76 | Halfling tozzo |\n| 77-96 | Umano |\n| 97-00 | Tiefling |\n\nLa creatura reincarnata ricorda la sua vita e le sue esperienze precedenti. Conserva le capacità che possedeva nella sua forma originale, ma sostituisce la sua razza originale con quella nuova e modifica di conseguenza i suoi tratti razziali.",
					HigherLevels = null
				}
			}
		};
	}
}
