using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cloudkill (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Cloudkill2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloudkill");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloudkill", "en"),
					Language = LanguageCode.En,
					Name = "Cloudkill",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You create a 20-foot-radius sphere of poisonous, yellow-green fog centered on a point you choose within range. The fog spreads around corners. It lasts for the duration or until strong wind disperses the fog, ending the spell. Its area is heavily obscured.\n\nWhen a creature enters the spell's area for the first time on a turn or starts its turn there, that creature must make a Constitution saving throw. The creature takes 5d8 poison damage on a failed save, or half as much damage on a successful one. Creatures are affected even if they hold their breath or don't need to breathe.\n\nThe fog moves 10 feet away from you at the start of each of your turns, rolling along the surface of the ground. The vapors, being heavier than air, sink to the lowest level of the land, even pouring down openings.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d8 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "cloudkill", "it"),
					Language = LanguageCode.It,
					Name = "Nube Mortale",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore crea una sfera di nebbia velenosa giallo-verdastra del raggio di 6 metri, centrata su un punto entro gittata da lui scelto. La nebbia si propaga dietro gli angoli. Dura per la durata dell'incantesimo o finché un vento forte non la disperde, ponendo fine all'incantesimo. La sua area è pesantemente oscurata.\n\nQuando una creatura entra nell'area dell'incantesimo per la prima volta in un turno o vi inizia il proprio turno, deve effettuare un tiro salvezza su Costituzione. La creatura subisce 5d8 danni da veleno se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Le creature sono influenzate anche se trattengono il respiro o non hanno bisogno di respirare.\n\nAll'inizio di ogni turno dell'incantatore, la nebbia si allontana da lui di 3 metri, rotolando sulla superficie del terreno. Essendo più pesanti dell'aria, i vapori scendono verso il punto più basso del terreno, riversandosi perfino nelle aperture.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
