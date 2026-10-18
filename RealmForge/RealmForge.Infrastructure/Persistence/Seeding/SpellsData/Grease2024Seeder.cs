using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Grease (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Grease2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grease");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grease", "en"),
					Language = LanguageCode.En,
					Name = "Grease",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "1 minute",
					MaterialComponent = "a bit of pork rind or butter",
					Description = "Nonflammable grease covers the ground in a 10-foot square centered on a point within range and turns it into Difficult Terrain for the duration.\n\nWhen the grease appears, each creature standing in its area must succeed on a Dexterity saving throw or have the Prone condition. A creature that enters the area or ends its turn there must also succeed on that save or fall Prone.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "grease", "it"),
					Language = LanguageCode.It,
					Name = "Unto",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "1 minuto",
					MaterialComponent = "un pezzetto di cotenna di maiale o di burro",
					Description = "Un grasso non infiammabile ricopre il terreno in un quadrato di 3 metri di lato centrato su un punto entro gittata, trasformandolo in terreno difficile per la durata.\n\nQuando il grasso compare, ogni creatura che si trova in piedi nella sua area deve superare un tiro salvezza su Destrezza, altrimenti cade prona. Anche una creatura che entra nell'area o vi termina il proprio turno deve superare quel tiro salvezza, altrimenti cade prona.",
					HigherLevels = null
				}
			}
		};
	}
}
