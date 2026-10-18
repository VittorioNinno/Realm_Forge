using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hideous Laughter (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HideousLaughter2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hideous-laughter");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hideous-laughter", "en"),
					Language = LanguageCode.En,
					Name = "Hideous Laughter",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tart and a feather",
					Description = "One creature of your choice that you can see within range makes a Wisdom saving throw. On a failed save, it has the Prone and Incapacitated conditions for the duration. During that time, it laughs uncontrollably if it's capable of laughter, and it can't end the Prone condition on itself.\n\nAt the end of each of its turns and each time it takes damage, it makes another Wisdom saving throw. The target has Advantage on the save if the save is triggered by damage. On a successful save, the spell ends.",
					HigherLevels = "You can target one additional creature for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hideous-laughter", "it"),
					Language = LanguageCode.It,
					Name = "Risata Incontenibile",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una crostatina e una piuma",
					Description = "Una creatura a scelta dell'incantatore entro gittata, che egli è in grado di vedere, effettua un tiro salvezza su Saggezza. Se lo fallisce, è prona e incapacitata per la durata. Durante quel periodo, ride in modo incontrollabile, se è capace di ridere, e non può porre fine alla condizione prono su di sé.\n\nAlla fine di ogni suo turno e ogni volta che subisce danni, effettua un altro tiro salvezza su Saggezza. Il bersaglio dispone di vantaggio al tiro salvezza se questo è provocato da danni. Se lo supera, l'incantesimo termina.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
