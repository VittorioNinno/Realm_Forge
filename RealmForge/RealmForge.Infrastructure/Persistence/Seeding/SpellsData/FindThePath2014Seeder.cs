using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find the Path (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindThePath2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-the-path");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-the-path", "en"),
					Language = LanguageCode.En,
					Name = "Find the Path",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Concentration, up to 1 day",
					MaterialComponent = "a set of divinatory tools—such as bones, ivory sticks, cards, teeth, or carved runes—worth 100 gp and an object from the location you wish to find",
					Description = "This spell allows you to find the shortest, most direct physical route to a specific fixed location that you are familiar with on the same plane of existence. If you name a destination on another plane of existence, a destination that moves (such as a mobile fortress), or a destination that isn't specific (such as \"a green dragon's lair\"), the spell fails.\n\nFor the duration, as long as you are on the same plane of existence as the destination, you know how far it is and in what direction it lies. While you are traveling there, whenever you are presented with a choice of paths along the way, you automatically determine which path is the shortest and most direct route (but not necessarily the safest route) to the destination.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-the-path", "it"),
					Language = LanguageCode.It,
					Name = "Scopri il Percorso",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 giorno",
					MaterialComponent = "un insieme di strumenti divinatori (come ossa, bastoncini d'avorio, carte, denti o rune intagliate) del valore di 100 mo e un oggetto proveniente dal luogo che l'incantatore desidera trovare",
					Description = "Questo incantesimo permette all'incantatore di trovare il percorso fisico più breve e diretto verso uno specifico luogo fisso a lui familiare, situato sullo stesso piano di esistenza. Se l'incantatore indica una destinazione su un altro piano di esistenza, una destinazione che si sposta (come una fortezza mobile) o una destinazione non specifica (come \"la tana di un drago verde\"), l'incantesimo fallisce.\n\nPer la durata, finché si trova sullo stesso piano di esistenza della destinazione, l'incantatore sa quanto dista e in quale direzione si trova. Mentre si dirige verso di essa, ogni volta che lungo la strada deve scegliere tra più percorsi, determina automaticamente quale sia il più breve e diretto (ma non necessariamente il più sicuro) per raggiungere la destinazione.",
					HigherLevels = null
				}
			}
		};
	}
}
