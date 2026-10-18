using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Maze (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Maze2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "maze");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "maze", "en"),
					Language = LanguageCode.En,
					Name = "Maze",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You banish a creature that you can see within range into a labyrinthine demiplane. The target remains there for the duration or until it escapes the maze.\n\nThe target can take a Study action to try to escape. When it does so, it makes a DC 20 Intelligence (Investigation) check. If it succeeds, it escapes, and the spell ends.\n\nWhen the spell ends, the target reappears in the space it left or, if that space is occupied, in the nearest unoccupied space.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "maze", "it"),
					Language = LanguageCode.It,
					Name = "Labirinto",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore esilia una creatura entro gittata che è in grado di vedere in un semipiano labirintico. Il bersaglio vi rimane per la durata o finché non riesce a fuggire dal labirinto.\n\nIl bersaglio può effettuare l'azione di Studio per tentare di fuggire. Quando lo fa, effettua una prova di Intelligenza (Indagare) con CD 20. Se la supera, fugge e l'incantesimo termina.\n\nQuando l'incantesimo termina, il bersaglio ricompare nello spazio che aveva lasciato o, se quello spazio è occupato, nello spazio libero più vicino.",
					HigherLevels = null
				}
			}
		};
	}
}
