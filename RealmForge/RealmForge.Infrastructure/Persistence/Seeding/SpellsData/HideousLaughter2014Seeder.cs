using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hideous Laughter (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HideousLaughter2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hideous-laughter");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hideous-laughter", "en"),
					Language = LanguageCode.En,
					Name = "Hideous Laughter",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "tiny tarts and a feather that is waved in the air",
					Description = "A creature of your choice that you can see within range perceives everything as hilariously funny and falls into fits of laughter if this spell affects it. The target must succeed on a Wisdom saving throw or fall prone, becoming incapacitated and unable to stand up for the duration. A creature with an Intelligence score of 4 or less isn't affected.\n\nAt the end of each of its turns, and each time it takes damage, the target can make another Wisdom saving throw. The target has advantage on the saving throw if it's triggered by damage. On a success, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hideous-laughter", "it"),
					Language = LanguageCode.It,
					Name = "Risata Incontenibile",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "delle minuscole crostate e una piuma da agitare in aria",
					Description = "Una creatura a scelta dell'incantatore entro gittata, che egli sia in grado di vedere, trova tutto esilarante e, se l'incantesimo ha effetto, scoppia in un accesso di risa. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti cade prono, diventando incapacitato e incapace di rialzarsi per la durata. Una creatura con punteggio di Intelligenza pari o inferiore a 4 non è influenzata.\n\nAlla fine di ogni suo turno, e ogni volta che subisce danni, il bersaglio può effettuare un altro tiro salvezza su Saggezza. Se il tiro salvezza è stato causato dai danni, il bersaglio dispone di vantaggio. Se lo supera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
