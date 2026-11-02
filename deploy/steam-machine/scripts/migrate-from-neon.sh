#!/usr/bin/env bash
# One-off move of the data from Neon to the database of the Steam Machine. Run it with the API stopped and the
# database started (systemctl --user start realmforge-db). Neon is only read: it stays as it is.
# The connection string is asked for and never written to disk or shown.
set -euo pipefail

read -r -s -p "Stringa di connessione di Neon (postgresql://...): " NEON_URL
echo
export NEON_URL

work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT

echo "Esporto da Neon..."
podman run --rm -e NEON_URL docker.io/library/postgres:18 \
  sh -c 'pg_dump --format=custom --no-owner --no-privileges --dbname="$NEON_URL"' > "$work/neon.dump"
tables=$(podman exec -i realmforge-db pg_restore --list < "$work/neon.dump" | grep -c ' TABLE DATA ' || true)
if [ "$tables" -lt 1 ]; then
  echo "L'esportazione è vuota: niente è stato importato." >&2
  exit 1
fi

systemctl --user stop realmforge-api 2>/dev/null || true
echo "Importo nel database locale ($tables tabelle con dati)..."
podman exec -i realmforge-db pg_restore -U realmforge -d realmforge --clean --if-exists --no-owner --no-privileges < "$work/neon.dump"

users=$(podman exec realmforge-db psql -U realmforge -d realmforge -At -c 'select count(*) from "AspNetUsers"')
characters=$(podman exec realmforge-db psql -U realmforge -d realmforge -At -c 'select count(*) from "Characters"')
echo "Fatto: $users account e $characters personaggi nel database locale."
echo "Ora: systemctl --user start realmforge-api realmforge-tunnel"
