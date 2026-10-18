using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Eye (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneEye2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-eye");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-eye", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Eye",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of bat fur",
					Description = "You create an Invisible, invulnerable eye within range that hovers for the duration. You mentally receive visual information from the eye, which can see in every direction. It also has Darkvision with a range of 30 feet.\n\nAs a Bonus Action, you can move the eye up to 30 feet in any direction. A solid barrier blocks the eye's movement, but the eye can pass through an opening as small as 1 inch in diameter.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-eye", "it"),
					Language = LanguageCode.It,
					Name = "Occhio Arcano",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un po' di pelo di pipistrello",
					Description = "L'incantatore crea entro gittata un occhio invisibile e invulnerabile che fluttua per la durata. L'incantatore riceve mentalmente le informazioni visive dall'occhio, che può vedere in ogni direzione. L'occhio dispone inoltre di scurovisione con un raggio di 9 metri.\n\nCome azione bonus, l'incantatore può spostare l'occhio fino a 9 metri in qualsiasi direzione. Una barriera solida blocca il movimento dell'occhio, ma l'occhio può passare attraverso un'apertura del diametro di appena 2,5 centimetri.",
					HigherLevels = null
				}
			}
		};
	}
}
