using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dimension Door (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DimensionDoor2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dimension-door");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dimension-door", "en"),
					Language = LanguageCode.En,
					Name = "Dimension Door",
					CastingTime = "1 action",
					Range = "500 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You teleport yourself from your current location to any other spot within range. You arrive at exactly the spot desired. It can be a place you can see, one you can visualize, or one you can describe by stating distance and direction, such as \"200 feet straight downward\" or \"upward to the northwest at a 45-degree angle, 300 feet.\"\n\nYou can bring along objects as long as their weight doesn't exceed what you can carry. You can also bring one willing creature of your size or smaller who is carrying gear up to its carrying capacity. The creature must be within 5 feet of you when you cast this spell.\n\nIf you would arrive in a place already occupied by an object or a creature, you and any creature traveling with you each take 4d6 force damage, and the spell fails to teleport you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dimension-door", "it"),
					Language = LanguageCode.It,
					Name = "Porta Dimensionale",
					CastingTime = "1 azione",
					Range = "150 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore si teletrasporta dalla sua posizione attuale a un qualsiasi altro punto entro gittata. Arriva esattamente nel punto desiderato, che può essere un luogo che è in grado di vedere, un luogo che riesce a visualizzare o un luogo che può descrivere indicando distanza e direzione, come \"60 metri esattamente verso il basso\" o \"verso l'alto, in direzione nord-ovest con un'inclinazione di 45 gradi, per 90 metri\".\n\nL'incantatore può portare con sé degli oggetti, purché il loro peso non superi ciò che è in grado di trasportare. Può anche portare con sé una creatura consenziente della sua taglia o inferiore, che trasporti equipaggiamento entro i limiti della sua capacità di trasporto. La creatura deve trovarsi entro 1,5 metri dall'incantatore quando questi lancia l'incantesimo.\n\nSe l'incantatore dovesse arrivare in un luogo già occupato da un oggetto o da una creatura, lui e qualsiasi creatura che viaggia con lui subiscono ciascuno 4d6 danni da forza, e l'incantesimo non riesce a teletrasportarli.",
					HigherLevels = null
				}
			}
		};
	}
}
