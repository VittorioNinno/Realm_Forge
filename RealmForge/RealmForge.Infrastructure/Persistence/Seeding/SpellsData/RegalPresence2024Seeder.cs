using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Regal Presence (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class RegalPresence2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regal-presence");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regal-presence", "en"),
					Language = LanguageCode.En,
					Name = "Regal Presence",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tiny crown",
					Description = "You take on an air of unearthly sovereignty that radiates in a 10-foot Emanation for the duration. You can demand a Wisdom saving throw from a creature you can see in any of these situations:\n\n- your Emanation moves into the creature's space;\n- the creature moves into your Emanation;\n- the creature finishes its turn inside your Emanation.\n\nA creature that fails suffers 4d6 Psychic damage, falls Prone, and can be shoved up to 10 feet away from you if you wish. A creature that succeeds suffers half the damage and nothing else. No creature makes this save more than once per turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "regal-presence", "it"),
					Language = LanguageCode.It,
					Name = "Presenza Regale",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una minuscola corona",
					Description = "L'incantatore assume un'aria di sovranità ultraterrena che si irradia in un'emanazione di 3 metri per la durata. Può pretendere un tiro salvezza su Saggezza da una creatura che è in grado di vedere in una qualsiasi di queste situazioni:\n\n- la sua emanazione si sposta nello spazio della creatura;\n- la creatura si sposta nella sua emanazione;\n- la creatura conclude il proprio turno all'interno della sua emanazione.\n\nUna creatura che fallisce subisce 4d6 danni psichici, cade prona e, se l'incantatore lo desidera, può essere spinta fino a 3 metri lontano da lui. Una creatura che riesce subisce metà dei danni e nient'altro. Nessuna creatura effettua questo tiro salvezza più di una volta per turno.",
					HigherLevels = null
				}
			}
		};
	}
}
