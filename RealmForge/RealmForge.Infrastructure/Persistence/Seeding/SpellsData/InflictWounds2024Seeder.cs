using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Inflict Wounds (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InflictWounds2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "inflict-wounds");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "inflict-wounds", "en"),
					Language = LanguageCode.En,
					Name = "Inflict Wounds",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A creature you touch makes a Constitution saving throw, taking 2d10 Necrotic damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "inflict-wounds", "it"),
					Language = LanguageCode.It,
					Name = "Infliggi Ferite",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una creatura toccata dall'incantatore effettua un tiro salvezza su Costituzione, subendo 2d10 danni necrotici se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
