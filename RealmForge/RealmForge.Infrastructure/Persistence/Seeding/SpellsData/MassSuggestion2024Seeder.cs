using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mass Suggestion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MassSuggestion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-suggestion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-suggestion", "en"),
					Language = LanguageCode.En,
					Name = "Mass Suggestion",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "24 hours",
					MaterialComponent = "a snake's tongue",
					Description = "You suggest a course of activity—described in no more than 25 words—to twelve or fewer creatures you can see within range that can hear and understand you. The suggestion must sound achievable and not involve anything that would obviously deal damage to any of the targets or their allies. For example, you could say, \"Walk to the village down that road, and help the villagers there harvest crops until sunset.\" Or you could say, \"Now is not the time for violence. Drop your weapons, and dance! Stop in an hour.\"\n\nEach target must succeed on a Wisdom saving throw or have the Charmed condition for the duration or until you or your allies deal damage to the target. Each Charmed target pursues the suggestion to the best of its ability. The suggested activity can continue for the entire duration, but if the suggested activity can be completed in a shorter time, the spell ends for a target upon completing it.",
					HigherLevels = "The duration is longer with a spell slot of level 7 (10 days), 8 (30 days), or 9 (366 days)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mass-suggestion", "it"),
					Language = LanguageCode.It,
					Name = "Suggestione di Massa",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "24 ore",
					MaterialComponent = "una lingua di serpente",
					Description = "L'incantatore suggerisce una linea d'azione (descritta in non più di 25 parole) a un massimo di dodici creature entro gittata che è in grado di vedere e che possono sentirlo e comprenderlo. La suggestione deve sembrare realizzabile e non deve comportare nulla che infliggerebbe ovviamente danni a uno qualsiasi dei bersagli o ai loro alleati. Per esempio, l'incantatore potrebbe dire: \"Andate al villaggio in fondo a quella strada e aiutate gli abitanti a raccogliere il grano fino al tramonto\". Oppure: \"Non è il momento della violenza. Gettate le armi e ballate! Smettete tra un'ora\".\n\nOgni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è affascinato per la durata o finché l'incantatore o i suoi alleati non gli infliggono danni. Ogni bersaglio affascinato persegue la suggestione al meglio delle sue capacità. L'attività suggerita può proseguire per l'intera durata, ma se può essere portata a termine in un tempo più breve, l'incantesimo termina per un bersaglio quando la completa.",
					HigherLevels = "La durata è maggiore con uno slot incantesimo di 7° livello (10 giorni), di 8° livello (30 giorni) o di 9° livello (366 giorni)."
				}
			}
		};
	}
}
