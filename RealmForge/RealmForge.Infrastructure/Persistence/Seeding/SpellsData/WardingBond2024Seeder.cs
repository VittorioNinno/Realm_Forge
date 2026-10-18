using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Warding Bond (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WardingBond2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "warding-bond");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "warding-bond", "en"),
					Language = LanguageCode.En,
					Name = "Warding Bond",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pair of platinum rings worth 50+ GP each, which you and the target must wear for the duration",
					Description = "You touch another creature that is willing and create a mystic connection between you and the target until the spell ends. While the target is within 60 feet of you, it gains a +1 bonus to AC and saving throws, and it has Resistance to all damage. Also, each time it takes damage, you take the same amount of damage.\n\nThe spell ends if you drop to 0 Hit Points or if you and the target become separated by more than 60 feet. It also ends if the spell is cast again on either of the connected creatures.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "warding-bond", "it"),
					Language = LanguageCode.It,
					Name = "Vincolo di Interdizione",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una coppia di anelli di platino del valore di almeno 50 mo ciascuno, che l'incantatore e il bersaglio devono indossare per la durata",
					Description = "L'incantatore tocca un'altra creatura consenziente e crea un legame mistico tra sé e il bersaglio finché l'incantesimo non termina. Finché il bersaglio si trova entro 18 metri dall'incantatore, ottiene un bonus di +1 alla CA e ai tiri salvezza e ha resistenza a tutti i danni. Inoltre, ogni volta che subisce danni, l'incantatore subisce lo stesso ammontare di danni.\n\nL'incantesimo termina se l'incantatore scende a 0 punti ferita o se l'incantatore e il bersaglio si separano di più di 18 metri. Termina anche se l'incantesimo viene lanciato di nuovo su una delle due creature collegate.",
					HigherLevels = null
				}
			}
		};
	}
}
