using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Control Water (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ControlWater2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-water");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-water", "en"),
					Language = LanguageCode.En,
					Name = "Control Water",
					CastingTime = "1 action",
					Range = "300 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a drop of water and a pinch of dust",
					Description = "Until the spell ends, you control any freestanding water inside an area you choose that is a cube up to 100 feet on a side. You can choose from any of the following effects when you cast this spell. As an action on your turn, you can repeat the same effect or choose a different one.\n\n***Flood.*** You cause the water level of all standing water in the area to rise by as much as 20 feet. If the area includes a shore, the flooding water spills over onto dry land.\n\nIf you choose an area in a large body of water, you instead create a 20-foot tall wave that travels from one side of the area to the other and then crashes down. Any Huge or smaller vehicles in the wave's path are carried with it to the other side. Any Huge or smaller vehicles struck by the wave have a 25 percent chance of capsizing.\n\nThe water level remains elevated until the spell ends or you choose a different effect. If this effect produced a wave, the wave repeats on the start of your next turn while the flood effect lasts.\n\n***Part Water.*** You cause water in the area to move apart and create a trench. The trench extends across the spell's area, and the separated water forms a wall to either side. The trench remains until the spell ends or you choose a different effect. The water then slowly fills in the trench over the course of the next round until the normal water level is restored.\n\n***Redirect Flow.*** You cause flowing water in the area to move in a direction you choose, even if the water has to flow over obstacles, up walls, or in other unlikely directions. The water in the area moves as you direct it, but once it moves beyond the spell's area, it resumes its flow based on the terrain conditions. The water continues to move in the direction you chose until the spell ends or you choose a different effect.\n\n***Whirlpool.*** This effect requires a body of water at least 50 feet square and 25 feet deep. You cause a whirlpool to form in the center of the area. The whirlpool forms a vortex that is 5 feet wide at the base, up to 50 feet wide at the top, and 25 feet tall. Any creature or object in the water and within 25 feet of the vortex is pulled 10 feet toward it. A creature can swim away from the vortex by making a Strength (Athletics) check against your spell save DC.\n\nWhen a creature enters the vortex for the first time on a turn or starts its turn there, it must make a Strength saving throw. On a failed save, the creature takes 2d8 bludgeoning damage and is caught in the vortex until the spell ends. On a successful save, the creature takes half damage, and isn't caught in the vortex. A creature caught in the vortex can use its action to try to swim away from the vortex as described above, but has disadvantage on the Strength (Athletics) check to do so.\n\nThe first time each turn that an object enters the vortex, the object takes 2d8 bludgeoning damage; this damage occurs each round it remains in the vortex.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "control-water", "it"),
					Language = LanguageCode.It,
					Name = "Controllare Acqua",
					CastingTime = "1 azione",
					Range = "90 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una goccia d'acqua e un pizzico di polvere",
					Description = "Finché l'incantesimo non termina, l'incantatore controlla qualsiasi massa d'acqua libera all'interno di un'area da lui scelta, che consiste in un cubo con spigolo fino a 30 metri. Quando lancia questo incantesimo, può scegliere uno qualsiasi degli effetti seguenti. Come azione nel suo turno, può ripetere lo stesso effetto o sceglierne uno diverso.\n\n***Inondazione.*** L'incantatore fa salire il livello di tutta l'acqua stagnante nell'area fino a un massimo di 6 metri. Se l'area comprende una riva, l'acqua che inonda si riversa sulla terraferma.\n\nSe l'incantatore sceglie un'area all'interno di un'ampia distesa d'acqua, crea invece un'onda alta 6 metri che attraversa l'area da un lato all'altro e poi si infrange. Tutti i veicoli di taglia Enorme o inferiore lungo il percorso dell'onda vengono trascinati con essa fino all'altro lato. Tutti i veicoli di taglia Enorme o inferiore colpiti dall'onda hanno una probabilità del 25 per cento di capovolgersi.\n\nIl livello dell'acqua resta elevato finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso. Se questo effetto ha prodotto un'onda, l'onda si ripete all'inizio del turno successivo dell'incantatore finché l'effetto di inondazione persiste.\n\n***Dividere le Acque.*** L'incantatore fa separare l'acqua nell'area, creando un fossato. Il fossato si estende per tutta l'area dell'incantesimo e l'acqua separata forma un muro su entrambi i lati. Il fossato rimane finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso. In seguito l'acqua riempie lentamente il fossato nel corso del round successivo, finché non viene ripristinato il livello normale.\n\n***Deviare la Corrente.*** L'incantatore fa scorrere l'acqua corrente nell'area in una direzione a sua scelta, anche se l'acqua deve scavalcare ostacoli, risalire pareti o scorrere in altre direzioni improbabili. L'acqua nell'area si muove come indicato dall'incantatore, ma una volta uscita dall'area dell'incantesimo riprende a scorrere in base alle condizioni del terreno. L'acqua continua a muoversi nella direzione scelta finché l'incantesimo non termina o finché l'incantatore non sceglie un effetto diverso.\n\n***Gorgo.*** Questo effetto richiede una massa d'acqua di almeno 15 metri per lato e profonda 7,5 metri. L'incantatore fa formare un gorgo al centro dell'area. Il gorgo forma un vortice largo 1,5 metri alla base, fino a 15 metri in cima, e alto 7,5 metri. Ogni creatura od oggetto che si trova in acqua entro 7,5 metri dal vortice viene trascinato di 3 metri verso di esso. Una creatura può allontanarsi a nuoto dal vortice superando una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore.\n\nQuando una creatura entra nel vortice per la prima volta in un turno o vi inizia il proprio turno, deve effettuare un tiro salvezza su Forza. Se lo fallisce, subisce 2d8 danni contundenti ed è intrappolata nel vortice finché l'incantesimo non termina. Se lo supera, subisce la metà dei danni e non viene intrappolata. Una creatura intrappolata nel vortice può usare la propria azione per tentare di allontanarsi a nuoto come descritto sopra, ma subisce svantaggio alla prova di Forza (Atletica).\n\nLa prima volta in ogni turno in cui un oggetto entra nel vortice, l'oggetto subisce 2d8 danni contundenti; questi danni si ripetono a ogni round in cui l'oggetto rimane nel vortice.",
					HigherLevels = null
				}
			}
		};
	}
}
