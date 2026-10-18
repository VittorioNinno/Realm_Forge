using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dispel Evil and Good (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DispelEvilAndGood2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dispel-evil-and-good");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dispel-evil-and-good", "en"),
					Language = LanguageCode.En,
					Name = "Dispel Evil and Good",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "holy water or powdered silver and iron",
					Description = "Shimmering energy surrounds and protects you from fey, undead, and creatures originating from beyond the Material Plane. For the duration, celestials, elementals, fey, fiends, and undead have disadvantage on attack rolls against you.\n\nYou can end the spell early by using either of the following special functions.\n\n***Break Enchantment.*** As your action, you touch a creature you can reach that is charmed, frightened, or possessed by a celestial, an elemental, a fey, a fiend, or an undead. The creature you touch is no longer charmed, frightened, or possessed by such creatures.\n\n***Dismissal.*** As your action, make a melee spell attack against a celestial, an elemental, a fey, a fiend, or an undead you can reach. On a hit, you attempt to drive the creature back to its home plane. The creature must succeed on a Charisma saving throw or be sent back to its home plane (if it isn't there already). If they aren't on their home plane, undead are sent to the Shadowfell, and fey are sent to the Feywild.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dispel-evil-and-good", "it"),
					Language = LanguageCode.It,
					Name = "Dissolvi il Bene e il Male",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "acqua santa oppure polvere d'argento e di ferro",
					Description = "Un'energia scintillante circonda l'incantatore e lo protegge dai folletti, dai non morti e dalle creature originarie di luoghi al di là del Piano Materiale. Per la durata, i celestiali, gli elementali, i folletti, gli immondi e i non morti subiscono svantaggio ai tiri per colpire contro l'incantatore.\n\nL'incantatore può porre fine prematuramente all'incantesimo usando una delle funzioni speciali seguenti.\n\n***Spezzare Ammaliamenti.*** Come azione, l'incantatore tocca una creatura a portata che sia affascinata, spaventata o posseduta da un celestiale, un elementale, un folletto, un immondo o un non morto. La creatura toccata non è più affascinata, spaventata o posseduta da tali creature.\n\n***Congedo.*** Come azione, l'incantatore effettua un attacco con incantesimo in mischia contro un celestiale, un elementale, un folletto, un immondo o un non morto a portata. Se colpisce, tenta di ricacciare la creatura nel suo piano d'origine. La creatura deve superare un tiro salvezza su Carisma, altrimenti viene rimandata nel suo piano d'origine (se non si trova già lì). Se non si trovano nel loro piano d'origine, i non morti vengono inviati nella Coltre Oscura e i folletti nella Selva Fatata.",
					HigherLevels = null
				}
			}
		};
	}
}
