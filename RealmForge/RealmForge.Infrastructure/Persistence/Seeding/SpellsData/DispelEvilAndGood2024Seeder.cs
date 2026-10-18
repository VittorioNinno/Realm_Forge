using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dispel Evil and Good (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DispelEvilAndGood2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-evil-and-good");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-evil-and-good", "en"),
					Language = LanguageCode.En,
					Name = "Dispel Evil and Good",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "powdered silver and iron",
					Description = "For the duration, Celestials, Elementals, Fey, Fiends, and Undead have Disadvantage on attack rolls against you. You can end the spell early by using either of the following special functions.\n\n***Break Enchantment.*** As a Magic action, you touch a creature that is possessed by or has the Charmed or Frightened condition from one or more creatures of the types above. The target is no longer possessed, Charmed, or Frightened by such creatures.\n\n***Dismissal.*** As a Magic action, you target one creature you can see within 5 feet of you that has one of the creature types above. The target must succeed on a Charisma saving throw or be sent back to its home plane if it isn't there already. If they aren't on their home plane, Undead are sent to the Shadowfell, and Fey are sent to the Feywild.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-evil-and-good", "it"),
					Language = LanguageCode.It,
					Name = "Dissolvi il Bene e il Male",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "argento e ferro in polvere",
					Description = "Per la durata, celestiali, elementali, folletti, immondi e non morti subiscono svantaggio ai tiri per colpire contro l'incantatore. L'incantatore può porre fine all'incantesimo prima del tempo usando una delle funzioni speciali seguenti.\n\n***Spezzare Ammaliamento.*** Come azione di Magia, l'incantatore tocca una creatura che è posseduta, affascinata o spaventata da una o più creature dei tipi sopra indicati. Il bersaglio non è più posseduto, affascinato o spaventato da tali creature.\n\n***Congedo.*** Come azione di Magia, l'incantatore sceglie come bersaglio una creatura che è in grado di vedere entro 1,5 metri da sé e che appartiene a uno dei tipi di creatura sopra indicati. Il bersaglio deve superare un tiro salvezza su Carisma, altrimenti viene rispedito al suo piano natale, se non si trova già lì. Se non si trovano sul loro piano natale, i non morti vengono inviati nella Coltre Oscura e i folletti nella Selva Fatata.",
					HigherLevels = null
				}
			}
		};
	}
}
