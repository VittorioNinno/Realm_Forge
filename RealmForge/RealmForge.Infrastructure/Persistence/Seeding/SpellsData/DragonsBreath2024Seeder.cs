using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dragon's Breath (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DragonsBreath2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dragons-breath");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dragons-breath", "en"),
					Language = LanguageCode.En,
					Name = "Dragon's Breath",
					CastingTime = "Bonus Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a hot pepper",
					Description = "You touch one willing creature, and choose Acid, Cold, Fire, Lightning, or Poison. Until the spell ends, the target can take a Magic action to exhale a 15-foot Cone. Each creature in that area makes a Dexterity saving throw, taking 3d6 damage of the chosen type on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dragons-breath", "it"),
					Language = LanguageCode.It,
					Name = "Soffio del Drago",
					CastingTime = "Azione bonus",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un peperoncino piccante",
					Description = "L'incantatore tocca una creatura consenziente e sceglie acido, freddo, fuoco, fulmine o veleno. Finché l'incantesimo non termina, il bersaglio può effettuare un'azione di Magia per esalare un cono di 4,5 metri. Ogni creatura in quell'area effettua un tiro salvezza su Destrezza, subendo 3d6 danni del tipo scelto se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
