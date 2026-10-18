using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Resistance (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Resistance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resistance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resistance", "en"),
					Language = LanguageCode.En,
					Name = "Resistance",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You touch a willing creature and choose a damage type: Acid, Bludgeoning, Cold, Fire, Lightning, Necrotic, Piercing, Poison, Radiant, Slashing, or Thunder. When the creature takes damage of the chosen type before the spell ends, the creature reduces the total damage taken by 1d4. A creature can benefit from this spell only once per turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resistance", "it"),
					Language = LanguageCode.It,
					Name = "Resistenza",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura consenziente e sceglie un tipo di danni: acido, contundente, freddo, fuoco, fulmine, necrotico, perforante, radioso, tagliente, tuono o veleno. Quando la creatura subisce danni del tipo scelto prima che l'incantesimo termini, riduce di 1d4 il totale dei danni subiti. Una creatura può beneficiare di questo incantesimo soltanto una volta per turno.",
					HigherLevels = null
				}
			}
		};
	}
}
