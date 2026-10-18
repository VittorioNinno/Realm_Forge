using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Barrage (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ConjureBarrage2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-barrage");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-barrage", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Barrage",
					CastingTime = "1 action",
					Range = "Self (60-foot cone)",
					Duration = "Instantaneous",
					MaterialComponent = "one piece of ammunition or a thrown weapon",
					Description = "You throw a nonmagical weapon or fire a piece of nonmagical ammunition into the air, and it splits into a storm of copies that rains down in a 60-foot cone. Each creature in the cone makes a Dexterity saving throw, taking 3d8 damage on a failure or half as much on a success. The damage type matches the weapon or ammunition used.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-barrage", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Raffica",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 18 metri)",
					Duration = "Istantanea",
					MaterialComponent = "una munizione o un'arma da lancio",
					Description = "L'incantatore lancia in aria un'arma non magica o scocca una munizione non magica, che si moltiplica in una tempesta di copie e si abbatte su un cono di 18 metri. Ogni creatura nel cono effettua un tiro salvezza su Destrezza; subisce 3d8 danni se lo fallisce, o la metà di quei danni se lo supera. Il tipo di danno è quello dell'arma o della munizione usata.",
					HigherLevels = null
				}
			}
		};
	}
}
