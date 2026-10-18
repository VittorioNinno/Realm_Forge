using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Power Word Heal (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class PowerWordHeal2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "power-word-heal");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 9,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "power-word-heal", "en"),
					Language = LanguageCode.En,
					Name = "Power Word Heal",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You speak a word of power and a flood of healing energy sweeps through the creature you touch. The target regains all its hit points. If it is charmed, frightened, paralyzed, or stunned, that condition ends. If it is prone, it can use its reaction to stand up. This spell has no effect on undead or constructs.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "power-word-heal", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Potere Guarire",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia una parola del potere e un'ondata di energia curativa pervade la creatura che tocca. Il bersaglio recupera tutti i suoi punti ferita. Se è affascinato, paralizzato, spaventato o stordito, quella condizione termina. Se è prono, può usare la sua reazione per rialzarsi. Questo incantesimo non ha alcun effetto sui non morti e sui costrutti.",
					HigherLevels = null
				}
			}
		};
	}
}
