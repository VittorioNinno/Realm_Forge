using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Geas (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Geas2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "geas");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "geas", "en"),
					Language = LanguageCode.En,
					Name = "Geas",
					CastingTime = "1 minute",
					Range = "60 feet",
					Duration = "30 days",
					MaterialComponent = null,
					Description = "You give a verbal command to a creature that you can see within range, ordering it to carry out some service or refrain from an action or a course of activity as you decide. The target must succeed on a Wisdom saving throw or have the Charmed condition for the duration. The target automatically succeeds if it can't understand your command.\n\nWhile Charmed, the creature takes 5d10 Psychic damage if it acts in a manner directly counter to your command. It takes this damage no more than once each day.\n\nYou can issue any command you choose, short of an activity that would result in certain death. Should you issue a suicidal command, the spell ends.\n\nA *Remove Curse*, *Greater Restoration*, or *Wish* spell ends this spell.",
					HigherLevels = "If you use a level 7 or 8 spell slot, the duration is 365 days. If you use a level 9 spell slot, the spell lasts until it is ended by one of the spells mentioned above."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "geas", "it"),
					Language = LanguageCode.It,
					Name = "Costrizione",
					CastingTime = "1 minuto",
					Range = "18 metri",
					Duration = "30 giorni",
					MaterialComponent = null,
					Description = "L'incantatore impartisce un comando verbale a una creatura entro gittata che è in grado di vedere, ordinandole di svolgere un servizio o di astenersi da un'azione o da una linea di condotta, secondo quanto da lui stabilito. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è affascinato per la durata. Il bersaglio supera automaticamente il tiro salvezza se non è in grado di comprendere il comando.\n\nFinché è affascinata, la creatura subisce 5d10 danni psichici se agisce in modo direttamente contrario al comando dell'incantatore. Non può subire questi danni più di una volta al giorno.\n\nL'incantatore può impartire qualsiasi comando desideri, tranne un'attività che porterebbe a morte certa. Se impartisce un comando suicida, l'incantesimo termina.\n\nUn incantesimo *rimuovi maledizione*, *ristorare superiore* o *desiderio* pone fine a questo incantesimo.",
					HigherLevels = "Se l'incantatore usa uno slot incantesimo di 7° o 8° livello, la durata è di 365 giorni. Se usa uno slot incantesimo di 9° livello, l'incantesimo dura finché non viene terminato da uno degli incantesimi sopra indicati."
				}
			}
		};
	}
}
