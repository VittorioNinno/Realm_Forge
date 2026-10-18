using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chromatic Orb (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ChromaticOrb2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chromatic-orb");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chromatic-orb", "en"),
					Language = LanguageCode.En,
					Name = "Chromatic Orb",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth at least 50 gp",
					Description = "You fling a sphere of raw energy, about 4 inches across, at a creature you can see within range. Choose acid, cold, fire, lightning, poison, or thunder as the orb's energy, then make a ranged spell attack against the target. On a hit, the target takes 3d8 damage of the chosen type.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chromatic-orb", "it"),
					Language = LanguageCode.It,
					Name = "Globo Cromatico",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 50 mo",
					Description = "L'incantatore scaglia una sfera di energia pura, del diametro di circa 10 cm, contro una creatura entro gittata che sia in grado di vedere. Sceglie acido, freddo, fuoco, fulmine, tuono o veleno come energia del globo, poi effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 3d8 danni del tipo scelto.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
