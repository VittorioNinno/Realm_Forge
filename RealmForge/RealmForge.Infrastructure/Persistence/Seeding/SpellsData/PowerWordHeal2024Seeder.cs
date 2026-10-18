using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Power Word Heal (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PowerWordHeal2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-heal");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-heal", "en"),
					Language = LanguageCode.En,
					Name = "Power Word Heal",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A wave of healing energy washes over one creature you can see within range. The target regains all its Hit Points. If the creature has the Charmed, Frightened, Paralyzed, Poisoned, or Stunned condition, the condition ends. If the creature has the Prone condition, it can use its Reaction to stand up.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-heal", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Potere Guarire",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un'ondata di energia curativa investe una creatura entro gittata che l'incantatore è in grado di vedere. Il bersaglio recupera tutti i propri punti ferita. Se la creatura è affascinata, avvelenata, paralizzata, spaventata o stordita, la condizione termina. Se la creatura è prona, può usare la propria reazione per rialzarsi.",
					HigherLevels = null
				}
			}
		};
	}
}
