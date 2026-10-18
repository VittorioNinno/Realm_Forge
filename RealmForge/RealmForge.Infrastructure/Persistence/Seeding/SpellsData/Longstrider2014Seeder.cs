using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Longstrider (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Longstrider2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "longstrider");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "longstrider", "en"),
					Language = LanguageCode.En,
					Name = "Longstrider",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pinch of dirt",
					Description = "You touch a creature. The target's speed increases by 10 feet until the spell ends.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "longstrider", "it"),
					Language = LanguageCode.It,
					Name = "Passo Veloce",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di terra",
					Description = "L'incantatore tocca una creatura. La velocità del bersaglio aumenta di 3 metri finché l'incantesimo non termina.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
