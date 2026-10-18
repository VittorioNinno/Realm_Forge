using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Storm of Radiance (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class StormOfRadiance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-radiance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-radiance", "en"),
					Language = LanguageCode.En,
					Name = "Storm of Radiance",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of phosphorus",
					Description = "Choose a point within range that you can see. For the duration, a Cylinder 10 feet in radius and 40 feet tall centered on it churns with blinding flares and deafening thunderclaps. Any creature inside the Cylinder is Blinded and Deafened, and it can't cast a spell that needs a Verbal component.\n\nEach creature in the storm when it forms attempts a Constitution saving throw, suffering 2d10 Radiant damage plus 2d10 Thunder damage if it fails, or half of each if it succeeds. A creature repeats this save when it first enters the Cylinder on a turn and when it finishes a turn there, but never more than once per turn.",
					HigherLevels = "For each slot level above 5, add 1d10 to the Radiant damage and 1d10 to the Thunder damage."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "storm-of-radiance", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta Radiosa",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di fosforo",
					Description = "L'incantatore sceglie un punto entro gittata che è in grado di vedere. Per la durata, un cilindro di 3 metri di raggio e 12 metri di altezza centrato su di esso ribolle di bagliori accecanti e tuoni assordanti. Ogni creatura all'interno del cilindro è accecata e assordata, e non può lanciare un incantesimo che richieda una componente verbale.\n\nOgni creatura che si trova nella tempesta quando questa si forma tenta un tiro salvezza su Costituzione e subisce 2d10 danni radiosi più 2d10 danni da tuono se fallisce, o metà di ciascuno se riesce. Una creatura ripete questo tiro salvezza la prima volta in un turno in cui entra nel cilindro e quando vi conclude un turno, ma mai più di una volta per turno.",
					HigherLevels = "Per ogni livello dello slot oltre il 5°, aggiungere 1d10 ai danni radiosi e 1d10 ai danni da tuono."
				}
			}
		};
	}
}
