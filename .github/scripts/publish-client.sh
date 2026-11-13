#!/usr/bin/env bash
# Publishes the Blazor client for a hosted deployment (used by deploy-client and by the CI container job).
#   .github/scripts/publish-client.sh <api-base-url> <output-folder>
# The API address must be in wwwroot/appsettings.json BEFORE publishing: Blazor lists the settings files in its
# boot configuration at build time, and a file added to the output afterwards is never loaded (the client then
# falls back to its own origin and receives index.html instead of JSON).
set -euo pipefail

api="${1:?API base URL required}"
out="${2:?output folder required}"
wwwroot=RealmForge/RealmForge.Client/wwwroot

# A trailing slash is required by HttpClient.BaseAddress; the development settings must not reach production
jq -n --arg url "${api%/}/" '{ApiBaseUrl: $url}' > "$wwwroot/appsettings.json"
rm -f "$wwwroot/appsettings.Development.json"

dotnet publish RealmForge/RealmForge.Client/RealmForge.Client.csproj --configuration Release --output "$out"

cd "$out/wwwroot"
# The stylesheet is not fingerprinted like the framework files: its link carries a hash of its content, so that a
# release never shows the new pages with the styles of the old one kept by the browser or by Cloudflare
css_hash=$(sha256sum css/app.css | cut -c1-12)
sed -i "s|href=\"css/app.css\"|href=\"css/app.css?v=$css_hash\"|" index.html
grep -q "css/app.css?v=$css_hash" index.html || { echo "::error title=publish-client::the stylesheet link was not versioned"; exit 1; }
# index.html is always asked again, so it points to the files of the release just published
printf '/index.html\n  Cache-Control: no-cache\n/\n  Cache-Control: no-cache\n' > _headers

# Every route (/reset-password, /confirm-email, ...) is served by index.html, as in the development server
echo '/* /index.html 200' > _redirects

# The boot configuration must reference appsettings.json, otherwise the API address is ignored
if ! grep -rqs --include='*.js' --include='*.json' 'appsettings.json' _framework; then
  echo "::error title=publish-client::appsettings.json is not referenced by the Blazor boot configuration"
  exit 1
fi
if grep -rqs --include='*.js' --include='*.json' 'appsettings.Development.json' _framework; then
  echo "::error title=publish-client::the boot configuration still references appsettings.Development.json"
  exit 1
fi

echo "::notice title=publish-client::$(find . -type f | wc -l) files, API $(jq -r .ApiBaseUrl appsettings.json), settings listed in the boot configuration"
