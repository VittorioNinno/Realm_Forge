using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shillelagh (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shillelagh2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shillelagh");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shillelagh", "en"),
					Language = LanguageCode.En,
					Name = "Shillelagh",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = "mistletoe",
					Description = "A Club or Quarterstaff you are holding is imbued with nature's power. For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon's damage die becomes a d8. If the attack deals damage, it can be Force damage or the weapon's normal damage type (your choice).\n\nThe spell ends early if you cast it again or if you let go of the weapon.",
					HigherLevels = "The damage die changes when you reach levels 5 (d10), 11 (d12), and 17 (2d6)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shillelagh", "it"),
					Language = LanguageCode.It,
					Name = "Randello Incantato",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = "vischio",
					Description = "Un randello o un bastone ferrato impugnato dall'incantatore viene infuso del potere della natura. Per la durata, l'incantatore può usare la propria caratteristica da incantatore invece della Forza per i tiri per colpire e per i danni degli attacchi in mischia effettuati con quell'arma, e il dado dei danni dell'arma diventa un d8. Se l'attacco infligge danni, questi possono essere danni da forza o del normale tipo di danni dell'arma (a scelta dell'incantatore).\n\nL'incantesimo termina prima del tempo se l'incantatore lo lancia di nuovo o se lascia andare l'arma.",
					HigherLevels = "Il dado dei danni cambia quando l'incantatore raggiunge il 5° livello (d10), l'11° livello (d12) e il 17° livello (2d6)."
				}
			}
		};
	}
}
