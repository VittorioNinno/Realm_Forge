using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wind Walk (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WindWalk2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wind-walk");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wind-walk", "en"),
					Language = LanguageCode.En,
					Name = "Wind Walk",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a candle",
					Description = "You and up to ten willing creatures of your choice within range assume gaseous forms for the duration, appearing as wisps of cloud. While in this cloud form, a target has a Fly Speed of 300 feet and can hover; it has Immunity to the Prone condition; and it has Resistance to Bludgeoning, Piercing, and Slashing damage. The only actions a target can take in this form are the Dash action or a Magic action to begin reverting to its normal form. Reverting takes 1 minute, during which the target has the Stunned condition. Until the spell ends, the target can revert to cloud form, which also requires a Magic action followed by a 1-minute transformation.\n\nIf a target is in cloud form and flying when the effect ends, the target descends 60 feet per round for 1 minute until it lands, which it does safely. If it can't land after 1 minute, it falls the remaining distance.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wind-walk", "it"),
					Language = LanguageCode.It,
					Name = "Camminare nel Vento",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "una candela",
					Description = "L'incantatore e fino a dieci creature consenzienti a sua scelta entro gittata assumono forme gassose per la durata, apparendo come sbuffi di nuvola. Finché è in questa forma di nuvola, un bersaglio ha una velocità di volo di 90 metri e può fluttuare, è immune alla condizione prono e ha resistenza ai danni contundenti, perforanti e taglienti. Le sole azioni che un bersaglio può effettuare in questa forma sono l'azione di Scatto o un'azione di Magia per iniziare a tornare alla sua forma normale. Il ritorno richiede 1 minuto, durante il quale il bersaglio è stordito. Finché l'incantesimo non termina, il bersaglio può tornare alla forma di nuvola, il che richiede a sua volta un'azione di Magia seguita da una trasformazione di 1 minuto.\n\nSe un bersaglio è in forma di nuvola e sta volando quando l'effetto termina, scende di 18 metri per round per 1 minuto finché non atterra, cosa che fa senza danni. Se non riesce ad atterrare entro 1 minuto, cade per la distanza rimanente.",
					HigherLevels = null
				}
			}
		};
	}
}
