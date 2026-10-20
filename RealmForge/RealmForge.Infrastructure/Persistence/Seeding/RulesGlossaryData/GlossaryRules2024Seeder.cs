using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.RulesGlossaryData;

///	<summary>
///	Rules glossary entries (except conditions and actions) of the 2024 rules. English text from the SRD 5.2.1 (CC BY 4.0); the Italian texts are RealmForge
///	translations that use the official names of the Italian Player's Handbook.
///	</summary>
public static class GlossaryRules2024Seeder
{
	public static IEnumerable<RuleEntry> Build()
	{
		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "ability-check", RuleCategory.Rule,
			related: new[] { "proficiency" },
			en: ("Ability Check", "An ability check is a D20 Test that represents using one of the six abilities—or a specific skill associated with an ability—to overcome a challenge.",
				Array.Empty<string>()),
			it: ("Prova di caratteristica", "Una prova di caratteristica è una prova con d20 che rappresenta l'uso di una delle sei caratteristiche, oppure di un'abilità associata a una caratteristica, per superare una sfida.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "ability-score-and-modifier", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Ability Score and Modifier", "A creature has six ability scores—Strength, Dexterity, Constitution, Intelligence, Wisdom, and Charisma—each of which has a corresponding modifier. Add the modifier when you make a D20 Test with the corresponding ability or when a rule asks you to do so.",
				Array.Empty<string>()),
			it: ("Punteggio di caratteristica e modificatore", "Ogni creatura ha sei punteggi di caratteristica (Forza, Destrezza, Costituzione, Intelligenza, Saggezza e Carisma), ciascuno con il proprio modificatore. Il modificatore si aggiunge quando si effettua una prova con d20 legata a quella caratteristica, o quando una regola lo richiede.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "action", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Action", "On your turn, you can take one action. Choose which action to take from those below or from the special actions provided by your features. These actions are defined elsewhere in this glossary:\n\n| Attack | Dodge | Influence | Search |\n|---|---|---|---|\n| Dash | Help | Magic | Study |\n| Disengage | Hide | Ready | Utilize |",
				Array.Empty<string>()),
			it: ("Azione", "Nel suo turno il personaggio può effettuare un'azione. La sceglie tra quelle elencate qui sotto o tra le azioni speciali concesse dai suoi privilegi. Ognuna di queste azioni ha una propria voce nel glossario:\n\n| Aiuto | Influenza | Prepararsi | Schivata |\n|---|---|---|---|\n| Attacco | Magia | Ricerca | Studio |\n| Disimpegno | Nascondersi | Scatto | Utilizzo |",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "advantage", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Advantage", "If you have Advantage on a D20 Test, roll two d20s, and use the higher roll. A roll can't be affected by more than one Advantage, and Advantage and Disadvantage on the same roll cancel each other.",
				new[] { "Advantage" }),
			it: ("Vantaggio", "Quando un personaggio ha vantaggio a una prova con d20, tira due d20 e usa il risultato più alto. Un tiro non può essere influenzato da più di un vantaggio, e vantaggio e svantaggio sullo stesso tiro si annullano a vicenda.",
				new[] { "vantaggio" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "adventure", RuleCategory.Rule,
			related: new[] { "encounter" },
			en: ("Adventure", "An adventure is a series of encounters. A story emerges through playing them.",
				Array.Empty<string>()),
			it: ("Avventura", "Un'avventura è una serie di incontri: giocandoli, prende forma una storia.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "alignment", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Alignment", "A creature's alignment broadly describes its ethical attitudes and ideals. Alignment is a combination of two factors: one identifies morality (good, evil, or neutral), and the other describes attitudes toward order (lawful, chaotic, or neutral). These factors allow for nine possible combinations, such as Lawful Good and Neutral Evil.",
				Array.Empty<string>()),
			it: ("Allineamento", "L'allineamento descrive a grandi linee gli atteggiamenti etici e gli ideali di una creatura. È la combinazione di due fattori: uno riguarda la morale (buono, malvagio o neutrale), l'altro il rapporto con l'ordine (legale, caotico o neutrale). Ne derivano nove combinazioni possibili, come legale buono o neutrale malvagio.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "ally", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Ally", "A creature is your ally if it is a member of your adventuring party, your friend, on your side in combat, or a creature that the rules or the GM designates as your ally.",
				Array.Empty<string>()),
			it: ("Alleato", "Una creatura è alleata del personaggio se fa parte del suo gruppo di avventurieri, se è sua amica, se combatte dalla sua parte o se le regole o il DM la designano come tale.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "area-of-effect", RuleCategory.Rule,
			related: new[] { "cover" },
			en: ("Area of Effect", "The descriptions of many spells and other features specify that they have an area of effect, which typically has one of six shapes. These shapes are defined elsewhere in this glossary:\n\n| Cone | Cylinder | Line |\n|---|---|---|\n| Cube | Emanation | Sphere |\n\nAn area of effect has a point of origin, a location from which the effect's energy erupts. The rules for each shape specify how to position its point of origin. If all straight lines extending from the point of origin to a location in the area of effect are blocked, that location isn't included in the area of effect. To block a line, an obstruction must provide Total Cover.",
				Array.Empty<string>()),
			it: ("Area di effetto", "Molti incantesimi e altri privilegi hanno un'area di effetto, che di solito ha una di queste sei forme, ciascuna definita nel glossario:\n\n| Cilindro | Cubo | Linea |\n|---|---|---|\n| Cono | Emanazione | Sfera |\n\nOgni area di effetto ha un punto di origine, il luogo da cui l'energia dell'effetto si sprigiona; le regole di ciascuna forma spiegano dove collocarlo. Un punto dell'area è escluso se tutte le linee rette che lo collegano al punto di origine sono bloccate: per bloccare una linea, un ostacolo deve fornire copertura totale.\n\nSe il creatore dell'area di effetto la colloca in un punto che non vede e tra lui e quel punto c'è un ostacolo, come un muro, il punto di origine si forma sul lato dell'ostacolo più vicino al creatore.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "armor-class", RuleCategory.Rule,
			related: new[] { "attack-roll" },
			en: ("Armor Class", "An Armor Class (AC) is the target number for an attack roll. AC represents how difficult it is to hit a target.\n\nYour base AC calculation is 10 plus your Dexterity modifier. If a rule gives you another base AC calculation, you choose which calculation to use; you can't use more than one.",
				Array.Empty<string>()),
			it: ("Classe Armatura", "La Classe Armatura (CA) è il numero bersaglio di un tiro per colpire e rappresenta quanto è difficile colpire un bersaglio.\n\nLa CA base di un personaggio è pari a 10 + il suo modificatore di Destrezza. Se una regola gli offre un altro modo per calcolare la CA base, il personaggio sceglie quale usare: non può combinarne più di uno.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "armor-training", RuleCategory.Rule,
			related: new[] { "disadvantage" },
			en: ("Armor Training", "Armor training allows you to use armor of a certain category without the following drawbacks. If you wear Light, Medium, or Heavy armor and lack training with it, you have Disadvantage on any D20 Test that involves Strength or Dexterity, and you can't cast spells. If you use a Shield and lack training with it, you don't gain its AC bonus.",
				Array.Empty<string>()),
			it: ("Competenza nelle armature", "La competenza nelle armature permette di usare le armature di una certa categoria senza subire questi svantaggi: un personaggio che indossa un'armatura leggera, media o pesante senza averne la competenza subisce svantaggio a ogni prova con d20 basata su Forza o Destrezza e non può lanciare incantesimi. Se usa uno scudo senza averne la competenza, non ottiene il bonus alla CA dello scudo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "attack-roll", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Attack Roll", "An attack roll is a D20 Test that represents making an attack with a weapon, an Unarmed Strike, or a spell.",
				Array.Empty<string>()),
			it: ("Tiro per colpire", "Un tiro per colpire è una prova con d20 che rappresenta un attacco portato con un'arma, con un colpo senz'armi o con un incantesimo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "attitude", RuleCategory.Rule,
			related: new[] { "friendly", "hostile", "indifferent", "influence" },
			en: ("Attitude", "A monster has a starting attitude toward a player character: Friendly, Hostile, or Indifferent.",
				Array.Empty<string>()),
			it: ("Atteggiamento", "Ogni mostro ha un atteggiamento iniziale nei confronti di un personaggio giocante: amichevole, ostile o indifferente.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "attunement", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Attunement", "Some magic items require a creature to form a bond—called Attunement—with them before the creature can use an item's magical properties. A creature can have Attunement with no more than three magic items at a time.",
				new[] { "Attunement" }),
			it: ("Sintonia", "Alcuni oggetti magici richiedono che una creatura stabilisca con loro un legame, detto sintonia, prima di poterne usare le proprietà magiche. Una creatura può essere in sintonia con un massimo di tre oggetti magici alla volta.",
				new[] { "sintonia" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "blindsight", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Blindsight", "If you have Blindsight, you can see within a specific range without relying on physical sight. Within that range, you can see anything that isn't behind Total Cover even if you have the Blinded condition or are in Darkness. Moreover, in that range, you can see something that has the Invisible condition.",
				new[] { "Blindsight" }),
			it: ("Vista cieca", "Una creatura con vista cieca può vedere entro un certo raggio senza fare affidamento sulla vista vera e propria. Entro quel raggio vede tutto ciò che non si trova dietro copertura totale, anche se ha la condizione di accecato o si trova nell'oscurità, e vede anche le creature e gli oggetti che hanno la condizione di invisibile.",
				new[] { "vista cieca" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "bloodied", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Bloodied", "A creature is Bloodied while it has half its Hit Points or fewer remaining.",
				new[] { "Bloodied" }),
			it: ("Sanguinante", "Una creatura è sanguinante finché le restano metà dei suoi punti ferita o meno.",
				new[] { "sanguinante", "sanguinanti" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "bonus-action", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Bonus Action", "A Bonus Action is a special action that you can take on the same turn that you take an action. You can't take more than one Bonus Action on a turn, and you have a Bonus Action to take only if a rule explicitly says so.",
				new[] { "Bonus Action", "Bonus Actions" }),
			it: ("Azione bonus", "L'azione bonus è un'azione speciale che il personaggio può effettuare nello stesso turno in cui effettua un'azione. Non può effettuare più di un'azione bonus per turno e ne dispone solo se una regola gliela concede esplicitamente.",
				new[] { "azione bonus", "azioni bonus" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "breaking-objects", RuleCategory.Rule,
			related: new[] { "damage-threshold" },
			en: ("Breaking Objects", "Objects can be harmed by attacks and by some spells, using the rules below. If an object is exceedingly fragile, the GM may allow a creature to break it automatically with the Attack or Utilize action.\n\n**Armor Class.** The Object Armor Class table suggests ACs for various substances.\n\n**Object Armor Class**\n\n| AC | Substance | AC | Substance |\n|---|---|---|---|\n| 11 | Cloth, paper, rope | 19 | Iron, steel |\n| 13 | Crystal, glass, ice | 21 | Mithral |\n| 15 | Wood | 23 | Adamantine |\n| 17 | Stone |  |  |\n\n**Hit Points.** An object is destroyed when it has 0 Hit Points. The Object Hit Points table suggests Hit Points for fragile and resilient objects that are Large or smaller. To track Hit Points for a Huge or Gargantuan object, divide it into Large or smaller sections, and track each section's Hit Points separately. The GM determines whether destroying part of an object causes the whole thing to collapse.\n\n**Object Hit Points**\n\n| Size | Fragile | Resilient |\n|---|---|---|\n| Tiny (bottle, lock) | 2 (1d4) | 5 (2d4) |\n| Small (chest, lute) | 3 (1d6) | 10 (3d6) |\n| Medium (barrel, chandelier) | 4 (1d8) | 18 (4d8) |\n| Large (cart, dining table) | 5 (1d10) | 27 (5d10) |\n\n**Damage Types and Objects.** Objects have Immunity to Poison and Psychic damage. The GM might decide that some damage types are more or less effective against an object. For example, Bludgeoning damage works well for smashing things but not for cutting. Paper or cloth objects might have Vulnerability to Fire damage.\n\n**Damage Threshold.** Big objects, such as castle walls, often have extra resilience represented by a damage threshold.** An object lacks ability scores unless a rule assigns scores to the object. Without ability scores, an object can't make ability checks, and it fails all saving throws.",
				Array.Empty<string>()),
			it: ("Rompere gli oggetti", "Gli oggetti possono essere danneggiati dagli attacchi e da alcuni incantesimi, secondo le regole seguenti. Se un oggetto è estremamente fragile, il DM può stabilire che una creatura lo rompa automaticamente con l'azione di Attacco o di Utilizzo.\n\n**Classe Armatura.** La tabella \"Classe Armatura degli oggetti\" suggerisce la CA dei vari materiali.\n\n**Classe Armatura degli oggetti**\n\n| CA | Materiale | CA | Materiale |\n|---|---|---|---|\n| 11 | Stoffa, carta, corda | 19 | Ferro, acciaio |\n| 13 | Cristallo, vetro, ghiaccio | 21 | Mithral |\n| 15 | Legno | 23 | Adamantio |\n| 17 | Pietra | | |\n\n**Punti ferita.** Un oggetto è distrutto quando arriva a 0 punti ferita. La tabella \"Punti ferita degli oggetti\" suggerisce i punti ferita degli oggetti fragili e resistenti di taglia Grande o inferiore. Per un oggetto Enorme o Mastodontico, lo si divide in sezioni di taglia Grande o inferiore e si tiene traccia dei punti ferita di ciascuna separatamente. Il DM stabilisce se distruggerne una parte fa crollare l'intero oggetto.\n\n**Punti ferita degli oggetti**\n\n| Taglia | Fragile | Resistente |\n|---|---|---|\n| Minuscola (bottiglia, serratura) | 2 (1d4) | 5 (2d4) |\n| Piccola (forziere, liuto) | 3 (1d6) | 10 (3d6) |\n| Media (barile, lampadario) | 4 (1d8) | 18 (4d8) |\n| Grande (carro, tavolo da pranzo) | 5 (1d10) | 27 (5d10) |\n\n**Tipi di danno e oggetti.** Gli oggetti hanno immunità ai danni da veleno e psichici. Il DM può decidere che alcuni tipi di danno siano più o meno efficaci contro un certo oggetto: i danni contundenti, per esempio, sono ottimi per frantumare ma non per tagliare, mentre gli oggetti di carta o di stoffa potrebbero avere vulnerabilità ai danni da fuoco.\n\n**Soglia di danno.** Gli oggetti di grandi dimensioni, come le mura di un castello, hanno spesso una resistenza supplementare rappresentata da una soglia di danno.\n\n**Nessun punteggio di caratteristica.** Un oggetto non ha punteggi di caratteristica, a meno che una regola non glieli assegni. Senza punteggi di caratteristica, non può effettuare prove di caratteristica e fallisce tutti i tiri salvezza.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "bright-light", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Bright Light", "Bright Light is normal illumination.",
				Array.Empty<string>()),
			it: ("Luce intensa", "La luce intensa è la normale illuminazione.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "burning", RuleCategory.Hazard,
			related: Array.Empty<string>(),
			en: ("Burning", "A burning creature or object takes 1d4 Fire damage at the start of each of its turns. As an action, you can extinguish fire on yourself by giving yourself the Prone condition and rolling on the ground. The fire also goes out if it is doused, submerged, or suffocated.",
				Array.Empty<string>()),
			it: ("In fiamme", "Una creatura o un oggetto in fiamme subisce 1d4 danni da fuoco all'inizio di ciascun suo turno. Come azione, una creatura in fiamme può spegnere il fuoco che la avvolge assumendo la condizione di prono e rotolandosi a terra. Il fuoco si spegne anche se viene bagnato, sommerso o soffocato.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "burrow-speed", RuleCategory.Rule,
			related: new[] { "speed" },
			en: ("Burrow Speed", "A creature that has a Burrow Speed can use that speed to move through sand, earth, mud, or ice. The creature can't burrow through solid rock unless the creature has a trait that allows it to do so.",
				new[] { "Burrow Speed" }),
			it: ("Velocità di scavo", "Una creatura con velocità di scavo può usarla per muoversi attraverso sabbia, terra, fango o ghiaccio. Non può scavare nella roccia solida, a meno che un suo tratto non glielo permetta.",
				new[] { "velocità di scavo" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "campaign", RuleCategory.Rule,
			related: new[] { "adventure" },
			en: ("Campaign", "A campaign is a series of adventures.",
				Array.Empty<string>()),
			it: ("Campagna", "Una campagna è una serie di avventure.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "cantrip", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Cantrip", "A cantrip is a level 0 spell, which is cast without a spell slot.",
				Array.Empty<string>()),
			it: ("Trucchetto", "Un trucchetto è un incantesimo di livello 0, lanciato senza spendere slot incantesimo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "carrying-capacity", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Carrying Capacity", "Your size and Strength score determine the maximum weight in pounds that you can carry, as shown in the Carrying Capacity table. The table also shows the maximum weight you can drag, lift, or push.\n\nWhile dragging, lifting, or pushing weight in excess of the maximum weight you can carry, your Speed can be no more than 5 feet.\n\n**Carrying Capacity**\n\n| Creature Size | Carry | Drag/Lift/Push |\n|---|---|---|\n| Tiny | Str. × 7.5 lb. | Str. × 15 lb. |\n| Small/Medium | Str. × 15 lb. | Str. × 30 lb. |\n| Large | Str. × 30 lb. | Str. × 60 lb. |\n| Huge | Str. × 60 lb. | Str. × 120 lb. |\n| Gargantuan | Str. × 120 lb. | Str. × 240 lb. |",
				new[] { "Carrying Capacity" }),
			it: ("Capacità di trasporto", "La taglia e il punteggio di Forza di una creatura determinano il peso massimo che può trasportare, come indicato nella tabella \"Capacità di trasporto\", che riporta anche il peso massimo che può trascinare, sollevare o spingere.\n\nMentre trascina, solleva o spinge un peso superiore a quello che può trasportare, la sua velocità non può superare 1,5 metri.\n\n**Capacità di trasporto**\n\n| Taglia della creatura | Trasporto | Trascinare/Sollevare/Spingere |\n|---|---|---|\n| Minuscola | For. × 3,75 kg | For. × 7,5 kg |\n| Piccola/Media | For. × 7,5 kg | For. × 15 kg |\n| Grande | For. × 15 kg | For. × 30 kg |\n| Enorme | For. × 30 kg | For. × 60 kg |\n| Mastodontica | For. × 60 kg | For. × 120 kg |",
				new[] { "capacità di trasporto" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "challenge-rating", RuleCategory.Rule,
			related: new[] { "stat-block" },
			en: ("Challenge Rating", "Challenge Rating (CR) summarizes the threat a monster poses to a group of four player characters. Compare a monster's CR to the characters' level. If the CR is higher, the monster is likely a danger. If the CR is lower, the monster likely poses little threat. But circumstances and the number of player characters can significantly alter how threatening a monster is in actual play. \"Gameplay Toolbox\" (\"Combat Encounters\") provides guidance to the GM on using CR while planning potential combat encounters.",
				Array.Empty<string>()),
			it: ("Grado di sfida", "Il grado di sfida (GS) riassume la minaccia che un mostro rappresenta per un gruppo di quattro personaggi giocanti. Si confronta il GS del mostro con il livello dei personaggi: se è più alto, il mostro è probabilmente pericoloso; se è più basso, rappresenta una minaccia modesta. Le circostanze e il numero di personaggi possono però cambiare molto la pericolosità effettiva di un mostro durante il gioco. Il DM trova nelle regole per preparare gli incontri di combattimento le indicazioni su come usare il GS.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "character-sheet", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Character Sheet", "A character sheet is a paper or digital record that you use to track your character's information.",
				Array.Empty<string>()),
			it: ("Scheda del personaggio", "La scheda del personaggio è il documento, cartaceo o digitale, in cui si annotano le informazioni del proprio personaggio.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "climbing", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Climbing", "While you're climbing, each foot of movement costs 1 extra foot (2 extra feet in Difficult Terrain). You ignore this extra cost if you have a Climb Speed and use it to climb. At the GM's option, climbing a slippery surface or one with few handholds might require a successful DC 15 Strength (Athletics) check.",
				Array.Empty<string>()),
			it: ("Scalare", "Mentre scala, ogni metro di movimento costa al personaggio 1 metro in più (2 metri in più su terreno difficile). Ignora questo costo aggiuntivo se ha una velocità di scalata e la usa per scalare.\n\nA discrezione del DM, scalare una superficie scivolosa o con pochi appigli può richiedere una prova di Forza (Atletica) con CD 15 superata.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "climb-speed", RuleCategory.Rule,
			related: new[] { "climbing", "speed" },
			en: ("Climb Speed", "A Climb Speed can be used in place of Speed to traverse a vertical surface without expending the extra movement normally associated with climbing.",
				new[] { "Climb Speed" }),
			it: ("Velocità di scalata", "La velocità di scalata può essere usata al posto della velocità normale per spostarsi su una superficie verticale senza spendere il movimento aggiuntivo che di solito richiede l'arrampicata.",
				new[] { "velocità di scalata" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "concentration", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Concentration", "Some spells and other effects require Concentration to remain active, as specified in their descriptions. If the effect's creator loses Concentration, the effect ends. If the effect has a maximum duration, the effect's description specifies how long the creator can concentrate on it: up to 1 minute, 1 hour, or some other duration. The creator can end Concentration at any time (no action required). The following factors break Concentration.\n\n**Another Concentration Effect.** You lose Concentration on an effect the moment you start casting a spell that requires Concentration or activate another effect that requires Concentration.\n\n**Damage.** If you take damage, you must succeed on a Constitution saving throw to maintain Concentration. The DC equals 10 or half the damage taken (round down), whichever number is higher, up to a maximum DC of 30.\n\n**Incapacitated or Dead.** Your Concentration ends if you have the Incapacitated condition or you die.",
				new[] { "Concentration" }),
			it: ("Concentrazione", "Alcuni incantesimi e altri effetti richiedono concentrazione per restare attivi, come indicato nella loro descrizione. Se il creatore dell'effetto perde la concentrazione, l'effetto termina. Se l'effetto ha una durata massima, la descrizione indica per quanto tempo il creatore può mantenere la concentrazione: fino a 1 minuto, 1 ora o un'altra durata. Il creatore può interrompere la concentrazione in qualsiasi momento (non richiede alcuna azione). La concentrazione si interrompe per i motivi seguenti.\n\n**Un altro effetto con concentrazione.** Il personaggio perde la concentrazione su un effetto nel momento in cui inizia a lanciare un altro incantesimo che richiede concentrazione o attiva un altro effetto che la richiede.\n\n**Danni.** Se subisce danni, il personaggio deve superare un tiro salvezza su Costituzione per mantenere la concentrazione. La CD è pari a 10 o alla metà dei danni subiti (arrotondata per difetto), a seconda di quale valore sia più alto, fino a un massimo di 30.\n\n**Incapacitato o morto.** La concentrazione termina se il personaggio ha la condizione di incapacitato o se muore.",
				new[] { "~(?<!punt[oi] )concentrazione" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "condition", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Condition", "A condition is a temporary game state. The definition of a condition says how it affects its recipient, and various rules define how to end a condition. This glossary defines these conditions:\n\n| Blinded | Grappled | Poisoned |\n|---|---|---|\n| Charmed | Incapacitated | Prone |\n| Deafened | Invisible | Restrained |\n| Exhaustion | Paralyzed | Stunned |\n| Frightened | Petrified | Unconscious |\n\nA condition doesn't stack with itself; a recipient either has a condition or doesn't. The Exhaustion condition is an exception to that rule.",
				Array.Empty<string>()),
			it: ("Condizione", "Una condizione è uno stato di gioco temporaneo. La sua definizione spiega come influisce su chi la subisce, mentre varie regole stabiliscono come porvi fine. Il glossario definisce queste condizioni:\n\n| Accecato | Avvelenato | Paralizzato |\n|---|---|---|\n| Affascinato | Incapacitato | Pietrificato |\n| Afferrato | Indebolimento | Privo di sensi |\n| Assordato | Invisibile | Prono |\n| Spaventato | Stordito | Trattenuto |\n\nUna condizione non si cumula con sé stessa: una creatura o ha una condizione o non ce l'ha. L'unica eccezione è la condizione di indebolimento.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "cone", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Cone", "A Cone is an area of effect that extends in straight lines from a point of origin in a direction its creator chooses. A Cone's width at any point along its length is equal to that point's distance from the point of origin. For example, a Cone is 15 feet wide at a point along its length that is 15 feet from the point of origin. The effect that creates a Cone specifies its maximum length.\n\nA Cone's point of origin isn't included in the area of effect unless its creator decides otherwise.",
				new[] { "=Cone", "=Cones" }),
			it: ("Cono", "Un cono è un'area di effetto che si estende in linea retta da un punto di origine, nella direzione scelta da chi lo crea. In ogni punto della sua lunghezza, la larghezza del cono è pari alla distanza di quel punto dal punto di origine: per esempio, a 4,5 metri dal punto di origine il cono è largo 4,5 metri. L'effetto che crea il cono ne specifica la lunghezza massima.\n\nIl punto di origine del cono non è compreso nell'area di effetto, a meno che il suo creatore non decida altrimenti.",
				new[] { "cono", "coni" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "cover", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Cover", "Cover provides a degree of protection to a target behind it. There are three degrees of cover, each of which provides a different benefit to a target: Half Cover (+2 bonus to AC and Dexterity saving throws), Three-Quarters Cover (+5 bonus to AC and Dexterity saving throws), and Total Cover (can't be targeted directly). If behind more than one degree of cover, a target benefits only from the most protective degree.",
				new[] { "Half Cover", "Three-Quarters Cover", "Total Cover" }),
			it: ("Copertura", "La copertura offre un certo grado di protezione al bersaglio che vi si trova dietro. Esistono tre gradi di copertura, ognuno con un beneficio diverso: mezza copertura (bonus di +2 alla CA e ai tiri salvezza su Destrezza), copertura di tre quarti (bonus di +5 alla CA e ai tiri salvezza su Destrezza) e copertura totale (il bersaglio non può essere preso di mira direttamente). Se si trova dietro più fonti di copertura, il bersaglio beneficia soltanto del grado più protettivo.",
				new[] { "mezza copertura", "copertura di tre quarti", "copertura dei tre quarti", "tre quarti di copertura", "copertura totale" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "crawling", RuleCategory.Rule,
			related: new[] { "speed" },
			en: ("Crawling", "While you're crawling, each foot of movement costs 1 extra foot (2 extra feet in Difficult Terrain).",
				Array.Empty<string>()),
			it: ("Strisciare", "Mentre striscia, ogni metro di movimento costa al personaggio 1 metro in più (2 metri in più su terreno difficile).",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "creature", RuleCategory.Rule,
			related: new[] { "creature-type" },
			en: ("Creature", "Any being in the game, including a player's character, is a creature.",
				Array.Empty<string>()),
			it: ("Creatura", "Ogni essere presente nel gioco, compresi i personaggi dei giocatori, è una creatura.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "creature-type", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Creature Type", "Every creature, including every player character, has a tag in the rules that identifies the type of creature it is. Most player characters are of the Humanoid type. These are the game's creature types:\n\n| Aberration | Elemental | Monstrosity |\n|---|---|---|\n| Beast | Fey | Ooze |\n| Celestial | Fiend | Plant |\n| Construct | Giant | Undead |\n| Dragon | Humanoid |  |\n\nThe types don't have rules themselves, but some rules in the game affect creatures of certain types in different ways.",
				Array.Empty<string>()),
			it: ("Tipo di creatura", "Ogni creatura, compreso ogni personaggio giocante, ha un'etichetta che ne indica il tipo. La maggior parte dei personaggi giocanti appartiene al tipo umanoide. Questi sono i tipi di creatura del gioco:\n\n| Aberrazione | Elementale | Mostruosità |\n|---|---|---|\n| Bestia | Folletto | Non morto |\n| Celestiale | Gigante | Vegetale |\n| Costrutto | Immondo | Umanoide |\n| Drago | Melma | |\n\nI tipi non hanno regole proprie, ma alcune regole influiscono in modo diverso sulle creature di certi tipi.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "critical-hit", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Critical Hit", "If you roll a 20 on the d20 for an attack roll, you score a Critical Hit, and the attack hits regardless of any modifiers or the target's AC. A Critical Hit lets you roll extra dice for the attack's damage against the target. Roll all of the attack's damage dice twice and add them together. Then add any relevant modifiers.",
				new[] { "Critical Hit", "Critical Hits" }),
			it: ("Colpo critico", "Se ottiene 20 sul d20 di un tiro per colpire, l'attaccante mette a segno un colpo critico: l'attacco va a segno a prescindere da qualsiasi modificatore e dalla CA del bersaglio. Un colpo critico permette di tirare dadi aggiuntivi per i danni dell'attacco: si tirano due volte tutti i dadi dei danni dell'attacco e si sommano, poi si aggiungono i modificatori pertinenti.",
				new[] { "colpo critico", "colpi critici" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "cube", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Cube", "A Cube is an area of effect that extends in straight lines from a point of origin located anywhere on a face of the Cube. The effect that creates a Cube specifies its size, which is the length of each side.\n\nA Cube's point of origin isn't included in the area of effect unless its creator decides otherwise.",
				new[] { "=Cube", "=Cubes" }),
			it: ("Cubo", "Un cubo è un'area di effetto che si estende in linea retta da un punto di origine situato in qualsiasi punto di una delle sue facce. L'effetto che crea il cubo ne specifica la dimensione, cioè la lunghezza di ciascun lato.\n\nIl punto di origine del cubo non è compreso nell'area di effetto, a meno che il suo creatore non decida altrimenti.",
				new[] { "cubo", "cubi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "curses", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Curses", "Some game effects curse a creature or an object. The effect that confers a curse defines what the curse does. Curses can be removed by the _Remove Curse_ and _Greater Restoration_ spells or other magic that explicitly ends curses.",
				Array.Empty<string>()),
			it: ("Maledizioni", "Alcuni effetti di gioco maledicono una creatura o un oggetto; è l'effetto stesso a stabilire cosa fa la maledizione. Le maledizioni possono essere rimosse dagli incantesimi _Rimuovi Maledizione_ e _Ristorare Superiore_ o da altra magia che ponga fine esplicitamente alle maledizioni.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "cylinder", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Cylinder", "A Cylinder is an area of effect that extends in straight lines from a point of origin located at the center of the circular top or bottom of the Cylinder. The effect that creates a Cylinder specifies the radius of the Cylinder's base and the Cylinder's height.\n\nA Cylinder's point of origin is included in the area of effect.",
				new[] { "=Cylinder", "=Cylinders" }),
			it: ("Cilindro", "Un cilindro è un'area di effetto che si estende in linea retta da un punto di origine situato al centro della base circolare superiore o inferiore del cilindro. L'effetto che crea il cilindro ne specifica il raggio della base e l'altezza.\n\nIl punto di origine del cilindro è compreso nell'area di effetto.",
				new[] { "cilindro", "cilindri" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "d20-test", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("D20 Test", "D20 Tests encompass the three main d20 rolls of the game: ability checks, attack rolls, and saving throws. If something in the game affects D20 Tests, it affects all three of these rolls. The GM determines whether a D20 Test is warranted in a given circumstance.",
				Array.Empty<string>()),
			it: ("Prova con d20", "Le prove con d20 comprendono i tre tiri di d20 principali del gioco: prove di caratteristica, tiri per colpire e tiri salvezza. Tutto ciò che nel gioco influenza le prove con d20 influenza tutti e tre questi tiri. Il DM stabilisce quando una prova con d20 è necessaria.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "damage", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Damage", "Damage represents harm that causes a creature or an object to lose Hit Points.",
				Array.Empty<string>()),
			it: ("Danni", "I danni rappresentano le ferite o i guasti che fanno perdere punti ferita a una creatura o a un oggetto.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "damage-roll", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Damage Roll", "A damage roll is a die roll, adjusted by any applicable modifiers, that deals damage to a target.",
				Array.Empty<string>()),
			it: ("Tiro per i danni", "Un tiro per i danni è un tiro di dadi, a cui si applicano gli eventuali modificatori, che infligge danni a un bersaglio.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "damage-threshold", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Damage Threshold", "A creature or an object that has a damage threshold has Immunity to all damage unless it takes an amount of damage from a single attack or effect equal to or greater than its damage threshold, in which case it takes that entire instance of damage. Any damage that fails to meet or exceed the damage threshold is superficial and doesn't reduce Hit Points. For example, if an object has a damage threshold of 10, the object takes no damage if 9 damage is dealt to it, since that damage fails to exceed the threshold. If the same object is dealt 11 damage, it takes all of that damage.",
				new[] { "Damage Threshold" }),
			it: ("Soglia di danno", "Una creatura o un oggetto con una soglia di danno ha immunità a tutti i danni, a meno che non subisca da un singolo attacco o effetto un ammontare di danni pari o superiore alla sua soglia: in quel caso subisce tutti quei danni. I danni che non raggiungono la soglia sono superficiali e non riducono i punti ferita. Per esempio, un oggetto con soglia di danno 10 non subisce alcun danno se ne riceve 9, perché non raggiungono la soglia; se ne riceve 11, li subisce tutti.",
				new[] { "soglia di danno" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "damage-types", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Damage Types", "Attacks and other harmful effects deal different types of damage. Damage types have no rules of their own, but other rules, such as Resistance, rely on the types. The Damage Types table offers examples to help a GM assign a type to a new effect.\n\n**Damage Types**\n\n| Type | Examples |\n|---|---|\n| Acid | Corrosive liquids, digestive enzymes |\n| Bludgeoning | Blunt objects, constriction, falling |\n| Cold | Freezing water, icy blasts |\n| Fire | Flames, unbearable heat |\n| Force | Pure magical energy |\n| Lightning | Electricity |\n| Necrotic | Life-draining energy |\n| Piercing | Fangs, puncturing objects |\n| Poison | Toxic gas, venom |\n| Psychic | Mind-rending energy |\n| Radiant | Holy energy, searing radiation |\n| Slashing | Claws, cutting objects |\n| Thunder | Concussive sound |",
				Array.Empty<string>()),
			it: ("Tipi di danno", "Gli attacchi e gli altri effetti dannosi infliggono danni di tipi diversi. I tipi di danno non hanno regole proprie, ma altre regole, come la resistenza, si basano su di essi. La tabella \"Tipi di danno\" propone esempi che aiutano il DM ad assegnare un tipo a un nuovo effetto.\n\n**Tipi di danno**\n\n| Tipo | Esempi |\n|---|---|\n| Acido | Liquidi corrosivi, enzimi digestivi |\n| Contundente | Oggetti smussati, stritolamento, cadute |\n| Freddo | Acqua gelida, raffiche di ghiaccio |\n| Fuoco | Fiamme, calore insopportabile |\n| Forza | Pura energia magica |\n| Fulmine | Elettricità |\n| Necrotico | Energia che prosciuga la vita |\n| Perforante | Zanne, oggetti appuntiti |\n| Veleno | Gas tossici, veleni |\n| Psichico | Energia che lacera la mente |\n| Radioso | Energia sacra, radiazioni ardenti |\n| Tagliente | Artigli, oggetti affilati |\n| Tuono | Suoni assordanti |",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "darkness", RuleCategory.Rule,
			related: new[] { "heavily-obscured" },
			en: ("Darkness", "An area of Darkness is Heavily Obscured.",
				Array.Empty<string>()),
			it: ("Oscurità", "Un'area di oscurità è in pesante oscurità.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "darkvision", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Darkvision", "If you have Darkvision, you can see in Dim Light within a specified range as if it were Bright Light and in Darkness within that range as if it were Dim Light. You discern colors in that Darkness only as shades of gray.",
				new[] { "Darkvision" }),
			it: ("Scurovisione", "Una creatura con scurovisione vede entro un certo raggio nella luce fioca come se fosse luce intensa, e nell'oscurità come se fosse luce fioca. Nell'oscurità distingue i colori soltanto come sfumature di grigio.",
				new[] { "scurovisione" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "dead", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Dead", "A dead creature has no Hit Points and can't regain them unless it is first revived by magic such as the _Raise Dead_ or _Revivify_ spell. When such a spell is cast, the spirit knows who is casting it and can refuse. The spirit of a dead creature has left the body and departed for the Outer Planes, and reviving the creature requires calling the spirit back.\n\nIf the creature returns to life, the revival effect determines the creature's current Hit Points. Unless otherwise stated, the creature returns to life with any conditions, magical contagions, or curses that were affecting it at death if the durations of those effects are still ongoing. If the creature died with any Exhaustion levels, it returns with 1 fewer level. If the creature had Attunement to one or more magic items, it is no longer attuned to them.",
				Array.Empty<string>()),
			it: ("Morte", "Una creatura morta non ha punti ferita e non può recuperarne finché non viene riportata in vita da una magia come gli incantesimi _Rianimare Morti_ o _Rinascita_. Quando viene lanciato un incantesimo del genere, lo spirito sa chi lo sta lanciando e può rifiutarsi di tornare. Lo spirito di una creatura morta ha lasciato il corpo per i Piani Esterni, e riportarla in vita significa richiamarlo.\n\nSe la creatura torna in vita, è l'effetto che la rianima a stabilirne i punti ferita attuali. Salvo diversa indicazione, la creatura torna in vita con le condizioni, i contagi magici e le maledizioni che la affliggevano al momento della morte, se la loro durata non è ancora terminata. Se è morta con dei livelli di indebolimento, torna in vita con un livello in meno. Se era in sintonia con uno o più oggetti magici, non lo è più.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "death-saving-throw", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Death Saving Throw", "A player character must make a Death Saving Throw (also called a Death Save) if they start their turn with 0 Hit Points.",
				new[] { "Death Saving Throw", "Death Saving Throws", "Death Save", "Death Saves" }),
			it: ("Tiro salvezza contro morte", "Un personaggio giocante deve effettuare un tiro salvezza contro morte se inizia il suo turno con 0 punti ferita.",
				new[] { "tiro salvezza contro morte", "tiri salvezza contro morte", "tiro salvezza contro la morte", "tiri salvezza contro la morte" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "dehydration", RuleCategory.Hazard,
			related: new[] { "exhaustion" },
			en: ("Dehydration", "A creature requires an amount of water per day based on its size, as shown in the Water Needs per Day table. A creature that drinks less than half the required water for a day gains 1 Exhaustion level at the day's end. Exhaustion caused by dehydration can't be removed until the creature drinks the full amount of water required for a day.",
				Array.Empty<string>()),
			it: ("Disidratazione", "Ogni creatura ha bisogno ogni giorno di una quantità d'acqua che dipende dalla sua taglia, come indicato nella tabella \"Fabbisogno d'acqua giornaliero\". Una creatura che in un giorno beve meno della metà dell'acqua necessaria ottiene 1 livello di indebolimento alla fine della giornata. L'indebolimento causato dalla disidratazione non può essere rimosso finché la creatura non beve l'intera quantità d'acqua giornaliera.\n\n**Fabbisogno d'acqua giornaliero**\n\n| Taglia | Acqua | Taglia | Acqua |\n|---|---|---|---|\n| Minuscola | 1 litro | Grande | 16 litri |\n| Piccola | 4 litri | Enorme | 64 litri |\n| Media | 4 litri | Mastodontica | 256 litri |",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "difficult-terrain", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Difficult Terrain", "If a space is Difficult Terrain, every foot of movement in that space costs 1 extra foot. For example, moving 5 feet through Difficult Terrain costs 10 feet of movement. Difficult Terrain isn't cumulative; either a space is Difficult Terrain or it isn't.\n\nA space is Difficult Terrain if the space contains any of the following or something similar:\n\n- A creature that isn't Tiny or your ally\n- Furniture that is sized for creatures of your size or larger\n- Heavy snow, ice, rubble, or undergrowth\n- Liquid that's between shin- and waist-deep\n- A narrow opening sized for a creature one size smaller than you\n- A slope of 20 degrees or more",
				new[] { "Difficult Terrain" }),
			it: ("Terreno difficile", "In uno spazio di terreno difficile, ogni metro di movimento costa 1 metro in più: per esempio, percorrere 1,5 metri di terreno difficile costa 3 metri di movimento. Il terreno difficile non è cumulativo: uno spazio o è terreno difficile o non lo è.\n\nUno spazio è terreno difficile se contiene uno degli elementi seguenti, o qualcosa di simile:\n\n- Una creatura che non è Minuscola e non è alleata del personaggio\n- Mobili adatti a creature della taglia del personaggio o più grandi\n- Neve alta, ghiaccio, macerie o sottobosco fitto\n- Un liquido profondo tra lo stinco e la vita\n- Un passaggio stretto, adatto a una creatura di una taglia inferiore a quella del personaggio\n- Un pendio di 20 gradi o più",
				new[] { "terreno difficile" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "difficulty-class", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Difficulty Class", "A Difficulty Class (DC) is the target number for an ability check or a saving throw.",
				Array.Empty<string>()),
			it: ("Classe Difficoltà", "La Classe Difficoltà (CD) è il numero bersaglio di una prova di caratteristica o di un tiro salvezza.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "dim-light", RuleCategory.Rule,
			related: new[] { "lightly-obscured" },
			en: ("Dim Light", "An area with Dim Light is Lightly Obscured.",
				new[] { "Dim Light" }),
			it: ("Luce fioca", "Un'area di luce fioca è in leggera oscurità.",
				new[] { "luce fioca" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "disadvantage", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Disadvantage", "If you have Disadvantage on a D20 Test, roll two d20s and use the lower roll. A roll can't be affected by more than one Disadvantage, and Advantage and Disadvantage on the same roll cancel each other.",
				new[] { "Disadvantage" }),
			it: ("Svantaggio", "Quando un personaggio subisce svantaggio a una prova con d20, tira due d20 e usa il risultato più basso. Un tiro non può essere influenzato da più di uno svantaggio, e vantaggio e svantaggio sullo stesso tiro si annullano a vicenda.",
				new[] { "svantaggio" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "emanation", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Emanation", "An Emanation is an area of effect that extends in straight lines from a creature or an object in all directions. The effect that creates an Emanation specifies the distance it extends.\n\nAn Emanation moves with the creature or object that is its origin unless it is an instantaneous or a stationary effect.\n\nAn Emanation's origin (creature or object) isn't included in the area of effect unless its creator decides otherwise.",
				new[] { "Emanation", "Emanations" }),
			it: ("Emanazione", "Un'emanazione è un'area di effetto che si estende in linea retta in tutte le direzioni a partire da una creatura o da un oggetto. L'effetto che la crea ne specifica la distanza.\n\nL'emanazione si sposta insieme alla creatura o all'oggetto da cui ha origine, a meno che non sia un effetto istantaneo o fisso.\n\nLa creatura o l'oggetto da cui ha origine l'emanazione non è compreso nell'area di effetto, a meno che il suo creatore non decida altrimenti.",
				new[] { "emanazione", "emanazioni" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "encounter", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Encounter", "An encounter is a scene in an adventure that is part of at least one of the game's three pillars: social interaction, exploration, or combat.",
				Array.Empty<string>()),
			it: ("Incontro", "Un incontro è una scena di un'avventura che riguarda almeno uno dei tre pilastri del gioco: interazione sociale, esplorazione o combattimento.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "enemy", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Enemy", "A creature is your enemy if it fights against you in combat, actively works to harm you, or is designated as your enemy by the rules or GM.",
				Array.Empty<string>()),
			it: ("Nemico", "Una creatura è nemica del personaggio se lo combatte, se si adopera attivamente per nuocergli o se le regole o il DM la designano come tale.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "experience-points", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Experience Points", "As they overcome challenges and complete adventures, characters earn Experience Points (XP), which are awarded by the Game Master. When a character's XP total crosses certain thresholds, the character's level increases.",
				Array.Empty<string>()),
			it: ("Punti esperienza", "Superando sfide e completando avventure, i personaggi guadagnano punti esperienza (PE), assegnati dal Dungeon Master. Quando il totale di PE di un personaggio supera determinate soglie, il suo livello aumenta.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "expertise", RuleCategory.Rule,
			related: new[] { "proficiency" },
			en: ("Expertise", "Expertise is a feature that enhances your use of a skill proficiency. When you make an ability check with a skill proficiency in which you have Expertise, your Proficiency Bonus is doubled for that check unless the bonus is doubled by another feature.\n\nIf you gain Expertise, you gain it in one skill in which you have proficiency. You can't have Expertise in the same skill proficiency more than once.",
				new[] { "Expertise" }),
			it: ("Maestria", "La maestria è un privilegio che potenzia l'uso di un'abilità in cui si ha competenza. Quando il personaggio effettua una prova di caratteristica con un'abilità in cui ha maestria, il suo bonus di competenza raddoppia per quella prova, a meno che non sia già raddoppiato da un altro privilegio.\n\nChi ottiene maestria la ottiene in un'abilità in cui ha competenza. Non si può avere maestria più di una volta nella stessa abilità.",
				new[] { "~maestria(?! negli)(?! nelle)(?! nei)(?! de[il])(?! della)(?! delle)(?! artigianale)" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "falling", RuleCategory.Hazard,
			related: Array.Empty<string>(),
			en: ("Falling", "A creature that falls takes 1d6 Bludgeoning damage at the end of the fall for every 10 feet it fell, to a maximum of 20d6. When the creature lands, it has the Prone condition unless it avoids taking any damage from the fall.\n\nA creature that falls into water or another liquid can use its Reaction to make a DC 15 Strength (Athletics) or Dexterity (Acrobatics) check to hit the surface head or feet first. On a successful check, any damage resulting from the fall is halved.",
				Array.Empty<string>()),
			it: ("Caduta", "Una creatura che cade subisce, al termine della caduta, 1d6 danni contundenti per ogni 3 metri di caduta, fino a un massimo di 20d6. Quando atterra, assume la condizione di prono, a meno che non eviti tutti i danni della caduta.\n\nUna creatura che cade in acqua o in un altro liquido può usare la sua reazione per effettuare una prova di Forza (Atletica) o di Destrezza (Acrobazia) con CD 15 ed entrare nel liquido di testa o di piedi: se la supera, i danni della caduta sono dimezzati.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "flying", RuleCategory.Rule,
			related: new[] { "falling", "fly-speed" },
			en: ("Flying", "A variety of effects allow a creature to fly. While flying, you fall if you have the Incapacitated or Prone condition or your Fly Speed is reduced to 0. You can stay aloft in those circumstances if you can hover.",
				Array.Empty<string>()),
			it: ("Volare", "Vari effetti permettono a una creatura di volare. Mentre vola, il personaggio cade se ha la condizione di incapacitato o di prono, oppure se la sua velocità di volo scende a 0. In queste circostanze può restare in aria solo se è in grado di fluttuare.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "fly-speed", RuleCategory.Rule,
			related: new[] { "flying", "speed" },
			en: ("Fly Speed", "A Fly Speed can be used to travel through the air. While you have a Fly Speed, you can stay aloft until you land, fall, or die.",
				new[] { "Fly Speed" }),
			it: ("Velocità di volo", "La velocità di volo permette di spostarsi in aria. Finché ha una velocità di volo, il personaggio può restare in aria fino a quando non atterra, cade o muore.",
				new[] { "velocità di volo" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "friendly", RuleCategory.Attitude,
			related: new[] { "influence" },
			en: ("Friendly", "A Friendly creature views you favorably. You have Advantage on an ability check to influence a Friendly creature.",
				Array.Empty<string>()),
			it: ("Amichevole", "Una creatura amichevole vede di buon occhio il personaggio, che ha vantaggio alle prove di caratteristica effettuate per influenzarla.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "grappling", RuleCategory.Rule,
			related: new[] { "unarmed-strike", "grappled" },
			en: ("Grappling", "A creature can grapple another creature. Characters typically grapple by using an Unarmed Strike. Many monsters have special attacks that allow them to quickly grapple prey. However a grapple is initiated, it follows these rules.** Successfully grappling a creature gives it the Grappled condition.\n\n**One Grapple per Hand.** A creature must have a hand free to grapple another creature. Some stat blocks and game effects allow a creature to grapple using a tentacle, a maw, or another body part. Whatever part a grappler uses, it can grapple only one creature at a time with that part, and the grappler can't use that part to target another creature unless it ends the grapple.\n\n**Ending a Grapple.** A Grappled creature can use its action to make a Strength (Athletics) or Dexterity (Acrobatics) check against the grapple's escape DC, ending the condition on itself on a success. The condition also ends if the grappler has the Incapacitated condition or if the distance between the Grappled target and the grappler exceeds the grapple's range. In addition, the grappler can release the target at any time (no action required).",
				Array.Empty<string>()),
			it: ("Afferrare", "Una creatura può afferrarne un'altra. I personaggi di solito lo fanno con un colpo senz'armi, mentre molti mostri dispongono di attacchi speciali che permettono di afferrare rapidamente la preda. Comunque sia iniziata la presa, segue queste regole.\n\n**Condizione di afferrato.** Afferrare con successo una creatura le infligge la condizione di afferrato.\n\n**Una presa per mano.** Per afferrare un'altra creatura serve una mano libera. Alcune schede delle statistiche ed effetti di gioco permettono di afferrare con un tentacolo, con le fauci o con un'altra parte del corpo. Qualunque parte usi, chi afferra può trattenere con essa una sola creatura alla volta e non può usarla per prendere di mira un'altra creatura finché non pone fine alla presa.\n\n**Porre fine alla presa.** Una creatura afferrata può usare la sua azione per effettuare una prova di Forza (Atletica) o di Destrezza (Acrobazia) contro la CD di fuga della presa: se la supera, la condizione termina. La condizione termina anche se chi afferra ha la condizione di incapacitato o se la distanza tra lui e il bersaglio afferrato supera la portata della presa. Inoltre, chi afferra può liberare il bersaglio in qualsiasi momento (non richiede alcuna azione).",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "hazard", RuleCategory.Rule,
			related: new[] { "burning", "dehydration", "falling", "malnutrition", "suffocation" },
			en: ("Hazard", "A hazard is an environmental danger.",
				Array.Empty<string>()),
			it: ("Pericolo", "Un pericolo è una minaccia legata all'ambiente, come le fiamme, la disidratazione, le cadute, la malnutrizione e il soffocamento.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "healing", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Healing", "Healing is how you regain Hit Points.",
				Array.Empty<string>()),
			it: ("Guarigione", "La guarigione è il modo in cui si recuperano i punti ferita.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "heavily-obscured", RuleCategory.Rule,
			related: new[] { "blinded", "darkness" },
			en: ("Heavily Obscured", "You have the Blinded condition while trying to see something in a Heavily Obscured space.",
				new[] { "Heavily Obscured" }),
			it: ("Pesante oscurità", "Chi cerca di vedere qualcosa in uno spazio in pesante oscurità ha la condizione di accecato.",
				new[] { "pesante oscurità", "pesantemente oscurato", "pesantemente oscurata", "pesantemente oscurati", "pesantemente oscurate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "heroic-inspiration", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Heroic Inspiration", "If you (a player character) have Heroic Inspiration, you can expend it to reroll any die immediately after rolling it, and you must use the new roll.\n\nIf you gain Heroic Inspiration but already have it, it's lost unless you give it to a player character who lacks it.",
				new[] { "Heroic Inspiration" }),
			it: ("Ispirazione eroica", "Un personaggio giocante che ha ispirazione eroica può spenderla per ripetere un qualsiasi tiro di dado subito dopo averlo effettuato, e deve tenere il nuovo risultato.\n\nSe ottiene ispirazione eroica quando ne dispone già, la perde, a meno che non la ceda a un personaggio giocante che ne è privo.",
				new[] { "ispirazione eroica" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "high-jump", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("High Jump", "When you make a High Jump, you leap into the air a number of feet equal to 3 plus your Strength modifier (minimum of 0 feet) if you move at least 10 feet on foot immediately before the jump. When you make a standing High Jump, you can jump only half that distance. Either way, each foot of the jump costs a foot of movement.\n\nYou can extend your arms half your height above yourself during the jump. Thus, you can reach a distance equal to the height of the jump plus 1½ times your height.",
				Array.Empty<string>()),
			it: ("Salto in alto", "Con un salto in alto, il personaggio balza in aria per (3 + il suo modificatore di Forza) × 30 centimetri (minimo 0), se si è mosso di almeno 3 metri a piedi subito prima di saltare. Da fermo può saltare solo la metà di quell'altezza. In entrambi i casi, ogni metro del salto costa un metro di movimento.\n\nDurante il salto può allungare le braccia sopra la testa per metà della sua altezza: può quindi raggiungere un'altezza pari a quella del salto più una volta e mezza la propria statura.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "hit-point-dice", RuleCategory.Rule,
			related: new[] { "short-rest" },
			en: ("Hit Point Dice", "Hit Point Dice, or Hit Dice for short, help determine a player character's Hit Point maximum, as explained in \"Character Creation.\" Most monsters also have Hit Dice. A creature can spend Hit Dice during a Short Rest to regain Hit Points.",
				new[] { "Hit Point Dice", "Hit Point Die", "Hit Dice", "Hit Die" }),
			it: ("Dadi Vita", "I Dadi Vita contribuiscono a determinare i punti ferita massimi di un personaggio giocante, come spiegato nelle regole di creazione del personaggio; anche la maggior parte dei mostri ha dei Dadi Vita. Durante un riposo breve una creatura può spendere Dadi Vita per recuperare punti ferita.",
				new[] { "dadi vita", "dado vita" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "hit-points", RuleCategory.Rule,
			related: new[] { "breaking-objects" },
			en: ("Hit Points", "Hit Points (HP) are a measure of how difficult it is to kill or destroy a creature or an object. Damage reduces Hit Points, and healing restores them. You can't have more Hit Points than your Hit Point maximum, and you can't have less than 0.",
				Array.Empty<string>()),
			it: ("Punti ferita", "I punti ferita (PF) misurano quanto è difficile uccidere o distruggere una creatura o un oggetto. I danni riducono i punti ferita, la guarigione li ripristina. Non si possono avere più punti ferita del proprio massimo, né meno di 0.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "hostile", RuleCategory.Attitude,
			related: new[] { "influence" },
			en: ("Hostile", "A Hostile creature views you unfavorably. You have Disadvantage on an ability check to influence a Hostile creature.",
				Array.Empty<string>()),
			it: ("Ostile", "Una creatura ostile vede di cattivo occhio il personaggio, che subisce svantaggio alle prove di caratteristica effettuate per influenzarla.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "hover", RuleCategory.Rule,
			related: new[] { "flying" },
			en: ("Hover", "Some creatures can hover, as noted in their stat blocks, and some spells and other effects grant the ability to hover. Hovering while flying prevents you from falling in certain circumstances.",
				Array.Empty<string>()),
			it: ("Fluttuare", "Alcune creature sono in grado di fluttuare, come indicato nella loro scheda delle statistiche, e alcuni incantesimi ed effetti concedono questa capacità. Fluttuare mentre si vola impedisce di cadere in certe circostanze.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "illusions", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Illusions", "Spells and other effects sometimes create magical illusions. Such an effect defines what the illusion does and which senses or mental faculties it deceives.\n\nIf an illusion manifests in space, the illusion is insubstantial and weightless, yet it seems to be affected by the environment as if the illusion were real unless the effect that created it specifies otherwise. For example, a visual illusion of a creature casts shadows and reflections, and wind appears to affect the illusory creature. Similarly, an audible illusion echoes in an echoey space.",
				Array.Empty<string>()),
			it: ("Illusioni", "Incantesimi e altri effetti a volte creano illusioni magiche. È l'effetto stesso a definire cosa fa l'illusione e quali sensi o facoltà mentali inganna.\n\nSe un'illusione si manifesta nello spazio, è incorporea e priva di peso, ma sembra subire l'influenza dell'ambiente come se fosse reale, a meno che l'effetto che l'ha creata non dica altrimenti. Per esempio, l'illusione visiva di una creatura proietta ombre e riflessi e sembra mossa dal vento; allo stesso modo, un'illusione sonora riecheggia in un ambiente che produce eco.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "immunity", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Immunity", "If you have Immunity to a damage type or a condition, it doesn't affect you in any way.",
				new[] { "Immunity" }),
			it: ("Immunità", "Se un personaggio ha immunità a un tipo di danno o a una condizione, quel danno o quella condizione non hanno alcun effetto su di lui.",
				new[] { "immunità" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "improvised-weapons", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Improvised Weapons", "An improvised weapon is an object wielded as a makeshift weapon, such as broken glass, a table leg, or a frying pan. A Simple or Martial weapon also counts as an improvised weapon if it's wielded in a way contrary to its design; if you use a Ranged weapon to make a melee attack or throw a Melee weapon that lacks the Thrown property, the weapon counts as an improvised weapon. An improvised weapon follows the rules below.\n\n**Proficiency.** Don't add your Proficiency Bonus to attack rolls with an improvised weapon.\n\n**Damage.** On a hit, the weapon deals 1d4 damage of a type the GM thinks is appropriate for the object.\n\n**Range.** If you throw the weapon, it has a normal range of 20 feet and a long range of 60 feet.\n\n**Weapon Equivalents.** If an improvised weapon resembles a Simple or Martial weapon, the GM may say it functions as that weapon and uses that weapon's rules. For example, the GM could treat a table leg as a Club.",
				new[] { "improvised weapon", "improvised weapons" }),
			it: ("Armi improvvisate", "Un'arma improvvisata è un oggetto impugnato come arma di fortuna, come un coccio di vetro, la gamba di un tavolo o una padella. Anche un'arma semplice o da guerra conta come arma improvvisata se viene usata in modo contrario alla sua natura: se si usa un'arma a distanza per un attacco in mischia, o si lancia un'arma da mischia che non ha la proprietà Lancio. Un'arma improvvisata segue queste regole.\n\n**Competenza.** Ai tiri per colpire con un'arma improvvisata non si aggiunge il bonus di competenza.\n\n**Danni.** Se colpisce, l'arma infligge 1d4 danni di un tipo che il DM ritiene adatto all'oggetto.\n\n**Gittata.** Se viene lanciata, l'arma ha una gittata normale di 6 metri e una gittata lunga di 18 metri.\n\n**Armi equivalenti.** Se un'arma improvvisata somiglia a un'arma semplice o da guerra, il DM può stabilire che funzioni come quell'arma e ne segua le regole: per esempio, può trattare la gamba di un tavolo come un randello.",
				new[] { "arma improvvisata", "armi improvvisate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "indifferent", RuleCategory.Attitude,
			related: new[] { "influence" },
			en: ("Indifferent", "An Indifferent creature has no desire to help or hinder you. Indifferent is the default attitude of a monster.",
				Array.Empty<string>()),
			it: ("Indifferente", "Una creatura indifferente non ha alcun desiderio di aiutare o di ostacolare il personaggio. È l'atteggiamento predefinito di un mostro.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "initiative", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Initiative", "Initiative determines the order of turns during combat. The combat rules in \"Playing the Game\" explain how to roll Initiative.\n\nSometimes a GM might have combatants use their Initiative scores instead of rolling Initiative. Your Initiative score equals 10 plus your Dexterity modifier. If you have Advantage on Initiative rolls, increase your Initiative score by 5. If you have Disadvantage on those rolls, decrease that score by 5.",
				new[] { "=Initiative" }),
			it: ("Iniziativa", "L'iniziativa determina l'ordine dei turni durante il combattimento; le regole del combattimento spiegano come tirarla.\n\nA volte il DM può chiedere ai combattenti di usare il loro punteggio di iniziativa invece di tirare. Il punteggio di iniziativa è pari a 10 + il modificatore di Destrezza; aumenta di 5 se il personaggio ha vantaggio ai tiri per l'iniziativa e diminuisce di 5 se vi subisce svantaggio.",
				new[] { "iniziativa" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "jumping", RuleCategory.Rule,
			related: new[] { "long-jump", "high-jump" },
			en: ("Jumping", "When you jump, you make either a Long Jump (horizontal) or a High Jump (vertical).",
				Array.Empty<string>()),
			it: ("Saltare", "Quando salta, il personaggio effettua un salto in lungo (orizzontale) o un salto in alto (verticale).",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "knocking-out-a-creature", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Knocking Out a Creature", "When you would reduce a creature to 0 Hit Points with a melee attack, you can instead reduce the creature to 1 Hit Point. The creature then has the Unconscious condition and starts a Short Rest.\n\nThe creature remains Unconscious until it regains any Hit Points or until someone uses an action to administer first aid to it, which requires a successful DC 10 Wisdom (Medicine) check.",
				Array.Empty<string>()),
			it: ("Tramortire una creatura", "Quando con un attacco in mischia ridurrebbe una creatura a 0 punti ferita, il personaggio può invece ridurla a 1 punto ferita. La creatura ottiene allora la condizione di privo di sensi e inizia un riposo breve.\n\nLa creatura resta priva di sensi finché non recupera punti ferita o finché qualcuno non usa un'azione per prestarle il primo soccorso, superando una prova di Saggezza (Medicina) con CD 10.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "lightly-obscured", RuleCategory.Rule,
			related: new[] { "dim-light" },
			en: ("Lightly Obscured", "You have Disadvantage on Wisdom (Perception) checks to see something in a Lightly Obscured space.",
				new[] { "Lightly Obscured" }),
			it: ("Leggera oscurità", "Chi cerca di vedere qualcosa in uno spazio in leggera oscurità subisce svantaggio alle prove di Saggezza (Percezione).",
				new[] { "leggera oscurità", "leggermente oscurato", "leggermente oscurata", "leggermente oscurati", "leggermente oscurate" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "line", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Line", "A Line is an area of effect that extends from a point of origin in a straight path along its length and covers an area defined by its width. The effect that creates a Line specifies its length and width.\n\nA Line's point of origin isn't included in the area of effect unless its creator decides otherwise.",
				new[] { "=Line", "=Lines" }),
			it: ("Linea", "Una linea è un'area di effetto che si estende in linea retta da un punto di origine per tutta la sua lunghezza e copre una superficie definita dalla sua larghezza. L'effetto che crea la linea ne specifica lunghezza e larghezza.\n\nIl punto di origine della linea non è compreso nell'area di effetto, a meno che il suo creatore non decida altrimenti.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "long-jump", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Long Jump", "When you make a Long Jump, you leap horizontally a number of feet up to your Strength score if you move at least 10 feet immediately before the jump. When you make a standing Long Jump, you can leap only half that distance. Either way, each foot you jump costs a foot of movement.\n\nIf you land in Difficult Terrain, you must succeed on a DC 10 Dexterity (Acrobatics) check or have the Prone condition.\n\nThis Long Jump rule assumes that the height of the jump doesn't matter, such as a jump across a stream or chasm. At your GM's option, you must succeed on a DC 10 Strength (Athletics) check to clear a low obstacle (no taller than a quarter of the jump's distance), such as a hedge or low wall. Otherwise, you hit the obstacle.",
				Array.Empty<string>()),
			it: ("Salto in lungo", "Con un salto in lungo, il personaggio balza in orizzontale fino a 30 centimetri per ogni punto del suo punteggio di Forza, se si è mosso di almeno 3 metri subito prima di saltare. Da fermo può saltare solo la metà di quella distanza. In entrambi i casi, ogni metro del salto costa un metro di movimento.\n\nSe atterra su terreno difficile, deve superare una prova di Destrezza (Acrobazia) con CD 10, altrimenti ottiene la condizione di prono.\n\nQuesta regola presuppone che l'altezza del salto non conti, come quando si salta un ruscello o un crepaccio. A discrezione del DM, per superare un ostacolo basso (non più alto di un quarto della lunghezza del salto), come una siepe o un muretto, serve una prova di Forza (Atletica) con CD 10 superata; altrimenti il personaggio urta l'ostacolo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "long-rest", RuleCategory.Rule,
			related: new[] { "short-rest" },
			en: ("Long Rest", "A Long Rest is a period of extended downtime—at least 8 hours—available to any creature. During a Long Rest, you sleep for at least 6 hours and perform no more than 2 hours of light activity, such as reading, talking, eating, or standing watch.\n\nDuring sleep, you have the Unconscious condition. After you finish a Long Rest, you must wait at least 16 hours before starting another one.\n\n**Benefits of the Rest.** To start a Long Rest, you must have at least 1 Hit Point. When you finish the rest, you gain the following benefits:\n\n**Regain All HP.** You regain all lost Hit Points and all spent Hit Point Dice. If your Hit Point maximum was reduced, it returns to normal.\n\n**Ability Scores Restored.** If any of your ability scores were reduced, they return to normal.\n\n**Exhaustion Reduced.** If you have the Exhaustion condition, its level decreases by 1.\n\n**Special Feature.** Some features are recharged by a Long Rest. If you have such a feature, it recharges in the way specified in its description.\n\n**Interrupting the Rest.** A Long Rest is stopped by the following interruptions:\n\n- Rolling Initiative\n- Casting a spell other than a cantrip\n- Taking any damage\n- 1 hour of walking or other physical exertion\n\nIf you rested at least 1 hour before the interruption, you gain the benefits of a Short Rest. If you do so, the rest requires 1 additional hour per interruption to finish.",
				new[] { "Long Rest", "Long Rests" }),
			it: ("Riposo lungo", "Un riposo lungo è un periodo di inattività prolungata, di almeno 8 ore, a disposizione di qualsiasi creatura. Durante un riposo lungo il personaggio dorme per almeno 6 ore e dedica non più di 2 ore ad attività leggere, come leggere, parlare, mangiare o montare la guardia.\n\nMentre dorme ha la condizione di privo di sensi. Dopo aver completato un riposo lungo, deve attendere almeno 16 ore prima di iniziarne un altro.\n\n**Benefici del riposo.** Per iniziare un riposo lungo il personaggio deve avere almeno 1 punto ferita. Quando lo completa, ottiene questi benefici.\n\n**Tutti i PF recuperati.** Recupera tutti i punti ferita perduti e tutti i Dadi Vita spesi. Se i suoi punti ferita massimi erano stati ridotti, tornano al valore normale.\n\n**Punteggi di caratteristica ripristinati.** Se uno dei suoi punteggi di caratteristica era stato ridotto, torna al valore normale.\n\n**Indebolimento ridotto.** Se ha la condizione di indebolimento, il suo livello diminuisce di 1.\n\n**Privilegi speciali.** Alcuni privilegi si ricaricano con un riposo lungo: in questo caso si ricaricano come indicato nella loro descrizione.\n\n**Interruzione del riposo.** Un riposo lungo si interrompe per questi motivi:\n\n- Tirare per l'iniziativa\n- Lanciare un incantesimo diverso da un trucchetto\n- Subire danni\n- Camminare o compiere altri sforzi fisici per 1 ora\n\nSe il personaggio aveva riposato almeno 1 ora prima dell'interruzione, ottiene i benefici di un riposo breve.\n\nPuò riprendere il riposo lungo subito dopo un'interruzione; in tal caso il riposo richiede 1 ora in più per ogni interruzione.",
				new[] { "riposo lungo", "riposi lunghi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "magical-effect", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Magical Effect", "An effect is magical if it is created by a spell, a magic item, or a phenomenon that a rule labels as magical.",
				Array.Empty<string>()),
			it: ("Effetto magico", "Un effetto è magico se è creato da un incantesimo, da un oggetto magico o da un fenomeno che una regola definisce magico.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "malnutrition", RuleCategory.Hazard,
			related: new[] { "exhaustion" },
			en: ("Malnutrition", "A creature needs an amount of food per day based on its size, as shown in the Food Needs per Day table. A creature that eats but consumes less than half the required food for a day must succeed on a DC 10 Constitution saving throw or gain 1 Exhaustion level at the day's end. A creature that eats nothing for 5 days automatically gains 1 Exhaustion level at the end of the fifth day as well as an additional level at the end of each subsequent day without food.\n\nExhaustion caused by malnutrition can't be removed until the creature eats the full amount of food required for a day.",
				Array.Empty<string>()),
			it: ("Malnutrizione", "Ogni creatura ha bisogno ogni giorno di una quantità di cibo che dipende dalla sua taglia, come indicato nella tabella \"Fabbisogno di cibo giornaliero\". Una creatura che mangia, ma in un giorno consuma meno della metà del cibo necessario, deve superare un tiro salvezza su Costituzione con CD 10, altrimenti ottiene 1 livello di indebolimento alla fine della giornata. Una creatura che non mangia nulla per 5 giorni ottiene automaticamente 1 livello di indebolimento alla fine del quinto giorno, e un altro livello alla fine di ogni giorno successivo senza cibo.\n\nL'indebolimento causato dalla malnutrizione non può essere rimosso finché la creatura non mangia l'intera quantità di cibo giornaliera.\n\n**Fabbisogno di cibo giornaliero**\n\n| Taglia | Cibo | Taglia | Cibo |\n|---|---|---|---|\n| Minuscola | 125 grammi | Grande | 2 kg |\n| Piccola | 0,5 kg | Enorme | 8 kg |\n| Media | 0,5 kg | Mastodontica | 32 kg |",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "monster", RuleCategory.Rule,
			related: new[] { "creature", "nonplayer-character" },
			en: ("Monster", "A monster is a creature controlled by the GM, even if the creature is benevolent.",
				Array.Empty<string>()),
			it: ("Mostro", "Un mostro è una creatura controllata dal DM, anche se è benevola.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "nonplayer-character", RuleCategory.Rule,
			related: new[] { "monster" },
			en: ("Nonplayer Character", "A nonplayer character (NPC) is a monster that has a personal name and a distinct personality.",
				Array.Empty<string>()),
			it: ("Personaggio non giocante", "Un personaggio non giocante (PNG) è un mostro che ha un nome proprio e una personalità distinta.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "object", RuleCategory.Rule,
			related: new[] { "breaking-objects" },
			en: ("Object", "An object is a nonliving, distinct thing. Composite things, like buildings, comprise more than one object.",
				Array.Empty<string>()),
			it: ("Oggetto", "Un oggetto è una cosa inanimata e distinta. Le cose composite, come gli edifici, sono formate da più oggetti.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "occupied-space", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Occupied Space", "A space is occupied if a creature is in it or if it is completely filled by objects.",
				Array.Empty<string>()),
			it: ("Spazio occupato", "Uno spazio è occupato se contiene una creatura o se è completamente riempito di oggetti.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "opportunity-attacks", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Opportunity Attacks", "You can make an Opportunity Attack when a creature that you can see leaves your reach using its action, its Bonus Action, its Reaction, or one of its speeds. To make the Opportunity Attack, take a Reaction to make one melee attack with a weapon or an Unarmed Strike against the provoking creature. The attack occurs right before the creature leaves your reach.",
				new[] { "Opportunity Attack", "Opportunity Attacks" }),
			it: ("Attacchi di opportunità", "Il personaggio può effettuare un attacco di opportunità quando una creatura che può vedere esce dalla sua portata usando la propria azione, azione bonus, reazione o una delle proprie velocità. Per farlo usa la sua reazione ed effettua un attacco in mischia con un'arma o con un colpo senz'armi contro la creatura che lo ha provocato. L'attacco avviene appena prima che la creatura esca dalla sua portata.",
				new[] { "attacco di opportunità", "attacchi di opportunità" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "passive-perception", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Passive Perception", "Passive Perception is a score that reflects a creature's general awareness of its surroundings. The GM uses this score when determining whether a creature notices something without consciously making a Wisdom (Perception) check.\n\nA creature's Passive Perception equals 10 plus the creature's Wisdom (Perception) check bonus. If the creature has Advantage on such checks, increase the score by 5. If the creature has Disadvantage on them, decrease the score by 5. For example, a level 1 character with a Wisdom of 15 and proficiency in Perception has a Passive Perception of 14 (10 + 2 + 2). If that character has Advantage on Wisdom (Perception) checks, the score becomes 19.",
				new[] { "Passive Perception" }),
			it: ("Percezione passiva", "La percezione passiva è un punteggio che riflette la consapevolezza generale di una creatura nei confronti di ciò che la circonda. Il DM la usa per stabilire se una creatura nota qualcosa senza effettuare consapevolmente una prova di Saggezza (Percezione).\n\nLa percezione passiva di una creatura è pari a 10 + il suo bonus alle prove di Saggezza (Percezione). Aumenta di 5 se la creatura ha vantaggio a quelle prove e diminuisce di 5 se vi subisce svantaggio. Per esempio, un personaggio di 1° livello con Saggezza 15 e competenza in Percezione ha percezione passiva 14 (10 + 2 + 2); se ha vantaggio alle prove di Saggezza (Percezione), il punteggio sale a 19.",
				new[] { "percezione passiva" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "per-day", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Per Day", "If a rule says you can use something a certain number of times per day, that means you must finish a Long Rest to use it again after you run out of uses.",
				Array.Empty<string>()),
			it: ("Al giorno", "Se una regola dice che si può usare qualcosa un certo numero di volte al giorno, significa che, esauriti gli utilizzi, bisogna completare un riposo lungo per poterla usare di nuovo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "player-character", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Player Character", "A player character is a character controlled by a player.",
				Array.Empty<string>()),
			it: ("Personaggio giocante", "Un personaggio giocante è un personaggio controllato da un giocatore.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "possession", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Possession", "Some effects cause a creature to be possessed by another creature or entity. A possessing effect defines how the possession operates. Possession can be prevented by the _Protection from Evil and Good_ spell and ended by the _Dispel Evil and Good_ spell.",
				Array.Empty<string>()),
			it: ("Possessione", "Alcuni effetti fanno sì che una creatura venga posseduta da un'altra creatura o entità; è l'effetto che causa la possessione a stabilirne il funzionamento. La possessione può essere impedita dall'incantesimo _Protezione dal Bene e dal Male_ e interrotta dall'incantesimo _Dissolvi il Bene e il Male_.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "proficiency", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Proficiency", "If you have proficiency with something, you can add your Proficiency Bonus to any D20 Test you make using that thing. A creature might have proficiency in a skill or saving throw or with a weapon or tool.",
				Array.Empty<string>()),
			it: ("Competenza", "Se un personaggio ha competenza in qualcosa, può aggiungere il suo bonus di competenza a qualsiasi prova con d20 che effettua usando quella cosa. Una creatura può avere competenza in un'abilità o in un tiro salvezza, oppure con un'arma o uno strumento.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "reach", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Reach", "A creature has a reach of 5 feet unless a rule says otherwise.",
				Array.Empty<string>()),
			it: ("Portata", "Una creatura ha una portata di 1,5 metri, a meno che una regola non dica altrimenti.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "reaction", RuleCategory.Rule,
			related: new[] { "opportunity-attacks" },
			en: ("Reaction", "A Reaction is a special action taken in response to a trigger defined in the Reaction's description. You can take a Reaction on another creature's turn, and if you take it on your turn, you can do so even if you also take an action, a Bonus Action, or both. Once you take a Reaction, you can't take another one until the start of your next turn. The Opportunity Attack is a Reaction available to all creatures.",
				new[] { "Reaction", "Reactions" }),
			it: ("Reazione", "Una reazione è un'azione speciale effettuata in risposta a un evento scatenante indicato nella sua descrizione. Il personaggio può effettuare una reazione durante il turno di un'altra creatura; se la effettua nel proprio turno, può farlo anche se effettua anche un'azione, un'azione bonus o entrambe. Dopo aver effettuato una reazione, non può effettuarne un'altra fino all'inizio del suo turno successivo. L'attacco di opportunità è una reazione a disposizione di tutte le creature.",
				new[] { "reazione", "reazioni" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "resistance", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Resistance", "If you have Resistance to a damage type, damage of that type is halved against you (round down). Resistance is applied only once to an instance of damage.",
				new[] { "Resistance" }),
			it: ("Resistenza", "Se un personaggio ha resistenza a un tipo di danno, i danni di quel tipo che subisce sono dimezzati (arrotondati per difetto). La resistenza si applica una sola volta a ogni singola istanza di danno.",
				new[] { "resistenza" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "ritual", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Ritual", "If you have a spell prepared that has the Ritual tag, you can cast that spell as a Ritual. The Ritual version of a spell takes 10 minutes longer to cast than normal. It also doesn't expend a spell slot, which means the ritual version of a spell can't be cast at a higher level.",
				new[] { "Ritual" }),
			it: ("Rituale", "Se ha preparato un incantesimo con l'etichetta rituale, il personaggio può lanciarlo come rituale. La versione rituale di un incantesimo richiede 10 minuti in più del normale per essere lanciata, ma non spende slot incantesimo; per questo non può essere lanciata a un livello superiore.",
				new[] { "rituale" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "round-down", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Round Down", "Whenever you divide or multiply a number in the game, round down if you end up with a fraction, even if the fraction is one-half or greater. Some rules make an exception and tell you to round up.",
				Array.Empty<string>()),
			it: ("Arrotondare per difetto", "Ogni volta che nel gioco si divide o si moltiplica un numero e si ottiene una frazione, si arrotonda per difetto, anche se la frazione è pari o superiore a un mezzo. Alcune regole fanno eccezione e indicano di arrotondare per eccesso.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "save", RuleCategory.Rule,
			related: new[] { "saving-throw" },
			en: ("Save", "Save is another name for a saving throw.",
				Array.Empty<string>()),
			it: ("Salvezza", "\"Salvezza\" è un altro modo di chiamare il tiro salvezza.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "saving-throw", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Saving Throw", "A saving throw—also called a save—represents an attempt to avoid or resist a threat. You normally make a saving throw only when a rule requires you to do so, but you can decide to fail the save without rolling. The result of a save is detailed in the effect that allowed it. If a target is forced to make a save and lacks the ability score used by it, the target automatically fails.",
				Array.Empty<string>()),
			it: ("Tiro salvezza", "Un tiro salvezza rappresenta il tentativo di evitare una minaccia o di resistervi. Di norma si effettua solo quando una regola lo richiede, ma il personaggio può decidere di fallirlo senza tirare. Il risultato del tiro salvezza è descritto nell'effetto che lo ha richiesto. Se il bersaglio deve effettuare un tiro salvezza ma non possiede il punteggio di caratteristica su cui si basa, lo fallisce automaticamente.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "shape-shifting", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Shape-Shifting", "If an effect, such as Wild Shape or the _Polymorph_ spell, lets you shape-shift, its description specifies what happens to you. Unless that description says otherwise, any ongoing effects on you—conditions, spells, curses, and the like—carry over from one form to the other. You revert to your true form if you die.",
				Array.Empty<string>()),
			it: ("Mutaforma", "Se un effetto, come Forma Selvatica o l'incantesimo _Metamorfosi_, permette al personaggio di cambiare forma, è la sua descrizione a stabilire cosa gli accade. Salvo diversa indicazione, gli effetti in corso su di lui (condizioni, incantesimi, maledizioni e simili) passano da una forma all'altra. Se muore, il personaggio torna alla sua vera forma.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "short-rest", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Short Rest", "A Short Rest is a 1-hour period of downtime, during which a creature does nothing more strenuous than reading, talking, eating, or standing watch. To start a Short Rest, you must have at least 1 Hit Point.\n\n**Benefits of the Rest.** When you finish the rest, you gain the following benefits:\n\n**Spend Hit Point Dice.** You can spend one or more of your Hit Point Dice to regain Hit Points. For each Hit Point Die you spend in this way, roll the die and add your Constitution modifier to it. You regain Hit Points equal to the total (minimum of 1 Hit Point). You can decide to spend an additional Hit Point Die after each roll.\n\n**Special Feature.** Some features are recharged by a Short Rest. If you have such a feature, it recharges in the way specified in its description.\n\n**Interrupting the Rest.** A Short Rest is stopped by the following interruptions:\n\n- Rolling Initiative\n- Casting a spell other than a cantrip\n- Taking any damage\n\nAn interrupted Short Rest confers no benefits.",
				new[] { "Short Rest", "Short Rests" }),
			it: ("Riposo breve", "Un riposo breve è un periodo di inattività di 1 ora durante il quale una creatura non fa nulla di più faticoso che leggere, parlare, mangiare o montare la guardia. Per iniziarlo il personaggio deve avere almeno 1 punto ferita.\n\n**Benefici del riposo.** Quando completa il riposo, il personaggio ottiene questi benefici.\n\n**Spendere Dadi Vita.** Può spendere uno o più Dadi Vita per recuperare punti ferita. Per ogni Dado Vita speso, tira il dado e aggiunge il suo modificatore di Costituzione: recupera un numero di punti ferita pari al totale (minimo 1). Dopo ogni tiro può decidere di spendere un altro Dado Vita.\n\n**Privilegi speciali.** Alcuni privilegi si ricaricano con un riposo breve: in questo caso si ricaricano come indicato nella loro descrizione.\n\n**Interruzione del riposo.** Un riposo breve si interrompe per questi motivi:\n\n- Tirare per l'iniziativa\n- Lanciare un incantesimo diverso da un trucchetto\n- Subire danni\n\nUn riposo breve interrotto non conferisce alcun beneficio.",
				new[] { "riposo breve", "riposi brevi" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "simultaneous-effects", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Simultaneous Effects", "If two or more things happen at the same time on a turn, the person at the game table—player or GM—whose turn it is decides the order in which those things happen. For example, if two effects occur at the start of a player character's turn, the player decides which of the effects happens first.",
				Array.Empty<string>()),
			it: ("Effetti simultanei", "Se due o più cose accadono contemporaneamente durante un turno, è la persona al tavolo (giocatore o DM) a cui appartiene il turno a decidere in che ordine avvengono. Per esempio, se due effetti si verificano all'inizio del turno di un personaggio giocante, il suo giocatore decide quale si verifica per primo.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "size", RuleCategory.Rule,
			related: new[] { "breaking-objects" },
			en: ("Size", "A creature or an object belongs to a size category: Tiny, Small, Medium, Large, Huge, or Gargantuan. A creature's size determines how much space the creature occupies in combat. An object's size affects its Hit Points.",
				Array.Empty<string>()),
			it: ("Taglia", "Ogni creatura od oggetto appartiene a una categoria di taglia: Minuscola, Piccola, Media, Grande, Enorme o Mastodontica. La taglia di una creatura determina quanto spazio occupa in combattimento; quella di un oggetto ne influenza i punti ferita.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "skill", RuleCategory.Rule,
			related: new[] { "proficiency" },
			en: ("Skill", "A skill is an area of specialization associated with an ability check. If you have proficiency in a skill, you can add your Proficiency Bonus when you make an ability check associated with that skill.",
				Array.Empty<string>()),
			it: ("Abilità", "Un'abilità è un campo di specializzazione associato a una prova di caratteristica. Se ha competenza in un'abilità, il personaggio può aggiungere il suo bonus di competenza alle prove di caratteristica associate a quell'abilità.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "speed", RuleCategory.Rule,
			related: new[] { "climbing", "crawling", "flying", "jumping", "swimming" },
			en: ("Speed", "A creature has a Speed, which is the distance in feet the creature can cover when it moves on its turn.\n\n**Special Speeds.** Some creatures have special speeds, such as a Burrow Speed, Climb Speed, Fly Speed, or Swim Speed, each of which is defined in this glossary. If you have more than one speed, choose which one to use when you move; you can switch between the speeds during your move. Whenever you switch, subtract the distance already moved from the new speed. The result determines how much farther you can move. If the result is 0 or less, you can't use the new speed during the current move. For example, if you have a Speed of 30 and a Fly Speed of 40, you could fly 10 feet, walk 10 feet, and leap into the air to fly 20 feet more.\n\n**Changes to Your Speeds.** If an effect increases or decreases your Speed for a time, any special speed you have increases or decreases by an equal amount for the same duration. For example, if your Speed is reduced to 0 and you have a Climb Speed, your Climb Speed is also reduced to 0. Similarly, if your Speed is halved and you have a Fly Speed, your Fly Speed is also halved.",
				Array.Empty<string>()),
			it: ("Velocità", "Ogni creatura ha una velocità, cioè la distanza che può percorrere quando si muove nel suo turno.\n\n**Velocità speciali.** Alcune creature hanno velocità speciali, come una velocità di scavo, di scalata, di volo o di nuoto, ciascuna definita nel glossario. Chi ha più di una velocità sceglie quale usare quando si muove e può passare dall'una all'altra durante il movimento. A ogni cambio, si sottrae dalla nuova velocità la distanza già percorsa: il risultato indica quanto può ancora muoversi. Se il risultato è 0 o meno, non può usare la nuova velocità durante quel movimento. Per esempio, con velocità 9 metri e velocità di volo 12 metri, una creatura potrebbe volare per 3 metri, camminare per 3 metri e poi spiccare il volo per altri 6 metri.\n\n**Modifiche alle velocità.** Se un effetto aumenta o riduce per un certo tempo la velocità di una creatura, anche le sue velocità speciali aumentano o diminuiscono della stessa quantità e per la stessa durata. Per esempio, se la sua velocità scende a 0 e ha una velocità di scalata, anche quest'ultima scende a 0; allo stesso modo, se la sua velocità viene dimezzata e ha una velocità di volo, anche la velocità di volo viene dimezzata.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "spell", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Spell", "A spell is a magical effect that has the characteristics described in \"Spells.\"",
				Array.Empty<string>()),
			it: ("Incantesimo", "Un incantesimo è un effetto magico con le caratteristiche descritte nelle regole sugli incantesimi.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "spell-attack", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Spell Attack", "A spell attack is an attack roll made as part of a spell or another magical effect.",
				Array.Empty<string>()),
			it: ("Attacco con incantesimo", "Un attacco con incantesimo è un tiro per colpire effettuato nell'ambito di un incantesimo o di un altro effetto magico.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "spellcasting-focus", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Spellcasting Focus", "A Spellcasting Focus is an object that certain creatures can use in place of a spell's Material components if those materials aren't consumed by the spell and don't have a cost specified. Some classes allow its members to use certain types of Spellcasting Focuses.",
				new[] { "Spellcasting Focus", "Spellcasting Focuses" }),
			it: ("Focus da incantatore", "Un focus da incantatore è un oggetto che alcune creature possono usare al posto delle componenti materiali di un incantesimo, se queste non vengono consumate dall'incantesimo e non hanno un costo indicato. Alcune classi permettono ai propri membri di usare determinati tipi di focus da incantatore.",
				new[] { "focus da incantatore" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "sphere", RuleCategory.AreaOfEffect,
			related: Array.Empty<string>(),
			en: ("Sphere", "A Sphere is an area of effect that extends in straight lines from a point of origin outward in all directions. The effect that creates a Sphere specifies the distance it extends as the radius of the Sphere.\n\nA Sphere's point of origin is included in the Sphere's area of effect.",
				new[] { "=Sphere", "=Spheres" }),
			it: ("Sfera", "Una sfera è un'area di effetto che si estende in linea retta dal punto di origine verso l'esterno, in tutte le direzioni. L'effetto che crea la sfera ne specifica la distanza come raggio.\n\nIl punto di origine della sfera è compreso nella sua area di effetto.",
				new[] { "sfera", "sfere" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "stable", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Stable", "A creature is Stable if it has 0 Hit Points but isn't required to make Death Saving Throws.",
				new[] { "=Stable" }),
			it: ("Stabile", "Una creatura è stabile se ha 0 punti ferita ma non deve effettuare tiri salvezza contro morte.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "stat-block", RuleCategory.Rule,
			related: new[] { "size", "creature-type", "alignment", "burrow-speed", "climb-speed", "fly-speed", "swim-speed", "proficiency", "resistance", "vulnerability", "immunity", "passive-perception", "challenge-rating", "experience-points" },
			en: ("Stat Block", "A stat block contains the game statistics of a monster. Each stat block includes the following information presented after the monster's name.\n\n**Size.** A monster is Tiny, Small, Medium, Large, Huge, or Gargantuan.** This entry notes the family of beings a monster belongs to, along with any descriptive tags.** An alignment is suggested for the monster, with the GM determining its actual alignment.** These entries give the monster's Armor Class, Initiative, and Hit Points, which are detailed in \"Playing the Game.\" In parentheses after the Hit Points, the monster's Hit Point Dice are provided, along with the contribution of its Constitution, if any, to its Hit Points. Following the Initiative modifier is an Initiative score. Some creatures that are created by magic lack Hit Dice and Initiative information.\n\n**Speed.** Here the monster's Speed is provided, along with any special speeds.** A table provides the monster's ability scores, modifiers, and saving throw modifiers, all of which are detailed in \"Playing the Game.\"\n\n**Skills.** This entry lists the monster's skill proficiencies, if any.\n\n**Resistances and Vulnerabilities.** These entries list the monster's Resistances and Vulnerabilities, if any.** This section lists the monster's damage and condition Immunities, if any.** If the monster has any equipment that can be given away or retrieved, it's listed in this entry.\n\n**Senses.** This entry lists the monster's special senses, such as Darkvision, and its Passive Perception.** This entry lists any languages the monster knows.\n\n**CR.** Challenge Rating summarizes the threat a monster poses and is detailed in \"Monsters.\" The Experience Points characters receive for defeating a monster and its Proficiency Bonus follow. Some creatures that are created by magic have no CR.** The monster's traits, if any, are features that are active at all times or in certain situations.\n\n**Actions.** The monster can take these actions in addition to those detailed in this glossary.\n\n**Bonus Actions.** If the monster has Bonus Action options, they are listed in this section.\n\n**Reactions.** If the monster can take special Reactions, those are listed in this section.\n\n**Attack Notation.** The entry for a monster's attack starts by identifying whether the attack is a melee or a ranged attack and then provides the attack roll's bonus, its reach or range, and what happens on a hit. An attack is against one target unless its entry says otherwise.\n\n**Saving Throw Effect Notation.** If an effect forces a saving throw, the effect's entry starts by identifying the kind of saving throw required and then provides the save's DC, a description of which creatures must make the save, and what happens on a failed or a successful save.\n\n**Damage Notation.** A stat block usually provides both a static number and a die expression for each instance of damage. For example, an attack might deal 4 (1d4 + 2) damage on a hit. The GM determines whether you use the static number or the die expression in parentheses; you don't use both.",
				Array.Empty<string>()),
			it: ("Scheda delle statistiche", "Una scheda delle statistiche contiene i dati di gioco di un mostro. Dopo il nome del mostro, ogni scheda riporta le informazioni seguenti.\n\n**Taglia.** Un mostro è Minuscolo, Piccolo, Medio, Grande, Enorme o Mastodontico.\n\n**Tipo di creatura.** Indica la famiglia di esseri a cui appartiene il mostro, insieme a eventuali etichette descrittive.\n\n**Allineamento.** Viene suggerito un allineamento per il mostro; quello effettivo lo stabilisce il DM.\n\n**CA, Iniziativa e PF.** Riportano la Classe Armatura, l'iniziativa e i punti ferita del mostro. Tra parentesi, dopo i punti ferita, sono indicati i Dadi Vita del mostro e l'eventuale contributo della Costituzione ai suoi punti ferita. Dopo il modificatore di iniziativa è indicato il punteggio di iniziativa. Alcune creature create dalla magia non hanno Dadi Vita né iniziativa.\n\n**Velocità.** Indica la velocità del mostro e le eventuali velocità speciali.\n\n**Punteggi di caratteristica.** Una tabella riporta i punteggi di caratteristica del mostro, i relativi modificatori e i modificatori dei tiri salvezza.\n\n**Abilità.** Elenca le eventuali abilità in cui il mostro ha competenza.\n\n**Resistenze e vulnerabilità.** Elencano le eventuali resistenze e vulnerabilità del mostro.\n\n**Immunità.** Elenca le eventuali immunità del mostro a danni e condizioni.\n\n**Equipaggiamento.** Elenca l'eventuale equipaggiamento del mostro che può essere ceduto o recuperato.\n\n**Sensi.** Elenca i sensi speciali del mostro, come la scurovisione, e la sua percezione passiva.\n\n**Linguaggi.** Elenca i linguaggi conosciuti dal mostro.\n\n**GS.** Il grado di sfida riassume la minaccia rappresentata dal mostro. Seguono i punti esperienza che i personaggi ricevono sconfiggendolo e il suo bonus di competenza. Alcune creature create dalla magia non hanno un GS.\n\n**Tratti.** I tratti del mostro, se ne ha, sono caratteristiche sempre attive o attive in determinate situazioni.\n\n**Azioni.** Il mostro può effettuare queste azioni in aggiunta a quelle descritte nel glossario.\n\n**Azioni bonus.** Se il mostro dispone di azioni bonus, sono elencate in questa sezione.\n\n**Reazioni.** Se il mostro può effettuare reazioni speciali, sono elencate in questa sezione.\n\n**Notazione degli attacchi.** La voce di un attacco indica prima se è in mischia o a distanza, poi il bonus del tiro per colpire, la portata o la gittata e cosa succede se colpisce. Un attacco è rivolto contro un solo bersaglio, salvo diversa indicazione.\n\n**Notazione degli effetti con tiro salvezza.** Se un effetto richiede un tiro salvezza, la sua voce indica prima il tipo di tiro salvezza, poi la CD, quali creature devono effettuarlo e cosa succede se lo falliscono o lo superano.\n\n**Notazione dei danni.** Di solito la scheda indica per ogni istanza di danno sia un valore fisso sia un'espressione con i dadi: per esempio, un attacco potrebbe infliggere 4 (1d4 + 2) danni se colpisce. Il DM decide se usare il valore fisso o l'espressione tra parentesi, ma non entrambi.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "suffocation", RuleCategory.Hazard,
			related: Array.Empty<string>(),
			en: ("Suffocation", "A creature can hold its breath for a number of minutes equal to 1 plus its Constitution modifier (minimum of 30 seconds) before suffocation begins. When a creature runs out of breath or is choking, it gains 1 Exhaustion level at the end of each of its turns. When a creature can breathe again, it removes all levels of Exhaustion it gained from suffocating.",
				Array.Empty<string>()),
			it: ("Soffocamento", "Una creatura può trattenere il respiro per un numero di minuti pari a 1 + il suo modificatore di Costituzione (minimo 30 secondi) prima di iniziare a soffocare. Quando resta senza fiato o sta soffocando, ottiene 1 livello di indebolimento alla fine di ciascun suo turno. Quando torna a respirare, perde tutti i livelli di indebolimento ottenuti a causa del soffocamento.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "surprise", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Surprise", "If a creature is caught unawares by the start of combat, that creature is surprised, which causes it to have Disadvantage on its Initiative roll.",
				Array.Empty<string>()),
			it: ("Sorpresa", "Se una creatura viene colta alla sprovvista dall'inizio del combattimento, è sorpresa: subisce svantaggio al suo tiro per l'iniziativa.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "swimming", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Swimming", "While you're swimming, each foot of movement costs 1 extra foot (2 extra feet in Difficult Terrain). You ignore this extra cost if you have a Swim Speed and use it to swim. At the GM's option, moving any distance in rough water might require a successful DC 15 Strength (Athletics) check.",
				Array.Empty<string>()),
			it: ("Nuotare", "Mentre nuota, ogni metro di movimento costa al personaggio 1 metro in più (2 metri in più su terreno difficile). Ignora questo costo aggiuntivo se ha una velocità di nuoto e la usa per nuotare. A discrezione del DM, muoversi in acque agitate può richiedere una prova di Forza (Atletica) con CD 15 superata.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "swim-speed", RuleCategory.Rule,
			related: new[] { "swimming", "speed" },
			en: ("Swim Speed", "A Swim Speed can be used to swim without expending the extra movement normally associated with swimming.",
				new[] { "Swim Speed" }),
			it: ("Velocità di nuoto", "La velocità di nuoto permette di nuotare senza spendere il movimento aggiuntivo che di solito richiede il nuoto.",
				new[] { "velocità di nuoto" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "target", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Target", "A target is the creature or object targeted by an attack roll, forced to make a saving throw by an effect, or selected to receive the effects of a spell or another phenomenon.",
				Array.Empty<string>()),
			it: ("Bersaglio", "Un bersaglio è la creatura o l'oggetto preso di mira da un tiro per colpire, costretto da un effetto a effettuare un tiro salvezza o scelto per ricevere gli effetti di un incantesimo o di un altro fenomeno.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "telepathy", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Telepathy", "Telepathy is a magical ability that allows a creature to communicate mentally with another creature within a specified range. Unless a rule states otherwise, the contacted creature doesn't need to share a language with the telepath to understand this communication, but the contacted creature must be able to understand at least one language or be telepathic itself to understand.\n\nA telepath doesn't need to see a contacted creature, and the telepath can start or end the telepathic contact at any time (no action required). Telepathic contact can't be initiated and is immediately broken if either the telepath or the other creature has the Incapacitated condition. Telepathic contact is also broken if the contacted creature is no longer within the telepathy's range or if the telepath contacts a different creature within range.\n\nA creature without telepathy can receive telepathic messages but can't initiate a telepathic conversation. Once a telepathic conversation starts, the non-telepath can communicate mentally to the telepath until the telepathic connection ends.",
				new[] { "telepathy" }),
			it: ("Telepatia", "La telepatia è una capacità magica che permette a una creatura di comunicare mentalmente con un'altra creatura entro un certo raggio. Salvo diversa indicazione, la creatura contattata non ha bisogno di condividere un linguaggio con il telepate per capire la comunicazione, ma deve conoscere almeno un linguaggio o essere a sua volta telepatica.\n\nIl telepate non ha bisogno di vedere la creatura contattata e può avviare o interrompere il contatto telepatico in qualsiasi momento (non richiede alcuna azione). Il contatto non può essere avviato, e si interrompe subito, se il telepate o l'altra creatura hanno la condizione di incapacitato. Si interrompe anche se la creatura contattata esce dal raggio della telepatia o se il telepate contatta un'altra creatura entro il raggio.\n\nUna creatura priva di telepatia può ricevere messaggi telepatici, ma non può avviare una conversazione telepatica. Una volta avviata la conversazione, può comunicare mentalmente con il telepate finché il collegamento non si interrompe.",
				new[] { "telepatia" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "teleportation", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Teleportation", "Teleportation is a special kind of magical transportation. If you teleport, you disappear and reappear elsewhere instantly, without moving through the intervening space. This transportation doesn't expend movement unless a rule tells you otherwise, and teleportation never provokes Opportunity Attacks.\n\nWhen you teleport, all the equipment you're wearing and carrying teleports with you. If you're touching another creature when you teleport, that creature doesn't teleport with you unless the teleportation effect says otherwise.\n\nIf the destination space of your teleportation is occupied by another creature or blocked by a solid obstacle, you instead appear in the nearest unoccupied space of your choice.\n\nThe description of a teleportation effect tells you if you must see the teleportation's destination.",
				new[] { "teleportation" }),
			it: ("Teletrasporto", "Il teletrasporto è una forma speciale di spostamento magico. Chi si teletrasporta scompare e ricompare altrove all'istante, senza attraversare lo spazio intermedio. Questo spostamento non consuma movimento, a meno che una regola non dica altrimenti, e non provoca mai attacchi di opportunità.\n\nQuando si teletrasporta, il personaggio porta con sé tutto l'equipaggiamento che indossa e trasporta. Se sta toccando un'altra creatura, quella creatura non si teletrasporta con lui, a meno che l'effetto non dica altrimenti.\n\nSe lo spazio di destinazione è occupato da un'altra creatura o bloccato da un ostacolo solido, il personaggio compare invece nello spazio libero più vicino a sua scelta.\n\nLa descrizione dell'effetto di teletrasporto indica se il personaggio deve vedere la destinazione.",
				new[] { "teletrasporto" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "temporary-hit-points", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Temporary Hit Points", "Temporary Hit Points are granted by certain effects and act as a buffer against losing real Hit Points.",
				new[] { "Temporary Hit Points", "Temporary Hit Point" }),
			it: ("Punti ferita temporanei", "I punti ferita temporanei sono concessi da certi effetti e fanno da cuscinetto prima di perdere i punti ferita veri e propri.",
				new[] { "punti ferita temporanei", "punto ferita temporaneo" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "tremorsense", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Tremorsense", "A creature with Tremorsense can pinpoint the location of creatures and moving objects within a specific range, provided that the creature with Tremorsense and anything it is detecting are both in contact with the same surface (such as the ground, a wall, or a ceiling) or the same liquid.\n\nTremorsense can't detect creatures or objects in the air, and it doesn't count as a form of sight.",
				new[] { "Tremorsense" }),
			it: ("Percezione tellurica", "Una creatura con percezione tellurica può individuare la posizione delle creature e degli oggetti in movimento entro un certo raggio, a patto che sia lei sia ciò che rileva siano a contatto con la stessa superficie (come il terreno, una parete o un soffitto) o con lo stesso liquido.\n\nLa percezione tellurica non rileva creature od oggetti in aria e non è considerata una forma di vista.",
				new[] { "percezione tellurica" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "truesight", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Truesight", "If you have Truesight, your vision is enhanced within a specified range. Within that range, your vision pierces through the following:\n\n**Darkness.** You can see in normal and magical Darkness.\n\n**Invisibility.** You see creatures and objects that have the Invisible condition.\n\n**Visual Illusions.** Visual illusions appear transparent to you, and you automatically succeed on saving throws against them.\n\n**Transformations.** You discern the true form of any creature or object you see that has been transformed by magic.\n\n**Ethereal Plane.** You see into the Ethereal Plane.",
				new[] { "Truesight" }),
			it: ("Vista pura", "Una creatura con vista pura ha una vista potenziata entro un certo raggio, entro il quale vede oltre:\n\n**Oscurità.** Vede nell'oscurità normale e magica.\n\n**Invisibilità.** Vede le creature e gli oggetti che hanno la condizione di invisibile.\n\n**Illusioni visive.** Le illusioni visive le appaiono trasparenti e supera automaticamente i tiri salvezza contro di esse.\n\n**Trasformazioni.** Distingue la vera forma di qualsiasi creatura od oggetto trasformato dalla magia che riesce a vedere.\n\n**Piano Etereo.** Vede nel Piano Etereo.",
				new[] { "vista pura" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "unarmed-strike", RuleCategory.Rule,
			related: new[] { "grappling" },
			en: ("Unarmed Strike", "Instead of using a weapon to make a melee attack, you can use a punch, kick, headbutt, or similar forceful blow. In game terms, this is an Unarmed Strike—a melee attack that involves you using your body to damage, grapple, or shove a target within 5 feet of you.\n\nWhenever you use your Unarmed Strike, choose one of the following options for its effect.\n\n**Damage.** You make an attack roll against the target. Your bonus to the roll equals your Strength modifier plus your Proficiency Bonus. On a hit, the target takes Bludgeoning damage equal to 1 plus your Strength modifier.\n\n**Grapple.** The target must succeed on a Strength or Dexterity saving throw (it chooses which), or it has the Grappled condition. The DC for the saving throw and any escape attempts equals 8 plus your Strength modifier and Proficiency Bonus. This grapple is possible only if the target is no more than one size larger than you and if you have a hand free to grab it.** The target must succeed on a Strength or Dexterity saving throw (it chooses which), or you either push it 5 feet away or cause it to have the Prone condition. The DC for the saving throw equals 8 plus your Strength modifier and Proficiency Bonus. This shove is possible only if the target is no more than one size larger than you.",
				new[] { "Unarmed Strike", "Unarmed Strikes" }),
			it: ("Colpo senz'armi", "Invece di usare un'arma per un attacco in mischia, il personaggio può sferrare un pugno, un calcio, una testata o un colpo simile. In termini di gioco si tratta di un colpo senz'armi: un attacco in mischia in cui il personaggio usa il proprio corpo per danneggiare, afferrare o spingere un bersaglio entro 1,5 metri.\n\nOgni volta che usa il colpo senz'armi, sceglie una delle opzioni seguenti.\n\n**Danni.** Effettua un tiro per colpire contro il bersaglio, con un bonus pari al suo modificatore di Forza + il suo bonus di competenza. Se colpisce, il bersaglio subisce danni contundenti pari a 1 + il suo modificatore di Forza.\n\n**Afferrare.** Il bersaglio deve superare un tiro salvezza su Forza o Destrezza (a sua scelta), altrimenti ottiene la condizione di afferrato. La CD del tiro salvezza e di ogni tentativo di fuga è pari a 8 + il modificatore di Forza e il bonus di competenza del personaggio. La presa è possibile solo se il bersaglio non è più di una taglia più grande del personaggio e se il personaggio ha una mano libera per afferrarlo.\n\n**Spingere.** Il bersaglio deve superare un tiro salvezza su Forza o Destrezza (a sua scelta), altrimenti il personaggio lo spinge di 1,5 metri lontano da sé oppure gli fa ottenere la condizione di prono. La CD del tiro salvezza è pari a 8 + il modificatore di Forza e il bonus di competenza del personaggio. La spinta è possibile solo se il bersaglio non è più di una taglia più grande del personaggio.",
				new[] { "colpo senz'armi", "colpi senz'armi", "colpo senz'arma", "colpi senz'arma" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "unoccupied-space", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Unoccupied Space", "A space is unoccupied if no creatures are in it and it isn't completely filled by objects.",
				Array.Empty<string>()),
			it: ("Spazio libero", "Uno spazio è libero se non contiene creature e non è completamente riempito di oggetti.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "vulnerability", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Vulnerability", "If you have Vulnerability to a damage type, damage of that type is doubled against you. Vulnerability is applied only once to an instance of damage.",
				new[] { "Vulnerability" }),
			it: ("Vulnerabilità", "Se un personaggio ha vulnerabilità a un tipo di danno, i danni di quel tipo che subisce sono raddoppiati. La vulnerabilità si applica una sola volta a ogni singola istanza di danno.",
				new[] { "vulnerabilità" }));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "weapon", RuleCategory.Rule,
			related: Array.Empty<string>(),
			en: ("Weapon", "A weapon is an object that is in the Simple or Martial weapon category.",
				Array.Empty<string>()),
			it: ("Arma", "Un'arma è un oggetto che appartiene alla categoria delle armi semplici o da guerra.",
				Array.Empty<string>()));

		yield return RuleEntryFactory.Create(RulesetVersion.Dnd5e_2024, ContentSource.Srd52, "weapon-attack", RuleCategory.Rule,
			related: new[] { "weapon" },
			en: ("Weapon Attack", "A weapon attack is an attack roll made with a weapon.",
				Array.Empty<string>()),
			it: ("Attacco con arma", "Un attacco con arma è un tiro per colpire effettuato con un'arma.",
				Array.Empty<string>()));
	}
}
