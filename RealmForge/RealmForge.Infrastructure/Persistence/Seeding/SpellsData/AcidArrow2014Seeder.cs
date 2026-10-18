using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Acid Arrow (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AcidArrow2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "acid-arrow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "acid-arrow", "en"),
					Language = LanguageCode.En,
					Name = "Acid Arrow",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Instantaneous",
					MaterialComponent = "powdered rhubarb leaf and an adder's stomach",
					Description = "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid. Make a ranged spell attack against the target. On a hit, the target takes 4d4 acid damage immediately and 2d4 acid damage at the end of its next turn. On a miss, the arrow splashes the target with acid for half as much of the initial damage and no damage at the end of its next turn.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage (both initial and later) increases by 1d4 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "acid-arrow", "it"),
					Language = LanguageCode.It,
					Name = "Freccia Acida",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Istantanea",
					MaterialComponent = "una foglia di rabarbaro in polvere e lo stomaco di una vipera",
					Description = "Una freccia verde e scintillante sfreccia verso un bersaglio entro gittata ed esplode in uno spruzzo di acido. L'incantatore effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce immediatamente 4d4 danni da acido e altri 2d4 danni da acido alla fine del suo turno successivo. Se manca, la freccia schizza il bersaglio di acido infliggendo la metà dei danni iniziali e nessun danno alla fine del turno successivo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni (sia quelli iniziali sia quelli successivi) aumentano di 1d4 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
