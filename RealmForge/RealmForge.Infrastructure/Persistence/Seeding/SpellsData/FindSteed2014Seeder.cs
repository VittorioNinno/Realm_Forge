using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Steed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindSteed2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-steed");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-steed", "en"),
					Language = LanguageCode.En,
					Name = "Find Steed",
					CastingTime = "10 minutes",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You summon a spirit that assumes the form of an unusually intelligent, strong, and loyal steed, creating a long-lasting bond with it. Appearing in an unoccupied space within range, the steed takes on a form that you choose, such as a warhorse, a pony, a camel, an elk, or a mastiff. (Your GM might allow other animals to be summoned as steeds.) The steed has the statistics of the chosen form, though it is a celestial, fey, or fiend (your choice) instead of its normal type. Additionally, if your steed has an Intelligence of 5 or less, its Intelligence becomes 6, and it gains the ability to understand one language of your choice that you speak.\n\nYour steed serves you as a mount, both in combat and out, and you have an instinctive bond with it that allows you to fight as a seamless unit. While mounted on your steed, you can make any spell you cast that targets only you also target your steed.\n\nWhen the steed drops to 0 hit points, it disappears, leaving behind no physical form. You can also dismiss your steed at any time as an action, causing it to disappear. In either case, casting this spell again summons the same steed, restored to its hit point maximum.\n\nWhile your steed is within 1 mile of you, you can communicate with it telepathically.\n\nYou can't have more than one steed bonded by this spell at a time. As an action, you can release the steed from its bond at any time, causing it to disappear.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-steed", "it"),
					Language = LanguageCode.It,
					Name = "Trova Cavalcatura",
					CastingTime = "10 minuti",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore evoca uno spirito che assume la forma di una cavalcatura insolitamente intelligente, forte e leale, creando con essa un legame duraturo. La cavalcatura compare in uno spazio libero entro gittata e assume una forma scelta dall'incantatore, come un cavallo da guerra, un pony, un cammello, un alce o un mastino. (Il DM può permettere di evocare altri animali come cavalcature.) La cavalcatura possiede le statistiche della forma scelta, ma è un celestiale, un folletto o un immondo (a scelta dell'incantatore) anziché del suo tipo normale. Inoltre, se la cavalcatura ha Intelligenza pari o inferiore a 5, la sua Intelligenza diventa 6 e ottiene la capacità di comprendere un linguaggio a scelta tra quelli parlati dall'incantatore.\n\nLa cavalcatura serve l'incantatore come destriero, sia in combattimento sia al di fuori di esso, e l'incantatore ha con essa un legame istintivo che permette a entrambi di combattere come un'unica entità. Mentre è in sella alla cavalcatura, l'incantatore può far sì che qualsiasi incantesimo da lui lanciato che bersaglia soltanto lui bersagli anche la cavalcatura.\n\nQuando la cavalcatura scende a 0 punti ferita, scompare senza lasciare alcuna forma fisica. L'incantatore può anche congedare la cavalcatura in qualsiasi momento come azione, facendola scomparire. In entrambi i casi, lanciare di nuovo questo incantesimo evoca la stessa cavalcatura, con i punti ferita ripristinati al massimo.\n\nFinché la cavalcatura si trova entro 1,5 km dall'incantatore, quest'ultimo può comunicare telepaticamente con essa.\n\nL'incantatore non può avere più di una cavalcatura legata a sé da questo incantesimo alla volta. Come azione, può sciogliere in qualsiasi momento il legame con la cavalcatura, facendola scomparire.",
					HigherLevels = null
				}
			}
		};
	}
}
