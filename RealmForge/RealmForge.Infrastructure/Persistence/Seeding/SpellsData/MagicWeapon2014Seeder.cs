using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Weapon (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicWeapon2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Magic Weapon",
					CastingTime = "1 bonus action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You touch a nonmagical weapon. Until the spell ends, that weapon becomes a magic weapon with a +1 bonus to attack rolls and damage rolls.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the bonus increases to +2. When you use a spell slot of 6th level or higher, the bonus increases to +3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Magica",
					CastingTime = "1 azione bonus",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca un'arma non magica. Finché l'incantesimo non termina, quell'arma diventa un'arma magica con un bonus di +1 ai tiri per colpire e ai tiri per i danni.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, il bonus aumenta a +2. Quando usa uno slot incantesimo di 6° livello o superiore, il bonus aumenta a +3."
				}
			}
		};
	}
}
