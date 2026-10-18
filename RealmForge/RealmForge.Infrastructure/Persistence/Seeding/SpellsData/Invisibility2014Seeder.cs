using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Invisibility (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Invisibility2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "invisibility");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "invisibility", "en"),
					Language = LanguageCode.En,
					Name = "Invisibility",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "an eyelash encased in gum arabic",
					Description = "A creature you touch becomes invisible until the spell ends. Anything the target is wearing or carrying is invisible as long as it is on the target's person. The spell ends for a target that attacks or casts a spell.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "invisibility", "it"),
					Language = LanguageCode.It,
					Name = "Invisibilità",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un ciglio avvolto nella gomma arabica",
					Description = "Una creatura toccata dall'incantatore diventa invisibile finché l'incantesimo non termina. Tutto ciò che il bersaglio indossa o trasporta è invisibile finché rimane sulla sua persona. L'incantesimo termina per un bersaglio che attacca o lancia un incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
