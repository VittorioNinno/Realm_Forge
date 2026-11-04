#!/usr/bin/env python3
"""RealmForge on the phone through ntfy (https://ntfy.sh), from anywhere.

- Alerts: every few minutes it checks database, API, tunnel and the public /health. When something stays down for two
  checks in a row it sends an alert, and another one when everything works again. Also: started (after a reboot or a
  power cut), and no backup for more than a day and a half.
- Commands: a message on the command topic, with the PIN, runs a fixed action. The commands are stato, avvia, ferma,
  riavvia, riavvia tutto, aggiorna, backup, log and aiuto. The answer comes back on the alerts topic. The alerts carry
  buttons for the most common commands.

Configuration in ~/realmforge/config/ntfy.env (written by install.sh with random topics and PIN). Only the standard
library: SteamOS has python3 but no pip. Run by systemd as realmforge-ntfy.service.
"""
import json
import pathlib
import subprocess
import sys
import threading
import time
import urllib.error
import urllib.request

BASE = pathlib.Path.home() / "realmforge"
SERVICES = [("realmforge-db", "Database"), ("realmforge-api", "API"), ("realmforge-tunnel", "Tunnel")]
STATES = {"active": "🟢 attivo", "activating": "🟡 in avvio", "reloading": "🟡 in avvio", "failed": "🔴 in errore"}


def load_env(path):
    values = {}
    try:
        for line in path.read_text(encoding="utf-8").splitlines():
            line = line.strip()
            if line and not line.startswith("#") and "=" in line:
                key, value = line.split("=", 1)
                values[key.strip()] = value.strip().strip('"').strip("'")
    except FileNotFoundError:
        pass
    return values


config = load_env(BASE / "config" / "ntfy.env")
SERVER = config.get("NTFY_SERVER", "https://ntfy.sh").rstrip("/")
TOPIC = config.get("NTFY_TOPIC", "")
COMMANDS = config.get("NTFY_CMD_TOPIC", "")
PIN = config.get("NTFY_PIN", "")
TOKEN = config.get("NTFY_TOKEN", "")
EVERY = max(1, int(config.get("NTFY_CHECK_MINUTES", "5") or "5")) * 60

origin = load_env(BASE / "config" / "api.env").get("Email__ClientBaseUrl", "https://myrealmforge.com")
HEALTH = origin.replace("https://", "https://api.", 1).rstrip("/") + "/health"

lock = threading.Lock()

# Stopped on purpose with "ferma": no alerts until "avvia"
paused = threading.Event()


def log(text):
    print(text, flush=True)


def auth():
    return {"Authorization": f"Bearer {TOKEN}"} if TOKEN else {}


def button(label, command):
    # A button that publishes the command (with the PIN) on the command topic
    action = {"action": "http", "label": label, "url": f"{SERVER}/{COMMANDS}", "method": "POST",
              "body": f"{command} {PIN}".strip(), "clear": False}
    if TOKEN:
        action["headers"] = auth()
    return action


def publish(message, title="RealmForge", priority=3, tags=None, buttons=True):
    payload = {"topic": TOPIC, "title": title, "message": message[:3900], "priority": priority}
    if tags:
        payload["tags"] = tags
    if buttons:
        payload["actions"] = [button("Stato", "stato"), button("Riavvia l'API", "riavvia"), button("Log", "log")]
    request = urllib.request.Request(SERVER, data=json.dumps(payload).encode("utf-8"), method="POST",
                                     headers={"Content-Type": "application/json", **auth()})
    try:
        urllib.request.urlopen(request, timeout=20).read()
    except (urllib.error.URLError, OSError) as error:
        log(f"ntfy: invio non riuscito ({error})")


def run(*command, timeout=300):
    try:
        done = subprocess.run(command, capture_output=True, text=True, timeout=timeout)
        return done.returncode, (done.stdout + done.stderr).strip()
    except subprocess.TimeoutExpired:
        return 1, "tempo scaduto"
    except OSError as error:
        return 1, str(error)


def unit_state(name):
    return run("systemctl", "--user", "is-active", name, timeout=20)[1] or "unknown"


def health():
    started = time.monotonic()
    try:
        with urllib.request.urlopen(HEALTH, timeout=20) as response:
            return response.status, time.monotonic() - started
    except urllib.error.HTTPError as error:
        return error.code, time.monotonic() - started
    except (urllib.error.URLError, OSError):
        return 0, time.monotonic() - started


def last_backup():
    files = sorted((BASE / "backups" / "daily").glob("*.dump.gpg"), key=lambda f: f.stat().st_mtime, reverse=True)
    return files[0].stat().st_mtime if files else None


def report():
    lines = [f"{label}: {STATES.get(unit_state(name), '⚪ fermo')}" for name, label in SERVICES]
    code, seconds = health()
    lines.append(f"Sito ({HEALTH.split('//')[1]}): " + (f"🟢 {code} in {seconds:.1f} s" if code == 200 else f"🔴 {code or 'non raggiungibile'}"))
    backup = last_backup()
    lines.append("Ultimo backup: " + (time.strftime("%d/%m %H:%M", time.localtime(backup)) if backup else "nessuno"))
    return "\n".join(lines)


