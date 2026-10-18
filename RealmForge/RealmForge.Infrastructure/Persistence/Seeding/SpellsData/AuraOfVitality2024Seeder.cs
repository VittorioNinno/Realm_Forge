using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Vitality (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class AuraOfVitality2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-vitality");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-vitality", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Vitality",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Healing power pours out of you, filling a 30-foot Emanation for the spell's duration. Right after you cast the spell, pick one creature in the aura (you can pick yourself); it regains 2d6 Hit Points. You can make the same choice again at the start of each of your turns while the aura remains.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aura-of-vitality", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Vitalità",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un potere curativo si riversa fuori dall'incantatore e riempie un'emanazione di 9 metri per la durata dell'incantesimo. Subito dopo il lancio, l'incantatore sceglie una creatura nell'aura (anche se stesso), che recupera 2d6 punti ferita. Può ripetere la stessa scelta all'inizio di ogni suo turno finché l'aura rimane.",
					HigherLevels = null
				}
			}
		};
	}
}
