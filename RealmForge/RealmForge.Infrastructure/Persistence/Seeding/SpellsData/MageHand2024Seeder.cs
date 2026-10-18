using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mage Hand (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MageHand2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-hand");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-hand", "en"),
					Language = LanguageCode.En,
					Name = "Mage Hand",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\n\nWhen you cast the spell, you can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial.\n\nAs a Magic action on your later turns, you can control the hand thus again. As part of that action, you can move the hand up to 30 feet.\n\nThe hand can't attack, activate magic items, or carry more than 10 pounds.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mage-hand", "it"),
					Language = LanguageCode.It,
					Name = "Mano Magica",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Una mano spettrale e fluttuante compare in un punto entro gittata a scelta dell'incantatore. La mano permane per la durata. La mano svanisce se in qualsiasi momento si trova a più di 9 metri dall'incantatore o se l'incantatore lancia di nuovo questo incantesimo.\n\nQuando lancia l'incantesimo, l'incantatore può usare la mano per manipolare un oggetto, aprire una porta o un contenitore non chiusi a chiave, riporre un oggetto in un contenitore aperto o estrarlo da esso, oppure versare il contenuto di una fiala.\n\nCome azione di Magia nei turni successivi, l'incantatore può controllare di nuovo la mano in questo modo. Come parte di quell'azione, può spostare la mano fino a 9 metri.\n\nLa mano non può attaccare, attivare oggetti magici o trasportare più di 5 kg.",
					HigherLevels = null
				}
			}
		};
	}
}
