using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Reincarnate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Reincarnate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reincarnate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Necromancy,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reincarnate", "en"),
					Language = LanguageCode.En,
					Name = "Reincarnate",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "rare oils worth 1,000+ GP, which the spell consumes",
					Description = "You touch a dead Humanoid or a piece of one. If the creature has been dead no longer than 10 days, the spell forms a new body for it and calls the soul to enter that body. Roll 1d10 and consult the table below to determine the body's species, or the GM chooses another playable species.\n\n| 1d10 | Species | 1d10 | Species |\n|---|---|---|---|\n| 1 | Roll again. | 6 | Goliath |\n| 2 | Dragonborn | 7 | Halfling |\n| 3 | Dwarf | 8 | Human |\n| 4 | Elf | 9 | Orc |\n| 5 | Gnome | 10 | Tiefling |\n\nThe reincarnated creature makes any choices that a species' description offers, and the creature recalls its former life. It retains the capabilities it had in its original form, except it loses the traits of its previous species and gains the traits of its new one.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "reincarnate", "it"),
					Language = LanguageCode.It,
					Name = "Reincarnazione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "oli rari del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca un umanoide morto o un pezzo del suo corpo. Se la creatura è morta da non più di 10 giorni, l'incantesimo forma per lei un nuovo corpo e richiama l'anima affinché vi entri. L'incantatore tira 1d10 e consulta la tabella seguente per determinare la specie del corpo, oppure il DM sceglie un'altra specie giocabile.\n\n| 1d10 | Specie | 1d10 | Specie |\n|---|---|---|---|\n| 1 | Tira di nuovo. | 6 | Goliath |\n| 2 | Dragonide | 7 | Halfling |\n| 3 | Nano | 8 | Umano |\n| 4 | Elfo | 9 | Orco |\n| 5 | Gnomo | 10 | Tiefling |\n\nLa creatura reincarnata compie le scelte offerte dalla descrizione della specie e ricorda la sua vita precedente. Mantiene le capacità che aveva nella sua forma originale, ma perde i tratti della specie precedente e ottiene i tratti di quella nuova.",
					HigherLevels = null
				}
			}
		};
	}
}
