using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aid (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Aid2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aid");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aid", "en"),
					Language = LanguageCode.En,
					Name = "Aid",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a tiny strip of white cloth",
					Description = "Your spell bolsters your allies with toughness and resolve. Choose up to three creatures within range. Each target's hit point maximum and current hit points increase by 5 for the duration.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, a target's hit points increase by an additional 5 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aid", "it"),
					Language = LanguageCode.It,
					Name = "Aiuto",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "una piccola striscia di stoffa bianca",
					Description = "L'incantesimo infonde negli alleati dell'incantatore tenacia e determinazione. L'incantatore sceglie fino a tre creature entro gittata. Il massimo dei punti ferita e i punti ferita attuali di ogni bersaglio aumentano di 5 per la durata.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i punti ferita di un bersaglio aumentano di altri 5 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
