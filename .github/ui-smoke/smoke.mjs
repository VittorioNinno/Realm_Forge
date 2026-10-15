// UI smoke test: drives the real Blazor client in headless Chromium.
import { chromium } from 'playwright';

const base = 'http://localhost:5227';
const email = `ui${Date.now()}@example.com`;
// Throwaway credential generated per run: upper + lower + digit + symbol, as Identity requires
const throwawayCredential = ['Rf', crypto.randomUUID(), 'A!'].join('-');
const results = [];
const ok = (name) => { results.push(`OK ${name}`); };

const browser = await chromium.launch();
const page = await browser.newPage();
const consoleErrors = [];
page.on('console', (m) => { if (m.type() === 'error' || m.type() === 'warning') consoleErrors.push(m.text()); });
const authCalls = [];
page.on('response', (r) => { if (r.url().includes('/api/auth/')) authCalls.push(`${r.request().method()} ${new URL(r.url()).pathname} -> ${r.status()}`); });

try {
  await page.goto(`${base}/feats`);
  await page.getByText('Accedi per forgiare').first().waitFor({ timeout: 120000 });
  ok('anonymous user sees "Accedi per forgiare"');

  await page.getByText('Allerta').first().waitFor({ timeout: 30000 });
  ok('feats list loaded from the API');

  await page.goto(`${base}/account`);
  await page.getByText('Non hai un account? Registrati').click();
  await page.locator('input[type=email]').fill(email);
  await page.locator('input[type=password]').fill(throwawayCredential);
  await page.getByRole('button', { name: 'Registrati' }).click();
  await page.getByText(email).first().waitFor({ timeout: 30000 });
  ok('registration signs the user in and shows the email in the header');

  await page.goto(`${base}/feats`);
  await page.getByText('Allerta').first().waitFor({ timeout: 30000 });
  if (await page.getByText('Accedi per forgiare').count() !== 0) throw new Error('create button still hidden after login');
  ok('signed-in user sees the create button');

  await page.reload();
  await page.getByText(email).first().waitFor({ timeout: 60000 });
  ok('session survives a page reload');

  await page.getByRole('button', { name: 'Esci' }).click();
  await page.getByText('Accedi per forgiare').first().waitFor({ timeout: 30000 });
  ok('logout restores the anonymous view');
} catch (e) {
  results.push(`FAIL ${e.message.split('\n')[0]}`);
  const stored = await page.evaluate(() => localStorage.getItem('realmforge.auth')).catch(() => 'n/a');
  results.push(`DEBUG localStorage=${stored ? stored.slice(0, 60) : stored}`);
  results.push(`DEBUG auth calls: ${authCalls.join(' | ')}`);
  await page.screenshot({ path: 'ui-failure.png', fullPage: true });
} finally {
  for (const r of results) console.log(`::notice title=ui::${r}`);
  for (const c of consoleErrors.slice(0, 5)) console.log(`::warning title=ui-console::${c.slice(0, 200)}`);
  await browser.close();
  if (results.some((r) => r.startsWith('FAIL'))) process.exit(1);
}
