using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mending (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Mending2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mending");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mending", "en"),
					Language = LanguageCode.En,
					Name = "Mending",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "two lodestones",
					Description = "This spell repairs a single break or tear in an object you touch, such as a broken key, a torn cloak, or a leaking wineskin. As long as the break or tear is no longer than 1 foot in any dimension, you mend it, leaving no trace of the former damage.\n\nThis spell can physically repair a magic item or construct, but the spell can't restore magic to such an object.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mending", "it"),
					Language = LanguageCode.It,
					Name = "Riparare",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "due calamite",
					Description = "Questo incantesimo ripara una singola rottura o uno strappo in un oggetto toccato dall'incantatore, come una chiave rotta, un mantello strappato o un otre che perde. Purché la rottura o lo strappo non superi i 30 cm in ogni dimensione, l'incantatore lo ripara senza lasciare traccia del danno precedente.\n\nQuesto incantesimo può riparare fisicamente un oggetto magico o un costrutto, ma non può ripristinare la magia di un oggetto simile.",
					HigherLevels = null
				}
			}
		};
	}
}
