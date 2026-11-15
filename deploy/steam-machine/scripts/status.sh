#!/usr/bin/env bash
# The state of RealmForge on this machine: services, containers, last backups and the public health check.
set -uo pipefail

base="$HOME/realmforge"
echo "== Servizi"
systemctl --user --no-pager --plain list-units 'realmforge*' --all | sed -n '1,12p'
echo
echo "== Container"
podman ps --all --filter name=realmforge --format '{{.Names}}\t{{.Status}}\t{{.Image}}'
echo
echo "== Ultimi backup"
ls -1t "$base"/backups/daily/*.dump.gpg 2>/dev/null | head -3 || echo "nessuno"
systemctl --user --no-pager list-timers realmforge-backup.timer podman-auto-update.timer | sed -n '1,4p'
echo
origin=$(grep -m1 '^Email__ClientBaseUrl=' "$base/config/api.env" | cut -d= -f2-)
api="${origin/https:\/\//https://api.}"
if [ -n "$origin" ] && [[ "$origin" != *"<dominio>"* ]]; then
  echo "== $api/health"
  curl -s -m 20 -o /dev/null -w '%{http_code} in %{time_total}s\n' "$api/health" || echo "non raggiungibile"
fi
echo
# The e-mails go out through api.brevo.com: the API container must resolve it
echo "== Email (DNS di api.brevo.com dal container dell'API)"
if podman exec realmforge-api getent hosts api.brevo.com > /dev/null 2>&1; then
  echo "ok"
else
  echo "NON risolto: le email non partono (controlla le righe DNS= in realmforge-api.container)"
fi
