using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Stoneskin (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Stoneskin2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stoneskin");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stoneskin", "en"),
					Language = LanguageCode.En,
					Name = "Stoneskin",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "diamond dust worth 100+ GP, which the spell consumes",
					Description = "Until the spell ends, one willing creature you touch has Resistance to Bludgeoning, Piercing, and Slashing damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stoneskin", "it"),
					Language = LanguageCode.It,
					Name = "Pelle di Pietra",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "polvere di diamante del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore ha resistenza ai danni contundenti, perforanti e taglienti.",
					HigherLevels = null
				}
			}
		};
	}
}
