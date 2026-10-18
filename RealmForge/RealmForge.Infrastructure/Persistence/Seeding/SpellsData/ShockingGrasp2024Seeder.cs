using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shocking Grasp (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ShockingGrasp2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shocking-grasp");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shocking-grasp", "en"),
					Language = LanguageCode.En,
					Name = "Shocking Grasp",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Lightning springs from you to a creature that you try to touch. Make a melee spell attack against the target. On a hit, the target takes 1d8 Lightning damage, and it can't make Opportunity Attacks until the start of its next turn.",
					HigherLevels = "The damage increases by 1d8 when you reach levels 5 (2d8), 11 (3d8), and 17 (4d8)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shocking-grasp", "it"),
					Language = LanguageCode.It,
					Name = "Stretta Folgorante",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una scarica elettrica scaturisce dall'incantatore verso una creatura che tenta di toccare. L'incantatore effettua un attacco con incantesimo in mischia contro il bersaglio. Se colpisce, il bersaglio subisce 1d8 danni da fulmine e non può effettuare attacchi di opportunità fino all'inizio del suo turno successivo.",
					HigherLevels = "I danni aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8)."
				}
			}
		};
	}
}
