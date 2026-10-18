using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ray of Sickness (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class RayOfSickness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ray-of-sickness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ray-of-sickness", "en"),
					Language = LanguageCode.En,
					Name = "Ray of Sickness",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A ray of sickly green energy streaks toward a creature within range. Make a ranged spell attack against it. On a hit, the target takes 2d8 poison damage and makes a Constitution saving throw; on a failure, it is also poisoned until the end of your next turn.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ray-of-sickness", "it"),
					Language = LanguageCode.It,
					Name = "Raggio di Infermità",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un raggio di energia verdastra e nauseante sfreccia verso una creatura entro gittata. L'incantatore effettua contro di essa un attacco con incantesimo a distanza. Se colpisce, il bersaglio subisce 2d8 danni da veleno ed effettua un tiro salvezza su Costituzione; se lo fallisce, è anche avvelenato fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
