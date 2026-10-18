using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Counterspell (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Counterspell2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "counterspell");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "counterspell", "en"),
					Language = LanguageCode.En,
					Name = "Counterspell",
					CastingTime = "1 reaction, which you take when you see a creature within 60 feet of you casting a spell",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You attempt to interrupt a creature in the process of casting a spell. If the creature is casting a spell of 3rd level or lower, its spell fails and has no effect. If it is casting a spell of 4th level or higher, make an ability check using your spellcasting ability. The DC equals 10 + the spell's level. On a success, the creature's spell fails and has no effect.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the interrupted spell has no effect if its level is less than or equal to the level of the spell slot you used."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "counterspell", "it"),
					Language = LanguageCode.It,
					Name = "Controincantesimo",
					CastingTime = "1 reazione, che l'incantatore effettua quando vede una creatura entro 18 metri da lui lanciare un incantesimo",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore tenta di interrompere una creatura mentre sta lanciando un incantesimo. Se la creatura sta lanciando un incantesimo di 3° livello o inferiore, il suo incantesimo fallisce e non ha alcun effetto. Se sta lanciando un incantesimo di 4° livello o superiore, l'incantatore effettua una prova di caratteristica usando la propria caratteristica da incantatore. La CD è pari a 10 + il livello dell'incantesimo. Se la prova riesce, l'incantesimo della creatura fallisce e non ha alcun effetto.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, l'incantesimo interrotto non ha alcun effetto se il suo livello è pari o inferiore al livello dello slot incantesimo usato."
				}
			}
		};
	}
}
