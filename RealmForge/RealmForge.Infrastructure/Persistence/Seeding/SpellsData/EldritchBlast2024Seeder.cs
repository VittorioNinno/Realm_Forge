using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Eldritch Blast (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class EldritchBlast2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eldritch-blast");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eldritch-blast", "en"),
					Language = LanguageCode.En,
					Name = "Eldritch Blast",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You hurl a beam of crackling energy. Make a ranged spell attack against one creature or object in range. On a hit, the target takes 1d10 Force damage.",
					HigherLevels = "The spell creates two beams at level 5, three beams at level 11, and four beams at level 17. You can direct the beams at the same target or at different ones. Make a separate attack roll for each beam."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eldritch-blast", "it"),
					Language = LanguageCode.It,
					Name = "Deflagrazione Occulta",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia un raggio di energia crepitante. Effettua un attacco con incantesimo a distanza contro una creatura o un oggetto entro gittata. Se colpisce, il bersaglio subisce 1d10 danni da forza.",
					HigherLevels = "L'incantesimo crea due raggi al 5° livello, tre raggi all'11° livello e quattro raggi al 17° livello. L'incantatore può dirigere i raggi contro lo stesso bersaglio o contro bersagli diversi, effettuando un tiro per colpire separato per ogni raggio."
				}
			}
		};
	}
}
