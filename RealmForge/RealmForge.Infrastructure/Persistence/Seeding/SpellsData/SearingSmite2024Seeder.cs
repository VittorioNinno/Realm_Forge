using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Searing Smite (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SearingSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "searing-smite");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "searing-smite", "en"),
					Language = LanguageCode.En,
					Name = "Searing Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a target with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "As you hit the target, it takes an extra 1d6 Fire damage from the attack. At the start of each of its turns until the spell ends, the target takes 1d6 Fire damage and then makes a Constitution saving throw. On a failed save, the spell continues. On a successful save, the spell ends.",
					HigherLevels = "All the damage increases by 1d6 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "searing-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Incandescente",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito un bersaglio con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Quando l'incantatore colpisce il bersaglio, questo subisce 1d6 danni da fuoco extra dall'attacco. All'inizio di ogni suo turno finché l'incantesimo non termina, il bersaglio subisce 1d6 danni da fuoco e poi effettua un tiro salvezza su Costituzione. Se lo fallisce, l'incantesimo continua. Se lo supera, l'incantesimo termina.",
					HigherLevels = "Tutti i danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
