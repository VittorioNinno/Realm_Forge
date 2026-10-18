using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hex (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Hex2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hex");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hex", "en"),
					Language = LanguageCode.En,
					Name = "Hex",
					CastingTime = "1 bonus action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "the petrified eye of a newt",
					Description = "You lay a curse on a creature you can see within range. Until the spell ends, you deal an extra 1d6 necrotic damage to the target whenever you hit it with an attack. When you cast the spell, you also choose one ability: the target has disadvantage on ability checks made with that ability.\n\nIf the target drops to 0 hit points before the spell ends, you can use a bonus action on a later turn to move the curse to a new creature.\n\nA remove curse spell cast on the target ends this spell early.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd or 4th level, you can maintain your concentration on it for up to 8 hours. When you use a spell slot of 5th level or higher, you can maintain your concentration on it for up to 24 hours."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hex", "it"),
					Language = LanguageCode.It,
					Name = "Sortilegio",
					CastingTime = "1 azione bonus",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "l'occhio pietrificato di un tritone",
					Description = "L'incantatore lancia una maledizione su una creatura entro gittata che sia in grado di vedere. Finché l'incantesimo non termina, ogni volta che colpisce il bersaglio con un attacco gli infligge 1d6 danni necrotici extra. Quando lancia l'incantesimo, l'incantatore sceglie anche una caratteristica: il bersaglio subisce svantaggio alle prove di caratteristica effettuate con quella caratteristica.\n\nSe il bersaglio scende a 0 punti ferita prima che l'incantesimo termini, l'incantatore può usare un'azione bonus in un turno successivo per trasferire la maledizione su una nuova creatura.\n\nUn incantesimo rimuovi maledizione lanciato sul bersaglio pone fine prematuramente a questo incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° o di 4° livello, può mantenere la concentrazione su di esso fino a 8 ore. Quando usa uno slot incantesimo di 5° livello o superiore, può mantenere la concentrazione su di esso fino a 24 ore."
				}
			}
		};
	}
}
