using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divine Word (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DivineWord2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divine-word");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divine-word", "en"),
					Language = LanguageCode.En,
					Name = "Divine Word",
					CastingTime = "1 bonus action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You utter a divine word, imbued with the power that shaped the world at the dawn of creation. Choose any number of creatures you can see within range. Each creature that can hear you must make a Charisma saving throw. On a failed save, a creature suffers an effect based on its current hit points:\n\n- 50 hit points or fewer: deafened for 1 minute\n\n- 40 hit points or fewer: deafened and blinded for 10 minutes\n\n- 30 hit points or fewer: blinded, deafened, and stunned for 1 hour\n\n- 20 hit points or fewer: killed instantly\n\nRegardless of its current hit points, a celestial, an elemental, a fey, or a fiend that fails its save is forced back to its plane of origin (if it isn't there already) and can't return to your current plane for 24 hours by any means short of a wish spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divine-word", "it"),
					Language = LanguageCode.It,
					Name = "Parola Divina",
					CastingTime = "1 azione bonus",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia una parola divina, intrisa del potere che plasmò il mondo all'alba della creazione. Sceglie un qualsiasi numero di creature entro gittata che sia in grado di vedere. Ogni creatura che può sentirlo deve effettuare un tiro salvezza su Carisma. Se lo fallisce, la creatura subisce un effetto che dipende dai suoi punti ferita attuali:\n\n- 50 punti ferita o meno: assordata per 1 minuto\n\n- 40 punti ferita o meno: assordata e accecata per 10 minuti\n\n- 30 punti ferita o meno: accecata, assordata e stordita per 1 ora\n\n- 20 punti ferita o meno: uccisa all'istante\n\nIndipendentemente dai suoi punti ferita attuali, un celestiale, un elementale, un folletto o un immondo che fallisce il tiro salvezza viene ricacciato nel suo piano d'origine (se non si trova già lì) e non può tornare nel piano attuale dell'incantatore per 24 ore con alcun mezzo, a eccezione di un incantesimo desiderio.",
					HigherLevels = null
				}
			}
		};
	}
}
