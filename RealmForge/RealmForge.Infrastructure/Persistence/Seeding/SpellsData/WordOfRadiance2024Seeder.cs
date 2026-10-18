using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Word of Radiance (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class WordOfRadiance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-radiance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-radiance", "en"),
					Language = LanguageCode.En,
					Name = "Word of Radiance",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a token shaped like a sunburst",
					Description = "You utter a single word charged with holy light, and burning brilliance flares in a 5-foot Emanation around you. You pick which creatures you can see in that area are affected; each of them attempts a Constitution saving throw and suffers 1d6 Radiant damage if it fails.",
					HigherLevels = "The damage becomes 2d6 at level 5, 3d6 at level 11, and 4d6 at level 17."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "word-of-radiance", "it"),
					Language = LanguageCode.It,
					Name = "Parola Radiosa",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un amuleto a forma di sole raggiante",
					Description = "L'incantatore pronuncia un'unica parola carica di luce sacra, e uno splendore ardente divampa in un'emanazione di 1,5 metri attorno a lui. L'incantatore sceglie quali creature visibili in quell'area sono colpite; ognuna di esse tenta un tiro salvezza su Costituzione e subisce 1d6 danni radiosi se fallisce.",
					HigherLevels = "I danni diventano 2d6 al 5° livello, 3d6 all'11° livello e 4d6 al 17° livello."
				}
			}
		};
	}
}
