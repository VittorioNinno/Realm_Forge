using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Insect Plague (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InsectPlague2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "insect-plague");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "insect-plague", "en"),
					Language = LanguageCode.En,
					Name = "Insect Plague",
					CastingTime = "Action",
					Range = "300 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a locust",
					Description = "Swarming locusts fill a 20-foot-radius Sphere centered on a point you choose within range. The Sphere remains for the duration, and its area is Lightly Obscured and Difficult Terrain.\n\nWhen the swarm appears, each creature in it makes a Constitution saving throw, taking 4d10 Piercing damage on a failed save or half as much damage on a successful one. A creature also makes this save when it enters the spell's area for the first time on a turn or ends its turn there. A creature makes this save only once per turn.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "insect-plague", "it"),
					Language = LanguageCode.It,
					Name = "Piaga degli Insetti",
					CastingTime = "Azione",
					Range = "90 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una locusta",
					Description = "Sciami di locuste riempiono una sfera del raggio di 6 metri centrata su un punto entro gittata a scelta dell'incantatore. La sfera permane per la durata e la sua area è leggermente oscurata e costituisce terreno difficile.\n\nQuando lo sciame compare, ogni creatura al suo interno effettua un tiro salvezza su Costituzione, subendo 4d10 danni perforanti se lo fallisce, o la metà di quei danni se lo supera. Una creatura effettua questo tiro salvezza anche quando entra nell'area dell'incantesimo per la prima volta in un turno o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
