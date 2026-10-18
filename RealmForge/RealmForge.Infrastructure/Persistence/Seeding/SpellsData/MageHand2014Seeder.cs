using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mage Hand (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MageHand2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-hand");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-hand", "en"),
					Language = LanguageCode.En,
					Name = "Mage Hand",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration or until you dismiss it as an action. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\n\nYou can use your action to control the hand. You can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial. You can move the hand up to 30 feet each time you use it.\n\nThe hand can't attack, activate magic items, or carry more than 10 pounds.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mage-hand", "it"),
					Language = LanguageCode.It,
					Name = "Mano Magica",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Una mano spettrale e fluttuante compare in un punto entro gittata scelto dall'incantatore. La mano dura per la durata o finché l'incantatore non la congeda come azione. La mano svanisce se in qualsiasi momento si trova a più di 9 metri dall'incantatore o se l'incantatore lancia di nuovo questo incantesimo.\n\nL'incantatore può usare la sua azione per controllare la mano. Può usare la mano per manipolare un oggetto, aprire una porta o un contenitore non chiusi a chiave, riporre un oggetto in un contenitore aperto o estrarlo da esso, oppure versare il contenuto di una fiala. Ogni volta che usa la mano, può spostarla di un massimo di 9 metri.\n\nLa mano non può attaccare, attivare oggetti magici o trasportare più di 5 kg.",
					HigherLevels = null
				}
			}
		};
	}
}
