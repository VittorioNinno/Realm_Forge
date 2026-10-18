using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Calm Emotions (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CalmEmotions2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "calm-emotions");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "calm-emotions", "en"),
					Language = LanguageCode.En,
					Name = "Calm Emotions",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You attempt to suppress strong emotions in a group of people. Each humanoid in a 20-foot-radius sphere centered on a point you choose within range must make a Charisma saving throw; a creature can choose to fail this saving throw if it wishes. If a creature fails its saving throw, choose one of the following two effects. You can suppress any effect causing a target to be charmed or frightened. When this spell ends, any suppressed effect resumes, provided that its duration has not expired in the meantime.\n\nAlternatively, you can make a target indifferent about creatures of your choice that it is hostile toward. This indifference ends if the target is attacked or harmed by a spell or if it witnesses any of its friends being harmed. When the spell ends, the creature becomes hostile again, unless the GM rules otherwise.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "calm-emotions", "it"),
					Language = LanguageCode.It,
					Name = "Calmare Emozioni",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tenta di sopprimere le emozioni forti in un gruppo di persone. Ogni umanoide in una sfera del raggio di 6 metri centrata su un punto entro gittata scelto dall'incantatore deve effettuare un tiro salvezza su Carisma; una creatura può scegliere di fallire questo tiro salvezza, se lo desidera. Se una creatura fallisce il tiro salvezza, l'incantatore sceglie uno dei due effetti seguenti. Può sopprimere qualsiasi effetto che renda il bersaglio affascinato o spaventato. Quando questo incantesimo termina, ogni effetto soppresso riprende, purché nel frattempo la sua durata non sia scaduta.\n\nIn alternativa, l'incantatore può rendere un bersaglio indifferente nei confronti di creature a sua scelta verso cui il bersaglio è ostile. Questa indifferenza termina se il bersaglio viene attaccato o danneggiato da un incantesimo, o se assiste al ferimento di uno dei suoi amici. Quando l'incantesimo termina, la creatura torna a essere ostile, a meno che il DM non stabilisca altrimenti.",
					HigherLevels = null
				}
			}
		};
	}
}
