using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Instant Summons (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InstantSummons2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "instant-summons");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "instant-summons", "en"),
					Language = LanguageCode.En,
					Name = "Instant Summons",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "a sapphire worth 1,000 gp",
					Description = "You touch an object weighing 10 pounds or less whose longest dimension is 6 feet or less. The spell leaves an invisible mark on its surface and invisibly inscribes the name of the item on the sapphire you use as the material component. Each time you cast this spell, you must use a different sapphire.\n\nAt any time thereafter, you can use your action to speak the item's name and crush the sapphire. The item instantly appears in your hand regardless of physical or planar distances, and the spell ends.\n\nIf another creature is holding or carrying the item, crushing the sapphire doesn't transport the item to you, but instead you learn who the creature possessing the object is and roughly where that creature is located at that moment.\n\nDispel magic or a similar effect successfully applied to the sapphire ends this spell's effect.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "instant-summons", "it"),
					Language = LanguageCode.It,
					Name = "Evocazioni Istantanee",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "uno zaffiro del valore di 1.000 mo",
					Description = "L'incantatore tocca un oggetto che pesa 5 kg o meno e la cui dimensione maggiore è di 1,8 metri o meno. L'incantesimo lascia un segno invisibile sulla superficie dell'oggetto e incide in modo invisibile il nome dell'oggetto sullo zaffiro usato come componente materiale. Ogni volta che lancia questo incantesimo, l'incantatore deve usare uno zaffiro diverso.\n\nIn qualsiasi momento successivo, l'incantatore può usare la sua azione per pronunciare il nome dell'oggetto e frantumare lo zaffiro. L'oggetto compare istantaneamente nella sua mano indipendentemente dalle distanze fisiche o planari, e l'incantesimo termina.\n\nSe un'altra creatura impugna o trasporta l'oggetto, frantumare lo zaffiro non trasporta l'oggetto all'incantatore, ma gli rivela invece chi è la creatura che possiede l'oggetto e dove si trova approssimativamente in quel momento.\n\nDissolvi magie o un effetto simile applicato con successo allo zaffiro pone fine all'effetto di questo incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
