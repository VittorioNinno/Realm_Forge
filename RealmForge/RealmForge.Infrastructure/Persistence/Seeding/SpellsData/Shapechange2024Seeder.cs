using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shapechange (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shapechange2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shapechange");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shapechange", "en"),
					Language = LanguageCode.En,
					Name = "Shapechange",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a jade circlet worth 1,500+ GP",
					Description = "You shape-shift into another creature for the duration or until you take a Magic action to shape-shift into a different eligible form. The new form must be of a creature that has a Challenge Rating no higher than your level or Challenge Rating. You must have seen the sort of creature before, and it can't be a Construct or an Undead.\n\nWhen you cast the spell, you gain a number of Temporary Hit Points equal to the Hit Points of the first form into which you shape-shift. These Temporary Hit Points vanish if any remain when the spell ends.\n\nYour game statistics are replaced by the stat block of the chosen form, but you retain your creature type; alignment; personality; Intelligence, Wisdom, and Charisma scores; Hit Points; Hit Point Dice; proficiencies; and ability to communicate. If you have the Spellcasting feature, you retain it too.\n\nUpon shape-shifting, you determine whether your equipment drops to the ground or changes in size and shape to fit the new form while you're in it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shapechange", "it"),
					Language = LanguageCode.It,
					Name = "Trasformazione",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un diadema di giada del valore di almeno 1.500 mo",
					Description = "L'incantatore si trasforma in un'altra creatura per la durata o finché non effettua un'azione di Magia per trasformarsi in una diversa forma consentita. La nuova forma deve essere quella di una creatura con un Grado di Sfida non superiore al livello o al Grado di Sfida dell'incantatore. L'incantatore deve aver già visto quel tipo di creatura, e non può trattarsi di un costrutto o di un non morto.\n\nQuando lancia l'incantesimo, l'incantatore ottiene un numero di punti ferita temporanei pari ai punti ferita della prima forma in cui si trasforma. Gli eventuali punti ferita temporanei rimasti svaniscono quando l'incantesimo termina.\n\nLe statistiche di gioco dell'incantatore sono sostituite dalla scheda delle statistiche della forma scelta, ma l'incantatore mantiene il proprio tipo di creatura, l'allineamento, la personalità, i punteggi di Intelligenza, Saggezza e Carisma, i punti ferita, i Dadi Vita, le competenze e la capacità di comunicare. Se dispone del privilegio Incantesimi, mantiene anche quello.\n\nQuando si trasforma, l'incantatore stabilisce se il proprio equipaggiamento cade a terra o cambia dimensioni e forma per adattarsi alla nuova forma finché vi rimane.",
					HigherLevels = null
				}
			}
		};
	}
}
