using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Plane Shift (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlaneShift2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plane-shift");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plane-shift", "en"),
					Language = LanguageCode.En,
					Name = "Plane Shift",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a forked, metal rod worth at least 250 gp, attuned to a particular plane of existence",
					Description = "You and up to eight willing creatures who link hands in a circle are transported to a different plane of existence. You can specify a target destination in general terms, such as the City of Brass on the Elemental Plane of Fire or the palace of Dispater on the second level of the Nine Hells, and you appear in or near that destination. If you are trying to reach the City of Brass, for example, you might arrive in its Street of Steel, before its Gate of Ashes, or looking at the city from across the Sea of Fire, at the GM's discretion.\n\nAlternatively, if you know the sigil sequence of a teleportation circle on another plane of existence, this spell can take you to that circle. If the teleportation circle is too small to hold all the creatures you transported, they appear in the closest unoccupied spaces next to the circle.\n\nYou can use this spell to banish an unwilling creature to another plane. Choose a creature within your reach and make a melee spell attack against it. On a hit, the creature must make a Charisma saving throw. If the creature fails this save, it is transported to a random location on the plane of existence you specify. A creature so transported must find its own way back to your current plane of existence.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "plane-shift", "it"),
					Language = LanguageCode.It,
					Name = "Spostamento Planare",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "una verga di metallo biforcuta del valore di almeno 250 mo, sintonizzata con un particolare piano di esistenza",
					Description = "L'incantatore e fino a otto creature consenzienti che si tengono per mano formando un cerchio vengono trasportati in un piano di esistenza diverso. L'incantatore può indicare una destinazione in termini generici, come la Città d'Ottone sul Piano Elementale del Fuoco o il palazzo di Dispater nel secondo livello dei Nove Inferi, e compare in quella destinazione o nelle sue vicinanze. Se cerca di raggiungere la Città d'Ottone, per esempio, potrebbe arrivare nella sua Via dell'Acciaio, davanti alla sua Porta delle Ceneri o mentre osserva la città dall'altra sponda del Mare di Fuoco, a discrezione del DM.\n\nIn alternativa, se l'incantatore conosce la sequenza di sigilli di un cerchio di teletrasporto su un altro piano di esistenza, questo incantesimo può portarlo a quel cerchio. Se il cerchio di teletrasporto è troppo piccolo per contenere tutte le creature trasportate, queste compaiono negli spazi liberi più vicini al cerchio.\n\nL'incantatore può usare questo incantesimo per esiliare una creatura non consenziente in un altro piano. Sceglie una creatura a portata ed effettua contro di essa un attacco con incantesimo in mischia. Se colpisce, la creatura deve effettuare un tiro salvezza su Carisma. Se lo fallisce, viene trasportata in un luogo casuale del piano di esistenza indicato dall'incantatore. Una creatura trasportata in questo modo deve trovare da sola la strada per tornare nel piano di esistenza attuale dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
