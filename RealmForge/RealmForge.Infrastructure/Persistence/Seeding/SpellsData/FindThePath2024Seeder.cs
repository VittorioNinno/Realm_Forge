using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find the Path (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindThePath2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-the-path");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-the-path", "en"),
					Language = LanguageCode.En,
					Name = "Find the Path",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Concentration, up to 1 day",
					MaterialComponent = "a set of divination tools—such as cards or runes—worth 100+ GP",
					Description = "You magically sense the most direct physical route to a location you name. You must be familiar with the location, and the spell fails if you name a destination on another plane of existence, a moving destination (such as a mobile fortress), or an unspecific destination (such as \"a green dragon's lair\").\n\nFor the duration, as long as you are on the same plane of existence as the destination, you know how far it is and in what direction it lies. Whenever you face a choice of paths along the way there, you know which path is the most direct.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-the-path", "it"),
					Language = LanguageCode.It,
					Name = "Scopri il Percorso",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 giorno",
					MaterialComponent = "un set di strumenti divinatori (come carte o rune) del valore di almeno 100 mo",
					Description = "L'incantatore percepisce magicamente il percorso fisico più diretto verso un luogo da lui nominato. Deve conoscere il luogo, e l'incantesimo fallisce se nomina una destinazione su un altro piano di esistenza, una destinazione in movimento (come una fortezza mobile) o una destinazione non specifica (come \"la tana di un drago verde\").\n\nPer la durata, finché si trova sullo stesso piano di esistenza della destinazione, l'incantatore sa quanto è lontana e in quale direzione si trova. Ogni volta che deve scegliere tra più percorsi lungo il tragitto, sa quale percorso è il più diretto.",
					HigherLevels = null
				}
			}
		};
	}
}
