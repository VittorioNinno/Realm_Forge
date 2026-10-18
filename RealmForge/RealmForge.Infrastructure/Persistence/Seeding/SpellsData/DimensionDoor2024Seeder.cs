using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dimension Door (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DimensionDoor2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dimension-door");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dimension-door", "en"),
					Language = LanguageCode.En,
					Name = "Dimension Door",
					CastingTime = "Action",
					Range = "500 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You teleport to a location within range. You arrive at exactly the spot desired. It can be a place you can see, one you can visualize, or one you can describe by stating distance and direction, such as \"200 feet straight downward\" or \"300 feet upward to the northwest at a 45-degree angle.\"\n\nYou can also teleport one willing creature. The creature must be within 5 feet of you when you teleport, and it teleports to a space within 5 feet of your destination space. If you, the other creature, or both would arrive in a space occupied by a creature or completely filled by one or more objects, you and any creature traveling with you each take 4d6 Force damage, and the teleportation fails.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dimension-door", "it"),
					Language = LanguageCode.It,
					Name = "Porta Dimensionale",
					CastingTime = "Azione",
					Range = "150 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore si teletrasporta in un luogo entro gittata. Arriva esattamente nel punto desiderato. Può trattarsi di un luogo che è in grado di vedere, di un luogo che riesce a visualizzare o di un luogo che può descrivere indicando distanza e direzione, come \"60 metri verso il basso\" o \"90 metri verso l'alto in direzione nord-ovest, con un angolo di 45 gradi\".\n\nL'incantatore può teletrasportare anche una creatura consenziente. La creatura deve trovarsi entro 1,5 metri da lui quando si teletrasporta, e si teletrasporta in uno spazio entro 1,5 metri dallo spazio di destinazione dell'incantatore. Se l'incantatore, l'altra creatura o entrambi arriverebbero in uno spazio occupato da una creatura o completamente riempito da uno o più oggetti, l'incantatore e ogni creatura che viaggia con lui subiscono ciascuno 4d6 danni da forza e il teletrasporto fallisce.",
					HigherLevels = null
				}
			}
		};
	}
}
