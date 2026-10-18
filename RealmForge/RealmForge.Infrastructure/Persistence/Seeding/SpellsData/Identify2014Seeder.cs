using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Identify (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Identify2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "identify");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "identify", "en"),
					Language = LanguageCode.En,
					Name = "Identify",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a pearl worth at least 100 gp and an owl feather",
					Description = "You choose one object that you must touch throughout the casting of the spell. If it is a magic item or some other magic-imbued object, you learn its properties and how to use them, whether it requires attunement to use, and how many charges it has, if any. You learn whether any spells are affecting the item and what they are. If the item was created by a spell, you learn which spell created it.\n\nIf you instead touch a creature throughout the casting, you learn what spells, if any, are currently affecting it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "identify", "it"),
					Language = LanguageCode.It,
					Name = "Identificare",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "una perla del valore di almeno 100 mo e una piuma di gufo",
					Description = "L'incantatore sceglie un oggetto che deve toccare per tutto il lancio dell'incantesimo. Se si tratta di un oggetto magico o di un altro oggetto infuso di magia, l'incantatore ne apprende le proprietà e il modo di usarle, se è necessaria la sintonia per usarlo e quante cariche possiede, se ne ha. Apprende se l'oggetto è influenzato da qualche incantesimo e quale. Se l'oggetto è stato creato da un incantesimo, apprende quale incantesimo lo ha creato.\n\nSe invece tocca una creatura per tutto il lancio, l'incantatore apprende quali incantesimi la stanno influenzando, se ce ne sono.",
					HigherLevels = null
				}
			}
		};
	}
}
