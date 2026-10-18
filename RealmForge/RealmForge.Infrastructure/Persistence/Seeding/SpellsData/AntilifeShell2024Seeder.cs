using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antilife Shell (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntilifeShell2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antilife-shell");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antilife-shell", "en"),
					Language = LanguageCode.En,
					Name = "Antilife Shell",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "An aura extends from you in a 10-foot Emanation for the duration. The aura prevents creatures other than Constructs and Undead from passing or reaching through it. An affected creature can cast spells or make attacks with Ranged or Reach weapons through the barrier.\n\nIf you move so that an affected creature is forced to pass through the barrier, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antilife-shell", "it"),
					Language = LanguageCode.It,
					Name = "Guscio Anti-vita",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "Un'aura si estende dall'incantatore in un'emanazione di 3 metri per la durata. L'aura impedisce alle creature che non siano costrutti o non morti di attraversarla o di allungarsi attraverso di essa. Una creatura influenzata può lanciare incantesimi o effettuare attacchi con armi a distanza o con portata attraverso la barriera.\n\nSe l'incantatore si muove in modo tale da costringere una creatura influenzata ad attraversare la barriera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
