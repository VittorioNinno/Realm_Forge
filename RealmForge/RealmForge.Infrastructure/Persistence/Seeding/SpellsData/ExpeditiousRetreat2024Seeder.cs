using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Expeditious Retreat (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ExpeditiousRetreat2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "expeditious-retreat");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "expeditious-retreat", "en"),
					Language = LanguageCode.En,
					Name = "Expeditious Retreat",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You take the Dash action, and until the spell ends, you can take that action again as a Bonus Action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "expeditious-retreat", "it"),
					Language = LanguageCode.It,
					Name = "Ritirata Rapida",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore effettua l'azione di Scatto e, finché l'incantesimo non termina, può effettuare di nuovo quell'azione come azione bonus.",
					HigherLevels = null
				}
			}
		};
	}
}
