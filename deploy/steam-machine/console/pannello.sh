#!/usr/bin/env bash
# Pannello di controllo di RealmForge sulla Steam Machine: una finestra con l'elenco delle azioni (kdialog, KDE).
# Le azioni che chiedono qualcosa o mostrano log in diretta si aprono in Konsole.
set -uo pipefail

base="$HOME/realmforge"
scripts="$base/scripts"
title="RealmForge"
services=(realmforge-db realmforge-api realmforge-tunnel)

in_terminal() {
  # Esegue un comando in una nuova finestra di Konsole che resta aperta fino a Invio
  konsole --hold -e bash -lc "$1; echo; read -r -p 'Premi Invio per chiudere…' _" >/dev/null 2>&1 &
}

state() {
  local s
  s=$(systemctl --user is-active "$1" 2>/dev/null)
  case "$s" in
    active) echo "🟢 attivo" ;;
    activating) echo "🟡 in avvio" ;;
    failed) echo "🔴 in errore" ;;
    *) echo "⚪ fermo" ;;
  esac
}

summary() {
  local health last
  health=$(curl -s -m 10 -o /dev/null -w '%{http_code}' https://api.myrealmforge.com/health 2>/dev/null)
  [ "$health" = "200" ] && health="🟢 raggiungibile (200)" || health="🔴 non raggiungibile ($health)"
  last=$(ls -1t "$base"/backups/daily/*.dump.gpg 2>/dev/null | head -1)
  [ -n "$last" ] && last="$(basename "$last") ($(date -r "$last" '+%d/%m %H:%M'))" || last="nessuno"
  printf 'Database:  %s\nAPI:       %s\nTunnel:    %s\n\nhttps://api.myrealmforge.com  %s\nUltimo backup: %s' \
    "$(state realmforge-db)" "$(state realmforge-api)" "$(state realmforge-tunnel)" "$health" "$last"
}

while true; do
  choice=$(kdialog --title "$title" --geometry 520x560 --menu "$(summary)" \
    status   "📋  Stato completo" \
    start    "▶️  Avvia tutto" \
    stop     "⏹️  Ferma tutto" \
    restart  "🔄  Riavvia l'API" \
    logapi   "📜  Log dell'API (in diretta)" \
    logtun   "📜  Log del tunnel (in diretta)" \
    backup   "💾  Backup adesso" \
    backups  "🗂️  Apri la cartella dei backup" \
    restore  "♻️  Ripristina un backup…" \
    update   "⬆️  Cerca aggiornamenti dell'API adesso" \
    config   "⚙️  Apri la cartella della configurazione" \
    neon     "🚚  Ricopia i dati da Neon (trasloco)" \
    site     "🌐  Apri il sito" \
    2>/dev/null) || exit 0

  case "$choice" in
    status)
      out=$(mktemp)
      "$scripts/status.sh" > "$out" 2>&1
      kdialog --title "$title — stato" --geometry 900x600 --textbox "$out" 2>/dev/null
      rm -f "$out" ;;
    start)
      systemctl --user start "${services[@]}" \
        && kdialog --title "$title" --passivepopup "Avvio in corso: l'API è pronta in circa un minuto." 6 \
        || kdialog --title "$title" --error "Avvio non riuscito: guarda il log dell'API." ;;
    stop)
      kdialog --title "$title" --warningyesno "Fermare database, API e tunnel? Il sito non funzionerà finché non li riavvii." \
        && systemctl --user stop realmforge-tunnel realmforge-api realmforge-db \
        && kdialog --title "$title" --passivepopup "RealmForge fermato." 5 ;;
    restart)
      systemctl --user restart realmforge-api \
        && kdialog --title "$title" --passivepopup "API riavviata: pronta in circa un minuto." 6 ;;
    logapi) in_terminal "journalctl --user -u realmforge-api -n 200 -f" ;;
    logtun) in_terminal "journalctl --user -u realmforge-tunnel -n 100 -f" ;;
    backup) in_terminal "$scripts/backup.sh" ;;
    backups) xdg-open "$base/backups" >/dev/null 2>&1 & ;;
    restore)
      file=$(kdialog --title "Scegli il backup da ripristinare" --getopenfilename "$base/backups/daily" "*.dump.gpg" 2>/dev/null) || continue
      [ -n "$file" ] && in_terminal "'$scripts/restore.sh' '$file'" ;;
    update) in_terminal "podman auto-update && echo && podman ps --format '{{.Names}}  {{.Image}}  {{.Status}}'" ;;
    config) xdg-open "$base/config" >/dev/null 2>&1 & ;;
    neon)
      kdialog --title "$title" --warningyesno "Il database della Steam Machine verrà sostituito con i dati di Neon. Serve solo durante il trasloco. Continuare?" \
        && in_terminal "'$scripts/migrate-from-neon.sh' && systemctl --user start realmforge-api && echo 'API riavviata.'" ;;
    site) xdg-open "https://myrealmforge.com" >/dev/null 2>&1 & ;;
  esac
done
