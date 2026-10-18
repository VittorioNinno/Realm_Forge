using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Enthrall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Enthrall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enthrall");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enthrall", "en"),
					Language = LanguageCode.En,
					Name = "Enthrall",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "You weave a distracting string of words, causing creatures of your choice that you can see within range and that can hear you to make a Wisdom saving throw. Any creature that can't be charmed succeeds on this saving throw automatically, and if you or your companions are fighting a creature, it has advantage on the save. On a failed save, the target has disadvantage on Wisdom (Perception) checks made to perceive any creature other than you until the spell ends or until the target can no longer hear you. The spell ends if you are incapacitated or can no longer speak.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enthrall", "it"),
					Language = LanguageCode.It,
					Name = "Estasiare",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore intreccia una sequenza di parole che distrae le creature a sua scelta entro gittata, che egli sia in grado di vedere e che possano sentirlo, costringendole a effettuare un tiro salvezza su Saggezza. Qualsiasi creatura che non può essere affascinata supera automaticamente questo tiro salvezza; se l'incantatore o i suoi compagni stanno combattendo una creatura, questa dispone di vantaggio al tiro salvezza. Se fallisce il tiro salvezza, il bersaglio subisce svantaggio alle prove di Saggezza (Percezione) effettuate per percepire qualsiasi creatura diversa dall'incantatore, finché l'incantesimo non termina o finché non può più sentire l'incantatore. L'incantesimo termina se l'incantatore è incapacitato o non è più in grado di parlare.",
					HigherLevels = null
				}
			}
		};
	}
}