def healthy():
    return all(unit_state(name) == "active" for name, _ in SERVICES) and health()[0] == 200


HELP = (f"Comandi (scrivili sul topic dei comandi, seguiti dal PIN, es. \"riavvia {PIN or '<PIN>'}\"):\n"
        "stato · avvia · ferma · riavvia (l'API) · riavvia tutto · aggiorna · backup · log · aiuto")


def execute(command):
    if command in ("stato", "status"):
        return "Stato", report(), 3
    if command in ("riavvia", "restart", "riavvia api"):
        code, out = run("systemctl", "--user", "restart", "realmforge-api")
        return "Riavvio dell'API", ("Riavviata: pronta in circa un minuto." if code == 0 else f"Non riuscito:\n{out}"), 3
    if command in ("riavvia tutto", "restart all"):
        code, out = run("systemctl", "--user", "restart", *[name for name, _ in SERVICES])
        return "Riavvio di tutto", ("Database, API e tunnel riavviati." if code == 0 else f"Non riuscito:\n{out}"), 3
    if command in ("avvia", "start"):
        paused.clear()
        code, out = run("systemctl", "--user", "start", *[name for name, _ in SERVICES])
        return "Avvio", ("Avviati: l'API è pronta in circa un minuto." if code == 0 else f"Non riuscito:\n{out}"), 3
    if command in ("ferma", "stop"):
        paused.set()
        code, out = run("systemctl", "--user", "stop", "realmforge-tunnel", "realmforge-api", "realmforge-db")
        return "Arresto", ("RealmForge fermato: il sito non funziona finché non mandi \"avvia\"." if code == 0 else f"Non riuscito:\n{out}"), 4
    if command in ("aggiorna", "update"):
        code, out = run("podman", "auto-update", timeout=600)
        return "Aggiornamento", (out or "Nessun aggiornamento.") if code == 0 else f"Non riuscito:\n{out}", 3
    if command == "backup":
        code, out = run("systemctl", "--user", "start", "realmforge-backup.service", timeout=1800)
        return "Backup", ("Backup completato.\n" + report().splitlines()[-1]) if code == 0 else f"Non riuscito:\n{out}", 3
    if command == "log":
        _, out = run("journalctl", "--user", "-u", "realmforge-api", "-n", "40", "--no-pager", "-o", "cat", timeout=30)
        return "Log dell'API", out[-3500:] or "vuoto", 2
    if command in ("aiuto", "help", "?"):
        return "Aiuto", HELP, 2
    return "Comando sconosciuto", HELP, 2


def handle(text):
    words = text.strip().lower().split()
    if PIN and PIN not in words:
        publish("PIN mancante o errato: il comando non è stato eseguito.", "RealmForge: comando rifiutato", 4, ["no_entry"], buttons=False)
        return
    command = " ".join(w for w in words if w != PIN)
    log(f"comando: {command}")
    with lock:
        title, message, priority = execute(command)
    publish(message, f"RealmForge: {title}", priority, ["robot"])


def listen():
    since = None
    while True:
        url = f"{SERVER}/{COMMANDS}/json" + (f"?since={since}" if since else "")
        try:
            with urllib.request.urlopen(urllib.request.Request(url, headers=auth()), timeout=90) as stream:
                for raw in stream:
                    event = json.loads(raw.decode("utf-8") or "{}")
                    if event.get("event") != "message":
                        continue
                    since = event.get("id", since)
                    # After a reconnection: commands older than ten minutes are not run
                    if time.time() - event.get("time", 0) > 600:
                        continue
                    threading.Thread(target=handle, args=(event.get("message", ""),), daemon=True).start()
        except (urllib.error.URLError, OSError, ValueError) as error:
            log(f"ntfy: ascolto interrotto ({error}), riprovo")
            time.sleep(10)


def watch():
    failures, alerted, backup_alerted = 0, False, 0.0
    while True:
        time.sleep(EVERY)
        if paused.is_set():
            continue
        with lock:
            ok = healthy()
        if ok:
            if alerted:
                publish(report(), "RealmForge: di nuovo online", 3, ["white_check_mark"])
            failures, alerted = 0, False
        else:
            failures += 1
            # Two checks in a row: an update or a restart in progress is not an alert
            if failures == 2 and not alerted:
                publish(report() + "\n\nUsa i pulsanti o scrivi un comando.", "RealmForge: qualcosa non va", 5, ["rotating_light"])
                alerted = True
        backup = last_backup()
        if (backup is None or time.time() - backup > 36 * 3600) and time.time() - backup_alerted > 24 * 3600:
            publish("Nessun backup nelle ultime 36 ore: controlla il timer realmforge-backup.", "RealmForge: backup mancante", 4, ["warning"])
            backup_alerted = time.time()


def main():
    if not TOPIC or not COMMANDS:
        log("ntfy.env senza NTFY_TOPIC o NTFY_CMD_TOPIC: rilancia install.sh")
        sys.exit(1)
    if "--test" in sys.argv:
        publish(report() + "\n\n" + HELP, "RealmForge: notifica di prova", 3, ["test_tube"])
        return
    publish(report(), "RealmForge: monitoraggio avviato", 2, ["rocket"])
    threading.Thread(target=watch, daemon=True).start()
    listen()


if __name__ == "__main__":
    main()
