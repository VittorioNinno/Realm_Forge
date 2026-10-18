using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prestidigitation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Prestidigitation2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prestidigitation");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prestidigitation", "en"),
					Language = LanguageCode.En,
					Name = "Prestidigitation",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "Up to 1 hour",
					MaterialComponent = null,
					Description = "This spell is a minor magical trick that novice spellcasters use for practice. You create one of the following magical effects within range:\n\n- You create an instantaneous, harmless sensory effect, such as a shower of sparks, a puff of wind, faint musical notes, or an odd odor.\n\n- You instantaneously light or snuff out a candle, a torch, or a small campfire.\n\n- You instantaneously clean or soil an object no larger than 1 cubic foot.\n\n- You chill, warm, or flavor up to 1 cubic foot of nonliving material for 1 hour.\n\n- You make a color, a small mark, or a symbol appear on an object or a surface for 1 hour.\n\n- You create a nonmagical trinket or an illusory image that can fit in your hand and that lasts until the end of your next turn.\n\nIf you cast this spell multiple times, you can have up to three of its non-instantaneous effects active at a time, and you can dismiss such an effect as an action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prestidigitation", "it"),
					Language = LanguageCode.It,
					Name = "Prestidigitazione",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "Fino a 1 ora",
					MaterialComponent = null,
					Description = "Questo incantesimo è un piccolo trucco magico che gli incantatori alle prime armi usano per esercitarsi. L'incantatore crea uno degli effetti magici seguenti entro gittata:\n\n- Crea un effetto sensoriale istantaneo e innocuo, come una pioggia di scintille, uno sbuffo di vento, deboli note musicali o un odore strano.\n\n- Accende o spegne istantaneamente una candela, una torcia o un piccolo fuoco da campo.\n\n- Pulisce o sporca istantaneamente un oggetto le cui dimensioni non superano un cubo con spigolo di 30 cm.\n\n- Raffredda, riscalda o insaporisce materiale non vivente, fino al volume di un cubo con spigolo di 30 cm, per 1 ora.\n\n- Fa comparire un colore, un piccolo segno o un simbolo su un oggetto o su una superficie per 1 ora.\n\n- Crea un ninnolo non magico o un'immagine illusoria che può essere contenuto in una mano e che dura fino alla fine del suo turno successivo.\n\nSe l'incantatore lancia questo incantesimo più volte, può avere attivi contemporaneamente fino a tre dei suoi effetti non istantanei, e può congedare uno di questi effetti come azione.",
					HigherLevels = null
				}
			}
		};
	}
}
