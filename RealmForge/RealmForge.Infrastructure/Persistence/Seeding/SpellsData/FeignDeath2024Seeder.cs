using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Feign Death (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class FeignDeath2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feign-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feign-death", "en"),
					Language = LanguageCode.En,
					Name = "Feign Death",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pinch of soil from a grave",
					Description = "A willing creature you touch sinks into a trance so deep that it passes for a corpse. Until the spell ends, nothing short of the spell ending reveals the truth: ordinary inspection and spells that check whether a creature is alive both find it dead.\n\nWhile entranced, the creature:\n\n- has the Blinded and Incapacitated conditions, and a Speed of 0;\n- has Resistance to every damage type except Psychic;\n- has Immunity to the Poisoned condition.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feign-death", "it"),
					Language = LanguageCode.It,
					Name = "Morte Apparente",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di terra prelevata da una tomba",
					Description = "Una creatura consenziente toccata dall'incantatore sprofonda in una trance così profonda da sembrare un cadavere. Finché l'incantesimo non termina, nulla rivela la verità: sia un normale esame sia gli incantesimi che verificano se una creatura è viva la trovano morta.\n\nMentre è in trance, la creatura:\n\n- è accecata e incapacitata, e la sua velocità è 0;\n- ha resistenza a tutti i tipi di danni tranne quelli psichici;\n- ha immunità alla condizione avvelenato.",
					HigherLevels = null
				}
			}
		};
	}
}
