using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Compelled Duel (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CompelledDuel2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compelled-duel");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compelled-duel", "en"),
					Language = LanguageCode.En,
					Name = "Compelled Duel",
					CastingTime = "1 bonus action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You issue a divine challenge to a creature you can see within range. It must make a Wisdom saving throw; on a failure, it is drawn into a duel with you for the duration. While the duel lasts, the target has disadvantage on attack rolls against creatures other than you, and whenever it tries to move to a space more than 30 feet away from you, it must make a Wisdom saving throw. On a success, the spell doesn't restrict its movement for that turn.\n\nThe spell ends early if you attack another creature, if you cast a spell that targets a hostile creature other than the target, if a creature friendly to you damages the target or casts a harmful spell on it, or if you end your turn more than 30 feet away from the target.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compelled-duel", "it"),
					Language = LanguageCode.It,
					Name = "Duello Obbligato",
					CastingTime = "1 azione bonus",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore lancia una sfida divina a una creatura entro gittata che sia in grado di vedere. La creatura deve effettuare un tiro salvezza su Saggezza; se lo fallisce, per la durata è costretta a duellare con l'incantatore. Finché il duello dura, il bersaglio subisce svantaggio ai tiri per colpire contro le creature diverse dall'incantatore e, ogni volta che tenta di spostarsi in uno spazio a più di 9 metri dall'incantatore, deve effettuare un tiro salvezza su Saggezza. Se lo supera, l'incantesimo non limita il suo movimento per quel turno.\n\nL'incantesimo termina prima del tempo se l'incantatore attacca un'altra creatura, se lancia un incantesimo che bersaglia una creatura ostile diversa dal bersaglio, se una creatura amichevole nei suoi confronti infligge danni al bersaglio o gli lancia contro un incantesimo dannoso, oppure se l'incantatore termina il proprio turno a più di 9 metri dal bersaglio.",
					HigherLevels = null
				}
			}
		};
	}
}
