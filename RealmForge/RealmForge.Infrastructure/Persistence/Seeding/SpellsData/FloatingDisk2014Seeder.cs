using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Floating Disk (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FloatingDisk2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "floating-disk");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "floating-disk", "en"),
					Language = LanguageCode.En,
					Name = "Floating Disk",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "a drop of mercury",
					Description = "This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1 inch thick, that floats 3 feet above the ground in an unoccupied space of your choice that you can see within range. The disk remains for the duration, and can hold up to 500 pounds. If more weight is placed on it, the spell ends, and everything on the disk falls to the ground.\n\nThe disk is immobile while you are within 20 feet of it. If you move more than 20 feet away from it, the disk follows you so that it remains within 20 feet of you. If can move across uneven terrain, up or down stairs, slopes and the like, but it can't cross an elevation change of 10 feet or more. For example, the disk can't move across a 10-foot-deep pit, nor could it leave such a pit if it was created at the bottom.\n\nIf you move more than 100 feet away from the disk (typically because it can't move around an obstacle to follow you), the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "floating-disk", "it"),
					Language = LanguageCode.It,
					Name = "Disco Fluttuante",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "una goccia di mercurio",
					Description = "Questo incantesimo crea un piano di forza circolare e orizzontale, del diametro di 90 cm e spesso 2,5 cm, che fluttua a 90 cm dal terreno in uno spazio libero entro gittata, scelto dall'incantatore e che egli sia in grado di vedere. Il disco rimane per la durata e può sostenere fino a 250 kg. Se viene caricato con un peso maggiore, l'incantesimo termina e tutto ciò che si trova sul disco cade a terra.\n\nIl disco resta immobile finché l'incantatore si trova entro 6 metri da esso. Se l'incantatore si allontana di più di 6 metri, il disco lo segue in modo da rimanere entro 6 metri da lui. Può muoversi su terreno irregolare, salire o scendere scale, pendii e simili, ma non può superare un dislivello di 3 metri o più. Per esempio, il disco non può attraversare una fossa profonda 3 metri, né potrebbe uscire da una fossa simile se fosse stato creato sul fondo.\n\nSe l'incantatore si allontana di più di 30 metri dal disco (di solito perché il disco non può aggirare un ostacolo per seguirlo), l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
