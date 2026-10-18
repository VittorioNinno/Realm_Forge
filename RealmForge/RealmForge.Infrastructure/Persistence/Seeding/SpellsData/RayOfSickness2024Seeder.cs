using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ray of Sickness (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RayOfSickness2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-sickness");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-sickness", "en"),
					Language = LanguageCode.En,
					Name = "Ray of Sickness",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You shoot a greenish ray at a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 2d8 Poison damage and has the Poisoned condition until the end of your next turn.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-sickness", "it"),
					Language = LanguageCode.It,
					Name = "Raggio di Infermità",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia un raggio verdastro contro una creatura entro gittata ed effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 2d8 danni da veleno ed è avvelenato fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
