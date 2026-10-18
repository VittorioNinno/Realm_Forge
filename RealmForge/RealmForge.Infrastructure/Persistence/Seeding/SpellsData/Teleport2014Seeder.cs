using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Teleport (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Teleport2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleport");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleport", "en"),
					Language = LanguageCode.En,
					Name = "Teleport",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "This spell instantly transports you and up to eight willing creatures of your choice that you can see within range, or a single object that you can see within range, to a destination you select. If you target an object, it must be able to fit entirely inside a 10-foot cube, and it can't be held or carried by an unwilling creature.\n\nThe destination you choose must be known to you, and it must be on the same plane of existence as you. Your familiarity with the destination determines whether you arrive there successfully. The GM rolls d100 and consults the table.\n\n| Familiarity | Mishap | Similar Area | Off Target | On Target |\n|---|---|---|---|---|\n| Permanent circle | — | — | — | 01-100 |\n| Associated object | — | — | — | 01-100 |\n| Very familiar | 01-05 | 06-13 | 14-24 | 25-100 |\n| Seen casually | 01-33 | 34-43 | 44-53 | 54-100 |\n| Viewed once | 01-43 | 44-53 | 54-73 | 74-100 |\n| Description | 01-43 | 44-53 | 54-73 | 74-100 |\n| False destination | 01-50 | 51-100 | — | — |\n\n***Familiarity.*** \"Permanent circle\" means a permanent teleportation circle whose sigil sequence you know.\n\n\"Associated object\" means that you possess an object taken from the desired destination within the last six months, such as a book from a wizard's library, bed linen from a royal suite, or a chunk of marble from a lich's secret tomb.\n\n\"Very familiar\" is a place you have been very often, a place you have carefully studied, or a place you can see when you cast the spell.\n\n\"Seen casually\" is someplace you have seen more than once but with which you aren't very familiar.\n\n\"Viewed once\" is a place you have seen once, possibly using magic.\n\n\"Description\" is a place whose location and appearance you know through someone else's description, perhaps from a map.\n\n\"False destination\" is a place that doesn't exist. Perhaps you tried to scry an enemy's sanctum but instead viewed an illusion, or you are attempting to teleport to a familiar location that no longer exists.\n\n***On Target.*** You and your group (or the target object) appear where you want to.\n\n***Off Target.*** You and your group (or the target object) appear a random distance away from the destination in a random direction. Distance off target is 1d10 x 1d10 percent of the distance that was to be traveled. For example, if you tried to travel 120 miles, landed off target, and rolled a 5 and 3 on the two d10s, then you would be off target by 15 percent, or 18 miles. The GM determines the direction off target randomly by rolling a d8 and designating 1 as north, 2 as northeast, 3 as east, and so on around the points of the compass. If you were teleporting to a coastal city and wound up 18 miles out at sea, you could be in trouble.\n\n***Similar Area.*** You and your group (or the target object) wind up in a different area that's visually or thematically similar to the target area. If you are heading for your home laboratory, for example, you might wind up in another wizard's laboratory or in an alchemical supply shop that has many of the same tools and implements as your laboratory. Generally, you appear in the closest similar place, but since the spell has no range limit, you could conceivably wind up anywhere on the plane.\n\n***Mishap.*** The spell's unpredictable magic results in a difficult journey. Each teleporting creature (or the target object) takes 3d10 force damage, and the GM rerolls on the table to see where you wind up (multiple mishaps can occur, dealing damage each time).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleport", "it"),
					Language = LanguageCode.It,
					Name = "Teletrasporto",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Questo incantesimo trasporta istantaneamente l'incantatore e fino a otto creature consenzienti a sua scelta entro gittata che sia in grado di vedere, oppure un singolo oggetto entro gittata che sia in grado di vedere, verso una destinazione da lui scelta. Se l'incantatore bersaglia un oggetto, questo deve poter essere contenuto interamente in un cubo con spigolo di 3 metri e non può essere impugnato o trasportato da una creatura non consenziente.\n\nLa destinazione scelta deve essere nota all'incantatore e deve trovarsi sul suo stesso piano di esistenza. La familiarità dell'incantatore con la destinazione determina se riesce ad arrivarvi. Il DM tira un d100 e consulta la tabella.\n\n| Familiarità | Incidente | Area simile | Fuori bersaglio | Sul bersaglio |\n|---|---|---|---|---|\n| Cerchio permanente | — | — | — | 01-100 |\n| Oggetto associato | — | — | — | 01-100 |\n| Molto familiare | 01-05 | 06-13 | 14-24 | 25-100 |\n| Visto di sfuggita | 01-33 | 34-43 | 44-53 | 54-100 |\n| Visto una volta | 01-43 | 44-53 | 54-73 | 74-100 |\n| Descrizione | 01-43 | 44-53 | 54-73 | 74-100 |\n| Falsa destinazione | 01-50 | 51-100 | — | — |\n\n***Familiarità.*** \"Cerchio permanente\" indica un cerchio di teletrasporto permanente di cui l'incantatore conosce la sequenza di sigilli.\n\n\"Oggetto associato\" significa che l'incantatore possiede un oggetto prelevato dalla destinazione desiderata negli ultimi sei mesi, come un libro della biblioteca di un mago, la biancheria del letto di una suite reale o un frammento di marmo della tomba segreta di un lich.\n\n\"Molto familiare\" è un luogo in cui l'incantatore è stato molto spesso, un luogo che ha studiato attentamente o un luogo che è in grado di vedere quando lancia l'incantesimo.\n\n\"Visto di sfuggita\" è un luogo che l'incantatore ha visto più di una volta, ma che non conosce molto bene.\n\n\"Visto una volta\" è un luogo che l'incantatore ha visto una sola volta, eventualmente tramite la magia.\n\n\"Descrizione\" è un luogo di cui l'incantatore conosce la posizione e l'aspetto tramite la descrizione di qualcun altro, magari grazie a una mappa.\n\n\"Falsa destinazione\" è un luogo che non esiste. Forse l'incantatore ha tentato di scrutare il santuario di un nemico ma ha visto invece un'illusione, oppure sta tentando di teletrasportarsi in un luogo familiare che non esiste più.\n\n***Sul Bersaglio.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) compaiono dove desiderano.\n\n***Fuori Bersaglio.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) compaiono a una distanza casuale dalla destinazione, in una direzione casuale. La distanza dal bersaglio è pari a 1d10 × 1d10 per cento della distanza da percorrere. Per esempio, se l'incantatore tentava di percorrere 180 km, è arrivato fuori bersaglio e ha ottenuto 5 e 3 con i due d10, si ritrova fuori bersaglio del 15 per cento, ovvero di 27 km. Il DM determina casualmente la direzione tirando un d8 e assegnando 1 al nord, 2 al nord-est, 3 all'est e così via, seguendo i punti cardinali. Se l'incantatore si stava teletrasportando in una città costiera ed è finito 27 km al largo, potrebbe trovarsi nei guai.\n\n***Area Simile.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) finiscono in un'area diversa, visivamente o tematicamente simile all'area bersaglio. Se l'incantatore era diretto al suo laboratorio, per esempio, potrebbe finire nel laboratorio di un altro mago o in un negozio di forniture alchemiche dotato di molti degli stessi attrezzi e strumenti del suo laboratorio. Di solito compare nel luogo simile più vicino, ma poiché l'incantesimo non ha limiti di gittata, potrebbe in teoria finire in qualsiasi punto del piano.\n\n***Incidente.*** La magia imprevedibile dell'incantesimo rende il viaggio difficoltoso. Ogni creatura teletrasportata (o l'oggetto bersaglio) subisce 3d10 danni da forza, e il DM tira di nuovo sulla tabella per vedere dove finiscono (possono verificarsi più incidenti, che infliggono danni ogni volta).",
					HigherLevels = null
				}
			}
		};
	}
}
