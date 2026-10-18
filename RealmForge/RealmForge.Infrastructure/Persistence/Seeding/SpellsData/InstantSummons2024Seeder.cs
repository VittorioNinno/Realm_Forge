using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Instant Summons (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InstantSummons2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "instant-summons");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "instant-summons", "en"),
					Language = LanguageCode.En,
					Name = "Instant Summons",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "a sapphire worth 1,000+ GP",
					Description = "You touch the sapphire used in the casting and an object weighing 10 pounds or less whose longest dimension is 6 feet or less. The spell leaves an Invisible mark on that object and invisibly inscribes the object's name on the sapphire. Each time you cast this spell, you must use a different sapphire.\n\nThereafter, you can take a Magic action to speak the object's name and crush the sapphire. The object instantly appears in your hand regardless of physical or planar distances, and the spell ends.\n\nIf another creature is holding or carrying the object, crushing the sapphire doesn't transport it, but instead you learn who that creature is and where that creature is currently located.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "instant-summons", "it"),
					Language = LanguageCode.It,
					Name = "Evocazioni Istantanee",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "uno zaffiro del valore di almeno 1.000 mo",
					Description = "L'incantatore tocca lo zaffiro usato per il lancio e un oggetto che pesa 5 kg o meno e la cui dimensione maggiore è di 1,8 metri o meno. L'incantesimo lascia un marchio invisibile su quell'oggetto e incide in modo invisibile il nome dell'oggetto sullo zaffiro. Ogni volta che lancia questo incantesimo, l'incantatore deve usare uno zaffiro diverso.\n\nIn seguito, l'incantatore può effettuare un'azione di Magia per pronunciare il nome dell'oggetto e frantumare lo zaffiro. L'oggetto compare istantaneamente nella sua mano, indipendentemente dalle distanze fisiche o planari, e l'incantesimo termina.\n\nSe un'altra creatura impugna o trasporta l'oggetto, frantumare lo zaffiro non lo trasporta, ma l'incantatore scopre invece chi è quella creatura e dove si trova in quel momento.",
					HigherLevels = null
				}
			}
		};
	}
}
