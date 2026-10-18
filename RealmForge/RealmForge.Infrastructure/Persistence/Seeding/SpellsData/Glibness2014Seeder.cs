using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Glibness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Glibness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glibness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glibness", "en"),
					Language = LanguageCode.En,
					Name = "Glibness",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "Until the spell ends, when you make a Charisma check, you can replace the number you roll with a 15. Additionally, no matter what you say, magic that would determine if you are telling the truth indicates that you are being truthful.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glibness", "it"),
					Language = LanguageCode.It,
					Name = "Loquacità",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Finché l'incantesimo non termina, quando l'incantatore effettua una prova di Carisma può sostituire il risultato del tiro con un 15. Inoltre, qualunque cosa dica, la magia che dovrebbe determinare se sta dicendo la verità indica che è sincero.",
					HigherLevels = null
				}
			}
		};
	}
}
