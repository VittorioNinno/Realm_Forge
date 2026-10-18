using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Light (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Light2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "light");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "light", "en"),
					Language = LanguageCode.En,
					Name = "Light",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a firefly or phosphorescent moss",
					Description = "You touch one object that is no larger than 10 feet in any dimension. Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet. The light can be colored as you like. Completely covering the object with something opaque blocks the light. The spell ends if you cast it again or dismiss it as an action.\n\nIf you target an object held or worn by a hostile creature, that creature must succeed on a Dexterity saving throw to avoid the spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "light", "it"),
					Language = LanguageCode.It,
					Name = "Luce",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una lucciola o del muschio fosforescente",
					Description = "L'incantatore tocca un oggetto le cui dimensioni non superano i 3 metri in ogni direzione. Finché l'incantesimo non termina, l'oggetto emette luce intensa in un raggio di 6 metri e luce fioca per ulteriori 6 metri. La luce può essere del colore che l'incantatore preferisce. Coprire completamente l'oggetto con qualcosa di opaco blocca la luce. L'incantesimo termina se l'incantatore lo lancia di nuovo o se lo congeda come azione.\n\nSe l'incantatore bersaglia un oggetto impugnato o indossato da una creatura ostile, quella creatura deve superare un tiro salvezza su Destrezza per evitare l'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
