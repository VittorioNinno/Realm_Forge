using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Legend Lore (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LegendLore2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "legend-lore");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "legend-lore", "en"),
					Language = LanguageCode.En,
					Name = "Legend Lore",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "incense worth 250+ GP, which the spell consumes, and four ivory strips worth 50+ GP each",
					Description = "Name or describe a famous person, place, or object. The spell brings to your mind a brief summary of the significant lore about that famous thing, as described by the GM.\n\nThe lore might consist of important details, amusing revelations, or even secret lore that has never been widely known. The more information you already know about the thing, the more precise and detailed the information you receive is. That information is accurate but might be couched in figurative language or poetry, as determined by the GM.\n\nIf the famous thing you chose isn't actually famous, you hear sad musical notes played on a trombone, and the spell fails.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "legend-lore", "it"),
					Language = LanguageCode.It,
					Name = "Conoscenza delle Leggende",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "incenso del valore di almeno 250 mo, che l'incantesimo consuma, e quattro strisce d'avorio del valore di almeno 50 mo ciascuna",
					Description = "L'incantatore nomina o descrive una persona, un luogo o un oggetto famoso. L'incantesimo gli porta alla mente un breve riassunto delle conoscenze significative su quell'elemento famoso, secondo quanto descritto dal DM.\n\nLe conoscenze potrebbero consistere in dettagli importanti, rivelazioni divertenti o persino conoscenze segrete che non sono mai state ampiamente note. Più informazioni l'incantatore possiede già sull'elemento, più precise e dettagliate sono le informazioni che riceve. Queste informazioni sono accurate, ma potrebbero essere espresse in un linguaggio figurato o poetico, a discrezione del DM.\n\nSe l'elemento scelto non è davvero famoso, l'incantatore sente delle tristi note suonate da un trombone e l'incantesimo fallisce.",
					HigherLevels = null
				}
			}
		};
	}
}
