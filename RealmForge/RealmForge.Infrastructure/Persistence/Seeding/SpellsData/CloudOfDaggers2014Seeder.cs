using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cloud of Daggers (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CloudOfDaggers2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloud-of-daggers");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloud-of-daggers", "en"),
					Language = LanguageCode.En,
					Name = "Cloud of Daggers",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a sliver of glass",
					Description = "A whirling mass of conjured daggers fills a 5-foot cube centered on a point you choose within range. A creature takes 4d4 slashing damage when it enters the cube for the first time on a turn or starts its turn inside it.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 2d4 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloud-of-daggers", "it"),
					Language = LanguageCode.It,
					Name = "Nube di Pugnali",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una scheggia di vetro",
					Description = "Una massa vorticante di pugnali evocati riempie un cubo con spigolo di 1,5 metri centrato su un punto entro gittata scelto dall'incantatore. Una creatura subisce 4d4 danni taglienti quando entra nel cubo per la prima volta in un turno o vi inizia il proprio turno.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 2d4 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
