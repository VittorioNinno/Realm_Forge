using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Phantom Steed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PhantomSteed2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantom-steed");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantom-steed", "en"),
					Language = LanguageCode.En,
					Name = "Phantom Steed",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "A Large quasi-real, horselike creature appears on the ground in an unoccupied space of your choice within range. You decide the creature's appearance, but it is equipped with a saddle, bit, and bridle. Any of the equipment created by the spell vanishes in a puff of smoke if it is carried more than 10 feet away from the steed.\n\nFor the duration, you or a creature you choose can ride the steed. The creature uses the statistics for a riding horse, except it has a speed of 100 feet and can travel 10 miles in an hour, or 13 miles at a fast pace. When the spell ends, the steed gradually fades, giving the rider 1 minute to dismount. The spell ends if you use an action to dismiss it or if the steed takes any damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantom-steed", "it"),
					Language = LanguageCode.It,
					Name = "Destriero Fantomatico",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Una creatura quasi reale di taglia Grande, simile a un cavallo, compare sul terreno in uno spazio libero entro gittata scelto dall'incantatore. L'incantatore decide l'aspetto della creatura, che è comunque dotata di sella, morso e briglie. Qualsiasi elemento dell'equipaggiamento creato dall'incantesimo svanisce in uno sbuffo di fumo se viene portato a più di 3 metri dalla cavalcatura.\n\nPer la durata, l'incantatore o una creatura da lui scelta può cavalcare il destriero. La creatura usa le statistiche di un cavallo da galoppo, ma ha velocità 30 metri e può percorrere 15 km in un'ora, o 19,5 km a passo veloce. Quando l'incantesimo termina, la cavalcatura svanisce gradualmente, lasciando al cavaliere 1 minuto per smontare. L'incantesimo termina se l'incantatore usa un'azione per congedarlo o se la cavalcatura subisce danni.",
					HigherLevels = null
				}
			}
		};
	}
}
