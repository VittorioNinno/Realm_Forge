using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Destructive Wave (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class DestructiveWave2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "destructive-wave");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "destructive-wave", "en"),
					Language = LanguageCode.En,
					Name = "Destructive Wave",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You strike the ground and release a burst of divine power that rolls out from you. Each creature you choose within 30 feet of you makes a Constitution saving throw. On a failure, a creature takes 5d6 thunder damage plus 5d6 radiant or necrotic damage (your choice) and is knocked prone. On a success, it takes half as much damage and stays on its feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "destructive-wave", "it"),
					Language = LanguageCode.It,
					Name = "Onda Distruttiva",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore colpisce il terreno e libera un'esplosione di potere divino che si propaga attorno a lui. Ogni creatura a sua scelta entro 9 metri da lui effettua un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 5d6 danni da tuono più 5d6 danni radiosi o necrotici (a scelta dell'incantatore) e cade prona. Se lo supera, subisce la metà di quei danni e resta in piedi.",
					HigherLevels = null
				}
			}
		};
	}
}
