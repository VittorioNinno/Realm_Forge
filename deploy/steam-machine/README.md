# RealmForge sulla Steam Machine

API e database di RealmForge sulla tua Steam Machine, sempre accesi, pubblicati su internet con **Cloudflare Tunnel**: niente porte aperte sul router, niente problemi di IP dinamico, niente pause come sul piano gratuito di Render. Il sito resta su Cloudflare Pages: cambia solo l'indirizzo dell'API.

```
Browser ──► https://myrealmforge.com            Cloudflare Pages (il sito, come oggi)
        └─► https://api.myrealmforge.com  ──►  Cloudflare Tunnel ──► Steam Machine
                                                              ├─ realmforge-tunnel  (cloudflared)
                                                              ├─ realmforge-api     (immagine da GitHub, si aggiorna da sola)
                                                              └─ realmforge-db      (PostgreSQL 18, volume persistente)
Backup: ogni notte, cifrati ──► ~/realmforge/backups ──► copia fuori casa (rclone)
```

Tutto gira come container **Podman senza root** dell'utente, avviati da systemd all'accensione (Quadlet). Il dominio è `myrealmforge.com`: il sito su `https://myrealmforge.com`, l'API su `https://api.myrealmforge.com`.

---

## 0. Prerequisiti

- **Podman 4.4 o più recente** e **gpg**. Controlla nel terminale (in modalità Desktop: Konsole):
  ```bash
  podman --version
  gpg --version | head -1
  ```
  Sulle versioni recenti di SteamOS Podman è già incluso. Se non c'è, non installarlo con `pacman` sul sistema: su SteamOS gli aggiornamenti lo cancellerebbero. Scrivimi l'output di `cat /etc/os-release` e scegliamo il metodo adatto. Su una distribuzione Linux normale basta il gestore di pacchetti (`sudo apt install podman`, `sudo dnf install podman`…).
- **La macchina non deve andare in sospensione**: nelle impostazioni di alimentazione disattiva la sospensione automatica, sia in modalità Desktop sia in modalità Gioco.
- **Il dominio su Cloudflare** (registrato su Cloudflare Registrar: i DNS sono già lì).
- Un account GitHub con accesso al repository, per scaricare questa cartella.

## 1. Installazione

```bash
git clone https://github.com/VittorioNinno/Realm_Forge.git ~/realmforge-src
cd ~/realmforge-src/deploy/steam-machine
./scripts/install.sh
```

Lo script:
- crea `~/realmforge/` (configurazione, backup, script) con permessi riservati al tuo utente;
- genera una password casuale per il database e la scrive in `config/db.env` e `config/api.env`;
- installa i container in `~/.config/containers/systemd/` e il backup notturno in `~/.config/systemd/user/`;
- abilita l'avvio dei servizi anche senza sessione aperta (`loginctl enable-linger`), il backup alle 03:30 e l'aggiornamento automatico delle immagini.

Si può rilanciare quando questa cartella cambia (`git pull` e di nuovo `./scripts/install.sh`): la configurazione già scritta non viene toccata.

## 2. Configurazione

Apri i file in `~/realmforge/config/` (per esempio `nano ~/realmforge/config/api.env`):

**api.env**
- il dominio `myrealmforge.com` è già scritto; controlla che `Email__FromAddress` sia il mittente verificato su Brevo;
- `Email__BrevoApiKey`: la chiave API di Brevo (la stessa impostata su Render);
- `Auth__AdminEmails__0`: la tua email da amministratore.

**backup.env**
- `BACKUP_PASSPHRASE`: una frase lunga e casuale. Salvala anche nel password manager: senza di lei i backup non si aprono.

La riga con la password del database non va cambiata.

## 3. Cloudflare Tunnel

1. dash.cloudflare.com → **Zero Trust** → **Networks → Tunnels** → **Create a tunnel** → **Cloudflared** → nome `realmforge`.
2. Nella schermata di installazione scegli **Docker**: copia solo il valore lungo dopo `--token` e incollalo in `~/realmforge/config/tunnel.env` dopo `TUNNEL_TOKEN=`.
3. **Public hostname**: sottodominio `api`, dominio `myrealmforge.com`, servizio **HTTP**, URL `realmforge-api:8080`. Cloudflare crea da solo il record DNS `api.myrealmforge.com`.

## 4. Primo avvio e trasferimento dei dati da Neon

```bash
systemctl --user start realmforge-db
~/realmforge/scripts/migrate-from-neon.sh
```

Lo script chiede la stringa di connessione di Neon, la stessa di `ConnectionStrings__DefaultConnection` su Render: non la salva e non la mostra. Esporta tutto da Neon, lo importa nel database locale e ti dice quanti account e personaggi ha trovato. Neon viene solo letto.

Poi:
```bash
systemctl --user start realmforge-api realmforge-tunnel
~/realmforge/scripts/status.sh
```

