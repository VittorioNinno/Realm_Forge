using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hunter's Mark (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HuntersMark2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunters-mark");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunters-mark", "en"),
					Language = LanguageCode.En,
					Name = "Hunter's Mark",
					CastingTime = "1 bonus action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You choose a creature you can see within range and mystically mark it as your quarry. Until the spell ends, you deal an extra 1d6 damage to the target whenever you hit it with a weapon attack, and you have advantage on any Wisdom (Perception) or Wisdom (Survival) check you make to find it. If the target drops to 0 hit points before this spell ends, you can use a bonus action on a subsequent turn of yours to mark a new creature.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd or 4th level, you can maintain your concentration on the spell for up to 8 hours. When you use a spell slot of 5th level or higher, you can maintain your concentration on the spell for up to 24 hours."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hunters-mark", "it"),
					Language = LanguageCode.It,
					Name = "Marchio del Cacciatore",
					CastingTime = "1 azione bonus",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura entro gittata che sia in grado di vedere e la marchia misticamente come sua preda. Finché l'incantesimo non termina, l'incantatore infligge 1d6 danni extra al bersaglio ogni volta che lo colpisce con un attacco con un'arma, e dispone di vantaggio a qualsiasi prova di Saggezza (Percezione) o di Saggezza (Sopravvivenza) effettuata per trovarlo. Se il bersaglio scende a 0 punti ferita prima che questo incantesimo termini, l'incantatore può usare un'azione bonus in un suo turno successivo per marchiare una nuova creatura.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° o di 4° livello, può mantenere la concentrazione sull'incantesimo fino a 8 ore. Quando usa uno slot incantesimo di 5° livello o superiore, può mantenere la concentrazione sull'incantesimo fino a 24 ore."
				}
			}
		};
	}
}
