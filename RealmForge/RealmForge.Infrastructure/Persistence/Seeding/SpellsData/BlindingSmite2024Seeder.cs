using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blinding Smite (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BlindingSmite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blinding-smite");

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
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blinding-smite", "en"),
					Language = LanguageCode.En,
					Name = "Blinding Smite",
					CastingTime = "Bonus Action, which you take immediately after hitting a creature with a Melee weapon or an Unarmed Strike",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "A flash of searing brilliance erupts where your blow lands. On top of the attack's usual damage, the creature suffers 3d8 extra Radiant damage, and it is Blinded for as long as the spell lasts. When each of its turns ends, the creature attempts a Constitution saving throw; a success frees it from the spell.",
					HigherLevels = "Add 1d8 to the extra damage for each slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blinding-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Accecante",
					CastingTime = "Azione bonus, che l'incantatore effettua subito dopo aver colpito una creatura con un'arma da mischia o un colpo senz'armi",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Nel punto in cui il colpo va a segno esplode un lampo di splendore bruciante. Oltre ai normali danni dell'attacco, la creatura subisce 3d8 danni radiosi extra ed è accecata per tutta la durata dell'incantesimo. Al termine di ogni suo turno, la creatura tenta un tiro salvezza su Costituzione; in caso di successo l'incantesimo smette di avere effetto su di lei.",
					HigherLevels = "Aggiungere 1d8 ai danni extra per ogni livello dello slot oltre il 3°."
				}
			}
		};
	}
}
