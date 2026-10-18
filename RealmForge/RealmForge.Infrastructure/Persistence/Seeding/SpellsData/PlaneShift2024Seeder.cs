using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Plane Shift (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlaneShift2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plane-shift");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plane-shift", "en"),
					Language = LanguageCode.En,
					Name = "Plane Shift",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a forked, metal rod worth 250+ GP and attuned to a plane of existence",
					Description = "You and up to eight willing creatures who link hands in a circle are transported to a different plane of existence. You can specify a target destination in general terms, such as a specific city on the Elemental Plane of Fire or palace on the second level of the Nine Hells, and you appear in or near that destination, as determined by the GM.\n\nAlternatively, if you know the sigil sequence of a teleportation circle on another plane of existence, this spell can take you to that circle. If the teleportation circle is too small to hold all the creatures you transported, they appear in the closest unoccupied spaces next to the circle.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "plane-shift", "it"),
					Language = LanguageCode.It,
					Name = "Spostamento Planare",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "una verga di metallo biforcuta del valore di almeno 250 mo, sintonizzata con un piano di esistenza",
					Description = "L'incantatore e fino a otto creature consenzienti che si tengono per mano formando un cerchio vengono trasportati su un diverso piano di esistenza. L'incantatore può specificare una destinazione in termini generici, come una città specifica sul Piano Elementale del Fuoco o un palazzo sul secondo strato dei Nove Inferi, e compare all'interno o nei pressi di quella destinazione, come stabilito dal DM.\n\nIn alternativa, se conosce la sequenza di sigilli di un cerchio di teletrasporto su un altro piano di esistenza, questo incantesimo può portarlo a quel cerchio. Se il cerchio di teletrasporto è troppo piccolo per contenere tutte le creature trasportate, queste compaiono negli spazi liberi più vicini accanto al cerchio.",
					HigherLevels = null
				}
			}
		};
	}
}
