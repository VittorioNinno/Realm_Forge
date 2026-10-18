using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Vitality (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class AuraOfVitality2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-vitality");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-vitality", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Vitality",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "An aura of restorative energy spreads from you in a 30-foot radius and moves with you, centered on you, until the spell ends. As a bonus action, you can make one creature in the aura (you included) regain 2d6 hit points.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-vitality", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Vitalità",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un'aura di energia ristoratrice si irradia dall'incantatore in un raggio di 9 metri e si sposta con lui, rimanendo centrata su di lui, finché l'incantesimo non termina. Come azione bonus, l'incantatore può far recuperare 2d6 punti ferita a una creatura nell'aura (incluso sé stesso).",
					HigherLevels = null
				}
			}
		};
	}
}
