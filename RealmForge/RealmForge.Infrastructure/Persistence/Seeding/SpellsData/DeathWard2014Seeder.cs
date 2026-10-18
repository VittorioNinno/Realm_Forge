using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Death Ward (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DeathWard2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "death-ward");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "death-ward", "en"),
					Language = LanguageCode.En,
					Name = "Death Ward",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "You touch a creature and grant it a measure of protection from death.\n\nThe first time the target would drop to 0 hit points as a result of taking damage, the target instead drops to 1 hit point, and the spell ends.\n\nIf the spell is still in effect when the target is subjected to an effect that would kill it instantaneously without dealing damage, that effect is instead negated against the target, and the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "death-ward", "it"),
					Language = LanguageCode.It,
					Name = "Interdizione alla Morte",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura e le conferisce una certa protezione contro la morte.\n\nLa prima volta che il bersaglio dovrebbe scendere a 0 punti ferita a causa dei danni subiti, scende invece a 1 punto ferita e l'incantesimo termina.\n\nSe l'incantesimo è ancora attivo quando il bersaglio è soggetto a un effetto che lo ucciderebbe istantaneamente senza infliggere danni, quell'effetto viene invece annullato nei confronti del bersaglio e l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
