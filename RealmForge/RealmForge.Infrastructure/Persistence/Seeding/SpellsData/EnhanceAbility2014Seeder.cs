using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Enhance Ability (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class EnhanceAbility2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enhance-ability");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enhance-ability", "en"),
					Language = LanguageCode.En,
					Name = "Enhance Ability",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "fur or a feather from a beast",
					Description = "You touch a creature and bestow upon it a magical enhancement. Choose one of the following effects; the target gains that effect until the spell ends.\n\n***Bear's Endurance.*** The target has advantage on Constitution checks. It also gains 2d6 temporary hit points, which are lost when the spell ends.\n\n***Bull's Strength.*** The target has advantage on Strength checks, and his or her carrying capacity doubles.\n\n***Cat's Grace.*** The target has advantage on Dexterity checks. It also doesn't take damage from falling 20 feet or less if it isn't incapacitated.\n\n***Eagle's Splendor.*** The target has advantage on Charisma checks.\n\n***Fox's Cunning.*** The target has advantage on Intelligence checks.\n\n***Owl's Wisdom.*** The target has advantage on Wisdom checks.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enhance-ability", "it"),
					Language = LanguageCode.It,
					Name = "Caratteristica Potenziata",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "pelo o una piuma di una bestia",
					Description = "L'incantatore tocca una creatura e le conferisce un potenziamento magico. Sceglie uno degli effetti seguenti; il bersaglio ottiene quell'effetto finché l'incantesimo non termina.\n\n***Resistenza dell'Orso.*** Il bersaglio dispone di vantaggio alle prove di Costituzione. Ottiene inoltre 2d6 punti ferita temporanei, che perde quando l'incantesimo termina.\n\n***Forza del Toro.*** Il bersaglio dispone di vantaggio alle prove di Forza e la sua capacità di trasporto raddoppia.\n\n***Grazia del Gatto.*** Il bersaglio dispone di vantaggio alle prove di Destrezza. Inoltre, se non è incapacitato, non subisce danni dalle cadute di 6 metri o meno.\n\n***Splendore dell'Aquila.*** Il bersaglio dispone di vantaggio alle prove di Carisma.\n\n***Astuzia della Volpe.*** Il bersaglio dispone di vantaggio alle prove di Intelligenza.\n\n***Saggezza del Gufo.*** Il bersaglio dispone di vantaggio alle prove di Saggezza.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
