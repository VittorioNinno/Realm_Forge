using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Identify (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Identify2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "identify");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "identify", "en"),
					Language = LanguageCode.En,
					Name = "Identify",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a pearl worth 100+ GP",
					Description = "You touch an object throughout the spell's casting. If the object is a magic item or some other magical object, you learn its properties and how to use them, whether it requires Attunement, and how many charges it has, if any. You learn whether any ongoing spells are affecting the item and what they are. If the item was created by a spell, you learn that spell's name.\n\nIf you instead touch a creature throughout the casting, you learn which ongoing spells, if any, are currently affecting it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "identify", "it"),
					Language = LanguageCode.It,
					Name = "Identificare",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "una perla del valore di almeno 100 mo",
					Description = "L'incantatore tocca un oggetto per tutta la durata del lancio dell'incantesimo. Se l'oggetto è un oggetto magico o un altro tipo di oggetto incantato, l'incantatore ne apprende le proprietà e il modo di usarle, se richiede sintonia e quante cariche ha, se ne ha. Apprende se l'oggetto è influenzato da incantesimi in corso e quali sono. Se l'oggetto è stato creato da un incantesimo, apprende il nome di quell'incantesimo.\n\nSe invece tocca una creatura per tutta la durata del lancio, l'incantatore apprende quali incantesimi in corso la stanno influenzando, se ce ne sono.",
					HigherLevels = null
				}
			}
		};
	}
}
