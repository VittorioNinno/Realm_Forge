using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Invisibility (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Invisibility2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "invisibility");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "invisibility", "en"),
					Language = LanguageCode.En,
					Name = "Invisibility",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "an eyelash in gum arabic",
					Description = "A creature you touch has the Invisible condition until the spell ends. The spell ends early immediately after the target makes an attack roll, deals damage, or casts a spell.",
					HigherLevels = "You can target one additional creature for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "invisibility", "it"),
					Language = LanguageCode.It,
					Name = "Invisibilità",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un ciglio avvolto nella gomma arabica",
					Description = "Una creatura toccata dall'incantatore è invisibile finché l'incantesimo non termina. L'incantesimo termina prima del tempo subito dopo che il bersaglio effettua un tiro per colpire, infligge danni o lancia un incantesimo.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
