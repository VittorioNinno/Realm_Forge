using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Counterspell (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Counterspell2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "counterspell");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "counterspell", "en"),
					Language = LanguageCode.En,
					Name = "Counterspell",
					CastingTime = "Reaction, which you take when you see a creature within 60 feet of yourself casting a spell with Verbal, Somatic, or Material components",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You attempt to interrupt a creature in the process of casting a spell. The creature makes a Constitution saving throw. On a failed save, the spell dissipates with no effect, and the action, Bonus Action, or Reaction used to cast it is wasted. If that spell was cast with a spell slot, the slot isn't expended.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "counterspell", "it"),
					Language = LanguageCode.It,
					Name = "Controincantesimo",
					CastingTime = "Reazione, che l'incantatore effettua quando vede una creatura entro 18 metri da sé lanciare un incantesimo con componenti verbali, somatiche o materiali",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore tenta di interrompere una creatura mentre sta lanciando un incantesimo. La creatura effettua un tiro salvezza su Costituzione. Se lo fallisce, l'incantesimo si dissolve senza alcun effetto e l'azione, l'azione bonus o la reazione usata per lanciarlo va sprecata. Se quell'incantesimo era stato lanciato con uno slot incantesimo, lo slot non viene speso.",
					HigherLevels = null
				}
			}
		};
	}
}
