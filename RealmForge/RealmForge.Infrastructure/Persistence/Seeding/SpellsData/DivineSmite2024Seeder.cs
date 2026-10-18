using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divine Smite (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DivineSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-smite", "en"),
					Language = LanguageCode.En,
					Name = "Divine Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a target with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "The target takes an extra 2d8 Radiant damage from the attack. The damage increases by 1d8 if the target is a Fiend or an Undead.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Divina",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito un bersaglio con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Il bersaglio subisce 2d8 danni radiosi extra dall'attacco. I danni aumentano di 1d8 se il bersaglio è un immondo o un non morto.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
