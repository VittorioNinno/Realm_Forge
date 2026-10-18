using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Water Walk (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WaterWalk2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-walk");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-walk", "en"),
					Language = LanguageCode.En,
					Name = "Water Walk",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "a piece of cork",
					Description = "This spell grants the ability to move across any liquid surface—such as water, acid, mud, snow, quicksand, or lava—as if it were harmless solid ground (creatures crossing molten lava can still take damage from the heat). Up to ten willing creatures of your choice within range gain this ability for the duration.\n\nAn affected target must take a Bonus Action to pass from the liquid's surface into the liquid itself and vice versa, but if the target falls into the liquid, the target passes through the surface into the liquid below.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-walk", "it"),
					Language = LanguageCode.It,
					Name = "Camminare sull'Acqua",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "un pezzo di sughero",
					Description = "Questo incantesimo conferisce la capacità di muoversi su qualsiasi superficie liquida (come acqua, acido, fango, neve, sabbie mobili o lava) come se fosse un terreno solido innocuo (le creature che attraversano la lava fusa possono comunque subire danni dal calore). Fino a dieci creature consenzienti a scelta dell'incantatore entro gittata ottengono questa capacità per la durata.\n\nUn bersaglio influenzato deve effettuare un'azione bonus per passare dalla superficie del liquido al liquido stesso e viceversa, ma se cade nel liquido, ne attraversa la superficie e finisce nel liquido sottostante.",
					HigherLevels = null
				}
			}
		};
	}
}
