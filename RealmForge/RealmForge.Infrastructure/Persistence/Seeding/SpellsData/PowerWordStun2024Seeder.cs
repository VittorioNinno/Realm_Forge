using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Power Word Stun (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PowerWordStun2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-stun");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-stun", "en"),
					Language = LanguageCode.En,
					Name = "Power Word Stun",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You overwhelm the mind of one creature you can see within range. If the target has 150 Hit Points or fewer, it has the Stunned condition. Otherwise, its Speed is 0 until the start of your next turn.\n\nThe Stunned target makes a Constitution saving throw at the end of each of its turns, ending the condition on itself on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-stun", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Potere Stordire",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sopraffà la mente di una creatura entro gittata che è in grado di vedere. Se il bersaglio ha 150 punti ferita o meno, è stordito. Altrimenti, la sua velocità è 0 fino all'inizio del turno successivo dell'incantatore.\n\nIl bersaglio stordito effettua un tiro salvezza su Costituzione alla fine di ogni suo turno e, se lo supera, la condizione termina su di lui.",
					HigherLevels = null
				}
			}
		};
	}
}
