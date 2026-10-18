using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cloudkill (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Cloudkill2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloudkill");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloudkill", "en"),
					Language = LanguageCode.En,
					Name = "Cloudkill",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You create a 20-foot-radius Sphere of yellow-green fog centered on a point within range. The fog lasts for the duration or until strong wind (such as the one created by *Gust of Wind*) disperses it, ending the spell. Its area is Heavily Obscured.\n\nEach creature in the Sphere makes a Constitution saving throw, taking 5d8 Poison damage on a failed save or half as much damage on a successful one. A creature must also make this save when the Sphere moves into its space and when it enters the Sphere or ends its turn there. A creature makes this save only once per turn.\n\nThe Sphere moves 10 feet away from you at the start of each of your turns.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloudkill", "it"),
					Language = LanguageCode.It,
					Name = "Nube Mortale",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore crea una sfera di nebbia giallo-verdastra del raggio di 6 metri, centrata su un punto entro gittata. La nebbia permane per la durata o finché un vento forte (come quello creato da *folata di vento*) non la disperde, ponendo fine all'incantesimo. La sua area è pesantemente oscurata.\n\nOgni creatura nella sfera effettua un tiro salvezza su Costituzione, subendo 5d8 danni da veleno se lo fallisce, o la metà di quei danni se lo supera. Una creatura deve effettuare questo tiro salvezza anche quando la sfera si sposta nel suo spazio e quando entra nella sfera o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno.\n\nLa sfera si allontana di 3 metri dall'incantatore all'inizio di ogni suo turno.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
