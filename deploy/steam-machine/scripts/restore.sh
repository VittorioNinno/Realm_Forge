#!/usr/bin/env bash
# Restores a backup into the RealmForge database: ./restore.sh ~/realmforge/backups/daily/realmforge-....dump.gpg
# The API is stopped during the restore and started again at the end. Everything written after the backup is lost.
set -euo pipefail

file="${1:?uso: restore.sh <file.dump.gpg>}"
base="$HOME/realmforge"
# shellcheck disable=SC1091
source "$base/config/backup.env"
: "${BACKUP_PASSPHRASE:?BACKUP_PASSPHRASE non è impostata in config/backup.env}"

read -r -p "Il database verrà sostituito con $(basename "$file"). Continuare? [s/N] " answer
[ "$answer" = "s" ] || [ "$answer" = "S" ] || { echo "Annullato."; exit 1; }

work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT
printf '%s' "$BACKUP_PASSPHRASE" | gpg --batch --yes --quiet --pinentry-mode loopback --passphrase-fd 0 \
  --decrypt --output "$work/restore.dump" "$file"

systemctl --user stop realmforge-api
podman exec -i realmforge-db pg_restore -U realmforge -d realmforge --clean --if-exists --no-owner --no-privileges < "$work/restore.dump"
systemctl --user start realmforge-api
echo "Ripristino completato: l'API si sta riavviando."
