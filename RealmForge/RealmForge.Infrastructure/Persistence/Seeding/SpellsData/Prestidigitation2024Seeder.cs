using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prestidigitation (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Prestidigitation2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prestidigitation");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prestidigitation", "en"),
					Language = LanguageCode.En,
					Name = "Prestidigitation",
					CastingTime = "Action",
					Range = "10 feet",
					Duration = "Up to 1 hour",
					MaterialComponent = null,
					Description = "You create a magical effect within range. Choose the effect from the options below. If you cast this spell multiple times, you can have up to three of its non-instantaneous effects active at a time.\n\n***Sensory Effect.*** You create an instantaneous, harmless sensory effect, such as a shower of sparks, a puff of wind, faint musical notes, or an odd odor.\n\n***Fire Play.*** You instantaneously light or snuff out a candle, a torch, or a small campfire.\n\n***Clean or Soil.*** You instantaneously clean or soil an object no larger than 1 cubic foot.\n\n***Minor Sensation.*** You chill, warm, or flavor up to 1 cubic foot of nonliving material for 1 hour.\n\n***Magic Mark.*** You make a color, a small mark, or a symbol appear on an object or a surface for 1 hour.\n\n***Minor Creation.*** You create a nonmagical trinket or an illusory image that can fit in your hand. It lasts until the end of your next turn. A trinket can deal no damage and has no monetary worth.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prestidigitation", "it"),
					Language = LanguageCode.It,
					Name = "Prestidigitazione",
					CastingTime = "Azione",
					Range = "3 metri",
					Duration = "Fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore crea un effetto magico entro gittata, scegliendolo tra le opzioni seguenti. Se lancia questo incantesimo più volte, può avere attivi contemporaneamente fino a tre dei suoi effetti non istantanei.\n\n***Effetto Sensoriale.*** L'incantatore crea un effetto sensoriale innocuo e istantaneo, come una pioggia di scintille, uno sbuffo di vento, deboli note musicali o un odore bizzarro.\n\n***Giocare col Fuoco.*** L'incantatore accende o spegne istantaneamente una candela, una torcia o un piccolo falò.\n\n***Pulire o Sporcare.*** L'incantatore pulisce o sporca istantaneamente un oggetto non più grande di 27 decimetri cubi.\n\n***Sensazione Minore.*** L'incantatore raffredda, riscalda o insaporisce fino a 27 decimetri cubi di materiale non vivente per 1 ora.\n\n***Segno Magico.*** L'incantatore fa comparire un colore, un piccolo segno o un simbolo su un oggetto o su una superficie per 1 ora.\n\n***Creazione Minore.*** L'incantatore crea un ninnolo non magico o un'immagine illusoria che può stare nella sua mano. Permane fino alla fine del suo turno successivo. Un ninnolo non può infliggere danni e non ha alcun valore economico.",
					HigherLevels = null
				}
			}
		};
	}
}
