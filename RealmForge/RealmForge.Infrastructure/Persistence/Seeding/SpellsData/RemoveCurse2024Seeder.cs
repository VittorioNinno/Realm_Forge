using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Remove Curse (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RemoveCurse2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "remove-curse");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "remove-curse", "en"),
					Language = LanguageCode.En,
					Name = "Remove Curse",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "At your touch, all curses affecting one creature or object end. If the object is a cursed magic item, its curse remains, but the spell breaks its owner's Attunement to the object so it can be removed or discarded.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "remove-curse", "it"),
					Language = LanguageCode.It,
					Name = "Rimuovi Maledizione",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Al tocco dell'incantatore, tutte le maledizioni che affliggono una creatura o un oggetto terminano. Se l'oggetto è un oggetto magico maledetto, la sua maledizione permane, ma l'incantesimo spezza la sintonia del proprietario con l'oggetto, in modo che possa essere rimosso o gettato via.",
					HigherLevels = null
				}
			}
		};
	}
}
