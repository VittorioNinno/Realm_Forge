using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mind Blank (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MindBlank2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-blank");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-blank", "en"),
					Language = LanguageCode.En,
					Name = "Mind Blank",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = null,
					Description = "Until the spell ends, one willing creature you touch has Immunity to Psychic damage and the Charmed condition. The target is also unaffected by anything that would sense its emotions or alignment, read its thoughts, or magically detect its location, and no spell—not even *Wish*—can gather information about the target, observe it remotely, or control its mind.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-blank", "it"),
					Language = LanguageCode.It,
					Name = "Vuoto Mentale",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = null,
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore è immune ai danni psichici e alla condizione affascinato. Il bersaglio non è inoltre influenzato da nulla che possa percepirne le emozioni o l'allineamento, leggerne i pensieri o individuarne magicamente la posizione, e nessun incantesimo (nemmeno *desiderio*) può raccogliere informazioni sul bersaglio, osservarlo a distanza o controllarne la mente.",
					HigherLevels = null
				}
			}
		};
	}
}
