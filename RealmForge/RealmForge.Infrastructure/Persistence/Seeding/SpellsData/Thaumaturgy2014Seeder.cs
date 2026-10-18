using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thaumaturgy (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thaumaturgy2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thaumaturgy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thaumaturgy", "en"),
					Language = LanguageCode.En,
					Name = "Thaumaturgy",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Up to 1 minute",
					MaterialComponent = null,
					Description = "You manifest a minor wonder, a sign of supernatural power, within range. You create one of the following magical effects within range.\n\n- Your voice booms up to three times as loud as normal for 1 minute.\n\n- You cause flames to flicker, brighten, dim, or change color for 1 minute.\n\n- You cause harmless tremors in the ground for 1 minute.\n\n- You create an instantaneous sound that originates from a point of your choice within range, such as a rumble of thunder, the cry of a raven, or ominous whispers.\n\n- You instantaneously cause an unlocked door or window to fly open or slam shut.\n\n- You alter the appearance of your eyes for 1 minute.\n\nIf you cast this spell multiple times, you can have up to three of its 1-minute effects active at a time, and you can dismiss such an effect as an action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thaumaturgy", "it"),
					Language = LanguageCode.It,
					Name = "Taumaturgia",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore manifesta entro gittata un piccolo prodigio, un segno di potere soprannaturale. Crea uno degli effetti magici seguenti entro gittata.\n\n- La sua voce rimbomba con un volume fino a tre volte superiore al normale per 1 minuto.\n\n- Fa tremolare, ravvivare, affievolire o cambiare colore alle fiamme per 1 minuto.\n\n- Provoca tremori innocui nel terreno per 1 minuto.\n\n- Crea un suono istantaneo che proviene da un punto entro gittata a sua scelta, come il rombo di un tuono, il gracchiare di un corvo o sussurri minacciosi.\n\n- Fa spalancare o sbattere istantaneamente una porta o una finestra non chiusa a chiave.\n\n- Altera l'aspetto dei propri occhi per 1 minuto.\n\nSe l'incantatore lancia questo incantesimo più volte, può avere attivi contemporaneamente fino a tre dei suoi effetti da 1 minuto, e può congedare uno di questi effetti come azione.",
					HigherLevels = null
				}
			}
		};
	}
}
