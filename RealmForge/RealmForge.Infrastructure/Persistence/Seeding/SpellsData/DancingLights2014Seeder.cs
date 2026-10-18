using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dancing Lights (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DancingLights2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dancing-lights");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dancing-lights", "en"),
					Language = LanguageCode.En,
					Name = "Dancing Lights",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a bit of phosphorus or wychwood, or a glowworm",
					Description = "You create up to four torch-sized lights within range, making them appear as torches, lanterns, or glowing orbs that hover in the air for the duration. You can also combine the four lights into one glowing vaguely humanoid form of Medium size. Whichever form you choose, each light sheds dim light in a 10-foot radius.\n\nAs a bonus action on your turn, you can move the lights up to 60 feet to a new spot within range. A light must be within 20 feet of another light created by this spell, and a light winks out if it exceeds the spell's range.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dancing-lights", "it"),
					Language = LanguageCode.It,
					Name = "Luci Danzanti",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzetto di fosforo o di legno di strega, oppure una lucciola",
					Description = "L'incantatore crea entro gittata fino a quattro luci grandi quanto una torcia, facendole apparire come torce, lanterne o globi luminosi che fluttuano a mezz'aria per la durata. Può anche unire le quattro luci in un'unica forma luminosa vagamente umanoide di taglia Media. Qualunque forma scelga, ogni luce emette luce fioca in un raggio di 3 metri.\n\nCome azione bonus nel suo turno, l'incantatore può spostare le luci di un massimo di 18 metri fino a un nuovo punto entro gittata. Ogni luce deve trovarsi entro 6 metri da un'altra luce creata da questo incantesimo, e una luce si spegne se supera la gittata dell'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
