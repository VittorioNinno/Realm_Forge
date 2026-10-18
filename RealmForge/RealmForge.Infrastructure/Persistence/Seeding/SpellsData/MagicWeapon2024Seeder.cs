using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Weapon (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicWeapon2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Magic Weapon",
					CastingTime = "Bonus Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You touch a nonmagical weapon. Until the spell ends, that weapon becomes a magic weapon with a +1 bonus to attack rolls and damage rolls. The spell ends early if you cast it again.",
					HigherLevels = "The bonus increases to +2 with a level 3–5 spell slot. The bonus increases to +3 with a level 6+ spell slot."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Magica",
					CastingTime = "Azione bonus",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca un'arma non magica. Finché l'incantesimo non termina, quell'arma diventa un'arma magica con un bonus di +1 ai tiri per colpire e ai tiri per i danni. L'incantesimo termina prima del tempo se l'incantatore lo lancia di nuovo.",
					HigherLevels = "Il bonus aumenta a +2 con uno slot incantesimo di 3°-5° livello. Il bonus aumenta a +3 con uno slot incantesimo di 6° livello o superiore."
				}
			}
		};
	}
}
