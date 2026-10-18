using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Slow (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Slow2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "slow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "slow", "en"),
					Language = LanguageCode.En,
					Name = "Slow",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a drop of molasses",
					Description = "You alter time around up to six creatures of your choice in a 40-foot cube within range. Each target must succeed on a Wisdom saving throw or be affected by this spell for the duration.\n\nAn affected target's speed is halved, it takes a -2 penalty to AC and Dexterity saving throws, and it can't use reactions. On its turn, it can use either an action or a bonus action, not both. Regardless of the creature's abilities or magic items, it can't make more than one melee or ranged attack during its turn.\n\nIf the creature attempts to cast a spell with a casting time of 1 action, roll a d20. On an 11 or higher, the spell doesn't take effect until the creature's next turn, and the creature must use its action on that turn to complete the spell. If it can't, the spell is wasted.\n\nA creature affected by this spell makes another Wisdom saving throw at the end of its turn. On a successful save, the effect ends for it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "slow", "it"),
					Language = LanguageCode.It,
					Name = "Lentezza",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una goccia di melassa",
					Description = "L'incantatore altera il tempo attorno a un massimo di sei creature a sua scelta in un cubo con spigolo di 12 metri entro gittata. Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è influenzato da questo incantesimo per la durata.\n\nLa velocità di un bersaglio influenzato si dimezza, il bersaglio subisce una penalità di -2 alla CA e ai tiri salvezza su Destrezza e non può usare reazioni. Nel suo turno può usare un'azione o un'azione bonus, ma non entrambe. Indipendentemente dalle capacità o dagli oggetti magici della creatura, durante il proprio turno non può effettuare più di un attacco in mischia o a distanza.\n\nSe la creatura tenta di lanciare un incantesimo con un tempo di lancio di 1 azione, si tira un d20. Con un risultato di 11 o superiore, l'incantesimo non ha effetto fino al turno successivo della creatura, e la creatura deve usare la sua azione in quel turno per completare l'incantesimo. Se non può farlo, l'incantesimo va sprecato.\n\nUna creatura influenzata da questo incantesimo effettua un altro tiro salvezza su Saggezza alla fine del suo turno. Se lo supera, l'effetto termina per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
