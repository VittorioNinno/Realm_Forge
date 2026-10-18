using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Geas (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Geas2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "geas");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "geas", "en"),
					Language = LanguageCode.En,
					Name = "Geas",
					CastingTime = "1 minute",
					Range = "60 feet",
					Duration = "30 days",
					MaterialComponent = null,
					Description = "You place a magical command on a creature that you can see within range, forcing it to carry out some service or refrain from some action or course of activity as you decide. If the creature can understand you, it must succeed on a Wisdom saving throw or become charmed by you for the duration. While the creature is charmed by you, it takes 5d10 psychic damage each time it acts in a manner directly counter to your instructions, but no more than once each day. A creature that can't understand you is unaffected by the spell.\n\nYou can issue any command you choose, short of an activity that would result in certain death. Should you issue a suicidal command, the spell ends.\n\nYou can end the spell early by using an action to dismiss it. A remove curse, greater restoration, or wish spell also ends it.",
					HigherLevels = "When you cast this spell using a spell slot of 7th or 8th level, the duration is 1 year. When you cast this spell using a spell slot of 9th level, the spell lasts until it is ended by one of the spells mentioned above."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "geas", "it"),
					Language = LanguageCode.It,
					Name = "Costrizione",
					CastingTime = "1 minuto",
					Range = "18 metri",
					Duration = "30 giorni",
					MaterialComponent = null,
					Description = "L'incantatore impone un comando magico a una creatura entro gittata che sia in grado di vedere, costringendola a svolgere un servizio o ad astenersi da un'azione o da una linea di condotta, a sua discrezione. Se la creatura è in grado di comprenderlo, deve superare un tiro salvezza su Saggezza, altrimenti è affascinata dall'incantatore per la durata. Finché è affascinata dall'incantatore, la creatura subisce 5d10 danni psichici ogni volta che agisce in modo direttamente contrario alle sue istruzioni, ma non più di una volta al giorno. Una creatura che non è in grado di comprendere l'incantatore non è influenzata dall'incantesimo.\n\nL'incantatore può impartire qualsiasi comando desideri, tranne un'attività che porterebbe a morte certa. Se impartisce un comando suicida, l'incantesimo termina.\n\nL'incantatore può porre fine prematuramente all'incantesimo usando un'azione per congedarlo. Anche un incantesimo rimuovi maledizione, ristorare superiore o desiderio pone fine all'incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° o di 8° livello, la durata è di 1 anno. Quando lo lancia usando uno slot incantesimo di 9° livello, l'incantesimo dura finché non viene interrotto da uno degli incantesimi sopra menzionati."
				}
			}
		};
	}
}
