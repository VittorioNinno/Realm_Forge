using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Phantasmal Killer (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PhantasmalKiller2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-killer");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-killer", "en"),
					Language = LanguageCode.En,
					Name = "Phantasmal Killer",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You tap into the nightmares of a creature you can see within range and create an illusion of its deepest fears, visible only to that creature. The target makes a Wisdom saving throw. On a failed save, the target takes 4d10 Psychic damage and has Disadvantage on ability checks and attack rolls for the duration. On a successful save, the target takes half as much damage, and the spell ends.\n\nFor the duration, the target makes a Wisdom saving throw at the end of each of its turns. On a failed save, it takes the Psychic damage again. On a successful save, the spell ends.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-killer", "it"),
					Language = LanguageCode.It,
					Name = "Allucinazione Mortale",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore attinge agli incubi di una creatura entro gittata che è in grado di vedere e crea un'illusione delle sue paure più profonde, visibile soltanto a quella creatura. Il bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, il bersaglio subisce 4d10 danni psichici e subisce svantaggio alle prove di caratteristica e ai tiri per colpire per la durata. Se lo supera, il bersaglio subisce la metà di quei danni e l'incantesimo termina.\n\nPer la durata, il bersaglio effettua un tiro salvezza su Saggezza alla fine di ogni suo turno. Se lo fallisce, subisce di nuovo i danni psichici. Se lo supera, l'incantesimo termina.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
