using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chill Touch (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ChillTouch2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chill-touch");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chill-touch", "en"),
					Language = LanguageCode.En,
					Name = "Chill Touch",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Channeling the chill of the grave, make a melee spell attack against a target within reach. On a hit, the target takes 1d10 Necrotic damage, and it can't regain Hit Points until the end of your next turn.",
					HigherLevels = "The damage increases by 1d10 when you reach levels 5 (2d10), 11 (3d10), and 17 (4d10)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chill-touch", "it"),
					Language = LanguageCode.It,
					Name = "Tocco Gelido",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Incanalando il gelo della tomba, l'incantatore effettua un attacco con incantesimo in mischia contro un bersaglio entro portata. Se colpisce, il bersaglio subisce 1d10 danni necrotici e non può recuperare punti ferita fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = "I danni aumentano di 1d10 quando l'incantatore raggiunge il 5° livello (2d10), l'11° livello (3d10) e il 17° livello (4d10)."
				}
			}
		};
	}
}
