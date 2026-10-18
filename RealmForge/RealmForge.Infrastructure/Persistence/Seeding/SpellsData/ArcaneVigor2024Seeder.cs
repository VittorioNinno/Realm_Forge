using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Vigor (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArcaneVigor2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-vigor");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-vigor", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Vigor",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You draw on your own vitality to mend your wounds. Roll one or two of your unexpended Hit Point Dice. You regain Hit Points equal to the total rolled plus your spellcasting ability modifier, and the dice you rolled are expended.",
					HigherLevels = "You can roll one additional unexpended Hit Point Die for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-vigor", "it"),
					Language = LanguageCode.It,
					Name = "Vigore Arcano",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore attinge alla propria vitalità per sanare le proprie ferite. Tira uno o due dei suoi Dadi Vita non spesi e recupera punti ferita pari al totale ottenuto più il suo modificatore di caratteristica da incantatore; i dadi tirati vengono spesi.",
					HigherLevels = "L'incantatore può tirare un Dado Vita non speso aggiuntivo per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
