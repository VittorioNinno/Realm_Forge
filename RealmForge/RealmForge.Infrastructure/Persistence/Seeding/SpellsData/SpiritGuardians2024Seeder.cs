using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spirit Guardians (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpiritGuardians2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spirit-guardians");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spirit-guardians", "en"),
					Language = LanguageCode.En,
					Name = "Spirit Guardians",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a prayer scroll",
					Description = "Protective spirits flit around you in a 15-foot Emanation for the duration. If you are good or neutral, their spectral form appears angelic or fey (your choice). If you are evil, they appear fiendish.\n\nWhen you cast this spell, you can designate creatures to be unaffected by it. Any other creature's Speed is halved in the Emanation, and whenever the Emanation enters a creature's space and whenever a creature enters the Emanation or ends its turn there, the creature must make a Wisdom saving throw. On a failed save, the creature takes 3d8 Radiant damage (if you are good or neutral) or 3d8 Necrotic damage (if you are evil). On a successful save, the creature takes half as much damage. A creature makes this save only once per turn.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spirit-guardians", "it"),
					Language = LanguageCode.It,
					Name = "Guardiani Spirituali",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una pergamena con una preghiera",
					Description = "Per la durata, spiriti protettivi svolazzano attorno all'incantatore in un'emanazione di 4,5 metri. Se l'incantatore è buono o neutrale, la loro forma spettrale ha un aspetto angelico o fatato (a sua scelta). Se è malvagio, hanno un aspetto immondo.\n\nQuando lancia questo incantesimo, l'incantatore può designare delle creature che non ne sono influenzate. La velocità di qualsiasi altra creatura è dimezzata nell'emanazione e, ogni volta che l'emanazione entra nello spazio di una creatura e ogni volta che una creatura entra nell'emanazione o vi termina il proprio turno, la creatura deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura subisce 3d8 danni radiosi (se l'incantatore è buono o neutrale) o 3d8 danni necrotici (se è malvagio). Se lo supera, la creatura subisce la metà di quei danni. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
