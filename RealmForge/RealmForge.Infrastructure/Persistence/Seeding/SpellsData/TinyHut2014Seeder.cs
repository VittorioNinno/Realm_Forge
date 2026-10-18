using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tiny Hut (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TinyHut2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tiny-hut");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tiny-hut", "en"),
					Language = LanguageCode.En,
					Name = "Tiny Hut",
					CastingTime = "1 minute",
					Range = "Self (10-foot-radius hemisphere)",
					Duration = "8 hours",
					MaterialComponent = "a small crystal bead",
					Description = "A 10-foot-radius immobile dome of force springs into existence around and above you and remains stationary for the duration. The spell ends if you leave its area.\n\nNine creatures of Medium size or smaller can fit inside the dome with you. The spell fails if its area includes a larger creature or more than nine creatures. Creatures and objects within the dome when you cast this spell can move through it freely. All other creatures and objects are barred from passing through it. Spells and other magical effects can't extend through the dome or be cast through it. The atmosphere inside the space is comfortable and dry, regardless of the weather outside.\n\nUntil the spell ends, you can command the interior to become dimly lit or dark. The dome is opaque from the outside, of any color you choose, but it is transparent from the inside.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tiny-hut", "it"),
					Language = LanguageCode.It,
					Name = "Piccolo Rifugio",
					CastingTime = "1 minuto",
					Range = "Incantatore (semisfera del raggio di 3 metri)",
					Duration = "8 ore",
					MaterialComponent = "una piccola perla di cristallo",
					Description = "Una cupola di forza immobile del raggio di 3 metri si materializza attorno e sopra l'incantatore e rimane ferma per la durata. L'incantesimo termina se l'incantatore esce dalla sua area.\n\nNove creature di taglia Media o inferiore possono entrare nella cupola insieme all'incantatore. L'incantesimo fallisce se la sua area comprende una creatura più grande o più di nove creature. Le creature e gli oggetti che si trovano all'interno della cupola quando l'incantatore lancia questo incantesimo possono attraversarla liberamente. A tutte le altre creature e a tutti gli altri oggetti è impedito di attraversarla. Gli incantesimi e gli altri effetti magici non possono estendersi attraverso la cupola né essere lanciati attraverso di essa. L'atmosfera all'interno dello spazio è confortevole e asciutta, indipendentemente dal clima all'esterno.\n\nFinché l'incantesimo non termina, l'incantatore può ordinare all'interno di diventare illuminato da luce fioca o buio. Dall'esterno la cupola è opaca, del colore scelto dall'incantatore, mentre dall'interno è trasparente.",
					HigherLevels = null
				}
			}
		};
	}
}
