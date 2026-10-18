using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Life (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class AuraOfLife2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-life");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-life", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Life",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "An aura of life-sustaining energy spreads from you in a 30-foot radius and moves with you, centered on you, until the spell ends. Every nonhostile creature inside the aura, you included, has resistance to necrotic damage, and its hit point maximum can't be reduced. In addition, a nonhostile living creature that starts its turn in the aura with 0 hit points regains 1 hit point.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-life", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Vita",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Un'aura di energia vitale si irradia dall'incantatore in un raggio di 9 metri e si sposta con lui, rimanendo centrata su di lui, finché l'incantesimo non termina. Ogni creatura non ostile all'interno dell'aura, incluso l'incantatore, ha resistenza ai danni necrotici e il suo massimo dei punti ferita non può essere ridotto. Inoltre, una creatura vivente non ostile che inizia il proprio turno nell'aura con 0 punti ferita recupera 1 punto ferita.",
					HigherLevels = null
				}
			}
		};
	}
}
