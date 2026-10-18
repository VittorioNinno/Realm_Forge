using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mass Healing Word (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MassHealingWord2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-healing-word");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-healing-word", "en"),
					Language = LanguageCode.En,
					Name = "Mass Healing Word",
					CastingTime = "1 bonus action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "As you call out words of restoration, up to six creatures of your choice that you can see within range regain hit points equal to 1d4 + your spellcasting ability modifier. This spell has no effect on undead or constructs.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the healing increases by 1d4 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-healing-word", "it"),
					Language = LanguageCode.It,
					Name = "Parola Guaritrice di Massa",
					CastingTime = "1 azione bonus",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Mentre l'incantatore pronuncia parole di ristoro, fino a sei creature a sua scelta entro gittata, che egli sia in grado di vedere, recuperano un numero di punti ferita pari a 1d4 + il modificatore di caratteristica da incantatore dell'incantatore. Questo incantesimo non ha alcun effetto sui non morti e sui costrutti.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, la guarigione aumenta di 1d4 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
