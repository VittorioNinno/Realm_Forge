#!/usr/bin/env bash
# Installs RealmForge (database, API, Cloudflare Tunnel, nightly backups) as rootless Podman containers of the
# current user, started by systemd at boot (Quadlet). Run it from this folder: ./scripts/install.sh
# It can be run again after an update of these files: the configuration in ~/realmforge/config is never overwritten.
set -euo pipefail

here="$(cd "$(dirname "$0")/.." && pwd)"
base="$HOME/realmforge"
quadlets="$HOME/.config/containers/systemd"
units="$HOME/.config/systemd/user"

say() { printf '\n\033[1;33m==> %s\033[0m\n' "$1"; }

say "Controllo di Podman"
if ! command -v podman >/dev/null; then
  echo "Podman non è installato: vedi la sezione 'Prerequisiti' della guida (README.md)." >&2
  exit 1
fi
version="$(podman version --format '{{.Client.Version}}')"
major="${version%%.*}"; rest="${version#*.}"; minor="${rest%%.*}"
if [ "$major" -lt 4 ] || { [ "$major" -eq 4 ] && [ "$minor" -lt 4 ]; }; then
  echo "Serve Podman 4.4 o più recente (Quadlet), trovato $version." >&2
  exit 1
fi
echo "Podman $version"
command -v gpg >/dev/null || { echo "Manca gpg (serve per cifrare i backup)." >&2; exit 1; }

say "Cartelle in $base"
mkdir -p "$base/config" "$base/backups/daily" "$base/backups/weekly" "$base/scripts" "$base/config/rclone" "$quadlets" "$units"
chmod 700 "$base" "$base/config" "$base/backups"

say "Configurazione (i file già presenti restano com'erano)"
password_file="$base/config/.db-password"
if [ ! -s "$password_file" ]; then
  head -c 32 /dev/urandom | base64 | tr -dc 'A-Za-z0-9' | head -c 32 > "$password_file"
fi
password="$(cat "$password_file")"
for name in db api tunnel backup; do
  target="$base/config/$name.env"
  if [ ! -e "$target" ]; then
    sed "s/__DB_PASSWORD__/$password/g" "$here/config/$name.env.example" > "$target"
    echo "creato $target"
  fi
done
ntfy_file="$base/config/ntfy.env"
if [ ! -e "$ntfy_file" ]; then
  # Random topics and PIN: whoever knows a topic can read it or write to it
  random() { head -c 64 /dev/urandom | base64 | tr -dc 'a-zA-Z0-9' | tr 'A-Z' 'a-z' | head -c "$1"; }
  pin="$(head -c 64 /dev/urandom | od -An -tu1 | tr -dc '0-9' | head -c 6)"
  sed -e "s/__NTFY_TOPIC__/realmforge-$(random 20)/" -e "s/__NTFY_CMD_TOPIC__/realmforge-cmd-$(random 20)/" -e "s/__NTFY_PIN__/$pin/" \
    "$here/config/ntfy.env.example" > "$ntfy_file"
  echo "creato $ntfy_file"
fi
chmod 600 "$base"/config/*.env "$password_file"

say "Script e unità di systemd"
cp "$here"/scripts/*.sh "$here"/scripts/*.py "$base/scripts/"
chmod 700 "$base"/scripts/*.sh "$base"/scripts/*.py
cp "$here"/console/pannello.sh "$base/scripts/"
chmod 700 "$base/scripts/pannello.sh"
cp "$here"/quadlet/* "$quadlets/"

say "Pannello di controllo (menu delle applicazioni e Desktop)"
mkdir -p "$HOME/.local/share/applications"
sed "s|/home/deck|$HOME|g" "$here/console/realmforge.desktop" > "$HOME/.local/share/applications/realmforge.desktop"
if [ -d "$HOME/Desktop" ]; then
  cp "$HOME/.local/share/applications/realmforge.desktop" "$HOME/Desktop/RealmForge.desktop"
  chmod +x "$HOME/Desktop/RealmForge.desktop"
fi
cp "$here"/systemd/* "$units/"

say "Avvio dei servizi anche senza sessione aperta (linger)"
loginctl enable-linger "$USER"

say "Aggiornamenti automatici ogni 15 minuti (nuova release -> nuova immagine -> riavvio dell'API)"
mkdir -p "$units/podman-auto-update.timer.d"
printf '[Timer]\nOnCalendar=\nOnCalendar=*:0/15\nRandomizedDelaySec=60\n' > "$units/podman-auto-update.timer.d/realmforge.conf"

systemctl --user daemon-reload
systemctl --user enable --now realmforge-backup.timer
systemctl --user enable --now podman-auto-update.timer
systemctl --user restart podman-auto-update.timer

say "Notifiche e comandi sul telefono (ntfy)"
if command -v python3 >/dev/null; then
  systemctl --user enable realmforge-ntfy.service
  systemctl --user restart realmforge-ntfy.service
  . "$ntfy_file"
  echo "Nell'app ntfy iscriviti a:  $NTFY_TOPIC   (avvisi e risposte)"
  echo "e aggiungi anche:          $NTFY_CMD_TOPIC   (per scrivere i comandi)"
  echo "PIN dei comandi:           $NTFY_PIN   (es. \"stato $NTFY_PIN\")"
else
  echo "python3 non trovato: le notifiche ntfy restano spente."
fi

cat <<MSG

Installazione completata. Prossimi passi (vedi README.md):
  1. completa $base/config/api.env, tunnel.env e backup.env
  2. systemctl --user start realmforge-db
  3. ~/realmforge/scripts/migrate-from-neon.sh   (solo la prima volta, per portare i dati da Neon)
  4. systemctl --user start realmforge-api realmforge-tunnel
  5. ~/realmforge/scripts/status.sh
MSG
