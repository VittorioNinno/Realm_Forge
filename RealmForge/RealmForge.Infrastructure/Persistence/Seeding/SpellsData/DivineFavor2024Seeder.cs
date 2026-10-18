using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divine Favor (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DivineFavor2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-favor");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-favor", "en"),
					Language = LanguageCode.En,
					Name = "Divine Favor",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Until the spell ends, your attacks with weapons deal an extra 1d4 Radiant damage on a hit.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-favor", "it"),
					Language = LanguageCode.It,
					Name = "Favore Divino",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Finché l'incantesimo non termina, gli attacchi con un'arma dell'incantatore infliggono 1d4 danni radiosi extra quando colpiscono.",
					HigherLevels = null
				}
			}
		};
	}
}
