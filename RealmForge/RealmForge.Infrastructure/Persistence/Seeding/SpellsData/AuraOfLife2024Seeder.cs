using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Life (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AuraOfLife2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-life");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-life", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Life",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "An aura radiates from you in a 30-foot Emanation for the duration. While in the aura, you and your allies have Resistance to Necrotic damage, and your Hit Point maximums can't be reduced. If an ally with 0 Hit Points starts its turn in the aura, that ally regains 1 Hit Point.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-life", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Vita",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Un'aura si irradia dall'incantatore in un'emanazione di 9 metri per la durata. Finché si trovano nell'aura, l'incantatore e i suoi alleati hanno resistenza ai danni necrotici e il loro massimo dei punti ferita non può essere ridotto. Se un alleato con 0 punti ferita inizia il proprio turno nell'aura, recupera 1 punto ferita.",
					HigherLevels = null
				}
			}
		};
	}
}
