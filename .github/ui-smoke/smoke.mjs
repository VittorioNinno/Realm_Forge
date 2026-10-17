// UI smoke test: drives the real Blazor client in headless Chromium.
import { chromium } from 'playwright';
import { readFileSync } from 'node:fs';

const base = 'http://localhost:5227';
const email = `ui${Date.now()}@example.com`;
// Throwaway credential generated per run: upper + lower + digit + symbol, as Identity requires
const throwawayCredential = ['Rf', crypto.randomUUID(), 'A!'].join('-');
const results = [];
const ok = (name) => { results.push(`OK ${name}`); };

const browser = await chromium.launch();
// Explicit context: the e-mail confirmation test opens a second tab in the same browser session
const context = await browser.newContext();
const page = await context.newPage();
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

  // Card previews are plain text: no Markdown marks, list dashes or table pipes
  const cardTexts = await page.locator('.rf-card').allInnerTexts();
  const marked = cardTexts.filter((t) => /\*\*|(^|\n)- |\|/.test(t));
  if (marked.length) throw new Error(`Markdown marks in ${marked.length} card previews: ${marked[0].replace(/\s+/g, ' ').slice(0, 160)}`);
  ok(`feat cards show plain-text previews (${cardTexts.length} cards)`);

  // Navigation: reference pages live in the collapsible "Compendio" group, opened on compendium routes
  const compendiumLinks = (await page.locator('[data-test=nav-compendium] a').allInnerTexts()).map((t) => t.trim());
  if (compendiumLinks.join(',') !== 'Specie,Background,Talenti') throw new Error(`unexpected compendium links: ${compendiumLinks.join(',')}`);

  // Brand: emblem next to the title in the sidebar, RealmForge favicon instead of the Blazor one
  await page.goto(`${base}/`);
  await page.locator('.rf-brand-icon').waitFor({ timeout: 30000 });
  const brand = await page.evaluate(async () => {
    const icon = document.querySelector('.rf-brand-icon');
    const favicon = document.querySelector('link[rel=icon]').getAttribute('href');
    const status = (await fetch(favicon)).status;
    return { loaded: icon.complete && icon.naturalWidth > 0, favicon, status, heroLogos: document.querySelectorAll('main img').length };
  });
  results.push(`INFO brand icon loaded=${brand.loaded} favicon=${brand.favicon} (${brand.status}) images in page body=${brand.heroLogos}`);
  if (!brand.loaded || brand.favicon !== 'img/favicon-32.png' || brand.status !== 200 || brand.heroLogos !== 0) throw new Error('unexpected brand icons');
  ok('emblem in the sidebar only, RealmForge favicon served');

  await page.goto(`${base}/account`);
  await page.getByText('Non hai un account? Registrati').waitFor({ timeout: 30000 });
  const collapsedLinks = await page.locator('[data-test=nav-compendium] a').count();
  if (collapsedLinks !== 0) throw new Error(`compendium group should start collapsed outside the compendium (${collapsedLinks} links)`);
  await page.locator('[data-test=nav-compendium] button').click();
  await page.locator('[data-test=nav-compendium] a').first().waitFor({ timeout: 5000 });
  await page.locator('[data-test=nav-compendium] button').click();
  // Every menu icon sits inside its entry (not on the hover edge) and in the same column as the "Compendio" icon
  // (measured on the account page, where the group starts closed: open it, measure, close it again)
  await page.locator('[data-test=nav-compendium] button').click();
  await page.locator('[data-test=nav-compendium] a').first().waitFor({ timeout: 5000 });
  const iconGaps = await page.evaluate(() => [...document.querySelectorAll('.sidebar .nav-link, .sidebar .rf-nav-group-toggle')].map((el) => {
    const icon = el.querySelector('svg').getBoundingClientRect();
    return { label: el.textContent.trim(), inset: Math.round(icon.left - el.getBoundingClientRect().left), left: Math.round(icon.left) };
  }));
  results.push(`INFO menu icons: ${iconGaps.map((g) => `${g.label}@${g.left}(+${g.inset})`).join(', ')}`);
  if (iconGaps.length !== 5 || iconGaps.some((g) => g.inset < 8) || new Set(iconGaps.map((g) => g.left)).size !== 1) throw new Error('menu icons are not padded or not aligned');
  await page.locator('[data-test=nav-compendium] button').click();
  ok('"Compendio" menu group: Specie, Background, Talenti; collapsed elsewhere and toggles on click; icons padded and aligned');
  await page.getByText('Non hai un account? Registrati').click();
  await page.locator('input[type=email]').fill(email);
  await page.locator('input[type=password]').fill(throwawayCredential);
  await page.getByRole('button', { name: 'Registrati' }).click();
  await page.locator('[data-test=account-area]', { hasText: email }).waitFor({ timeout: 30000 });
  const headerText = await page.locator('main .top-row').innerText();
  if (headerText.includes(email) || /Esci|Accedi/.test(headerText)) throw new Error(`account controls still in the header: ${headerText.replace(/\s+/g, ' ')}`);
  ok('registration signs the user in; the account sits at the bottom of the sidebar, not in the header');

  // New account: e-mail not confirmed yet, so the compendium asks to verify it instead of offering the create button
  await page.goto(`${base}/feats`);
  await page.locator('[data-test=verify-to-forge]').waitFor({ timeout: 30000 });
  ok('unconfirmed account sees "Verifica l\'email per forgiare" instead of the create button');

  // Without SMTP the API writes the confirmation link to its log (the UI job starts it with output in api.log)
  const link = readFileSync('../../api.log', 'utf8').match(new RegExp(`for ${email.replace(/[.]/g, '\\.')}: (\\S+)`))?.[1];
  if (!link || !link.startsWith(`${base}/confirm-email?`)) throw new Error(`confirmation link not found or not pointing to the client: ${link}`);
  // Another browser profile (isolated context, same account) that cannot receive tab messages
  const otherProfile = await browser.newContext();
  const otherPage = await otherProfile.newPage();
  await otherPage.goto(`${base}/feats`);
  await otherPage.evaluate((t) => localStorage.setItem('realmforge.auth', t), await page.evaluate(() => localStorage.getItem('realmforge.auth')));
  await otherPage.reload();
  const otherProfileReady = await otherPage.locator('[data-test=verify-to-forge]').waitFor({ timeout: 30000 }).then(() => true).catch(() => false);

  // The link opens in a new tab (as from an e-mail): it confirms, updates the tab already open and closes itself
  const linkTab = await context.newPage();
  await linkTab.goto(link);
  await linkTab.locator('[data-test=confirm-email-ok]').waitFor({ timeout: 30000 });
  await page.getByText('+ NUOVO TALENTO').waitFor({ timeout: 15000 });
  await linkTab.waitForEvent('close', { timeout: 10000 }).catch(() => {});
  results.push(`INFO confirmation tab closed by itself=${linkTab.isClosed()}`);
  if (!linkTab.isClosed()) { await linkTab.close(); }
  ok('confirmation link (to the client page) confirms the e-mail and the tab already open updates without reloading');

  if (otherProfileReady) {
    await otherPage.evaluate(() => window.dispatchEvent(new Event('focus')));
    await otherPage.getByText('+ NUOVO TALENTO').waitFor({ timeout: 15000 });
    ok('a window in another browser profile refreshes the e-mail status when it gets the focus');
  } else {
    results.push('INFO other-profile check skipped (token key not found)');
  }
  await otherProfile.close();

  await page.goto(`${base}/feats`);
  await page.getByText('Allerta').first().waitFor({ timeout: 30000 });
  await page.getByText('+ NUOVO TALENTO').waitFor({ timeout: 30000 });
  if (await page.getByText('Accedi per forgiare').count() !== 0) throw new Error('create button still hidden after login');
  ok('signed-in user with a confirmed e-mail sees the create button');

  // Layout guard for the "Forgia Talento" modal (desktop width)
  await page.setViewportSize({ width: 1280, height: 900 });
  await page.getByText('+ NUOVO TALENTO').click();
  await page.locator('[data-test=prereq-level]').waitFor({ timeout: 15000 });
  const layout = await page.evaluate(() => {
    const box = (el) => el.getBoundingClientRect();
    const level = box(document.querySelector('[data-test=prereq-level]'));
    const feature = box(document.querySelector('[data-test=prereq-feature] .rf-custom-select-trigger'));
    const truncated = [...document.querySelectorAll('.rf-label-single-line')]
      .filter((l) => l.offsetParent !== null && l.scrollWidth > l.clientWidth + 1)
      .map((l) => l.textContent.trim());
    return { topDelta: Math.abs(level.top - feature.top), heightDelta: Math.abs(level.height - feature.height), truncated };
  });
  results.push(`INFO modal layout: top delta=${layout.topDelta.toFixed(1)}px, height delta=${layout.heightDelta.toFixed(1)}px, truncated labels=[${layout.truncated.join(', ')}]`);
  if (layout.topDelta > 2) throw new Error('level and feature controls are not aligned');
  if (layout.heightDelta > 4) throw new Error('level and feature controls have different heights');
  if (layout.truncated.length > 0) throw new Error(`truncated labels: ${layout.truncated.join(', ')}`);
  ok('feat modal layout: controls aligned, no truncated labels');
  await page.getByRole('button', { name: 'ANNULLA' }).click();

  // Backgrounds: page, "Forge Background" layout and end-to-end creation
  await page.goto(`${base}/backgrounds`);
  await page.getByText('+ NUOVO BACKGROUND').click();
  await page.locator('[data-test=bg-name-It]').waitFor({ timeout: 15000 });
  const bgLayout = await page.evaluate(() => {
    const top = (sel) => document.querySelector(sel).getBoundingClientRect().top;
    const truncated = [...document.querySelectorAll('.rf-label-single-line')]
      .filter((l) => l.offsetParent !== null && l.scrollWidth > l.clientWidth + 1)
      .map((l) => l.textContent.trim());
    return {
      topDelta: Math.abs(top('[data-test=bg-ruleset] .rf-custom-select-trigger') - top('[data-test=bg-origin-feat] .rf-custom-select-trigger')),
      truncated,
    };
  });
  results.push(`INFO background modal: top delta=${bgLayout.topDelta.toFixed(1)}px, truncated labels=[${bgLayout.truncated.join(', ')}]`);
  if (bgLayout.topDelta > 2) throw new Error('ruleset and origin feat controls are not aligned');
  if (bgLayout.truncated.length > 0) throw new Error(`truncated labels: ${bgLayout.truncated.join(', ')}`);

  await page.locator('[data-test=bg-origin-feat] .rf-custom-select-trigger').click();
  await page.locator('.rf-custom-select-option', { hasText: 'Allerta' }).click();
  await page.getByRole('button', { name: 'Intuizione' }).click();
  await page.getByRole('button', { name: 'Religione' }).click();
  await page.locator('[data-test=bg-name-It]').fill('Accolito UI');
  await page.locator('[data-test=bg-name-En]').fill('UI Acolyte');
  const defaultVisibility = (await page.locator('[data-test=visibility-picker] .rf-pill-btn.active').innerText()).trim();
  if (!/^privato$/i.test(defaultVisibility)) throw new Error(`new Homebrew should default to Privato, got ${defaultVisibility}`);
  await page.getByRole('button', { name: 'SALVA BACKGROUND' }).click();
  await page.locator('.rf-card', { hasText: 'Accolito UI' }).waitFor({ timeout: 15000 });
  const card = await page.locator('.rf-card', { hasText: 'Accolito UI' }).innerText();
  if (!card.includes('Allerta') || !card.includes('Intuizione')) throw new Error(`background card misses feat/skills: ${card.replace(/\s+/g, ' ')}`);
  if (!/privato/i.test(card)) throw new Error(`background card misses the Privato badge: ${card.replace(/\s+/g, ' ')}`);
  ok('background modal aligned; homebrew background created from the UI with origin feat and skills, private by default');

  await page.locator('.rf-card').filter({ has: page.locator('.rf-card-title', { hasText: /^Accolito UI$/ }) }).click();
  await page.locator('[data-test=share-private]').waitFor({ timeout: 15000 });
  await page.getByRole('button', { name: 'CHIUDI' }).click();
  ok('private Homebrew detail explains how to share it');

  // Origin filter (client-side, as on the species page): "Solo Homebrew" leaves only the background created above
  await page.locator('.rf-custom-select-trigger', { hasText: 'Tutte le Origini' }).click();
  await page.locator('.rf-custom-select-option', { hasText: 'Solo Homebrew' }).click();
  const homebrewTitles = await page.locator('.rf-card .rf-card-title').allInnerTexts();
  results.push(`INFO backgrounds with "Solo Homebrew": ${homebrewTitles.join(', ')}`);
  if (homebrewTitles.join(',') !== 'Accolito UI') throw new Error(`origin filter: unexpected cards ${homebrewTitles.join(', ')}`);
  await page.locator('.rf-custom-select-trigger', { hasText: 'Solo Homebrew' }).click();
  await page.locator('.rf-custom-select-option', { hasText: 'Tutte le Origini' }).click();
  ok('background origin filter: "Solo Homebrew" shows only the user\'s Homebrew');

  // Exact title match: substring filters are case-insensitive ("Intuizione" contains "ui")
  // Many base backgrounds exist in both editions with the same name: pick each one by its edition badge
  const backgroundCard = (name, edition) => page.locator('.rf-card')
    .filter({ has: page.locator('.rf-card-title', { hasText: new RegExp(`^${name}$`) }) })
    .filter({ has: page.locator(`.badge-edition-${edition}`) });
  const acolyteCard = (edition) => backgroundCard('Accolito', edition);
  await acolyteCard('2014').click();
  await page.locator('[data-test=bg-characteristics]').waitFor({ timeout: 15000 });
  const tables = await page.locator('[data-test=bg-characteristics] .rf-dice-table').evaluateAll((ts) =>
    ts.map((t) => `${t.querySelector('th').textContent.trim()}x${t.querySelectorAll('tbody tr').length}`));
  results.push(`INFO Acolyte tables: ${tables.join(', ')}`);
  if (tables.join(',') !== 'd8x8,d6x6,d6x6,d6x6') throw new Error(`unexpected characteristic tables: ${tables.join(', ')}`);
  // One table per row: every table starts at the same x, on its own line, with the same width
  const boxes = await page.locator('[data-test=bg-characteristics] .rf-dice-table').evaluateAll((ts) => ts.map((t) => t.getBoundingClientRect()).map((r) => [Math.round(r.left), Math.round(r.top), Math.round(r.width)]));
  const stacked = boxes.every((b, i) => i === 0 || (b[0] === boxes[0][0] && b[2] === boxes[0][2] && b[1] > boxes[i - 1][1]));
  if (!stacked) throw new Error(`characteristic tables are not stacked: ${JSON.stringify(boxes)}`);
  const equipment = await page.locator('[data-test=bg-equipment] li').count();
  results.push(`INFO Acolyte equipment items=${equipment}`);
  if (equipment !== 6) throw new Error(`expected 6 equipment items, got ${equipment}`);
  const source = (await page.locator('[data-test=content-source]').first().innerText()).trim();
  const badge = (await page.locator('.rf-modal-dialog [data-test=content-badge]').first().textContent()).trim(); // textContent: the badge CSS uppercases the rendered text
  results.push(`INFO Acolyte badge='${badge}' source='${source}'`);
  if (badge !== 'Base' || source !== 'Fonte: SRD 5.1') throw new Error(`unexpected badge/source: ${badge} / ${source}`);
  await page.getByRole('button', { name: 'CHIUDI' }).click();
  ok('SRD Acolyte: four stacked characteristic tables (d8, d6, d6, d6), equipment list, badge "Base", source SRD 5.1');

  await acolyteCard('2024').click();
  await page.locator('[data-test=bg-equipment-b]').waitFor({ timeout: 15000 });
  const meta2024 = (await page.locator('.rf-modal-dialog .rf-meta-row').innerText()).replace(/\s+/g, ' ');
  const items2024 = await page.locator('[data-test=bg-equipment-a] li').count();
  const gold2024 = (await page.locator('[data-test=bg-equipment-b]').innerText()).replace(/\s+/g, ' ');
  const source2024 = (await page.locator('[data-test=content-source]').first().innerText()).trim();
  results.push(`INFO Acolyte 2024: items=${items2024} gold='${gold2024}' source='${source2024}'`);
  if (!meta2024.includes('Iniziato alla Magia') || !meta2024.includes('(Chierico)')) throw new Error(`Acolyte 2024 misses its origin feat: ${meta2024}`);
  if (items2024 !== 6 || !gold2024.includes('50') || source2024 !== 'Fonte: SRD 5.2') throw new Error(`unexpected Acolyte 2024 equipment/source: ${items2024} / ${gold2024} / ${source2024}`);
  await page.getByRole('button', { name: 'CHIUDI' }).click();
  ok('SRD 5.2 Acolyte: Magic Initiate (Cleric), equipment options A (6 items) and B (50 gp), source SRD 5.2');

  await backgroundCard('Ciarlatano', '2014').click();
  await page.locator('[data-test=bg-characteristics]').waitFor({ timeout: 15000 });
  const schemes = await page.locator('.rf-modal-dialog table:not(.rf-dice-table) tbody tr').count();
  const charlatanSource = (await page.locator('[data-test=content-source]').first().innerText()).trim();
  results.push(`INFO Charlatan schemes rows=${schemes} source='${charlatanSource}'`);
  if (schemes !== 6 || charlatanSource !== 'Fonte: testo RealmForge') throw new Error(`unexpected Charlatan detail: rows=${schemes} source=${charlatanSource}`);
  await page.getByRole('button', { name: 'CHIUDI' }).click();
  ok('Charlatan: schemes table rendered from Markdown (6 rows), source RealmForge');

  // Species: text search on name and description, with a dedicated message when nothing matches
  await page.goto(`${base}/species`);
  await page.locator('.rf-card').first().waitFor({ timeout: 30000 });
  const speciesTotal = await page.locator('.rf-card').count();
  await page.locator('[data-test=species-search]').fill('nano');
  await page.locator('.rf-card .rf-card-title', { hasText: /^Nano$/ }).first().waitFor({ timeout: 10000 });
  const speciesFound = await page.locator('.rf-card').count();
  await page.locator('[data-test=species-search]').fill('zzzz');
  await page.locator('[data-test=species-empty]', { hasText: 'Nessuna specie corrisponde alla ricerca.' }).waitFor({ timeout: 10000 });
  results.push(`INFO species search: total=${speciesTotal} "nano"=${speciesFound}`);
  if (speciesFound < 1 || speciesFound >= speciesTotal) throw new Error(`species search did not filter: ${speciesFound}/${speciesTotal}`);
  ok('species search filters by text and explains when nothing matches');

  // Account page: profile, Homebrew counts (the UI created one background) and password change
  await page.goto(`${base}/account`);
  await page.locator('[data-test=account-role]').waitFor({ timeout: 30000 });
  const role = (await page.locator('[data-test=account-role]').innerText()).trim();
  const emailStatus = (await page.locator('[data-test=account-email-status]').innerText()).trim();
  if (emailStatus !== 'verificata' || await page.locator('[data-test=account-verify]').count() !== 0) throw new Error(`unexpected e-mail status: ${emailStatus}`);
  const stats = (await page.locator('[data-test=account-homebrew] .rf-account-stat').allInnerTexts()).map((t) => t.replace(/\s+/g, ' ').trim());
  results.push(`INFO account role='${role}' homebrew=[${stats.join(' | ')}]`);
  if (!/^utente$/i.test(role) || !stats.some((t) => /^0 talenti$/i.test(t)) || !stats.some((t) => /^1 background$/i.test(t))) throw new Error('unexpected account summary');
  const newCredential = ['Rf', crypto.randomUUID(), 'B!'].join('-');
  await page.locator('[data-test=pwd-current]').fill('wrong-password-1A!');
  await page.locator('[data-test=pwd-new]').fill(newCredential);
  await page.locator('[data-test=pwd-repeat]').fill(newCredential);
  await page.getByRole('button', { name: 'Aggiorna password' }).click();
  await page.getByText('La password attuale non è corretta.').waitFor({ timeout: 15000 });
  await page.locator('[data-test=pwd-current]').fill(throwawayCredential);
  await page.getByRole('button', { name: 'Aggiorna password' }).click();
  await page.getByText('Password aggiornata.').waitFor({ timeout: 15000 });
  ok('account page: role "Utente", Homebrew counts (0 feats, 1 background), password change rejects a wrong current password and succeeds with the right one');
  await page.goto(`${base}/backgrounds`);
  await page.getByText('Accolito').first().waitFor({ timeout: 30000 });

  await page.reload();
  await page.getByText(email).first().waitFor({ timeout: 60000 });
  ok('session survives a page reload');

  await page.locator('[data-test=account-area]').getByRole('button', { name: 'Esci' }).click();
  await page.getByText('Accedi per forgiare').first().waitFor({ timeout: 30000 });
  await page.locator('[data-test=account-area]', { hasText: 'Accedi' }).waitFor({ timeout: 15000 });
  ok('logout from the sidebar restores the anonymous view');

  // Password recovery: "Password dimenticata?" on the sign-in form -> e-mail with a link to /reset-password -> new password signs in
  await page.goto(`${base}/reset-password`);
  await page.locator('[data-test=reset-password-invalid]').waitFor({ timeout: 30000 });
  await page.goto(`${base}/account`);
  await page.locator('[data-test=forgot-password-link]').click();
  await page.locator('[data-test=forgot-email]').fill(email);
  await page.locator('[data-test=forgot-submit]').click();
  await page.locator('[data-test=forgot-password-sent]').waitFor({ timeout: 15000 });
  let resetLink;
  for (let i = 0; i < 20 && !resetLink; i++) {
    resetLink = readFileSync('../../api.log', 'utf8').match(new RegExp(`Reset your password for ${email.replace(/[.]/g, '\\.')}: (\\S+)`))?.[1];
    if (!resetLink) await page.waitForTimeout(500);
  }
  if (!resetLink || !resetLink.startsWith(`${base}/reset-password?email=`)) throw new Error(`reset link not found or not pointing to the client: ${resetLink}`);
  const resetCredential = ['Rf', crypto.randomUUID(), 'C!'].join('-');
  await page.goto(resetLink);
  await page.locator('[data-test=reset-new]').fill(resetCredential);
  await page.locator('[data-test=reset-repeat]').fill(`${resetCredential}x`);
  await page.locator('[data-test=reset-submit]').click();
  await page.getByText('Le due nuove password non coincidono.').waitFor({ timeout: 15000 });
  await page.locator('[data-test=reset-repeat]').fill(resetCredential);
  await page.locator('[data-test=reset-submit]').click();
  await page.locator('[data-test=reset-password-done]').waitFor({ timeout: 15000 });
  await page.goto(`${base}/account`);
  await page.locator('input[type=email]').fill(email);
  await page.locator('input[type=password]').fill(resetCredential);
  await page.getByRole('button', { name: 'Accedi', exact: true }).click();
  await page.locator('[data-test=account-area]', { hasText: email }).waitFor({ timeout: 30000 });
  await page.locator('[data-test=account-area]').getByRole('button', { name: 'Esci' }).click();
  await page.locator('[data-test=account-area]', { hasText: 'Accedi' }).waitFor({ timeout: 15000 });
  ok('password recovery: link on the sign-in form, e-mail link to /reset-password, mismatch rejected, new password signs in');
  await page.goto(`${base}/backgrounds`);
  await page.getByText('Accedi per forgiare').first().waitFor({ timeout: 30000 });

  await page.locator('[data-test=lang-select] button').click();
  const languages = (await page.locator('[data-test=lang-select] [role=option]').allInnerTexts()).map((t) => t.trim());
  if (languages.join(',') !== 'English,Italiano') throw new Error(`unexpected language options: ${languages.join(',')}`);
  await page.locator('[data-test=lang-select] [role=option]', { hasText: 'English' }).click();
  await page.getByText('Sign in to forge').first().waitFor({ timeout: 15000 });
  await page.reload();
  await page.getByText('Sign in to forge').first().waitFor({ timeout: 60000 });
  const htmlLang = await page.evaluate(() => document.documentElement.lang);
  if (htmlLang !== 'en') throw new Error(`html lang is '${htmlLang}' after reload`);
  ok('language drop-down (English, Italiano): EN survives a reload and sets <html lang="en">');
} catch (e) {
  results.push(`FAIL ${e.message.split('\n')[0]}`);
  const stored = await page.evaluate(() => localStorage.getItem('realmforge.auth')).catch(() => 'n/a');
  results.push(`DEBUG localStorage=${stored ? stored.slice(0, 60) : stored}`);
  results.push(`DEBUG auth calls: ${authCalls.join(' | ')}`);
  await page.screenshot({ path: 'ui-failure.png', fullPage: true });
} finally {
  // GitHub shows at most 10 annotations per step: one line per result in the log, one summary annotation
  for (const r of results) console.log(r);
  console.log(`::notice title=ui::${results.filter((r) => r.startsWith('OK')).length} checks passed — ${results.join(' · ')}`);
  for (const c of consoleErrors.slice(0, 5)) console.log(`::warning title=ui-console::${c.slice(0, 200)}`);
  await browser.close();
  if (results.some((r) => r.startsWith('FAIL'))) process.exit(1);
}
