# RealmForge

[![build](https://github.com/VittorioNinno/realm-forge/actions/workflows/build.yml/badge.svg?branch=develop)](https://github.com/VittorioNinno/realm-forge/actions/workflows/build.yml)

[🇬🇧 English]
A modular, bilingual web platform for managing tabletop RPG campaigns, sessions and rules, inspired by D&D 5e (2014) and 5.5e (2024).

[🇮🇹 Italiano]
*Piattaforma web modulare e bilingue per la gestione di campagne, sessioni e regole di giochi di ruolo da tavolo, ispirata a D&D 5e (2014) e 5.5e (2024).*

---

## ✨ Features / Funzionalità

- **Native bilingual support** · *Bilinguismo nativo*
  Italian and English everywhere, from database translations to the UI, switchable at runtime without reloading.
  *Italiano e inglese ovunque, dalle traduzioni nel database all'interfaccia, con cambio lingua immediato senza ricaricare.*

- **Base vs Homebrew separation** · *Separazione Base / Homebrew*
  Base content is part of the platform: read-only and kept in sync by the seeders, with its text source shown in the app. Homebrew belongs to its author.
  *I contenuti Base fanno parte della piattaforma: sola lettura, sincronizzati dai seeder, con la fonte del testo indicata nell'app. Gli Homebrew appartengono al loro autore.*

- **User accounts** · *Account utente*
  Registration and sign-in; anyone can browse, only signed-in users with a confirmed e-mail can forge content. Password change from the account page and password recovery by e-mail.
  *Registrazione e accesso; tutti possono consultare, solo gli utenti con email confermata possono forgiare contenuti. Cambio password dalla pagina account e recupero password via email.*

- **Homebrew sharing** · *Condivisione Homebrew*
  Every Homebrew entry is private, shareable through its link, or public (listed for everyone).
  *Ogni contenuto Homebrew è privato, condivisibile tramite link oppure pubblico (visibile a tutti nelle liste).*

- **Passkeys and account security** · *Passkey e sicurezza dell'account*
  Sign-in with passkeys (iPhone, Safari, Android, Windows Hello, security keys) offered right in the e-mail field, rate limiting, e-mail change, account suspension and deletion confirmed by e-mail.
  *Accesso con passkey (iPhone, Safari, Android, Windows Hello, chiavi di sicurezza) proposte già nel campo email, limiti di frequenza, cambio email, sospensione ed eliminazione dell'account confermate via email.*

- **Clone and customise** · *Clona e personalizza*
  Any entry you can read (Base content or someone's public Homebrew) becomes a private copy of yours with one click, with everything that belongs to it, ready to change for your campaign; the copy shows "Based on …" with a link to the original.
  *Qualsiasi voce che puoi leggere (contenuti Base o Homebrew pubblico di altri) diventa con un clic una tua copia privata, con tutto ciò che le appartiene, pronta da modificare per la tua campagna; la copia mostra "Basato su …" con il link all'originale.*

- **JSON files and the author's page** · *File JSON e pagina dell'autore*
  Characters and Homebrew (with everything that belongs to each entry) export to a versioned JSON file and import back, also on another RealmForge (self-hosting); "My Homebrew" lists what you created by kind, with the languages each entry is written in and a filter for what is left to translate.
  *Personaggi e Homebrew (con tutto ciò che appartiene a ogni voce) si esportano in un file JSON versionato e si reimportano, anche su un altro RealmForge (self-hosting); "Il mio Homebrew" elenca ciò che hai creato per tipo, con le lingue in cui è scritta ogni voce e un filtro per ciò che resta da tradurre.*

- **Search, pins, bin and moderation** · *Ricerca, pagine fissate, cestino e moderazione*
  Global search with quick lookup (`/` or Ctrl+K), recently viewed entries and a random entry; any page (a character, a campaign, a list of the compendium) pinned to the side menu from the top bar; deleted Homebrew goes to a bin first; administrators manage accounts and Homebrew.
  *Ricerca globale con consultazione rapida (`/` o Ctrl+K), voci viste di recente e voce casuale; qualsiasi pagina (un personaggio, una campagna, un elenco del compendio) fissabile nella barra laterale dal pulsante in alto; gli Homebrew eliminati passano prima dal cestino; gli amministratori gestiscono account e Homebrew.*

- **Campaigns and virtual tabletop** · *Campagne e tavolo virtuale*
  Campaigns with masters, co-masters and players, sessions, encounters, a shared roll log and a full virtual tabletop that applies the rules of both editions (see below).
  *Campagne con master, co-master e giocatori, sessioni, incontri, registro dei tiri condiviso e un tavolo virtuale completo che applica le regole di entrambe le edizioni (vedi sotto).*

- **Dark Fantasy design system** · *Design system "Dark Fantasy"*
  Dark surfaces, forge-orange accents and custom components.
  *Superfici scure, accenti arancione forgia e componenti personalizzati.*

### Module status / Stato dei moduli

| Module · *Modulo* | Status · *Stato* | Notes · *Note* |
|---|---|---|
| Species & lineages · *Specie e sottospecie* | ✅ | 9 base 2014 + 10 base 2024 species, speed and traits recalculated per lineage · *velocità e tratti ricalcolati per sottospecie* |
| Feats · *Talenti* | ✅ | 117 base feats (42 × 2014, 75 × 2024), structured bilingual prerequisites, "Forge Feat" editor · *prerequisiti strutturati bilingue, editor "Forgia Talento"* |
| Accounts & ownership · *Account e proprietà* | ✅ | ASP.NET Core Identity, bearer tokens, e-mail confirmation, password recovery, per-author Homebrew with private / link / public visibility · *conferma email, recupero password, Homebrew per autore con visibilità privata / link / pubblica* |
| Backgrounds · *Background* | ✅ | 13 base 2014 backgrounds with feature and characteristic tables; 16 base 2024 backgrounds with ability scores, Origin feat and equipment options A/B (Acolyte, Criminal, Sage and Soldier from SRD 5.2) · *13 background base 2014 con privilegio e tabelle delle caratteristiche; 16 background base 2024 con caratteristiche, Talento di Origine e opzioni di equipaggiamento A/B (Accolito, Criminale, Sapiente e Soldato dall'SRD 5.2)* |
| Spells · *Incantesimi* | ✅ | 361 base 2014 spells (319 from SRD 5.1, 42 with RealmForge text) and 391 base 2024 spells (339 from SRD 5.2, 52 with RealmForge text, summoning stat blocks included), class lists, filters by edition, level, school, class, ritual and concentration, Homebrew editor · *361 incantesimi base 2014 (319 dall'SRD 5.1, 42 con testo RealmForge) e 391 incantesimi base 2024 (339 dall'SRD 5.2, 52 con testo RealmForge, schede delle evocazioni incluse), liste per classe, filtri per edizione, livello, scuola, classe, rituale e concentrazione, editor Homebrew* |
| Classes · *Classi* | ✅ | 12 base 2014 classes from SRD 5.1 with 40 subclasses (12 from SRD 5.1, 28 with RealmForge text) and 12 base 2024 classes from SRD 5.2 with 48 subclasses (12 from SRD 5.2, 36 with RealmForge text): full sheet with overview, 20-level progression table, features level by level (Metamagic, Eldritch Invocations, Battle Master maneuvers included) and subclasses; simplified Homebrew editor for classes and subclasses · *12 classi base 2014 dall'SRD 5.1 con 40 sottoclassi (12 dall'SRD 5.1, 28 con testo RealmForge) e 12 classi base 2024 dall'SRD 5.2 con 48 sottoclassi (12 dall'SRD 5.2, 36 con testo RealmForge): scheda completa con panoramica, tabella di progressione su 20 livelli, privilegi livello per livello (Metamagia, Suppliche occulte e manovre del Maestro di Battaglia incluse) e sottoclassi; editor Homebrew semplificato per classi e sottoclassi* |
| Equipment · *Equipaggiamento* | ✅ | 242 base 2014 items (SRD 5.1) and 208 base 2024 items (SRD 5.2): weapons with damage, properties and 2024 mastery, armor with AC, Strength and Stealth, tools (2024: ability, Utilize and Craft), adventuring gear, equipment packs, spellcasting focuses, mounts, vehicles, ships and trade goods; costs and weights checked against the Player's Handbook, kilograms and metres in Italian, weapon property and mastery rules, Homebrew editor · *242 oggetti base 2014 (SRD 5.1) e 208 oggetti base 2024 (SRD 5.2): armi con danni, proprietà e padronanza 2024, armature con CA, Forza e Furtività, strumenti (2024: caratteristica, Utilizzo e Creazione), equipaggiamento d'avventura, dotazioni, focus da incantatore, cavalcature, veicoli, navi e merci; costi e pesi verificati sul Manuale del Giocatore, chilogrammi e metri in italiano, regole delle proprietà delle armi e della padronanza, editor Homebrew* |
| Rules glossary · *Glossario delle regole* | ✅ | 155 entries of 2024 (the whole Rules Glossary of the SRD 5.2.1, the same entries as appendix C of the Player's Handbook) and 88 of 2014 (conditions, combat actions, areas of effect and the main rules of the SRD 5.1) with the official Italian names; the rules terms in the descriptions of spells, classes, species, feats, backgrounds and equipment link to their entry, with a tooltip · *155 voci 2024 (l'intero glossario delle regole dell'SRD 5.2.1, le stesse voci dell'appendice C del Manuale del Giocatore) e 88 voci 2014 (condizioni, azioni in combattimento, aree di effetto e regole principali dell'SRD 5.1) con i nomi ufficiali italiani; i termini di regola nei testi di incantesimi, classi, specie, talenti, background ed equipaggiamento rimandano alla loro voce, con un tooltip* |
| Characters · *Personaggi* | ✅ | Wizard that follows each Player's Handbook: 2014 race → class → scores → background (racial increases, subraces, variant human), 2024 class → background → species (background increases and Origin feat, Versatile human); levels one by one with multiclassing (prerequisites, reduced proficiencies, multiclass spell slots, Pact Magic), fixed or rolled hit points, Ability Score Improvements and feats, Epic Boons, subclasses, Expertise, Fighting Styles, Divine/Primal Orders, Weapon Mastery; languages from the Standard/Exotic (2014) and Standard/Rare (2024) tables of the manuals; starting equipment built on the English structure (same choices in both languages, specific weapon for the generic lines); spells per class and per feat. Every choice is checked by one rules engine shared by the wizard, the sheet and the API. Interactive sheet saved automatically: hit points, temporary HP, death saves, rests and hit dice, spell slots, conditions and exhaustion, d20 rolls with advantage, attacks, inventory with worn armor and coins, resources, notes; edit and level up; PDF download · *Creazione guidata che segue il Manuale del Giocatore di ogni edizione: 2014 razza → classe → punteggi → background (incrementi razziali, sottorazze, umano variante), 2024 classe → background → specie (incrementi e Talento di Origine dal background, umano Versatile); livelli uno per uno con multiclasse (prerequisiti, competenze ridotte, slot multiclasse, Magia del Patto), punti ferita fissi o tirati, aumenti dei punteggi e talenti, Doni Epici, sottoclassi, Maestria, Stili di combattimento, Ordini, Maestria nelle armi; lingue dalle tabelle dei manuali; equipaggiamento iniziale costruito sulla struttura inglese (stesse scelte in entrambe le lingue); incantesimi per classe e per talento. Ogni scelta è controllata da un unico motore di regole condiviso da wizard, scheda e API. Scheda interattiva con salvataggio automatico, modifica, avanzamento di livello e PDF* |
| Monsters & NPCs · *Mostri e PNG* | ✅ | 2014 bestiary (SRD 5.1 statblocks and the rest of the Monster Manual with RealmForge text), Homebrew variants, monster pictures; NPC register with its own sheet · *bestiario 2014 (schede SRD 5.1 e il resto del Manuale dei Mostri con testo RealmForge), varianti Homebrew, immagini dei mostri; registro dei PNG con scheda dedicata* |
| Magic items · *Oggetti magici* | ✅ | 2014 compendium, Homebrew items and variants; on the sheet with their spells and charges · *compendio 2014, oggetti e varianti Homebrew; nella scheda con i loro incantesimi e le cariche* |
| Rule modules · *Moduli di regole* | ✅ | Homebrew rules computed by the sheet: extra abilities (e.g. Luck next to the six), resources, bonuses and proficiencies; an automation builder for modules, feats, species and class features: features used at the table with their dice (MOD, PB, LV), healing or temporary hit points and the resource they spend, and extra damage on hits (melee, ranged or any, once per turn, always or when chosen) · *regole Homebrew calcolate dalla scheda: caratteristiche in più (es. Fortuna accanto alle sei), risorse, bonus e competenze; un costruttore di automazioni per moduli, talenti, specie e privilegi di classe: capacità usate al tavolo con i loro dadi (MOD, PB, LV), cure o punti ferita temporanei e la risorsa che spendono, e danni in più sui colpi (in mischia, a distanza o tutti, una volta per turno, sempre o a scelta)* |
| Campaigns & sessions · *Campagne e sessioni* | ✅ | Masters, co-masters and players by invitation, characters shared with the master, notes and requirements, sessions, shared roll log with filters, live table notice to the players; each session exported as Markdown with the rolls of its day, the whole log as Markdown or CSV · *master, co-master e giocatori su invito, personaggi condivisi con il master, note e requisiti, sessioni, registro dei tiri condiviso con filtri, avviso del tavolo aperto ai giocatori; ogni sessione esportabile in Markdown con i tiri del suo giorno, l'intero registro in Markdown o CSV* |
| Encounters · *Incontri* | ✅ | Builder with difficulty and generator, starting positions on the map, hit points and conditions synchronized with the sheets · *costruttore con difficoltà e generatore, posizioni di partenza sulla mappa, punti ferita e condizioni sincronizzati con le schede* |
| Virtual tabletop · *Tavolo virtuale* | ✅ | Square and hex maps, fog, walls and doors, initiative and turns with the rules of both editions, attacks, spells and saves, dynamic vision, master tools; details below · *mappe quadrate ed esagonali, nebbia, muri e porte, iniziativa e turni con le regole di entrambe le edizioni, attacchi, incantesimi e tiri salvezza, visione dinamica, strumenti del master; dettagli sotto* |

---

## 🗺️ Virtual tabletop / Tavolo virtuale

The table of a campaign, on its own page: the master prepares the maps away from the players, opens the table (the players are notified) and shows one map at a time. Changes reach everyone almost at once (the API answers as soon as something changes).
*Il tavolo di una campagna, su una pagina dedicata: il master prepara le mappe lontano dai giocatori, apre il tavolo (i giocatori ricevono l'avviso) e mostra una mappa alla volta. Le modifiche arrivano a tutti quasi subito (l'API risponde appena qualcosa cambia).*

**Maps · *Mappe***
- Square or hex grid aligned on the picture, adaptive zoom, ruler in metres or feet, pings, drawings, texts and areas, map duplication.
  *Griglia quadrata o esagonale allineata sull'immagine, zoom adattivo, righello in metri o piedi, ping, disegni, testi e aree, duplicazione della mappa.*
- Fog of war painted cell by cell; terrain with walls, difficult terrain and cover (half, three-quarters, total), walkable zones.
  *Nebbia di guerra dipinta a caselle; terreno con muri, terreno difficile e coperture (mezza, tre quarti, totale), zone percorribili.*
- Objects with states: doors (also locked and secret), chests and loot, levers, traps, items on the ground; **stairs and portals** linked to each other, on the same map or on another floor: a creature next to one goes through, and the players' table follows the party.
  *Oggetti con stati: porte (anche chiuse a chiave e segrete), forzieri e bottino, leve, trappole, oggetti a terra; **scale e portali** collegati tra loro, sulla stessa mappa o su un altro piano: una creatura accanto passa, e il tavolo dei giocatori segue il gruppo.*

**Tokens · *Segnalini***
- Characters, NPCs, monsters (with pictures) and markers; tokens assigned to players; quick sheet with hit points, armor class, conditions, abilities with uses and dice.
  *Personaggi, PNG, mostri (con immagini) e segnalini; segnalini assegnati ai giocatori; scheda rapida con punti ferita, classe armatura, condizioni, capacità con usi e dadi.*
- Auras that move with their token (and hit whoever enters them), summons and familiars, mounts that carry their riders, grapples that drag the creature held.
  *Aure che seguono il segnalino (e colpiscono chi ci entra), evocazioni e famigli, cavalcature che portano chi le monta, prese che trascinano la creatura afferrata.*

**Combat · *Combattimento***
- Initiative (vertical or horizontal bar, group initiative), turn-bound movement with difficult terrain and diagonals, actions, bonus actions and reactions per turn, Disengage and opportunity attacks, Ready with a trigger, weapon swap.
  *Iniziativa (barra verticale o orizzontale, iniziativa di gruppo), movimento solo nel proprio turno con terreno difficile e diagonali, azioni, azioni bonus e reazioni per turno, Disimpegno e attacchi di opportunità, Preparare con innesco, cambio arma.*
- Attacks against armor class with confirmation, cover and line of sight, linked features (Sneak Attack, Rage, Divine Smite…), resistances, immunities and vulnerabilities applied to the damage, concentration checks, characters at 0 hit points and death saves.
  *Attacchi contro la classe armatura con conferma, coperture e linea di vista, capacità collegate (Attacco furtivo, Ira, Punizione divina…), resistenze, immunità e vulnerabilità applicate ai danni, prove di concentrazione, personaggi a 0 punti ferita e tiri salvezza contro la morte.*
- Spells aimed like attacks or placed as areas of the right size, saving throws called by the caster and rolled by each target (the master sees them all), Metamagic and the other casting options of the classes (Evocation, Agonizing Blast), spell rules per turn.
  *Incantesimi mirati come gli attacchi o piazzati come aree della dimensione giusta, tiri salvezza chiamati da chi lancia e tirati da ogni bersaglio (il master li vede tutti), Metamagia e le altre opzioni di lancio delle classi (Evocazione, Deflagrazione agonizzante), regole degli incantesimi nel turno.*
- While an attack or a spell is aimed, each possible target tells its distance (metres or feet), whether it is at long range (disadvantage) or out of reach, and the cover the walls give it (½, ¾, total). Casting a second spell with concentration asks first: the previous one ends, its aura with it.
  *Mentre si mira un attacco o un incantesimo, ogni possibile bersaglio mostra la distanza (metri o piedi), se è a gittata lunga (svantaggio) o fuori portata e la copertura data dai muri (½, ¾, totale). Lanciare un secondo incantesimo a concentrazione chiede conferma: il precedente termina, e con lui la sua aura.*
- Dice rolled at the table with a floating tray and the shared log; rests are not allowed during an encounter.
  *Dadi tirati al tavolo con il vassoio fluttuante e il registro condiviso; durante un incontro non si riposa.*

**Light and vision · *Luce e visione***
- Map light (bright, dim, dark) and **dynamic vision**: each player sees only what their creatures see. Walls and closed doors block the sight; torches, lanterns and the Light spell light the way; darkvision comes from the sheet, the statblock or is set by hand. Creatures out of sight are never sent to the player.
  *Luce della mappa (piena, penombra, buio) e **visione dinamica**: ogni giocatore vede solo ciò che vedono le sue creature. Muri e porte chiuse bloccano la vista; torce, lanterne e l'incantesimo Luce illuminano; la scurovisione arriva dalla scheda, dal bestiario o è impostata a mano. Le creature fuori vista non vengono mai inviate al giocatore.*

**Handouts · *Handout***
- Letters, clues, portraits and maps that are not tactical, written in Italian and English with a picture: hidden until the master reveals them (from the campaign or from the table), then they open on the players' screens, each in their own language, and stay in the campaign's Handouts tab.
  *Lettere, indizi, ritratti e mappe non tattiche, scritti in italiano e inglese con un'immagine: nascosti finché il master non li rivela (dalla campagna o dal tavolo), poi si aprono sullo schermo dei giocatori, ciascuno nella propria lingua, e restano nella scheda Handout della campagna.*

**Theater of the mind · *Teatro della mente***
- A handout shown as a scene in place of the tactical map for the whole table (a landscape, an NPC's portrait, a letter), with the party's portraits; dice, log and initiative stay active. One click goes back to the map.
  *Un handout mostrato come scena al posto della mappa tattica per tutto il tavolo (un paesaggio, il ritratto di un PNG, una lettera), con i ritratti del gruppo; dadi, log e iniziativa restano attivi. Un clic e si torna alla mappa.*

**Journal with mentions · *Diario con menzioni***
- In the campaign's notes, typing @ offers the characters, the NPCs shared with the campaign, shops, factions, handouts, maps (masters only) and the journal's pages; a mention shows as a tag, linked to the sheet or dossier when there is one. A master can add the "Master's secrets" to a journal page: only who runs the table reads them. Notes render Markdown without raw HTML.
  *Nelle note della campagna, scrivendo @ compaiono personaggi, PNG condivisi con la campagna, negozi, fazioni, dispense, mappe (solo master) e pagine del diario; la menzione appare come etichetta, collegata alla scheda o al dossier quando c'è. Il master può aggiungere a una pagina del diario i "Segreti del Master": li legge solo chi conduce il tavolo. Le note mostrano il Markdown senza HTML grezzo.*

**Riddles and ciphers · *Enigmi e cifrari***
- Each handout can hold a riddle: the master writes the accepted answers and may tie it to a door, gate or secret passage of a map. The players answer from the handout (capitals, accents and spaces do not matter); the right answer solves it for the whole table and opens the door. The lab in the handout editor turns a message into Caesar, Vigenère, Atbash, runes, draconic glyphs or numbers, and offers a catalogue of environmental riddles written for RealmForge, each with three hints for the master, given to whoever passes a skill check against their DC.
  *Ogni handout può contenere un enigma: il master scrive le risposte accettate e può collegarlo a una porta, un cancello o un passaggio segreto di una mappa. I giocatori rispondono dall'handout (maiuscole, accenti e spazi non contano); la risposta giusta lo risolve per tutto il tavolo e apre la porta. Il laboratorio nell'editor degli handout trasforma un messaggio in cifrario di Cesare, Vigenère, Atbash, rune, glifi draconici o numeri, e offre un catalogo di enigmi ambientali scritti per RealmForge, ognuno con tre indizi per il master da dare a chi supera una prova di abilità contro la sua CD.*

**Shops · *Negozi***
- Merchants prepared by the master in the campaign's Shops tab: equipment and magic items of the compendium (list price, or the usual price of the rarity) or free items, with a price multiplier and an optional stock. Once opened, the players buy for their characters: the coins come off the purse (with change in smaller coins) and the item lands in the inventory, magic properties included.
  *Mercanti preparati dal master nella scheda Negozi della campagna: equipaggiamento e oggetti magici del compendio (prezzo di listino, o quello abituale della rarità) oppure oggetti liberi, con un moltiplicatore di prezzo e scorte facoltative. Una volta aperti, i giocatori comprano per i propri personaggi: le monete escono dalla borsa (con il resto in monete più piccole) e l'oggetto finisce nell'inventario, proprietà magiche comprese.*
- Quick generators: one click makes a general store, blacksmith, armorer, alchemist, arcane shop or tavern with a name, a keeper and their manner, the look of the place (a rumour in taverns), prices and shelves filled from the official compendium (a menu and rooms in taverns); it starts closed, to look over before opening. In the NPC registry, "Instant NPC" saves a random NPC straight into the cast.
  *Generatori rapidi: un clic crea un emporio, un fabbro, un armaiolo, un alchimista, una bottega arcana o una taverna con nome, gestore e suo carattere, atmosfera del luogo (una voce di corridoio nelle taverne), prezzi e scaffali presi dal compendio ufficiale (menu e stanze nelle taverne); nasce chiuso, da controllare prima di aprirlo. Nel registro dei PNG, "PNG istantaneo" salva subito un PNG casuale nel cast.*

**Game time and supplies · *Tempo di gioco e scorte***
- Each campaign has a game clock (day and hour) that the master moves on from the campaign overview or from the table's top bar: +10 minutes, +1 hour, a long rest, days of travel. Spells of ten minutes or more cast from the sheet run on it and end on their own (concentration included); days of travel can eat a ration a day from every active character, and the master sees who went hungry.
  *Ogni campagna ha un orologio di gioco (giorno e ora) che il master fa avanzare dalla panoramica della campagna o dalla barra del tavolo: +10 minuti, +1 ora, riposo lungo, giorni di viaggio. Gli incantesimi di almeno dieci minuti lanciati dalla scheda vi scorrono sopra e terminano da soli (concentrazione compresa); i giorni di viaggio possono consumare una razione al giorno per ogni personaggio attivo, e il master vede chi è rimasto senza.*
- The sheet shows the supplies (rations, torches, ammunition) with quick steppers and, after a fight, recovers half of the ammunition shot. Purchases, rations and loot changed at the table win over an older copy of the sheet left open.
  *La scheda mostra le scorte (razioni, torce, munizioni) con contatori rapidi e, dopo uno scontro, recupera metà delle munizioni tirate. Acquisti, razioni e bottino cambiati al tavolo prevalgono su una copia più vecchia della scheda rimasta aperta.*

**Homebrew collections · *Raccolte di Homebrew***
- On "My Homebrew" an author gathers the selected entries into a collection with one link. Whoever opens the link can add every entry to their own collection at once, or switch the whole collection on in a campaign (and off again as a block from the campaign's Content tab).
  *In "Il mio Homebrew" l'autore riunisce i contenuti selezionati in una raccolta con un unico link. Chi apre il link può aggiungere tutti i contenuti alla propria raccolta in un colpo, oppure attivare l'intera raccolta in una campagna (e disattivarla in blocco dalla scheda Contenuti della campagna).*

**Soundboard · *Soundboard sincronizzata***
- In the table's Soundboard drawer the master keeps links to audio files or streams hosted elsewhere (https, nothing is uploaded): tracks that loop (music, ambience) and one-shot effects. Playing one reaches every screen at the table: the track in time with its start, the effect once. Each player turns the sound on with one click (browsers require it) and can mute it just for themselves.
  *Nel cassetto Soundboard del tavolo il master tiene link a file audio o stream ospitati altrove (https, nulla viene caricato): tracce in loop (musica, ambiente) ed effetti singoli. Avviarne uno raggiunge tutti gli schermi del tavolo: la traccia sincronizzata con il suo inizio, l'effetto una volta. Ogni giocatore attiva l'audio con un clic (lo richiedono i browser) e può silenziarlo solo per sé.*
- Sound scenes put a track, up to four ambience loops (rain, crowd, fire) and an opening effect together, started with one click; the loops fade in and out. A scene tied to a map starts by itself when the master shows that map to the players.
  *Le scene sonore uniscono una traccia, fino a quattro loop d'ambiente (pioggia, folla, fuoco) e un effetto iniziale, avviati con un clic; i loop entrano ed escono in dissolvenza. Una scena collegata a una mappa parte da sola quando il master mostra quella mappa ai giocatori.*

**2014 ↔ 2024 equivalences · *Equivalenze 2014 ↔ 2024***
- The detail pages of the compendium (and of Homebrew) suggest the corresponding entry of the other edition, by its English name ("Melf's Acid Arrow" finds "Acid Arrow" too): one click moves from a 2014 spell, monster or item to its 2024 version and back.
  *Le pagine di dettaglio del compendio (e dell'Homebrew) suggeriscono la voce corrispondente dell'altra edizione, tramite il nome inglese ("Melf's Acid Arrow" trova anche "Acid Arrow"): un clic porta da un incantesimo, mostro o oggetto 2014 alla sua versione 2024 e viceversa.*

**3D dice · *Dadi 3D***
- Every roll of the sheet, the roll log and the table can be thrown as real 3D dice across the screen (three.js with physics), landing on the result the app already decided, as on D&D Beyond: d4 to d20 and the percentile pair. Colour, material (resin, metal, wood, glass) and sound are chosen in the account and kept on the device; the rolls of the others at the table can tumble too, in their colour. Without WebGL or with reduced motion the animated dice of the tray stay.
  *Ogni tiro della scheda, del registro dei tiri e del tavolo può diventare un lancio di veri dadi 3D sullo schermo (three.js con fisica), che si fermano sul risultato già deciso dall'app, come su D&D Beyond: dal d4 al d20 e la coppia dei percentili. Colore, materiale (resina, metallo, legno, vetro) e suono si scelgono nell'account e restano sul dispositivo; anche i lanci degli altri al tavolo possono rotolare, nel loro colore. Senza WebGL o con il movimento ridotto restano i dadi animati del vassoio.*

**Visual effects · *Effetti visivi***
- A light particle layer (no library): hits on the table burst in the colour of their damage type (fire embers, ice shards, lightning bolts, acid, necrotic smoke, radiant rays…), criticals in gold with a shock ring and a shake of the board, misses in dust, healing in rising motes; a spell area blooms where it lands, natural 20s and 1s glow from the dice tray, every new level rains confetti on the sheet and pages fade in. Full, reduced or off for each device in the account; reduced motion means reduced.
  *Uno strato leggero di particelle (senza librerie): i colpi sul tavolo esplodono nel colore del tipo di danno (braci, schegge di ghiaccio, fulmini, acido, fumo necrotico, raggi radiosi…), i critici in oro con un'onda d'urto e una scossa della mappa, i mancati in polvere, le cure in scintille che salgono; l'area di un incantesimo si accende dove cade, i 20 e gli 1 naturali brillano dal vassoio dei dadi, ogni nuovo livello fa piovere coriandoli sulla scheda e le pagine entrano in dissolvenza. Completi, ridotti o spenti per ogni dispositivo nell'account; con il movimento ridotto restano ridotti.*

**Party treasure · *Tesoro del gruppo***
- The campaign's Treasure tab is the party's chest: the master puts in coins, gems and items (from the compendium or free); magic items can stay unidentified, showing the players only what they look like until someone identifies them. Coins are shared out evenly among the characters chosen, the change in smaller coins; items are given (or taken by the players for their own character) straight into the inventory, magic included.
  *La scheda Tesoro della campagna è il forziere del gruppo: il master deposita monete, gemme e oggetti (dal compendio o liberi); gli oggetti magici possono restare non identificati, mostrando ai giocatori solo il loro aspetto finché qualcuno non li identifica. Le monete si dividono in parti uguali tra i personaggi scelti, con il resto in monete più piccole; gli oggetti si danno (o i giocatori li prendono per il proprio personaggio) direttamente nell'inventario, magia compresa.*

**Clocks and factions · *Orologi e fazioni***
- Progress clocks of 4, 6, 8 or 12 segments track a threat or a project: the master fills them by hand (at each failure) or lets them fill by themselves every so many hours of game time, and decides whether the players see them. Factions have a standing from hostile to allied, shown as a bar; a shop tied to a faction changes its prices with it (+50% hostile … −20% allied).
  *Gli orologi di progresso da 4, 6, 8 o 12 segmenti tengono traccia di una minaccia o di un progetto: il master li riempie a mano (a ogni fallimento) o li lascia riempire da soli ogni tot ore di tempo di gioco, e decide se i giocatori li vedono. Le fazioni hanno una reputazione da ostile ad alleata, mostrata come una barra; un negozio collegato a una fazione cambia i prezzi di conseguenza (+50% ostile … −20% alleata).*

**Installable app, offline sheet · *App installabile, scheda offline***
- RealmForge can be installed as an app (phone home screen or desktop). Once opened online, the app and the characters read last stay on the device: a sheet opens without network, and its changes are kept on the device and sent as soon as the connection is back. Signing out forgets the characters kept.
  *RealmForge si può installare come app (schermata home del telefono o desktop). Dopo averla aperta online, l'app e gli ultimi personaggi letti restano sul dispositivo: una scheda si apre senza rete e le modifiche vengono conservate sul dispositivo e inviate appena torna la connessione. Uscendo dall'account i personaggi conservati vengono dimenticati.*

**Master tools · *Strumenti del master***
- **Undo** (button or Ctrl+Z) for the master's own edits: tokens, doors, drawings, terrain and fog (the last 40 steps per map).
  ***Annulla** (pulsante o Ctrl+Z) per le proprie modifiche: segnalini, porte, disegni, terreno e nebbia (gli ultimi 40 passi per mappa).*
- **Monster drawer**: monsters gathered from the search with their numbers, placed together in the middle of the view (hidden if needed) or saved as campaign groups (e.g. "Goblin patrol").
  ***Cassetto mostri**: mostri raccolti dalla ricerca con le quantità, piazzati insieme al centro della vista (anche nascosti) o salvati come gruppi della campagna (es. "Pattuglia goblin").*
- Preview as the players see the map, players' tokens blocked, turn reset, encounters started from the map.
  *Anteprima come la vedono i giocatori, blocco dei giocatori, azzeramento del turno, incontri avviati dalla mappa.*

**Connection · *Connessione***
- An indicator at the top tells whether the table is live, reconnecting or offline; when the network comes back the map is read again at once.
  *Un indicatore in alto dice se il tavolo è in linea, in riconnessione o disconnesso; quando torna la rete la mappa si rilegge subito.*

---

## 🛠️ Tech Stack / Tecnologie

| Area | Technology · *Tecnologia* |
|---|---|
| Backend | ASP.NET Core (.NET 10), controllers, ProblemDetails, OpenAPI + Scalar |
| Frontend | Blazor WebAssembly (.NET 10), custom components, Markdig |
| Database | PostgreSQL + Entity Framework Core 10 (Npgsql) |
| Auth | ASP.NET Core Identity API endpoints (bearer tokens) |
| Tests & CI | xUnit, GitHub Actions, PostgreSQL service container, Playwright (headless Chromium) |

## 🧱 Architecture / Architettura

```
RealmForge/
├── RealmForge.Shared          DTOs, enums, FeatPrerequisiteFormatter (used by API and client)
├── RealmForge.Domain          Entities (GameEntity, translations) — server only
├── RealmForge.Infrastructure  DbContext, Identity, migrations, base content seeders
├── RealmForge.Api             REST API, auth endpoints, ownership rules (ContentAccess)
├── RealmForge.Client          Blazor WebAssembly UI
└── RealmForge.Tests           Seed-data integrity, formatter, e-mail template and GUID tests
```

- The client references **only** `RealmForge.Shared`: domain entities never reach the WebAssembly bundle.
  *Il client referenzia **solo** `RealmForge.Shared`: le entità di dominio non finiscono nel bundle WebAssembly.*
- Every localized entity has a `…Translation` table with a unique `(EntityId, Language)` index.
  *Ogni entità localizzata ha una tabella `…Translation` con indice univoco `(EntityId, Language)`.*

---

## 🚀 Getting Started / Avvio in locale

### Prerequisites / Prerequisiti
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL (local · *locale*)

### 1. Database connection / Connessione al database
The connection string is **never committed**: it lives in your user profile via user-secrets.
*La connection string **non è mai nel repository**: sta nel tuo profilo utente tramite user-secrets.*

```bash
cd RealmForge/RealmForge.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=realm_forge_db;Username=postgres;Password=<password>"
dotnet user-secrets list   # check · verifica
```

In Visual Studio: right-click `RealmForge.Api` → **Manage User Secrets** · *tasto destro → **Gestisci segreti utente***.
If the value is missing, the API stops at startup and prints this command.
*Se manca, l'API si ferma all'avvio e mostra questo comando.*

### 2. Administrator (optional) / Amministratore (facoltativo)
Add your e-mail to `Auth:AdminEmails` in `RealmForge.Api/appsettings.Development.json` to manage Homebrew created before accounts existed (it has no author).
*Aggiungi la tua email in `Auth:AdminEmails` per gestire gli Homebrew creati prima degli account (non hanno autore).*

### 3. E-mail (optional) / Email (facoltativo)
New accounts must confirm their e-mail before creating or editing Homebrew. With Gmail, create an **app password** (Google account → Security → 2-Step Verification → App passwords) and store it in user-secrets:
*I nuovi account devono confermare l'email prima di creare o modificare Homebrew. Con Gmail crea una **password per le app** (Account Google → Sicurezza → Verifica in due passaggi → Password per le app) e salvala negli user-secrets:*

```bash
cd RealmForge/RealmForge.Api
dotnet user-secrets set "Email:Host" "smtp.gmail.com"
dotnet user-secrets set "Email:Port" "587"
dotnet user-secrets set "Email:Username" "<you>@gmail.com"
dotnet user-secrets set "Email:Password" "<16-character app password>"
dotnet user-secrets set "Email:FromAddress" "<you>@gmail.com"
```

Without these settings no e-mail is sent: the confirmation and password reset links are written to the API console, so you can open them from there.
*Senza queste impostazioni nessuna email viene inviata: i link di conferma e di reimpostazione della password compaiono nella console dell'API e puoi aprirli da lì.*

Instead of SMTP you can use the [Brevo](https://www.brevo.com) transactional API (free: 300 e-mails a day), which works over HTTPS where SMTP ports are blocked, as on Render's free plan. Verify the sender address in Brevo (Senders, Domains & Dedicated IPs → Senders), create an API key (SMTP & API → API Keys) and set `Email:BrevoApiKey` plus `Email:FromAddress`. When the key is set it takes precedence over the SMTP settings.
*Al posto dell'SMTP puoi usare l'API transazionale di [Brevo](https://www.brevo.com) (gratis: 300 email al giorno), che passa da HTTPS dove le porte SMTP sono bloccate, come sul piano gratuito di Render. Verifica il mittente su Brevo, crea una chiave API e imposta `Email:BrevoApiKey` e `Email:FromAddress`. Se la chiave è presente ha la precedenza sull'SMTP.*

### 4. Run / Avvio

```bash
dotnet run --project RealmForge/RealmForge.Api --launch-profile https
dotnet run --project RealmForge/RealmForge.Client --launch-profile https
```

| | URL |
|---|---|
| Client | https://localhost:7171 |
| API | https://localhost:7086 |
| API reference (Scalar) | https://localhost:7086/scalar |

In development the API applies pending migrations and synchronizes the base content at startup.
*In sviluppo l'API applica le migrazioni in sospeso e sincronizza i contenuti Base all'avvio.*

## ☁️ Deployment / Pubblicazione

**Self-hosting**: [`deploy/steam-machine`](deploy/steam-machine/README.md) runs API and database on a home machine (rootless Podman with Quadlet, Cloudflare Tunnel, automatic image updates, nightly encrypted backups, a desktop control panel); the site stays on Cloudflare Pages.
***Self-hosting**: `deploy/steam-machine` fa girare API e database su una macchina di casa (Podman senza root con Quadlet, Cloudflare Tunnel, aggiornamento automatico dell'immagine, backup notturni cifrati, pannello di controllo sul desktop); il sito resta su Cloudflare Pages.*

Free setup: API on [Render](https://render.com) (Docker, `render.yaml`), database on [Neon](https://neon.com), client on [Cloudflare Pages](https://pages.cloudflare.com). Every push to `release` redeploys API and client.
*Configurazione gratuita: API su Render, database su Neon, client su Cloudflare Pages. Ogni push su `release` ripubblica API e client.*

Branches · *Rami*: `develop` (work, PRs) → `release` (default branch, published: one commit per version, without the development history). To publish what is on `develop` · *Per pubblicare ciò che è su `develop`*:

```bash
git fetch origin
git switch release
git pull
git read-tree -u --reset origin/develop   # files exactly as on develop, deletions included · file identici a develop, eliminazioni comprese
git commit -m "release: v0.2.0"
git push
git switch develop
```

`release` has no history in common with `develop`: never merge it or open pull requests towards it, update it only with these commands. Pull requests target `develop`.
*`release` non ha storia in comune con `develop`: non va mai unito né usato come destinazione di pull request, si aggiorna solo con questi comandi. Le pull request puntano a `develop`.*

1. **Neon**: create a project and copy the connection string (`postgresql://…?sslmode=require`) · *crea un progetto e copia la connection string*.
2. **Render**: New → Blueprint → this repository. Fill in the values the Blueprint asks for (connection string, client address, e-mail: `Email__BrevoApiKey` and `Email__FromAddress`, since the free plan blocks SMTP) · *compila i valori richiesti (per le email la chiave Brevo e il mittente, perché il piano gratuito blocca l'SMTP)*.
3. **Cloudflare Pages**: create a project (Direct Upload) and an API token with *Cloudflare Pages · Edit* · *crea un progetto e un token API*.
4. **GitHub** → Settings → Secrets and variables → Actions · *aggiungi*:
   secrets `CLOUDFLARE_API_TOKEN`, `CLOUDFLARE_ACCOUNT_ID`; variables `API_BASE_URL` (Render address), `CLOUDFLARE_PAGES_PROJECT`.

The free API sleeps after 15 minutes without requests, so the `keep-alive` workflow calls `/health` every 10 minutes (it does not touch the database, Neon still suspends when idle). Tokens and e-mail links survive restarts (data protection keys are stored in the database).
*L'API gratuita si sospende dopo 15 minuti senza richieste: il workflow `keep-alive` chiama `/health` ogni 10 minuti (senza toccare il database). Token e link nelle email sopravvivono ai riavvii.*

Scheduled workflows run from `release` and GitHub disables them after 60 days without commits: re-enable them from the Actions tab if that happens.
*I workflow programmati partono da `release` e GitHub li disattiva dopo 60 giorni senza commit: in quel caso riattivali dalla scheda Actions.*

**Backups / Backup**: `backup-db` dumps the Neon database every Sunday, encrypts it and keeps it 90 days as a workflow artifact. Secrets: `BACKUP_DATABASE_URL` (Neon connection string) and `BACKUP_PASSPHRASE` (long random passphrase, keep a copy in a password manager: without it the backups cannot be opened). The repository is public, so artifacts are never stored unencrypted.
*`backup-db` salva ogni domenica il database cifrato come artifact per 90 giorni. Secret: `BACKUP_DATABASE_URL` e `BACKUP_PASSPHRASE` (conservane una copia: senza non si aprono i backup).*

```bash
gpg -d realmforge-20261018-032300.dump.gpg > realmforge.dump
pg_restore --clean --if-exists --no-owner --no-privileges -d "postgresql://…" realmforge.dump   # pg_restore 17+
```

---

## 📜 Content Rules / Regole sui contenuti

| | Base | Homebrew |
|---|---|---|
| Origin · *Origine* | Seeders only · *Solo seeder* | Created from the UI/API · *Creato da UI/API* |
| Text source · *Fonte del testo* | `RealmForge` text, or `SRD 5.1` / `SRD 5.2` when taken from the SRD · *testo RealmForge, oppure SRD 5.1 / 5.2* | The author · *L'autore* |
| Read · *Lettura* | Everyone · *Tutti* | Everyone · *Tutti* |
| Edit / delete · *Modifica / elimina* | Nobody (403) · *Nessuno* | Author or admin · *Autore o amministratore* |

- Content created through the API is **always** Homebrew; the `IsOfficialSRD` flag cannot be set by clients.
  *I contenuti creati via API sono **sempre** Homebrew; il flag `IsOfficialSRD` non è impostabile dal client.*
- Responses include `CanEdit`, computed by the server for the current user; the UI shows Edit/Delete only when it is `true`.
  *Le risposte includono `CanEdit`, calcolato dal server; l'interfaccia mostra Modifica/Elimina solo se è `true`.*
- SRD texts are used in English as published; the Italian versions are RealmForge translations that follow the official Italian game terms and use metric units (1,5 m per 5 feet). Content outside the SRD keeps only names and mechanics, with descriptions written for RealmForge.
  *I testi SRD sono usati in inglese come pubblicati; le versioni italiane sono traduzioni RealmForge che seguono la terminologia italiana ufficiale e usano il sistema metrico (1,5 m ogni 5 piedi). Per i contenuti fuori dall'SRD si mantengono solo nomi e meccaniche, con descrizioni scritte per RealmForge.*

## 🌍 Localization / Localizzazione

- **Data** · *Dati*: translations are stored per language; the API picks **requested language → English → any available**.
  *Le traduzioni sono salvate per lingua; l'API sceglie **lingua richiesta → inglese → qualsiasi disponibile**.*
- **UI texts** · *Testi dell'interfaccia*: `RealmForge.Client/Localization/UiText.cs`.
- **Feat prerequisites** · *Prerequisiti dei talenti*: stored as data (level, abilities, score, feature) and rendered by `FeatPrerequisiteFormatter` with the correct wording per ruleset (e.g. 2014 "Proficiency with medium armor" / 2024 "Medium Armor Training").
  *Salvati come dati e resi da `FeatPrerequisiteFormatter` con la dicitura corretta per regolamento.*

## 🌱 Seed Data Conventions / Convenzioni sui contenuti Base

- One seeder file per entry (`FeatsData/`, `SpeciesData/`, `BackgroundsData/`), exposing `public static Feat Build()` / `Species Build()` / `Background Build()`; `FeatSeeder`, `SpeciesSeeder` and `BackgroundSeeder` discover them automatically, so a new file cannot be forgotten.
  *Un file per voce con `Build()`; `FeatSeeder`, `SpeciesSeeder` e `BackgroundSeeder` li trovano da soli, quindi un nuovo file non può essere dimenticato.*
- Base content whose text is not in the SRD is written for RealmForge (official game terms, same mechanics) and has source `RealmForge`; text taken from the SRD has source `Srd51` / `Srd52`. Dice tables keep the same order in every language, so a roll gives the same result.
  *I contenuti Base il cui testo non è nell'SRD sono scritti per RealmForge (termini di gioco ufficiali, stesse meccaniche) con fonte `RealmForge`; i testi presi dall'SRD hanno fonte `Srd51` / `Srd52`. Le tabelle dei dadi hanno lo stesso ordine in ogni lingua, così un tiro dà lo stesso risultato.*
- At startup missing base rows are inserted and existing ones are **updated** to match the seed (one query, one transaction).
  *All'avvio le righe Base mancanti vengono inserite e quelle esistenti **aggiornate** (una query, una transazione).*
- Duplicate ids fail fast at startup and in the tests.
  *Gli id duplicati bloccano l'avvio e fanno fallire i test.*
- **New modules** must generate ids with `DeterministicGuid` (UUIDv5) from readable keys instead of hand-written GUIDs:
  *I **nuovi moduli** devono generare gli id con `DeterministicGuid` invece di GUID scritti a mano:*

  ```csharp
  DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball");        // entity
  DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball", "it");  // Italian translation
  ```
  Existing ids are kept as they are: changing them would orphan rows in existing databases.
  *Gli id esistenti restano invariati: cambiarli scollegherebbe le righe nei database esistenti.*

## 🗄️ Migrations / Migrazioni

```bash
dotnet ef migrations add <Name> --project RealmForge/RealmForge.Infrastructure --startup-project RealmForge/RealmForge.Api
```

No local SDK tools? Push a commit whose message contains `[ef-migration:<Name>]`: GitHub generates the migration and commits it to the branch.
*Senza strumenti locali? Fai un push con `[ef-migration:<Nome>]` nel messaggio del commit: GitHub genera la migrazione e la aggiunge al branch.*

## 🧪 Tests & CI / Test e CI

Every push and pull request runs four jobs · *Ogni push e pull request esegue quattro job*:

| Job | Checks · *Verifica* |
|---|---|
| `build` | Build without warnings + unit tests · *Compilazione senza warning + test* |
| `database` | Migrations on PostgreSQL 17, data preservation, base content seeding and re-sync, auth and ownership rules (401/403/204), e-mail confirmation, password reset, visibility, character rules and derived values, passkeys, campaigns, encounters and the rules of the virtual tabletop (turns, attacks, saves, vision, undo, floors) · *Migrazioni, conservazione dei dati, seeding, regole di accesso, conferma email, reset password, visibilità, regole e valori derivati dei personaggi, passkey, campagne, incontri e regole del tavolo virtuale (turni, attacchi, tiri salvezza, visione, annulla, piani)* |
| `container` | API image run as on Render (Production, PORT, Neon-style URL, migrations, /health, keys kept across restarts, e-mail through a mock Brevo API, encrypted backup and restore) and client publish · *Immagine dell'API eseguita come su Render e pubblicazione del client* |
| `ui` | Headless browser: dashboard, registration and e-mail confirmation across tabs, password change and recovery, search and filters, modal layout, Base content rendering, character wizard, sheet, PDF and level up, phone layout at 375 px, language switch, virtual tabletop · *Browser headless: tavolo virtuale, dashboard, creazione guidata, scheda, PDF e avanzamento del personaggio, layout a 375 px, registrazione e conferma email tra schede, cambio e recupero password, ricerca e filtri, layout dei modali, contenuti Base, cambio lingua* |

```bash
dotnet test RealmForge/RealmForge.slnx
```

---

## 🗺️ Roadmap

- [x] Backgrounds 2024 (with Origin feats) · *Background 2024 (con i Talenti di Origine)*
- [x] Species seeders with deterministic ids and re-sync, as for feats · *Seeder delle specie con id deterministici e risincronizzazione*
- [x] Remember the selected language across reloads · *Ricordare la lingua scelta tra un ricaricamento e l'altro*
- [x] E-mail confirmation, Homebrew visibility and password recovery · *Conferma email, visibilità degli Homebrew e recupero password*
- [x] Spells 2014 · *Incantesimi 2014*
- [x] Spells 2024 · *Incantesimi 2024*
- [x] Classes 2014 · *Classi 2014*
- [x] Classes 2024 · *Classi 2024*
- [x] Equipment · *Equipaggiamento*
- [x] Rules glossary and conditions, linked in the texts · *Glossario delle regole e condizioni, collegati nei testi*
- [x] Character wizard, interactive sheet, multiclassing, level up and PDF · *Creazione guidata, scheda interattiva, multiclasse, avanzamento e PDF*
- [x] Monsters, NPCs and magic items · *Mostri, PNG e oggetti magici*
- [x] Campaigns, sessions, encounters and shared roll log · *Campagne, sessioni, incontri e registro dei tiri condiviso*
- [x] Virtual tabletop: maps, fog, objects, initiative and turns · *Tavolo virtuale: mappe, nebbia, oggetti, iniziativa e turni*
- [x] Advanced combat: saves, Metamagic, damage defenses, Ready, grapples, auras, summons and mounts · *Combattimento avanzato: tiri salvezza, Metamagia, difese ai danni, Preparare, lotta, aure, evocazioni e cavalcature*
- [x] Dynamic vision with lights and darkvision · *Visione dinamica con luci e scurovisione*
- [x] Master tools: undo, monster drawer and groups, floors, stairs and portals · *Strumenti del master: annulla, cassetto e gruppi di mostri, piani, scale e portali*
- [x] Table stability: connection indicator · *Stabilità del tavolo: indicatore di connessione*
- [x] Session log export · *Esportazione del registro di sessione*
- [x] Pinned pages in the sidebar · *Pagine fissate nella barra laterale*
- [x] Homebrew automation builder · *Costruttore di automazioni Homebrew*

## 📄 License / Licenza

Source code released under the [MIT License](LICENSE).
*Codice sorgente rilasciato sotto licenza [MIT](LICENSE).*

### SRD attribution

Entries whose source is shown as SRD 5.1 or SRD 5.2 in the app use text from the System Reference Documents. All other base content is text written for RealmForge; the game rules it describes (for example the traits of the SRD species) are adapted from the SRDs.
*Le voci con fonte SRD 5.1 o SRD 5.2 usano il testo dei System Reference Document. Tutti gli altri contenuti Base sono testi scritti per RealmForge; le regole di gioco che descrivono (ad esempio i tratti delle specie presenti negli SRD) sono adattate dagli SRD.*

This work includes material taken from the System Reference Document 5.1 ("SRD 5.1") by Wizards of the Coast LLC and available at https://dnd.wizards.com/resources/systems-reference-document. The SRD 5.1 is licensed under the Creative Commons Attribution 4.0 International License available at https://creativecommons.org/licenses/by/4.0/legalcode.

This work includes material from the System Reference Document 5.2 ("SRD 5.2") by Wizards of the Coast LLC, available at https://www.dndbeyond.com/srd. The SRD 5.2 is licensed under the Creative Commons Attribution 4.0 International License, available at https://creativecommons.org/licenses/by/4.0/legalcode.

RealmForge is compatible with fifth edition. · *RealmForge è compatibile con la quinta edizione.*

### Third-party assets

The 3D dice use [dice-box-threejs](https://github.com/3d-dice/dice-box-threejs) (MIT, which bundles three.js and cannon-es, both MIT) with its dice sounds, kept in `wwwroot/lib/dice3d` with their license.
