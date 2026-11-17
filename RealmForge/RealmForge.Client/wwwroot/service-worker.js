// While developing nothing is cached: the published worker (service-worker.published.js) keeps the app offline
self.addEventListener('fetch', () => { });
