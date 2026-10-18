using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hunter's Mark (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HuntersMark2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunters-mark");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunters-mark", "en"),
					Language = LanguageCode.En,
					Name = "Hunter's Mark",
					CastingTime = "Bonus Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You magically mark one creature you can see within range as your quarry. Until the spell ends, you deal an extra 1d6 Force damage to the target whenever you hit it with an attack roll. You also have Advantage on any Wisdom (Perception or Survival) check you make to find it.\n\nIf the target drops to 0 Hit Points before this spell ends, you can take a Bonus Action to move the mark to a new creature you can see within range.",
					HigherLevels = "Your Concentration can last longer with a spell slot of level 3–4 (up to 8 hours) or 5+ (up to 24 hours)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunters-mark", "it"),
					Language = LanguageCode.It,
					Name = "Marchio del Cacciatore",
					CastingTime = "Azione bonus",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore marchia magicamente come propria preda una creatura entro gittata che è in grado di vedere. Finché l'incantesimo non termina, l'incantatore infligge 1d6 danni da forza extra al bersaglio ogni volta che lo colpisce con un tiro per colpire. Dispone inoltre di vantaggio a qualsiasi prova di Saggezza (Percezione o Sopravvivenza) effettuata per trovarlo.\n\nSe il bersaglio scende a 0 punti ferita prima che questo incantesimo termini, l'incantatore può effettuare un'azione bonus per spostare il marchio su una nuova creatura entro gittata che è in grado di vedere.",
					HigherLevels = "La concentrazione dell'incantatore può durare più a lungo con uno slot incantesimo di 3°-4° livello (fino a 8 ore) o di 5° livello o superiore (fino a 24 ore)."
				}
			}
		};
	}
}
