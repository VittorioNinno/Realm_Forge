using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telepathic Bond (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TelepathicBond2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathic-bond");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathic-bond", "en"),
					Language = LanguageCode.En,
					Name = "Telepathic Bond",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "two eggs",
					Description = "You forge a telepathic link among up to eight willing creatures of your choice within range, psychically linking each creature to all the others for the duration. Creatures that can't communicate in any languages aren't affected by this spell.\n\nUntil the spell ends, the targets can communicate telepathically through the bond whether or not they share a language. The communication is possible over any distance, though it can't extend to other planes of existence.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathic-bond", "it"),
					Language = LanguageCode.It,
					Name = "Legame Telepatico",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "due uova",
					Description = "L'incantatore crea un legame telepatico tra un massimo di otto creature consenzienti a sua scelta entro gittata, collegando psichicamente ogni creatura a tutte le altre per la durata. Le creature che non sono in grado di comunicare in alcun linguaggio non sono influenzate da questo incantesimo.\n\nFinché l'incantesimo non termina, i bersagli possono comunicare telepaticamente attraverso il legame, che abbiano o meno un linguaggio in comune. La comunicazione è possibile a qualsiasi distanza, ma non può estendersi ad altri piani di esistenza.",
					HigherLevels = null
				}
			}
		};
	}
}
