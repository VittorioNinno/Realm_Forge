using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Longstrider (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Longstrider2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "longstrider");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "longstrider", "en"),
					Language = LanguageCode.En,
					Name = "Longstrider",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pinch of dirt",
					Description = "You touch a creature. The target's Speed increases by 10 feet until the spell ends.",
					HigherLevels = "You can target one additional creature for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "longstrider", "it"),
					Language = LanguageCode.It,
					Name = "Passo Veloce",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di terra",
					Description = "L'incantatore tocca una creatura. La velocità del bersaglio aumenta di 3 metri finché l'incantesimo non termina.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
