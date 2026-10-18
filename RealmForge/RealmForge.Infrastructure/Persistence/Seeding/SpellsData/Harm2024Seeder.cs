using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Harm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Harm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "harm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "harm", "en"),
					Language = LanguageCode.En,
					Name = "Harm",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You unleash virulent magic on a creature you can see within range. The target makes a Constitution saving throw. On a failed save, it takes 14d6 Necrotic damage, and its Hit Point maximum is reduced by an amount equal to the Necrotic damage it took. On a successful save, it takes half as much damage only. This spell can't reduce a target's Hit Point maximum below 1.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "harm", "it"),
					Language = LanguageCode.It,
					Name = "Ferire",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scatena una magia virulenta su una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Costituzione. Se lo fallisce, subisce 14d6 danni necrotici e il suo massimo dei punti ferita si riduce di un ammontare pari ai danni necrotici subiti. Se lo supera, subisce soltanto la metà dei danni. Questo incantesimo non può ridurre il massimo dei punti ferita di un bersaglio al di sotto di 1.",
					HigherLevels = null
				}
			}
		};
	}
}
