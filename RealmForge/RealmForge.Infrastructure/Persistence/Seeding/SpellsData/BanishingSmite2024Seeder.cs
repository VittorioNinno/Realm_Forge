using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Banishing Smite (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BanishingSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishing-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishing-smite", "en"),
					Language = LanguageCode.En,
					Name = "Banishing Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Your blow crackles with force: the creature you hit takes an extra 5d10 Force damage from the attack. If this attack leaves the creature with 50 Hit Points or fewer, it must succeed on a Charisma saving throw or be whisked away to a harmless demiplane for the duration, where it has the Incapacitated condition. When the spell ends, the creature returns to the space it left, or to the nearest unoccupied space if that one is taken.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishing-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Esiliante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Il colpo dell'incantatore crepita di forza: la creatura colpita subisce 5d10 danni da forza extra dall'attacco. Se l'attacco la lascia con 50 punti ferita o meno, la creatura deve superare un tiro salvezza su Carisma, altrimenti viene trasportata in un semipiano innocuo per la durata, dove è incapacitata. Quando l'incantesimo termina, la creatura ritorna nello spazio che aveva lasciato o, se è occupato, nello spazio libero più vicino.",
					HigherLevels = null
				}
			}
		};
	}
}
