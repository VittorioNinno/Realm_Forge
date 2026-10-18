using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Maze (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Maze2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "maze");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "maze", "en"),
					Language = LanguageCode.En,
					Name = "Maze",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You banish a creature that you can see within range into a labyrinthine demiplane. The target remains there for the duration or until it escapes the maze.\n\nThe target can use its action to attempt to escape. When it does so, it makes a DC 20 Intelligence check. If it succeeds, it escapes, and the spell ends (a minotaur or goristro demon automatically succeeds).\n\nWhen the spell ends, the target reappears in the space it left or, if that space is occupied, in the nearest unoccupied space.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "maze", "it"),
					Language = LanguageCode.It,
					Name = "Labirinto",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore esilia una creatura entro gittata, che egli sia in grado di vedere, in un semipiano labirintico. Il bersaglio vi rimane per la durata o finché non riesce a uscire dal labirinto.\n\nIl bersaglio può usare la sua azione per tentare di fuggire. Quando lo fa, effettua una prova di Intelligenza con CD 20. Se la supera, fugge e l'incantesimo termina (un minotauro o un demone goristro la supera automaticamente).\n\nQuando l'incantesimo termina, il bersaglio ricompare nello spazio che aveva lasciato o, se quello spazio è occupato, nello spazio libero più vicino.",
					HigherLevels = null
				}
			}
		};
	}
}
