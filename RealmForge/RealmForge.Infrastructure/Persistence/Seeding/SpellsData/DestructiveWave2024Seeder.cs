using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Destructive Wave (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class DestructiveWave2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "destructive-wave");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "destructive-wave", "en"),
					Language = LanguageCode.En,
					Name = "Destructive Wave",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You slam the earth, and a rolling shock wave spreads through a 30-foot Emanation around you. Each creature you choose in the area attempts a Constitution saving throw.\n\n- **Failure:** 5d6 Thunder damage plus 5d6 Radiant or Necrotic damage (you pick which when you cast the spell), and the creature is knocked Prone.\n- **Success:** half of both kinds of damage, and the creature stays on its feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "destructive-wave", "it"),
					Language = LanguageCode.It,
					Name = "Onda Distruttiva",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore percuote il suolo, e un'onda d'urto si propaga in un'emanazione di 9 metri attorno a lui. Ogni creatura scelta dall'incantatore nell'area tenta un tiro salvezza su Costituzione.\n\n- **Fallimento:** 5d6 danni da tuono più 5d6 danni radiosi o necrotici (l'incantatore sceglie quali quando lancia l'incantesimo), e la creatura cade prona.\n- **Successo:** metà di entrambi i tipi di danni, e la creatura resta in piedi.",
					HigherLevels = null
				}
			}
		};
	}
}
