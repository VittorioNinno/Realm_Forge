// RealmForge offline: the files of the app are kept at install (the app opens without network), and the characters
// and their rules read last are kept too, so that a sheet opens offline; the network wins whenever it answers.
self.importScripts('./service-worker-assets.js');
self.addEventListener('install', event => event.waitUntil(onInstall()));
self.addEventListener('activate', event => event.waitUntil(onActivate()));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));
self.addEventListener('message', event => {
    if (event.data === 'rf-forget') {
        event.waitUntil(caches.delete(apiCacheName));
    }
});

const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${self.assetsManifest.version}`;
const apiCacheName = 'rf-api-v1';
const offlineAssetsInclude = [/\.dll$/, /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff2?$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/, /\.webmanifest$/];
const offlineAssetsExclude = [/^service-worker\.js$/];
const base = '/';
const baseUrl = new URL(base, self.origin);
const manifestUrlList = self.assetsManifest.assets.map(asset => new URL(asset.url, baseUrl).href);

// The answers of the API kept for offline: a character, the list, the rules of an edition
const apiKept = [/\/api\/characters\/[0-9a-f-]{36}$/i, /\/api\/characters\/context\?/i, /\/api\/characters(\?|$)/i];

async function onInstall() {
    const assetsRequests = self.assetsManifest.assets
        .filter(asset => offlineAssetsInclude.some(pattern => pattern.test(asset.url)))
        .filter(asset => !offlineAssetsExclude.some(pattern => pattern.test(asset.url)))
        // index.html is versioned again after the publish (the stylesheet link): it is kept without its hash
        .map(asset => new Request(asset.url, asset.url === 'index.html' ? { cache: 'no-cache' } : { integrity: asset.hash, cache: 'no-cache' }));
    await caches.open(cacheName).then(cache => cache.addAll(assetsRequests));
}

async function onActivate() {
    const cacheKeys = await caches.keys();
    await Promise.all(cacheKeys
        .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
        .map(key => caches.delete(key)));
}

async function onFetch(event) {
    const request = event.request;
    if (request.method !== 'GET') {
        return fetch(request);
    }
    const url = new URL(request.url);
    if (apiKept.some(pattern => pattern.test(url.pathname + url.search))) {
        const cache = await caches.open(apiCacheName);
        try {
            const response = await fetch(request);
            if (response.ok) {
                cache.put(request, response.clone());
            }
            return response;
        } catch (error) {
            const kept = await cache.match(request);
            if (kept) {
                return kept;
            }
            throw error;
        }
    }
    if (url.origin !== self.origin) {
        return fetch(request);
    }
    const shouldServeIndexHtml = request.mode === 'navigate' && !manifestUrlList.some(u => u === request.url);
    const cache = await caches.open(cacheName);
    // The stylesheet is asked with its version (css/app.css?v=…): kept without it
    const cached = await cache.match(shouldServeIndexHtml ? 'index.html' : request, { ignoreSearch: true });
    return cached || fetch(request);
}
