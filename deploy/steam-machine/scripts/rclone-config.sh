#!/usr/bin/env bash
# Interactive set-up of the off-site copy (Google Drive, OneDrive, Dropbox, an S3 bucket...) with rclone in a
# container: the configuration is saved in ~/realmforge/config/rclone. Then set RCLONE_REMOTE in backup.env
# (e.g. gdrive:RealmForge-backup) and try ~/realmforge/scripts/backup.sh.
set -euo pipefail
mkdir -p "$HOME/realmforge/config/rclone"
podman run --rm -it -v "$HOME/realmforge/config/rclone:/config/rclone" docker.io/rclone/rclone:latest config
