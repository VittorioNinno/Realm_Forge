using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arms of Hadar (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArmsOfHadar2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arms-of-hadar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arms-of-hadar", "en"),
					Language = LanguageCode.En,
					Name = "Arms of Hadar",
					CastingTime = "1 action",
					Range = "Self (10-foot radius)",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You call on Hadar, the Dark Hunger, and tendrils of black energy burst out of you to lash everything around you. Each creature within 10 feet of you makes a Strength saving throw. A creature that fails takes 2d6 necrotic damage and can't take reactions until its next turn. A creature that succeeds takes half as much damage and suffers no other effect.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arms-of-hadar", "it"),
					Language = LanguageCode.It,
					Name = "Braccia di Hadar",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 3 metri)",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore invoca Hadar, la Fame Oscura, e dal suo corpo erompono tentacoli di energia nera che sferzano tutto ciò che lo circonda. Ogni creatura entro 3 metri dall'incantatore effettua un tiro salvezza su Forza. Una creatura che lo fallisce subisce 2d6 danni necrotici e non può effettuare reazioni fino al suo turno successivo. Una creatura che lo supera subisce la metà di quei danni e nessun altro effetto.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
