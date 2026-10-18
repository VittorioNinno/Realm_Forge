using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blindness/Deafness (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BlindnessDeafness2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blindness-deafness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blindness-deafness", "en"),
					Language = LanguageCode.En,
					Name = "Blindness/Deafness",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "One creature that you can see within range must succeed on a Constitution saving throw, or it has the Blinded or Deafened condition (your choice) for the duration. At the end of each of its turns, the target repeats the save, ending the spell on itself on a success.",
					HigherLevels = "You can target one additional creature for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blindness-deafness", "it"),
					Language = LanguageCode.It,
					Name = "Cecità/Sordità",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Una creatura entro gittata che l'incantatore è in grado di vedere deve superare un tiro salvezza su Costituzione, altrimenti è accecata o assordata (a scelta dell'incantatore) per la durata. Alla fine di ogni suo turno, il bersaglio ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
