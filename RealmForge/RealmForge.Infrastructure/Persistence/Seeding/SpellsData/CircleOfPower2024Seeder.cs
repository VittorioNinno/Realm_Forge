using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Circle of Power (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CircleOfPower2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-power");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-power", "en"),
					Language = LanguageCode.En,
					Name = "Circle of Power",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "A 30-foot Emanation of warding magic surrounds you for the duration, shielding you and your allies while they stand within it:\n\n- Saving throws against spells and other magical effects are made with Advantage.\n- Against a spell or magical effect that normally inflicts half damage on a successful save, a success means no damage at all.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-power", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Potere",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Per la durata, un'emanazione di 9 metri di magia protettiva circonda l'incantatore e scherma lui e i suoi alleati finché si trovano al suo interno:\n\n- I tiri salvezza contro incantesimi e altri effetti magici si effettuano con vantaggio.\n- Contro un incantesimo o un effetto magico che normalmente infligge metà dei danni con un tiro salvezza riuscito, un successo annulla del tutto i danni.",
					HigherLevels = null
				}
			}
		};
	}
}
