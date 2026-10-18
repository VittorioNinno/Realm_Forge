using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mind Spike (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MindSpike2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-spike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-spike", "en"),
					Language = LanguageCode.En,
					Name = "Mind Spike",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You drive a spike of psionic energy into the mind of one creature you can see within range. The target makes a Wisdom saving throw, taking 3d8 Psychic damage on a failed save or half as much damage on a successful one. On a failed save, you also always know the target's location until the spell ends, but only while the two of you are on the same plane of existence. While you have this knowledge, the target can't become hidden from you, and if it has the Invisible condition, it gains no benefit from that condition against you.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mind-spike", "it"),
					Language = LanguageCode.It,
					Name = "Aculeo Mentale",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore conficca un aculeo di energia psionica nella mente di una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Saggezza, subendo 3d8 danni psichici se lo fallisce, o la metà di quei danni se lo supera. Se lo fallisce, inoltre, l'incantatore conosce sempre la posizione del bersaglio finché l'incantesimo non termina, ma soltanto finché entrambi si trovano sullo stesso piano di esistenza. Finché possiede questa conoscenza, il bersaglio non può nascondersi da lui e, se è invisibile, non ottiene alcun beneficio da quella condizione contro di lui.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
