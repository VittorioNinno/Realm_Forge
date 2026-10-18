using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Entangle (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Entangle2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "entangle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "entangle", "en"),
					Language = LanguageCode.En,
					Name = "Entangle",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Grasping plants sprout from the ground in a 20-foot square within range. For the duration, these plants turn the ground in the area into Difficult Terrain. They disappear when the spell ends.\n\nEach creature (other than you) in the area when you cast the spell must succeed on a Strength saving throw or have the Restrained condition until the spell ends. A Restrained creature can take an action to make a Strength (Athletics) check against your spell save DC. On a success, it frees itself from the grasping plants and is no longer Restrained by them.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "entangle", "it"),
					Language = LanguageCode.It,
					Name = "Intralciare",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Piante avvinghianti spuntano dal terreno in un quadrato di 6 metri di lato entro gittata. Per la durata, queste piante trasformano il terreno nell'area in terreno difficile. Scompaiono quando l'incantesimo termina.\n\nOgni creatura (tranne l'incantatore) che si trova nell'area quando l'incantesimo viene lanciato deve superare un tiro salvezza su Forza, altrimenti è trattenuta finché l'incantesimo non termina. Una creatura trattenuta può effettuare un'azione per compiere una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, si libera dalle piante avvinghianti e non è più trattenuta da esse.",
					HigherLevels = null
				}
			}
		};
	}
}
