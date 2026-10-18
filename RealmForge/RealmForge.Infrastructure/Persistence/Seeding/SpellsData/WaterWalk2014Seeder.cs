using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Water Walk (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WaterWalk2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-walk");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-walk", "en"),
					Language = LanguageCode.En,
					Name = "Water Walk",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "a piece of cork",
					Description = "This spell grants the ability to move across any liquid surface—such as water, acid, mud, snow, quicksand, or lava—as if it were harmless solid ground (creatures crossing molten lava can still take damage from the heat). Up to ten willing creatures you can see within range gain this ability for the duration.\n\nIf you target a creature submerged in a liquid, the spell carries the target to the surface of the liquid at a rate of 60 feet per round.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-walk", "it"),
					Language = LanguageCode.It,
					Name = "Camminare sull'Acqua",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "un pezzo di sughero",
					Description = "Questo incantesimo conferisce la capacità di muoversi su qualsiasi superficie liquida (come acqua, acido, fango, neve, sabbie mobili o lava) come se fosse un terreno solido innocuo (le creature che attraversano la lava fusa possono comunque subire danni a causa del calore). Fino a dieci creature consenzienti entro gittata, che l'incantatore sia in grado di vedere, ottengono questa capacità per la durata.\n\nSe l'incantatore bersaglia una creatura immersa in un liquido, l'incantesimo la porta in superficie a una velocità di 18 metri per round.",
					HigherLevels = null
				}
			}
		};
	}
}
