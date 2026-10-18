using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blade Barrier (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BladeBarrier2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-barrier");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-barrier", "en"),
					Language = LanguageCode.En,
					Name = "Blade Barrier",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You create a wall of whirling blades made of magical energy. The wall appears within range and lasts for the duration. You make a straight wall up to 100 feet long, 20 feet high, and 5 feet thick, or a ringed wall up to 60 feet in diameter, 20 feet high, and 5 feet thick. The wall provides Three-Quarters Cover, and its space is Difficult Terrain.\n\nAny creature in the wall's space makes a Dexterity saving throw, taking 6d10 Force damage on a failed save or half as much damage on a successful one. A creature also makes that save if it enters the wall's space or ends it turn there. A creature makes that save only once per turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-barrier", "it"),
					Language = LanguageCode.It,
					Name = "Barriera di Lame",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore crea un muro di lame vorticanti fatte di energia magica. Il muro compare entro gittata e permane per la durata. L'incantatore crea un muro dritto lungo fino a 30 metri, alto 6 metri e spesso 1,5 metri, oppure un muro circolare con un diametro fino a 18 metri, alto 6 metri e spesso 1,5 metri. Il muro fornisce copertura dei tre quarti e il suo spazio è terreno difficile.\n\nOgni creatura nello spazio del muro effettua un tiro salvezza su Destrezza, subendo 6d10 danni da forza se lo fallisce, o la metà di quei danni se lo supera. Una creatura effettua questo tiro salvezza anche se entra nello spazio del muro o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = null
				}
			}
		};
	}
}
