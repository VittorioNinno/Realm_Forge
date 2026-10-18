using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Finger of Death (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FingerOfDeath2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "finger-of-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "finger-of-death", "en"),
					Language = LanguageCode.En,
					Name = "Finger of Death",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You send negative energy coursing through a creature that you can see within range, causing it searing pain. The target must make a Constitution saving throw. It takes 7d8 + 30 necrotic damage on a failed save, or half as much damage on a successful one.\n\nA humanoid killed by this spell rises at the start of your next turn as a zombie that is permanently under your command, following your verbal orders to the best of its ability.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "finger-of-death", "it"),
					Language = LanguageCode.It,
					Name = "Dito della Morte",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore fa scorrere dell'energia negativa attraverso una creatura entro gittata che sia in grado di vedere, provocandole un dolore lancinante. Il bersaglio deve effettuare un tiro salvezza su Costituzione. Subisce 7d8 + 30 danni necrotici se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nUn umanoide ucciso da questo incantesimo si rialza all'inizio del turno successivo dell'incantatore come zombi permanentemente sotto il suo comando, ed esegue i suoi ordini verbali al meglio delle sue capacità.",
					HigherLevels = null
				}
			}
		};
	}
}
