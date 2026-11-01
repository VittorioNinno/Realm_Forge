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
chmod 600 "$base"/config/*.env "$password_file"

say "Script e unità di systemd"
cp "$here"/scripts/*.sh "$base/scripts/"
chmod 700 "$base"/scripts/*.sh
cp "$here"/quadlet/* "$quadlets/"
cp "$here"/systemd/* "$units/"

say "Avvio dei servizi anche senza sessione aperta (linger)"
loginctl enable-linger "$USER"

systemctl --user daemon-reload
systemctl --user enable --now realmforge-backup.timer
systemctl --user enable --now podman-auto-update.timer

cat <<MSG

Installazione completata. Prossimi passi (vedi README.md):
  1. completa $base/config/api.env, tunnel.env e backup.env
  2. systemctl --user start realmforge-db
  3. ~/realmforge/scripts/migrate-from-neon.sh   (solo la prima volta, per portare i dati da Neon)
  4. systemctl --user start realmforge-api realmforge-tunnel
  5. ~/realmforge/scripts/status.sh
MSG
