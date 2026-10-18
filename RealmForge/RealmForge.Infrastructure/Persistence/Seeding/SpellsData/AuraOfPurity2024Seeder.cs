using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Purity (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class AuraOfPurity2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-purity");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-purity", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Purity",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "For as long as the spell lasts, a 30-foot Emanation of cleansing energy surrounds you. You and every ally inside it gain two protections:\n\n- Resistance to Poison damage.\n- Advantage on any saving throw against an effect that inflicts, or lets the target shake off, one of these conditions: Blinded, Charmed, Deafened, Frightened, Paralyzed, Poisoned, or Stunned.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-purity", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Purezza",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Finché l'incantesimo dura, l'incantatore è circondato da un'emanazione di 9 metri di energia purificatrice. L'incantatore e tutti gli alleati al suo interno ottengono due protezioni:\n\n- Resistenza ai danni da veleno.\n- Vantaggio a qualunque tiro salvezza contro un effetto che impone, o permette al bersaglio di scrollarsi di dosso, una di queste condizioni: accecato, affascinato, assordato, avvelenato, paralizzato, spaventato o stordito.",
					HigherLevels = null
				}
			}
		};
	}
}
