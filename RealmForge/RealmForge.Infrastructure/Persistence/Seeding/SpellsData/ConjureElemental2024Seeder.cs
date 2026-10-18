using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Elemental (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureElemental2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-elemental");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-elemental", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Elemental",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure a Large, intangible spirit from the Elemental Planes that appears in an unoccupied space within range. Choose the spirit's element, which determines its damage type: air (Lightning), earth (Thunder), fire (Fire), or water (Cold). The spirit lasts for the duration.\n\nWhenever a creature you can see enters the spirit's space or starts its turn within 5 feet of the spirit, you can force that creature to make a Dexterity saving throw if the spirit has no creature Restrained. On failed save, the target takes 8d8 damage of the spirit's type, and the target has the Restrained condition until the spell ends. At the start of each of its turns, the Restrained target repeats the save.\n\nOn a failed save, the target takes 4d8 damage of the spirit's type. On a successful save, the target isn't Restrained by the spirit.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-elemental", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Elementale",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca uno spirito Grande e intangibile dai Piani Elementali, che compare in uno spazio libero entro gittata. Sceglie l'elemento dello spirito, che determina il suo tipo di danni: aria (fulmine), terra (tuono), fuoco (fuoco) o acqua (freddo). Lo spirito permane per la durata.\n\nOgni volta che una creatura che l'incantatore è in grado di vedere entra nello spazio dello spirito o inizia il proprio turno entro 1,5 metri dallo spirito, l'incantatore può costringere quella creatura a effettuare un tiro salvezza su Destrezza, se lo spirito non sta già trattenendo una creatura. Se lo fallisce, il bersaglio subisce 8d8 danni del tipo dello spirito ed è trattenuto finché l'incantesimo non termina. All'inizio di ogni suo turno, il bersaglio trattenuto ripete il tiro salvezza.\n\nSe lo fallisce, il bersaglio subisce 4d8 danni del tipo dello spirito. Se lo supera, il bersaglio non è più trattenuto dallo spirito.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
