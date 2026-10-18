using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wind Walk (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WindWalk2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-walk");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-walk", "en"),
					Language = LanguageCode.En,
					Name = "Wind Walk",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "fire and holy water",
					Description = "You and up to ten willing creatures you can see within range assume a gaseous form for the duration, appearing as wisps of cloud. While in this cloud form, a creature has a flying speed of 300 feet and has resistance to damage from nonmagical weapons. The only actions a creature can take in this form are the Dash action or to revert to its normal form. Reverting takes 1 minute, during which time a creature is incapacitated and can't move. Until the spell ends, a creature can revert to cloud form, which also requires the 1-minute transformation.\n\nIf a creature is in cloud form and flying when the effect ends, the creature descends 60 feet per round for 1 minute until it lands, which it does safely. If it can't land after 1 minute, the creature falls the remaining distance.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-walk", "it"),
					Language = LanguageCode.It,
					Name = "Camminare nel Vento",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "fuoco e acqua santa",
					Description = "L'incantatore e fino a dieci creature consenzienti entro gittata, che egli sia in grado di vedere, assumono per la durata una forma gassosa, apparendo come sbuffi di nuvola. Finché si trova in questa forma di nuvola, una creatura ha una velocità di volare di 90 metri e ha resistenza ai danni inflitti dalle armi non magiche. Le uniche azioni che una creatura può compiere in questa forma sono l'azione di Scatto o tornare alla sua forma normale. Tornare alla forma normale richiede 1 minuto, durante il quale la creatura è incapacitata e non può muoversi. Finché l'incantesimo non termina, una creatura può tornare alla forma di nuvola, il che richiede anch'esso una trasformazione di 1 minuto.\n\nSe una creatura si trova in forma di nuvola e sta volando quando l'effetto termina, scende di 18 metri per round per 1 minuto finché non atterra, cosa che fa senza subire danni. Se non riesce ad atterrare entro 1 minuto, la creatura cade per la distanza rimanente.",
					HigherLevels = null
				}
			}
		};
	}
}
