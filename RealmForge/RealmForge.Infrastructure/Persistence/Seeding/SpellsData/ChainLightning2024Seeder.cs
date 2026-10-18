using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chain Lightning (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ChainLightning2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chain-lightning");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chain-lightning", "en"),
					Language = LanguageCode.En,
					Name = "Chain Lightning",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "three silver pins",
					Description = "You launch a lightning bolt toward a target you can see within range. Three bolts then leap from that target to as many as three other targets of your choice, each of which must be within 30 feet of the first target. A target can be a creature or an object and can be targeted by only one of the bolts.\n\nEach target makes a Dexterity saving throw, taking 10d8 Lightning damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "One additional bolt leaps from the first target to another target for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chain-lightning", "it"),
					Language = LanguageCode.It,
					Name = "Catena di Fulmini",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "tre spilli d'argento",
					Description = "L'incantatore scaglia un fulmine verso un bersaglio entro gittata che è in grado di vedere. Da quel bersaglio balzano poi tre fulmini, diretti verso un massimo di altri tre bersagli a scelta dell'incantatore, ognuno dei quali deve trovarsi entro 9 metri dal primo bersaglio. Un bersaglio può essere una creatura o un oggetto e può essere colpito da un solo fulmine.\n\nOgni bersaglio effettua un tiro salvezza su Destrezza, subendo 10d8 danni da fulmine se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "Un fulmine aggiuntivo balza dal primo bersaglio verso un altro bersaglio per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
