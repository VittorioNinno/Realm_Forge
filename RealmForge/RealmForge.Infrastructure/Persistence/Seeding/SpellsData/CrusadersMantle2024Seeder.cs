using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Crusader's Mantle (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CrusadersMantle2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crusaders-mantle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crusaders-mantle", "en"),
					Language = LanguageCode.En,
					Name = "Crusader's Mantle",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Holy power radiates from you in a 30-foot Emanation for the duration. While inside it, you and each of your allies deal an extra 1d4 Radiant damage whenever you hit with a weapon or an Unarmed Strike.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crusaders-mantle", "it"),
					Language = LanguageCode.It,
					Name = "Manto del Crociato",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un potere sacro si irradia dall'incantatore in un'emanazione di 9 metri per la durata. Finché si trovano al suo interno, l'incantatore e ciascuno dei suoi alleati infliggono 1d4 danni radiosi extra ogni volta che colpiscono con un'arma o con un colpo senz'armi.",
					HigherLevels = null
				}
			}
		};
	}
}
