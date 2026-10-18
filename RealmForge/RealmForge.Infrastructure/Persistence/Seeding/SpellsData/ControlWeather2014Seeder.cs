using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Control Weather (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ControlWeather2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-weather");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-weather", "en"),
					Language = LanguageCode.En,
					Name = "Control Weather",
					CastingTime = "10 minutes",
					Range = "Self (5-mile radius)",
					Duration = "Concentration, up to 8 hours",
					MaterialComponent = "burning incense and bits of earth and wood mixed in water",
					Description = "You take control of the weather within 5 miles of you for the duration. You must be outdoors to cast this spell. Moving to a place where you don't have a clear path to the sky ends the spell early.\n\nWhen you cast the spell, you change the current weather conditions, which are determined by the GM based on the climate and season. You can change precipitation, temperature, and wind. It takes 1d4 x 10 minutes for the new conditions to take effect. Once they do so, you can change the conditions again. When the spell ends, the weather gradually returns to normal.\n\nWhen you change the weather conditions, find a current condition on the following tables and change its stage by one, up or down. When changing the wind, you can change its direction.\n\n##### Precipitation\n\n| Stage | Condition |\n|---|---|\n| 1 | Clear |\n| 2 | Light clouds |\n| 3 | Overcast or ground fog |\n| 4 | Rain, hail, or snow |\n| 5 | Torrential rain, driving hail, or blizzard |\n\n##### Temperature\n\n| Stage | Condition |\n|---|---|\n| 1 | Unbearable heat |\n| 2 | Hot |\n| 3 | Warm |\n| 4 | Cool |\n| 5 | Cold |\n| 6 | Arctic cold |\n\n##### Wind\n\n| Stage | Condition |\n|---|---|\n| 1 | Calm |\n| 2 | Moderate wind |\n| 3 | Strong wind |\n| 4 | Gale |\n| 5 | Storm |",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-weather", "it"),
					Language = LanguageCode.It,
					Name = "Controllare Tempo Atmosferico",
					CastingTime = "10 minuti",
					Range = "Incantatore (raggio di 7,5 km)",
					Duration = "Concentrazione, fino a 8 ore",
					MaterialComponent = "incenso acceso e frammenti di terra e di legno mescolati nell'acqua",
					Description = "Per la durata, l'incantatore assume il controllo del clima entro 7,5 km da lui. Per lanciare questo incantesimo deve trovarsi all'aperto. Spostarsi in un luogo da cui non abbia libera visuale del cielo pone fine prematuramente all'incantesimo.\n\nQuando lancia l'incantesimo, l'incantatore modifica le condizioni climatiche attuali, determinate dal DM in base al clima e alla stagione. Può modificare le precipitazioni, la temperatura e il vento. Le nuove condizioni impiegano 1d4 × 10 minuti per manifestarsi. Una volta manifestate, l'incantatore può modificarle di nuovo. Quando l'incantesimo termina, il clima torna gradualmente alla normalità.\n\nQuando modifica le condizioni climatiche, l'incantatore individua una condizione attuale nelle tabelle seguenti e ne sposta lo stadio di un grado, verso l'alto o verso il basso. Quando modifica il vento, può cambiarne la direzione.\n\n##### Precipitazioni\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Sereno |\n| 2 | Nuvole sparse |\n| 3 | Cielo coperto o nebbia al suolo |\n| 4 | Pioggia, grandine o neve |\n| 5 | Pioggia torrenziale, grandinata violenta o bufera di neve |\n\n##### Temperatura\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Caldo insopportabile |\n| 2 | Caldo |\n| 3 | Tiepido |\n| 4 | Fresco |\n| 5 | Freddo |\n| 6 | Freddo artico |\n\n##### Vento\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Calma |\n| 2 | Vento moderato |\n| 3 | Vento forte |\n| 4 | Burrasca |\n| 5 | Tempesta |",
					HigherLevels = null
				}
			}
		};
	}
}
