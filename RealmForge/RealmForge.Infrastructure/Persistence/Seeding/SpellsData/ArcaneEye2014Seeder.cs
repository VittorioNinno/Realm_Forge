using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Eye (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneEye2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-eye");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-eye", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Eye",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of bat fur",
					Description = "You create an invisible, magical eye within range that hovers in the air for the duration.\n\nYou mentally receive visual information from the eye, which has normal vision and darkvision out to 30 feet. The eye can look in every direction.\n\nAs an action, you can move the eye up to 30 feet in any direction. There is no limit to how far away from you the eye can move, but it can't enter another plane of existence. A solid barrier blocks the eye's movement, but the eye can pass through an opening as small as 1 inch in diameter.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-eye", "it"),
					Language = LanguageCode.It,
					Name = "Occhio Arcano",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un po' di pelo di pipistrello",
					Description = "L'incantatore crea entro gittata un occhio magico invisibile che fluttua a mezz'aria per la durata.\n\nL'incantatore riceve mentalmente le informazioni visive dall'occhio, che possiede vista normale e scurovisione entro 9 metri. L'occhio può guardare in ogni direzione.\n\nCome azione, l'incantatore può spostare l'occhio di un massimo di 9 metri in qualsiasi direzione. Non c'è limite alla distanza a cui l'occhio può allontanarsi dall'incantatore, ma non può entrare in un altro piano di esistenza. Una barriera solida blocca il movimento dell'occhio, ma l'occhio può passare attraverso un'apertura del diametro di appena 2,5 cm.",
					HigherLevels = null
				}
			}
		};
	}
}
