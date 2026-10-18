using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Word of Recall (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WordOfRecall2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-recall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-recall", "en"),
					Language = LanguageCode.En,
					Name = "Word of Recall",
					CastingTime = "Action",
					Range = "5 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You and up to five willing creatures within 5 feet of you instantly teleport to a previously designated sanctuary. You and any creatures that teleport with you appear in the nearest unoccupied space to the spot you designated when you prepared your sanctuary (see below). If you cast this spell without first preparing a sanctuary, the spell has no effect.\n\nYou must designate a location, such as a temple, as a sanctuary by casting this spell there.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-recall", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Ritiro",
					CastingTime = "Azione",
					Range = "1,5 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore e fino a cinque creature consenzienti entro 1,5 metri da lui si teletrasportano istantaneamente in un santuario designato in precedenza. L'incantatore e le creature che si teletrasportano con lui compaiono nello spazio libero più vicino al punto che l'incantatore ha designato quando ha preparato il santuario (vedi sotto). Se l'incantatore lancia questo incantesimo senza aver prima preparato un santuario, l'incantesimo non ha alcun effetto.\n\nL'incantatore deve designare un luogo, come un tempio, come santuario lanciando questo incantesimo in quel luogo.",
					HigherLevels = null
				}
			}
		};
	}
}
