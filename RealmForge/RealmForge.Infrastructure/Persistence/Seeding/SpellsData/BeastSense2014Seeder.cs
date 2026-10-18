using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Beast Sense (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BeastSense2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "beast-sense");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "beast-sense", "en"),
					Language = LanguageCode.En,
					Name = "Beast Sense",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You touch a willing beast and link your senses to it. For the duration, you can use your action to see through the beast's eyes and hear what it hears, and you keep doing so until you use your action to return to your own senses.\n\nWhile you are using the beast's senses, you also benefit from any special senses it has, but you are blinded and deafened with regard to your own surroundings.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "beast-sense", "it"),
					Language = LanguageCode.It,
					Name = "Percezione delle Bestie",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca una bestia consenziente e collega i propri sensi ai suoi. Per la durata, può usare la sua azione per vedere attraverso gli occhi della bestia e sentire ciò che sente, e continua a farlo finché non usa la sua azione per tornare ai propri sensi.\n\nMentre usa i sensi della bestia, l'incantatore beneficia anche di tutti i sensi speciali che essa possiede, ma è accecato e assordato per quanto riguarda ciò che lo circonda.",
					HigherLevels = null
				}
			}
		};
	}
}
