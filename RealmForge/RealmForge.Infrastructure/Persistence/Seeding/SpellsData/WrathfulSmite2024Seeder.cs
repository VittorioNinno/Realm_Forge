using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wrathful Smite (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class WrathfulSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wrathful-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Necromancy,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wrathful-smite", "en"),
					Language = LanguageCode.En,
					Name = "Wrathful Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Dread rides along with your strike. Besides the attack's usual damage, the creature suffers 1d6 extra Necrotic damage. It then attempts a Wisdom saving throw, and if it fails it is Frightened for as long as the spell lasts. A Frightened creature gets another Wisdom save as each of its turns ends; a success frees it from the spell.",
					HigherLevels = "Add 1d6 to the damage for each slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wrathful-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Collerica",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Il terrore accompagna il colpo dell'incantatore. Oltre ai normali danni dell'attacco, la creatura subisce 1d6 danni necrotici extra. Poi tenta un tiro salvezza su Saggezza e, se fallisce, è spaventata per tutta la durata dell'incantesimo. Una creatura spaventata ottiene un altro tiro salvezza su Saggezza al termine di ogni suo turno; in caso di successo l'incantesimo smette di avere effetto su di lei.",
					HigherLevels = "Aggiungere 1d6 ai danni per ogni livello dello slot oltre il 1°."
				}
			}
		};
	}
}
