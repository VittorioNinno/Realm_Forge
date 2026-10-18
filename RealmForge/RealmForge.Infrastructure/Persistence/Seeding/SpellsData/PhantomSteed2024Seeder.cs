using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Phantom Steed (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PhantomSteed2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantom-steed");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantom-steed", "en"),
					Language = LanguageCode.En,
					Name = "Phantom Steed",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "A Large, quasi-real, horselike creature appears on the ground in an unoccupied space of your choice within range. You decide the creature's appearance, and it is equipped with a saddle, bit, and bridle. Any of the equipment created by the spell vanishes in a puff of smoke if it is carried more than 10 feet away from the steed.\n\nFor the duration, you or a creature you choose can ride the steed. The steed uses the Riding Horse stat block (see \"Monsters\"), except it has a Speed of 100 feet and can travel 13 miles in an hour. When the spell ends, the steed gradually fades, giving the rider 1 minute to dismount. The spell ends early if the steed takes any damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantom-steed", "it"),
					Language = LanguageCode.It,
					Name = "Destriero Fantomatico",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Una creatura Grande, semireale e simile a un cavallo compare sul terreno in uno spazio libero entro gittata a scelta dell'incantatore. L'incantatore decide l'aspetto della creatura, che è equipaggiata con sella, morso e briglie. Qualsiasi elemento dell'equipaggiamento creato dall'incantesimo svanisce in uno sbuffo di fumo se viene portato a più di 3 metri di distanza dal destriero.\n\nPer la durata, l'incantatore o una creatura a sua scelta può cavalcare il destriero. Il destriero usa la scheda delle statistiche del **cavallo da galoppo** (vedi il capitolo \"Mostri\" dell'SRD), tranne per il fatto che ha una velocità di 30 metri e può percorrere 19,5 km in un'ora. Quando l'incantesimo termina, il destriero svanisce gradualmente, concedendo al cavaliere 1 minuto per smontare. L'incantesimo termina prima del tempo se il destriero subisce danni.",
					HigherLevels = null
				}
			}
		};
	}
}
