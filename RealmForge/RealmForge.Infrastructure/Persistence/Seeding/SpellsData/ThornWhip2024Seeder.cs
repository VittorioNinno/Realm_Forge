using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thorn Whip (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ThornWhip2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thorn-whip");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thorn-whip", "en"),
					Language = LanguageCode.En,
					Name = "Thorn Whip",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a stalk from a thorny plant",
					Description = "A barbed, whiplike vine springs from your hand and lashes at a creature within range. Make a melee spell attack. A hit deals 1d6 Piercing damage, and if the creature is no bigger than Large you can also yank it up to 10 feet closer to you.",
					HigherLevels = "The damage becomes 2d6 at level 5, 3d6 at level 11, and 4d6 at level 17."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thorn-whip", "it"),
					Language = LanguageCode.It,
					Name = "Frusta di Spine",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "un gambo di una pianta spinosa",
					Description = "Un tralcio uncinato simile a una frusta scaturisce dalla mano dell'incantatore e sferza una creatura entro gittata. L'incantatore effettua un attacco con incantesimo in mischia. Un colpo a segno infligge 1d6 danni perforanti e, se la creatura non è più grande di taglia Grande, l'incantatore può anche strattonarla fino a 3 metri più vicino a sé.",
					HigherLevels = "I danni diventano 2d6 al 5° livello, 3d6 all'11° livello e 4d6 al 17° livello."
				}
			}
		};
	}
}
