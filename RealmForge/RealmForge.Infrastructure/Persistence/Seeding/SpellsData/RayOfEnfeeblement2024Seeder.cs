using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ray of Enfeeblement (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RayOfEnfeeblement2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-enfeeblement");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-enfeeblement", "en"),
					Language = LanguageCode.En,
					Name = "Ray of Enfeeblement",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A beam of enervating energy shoots from you toward a creature within range. The target must make a Constitution saving throw. On a successful save, the target has Disadvantage on the next attack roll it makes until the start of your next turn.\n\nOn a failed save, the target has Disadvantage on Strength-based D20 Tests for the duration. During that time, it also subtracts 1d8 from all its damage rolls. The target repeats the save at the end of each of its turns, ending the spell on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ray-of-enfeeblement", "it"),
					Language = LanguageCode.It,
					Name = "Raggio di Affaticamento",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un raggio di energia debilitante scaturisce dall'incantatore verso una creatura entro gittata. Il bersaglio deve effettuare un tiro salvezza su Costituzione. Se lo supera, il bersaglio subisce svantaggio al successivo tiro per colpire che effettua prima dell'inizio del turno successivo dell'incantatore.\n\nSe lo fallisce, il bersaglio subisce svantaggio alle prove con d20 basate sulla Forza per la durata. Durante quel periodo, sottrae inoltre 1d8 a tutti i suoi tiri per i danni. Il bersaglio ripete il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
