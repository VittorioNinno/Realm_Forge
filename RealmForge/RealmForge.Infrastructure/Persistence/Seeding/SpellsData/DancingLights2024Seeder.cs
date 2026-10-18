using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dancing Lights (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DancingLights2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dancing-lights");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dancing-lights", "en"),
					Language = LanguageCode.En,
					Name = "Dancing Lights",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a bit of phosphorus",
					Description = "You create up to four torch-size lights within range, making them appear as torches, lanterns, or glowing orbs that hover for the duration. Alternatively, you combine the four lights into one glowing Medium form that is vaguely humanlike. Whichever form you choose, each light sheds Dim Light in a 10-foot radius.\n\nAs a Bonus Action, you can move the lights up to 60 feet to a space within range. A light must be within 20 feet of another light created by this spell, and a light vanishes if it exceeds the spell's range.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dancing-lights", "it"),
					Language = LanguageCode.It,
					Name = "Luci Danzanti",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzetto di fosforo",
					Description = "L'incantatore crea entro gittata fino a quattro luci delle dimensioni di una torcia, facendole apparire come torce, lanterne o globi luminosi che fluttuano per la durata. In alternativa, combina le quattro luci in un'unica forma luminosa di taglia Media dalle vaghe sembianze umanoidi. Qualunque sia la forma scelta, ogni luce proietta luce fioca in un raggio di 3 metri.\n\nCome azione bonus, l'incantatore può spostare le luci fino a 18 metri in uno spazio entro gittata. Ogni luce deve trovarsi entro 6 metri da un'altra luce creata da questo incantesimo, e una luce svanisce se esce dalla gittata dell'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
