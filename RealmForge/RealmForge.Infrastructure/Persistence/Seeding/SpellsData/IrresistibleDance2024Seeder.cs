using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Irresistible Dance (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IrresistibleDance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "irresistible-dance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "irresistible-dance", "en"),
					Language = LanguageCode.En,
					Name = "Irresistible Dance",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "One creature that you can see within range must make a Wisdom saving throw. On a successful save, the target dances comically until the end of its next turn, during which it must spend all its movement to dance in place.\n\nOn a failed save, the target has the Charmed condition for the duration. While Charmed, the target dances comically, must use all its movement to dance in place, and has Disadvantage on Dexterity saving throws and attack rolls, and other creatures have Advantage on attack rolls against it. On each of its turns, the target can take an action to collect itself and repeat the save, ending the spell on itself on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "irresistible-dance", "it"),
					Language = LanguageCode.It,
					Name = "Danza Irresistibile",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Una creatura entro gittata che l'incantatore è in grado di vedere deve effettuare un tiro salvezza su Saggezza. Se lo supera, il bersaglio balla in modo comico fino alla fine del suo turno successivo, durante il quale deve spendere tutto il suo movimento per ballare sul posto.\n\nSe lo fallisce, il bersaglio è affascinato per la durata. Finché è affascinato, il bersaglio balla in modo comico, deve usare tutto il suo movimento per ballare sul posto e subisce svantaggio ai tiri salvezza su Destrezza e ai tiri per colpire, mentre le altre creature dispongono di vantaggio ai tiri per colpire contro di esso. In ognuno dei suoi turni, il bersaglio può effettuare un'azione per ricomporsi e ripetere il tiro salvezza; se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = null
				}
			}
		};
	}
}
