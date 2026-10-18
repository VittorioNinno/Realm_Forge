using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sanctuary (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sanctuary2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sanctuary");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sanctuary", "en"),
					Language = LanguageCode.En,
					Name = "Sanctuary",
					CastingTime = "Bonus Action",
					Range = "30 feet",
					Duration = "1 minute",
					MaterialComponent = "a shard of glass from a mirror",
					Description = "You ward a creature within range. Until the spell ends, any creature who targets the warded creature with an attack roll or a damaging spell must succeed on a Wisdom saving throw or either choose a new target or lose the attack or spell. This spell doesn't protect the warded creature from areas of effect. The spell ends if the warded creature makes an attack roll, casts a spell, or deals damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sanctuary", "it"),
					Language = LanguageCode.It,
					Name = "Santuario",
					CastingTime = "Azione bonus",
					Range = "9 metri",
					Duration = "1 minuto",
					MaterialComponent = "una scheggia di vetro di uno specchio",
					Description = "L'incantatore protegge una creatura entro gittata. Finché l'incantesimo non termina, qualsiasi creatura che prende come bersaglio la creatura protetta con un tiro per colpire o con un incantesimo dannoso deve superare un tiro salvezza su Saggezza, altrimenti deve scegliere un nuovo bersaglio o perdere l'attacco o l'incantesimo. Questo incantesimo non protegge la creatura protetta dalle aree d'effetto. L'incantesimo termina se la creatura protetta effettua un tiro per colpire, lancia un incantesimo o infligge danni.",
					HigherLevels = null
				}
			}
		};
	}
}