Il primo avvio dell'API applica le migrazioni (già presenti nei dati importati) e sincronizza i contenuti Base: ci vuole circa un minuto. Quando `status.sh` mostra `200` per `https://api.myrealmforge.com/health`, l'API è online.

> **Immagine dell'API.** La prima volta che GitHub la pubblica (workflow *publish-api-image*, a ogni release), il pacchetto `realmforge-api` è privato. Su GitHub: profilo → **Packages → realmforge-api → Package settings → Change visibility → Public**. Contiene solo il programma, nessun segreto. In alternativa: `podman login ghcr.io` con un token che può leggere i pacchetti.

## 5. Collegare il sito

1. GitHub → repository → **Settings → Secrets and variables → Actions → Variables**: `API_BASE_URL` = `https://api.myrealmforge.com/`.
2. **Actions → deploy-client → Run workflow** (oppure la prossima release): il sito userà il nuovo indirizzo.
3. Il sito sul dominio: Cloudflare → **Workers & Pages** → il progetto del sito → **Custom domains → Set up a custom domain** → `myrealmforge.com`.
4. Prova accesso, compendi e un personaggio.
5. Quando tutto funziona, su Render **sospendi** il servizio `realmforge-api` (Settings → Suspend). Non deve restare acceso: scriverebbe su Neon dati che il nuovo server non vede. Neon resta com'è, come copia del giorno del trasloco: tienilo almeno un mese.

## 6. Backup

- Ogni notte alle 03:30 un dump cifrato (AES-256) in `~/realmforge/backups/daily/`. La domenica una copia va anche in `weekly/`. Se ne tengono 14 giornalieri e 8 settimanali.
- **Copia fuori casa** (consigliata: un backup sulla stessa macchina non ti protegge da guasti, furti o incendi):
  ```bash
  ~/realmforge/scripts/rclone-config.sh     # guida interattiva: Google Drive, OneDrive, Dropbox…
  ```
  poi in `backup.env` imposta per esempio `RCLONE_REMOTE=gdrive:RealmForge-backup`. I file sono già cifrati prima di uscire di casa.
- **Avviso se i backup si fermano** (facoltativo): crea un controllo gratuito su healthchecks.io con periodo 1 giorno e metti l'URL in `HEALTHCHECK_URL`. Se una notte il backup non arriva, ti scrive un'email.
- **Prova subito** che funzioni:
  ```bash
  ~/realmforge/scripts/backup.sh
  ```
- **Ripristino** di un backup (sostituisce il database; l'API si ferma e riparte da sola):
  ```bash
  ~/realmforge/scripts/restore.sh ~/realmforge/backups/daily/realmforge-AAAAMMGG-HHMMSS.dump.gpg
  ```
  Conviene provarlo una volta, così sai che i backup si aprono davvero.

## 7. Aggiornamenti

A ogni release GitHub pubblica la nuova immagine dell'API. `podman-auto-update.timer` la scarica ogni giorno e riavvia il container. Per aggiornare subito:
```bash
podman auto-update
```
Le migrazioni del database si applicano da sole all'avvio, come su Render. Anche `cloudflared` si aggiorna allo stesso modo. Per PostgreSQL, gli aggiornamenti dentro la versione 18 arrivano con `podman pull docker.io/library/postgres:18`. Un passaggio a una versione nuova (19) va fatto con un backup e un ripristino, mai cambiando solo il numero.

## 8. Comandi utili

| Cosa | Comando |
|---|---|
| Stato di tutto | `~/realmforge/scripts/status.sh` |
| Log dell'API (in diretta) | `journalctl --user -u realmforge-api -f` |
| Log del tunnel | `journalctl --user -u realmforge-tunnel -n 100` |
| Riavviare l'API | `systemctl --user restart realmforge-api` |
| Fermare tutto | `systemctl --user stop realmforge-tunnel realmforge-api realmforge-db` |
| Console SQL | `podman exec -it realmforge-db psql -U realmforge` |

## 9. Problemi comuni

- **`status.sh` dice 502 o 530**: il tunnel è su, ma l'API no (sta partendo, o è in errore): guarda `journalctl --user -u realmforge-api -n 200`.
- **Dopo il riavvio della macchina non riparte nulla**: controlla che il linger sia attivo (`loginctl show-user $USER | grep Linger` deve dire `yes`).
- **`podman` non trova l'immagine `ghcr.io/vittorioninno/realmforge-api`**: il pacchetto è ancora privato (vedi il riquadro al punto 4), oppure la prima release dopo questa modifica non è ancora stata pubblicata.
- **Il sito dà errore di rete ma `/health` risponde**: l'origine del sito non è in `Cors__AllowedOrigins__*` di `api.env` (dopo la modifica: `systemctl --user restart realmforge-api`).
