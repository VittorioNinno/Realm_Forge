using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hellish Rebuke (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HellishRebuke2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hellish-rebuke");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hellish-rebuke", "en"),
					Language = LanguageCode.En,
					Name = "Hellish Rebuke",
					CastingTime = "Reaction, which you take in response to taking damage from a creature that you can see within 60 feet of yourself",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "The creature that damaged you is momentarily surrounded by green flames. It makes a Dexterity saving throw, taking 2d10 Fire damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hellish-rebuke", "it"),
					Language = LanguageCode.It,
					Name = "Intimorire Infernale",
					CastingTime = "Reazione, che l'incantatore effettua quando subisce danni da una creatura che è in grado di vedere entro 18 metri da sé",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "La creatura che ha inflitto danni all'incantatore viene avvolta per un istante da fiamme verdi. Effettua un tiro salvezza su Destrezza, subendo 2d10 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
