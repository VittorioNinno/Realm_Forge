using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blindness/Deafness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BlindnessDeafness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blindness-deafness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Necromancy,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blindness-deafness", "en"),
					Language = LanguageCode.En,
					Name = "Blindness/Deafness",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "You can blind or deafen a foe. Choose one creature that you can see within range to make a Constitution saving throw. If it fails, the target is either blinded or deafened (your choice) for the duration. At the end of each of its turns, the target can make a Constitution saving throw. On a success, the spell ends.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blindness-deafness", "it"),
					Language = LanguageCode.It,
					Name = "Cecità/Sordità",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore può accecare o assordare un nemico. Sceglie una creatura entro gittata che sia in grado di vedere, la quale deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, il bersaglio è accecato o assordato (a scelta dell'incantatore) per la durata. Alla fine di ogni suo turno, il bersaglio può effettuare un tiro salvezza su Costituzione. Se lo supera, l'incantesimo termina.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
