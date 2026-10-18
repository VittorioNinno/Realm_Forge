using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Traps (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindTraps2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-traps");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-traps", "en"),
					Language = LanguageCode.En,
					Name = "Find Traps",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You sense any trap within range that is within line of sight. A trap, for the purpose of this spell, includes any object or mechanism that was created to cause damage or other danger. Thus, the spell would sense the *Alarm* or *Glyph of Warding* spell or a mechanical pit trap, but it wouldn't reveal a natural weakness in the floor, an unstable ceiling, or a hidden sinkhole.\n\nThis spell reveals that a trap is present but not its location. You do learn the general nature of the danger posed by a trap you sense.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-traps", "it"),
					Language = LanguageCode.It,
					Name = "Scopri Trappole",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore percepisce qualsiasi trappola entro gittata che si trovi entro la sua linea di vista. Ai fini di questo incantesimo, una trappola comprende qualsiasi oggetto o meccanismo creato per infliggere danni o costituire un altro pericolo. L'incantesimo percepirebbe quindi l'incantesimo *allarme* o *glifo di interdizione* o una fossa meccanica, ma non rivelerebbe un punto debole naturale del pavimento, un soffitto instabile o una dolina nascosta.\n\nQuesto incantesimo rivela che è presente una trappola, ma non la sua posizione. L'incantatore apprende però la natura generale del pericolo rappresentato da una trappola che percepisce.",
					HigherLevels = null
				}
			}
		};
	}
}
