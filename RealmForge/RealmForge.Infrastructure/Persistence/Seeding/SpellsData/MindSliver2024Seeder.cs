using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mind Sliver (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class MindSliver2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-sliver");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-sliver", "en"),
					Language = LanguageCode.En,
					Name = "Mind Sliver",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "A needle of psychic force stabs into the thoughts of one creature you can see within range. The creature attempts an Intelligence saving throw. If it fails, it suffers 1d6 Psychic damage, and the first saving throw it makes before your next turn ends takes a 1d4 penalty (roll the die and subtract it).",
					HigherLevels = "The damage becomes 2d6 at level 5, 3d6 at level 11, and 4d6 at level 17."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-sliver", "it"),
					Language = LanguageCode.It,
					Name = "Scheggia della Mente",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "Un ago di forza psichica trafigge i pensieri di una creatura entro gittata che l'incantatore è in grado di vedere. La creatura tenta un tiro salvezza su Intelligenza. Se fallisce, subisce 1d6 danni psichici, e il primo tiro salvezza che effettua prima del termine del turno successivo dell'incantatore subisce una penalità di 1d4 (si tira il dado e lo si sottrae).",
					HigherLevels = "I danni diventano 2d6 al 5° livello, 3d6 all'11° livello e 4d6 al 17° livello."
				}
			}
		};
	}
}
