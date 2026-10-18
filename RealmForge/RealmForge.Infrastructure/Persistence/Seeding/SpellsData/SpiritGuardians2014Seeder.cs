using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spirit Guardians (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpiritGuardians2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spirit-guardians");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spirit-guardians", "en"),
					Language = LanguageCode.En,
					Name = "Spirit Guardians",
					CastingTime = "1 action",
					Range = "Self (15-foot radius)",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a holy symbol",
					Description = "You call forth spirits to protect you. They flit around you to a distance of 15 feet for the duration. If you are good or neutral, their spectral form appears angelic or fey (your choice). If you are evil, they appear fiendish.\n\nWhen you cast this spell, you can designate any number of creatures you can see to be unaffected by it. An affected creature's speed is halved in the area, and when the creature enters the area for the first time on a turn or starts its turn there, it must make a Wisdom saving throw. On a failed save, the creature takes 3d8 radiant damage (if you are good or neutral) or 3d8 necrotic damage (if you are evil). On a successful save, the creature takes half as much damage.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d8 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spirit-guardians", "it"),
					Language = LanguageCode.It,
					Name = "Guardiani Spirituali",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 4,5 metri)",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un simbolo sacro",
					Description = "L'incantatore richiama degli spiriti che lo proteggano. Per la durata, gli spiriti svolazzano attorno a lui fino a una distanza di 4,5 metri. Se l'incantatore è buono o neutrale, la loro forma spettrale appare angelica o fatata (a sua scelta). Se è malvagio, appaiono demoniaci.\n\nQuando lancia questo incantesimo, l'incantatore può designare un qualsiasi numero di creature che sia in grado di vedere affinché non siano influenzate. La velocità di una creatura influenzata si dimezza nell'area e, quando la creatura entra nell'area per la prima volta in un turno o vi inizia il proprio turno, deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura subisce 3d8 danni radiosi (se l'incantatore è buono o neutrale) o 3d8 danni necrotici (se l'incantatore è malvagio). Se lo supera, la creatura subisce la metà di quei danni.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
