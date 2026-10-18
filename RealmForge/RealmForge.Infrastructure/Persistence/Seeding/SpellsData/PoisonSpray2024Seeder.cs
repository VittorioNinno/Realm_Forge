using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Poison Spray (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PoisonSpray2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "poison-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "poison-spray", "en"),
					Language = LanguageCode.En,
					Name = "Poison Spray",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You spray toxic mist at a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d12 Poison damage.",
					HigherLevels = "The damage increases by 1d12 when you reach levels 5 (2d12), 11 (3d12), and 17 (4d12)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "poison-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Velenoso",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore spruzza una nebbia tossica contro una creatura entro gittata ed effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d12 danni da veleno.",
					HigherLevels = "I danni aumentano di 1d12 quando l'incantatore raggiunge il 5° livello (2d12), l'11° livello (3d12) e il 17° livello (4d12)."
				}
			}
		};
	}
}
