using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tiny Hut (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TinyHut2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tiny-hut");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tiny-hut", "en"),
					Language = LanguageCode.En,
					Name = "Tiny Hut",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "8 hours",
					MaterialComponent = "a crystal bead",
					Description = "A 10-foot Emanation springs into existence around you and remains stationary for the duration. The spell fails when you cast it if the Emanation isn't big enough to fully encapsulate all creatures in its area.\n\nCreatures and objects within the Emanation when you cast the spell can move through it freely. All other creatures and objects are barred from passing through it. Spells of level 3 or lower can't be cast through it, and the effects of such spells can't extend into it.\n\nThe atmosphere inside the Emanation is comfortable and dry, regardless of the weather outside. Until the spell ends, you can command the interior to have Dim Light or Darkness (no action required). The Emanation is opaque from the outside and of any color you choose, but it's transparent from the inside.\n\nThe spell ends early if you leave the Emanation or if you cast it again.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tiny-hut", "it"),
					Language = LanguageCode.It,
					Name = "Piccolo Rifugio",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "8 ore",
					MaterialComponent = "una perlina di cristallo",
					Description = "Un'emanazione di 3 metri prende forma attorno all'incantatore e resta immobile per la durata. L'incantesimo fallisce al momento del lancio se l'emanazione non è abbastanza grande da racchiudere completamente tutte le creature nella sua area.\n\nLe creature e gli oggetti che si trovano all'interno dell'emanazione quando l'incantesimo viene lanciato possono attraversarla liberamente. A tutte le altre creature e oggetti è impedito di attraversarla. Non è possibile lanciare incantesimi di 3° livello o inferiore attraverso di essa, e gli effetti di tali incantesimi non possono estendersi al suo interno.\n\nL'atmosfera all'interno dell'emanazione è confortevole e asciutta, indipendentemente dal tempo atmosferico all'esterno. Finché l'incantesimo non termina, l'incantatore può fare in modo che all'interno ci sia luce fioca od oscurità (non è richiesta alcuna azione). L'emanazione è opaca dall'esterno e del colore che l'incantatore preferisce, ma è trasparente dall'interno.\n\nL'incantesimo termina prima del tempo se l'incantatore esce dall'emanazione o se lo lancia di nuovo.",
					HigherLevels = null
				}
			}
		};
	}
}
