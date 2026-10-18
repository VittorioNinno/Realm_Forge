using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Detect Evil and Good (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DetectEvilAndGood2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-evil-and-good");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-evil-and-good", "en"),
					Language = LanguageCode.En,
					Name = "Detect Evil and Good",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "For the duration, you know if there is an aberration, celestial, elemental, fey, fiend, or undead within 30 feet of you, as well as where the creature is located. Similarly, you know if there is a place or object within 30 feet of you that has been magically consecrated or desecrated.\n\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-evil-and-good", "it"),
					Language = LanguageCode.It,
					Name = "Individuazione del Bene e del Male",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Per la durata, l'incantatore sa se entro 9 metri da lui si trova un'aberrazione, un celestiale, un elementale, un folletto, un immondo o un non morto, e sa anche dove si trova quella creatura. Allo stesso modo, sa se entro 9 metri da lui si trova un luogo o un oggetto che è stato consacrato o dissacrato tramite la magia.\n\nL'incantesimo può penetrare la maggior parte delle barriere, ma è bloccato da 30 cm di pietra, 2,5 cm di metallo comune, una sottile lamina di piombo o 90 cm di legno o terra.",
					HigherLevels = null
				}
			}
		};
	}
}
