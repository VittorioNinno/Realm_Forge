#!/usr/bin/env bash
# Dumps the database and encrypts the dump with a passphrase.
#   DATABASE_URL=postgresql://... BACKUP_PASSPHRASE=... backup-db.sh <output-dir>
# Writes <output-dir>/realmforge-<UTC timestamp>.dump.gpg (pg_dump custom format, AES-256 with gpg).
# pg_dump runs from the postgres:18 image, which can dump any older server (Neon, the CI service).
# Restore:
#   gpg -d realmforge-....dump.gpg > realmforge.dump
#   pg_restore --clean --if-exists --no-owner --no-privileges -d "postgresql://..." realmforge.dump
set -euo pipefail

out="${1:?usage: backup-db.sh <output-dir>}"
: "${DATABASE_URL:?DATABASE_URL is not set}"
: "${BACKUP_PASSPHRASE:?BACKUP_PASSPHRASE is not set}"
image="postgres:18"

mkdir -p "$out"
work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT
name="realmforge-$(date -u +%Y%m%d-%H%M%S)"

# The URL goes in through the environment, not on the command line
docker run --rm --network host -e DATABASE_URL "$image" \
  sh -c 'pg_dump --format=custom --no-owner --no-privileges --dbname="$DATABASE_URL"' > "$work/$name.dump"

# An empty or broken dump must fail the run, not be stored as a backup
tables=$(docker run --rm -i "$image" pg_restore --list < "$work/$name.dump" | grep -c ' TABLE DATA ' || true)
if [ "$tables" -lt 1 ]; then
  echo "::error title=backup::The dump contains no table data"
  exit 1
fi

printf '%s' "$BACKUP_PASSPHRASE" | gpg --batch --yes --quiet --pinentry-mode loopback --passphrase-fd 0 \
  --symmetric --cipher-algo AES256 --output "$out/$name.dump.gpg" "$work/$name.dump"

size=$(du -h "$out/$name.dump.gpg" | cut -f1)
echo "::notice title=backup::$name.dump.gpg ($size, $tables tables with data)"
