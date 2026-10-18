using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hex (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Hex2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hex");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hex", "en"),
					Language = LanguageCode.En,
					Name = "Hex",
					CastingTime = "Bonus Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "the petrified eye of a newt",
					Description = "You place a curse on a creature that you can see within range. Until the spell ends, you deal an extra 1d6 Necrotic damage to the target whenever you hit it with an attack roll. Also, choose one ability when you cast the spell. The target has Disadvantage on ability checks made with the chosen ability.\n\nIf the target drops to 0 Hit Points before this spell ends, you can take a Bonus Action on a later turn to curse a new creature.",
					HigherLevels = "Your Concentration can last longer with a spell slot of level 2 (up to 4 hours), 3–4 (up to 8 hours), or 5+ (24 hours)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hex", "it"),
					Language = LanguageCode.It,
					Name = "Sortilegio",
					CastingTime = "Azione bonus",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "l'occhio pietrificato di un tritone",
					Description = "L'incantatore lancia una maledizione su una creatura entro gittata che è in grado di vedere. Finché l'incantesimo non termina, l'incantatore infligge 1d6 danni necrotici extra al bersaglio ogni volta che lo colpisce con un tiro per colpire. Inoltre, quando lancia l'incantesimo, l'incantatore sceglie una caratteristica. Il bersaglio subisce svantaggio alle prove di caratteristica effettuate con la caratteristica scelta.\n\nSe il bersaglio scende a 0 punti ferita prima che questo incantesimo termini, l'incantatore può effettuare un'azione bonus in un turno successivo per maledire una nuova creatura.",
					HigherLevels = "La concentrazione dell'incantatore può durare più a lungo con uno slot incantesimo di 2° livello (fino a 4 ore), di 3°-4° livello (fino a 8 ore) o di 5° livello o superiore (24 ore)."
				}
			}
		};
	}
}
