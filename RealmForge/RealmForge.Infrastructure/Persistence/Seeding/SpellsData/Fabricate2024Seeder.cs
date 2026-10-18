using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fabricate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fabricate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fabricate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fabricate", "en"),
					Language = LanguageCode.En,
					Name = "Fabricate",
					CastingTime = "10 minutes",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You convert raw materials into products of the same material. For example, you can fabricate a wooden bridge from a clump of trees, a rope from a patch of hemp, or clothes from flax or wool.\n\nChoose raw materials that you can see within range. You can fabricate a Large or smaller object (contained within a 10-foot Cube or eight connected 5-foot Cubes) given a sufficient quantity of material. If you're working with metal, stone, or another mineral substance, however, the fabricated object can be no larger than Medium (contained within a 5-foot Cube). The quality of any fabricated objects is based on the quality of the raw materials.\n\nCreatures and magic items can't be created by this spell. You also can't use it to create items that require a high degree of skill—such as weapons and armor—unless you have proficiency with the type of Artisan's Tools used to craft such objects.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fabricate", "it"),
					Language = LanguageCode.It,
					Name = "Fabbricare",
					CastingTime = "10 minuti",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore trasforma materie prime in prodotti fatti dello stesso materiale. Per esempio, può fabbricare un ponte di legno da un gruppo di alberi, una corda da un mucchio di canapa o abiti dal lino o dalla lana.\n\nL'incantatore sceglie materie prime entro gittata che è in grado di vedere. Può fabbricare un oggetto di taglia Grande o inferiore (contenuto in un cubo con spigolo di 3 metri o in otto cubi collegati con spigolo di 1,5 metri), purché disponga di una quantità sufficiente di materiale. Se lavora con metallo, pietra o un'altra sostanza minerale, tuttavia, l'oggetto fabbricato non può essere più grande di Medio (contenuto in un cubo con spigolo di 1,5 metri). La qualità degli oggetti fabbricati dipende dalla qualità delle materie prime.\n\nQuesto incantesimo non può creare creature od oggetti magici. Non può nemmeno essere usato per creare oggetti che richiedono un elevato grado di abilità, come armi e armature, a meno che l'incantatore non abbia competenza con il tipo di strumenti da artigiano usati per fabbricare tali oggetti.",
					HigherLevels = null
				}
			}
		};
	}
}
