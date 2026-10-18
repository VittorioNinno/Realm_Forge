using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Slow (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Slow2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "slow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Transmutation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "slow", "en"),
					Language = LanguageCode.En,
					Name = "Slow",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a drop of molasses",
					Description = "You alter time around up to six creatures of your choice in a 40-foot Cube within range. Each target must succeed on a Wisdom saving throw or be affected by this spell for the duration.\n\nAn affected target's Speed is halved, it takes a −2 penalty to AC and Dexterity saving throws, and it can't take Reactions. On its turns, it can take either an action or a Bonus Action, not both, and it can make only one attack if it takes the Attack action. If it casts a spell with a Somatic component, there is a 25 percent chance the spell fails as a result of the target making the spell's gestures too slowly.\n\nAn affected target repeats the save at the end of each of its turns, ending the spell on itself on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "slow", "it"),
					Language = LanguageCode.It,
					Name = "Lentezza",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una goccia di melassa",
					Description = "L'incantatore altera il tempo attorno a un massimo di sei creature a sua scelta in un cubo con spigolo di 12 metri entro gittata. Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è influenzato da questo incantesimo per la durata.\n\nLa velocità di un bersaglio influenzato è dimezzata, il bersaglio subisce una penalità di −2 alla CA e ai tiri salvezza su Destrezza e non può effettuare reazioni. Nei suoi turni, può effettuare un'azione o un'azione bonus, non entrambe, e può effettuare un solo attacco se effettua l'azione di Attacco. Se lancia un incantesimo con una componente somatica, c'è una probabilità del 25 per cento che l'incantesimo fallisca perché il bersaglio compie i gesti dell'incantesimo troppo lentamente.\n\nUn bersaglio influenzato ripete il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = null
				}
			}
		};
	}
}
