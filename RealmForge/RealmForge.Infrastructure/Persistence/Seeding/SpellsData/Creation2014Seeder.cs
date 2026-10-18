using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Creation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Creation2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "creation");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "creation", "en"),
					Language = LanguageCode.En,
					Name = "Creation",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "Special",
					MaterialComponent = "a tiny piece of matter of the same type of the item you plan to create",
					Description = "You pull wisps of shadow material from the Shadowfell to create a nonliving object of vegetable matter within range: soft goods, rope, wood, or something similar. You can also use this spell to create mineral objects such as stone, crystal, or metal. The object created must be no larger than a 5-foot cube, and the object must be of a form and material that you have seen before.\n\nThe duration depends on the object's material. If the object is composed of multiple materials, use the shortest duration.\n\n| Material | Duration |\n|---|---|\n| Vegetable matter | 1 day |\n| Stone or crystal | 12 hours |\n| Precious metals | 1 hour |\n| Gems | 10 minutes |\n| Adamantine or mithral | 1 minute |\n\nUsing any material created by this spell as another spell's material component causes that spell to fail.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the cube increases by 5 feet for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "creation", "it"),
					Language = LanguageCode.It,
					Name = "Creazione",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "Speciale",
					MaterialComponent = "un minuscolo frammento di materia dello stesso tipo dell'oggetto che l'incantatore intende creare",
					Description = "L'incantatore attinge filamenti di materia d'ombra dalla Coltre Oscura per creare entro gittata un oggetto non vivente di materia vegetale: tessuti, corde, legno o qualcosa di simile. Può anche usare questo incantesimo per creare oggetti minerali come pietra, cristallo o metallo. L'oggetto creato non può essere più grande di un cubo con spigolo di 1,5 metri e deve avere una forma ed essere fatto di un materiale che l'incantatore ha già visto in precedenza.\n\nLa durata dipende dal materiale dell'oggetto. Se l'oggetto è composto da più materiali, si usa la durata più breve.\n\n| Materiale | Durata |\n|---|---|\n| Materia vegetale | 1 giorno |\n| Pietra o cristallo | 12 ore |\n| Metalli preziosi | 1 ora |\n| Gemme | 10 minuti |\n| Adamantio o mithral | 1 minuto |\n\nUsare un materiale creato da questo incantesimo come componente materiale di un altro incantesimo fa fallire quell'incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, lo spigolo del cubo aumenta di 1,5 metri per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
