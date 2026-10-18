using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Telepathy (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Telepathy2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 8,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathy", "en"),
					Language = LanguageCode.En,
					Name = "Telepathy",
					CastingTime = "Action",
					Range = "Unlimited",
					Duration = "24 hours",
					MaterialComponent = "a pair of linked silver rings",
					Description = "You open a mental channel between yourself and a willing creature you know well. The creature can be anywhere on your plane of existence; the spell ends if either of you leaves that plane.\n\nUntil the spell ends, the two of you can instantly exchange words, images, sounds, and other sensations through the link, and the target knows that it is you on the other end. The spell lets the creature understand the meaning of your words and of any sensations you send it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "telepathy", "it"),
					Language = LanguageCode.It,
					Name = "Telepatia",
					CastingTime = "Azione",
					Range = "Illimitata",
					Duration = "24 ore",
					MaterialComponent = "una coppia di anelli d'argento intrecciati",
					Description = "L'incantatore apre un canale mentale tra sé e una creatura consenziente che conosce bene. La creatura può trovarsi in qualsiasi punto del suo stesso piano di esistenza; l'incantesimo termina se uno dei due lascia quel piano.\n\nFinché l'incantesimo non termina, i due possono scambiarsi istantaneamente parole, immagini, suoni e altre sensazioni attraverso il legame, e il bersaglio sa che dall'altra parte c'è l'incantatore. L'incantesimo permette alla creatura di comprendere il significato delle parole dell'incantatore e delle sensazioni che le invia.",
					HigherLevels = null
				}
			}
		};
	}
}
