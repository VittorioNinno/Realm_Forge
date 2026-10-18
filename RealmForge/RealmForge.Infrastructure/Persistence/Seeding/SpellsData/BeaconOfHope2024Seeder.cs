using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Beacon of Hope (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BeaconOfHope2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "beacon-of-hope");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "beacon-of-hope", "en"),
					Language = LanguageCode.En,
					Name = "Beacon of Hope",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Choose any number of creatures within range. For the duration, each target has Advantage on Wisdom saving throws and Death Saving Throws and regains the maximum number of Hit Points possible from any healing.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "beacon-of-hope", "it"),
					Language = LanguageCode.It,
					Name = "Faro di Speranza",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore sceglie un qualsiasi numero di creature entro gittata. Per la durata, ogni bersaglio dispone di vantaggio ai tiri salvezza su Saggezza e ai tiri salvezza contro la morte, e recupera il numero massimo possibile di punti ferita da qualsiasi forma di guarigione.",
					HigherLevels = null
				}
			}
		};
	}
}
