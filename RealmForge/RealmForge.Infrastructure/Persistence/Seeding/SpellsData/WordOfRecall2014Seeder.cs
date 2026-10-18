using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Word of Recall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WordOfRecall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "word-of-recall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "word-of-recall", "en"),
					Language = LanguageCode.En,
					Name = "Word of Recall",
					CastingTime = "1 action",
					Range = "5 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You and up to five willing creatures within 5 feet of you instantly teleport to a previously designated sanctuary. You and any creatures that teleport with you appear in the nearest unoccupied space to the spot you designated when you prepared your sanctuary (see below). If you cast this spell without first preparing a sanctuary, the spell has no effect.\n\nYou must designate a sanctuary by casting this spell within a location, such as a temple, dedicated to or strongly linked to your deity. If you attempt to cast the spell in this manner in an area that isn't dedicated to your deity, the spell has no effect.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "word-of-recall", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Ritiro",
					CastingTime = "1 azione",
					Range = "1,5 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore e fino a cinque creature consenzienti entro 1,5 metri da lui si teletrasportano istantaneamente in un santuario designato in precedenza. L'incantatore e le creature che si teletrasportano con lui compaiono nello spazio libero più vicino al punto designato quando ha preparato il santuario (vedi sotto). Se l'incantatore lancia questo incantesimo senza aver prima preparato un santuario, l'incantesimo non ha alcun effetto.\n\nL'incantatore deve designare un santuario lanciando questo incantesimo all'interno di un luogo, come un tempio, dedicato alla sua divinità o fortemente legato a essa. Se tenta di lanciare l'incantesimo in questo modo in un'area che non è dedicata alla sua divinità, l'incantesimo non ha alcun effetto.",
					HigherLevels = null
				}
			}
		};
	}
}
