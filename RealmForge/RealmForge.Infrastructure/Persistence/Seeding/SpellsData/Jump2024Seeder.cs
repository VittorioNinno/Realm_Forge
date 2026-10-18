using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Jump (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Jump2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "jump");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "jump", "en"),
					Language = LanguageCode.En,
					Name = "Jump",
					CastingTime = "Bonus Action",
					Range = "Touch",
					Duration = "1 minute",
					MaterialComponent = "a grasshopper's hind leg",
					Description = "You touch a willing creature. Once on each of its turns until the spell ends, that creature can jump up to 30 feet by spending 10 feet of movement.",
					HigherLevels = "You can target one additional creature for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "jump", "it"),
					Language = LanguageCode.It,
					Name = "Saltare",
					CastingTime = "Azione bonus",
					Range = "Contatto",
					Duration = "1 minuto",
					MaterialComponent = "la zampa posteriore di una cavalletta",
					Description = "L'incantatore tocca una creatura consenziente. Una volta in ognuno dei suoi turni finché l'incantesimo non termina, quella creatura può saltare fino a 9 metri spendendo 3 metri di movimento.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
