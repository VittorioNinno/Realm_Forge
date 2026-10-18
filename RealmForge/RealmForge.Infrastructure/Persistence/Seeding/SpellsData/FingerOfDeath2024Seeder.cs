using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Finger of Death (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FingerOfDeath2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "finger-of-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "finger-of-death", "en"),
					Language = LanguageCode.En,
					Name = "Finger of Death",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You unleash negative energy toward a creature you can see within range. The target makes a Constitution saving throw, taking 7d8 + 30 Necrotic damage on a failed save or half as much damage on a successful one.\n\nA Humanoid killed by this spell rises at the start of your next turn as a **Zombie** (see \"Monsters\") that follows your verbal orders.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "finger-of-death", "it"),
					Language = LanguageCode.It,
					Name = "Dito della Morte",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scatena un'ondata di energia negativa contro una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Costituzione, subendo 7d8 + 30 danni necrotici se lo fallisce, o la metà di quei danni se lo supera.\n\nUn umanoide ucciso da questo incantesimo si rialza all'inizio del turno successivo dell'incantatore come **zombi** (vedi il capitolo \"Mostri\" dell'SRD) che obbedisce ai suoi ordini verbali.",
					HigherLevels = null
				}
			}
		};
	}
}
