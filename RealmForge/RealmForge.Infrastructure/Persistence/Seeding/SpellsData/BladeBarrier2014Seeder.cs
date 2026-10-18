using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blade Barrier (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BladeBarrier2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-barrier");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-barrier", "en"),
					Language = LanguageCode.En,
					Name = "Blade Barrier",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You create a vertical wall of whirling, razor-sharp blades made of magical energy. The wall appears within range and lasts for the duration. You can make a straight wall up to 100 feet long, 20 feet high, and 5 feet thick, or a ringed wall up to 60 feet in diameter, 20 feet high, and 5 feet thick. The wall provides three-quarters cover to creatures behind it, and its space is difficult terrain.\n\nWhen a creature enters the wall's area for the first time on a turn or starts its turn there, the creature must make a Dexterity saving throw. On a failed save, the creature takes 6d10 slashing damage. On a successful save, the creature takes half as much damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-barrier", "it"),
					Language = LanguageCode.It,
					Name = "Barriera di Lame",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore crea un muro verticale di lame turbinanti e affilate come rasoi, fatte di energia magica. Il muro compare entro gittata e dura per la durata dell'incantesimo. L'incantatore può creare un muro dritto lungo fino a 30 metri, alto 6 metri e spesso 1,5 metri, oppure un muro circolare del diametro massimo di 18 metri, alto 6 metri e spesso 1,5 metri. Il muro fornisce copertura dei tre quarti alle creature dietro di esso e il suo spazio è terreno difficile.\n\nQuando una creatura entra nell'area del muro per la prima volta in un turno o vi inizia il proprio turno, deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, subisce 6d10 danni taglienti. Se lo supera, subisce la metà di quei danni.",
					HigherLevels = null
				}
			}
		};
	}
}
