using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Calm Emotions (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CalmEmotions2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "calm-emotions");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "calm-emotions", "en"),
					Language = LanguageCode.En,
					Name = "Calm Emotions",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Each Humanoid in a 20-foot-radius Sphere centered on a point you choose within range must succeed on a Charisma saving throw or be affected by one of the following effects (choose for each creature):\n\n- The creature has Immunity to the Charmed and Frightened conditions until the spell ends. If the creature was already Charmed or Frightened, those conditions are suppressed for the duration.\n\n- The creature becomes Indifferent about creatures of your choice that it's Hostile toward. This indifference ends if the target takes damage or witnesses its allies taking damage. When the spell ends, the creature's attitude returns to normal.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "calm-emotions", "it"),
					Language = LanguageCode.It,
					Name = "Calmare Emozioni",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Ogni umanoide in una sfera del raggio di 6 metri centrata su un punto entro gittata a scelta dell'incantatore deve superare un tiro salvezza su Carisma, altrimenti subisce uno degli effetti seguenti (a scelta dell'incantatore per ogni creatura):\n\n- La creatura è immune alle condizioni affascinato e spaventato finché l'incantesimo non termina. Se la creatura era già affascinata o spaventata, quelle condizioni sono sospese per la durata.\n\n- La creatura diventa indifferente nei confronti delle creature a scelta dell'incantatore verso cui è ostile. Questa indifferenza termina se il bersaglio subisce danni o vede i propri alleati subire danni. Quando l'incantesimo termina, l'atteggiamento della creatura torna normale.",
					HigherLevels = null
				}
			}
		};
	}
}
