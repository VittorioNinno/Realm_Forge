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
| Spells · *Incantesimi* | 📋 | Planned · *Pianificato* |
| Classes · *Classi* | 📋 | Planned · *Pianificato* |
| Character sheet · *Scheda personaggio* | 📋 | Planned · *Pianificato* |

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

Free setup: API on [Render](https://render.com) (Docker, `render.yaml`), database on [Neon](https://neon.com), client on [Cloudflare Pages](https://pages.cloudflare.com). Every push to `main` redeploys API and client.
*Configurazione gratuita: API su Render, database su Neon, client su Cloudflare Pages. Ogni push su `main` ripubblica API e client.*

1. **Neon**: create a project and copy the connection string (`postgresql://…?sslmode=require`) · *crea un progetto e copia la connection string*.
2. **Render**: New → Blueprint → this repository. Fill in the values the Blueprint asks for (connection string, client address, e-mail) · *compila i valori richiesti*.
3. **Cloudflare Pages**: create a project (Direct Upload) and an API token with *Cloudflare Pages · Edit* · *crea un progetto e un token API*.
4. **GitHub** → Settings → Secrets and variables → Actions · *aggiungi*:
   secrets `CLOUDFLARE_API_TOKEN`, `CLOUDFLARE_ACCOUNT_ID`; variables `API_BASE_URL` (Render address), `CLOUDFLARE_PAGES_PROJECT`.

The free API sleeps after 15 minutes without requests: the first page after a pause waits about a minute. Tokens and e-mail links survive restarts (data protection keys are stored in the database).
*L'API gratuita si sospende dopo 15 minuti senza richieste: la prima pagina dopo una pausa attende circa un minuto. Token e link nelle email sopravvivono ai riavvii.*

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
| `database` | Migrations on PostgreSQL 17, data preservation, base content seeding and re-sync, auth and ownership rules (401/403/204), e-mail confirmation, password reset, visibility · *Migrazioni, conservazione dei dati, seeding, regole di accesso, conferma email, reset password, visibilità* |
| `container` | API image run as on Render (Production, PORT, Neon-style URL, migrations, /health, keys kept across restarts) and client publish · *Immagine dell'API eseguita come su Render e pubblicazione del client* |
| `ui` | Headless browser: dashboard, registration and e-mail confirmation across tabs, password change and recovery, search and filters, modal layout, Base content rendering, language switch · *Browser headless: dashboard, registrazione e conferma email tra schede, cambio e recupero password, ricerca e filtri, layout dei modali, contenuti Base, cambio lingua* |

```bash
dotnet test RealmForge/RealmForge.slnx
```

---

## 🗺️ Roadmap

- [x] Backgrounds 2024 (with Origin feats) · *Background 2024 (con i Talenti di Origine)*
- [x] Species seeders with deterministic ids and re-sync, as for feats · *Seeder delle specie con id deterministici e risincronizzazione*
- [x] Remember the selected language across reloads · *Ricordare la lingua scelta tra un ricaricamento e l'altro*
- [x] E-mail confirmation, Homebrew visibility and password recovery · *Conferma email, visibilità degli Homebrew e recupero password*
- [ ] Spells · *Incantesimi*
- [ ] Classes · *Classi*
- [ ] Character sheet · *Scheda personaggio*
- [ ] Campaigns and sessions · *Campagne e sessioni*

## 📄 License / Licenza

Source code released under the [MIT License](LICENSE).
*Codice sorgente rilasciato sotto licenza [MIT](LICENSE).*

### SRD attribution

Entries whose source is shown as SRD 5.1 or SRD 5.2 in the app use text from the System Reference Documents. All other base content is text written for RealmForge; the game rules it describes (for example the traits of the SRD species) are adapted from the SRDs.
*Le voci con fonte SRD 5.1 o SRD 5.2 usano il testo dei System Reference Document. Tutti gli altri contenuti Base sono testi scritti per RealmForge; le regole di gioco che descrivono (ad esempio i tratti delle specie presenti negli SRD) sono adattate dagli SRD.*

This work includes material taken from the System Reference Document 5.1 ("SRD 5.1") by Wizards of the Coast LLC and available at https://dnd.wizards.com/resources/systems-reference-document. The SRD 5.1 is licensed under the Creative Commons Attribution 4.0 International License available at https://creativecommons.org/licenses/by/4.0/legalcode.

This work includes material from the System Reference Document 5.2 ("SRD 5.2") by Wizards of the Coast LLC, available at https://www.dndbeyond.com/srd. The SRD 5.2 is licensed under the Creative Commons Attribution 4.0 International License, available at https://creativecommons.org/licenses/by/4.0/legalcode.

RealmForge is compatible with fifth edition. · *RealmForge è compatibile con la quinta edizione.*
