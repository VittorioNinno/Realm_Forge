using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Synaptic Static (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SynapticStatic2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "synaptic-static");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "synaptic-static", "en"),
					Language = LanguageCode.En,
					Name = "Synaptic Static",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You set off a pulse of psychic noise at a point within range. Every creature in a 20-foot-radius Sphere around that point attempts an Intelligence saving throw, suffering 8d6 Psychic damage if it fails or half that much if it succeeds.\n\nOn a failure, the creature's thoughts are also muddled for 1 minute. While muddled, it subtracts 1d6 from its attack rolls and ability checks, as well as from the Constitution saves it makes to keep Concentration. When each of its turns ends, it attempts another Intelligence saving throw, clearing its mind on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "synaptic-static", "it"),
					Language = LanguageCode.It,
					Name = "Scossa Sinaptica",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore fa scattare un impulso di rumore psichico in un punto entro gittata. Ogni creatura in una sfera di 6 metri di raggio attorno a quel punto tenta un tiro salvezza su Intelligenza e subisce 8d6 danni psichici se fallisce, o metà di quei danni se riesce.\n\nIn caso di fallimento, i pensieri della creatura sono anche annebbiati per 1 minuto. Finché è annebbiata, sottrae 1d6 ai propri tiri per colpire e alle prove di caratteristica, oltre che ai tiri salvezza su Costituzione effettuati per mantenere la concentrazione. Al termine di ogni suo turno tenta un altro tiro salvezza su Intelligenza, e un successo le schiarisce la mente.",
					HigherLevels = null
				}
			}
		};
	}
}
