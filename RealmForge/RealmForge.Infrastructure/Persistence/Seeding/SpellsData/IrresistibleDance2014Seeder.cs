using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Irresistible Dance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IrresistibleDance2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "irresistible-dance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "irresistible-dance", "en"),
					Language = LanguageCode.En,
					Name = "Irresistible Dance",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Choose one creature that you can see within range. The target begins a comic dance in place: shuffling, tapping its feet, and capering for the duration. Creatures that can't be charmed are immune to this spell.\n\nA dancing creature must use all its movement to dance without leaving its space and has disadvantage on Dexterity saving throws and attack rolls. While the target is affected by this spell, other creatures have advantage on attack rolls against it. As an action, a dancing creature makes a Wisdom saving throw to regain control of itself. On a successful save, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "irresistible-dance", "it"),
					Language = LanguageCode.It,
					Name = "Danza Irresistibile",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura entro gittata che sia in grado di vedere. Per la durata, il bersaglio inizia una danza comica sul posto, strascicando e battendo i piedi e saltellando. Le creature che non possono essere affascinate sono immuni a questo incantesimo.\n\nUna creatura che danza deve usare tutto il suo movimento per ballare senza lasciare il proprio spazio, e subisce svantaggio ai tiri salvezza su Destrezza e ai tiri per colpire. Finché il bersaglio è influenzato da questo incantesimo, le altre creature dispongono di vantaggio ai tiri per colpire contro di esso. Come azione, una creatura che danza effettua un tiro salvezza su Saggezza per riprendere il controllo di sé. Se lo supera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
