using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Druidcraft (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Druidcraft2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "druidcraft");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "druidcraft", "en"),
					Language = LanguageCode.En,
					Name = "Druidcraft",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Whispering to the spirits of nature, you create one of the following effects within range.\n\n***Weather Sensor.*** You create a Tiny, harmless sensory effect that predicts what the weather will be at your location for the next 24 hours. The effect might manifest as a golden orb for clear skies, a cloud for rain, falling snowflakes for snow, and so on. This effect persists for 1 round.\n\n***Bloom.*** You instantly make a flower blossom, a seed pod open, or a leaf bud bloom.\n\n***Sensory Effect.*** You create a harmless sensory effect, such as falling leaves, spectral dancing fairies, a gentle breeze, the sound of an animal, or the faint odor of skunk. The effect must fit in a 5-foot Cube.\n\n***Fire Play.*** You light or snuff out a candle, a torch, or a campfire.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "druidcraft", "it"),
					Language = LanguageCode.It,
					Name = "Artificio Druidico",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Sussurrando agli spiriti della natura, l'incantatore crea uno degli effetti seguenti entro gittata.\n\n***Sensore Meteorologico.*** L'incantatore crea un effetto sensoriale innocuo e Minuscolo che prevede il tempo atmosferico nel luogo in cui si trova per le 24 ore successive. L'effetto potrebbe manifestarsi come un globo dorato per il cielo sereno, una nuvola per la pioggia, fiocchi di neve che cadono per la neve e così via. Questo effetto persiste per 1 round.\n\n***Fioritura.*** L'incantatore fa sbocciare istantaneamente un fiore, aprire un baccello di semi o schiudere una gemma fogliare.\n\n***Effetto Sensoriale.*** L'incantatore crea un effetto sensoriale innocuo, come foglie che cadono, fate spettrali danzanti, una brezza leggera, il verso di un animale o il debole odore di una moffetta. L'effetto deve rientrare in un cubo con spigolo di 1,5 metri.\n\n***Giocare col Fuoco.*** L'incantatore accende o spegne una candela, una torcia o un falò.",
					HigherLevels = null
				}
			}
		};
	}
}
