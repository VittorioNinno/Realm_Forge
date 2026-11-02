#!/usr/bin/env bash
# Nightly backup of the RealmForge database (systemd timer realmforge-backup.timer, or by hand):
# an encrypted dump in ~/realmforge/backups/daily (a copy in weekly/ on Sundays), the old ones rotated,
# and the folder mirrored off-site with rclone when RCLONE_REMOTE is set.
# Restore: ~/realmforge/scripts/restore.sh <file.dump.gpg>
set -euo pipefail

base="$HOME/realmforge"
# shellcheck disable=SC1091
source "$base/config/backup.env"
: "${BACKUP_PASSPHRASE:?BACKUP_PASSPHRASE non è impostata in config/backup.env}"
keep_daily="${KEEP_DAILY:-14}"
keep_weekly="${KEEP_WEEKLY:-8}"
out="$base/backups"
mkdir -p "$out/daily" "$out/weekly"

work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT
name="realmforge-$(date -u +%Y%m%d-%H%M%S)"

podman exec realmforge-db pg_dump -U realmforge -d realmforge --format=custom --no-owner --no-privileges > "$work/$name.dump"

# An empty or broken dump is an error, never a backup
tables=$(podman exec -i realmforge-db pg_restore --list < "$work/$name.dump" | grep -c ' TABLE DATA ' || true)
if [ "$tables" -lt 1 ]; then
  echo "Il dump non contiene dati: backup NON salvato." >&2
  exit 1
fi

printf '%s' "$BACKUP_PASSPHRASE" | gpg --batch --yes --quiet --pinentry-mode loopback --passphrase-fd 0 \
  --symmetric --cipher-algo AES256 --output "$out/daily/$name.dump.gpg" "$work/$name.dump"
if [ "$(date +%u)" = "7" ]; then
  cp "$out/daily/$name.dump.gpg" "$out/weekly/"
fi

# Rotation: the newest KEEP_DAILY nightly and KEEP_WEEKLY weekly backups
ls -1t "$out"/daily/*.dump.gpg 2>/dev/null | tail -n +"$((keep_daily + 1))" | xargs -r rm --
ls -1t "$out"/weekly/*.dump.gpg 2>/dev/null | tail -n +"$((keep_weekly + 1))" | xargs -r rm --

echo "Backup $name.dump.gpg ($(du -h "$out/daily/$name.dump.gpg" | cut -f1), $tables tabelle con dati)"

# Off-site copy: the backups folder mirrored to the rclone remote (already encrypted)
if [ -n "${RCLONE_REMOTE:-}" ]; then
  podman run --rm \
    -v "$base/config/rclone:/config/rclone" \
    -v "$out:/data:ro" \
    docker.io/rclone/rclone:latest sync /data "$RCLONE_REMOTE" --quiet
  echo "Copia fuori sede aggiornata: $RCLONE_REMOTE"
fi

if [ -n "${HEALTHCHECK_URL:-}" ]; then
  curl -fsS -m 10 --retry 3 "$HEALTHCHECK_URL" >/dev/null || echo "Ping di controllo non riuscito (il backup è comunque salvato)." >&2
fi
