# RealmForge

[🇬🇧 English]  
A modular, multi-language web platform for managing TTRPG campaigns, sessions, and rules (inspired by modern D&D mechanics).

[🇮🇹 Italiano]  
Piattaforma web modulare e multilingua per la gestione di campagne, sessioni e regole TTRPG (ispirata alle meccaniche moderne di D&D).

---

## 🛠️ Tech Stack / Tecnologie Principali
- **Backend:** ASP.NET Core (C#)
- **Frontend:** Blazor WebAssembly / Custom UI
- **Database:** PostgreSQL (Entity Framework Core)

## 🌍 Project Goals / Obiettivi del Progetto
- **Native multi-language support** · *Supporto nativo multilingua*  
  Starting with English and Italian, built for future localizations.  
  *Inizialmente in Inglese e Italiano, con architettura aperta a future localizzazioni.*

- **Flexible TTRPG Compendium** · *Compendio e Schede Flessibili*  
  Modular management of character sheets, class rules, species, and compendiums.  
  *Gestione flessibile di schede personaggio, regole di classe, specie e compendi.*

- **Licensing & Content Separation** · *Separazione Contenuti & Licenze*  
  Clear boundary between official SRD material (public domain) and Homebrew/private content.  
  *Netta separazione tra contenuti ufficiali SRD (pubblico dominio) e Homebrew/privati.*

## 🚀 Local setup / Avvio in locale

1. **Database connection** · *Connessione al database* (stored with user-secrets, never committed · *salvata con user-secrets, mai nel repository*)
   ```bash
   cd RealmForge/RealmForge.Api
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=realm_forge_db;Username=postgres;Password=<password>"
   ```
2. **Admin e-mail** · *Email amministratore* (optional · *facoltativo*): add your account to `Auth:AdminEmails` in `RealmForge.Api/appsettings.Development.json` to manage Homebrew created before authentication.
3. **Run** · *Avvio*
   ```bash
   dotnet run --project RealmForge/RealmForge.Api --launch-profile https
   dotnet run --project RealmForge/RealmForge.Client --launch-profile https
   ```
   In development the API applies pending migrations and synchronizes the SRD data at startup.
   *In sviluppo l'API applica le migrazioni e sincronizza i dati SRD all'avvio.*

## 🧪 CI

Every push builds the solution, runs the tests, checks migrations and seeding on PostgreSQL and drives the UI in a headless browser.
To generate an EF Core migration on GitHub, push a commit whose message contains `[ef-migration:MigrationName]`.

## 📄 License / Licenza
Released under the [MIT License](LICENSE) / Rilasciato sotto licenza [MIT License](LICENSE).