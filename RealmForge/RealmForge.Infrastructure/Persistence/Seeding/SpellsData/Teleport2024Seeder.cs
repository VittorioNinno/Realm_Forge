using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Teleport (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Teleport2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleport");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleport", "en"),
					Language = LanguageCode.En,
					Name = "Teleport",
					CastingTime = "Action",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "This spell instantly transports you and up to eight willing creatures that you can see within range, or a single object that you can see within range, to a destination you select. If you target an object, it must be Large or smaller, and it can't be held or carried by an unwilling creature.\n\nThe destination you choose must be known to you, and it must be on the same plane of existence as you. Your familiarity with the destination determines whether you arrive there successfully. The GM rolls 1d100 and consults the Teleportation Outcome table and the explanations after it.\n\n**Teleportation Outcome**\n\n| Familiarity | Mishap | Similar Area | Off Target | On Target |\n|---|---|---|---|---|\n| Permanent circle | — | — | — | 01–00 |\n| Linked object | — | — | — | 01–00 |\n| Very familiar | 01–05 | 06–13 | 14–24 | 25–00 |\n| Seen casually | 01–33 | 34–43 | 44–53 | 54–00 |\n| Viewed once or described | 01–43 | 44–53 | 54–73 | 74–00 |\n| False destination | 01–50 | 51–00 | — | — |\n\n***Familiarity.*** Here are the meanings of the terms in the table's Familiarity column:\n\n- \"Permanent circle\" means a permanent teleportation circle whose sigil sequence you know.\n\n- \"Linked object\" means you possess an object taken from the desired destination within the last six months, such as a book from a wizard's library.\n\n- \"Very familiar\" is a place you have visited often, a place you have carefully studied, or a place you can see when you cast the spell.\n\n- \"Seen casually\" is a place you have seen more than once but with which you aren't very familiar.\n\n- \"Viewed once or described\" is a place you have seen once, possibly using magic, or a place you know through someone else's description, perhaps from a map.\n\n- \"False destination\" is a place that doesn't exist. Perhaps you tried to scry an enemy's sanctum but instead viewed an illusion, or you are attempting to teleport to a location that no longer exists.\n\n***Mishap.*** The spell's unpredictable magic results in a difficult journey. Each teleporting creature (or the target object) takes 3d10 Force damage, and the GM rerolls on the table to see where you wind up (multiple mishaps can occur, dealing damage each time).\n\n***Similar Area.*** You and your group (or the target object) appear in a different area that's visually or thematically similar to the target area. You appear in the closest similar place. If you are heading for your home laboratory, for example, you might appear in another person's laboratory in the same city.\n\n***Off Target.*** You and your group (or the target object) appear 2d12 miles away from the destination in a random direction. Roll 1d8 for the direction: 1, east; 2, southeast; 3, south; 4, southwest; 5, west; 6, northwest; 7, north; or 8, northeast.\n\n***On Target.*** You and your group (or the target object) appear where you intended.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleport", "it"),
					Language = LanguageCode.It,
					Name = "Teletrasporto",
					CastingTime = "Azione",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Questo incantesimo trasporta istantaneamente l'incantatore e fino a otto creature consenzienti entro gittata che è in grado di vedere, oppure un singolo oggetto entro gittata che è in grado di vedere, in una destinazione da lui scelta. Se l'incantatore prende come bersaglio un oggetto, questo deve essere di taglia Grande o inferiore e non può essere impugnato o trasportato da una creatura non consenziente.\n\nLa destinazione scelta deve essere nota all'incantatore e deve trovarsi sul suo stesso piano di esistenza. La familiarità dell'incantatore con la destinazione determina se vi arriva con successo. Il DM tira 1d100 e consulta la tabella dell'Esito del Teletrasporto e le spiegazioni che la seguono.\n\n**Esito del Teletrasporto**\n\n| Familiarità | Incidente | Area simile | Fuori bersaglio | Sul bersaglio |\n|---|---|---|---|---|\n| Cerchio permanente | — | — | — | 01–00 |\n| Oggetto collegato | — | — | — | 01–00 |\n| Molto familiare | 01–05 | 06–13 | 14–24 | 25–00 |\n| Visto di sfuggita | 01–33 | 34–43 | 44–53 | 54–00 |\n| Visto una volta o descritto | 01–43 | 44–53 | 54–73 | 74–00 |\n| Falsa destinazione | 01–50 | 51–00 | — | — |\n\n***Familiarità.*** Ecco il significato dei termini della colonna Familiarità della tabella:\n\n- \"Cerchio permanente\" indica un cerchio di teletrasporto permanente di cui l'incantatore conosce la sequenza di sigilli.\n\n- \"Oggetto collegato\" significa che l'incantatore possiede un oggetto prelevato dalla destinazione desiderata negli ultimi sei mesi, come un libro proveniente dalla biblioteca di un mago.\n\n- \"Molto familiare\" è un luogo che l'incantatore ha visitato spesso, un luogo che ha studiato attentamente o un luogo che è in grado di vedere quando lancia l'incantesimo.\n\n- \"Visto di sfuggita\" è un luogo che l'incantatore ha visto più di una volta, ma con cui non ha molta familiarità.\n\n- \"Visto una volta o descritto\" è un luogo che l'incantatore ha visto una volta, magari tramite la magia, o un luogo che conosce attraverso la descrizione di qualcun altro, magari grazie a una mappa.\n\n- \"Falsa destinazione\" è un luogo che non esiste. Forse l'incantatore ha tentato di scrutare il santuario di un nemico ma ha visto invece un'illusione, oppure sta tentando di teletrasportarsi in un luogo che non esiste più.\n\n***Incidente.*** La magia imprevedibile dell'incantesimo dà luogo a un viaggio difficile. Ogni creatura che si teletrasporta (o l'oggetto bersaglio) subisce 3d10 danni da forza, e il DM tira di nuovo sulla tabella per stabilire dove finisce l'incantatore (possono verificarsi più incidenti, che infliggono danni ogni volta).\n\n***Area Simile.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) compaiono in un'area diversa che è visivamente o tematicamente simile all'area bersaglio. Compaiono nel luogo simile più vicino. Se l'incantatore è diretto al proprio laboratorio, per esempio, potrebbe comparire nel laboratorio di un'altra persona nella stessa città.\n\n***Fuori Bersaglio.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) compaiono a 2d12 × 1,5 km dalla destinazione, in una direzione casuale. Si tira 1d8 per determinare la direzione: 1, est; 2, sud-est; 3, sud; 4, sud-ovest; 5, ovest; 6, nord-ovest; 7, nord; 8, nord-est.\n\n***Sul Bersaglio.*** L'incantatore e il suo gruppo (o l'oggetto bersaglio) compaiono dove l'incantatore intendeva.",
					HigherLevels = null
				}
			}
		};
	}
}
