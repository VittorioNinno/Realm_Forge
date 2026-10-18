using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Acid Arrow (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AcidArrow2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-arrow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-arrow", "en"),
					Language = LanguageCode.En,
					Name = "Acid Arrow",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Instantaneous",
					MaterialComponent = "powdered rhubarb leaf",
					Description = "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid. Make a ranged spell attack against the target. On a hit, the target takes 4d4 Acid damage and 2d4 Acid damage at the end of its next turn. On a miss, the arrow splashes the target with acid for half as much of the initial damage only.",
					HigherLevels = "The damage (both initial and later) increases by 1d4 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-arrow", "it"),
					Language = LanguageCode.It,
					Name = "Freccia Acida",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Istantanea",
					MaterialComponent = "foglia di rabarbaro in polvere",
					Description = "Una freccia verde e scintillante sfreccia verso un bersaglio entro gittata ed esplode in uno spruzzo di acido. L'incantatore effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 4d4 danni da acido e altri 2d4 danni da acido alla fine del suo turno successivo. Se manca, la freccia schizza il bersaglio di acido infliggendo soltanto la metà dei danni iniziali.",
					HigherLevels = "I danni (sia quelli iniziali sia quelli successivi) aumentano di 1d4 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
