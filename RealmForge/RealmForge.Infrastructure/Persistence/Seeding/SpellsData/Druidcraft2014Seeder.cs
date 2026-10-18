using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Druidcraft (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Druidcraft2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "druidcraft");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "druidcraft", "en"),
					Language = LanguageCode.En,
					Name = "Druidcraft",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Whispering to the spirits of nature, you create one of the following effects within range:\n\n- You create a tiny, harmless sensory effect that predicts what the weather will be at your location for the next 24 hours. The effect might manifest as a golden orb for clear skies, a cloud for rain, falling snowflakes for snow, and so on. This effect persists for 1 round.\n\n- You instantly make a flower bloom, a seed pod open, or a leaf bud bloom.\n\n- You create an instantaneous, harmless sensory effect, such as falling leaves, a puff of wind, the sound of a small animal, or the faint odor of skunk. The effect must fit in a 5-foot cube.\n\n- You instantly light or snuff out a candle, a torch, or a small campfire.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "druidcraft", "it"),
					Language = LanguageCode.It,
					Name = "Artificio Druidico",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Sussurrando agli spiriti della natura, l'incantatore crea uno degli effetti seguenti entro gittata:\n\n- Crea un minuscolo effetto sensoriale innocuo che predice quale sarà il clima nel luogo in cui si trova nelle 24 ore successive. L'effetto potrebbe manifestarsi come un globo dorato per il cielo sereno, una nuvola per la pioggia, fiocchi di neve che cadono per la neve e così via. Questo effetto persiste per 1 round.\n\n- Fa sbocciare all'istante un fiore, aprire un baccello o schiudere una gemma fogliare.\n\n- Crea un effetto sensoriale istantaneo e innocuo, come foglie che cadono, uno sbuffo di vento, il verso di un piccolo animale o un debole odore di puzzola. L'effetto deve essere contenuto in un cubo con spigolo di 1,5 metri.\n\n- Accende o spegne all'istante una candela, una torcia o un piccolo fuoco da campo.",
					HigherLevels = null
				}
			}
		};
	}
}
