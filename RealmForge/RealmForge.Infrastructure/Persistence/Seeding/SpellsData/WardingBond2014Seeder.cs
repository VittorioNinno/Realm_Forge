using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Warding Bond (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WardingBond2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "warding-bond");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "warding-bond", "en"),
					Language = LanguageCode.En,
					Name = "Warding Bond",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pair of platinum rings worth at least 50 gp each, which you and the target must wear for the duration",
					Description = "This spell wards a willing creature you touch and creates a mystic connection between you and the target until the spell ends. While the target is within 60 feet of you, it gains a +1 bonus to AC and saving throws, and it has resistance to all damage. Also, each time it takes damage, you take the same amount of damage.\n\nThe spell ends if you drop to 0 hit points or if you and the target become separated by more than 60 feet.\n\nIt also ends if the spell is cast again on either of the connected creatures. You can also dismiss the spell as an action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "warding-bond", "it"),
					Language = LanguageCode.It,
					Name = "Vincolo di Interdizione",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un paio di anelli di platino del valore di almeno 50 mo ciascuno, che l'incantatore e il bersaglio devono indossare per la durata",
					Description = "Questo incantesimo protegge una creatura consenziente toccata dall'incantatore e crea un legame mistico tra l'incantatore e il bersaglio finché l'incantesimo non termina. Finché il bersaglio si trova entro 18 metri dall'incantatore, ottiene un bonus di +1 alla CA e ai tiri salvezza e ha resistenza a tutti i danni. Inoltre, ogni volta che subisce danni, l'incantatore subisce la stessa quantità di danni.\n\nL'incantesimo termina se l'incantatore scende a 0 punti ferita o se lui e il bersaglio si separano di più di 18 metri.\n\nTermina anche se l'incantesimo viene lanciato di nuovo su una delle due creature collegate. L'incantatore può anche congedare l'incantesimo come azione.",
					HigherLevels = null
				}
			}
		};
	}
}
