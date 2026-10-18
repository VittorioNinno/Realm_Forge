using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Control Water (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ControlWater2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-water");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-water", "en"),
					Language = LanguageCode.En,
					Name = "Control Water",
					CastingTime = "Action",
					Range = "300 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a mixture of water and dust",
					Description = "Until the spell ends, you control any water inside an area you choose that is a Cube up to 100 feet on a side, using one of the following effects. As a Magic action on your later turns, you can repeat the same effect or choose a different one.\n\n***Flood.*** You cause the water level of all standing water in the area to rise by as much as 20 feet. If you choose an area in a large body of water, you instead create a 20-foot tall wave that travels from one side of the area to the other and then crashes. Any Huge or smaller vehicles in the wave's path are carried with it to the other side. Any Huge or smaller vehicles struck by the wave have a 25 percent chance of capsizing.\n\nThe water level remains elevated until the spell ends or you choose a different effect. If this effect produced a wave, the wave repeats on the start of your next turn while the flood effect lasts.\n\n***Part Water.*** You part water in the area and create a trench. The trench extends across the spell's area, and the separated water forms a wall to either side. The trench remains until the spell ends or you choose a different effect. The water then slowly fills in the trench over the course of the next round until the normal water level is restored.\n\n***Redirect Flow.*** You cause flowing water in the area to move in a direction you choose, even if the water has to flow over obstacles, up walls, or in other unlikely directions. The water in the area moves as you direct it, but once it moves beyond the spell's area, it resumes its flow based on the terrain. The water continues to move in the direction you chose until the spell ends or you choose a different effect.\n\n***Whirlpool.*** You cause a whirlpool to form in the center of the area, which must be at least 50 feet square and 25 feet deep. The whirlpool lasts until you choose a different effect or the spell ends. The whirlpool is 5 feet wide at the base, up to 50 feet wide at the top, and 25 feet tall. Any creature in the water and within 25 feet of the whirlpool is pulled 10 feet toward it. When a creature enters the whirlpool for the first time on a turn or ends its turn there, it makes a Strength saving throw. On a failed save, the creature takes 2d8 Bludgeoning damage. On a successful save, the creature takes half as much damage. A creature can swim away from the whirlpool only if it first takes an action to pull away and succeeds on a Strength (Athletics) check against your spell save DC.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "control-water", "it"),
					Language = LanguageCode.It,
					Name = "Controllare Acqua",
					CastingTime = "Azione",
					Range = "90 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un miscuglio di acqua e polvere",
					Description = "Finché l'incantesimo non termina, l'incantatore controlla tutta l'acqua all'interno di un'area a sua scelta, costituita da un cubo con spigolo fino a 30 metri, usando uno degli effetti seguenti. Come azione di Magia nei turni successivi, può ripetere lo stesso effetto o sceglierne uno diverso.\n\n***Inondazione.*** L'incantatore fa salire il livello di tutta l'acqua stagnante nell'area fino a un massimo di 6 metri. Se sceglie un'area all'interno di un'ampia distesa d'acqua, crea invece un'onda alta 6 metri che attraversa l'area da un lato all'altro e poi si infrange. Tutti i veicoli di taglia Enorme o inferiore lungo il percorso dell'onda vengono trascinati con essa fino all'altro lato. Tutti i veicoli di taglia Enorme o inferiore colpiti dall'onda hanno una probabilità del 25 per cento di capovolgersi.\n\nIl livello dell'acqua resta elevato finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso. Se questo effetto ha prodotto un'onda, l'onda si ripete all'inizio del turno successivo dell'incantatore finché l'effetto di inondazione persiste.\n\n***Dividere le Acque.*** L'incantatore divide l'acqua nell'area e crea un fossato. Il fossato si estende per tutta l'area dell'incantesimo e l'acqua separata forma un muro su entrambi i lati. Il fossato rimane finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso. L'acqua poi riempie lentamente il fossato nel corso del round successivo, finché non viene ripristinato il livello normale.\n\n***Deviare la Corrente.*** L'incantatore fa scorrere l'acqua corrente nell'area in una direzione a sua scelta, anche se l'acqua deve scavalcare ostacoli, risalire pareti o scorrere in altre direzioni improbabili. L'acqua nell'area si muove come indicato dall'incantatore, ma una volta uscita dall'area dell'incantesimo riprende a scorrere in base al terreno. L'acqua continua a muoversi nella direzione scelta finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso.\n\n***Gorgo.*** L'incantatore fa formare un gorgo al centro dell'area, che deve misurare almeno 15 metri per lato ed essere profonda almeno 7,5 metri. Il gorgo permane finché l'incantatore non sceglie un effetto diverso o finché l'incantesimo non termina. Il gorgo è largo 1,5 metri alla base, fino a 15 metri in cima, ed è alto 7,5 metri. Ogni creatura che si trova in acqua entro 7,5 metri dal gorgo viene trascinata di 3 metri verso di esso. Quando una creatura entra nel gorgo per la prima volta in un turno o vi termina il proprio turno, effettua un tiro salvezza su Forza. Se lo fallisce, subisce 2d8 danni contundenti. Se lo supera, subisce la metà di quei danni. Una creatura può allontanarsi a nuoto dal gorgo soltanto se prima effettua un'azione per divincolarsi e supera una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
