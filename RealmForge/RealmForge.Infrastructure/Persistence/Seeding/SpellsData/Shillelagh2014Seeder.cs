using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shillelagh (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shillelagh2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shillelagh");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shillelagh", "en"),
					Language = LanguageCode.En,
					Name = "Shillelagh",
					CastingTime = "1 bonus action",
					Range = "Touch",
					Duration = "1 minute",
					MaterialComponent = "mistletoe, a shamrock leaf, and a club or quarterstaff",
					Description = "The wood of a club or a quarterstaff you are holding is imbued with nature's power. For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon's damage die becomes a d8. The weapon also becomes magical, if it isn't already. The spell ends if you cast it again or if you let go of the weapon.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shillelagh", "it"),
					Language = LanguageCode.It,
					Name = "Randello Incantato",
					CastingTime = "1 azione bonus",
					Range = "Contatto",
					Duration = "1 minuto",
					MaterialComponent = "vischio, una foglia di trifoglio e un randello o un bastone ferrato",
					Description = "Il legno di un randello o di un bastone ferrato impugnato dall'incantatore viene infuso del potere della natura. Per la durata, l'incantatore può usare la propria caratteristica da incantatore al posto della Forza per i tiri per colpire e per i danni degli attacchi in mischia effettuati con quell'arma, e il dado dei danni dell'arma diventa un d8. Inoltre, l'arma diventa magica, se non lo è già. L'incantesimo termina se l'incantatore lo lancia di nuovo o se lascia andare l'arma.",
					HigherLevels = null
				}
			}
		};
	}
}
