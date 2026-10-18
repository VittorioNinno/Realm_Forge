using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prayer of Healing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrayerOfHealing2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prayer-of-healing");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prayer-of-healing", "en"),
					Language = LanguageCode.En,
					Name = "Prayer of Healing",
					CastingTime = "10 minutes",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Up to six creatures of your choice that you can see within range each regain hit points equal to 2d8 + your spellcasting ability modifier. This spell has no effect on undead or constructs.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the healing increases by 1d8 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prayer-of-healing", "it"),
					Language = LanguageCode.It,
					Name = "Preghiera di Guarigione",
					CastingTime = "10 minuti",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Fino a sei creature a scelta dell'incantatore entro gittata, che egli sia in grado di vedere, recuperano ciascuna un numero di punti ferita pari a 2d8 + il modificatore di caratteristica da incantatore dell'incantatore. Questo incantesimo non ha alcun effetto sui non morti e sui costrutti.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, la guarigione aumenta di 1d8 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
