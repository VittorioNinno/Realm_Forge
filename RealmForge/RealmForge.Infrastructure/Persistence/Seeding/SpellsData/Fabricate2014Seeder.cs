using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fabricate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fabricate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fabricate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fabricate", "en"),
					Language = LanguageCode.En,
					Name = "Fabricate",
					CastingTime = "10 minutes",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You convert raw materials into products of the same material. For example, you can fabricate a wooden bridge from a clump of trees, a rope from a patch of hemp, and clothes from flax or wool.\n\nChoose raw materials that you can see within range. You can fabricate a Large or smaller object (contained within a 10-foot cube, or eight connected 5-foot cubes), given a sufficient quantity of raw material. If you are working with metal, stone, or another mineral substance, however, the fabricated object can be no larger than Medium (contained within a single 5-foot cube). The quality of objects made by the spell is commensurate with the quality of the raw materials.\n\nCreatures or magic items can't be created or transmuted by this spell. You also can't use it to create items that ordinarily require a high degree of craftsmanship, such as jewelry, weapons, glass, or armor, unless you have proficiency with the type of artisan's tools used to craft such objects.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fabricate", "it"),
					Language = LanguageCode.It,
					Name = "Fabbricare",
					CastingTime = "10 minuti",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore trasforma delle materie prime in manufatti dello stesso materiale. Per esempio, può fabbricare un ponte di legno da un gruppo di alberi, una corda da un campo di canapa e degli abiti dal lino o dalla lana.\n\nL'incantatore sceglie delle materie prime entro gittata che sia in grado di vedere. Può fabbricare un oggetto di taglia Grande o inferiore (contenuto in un cubo con spigolo di 3 metri, o in otto cubi con spigolo di 1,5 metri collegati tra loro), purché disponga di una quantità sufficiente di materia prima. Se però lavora il metallo, la pietra o un'altra sostanza minerale, l'oggetto fabbricato non può essere più grande di taglia Media (contenuto in un singolo cubo con spigolo di 1,5 metri). La qualità degli oggetti creati dall'incantesimo è commisurata alla qualità delle materie prime.\n\nQuesto incantesimo non può creare né trasmutare creature o oggetti magici. Non può nemmeno essere usato per creare oggetti che normalmente richiedono un alto grado di maestria artigianale, come gioielli, armi, vetro o armature, a meno che l'incantatore non abbia competenza nel tipo di strumenti da artigiano usati per realizzarli.",
					HigherLevels = null
				}
			}
		};
	}
}
