using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fly (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fly2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fly");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fly", "en"),
					Language = LanguageCode.En,
					Name = "Fly",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a wing feather from any bird",
					Description = "You touch a willing creature. The target gains a flying speed of 60 feet for the duration. When the spell ends, the target falls if it is still aloft, unless it can stop the fall.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, you can target one additional creature for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fly", "it"),
					Language = LanguageCode.It,
					Name = "Volare",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una penna dell'ala di un uccello qualsiasi",
					Description = "L'incantatore tocca una creatura consenziente. Per la durata, il bersaglio ottiene una velocità di volare di 18 metri. Quando l'incantesimo termina, il bersaglio cade se si trova ancora in volo, a meno che non riesca a interrompere la caduta.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
