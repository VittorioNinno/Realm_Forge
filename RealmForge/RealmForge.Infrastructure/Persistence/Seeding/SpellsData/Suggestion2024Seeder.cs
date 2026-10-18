using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Suggestion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Suggestion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "suggestion");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "suggestion", "en"),
					Language = LanguageCode.En,
					Name = "Suggestion",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 8 hours",
					MaterialComponent = "a drop of honey",
					Description = "You suggest a course of activity—described in no more than 25 words—to one creature you can see within range that can hear and understand you. The suggestion must sound achievable and not involve anything that would obviously deal damage to the target or its allies. For example, you could say, \"Fetch the key to the cult's treasure vault, and give the key to me.\" Or you could say, \"Stop fighting, leave this library peacefully, and don't return.\"\n\nThe target must succeed on a Wisdom saving throw or have the Charmed condition for the duration or until you or your allies deal damage to the target. The Charmed target pursues the suggestion to the best of its ability. The suggested activity can continue for the entire duration, but if the suggested activity can be completed in a shorter time, the spell ends for the target upon completing it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "suggestion", "it"),
					Language = LanguageCode.It,
					Name = "Suggestione",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 8 ore",
					MaterialComponent = "una goccia di miele",
					Description = "L'incantatore suggerisce una linea d'azione (descritta in non più di 25 parole) a una creatura entro gittata che è in grado di vedere e che può sentirlo e comprenderlo. La suggestione deve sembrare realizzabile e non deve comportare nulla che infliggerebbe ovviamente danni al bersaglio o ai suoi alleati. Per esempio, l'incantatore potrebbe dire: \"Prendi la chiave della camera del tesoro del culto e consegnamela\". Oppure: \"Smetti di combattere, lascia questa biblioteca pacificamente e non tornare più\".\n\nIl bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è affascinato per la durata o finché l'incantatore o i suoi alleati non gli infliggono danni. Il bersaglio affascinato persegue la suggestione al meglio delle sue capacità. L'attività suggerita può proseguire per l'intera durata, ma se può essere portata a termine in un tempo più breve, l'incantesimo termina per il bersaglio quando la completa.",
					HigherLevels = null
				}
			}
		};
	}
}
