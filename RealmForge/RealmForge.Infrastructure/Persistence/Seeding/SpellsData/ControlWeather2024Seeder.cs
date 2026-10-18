using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Control Weather (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ControlWeather2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-weather");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-weather", "en"),
					Language = LanguageCode.En,
					Name = "Control Weather",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Concentration, up to 8 hours",
					MaterialComponent = "burning incense",
					Description = "You take control of the weather within 5 miles of you for the duration. You must be outdoors to cast this spell, and it ends early if you go indoors.\n\nWhen you cast the spell, you change the current weather conditions, which are determined by the GM. You can change precipitation, temperature, and wind. It takes 1d4 × 10 minutes for the new conditions to take effect. Once they do so, you can change the conditions again. When the spell ends, the weather gradually returns to normal.\n\nWhen you change the weather conditions, find a current condition on the following tables and change its stage by one, up or down. When changing the wind, you can change its direction.\n\n**Precipitation**\n\n| Stage | Condition |\n|---|---|\n| 1 | Clear |\n| 2 | Light clouds |\n| 3 | Overcast or ground fog |\n| 4 | Rain, hail, or snow |\n| 5 | Torrential rain, driving hail, or blizzard |\n\n**Temperature**\n\n| Stage | Condition |\n|---|---|\n| 1 | Heat wave |\n| 2 | Hot |\n| 3 | Warm |\n| 4 | Cool |\n| 5 | Cold |\n| 6 | Freezing |\n\n**Wind**\n\n| Stage | Condition |\n|---|---|\n| 1 | Calm |\n| 2 | Moderate wind |\n| 3 | Strong wind |\n| 4 | Gale |\n| 5 | Storm |",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-weather", "it"),
					Language = LanguageCode.It,
					Name = "Controllare Tempo Atmosferico",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 8 ore",
					MaterialComponent = "incenso acceso",
					Description = "L'incantatore assume il controllo del tempo atmosferico entro 7,5 km da sé per la durata. Per lanciare questo incantesimo deve trovarsi all'aperto, e l'incantesimo termina prima del tempo se entra in un luogo chiuso.\n\nQuando lancia l'incantesimo, l'incantatore cambia le condizioni atmosferiche attuali, che sono determinate dal DM. Può cambiare le precipitazioni, la temperatura e il vento. Occorrono 1d4 × 10 minuti perché le nuove condizioni abbiano effetto. Una volta che ciò è avvenuto, l'incantatore può cambiarle di nuovo. Quando l'incantesimo termina, il tempo atmosferico torna gradualmente alla normalità.\n\nQuando cambia le condizioni atmosferiche, l'incantatore individua una condizione attuale nelle tabelle seguenti e ne cambia lo stadio di uno, in alto o in basso. Quando cambia il vento, può cambiarne la direzione.\n\n**Precipitazioni**\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Sereno |\n| 2 | Nuvole sparse |\n| 3 | Cielo coperto o nebbia bassa |\n| 4 | Pioggia, grandine o neve |\n| 5 | Pioggia torrenziale, grandinata violenta o bufera di neve |\n\n**Temperatura**\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Ondata di calore |\n| 2 | Caldo |\n| 3 | Tiepido |\n| 4 | Fresco |\n| 5 | Freddo |\n| 6 | Gelido |\n\n**Vento**\n\n| Stadio | Condizione |\n|---|---|\n| 1 | Calma |\n| 2 | Vento moderato |\n| 3 | Vento forte |\n| 4 | Burrasca |\n| 5 | Tempesta |",
					HigherLevels = null
				}
			}
		};
	}
}
