using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fly (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fly2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fly");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fly", "en"),
					Language = LanguageCode.En,
					Name = "Fly",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a feather",
					Description = "You touch a willing creature. For the duration, the target gains a Fly Speed of 60 feet and can hover. When the spell ends, the target falls if it is still aloft unless it can stop the fall.",
					HigherLevels = "You can target one additional creature for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fly", "it"),
					Language = LanguageCode.It,
					Name = "Volare",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una piuma",
					Description = "L'incantatore tocca una creatura consenziente. Per la durata, il bersaglio ottiene una velocità di volo di 18 metri e può fluttuare. Quando l'incantesimo termina, il bersaglio cade se si trova ancora in aria, a meno che non sia in grado di arrestare la caduta.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
