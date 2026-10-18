using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divine Word (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DivineWord2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-word");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-word", "en"),
					Language = LanguageCode.En,
					Name = "Divine Word",
					CastingTime = "Bonus Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You utter a word imbued with power from the Upper Planes. Each creature of your choice in range makes a Charisma saving throw. On a failed save, a target that has 50 Hit Points or fewer suffers an effect based on its current Hit Points, as shown in the Divine Word Effects table. Regardless of its Hit Points, a Celestial, an Elemental, a Fey, or a Fiend target that fails its save is forced back to its plane of origin (if it isn't there already) and can't return to the current plane for 24 hours by any means short of a *Wish* spell.\n\n**Divine Word Effects**\n\n| Hit Points | Effect |\n|---|---|\n| 0–20 | The target dies. |\n| 21–30 | The target has the Blinded, Deafened, and Stunned conditions for 1 hour. |\n| 31–40 | The target has the Blinded and Deafened conditions for 10 minutes. |\n| 41–50 | The target has the Deafened condition for 1 minute. |",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divine-word", "it"),
					Language = LanguageCode.It,
					Name = "Parola Divina",
					CastingTime = "Azione bonus",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia una parola intrisa del potere dei Piani Superiori. Ogni creatura a sua scelta entro gittata effettua un tiro salvezza su Carisma. Se lo fallisce, un bersaglio che ha 50 punti ferita o meno subisce un effetto basato sui suoi punti ferita attuali, come indicato nella tabella degli Effetti della Parola Divina. Indipendentemente dai suoi punti ferita, un bersaglio celestiale, elementale, folletto o immondo che fallisce il tiro salvezza viene rispedito al suo piano d'origine (se non si trova già lì) e non può tornare sul piano attuale per 24 ore con alcun mezzo, se non con un incantesimo *desiderio*.\n\n**Effetti della Parola Divina**\n\n| Punti ferita | Effetto |\n|---|---|\n| 0–20 | Il bersaglio muore. |\n| 21–30 | Il bersaglio è accecato, assordato e stordito per 1 ora. |\n| 31–40 | Il bersaglio è accecato e assordato per 10 minuti. |\n| 41–50 | Il bersaglio è assordato per 1 minuto. |",
					HigherLevels = null
				}
			}
		};
	}
}
