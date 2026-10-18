using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telepathy (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Telepathy2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 8,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathy", "en"),
					Language = LanguageCode.En,
					Name = "Telepathy",
					CastingTime = "1 action",
					Range = "Unlimited",
					Duration = "24 hours",
					MaterialComponent = "a pair of linked silver rings",
					Description = "You open a telepathic link between yourself and a willing creature you know well. The creature can be anywhere on your plane of existence; the spell ends if either of you leaves that plane.\n\nUntil the spell ends, you and the target can instantly exchange words, images, sounds, and other sensory messages through the link, and the target knows that it is you on the other end. The link lets any creature with an Intelligence score of at least 1 understand what you mean and grasp the content of the sensory messages you send.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "telepathy", "it"),
					Language = LanguageCode.It,
					Name = "Telepatia",
					CastingTime = "1 azione",
					Range = "Illimitata",
					Duration = "24 ore",
					MaterialComponent = "un paio di anelli d'argento collegati",
					Description = "L'incantatore apre un legame telepatico tra sé e una creatura consenziente che conosce bene. La creatura può trovarsi in qualsiasi punto del piano di esistenza dell'incantatore; l'incantesimo termina se uno dei due lascia quel piano.\n\nFinché l'incantesimo non termina, l'incantatore e il bersaglio possono scambiarsi istantaneamente parole, immagini, suoni e altri messaggi sensoriali attraverso il legame, e il bersaglio sa che dall'altra parte c'è l'incantatore. Il legame permette a qualsiasi creatura con un punteggio di Intelligenza pari ad almeno 1 di comprendere ciò che l'incantatore intende e di cogliere il contenuto dei messaggi sensoriali che le invia.",
					HigherLevels = null
				}
			}
		};
	}
}
