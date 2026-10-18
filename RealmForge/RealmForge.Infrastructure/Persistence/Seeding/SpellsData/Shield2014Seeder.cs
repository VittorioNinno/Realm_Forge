using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shield (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shield2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield", "en"),
					Language = LanguageCode.En,
					Name = "Shield",
					CastingTime = "1 reaction, which you take when you are hit by an attack or targeted by the magic missile spell",
					Range = "Self",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "An invisible barrier of magical force appears and protects you. Until the start of your next turn, you have a +5 bonus to AC, including against the triggering attack, and you take no damage from magic missile.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield", "it"),
					Language = LanguageCode.It,
					Name = "Scudo",
					CastingTime = "1 reazione, che l'incantatore effettua quando viene colpito da un attacco o bersagliato dall'incantesimo dardo incantato",
					Range = "Incantatore",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "Una barriera invisibile di forza magica compare e protegge l'incantatore. Fino all'inizio del suo turno successivo, l'incantatore ottiene un bonus di +5 alla CA, anche contro l'attacco che ha innescato l'incantesimo, e non subisce danni da dardo incantato.",
					HigherLevels = null
				}
			}
		};
	}
}
