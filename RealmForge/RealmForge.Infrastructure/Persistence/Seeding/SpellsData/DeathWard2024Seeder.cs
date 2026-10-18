using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Death Ward (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DeathWard2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "death-ward");

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
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "death-ward", "en"),
					Language = LanguageCode.En,
					Name = "Death Ward",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "You touch a creature and grant it a measure of protection from death. The first time the target would drop to 0 Hit Points before the spell ends, the target instead drops to 1 Hit Point, and the spell ends.\n\nIf the spell is still in effect when the target is subjected to an effect that would kill it instantly without dealing damage, that effect is negated against the target, and the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "death-ward", "it"),
					Language = LanguageCode.It,
					Name = "Interdizione alla Morte",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura e le conferisce una certa protezione dalla morte. La prima volta che il bersaglio scenderebbe a 0 punti ferita prima che l'incantesimo termini, scende invece a 1 punto ferita e l'incantesimo termina.\n\nSe l'incantesimo è ancora attivo quando il bersaglio è soggetto a un effetto che lo ucciderebbe all'istante senza infliggere danni, quell'effetto viene annullato contro il bersaglio e l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
