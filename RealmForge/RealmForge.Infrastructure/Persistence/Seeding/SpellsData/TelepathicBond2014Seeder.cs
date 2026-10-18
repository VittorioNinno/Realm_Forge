using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telepathic Bond (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TelepathicBond2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathic-bond");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathic-bond", "en"),
					Language = LanguageCode.En,
					Name = "Telepathic Bond",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "pieces of eggshell from two different kinds of creatures",
					Description = "You forge a telepathic link among up to eight willing creatures of your choice within range, psychically linking each creature to all the others for the duration. Creatures with Intelligence scores of 2 or less aren't affected by this spell.\n\nUntil the spell ends, the targets can communicate telepathically through the bond whether or not they have a common language. The communication is possible over any distance, though it can't extend to other planes of existence.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathic-bond", "it"),
					Language = LanguageCode.It,
					Name = "Legame Telepatico",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "frammenti di guscio d'uovo di due tipi diversi di creature",
					Description = "L'incantatore stabilisce un legame telepatico tra un massimo di otto creature consenzienti a sua scelta entro gittata, collegando psichicamente ogni creatura a tutte le altre per la durata. Le creature con punteggio di Intelligenza pari o inferiore a 2 non sono influenzate da questo incantesimo.\n\nFinché l'incantesimo non termina, i bersagli possono comunicare telepaticamente tramite il legame, che abbiano o meno un linguaggio in comune. La comunicazione è possibile a qualsiasi distanza, ma non può estendersi ad altri piani di esistenza.",
					HigherLevels = null
				}
			}
		};
	}
}
