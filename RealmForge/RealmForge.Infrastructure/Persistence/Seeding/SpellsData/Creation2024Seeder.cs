using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Creation (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Creation2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "creation");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Illusion,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "creation", "en"),
					Language = LanguageCode.En,
					Name = "Creation",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "Special",
					MaterialComponent = "a paintbrush",
					Description = "You pull wisps of shadow material from the Shadowfell to create an object within range. It is either an object of vegetable matter (soft goods, rope, wood, and the like) or mineral matter (stone, crystal, metal, and the like). The object must be no larger than a 5-foot Cube, and the object must be of a form and material that you have seen.\n\nThe spell's duration depends on the object's material, as shown in the Materials table. If the object is composed of multiple materials, use the shortest duration. Using any object created by this spell as another spell's Material component causes the other spell to fail.\n\n**Materials**\n\n| Material | Duration |\n|---|---|\n| Vegetable matter | 24 hours |\n| Stone or crystal | 12 hours |\n| Precious metals | 1 hour |\n| Gems | 10 minutes |\n| Adamantine or mithral | 1 minute |",
					HigherLevels = "The Cube increases by 5 feet for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "creation", "it"),
					Language = LanguageCode.It,
					Name = "Creazione",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "Speciale",
					MaterialComponent = "un pennello",
					Description = "L'incantatore attinge filamenti di materia d'ombra dalla Coltre Oscura per creare un oggetto entro gittata. Può trattarsi di un oggetto di materia vegetale (tessuti, corde, legno e simili) o di materia minerale (pietra, cristallo, metallo e simili). L'oggetto non deve essere più grande di un cubo con spigolo di 1,5 metri e deve avere una forma ed essere fatto di un materiale che l'incantatore ha già visto.\n\nLa durata dell'incantesimo dipende dal materiale dell'oggetto, come indicato nella tabella dei Materiali. Se l'oggetto è composto da più materiali, si usa la durata più breve. Usare un oggetto creato da questo incantesimo come componente materiale di un altro incantesimo fa fallire quell'altro incantesimo.\n\n**Materiali**\n\n| Materiale | Durata |\n|---|---|\n| Materia vegetale | 24 ore |\n| Pietra o cristallo | 12 ore |\n| Metalli preziosi | 1 ora |\n| Gemme | 10 minuti |\n| Adamantio o mithral | 1 minuto |",
					HigherLevels = "Lo spigolo del cubo aumenta di 1,5 metri per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
