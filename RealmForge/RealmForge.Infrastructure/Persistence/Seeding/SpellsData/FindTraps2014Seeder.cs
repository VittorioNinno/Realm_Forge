using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Traps (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindTraps2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-traps");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-traps", "en"),
					Language = LanguageCode.En,
					Name = "Find Traps",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You sense the presence of any trap within range that is within line of sight. A trap, for the purpose of this spell, includes anything that would inflict a sudden or unexpected effect you consider harmful or undesirable, which was specifically intended as such by its creator. Thus, the spell would sense an area affected by the alarm spell, a glyph of warding, or a mechanical pit trap, but it would not reveal a natural weakness in the floor, an unstable ceiling, or a hidden sinkhole.\n\nThis spell merely reveals that a trap is present. You don't learn the location of each trap, but you do learn the general nature of the danger posed by a trap you sense.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-traps", "it"),
					Language = LanguageCode.It,
					Name = "Scopri Trappole",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore percepisce la presenza di qualsiasi trappola entro gittata che si trovi entro la sua linea di vista. Ai fini di questo incantesimo, una trappola comprende qualsiasi cosa che produrrebbe un effetto improvviso o inaspettato che l'incantatore considera dannoso o indesiderato, e che sia stato concepito espressamente come tale dal suo creatore. L'incantesimo percepirebbe quindi un'area influenzata dall'incantesimo allarme, un glifo di interdizione o una trappola meccanica a fossa, ma non rivelerebbe una debolezza naturale del pavimento, un soffitto instabile o una dolina nascosta.\n\nQuesto incantesimo si limita a rivelare la presenza di una trappola. L'incantatore non apprende la posizione di ogni trappola, ma apprende la natura generale del pericolo rappresentato da una trappola che percepisce.",
					HigherLevels = null
				}
			}
		};
	}
}
