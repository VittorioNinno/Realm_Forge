using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Feign Death (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class FeignDeath2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feign-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feign-death", "en"),
					Language = LanguageCode.En,
					Name = "Feign Death",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a pinch of graveyard dirt",
					Description = "You touch a willing creature and plunge it into a deathlike trance that no one can tell apart from real death.\n\nFor the duration, or until you use an action to touch the target and end the spell, the target looks dead to any outward examination and to spells that reveal whether it is alive. While in the trance, the target is blinded and incapacitated, its speed is 0, and it has resistance to all damage except psychic damage. Any disease or poison that affects the target when you cast the spell, or that it contracts during the trance, has no effect until the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feign-death", "it"),
					Language = LanguageCode.It,
					Name = "Morte Apparente",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di terra di cimitero",
					Description = "L'incantatore tocca una creatura consenziente e la fa sprofondare in una trance simile alla morte, impossibile da distinguere da un vero decesso.\n\nPer la durata, o finché l'incantatore non usa un'azione per toccare il bersaglio e porre fine all'incantesimo, il bersaglio appare morto a qualsiasi esame esterno e agli incantesimi che rivelano se è vivo. Durante la trance, il bersaglio è accecato e incapacitato, la sua velocità è 0 e ha resistenza a tutti i danni tranne quelli psichici. Qualsiasi malattia o veleno che affligge il bersaglio quando l'incantatore lancia l'incantesimo, o che contrae durante la trance, non ha effetto finché l'incantesimo non termina.",
					HigherLevels = null
				}
			}
		};
	}
}
