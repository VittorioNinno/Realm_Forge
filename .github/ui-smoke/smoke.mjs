// UI smoke test: drives the real Blazor client in headless Chromium.
import { chromium } from 'playwright';
import { readFileSync, mkdirSync, copyFileSync } from 'node:fs';

// Screenshots of the screens changed most often, kept as a CI artifact for a visual review
mkdirSync('shots', { recursive: true });
const shot = async (page, name, selector) => {
  try {
    const target = selector ? page.locator(selector).first() : page;
    await target.screenshot({ path: `shots/${name}.png`, ...(selector ? {} : { fullPage: false }) });
  } catch { /* a missing screenshot never fails the test */ }
};

const base = 'http://localhost:5227';
const email = `ui${Date.now()}@example.com`;
// Throwaway credential generated per run: upper + lower + digit + symbol, as Identity requires
const throwawayCredential = ['Rf', crypto.randomUUID(), 'A!'].join('-');
const results = [];
// Elements wider than the window (phone audits): wide tables may scroll inside their own box
const overflowOf = async (target, label) => target.evaluate((label) => {
  const width = document.documentElement.clientWidth;
  const scrolls = (el) => { for (let p = el.parentElement; p; p = p.parentElement) { const o = getComputedStyle(p).overflowX; if (o === 'auto' || o === 'scroll' || o === 'hidden') return true; } return false; };
  const out = [];
  for (const el of document.querySelectorAll('body *')) {
    const r = el.getBoundingClientRect();
    if (r.width === 0 || r.height === 0 || getComputedStyle(el).position === 'fixed') continue;
    if ((r.right > width + 1 || r.left < -1) && !scrolls(el)) out.push(`${el.tagName.toLowerCase()}.${[...el.classList].slice(0, 2).join('.')}(${Math.round(r.left)}..${Math.round(r.right)})`);
  }
  const page = document.documentElement.scrollWidth > width + 1 ? `page ${document.documentElement.scrollWidth}px` : '';
  return page || out.length ? [label, page, ...[...new Set(out)].slice(0, 6)].filter(Boolean).join(' ') : null;
}, label);
const ok = (name) => { results.push(`OK ${name}`); };
const characterAudits = [];

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

  await page.locator('[data-test=feat-group]').first().waitFor({ timeout: 30000 });
  await shot(page, 'feats-groups', 'main');
  await page.locator('[data-test=feat-expand-all]').click();
  await page.getByText('Allerta').first().waitFor({ timeout: 30000 });
  ok('feats list loaded from the API, grouped by category');

  // Blazor boot UI: the error bar stays hidden when nothing failed, the loading ring is a styled ring (not a black disc)
  const bootUi = await page.evaluate(() => {
    const bar = getComputedStyle(document.getElementById('blazor-error-ui')).display;
    const svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
    svg.setAttribute('class', 'loading-progress');
    const circle = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
    svg.appendChild(circle);
    document.body.appendChild(svg);
    const fill = getComputedStyle(circle).fill;
    svg.remove();
    return { bar, fill };
  });
  if (bootUi.bar !== 'none') throw new Error(`blazor-error-ui visible without an error (display: ${bootUi.bar})`);
  if (bootUi.fill !== 'none') throw new Error(`loading ring filled (fill: ${bootUi.fill})`);
  ok('boot UI: error bar hidden, loading ring unfilled');

  // Card previews are plain text: no Markdown marks, list dashes or table pipes
  const cardTexts = await page.locator('.rf-card').allInnerTexts();
  const marked = cardTexts.filter((t) => /\*\*|(^|\n)- |\|/.test(t));
  if (marked.length) throw new Error(`Markdown marks in ${marked.length} card previews: ${marked[0].replace(/\s+/g, ' ').slice(0, 160)}`);
  ok(`feat cards show plain-text previews (${cardTexts.length} cards)`);

  // Navigation: reference pages live in the collapsible "Compendio" group, opened on compendium routes
  const compendiumLinks = (await page.locator('[data-test=nav-compendium] a').allInnerTexts()).map((t) => t.trim());
  if (compendiumLinks.join(',') !== 'Specie,Background,Talenti,Incantesimi,Classi,Equipaggiamento,Oggetti magici,Mostri,Moduli di regole') throw new Error(`unexpected compendium links: ${compendiumLinks.join(',')}`);
  // The rules glossary is a menu entry of its own, next to the compendium group
  const rulesLink = (await page.locator('[data-test=nav-rules] a').innerText()).trim();
  if (rulesLink !== 'Glossario') throw new Error(`unexpected glossary menu entry: ${rulesLink}`);

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

  // Dashboard: one card per compendium module with Base counts per edition and the visible Homebrew
  // Dashboard: welcome, one link per section (glossary first, no figures), how it works and the house rules
  await page.locator('[data-test=home-intro]').waitFor({ timeout: 30000 });
  const home = await page.evaluate(() => ({
    links: [...document.querySelectorAll('[data-test=dashboard-modules] a')].map((a) => a.getAttribute('href')),
    figures: document.querySelectorAll('[data-test=dashboard-modules] .rf-account-stat').length,
    how: document.querySelectorAll('[data-test=home-how] dt').length,
    rules: document.querySelectorAll('[data-test=home-rules] dt').length,
  }));
  results.push(`INFO dashboard: ${JSON.stringify(home)}`);
  if (home.links.join(',') !== 'rules,species,backgrounds,feats,spells,classes,equipment,magic-items,monsters' || home.figures !== 0 || home.how !== 4 || home.rules !== 6) throw new Error('unexpected dashboard');
  if (await page.locator('main a[href=account]', { hasText: 'Accedi per forgiare' }).count() !== 1) throw new Error('dashboard misses the sign-in call to action');
  ok('dashboard: welcome, links to the 8 sections without figures, how it works (4 points), house rules (6) and the sign-in call to action');

  // Spells: 752 base spells (361 of 2014, 391 of 2024) grouped by level, edition and client-side filters, detail with the stat block
  await page.goto(`${base}/spells`);
  await page.locator('[data-test=spell-level-group]').first().waitFor({ timeout: 60000 });
  // Levels start closed and open with a filter or a search; expand/collapse all
  const closedSpells = await page.locator('[data-test=spell-card]').count();
  await page.locator('[data-test=spell-expand-all]').click();
  const openSpells = await page.locator('[data-test=spell-card]').count();
  await page.locator('[data-test=spell-collapse-all]').click();
  if (closedSpells !== 0 || openSpells !== 752) throw new Error(`spell levels do not open and close: closed=${closedSpells} open=${openSpells}`);
  ok('spells: 10 levels closed by default, expand all shows the 752 cards, collapse all closes them');
  const spellCount = async () => (await page.locator('[data-test=spell-count]').innerText()).trim();
  const waitCount = async (expected) => {
    for (let i = 0; i < 100 && (await spellCount()) !== expected; i++) await page.waitForTimeout(100);
    return spellCount();
  };
  const allSpells = await waitCount('752 incantesimi');
  const pickOption = async (filter, label) => {
    await page.locator(`[data-test=${filter}] .rf-custom-select-trigger`).click();
    await page.locator(`[data-test=${filter}] .rf-custom-select-option`, { hasText: label }).first().click();
  };
  // Counts of one edition: all, wizard 3rd level (and with concentration), rituals
  const editionCounts = async () => {
    const all = await spellCount();
    const groups = await page.locator('[data-test=spell-level-group]').count();
    await pickOption('spell-class', 'Mago');
    await pickOption('spell-level', '3° livello');
    const wizard3 = await spellCount();
    await page.locator('[data-test=spell-filter-concentration]').click();
    const wizard3Concentration = await spellCount();
    await page.locator('[data-test=spell-filter-concentration]').click();
    await pickOption('spell-class', 'Tutte le classi');
    await pickOption('spell-level', 'Tutti i livelli');
    await page.locator('[data-test=spell-filter-ritual]').click();
    const rituals = await spellCount();
    await page.locator('[data-test=spell-filter-ritual]').click();
    return { all, groups, wizard3, wizard3Concentration, rituals };
  };
  // Opens Fireball of the selected edition and reads its stat block
  const fireballDetail = async () => {
    await page.locator('[data-test=spell-search]').fill('palla di fuoco');
    await page.locator('[data-test=spell-card]', { hasText: 'Palla di Fuoco Ritardata' }).waitFor({ timeout: 5000 });
    await page.locator('[data-test=spell-card]').filter({ has: page.locator('.rf-card-title', { hasText: /^Palla di Fuoco$/ }) }).click();
    await page.locator('[data-test=spell-detail]').waitFor({ timeout: 15000 });
    const detail = await page.evaluate(() => ({
      subtitle: document.querySelector('[data-test=spell-subtitle]').textContent.trim(),
      stats: [...document.querySelectorAll('[data-test=spell-stats] dd')].map((d) => d.textContent.trim()),
      higher: document.querySelector('[data-test=spell-higher-levels] strong')?.textContent.trim() ?? '',
      classes: document.querySelector('[data-test=spell-classes]').textContent.replace(/\s+/g, ' ').trim(),
      source: (document.querySelector('[data-test=spell-detail]').textContent.match(/SRD 5\.\d/) ?? [''])[0],
    }));
    await page.locator('[data-test=spell-detail] button', { hasText: 'CHIUDI' }).click();
    await page.locator('[data-test=spell-search]').fill('');
    return detail;
  };

  await pickOption('spell-ruleset', '5e (2014)');
  await waitCount('361 incantesimi');
  const counts2014 = await editionCounts();
  const fireball = await fireballDetail();
  results.push(`INFO spells: all editions=${allSpells} | 2014 ${JSON.stringify(counts2014)} | fireball ${JSON.stringify(fireball)}`);
  if (allSpells !== '752 incantesimi' || JSON.stringify(counts2014) !== JSON.stringify({ all: '361 incantesimi', groups: 10, wizard3: '29 incantesimi', wizard3Concentration: '13 incantesimi', rituals: '31 incantesimi' })) throw new Error('unexpected 2014 spell counts');
  if (fireball.subtitle !== 'Invocazione di 3° livello' || fireball.stats.join(' | ') !== '1 azione | 45 metri | V, S, M (una minuscola pallina di guano di pipistrello e zolfo) | Istantanea'
    || fireball.higher.toLowerCase() !== 'ai livelli superiori' || !fireball.classes.endsWith('Mago, Stregone') || fireball.source !== 'SRD 5.1') throw new Error('unexpected Fireball detail');
  ok('spells 2014: 361 cards in 10 level groups, class/level/concentration/ritual filters, search, Fireball stat block in Italian with SRD 5.1 source');

  await pickOption('spell-ruleset', '5.5e (2024)');
  await waitCount('391 incantesimi');
  const counts2024 = await editionCounts();
  const fireball24 = await fireballDetail();
  results.push(`INFO spells 2024: ${JSON.stringify(counts2024)} | fireball ${JSON.stringify(fireball24)}`);
  if (JSON.stringify(counts2024) !== JSON.stringify({ all: '391 incantesimi', groups: 10, wizard3: '32 incantesimi', wizard3Concentration: '15 incantesimi', rituals: '31 incantesimi' })) throw new Error('unexpected 2024 spell counts');
  if (fireball24.subtitle !== 'Invocazione di 3° livello' || fireball24.stats.join(' | ') !== 'Azione | 45 metri | V, S, M (una pallina di guano di pipistrello e zolfo) | Istantanea'
    || fireball24.higher.toLowerCase() !== 'utilizzo di uno slot di livello superiore' || !fireball24.classes.endsWith('Mago, Stregone') || fireball24.source !== 'SRD 5.2') throw new Error('unexpected 2024 Fireball detail');
  await pickOption('spell-ruleset', 'Tutte le Edizioni');
  await waitCount('752 incantesimi');
  ok('spells 2024: 391 cards, edition filter, Fireball 2024 stat block in Italian with SRD 5.2 source and the 2024 "higher-level slot" heading');

  // Classes: 12 base classes per edition with their full sheet (overview, progression table, features, subclasses)
  await page.goto(`${base}/classes`);
  await page.locator('[data-test=class-card]').first().waitFor({ timeout: 60000 });
  const classCount = async (expected) => {
    for (let i = 0; i < 100 && (await page.locator('[data-test=class-count]').innerText()).trim() !== expected; i++) await page.waitForTimeout(100);
    return (await page.locator('[data-test=class-count]').innerText()).trim();
  };
  const allClasses = await classCount('24 classi');
  await page.locator('[data-test=class-caster] .rf-custom-select-trigger').click();
  await page.locator('[data-test=class-caster] .rf-custom-select-option', { hasText: 'Incantatore completo' }).first().click();
  const fullCasters = await classCount('10 classi');
  await page.locator('[data-test=class-caster] .rf-custom-select-trigger').click();
  await page.locator('[data-test=class-caster] .rf-custom-select-option').first().click();
  await classCount('24 classi');
  await pickOption('class-ruleset', '5e (2014)');
  const classes2014 = await classCount('12 classi');
  await page.locator('[data-test=class-search]').fill('mago');
  await page.locator('[data-test=class-card]', { hasText: 'Mago' }).first().click();
  await page.locator('[data-test=class-detail]').waitFor({ timeout: 15000 });
  const wizardSheet = { name: (await page.locator('[data-test=class-name]').textContent()).trim(), skills: (await page.locator('[data-test=class-skills]').textContent()).trim() };
  // 2014 starting equipment: one line per choice, options separated by "oppure"
  wizardSheet.equipment = [await page.locator('[data-test=class-equipment] li').count(), await page.locator('[data-test=class-equipment] .rf-loadout-or').count()];
  if (wizardSheet.equipment.join('/') !== '4/3') throw new Error(`unexpected wizard 2014 equipment: ${wizardSheet.equipment.join('/')}`);
  await page.locator('[data-test=class-tab-table]').click();
  wizardSheet.tableRows = await page.locator('[data-test=class-table] tbody tr').count();
  await page.locator('[data-test=class-tab-features]').click();
  wizardSheet.features = (await page.locator('[data-test=class-feature-name]').allTextContents()).map((t) => t.trim());
  await page.locator('[data-test=class-tab-subclasses]').click();
  wizardSheet.subclasses = await page.locator('[data-test=subclass-pill]').count();
  await page.locator('[data-test=subclass-pill]', { hasText: 'Necromanzia' }).click();
  wizardSheet.subclass = (await page.locator('[data-test=subclass-name]').textContent()).trim();
  wizardSheet.subclassFeatures = await page.locator('[data-test=subclass-detail] [data-test=class-feature]').count();
  results.push(`INFO classes: ${allClasses} (2014: ${classes2014}) | full casters=${fullCasters} | wizard ${JSON.stringify(wizardSheet)}`);
  if (allClasses !== '24 classi' || classes2014 !== '12 classi' || fullCasters !== '10 classi' || wizardSheet.name !== 'Mago' || wizardSheet.tableRows !== 20 || wizardSheet.features[0] !== 'Incantesimi'
    || wizardSheet.features.length !== 6 || wizardSheet.subclasses !== 8 || wizardSheet.subclass !== 'Scuola di Necromanzia' || wizardSheet.subclassFeatures !== 5) throw new Error('unexpected classes page');
  await page.locator('[data-test=class-detail] button', { hasText: 'CHIUDI' }).click();
  ok('classes: 24 base cards (12 per edition), caster and edition filters, 2014 Wizard sheet with 20-level table, 6 class features and 8 schools (Necromancy with 5 features)');

  // 2024 Wizard: 10 class features, 4 subclasses (Evoker from SRD 5.2)
  await page.locator('[data-test=class-search]').fill('');
  await pickOption('class-ruleset', '5.5e (2024)');
  const classes2024 = await classCount('12 classi');
  await page.locator('[data-test=class-search]').fill('mago');
  await page.locator('[data-test=class-card]', { hasText: 'Mago' }).first().click();
  await page.locator('[data-test=class-detail]').waitFor({ timeout: 15000 });
  const wizard24 = { name: (await page.locator('[data-test=class-name]').textContent()).trim() };
  // Starting equipment as two kits (A: 6 items, B: 55 mo), items linked to the equipment, link to the wizard spell list
  await page.locator('[data-test=class-spell-list]').waitFor({ timeout: 30000 });
  wizard24.kits = [await page.locator('[data-test=class-equipment-a] li').count(), (await page.locator('[data-test=class-equipment-b]').innerText()).replace(/\s+/g, ' ').trim()];
  wizard24.itemLinks = await page.locator('[data-test=class-equipment-a] a.rf-loadout-link').count();
  wizard24.spellList = await page.locator('[data-test=class-spell-list]').getAttribute('href');
  if (wizard24.kits[0] !== 6 || !wizard24.kits[1].endsWith('55 mo') || wizard24.itemLinks < 3 || wizard24.spellList !== 'spells?class=8&ruleset=2') throw new Error(`unexpected wizard 2024 equipment/spell list: ${JSON.stringify(wizard24)}`);
  await page.locator('[data-test=class-tab-table]').click();
  wizard24.tableRows = await page.locator('[data-test=class-table] tbody tr').count();
  await page.locator('[data-test=class-tab-features]').click();
  wizard24.features = (await page.locator('[data-test=class-feature-name]').allTextContents()).map((t) => t.trim());
  await page.locator('[data-test=class-tab-subclasses]').click();
  wizard24.subclasses = await page.locator('[data-test=subclass-pill]').count();
  await page.locator('[data-test=subclass-pill]', { hasText: 'Invocatore' }).click();
  wizard24.subclass = (await page.locator('[data-test=subclass-name]').textContent()).trim();
  wizard24.subclassFeatures = await page.locator('[data-test=subclass-detail] [data-test=class-feature]').count();
  results.push(`INFO classes 2024: ${classes2024} | wizard ${JSON.stringify(wizard24)}`);
  if (classes2024 !== '12 classi' || wizard24.name !== 'Mago' || wizard24.tableRows !== 20 || wizard24.features[0] !== 'Incantesimi' || wizard24.features.length !== 10
    || wizard24.subclasses !== 4 || wizard24.subclass !== 'Invocatore' || wizard24.subclassFeatures !== 5) throw new Error('unexpected 2024 classes page');
  await page.locator('[data-test=class-detail] button', { hasText: 'CHIUDI' }).click();
  ok('classes 2024: 12 cards, Wizard sheet with equipment kits A/B linked to the equipment, spell list link, 20-level table, 10 class features and 4 subclasses (Evoker with 5 features)');

  // Equipment: 450 Base items, weapon and armor tables, Longsword 2024 detail in Italian (metric weight, mastery), weapon rules
  await page.goto(`${base}/equipment`);
  await page.locator('[data-test=equipment-group]').first().waitFor({ timeout: 60000 });
  // Sections start closed (an index of the chapter): no rows until one is opened; "Espandi tutto" opens them all
  const closedRows = await page.locator('[data-test=equipment-row], [data-test=equipment-tile]').count();
  const groups = await page.locator('[data-test=equipment-group]').count();
  await page.locator('[data-test=equipment-group]', { hasText: 'Armi' }).first().click();
  await page.locator('[data-test=equipment-row]').first().waitFor({ timeout: 5000 });
  await page.locator('[data-test=equipment-group]', { hasText: 'Armi' }).first().click();
  await page.locator('[data-test=equipment-row]').first().waitFor({ state: 'detached', timeout: 5000 });
  await page.locator('[data-test=equipment-expand-all]').click();
  const openTiles = await page.locator('[data-test=equipment-tile]').count();
  await page.locator('[data-test=equipment-collapse-all]').click();
  results.push(`INFO equipment sections: ${groups} closed (rows=${closedRows}), expand all shows ${openTiles} tiles`);
  if (closedRows !== 0 || groups !== 11 || openTiles < 100) throw new Error('equipment sections do not open and close');
  ok('equipment: 11 sections closed by default, each opens and closes, expand/collapse all');
  const equipmentCount = async (expected) => {
    for (let i = 0; i < 100 && (await page.locator('[data-test=equipment-count]').innerText()).trim() !== expected; i++) await page.waitForTimeout(100);
    return (await page.locator('[data-test=equipment-count]').innerText()).trim();
  };
  const allEquipment = await equipmentCount('450 oggetti');
  await pickOption('equipment-ruleset', '5.5e (2024)');
  const equipment2024 = await equipmentCount('208 oggetti');
  await pickOption('equipment-category', 'Armi');
  const weapons2024 = await equipmentCount('38 oggetti');
  await pickOption('equipment-mastery', 'Prosciugamento');
  const sapWeapons = await equipmentCount('6 oggetti');
  await page.locator('[data-test=equipment-row]', { hasText: 'Spada lunga' }).first().click();
  await page.locator('[data-test=equipment-detail]').waitFor({ timeout: 15000 });
  const longsword = await page.evaluate(() => ({
    name: document.querySelector('[data-test=equipment-name]').textContent.trim(),
    subtitle: document.querySelector('[data-test=equipment-subtitle]').textContent.trim(),
    stats: [...document.querySelectorAll('[data-test=equipment-stats] dd')].map((d) => d.textContent.replace(/\s+/g, ' ').trim()),
  }));
  await page.locator('[data-test=equipment-detail] button', { hasText: 'CHIUDI' }).click();
  await pickOption('equipment-category', 'Armature e scudi');
  await page.locator('[data-test=equipment-row]', { hasText: 'Cotta di maglia' }).first().click();
  await page.locator('[data-test=equipment-detail]').waitFor({ timeout: 15000 });
  const chainMail = [...(await page.locator('[data-test=equipment-stats] dd').allInnerTexts())].map((t) => t.trim());
  await page.locator('[data-test=equipment-detail] button', { hasText: 'CHIUDI' }).click();
  await page.locator('[data-test=equipment-rules-open]').click();
  const masteryRules = await page.locator('[data-test=equipment-mastery-rules] dt').count();
  await page.locator('[data-test=equipment-rules] button', { hasText: 'CHIUDI' }).click();
  results.push(`INFO equipment: ${allEquipment} | 2024=${equipment2024} weapons=${weapons2024} sap=${sapWeapons} | ${JSON.stringify(longsword)} | chain mail=${JSON.stringify(chainMail)} | mastery rules=${masteryRules}`);
  if (allEquipment !== '450 oggetti' || equipment2024 !== '208 oggetti' || weapons2024 !== '38 oggetti' || sapWeapons !== '6 oggetti' || longsword.name !== 'Spada lunga'
    || longsword.subtitle !== 'Arma da guerra da mischia' || longsword.stats.slice(0, 4).join(' | ') !== '15 mo | 1,5 kg | 1d8 taglienti | Versatile (1d10)' || !longsword.stats[4]?.startsWith('Prosciugamento. ')
    || chainMail.slice(0, 5).join(' | ') !== '75 mo | 27,5 kg | 16 | For 13 | Svantaggio' || masteryRules !== 8) throw new Error('unexpected equipment page');
  ok('equipment: 450 Base items (208 of 2024), category and mastery filters, Longsword 2024 (15 mo, 1,5 kg, 1d8 taglienti, Versatile, Prosciugamento), Chain Mail (CA 16, For 13) and the weapon rules');

  // Magic items: 276 items of 2014 in 9 closed categories, category filter, a search that finds a variant, the item
  // detail with its variants and a variant with the healing the sheet applies
  await page.goto(`${base}/magic-items`);
  await page.locator('[data-test=magic-group]').first().waitFor({ timeout: 60000 });
  const magicClosed = await page.locator('[data-test=magic-card]').count();
  const magicGroups = await page.locator('[data-test=magic-group]').count();
  const magicCount = async (expected) => {
    for (let i = 0; i < 100 && (await page.locator('[data-test=magic-count]').innerText()).trim() !== expected; i++) await page.waitForTimeout(100);
    return (await page.locator('[data-test=magic-count]').innerText()).trim();
  };
  const allMagic = await magicCount('276 oggetti');
  await pickOption('magic-type', 'Pozioni');
  const potions = await magicCount('25 oggetti');
  await page.locator('[data-test=magic-search]').fill('superiore');
  await page.locator('[data-test=magic-card]', { hasText: 'Pozione di guarigione' }).first().click();
  await page.locator('[data-test=magic-detail]').waitFor({ timeout: 15000 });
  const healingVariants = await page.locator('[data-test=magic-variants] tr').count();
  await page.locator('[data-test=magic-variant-link]', { hasText: 'Pozione di guarigione superiore' }).click();
  await page.locator('[data-test=magic-detail-name]', { hasText: 'Pozione di guarigione superiore' }).waitFor({ timeout: 15000 });
  const superior = {
    parent: (await page.locator('[data-test=magic-parent]').innerText()).trim(),
    onSheet: (await page.locator('[data-test=magic-on-sheet]').innerText()).trim(),
    table: await page.locator('[data-test=magic-description] table').count(),
  };
  await page.locator('[data-test=magic-detail] button', { hasText: 'CHIUDI' }).click();
  results.push(`INFO magic items: closed=${magicClosed} groups=${magicGroups} | ${allMagic} | potions=${potions} | healing variants=${healingVariants} | superior=${JSON.stringify(superior)}`);
  if (magicClosed !== 0 || magicGroups !== 9 || allMagic !== '276 oggetti' || potions !== '25 oggetti' || healingVariants !== 4
    || !/Pozione di guarigione/.test(superior.parent) || !/8d4\+8/.test(superior.onSheet) || superior.table !== 1) throw new Error('unexpected magic items page');
  ok('magic items: 276 items of 2014 in 9 closed categories, 25 potions, a search finds a variant, Potion of Healing with 4 variants, Superior (8d4+8 on the sheet)');

  // Rules glossary: 243 Base entries (155 of 2024, 88 of 2014), family filter, Prone 2024 with its own terms linked and "See also"
  await page.goto(`${base}/rules`);
  await page.locator('[data-test=rules-group]').first().waitFor({ timeout: 60000 });
  const closedRules = await page.locator('[data-test=rules-tile]').count();
  await page.locator('[data-test=rules-expand-all]').click();
  const openRules = await page.locator('[data-test=rules-tile]').count();
  await page.locator('[data-test=rules-collapse-all]').click();
  if (closedRules !== 0 || openRules !== 243) throw new Error(`glossary families do not open and close: closed=${closedRules} open=${openRules}`);
  const rulesCount = async (expected) => {
    for (let i = 0; i < 100 && (await page.locator('[data-test=rules-count]').innerText()).trim() !== expected; i++) await page.waitForTimeout(100);
    return (await page.locator('[data-test=rules-count]').innerText()).trim();
  };
  const allRules = await rulesCount('243 termini');
  await pickOption('rules-ruleset', '5.5e (2024)');
  const rules2024 = await rulesCount('155 termini');
  await pickOption('rules-category', 'Condizioni');
  const conditions2024 = await rulesCount('15 termini');
  await page.locator('[data-test=rules-tile]').filter({ has: page.locator('.rf-glossary-tile-name', { hasText: /^Prono$/ }) }).first().click();
  await page.locator('[data-test=rules-detail]').waitFor({ timeout: 15000 });
  const prone = await page.evaluate(() => ({
    name: document.querySelector('[data-test=rules-name]').textContent.trim(),
    tag: document.querySelector('[data-test=rules-tag]').textContent.trim(),
    terms: [...document.querySelectorAll('[data-test=rules-description] a.rf-term')].map((a) => a.textContent.trim()),
    url: location.pathname + location.search.replace(/=.*/, '='),
  }));
  await page.locator('[data-test=rules-detail] button', { hasText: 'CHIUDI' }).click();
  await page.locator('[data-test=rules-detail]').waitFor({ state: 'detached', timeout: 5000 });
  results.push(`INFO glossary: ${allRules} | 2024=${rules2024} conditions=${conditions2024} | prone ${JSON.stringify(prone)}`);
  if (allRules !== '243 termini' || rules2024 !== '155 termini' || conditions2024 !== '15 termini' || prone.name !== 'Prono' || prone.tag !== 'Condizione'
    || prone.terms.join(',') !== 'svantaggio,vantaggio' || prone.url !== '/rules?id=') throw new Error('unexpected glossary page');
  ok('glossary: 243 Base entries (155 of 2024), edition and family filters, Prone 2024 (Condizione) with its rules terms linked, opened at rules?id=');
  // Search: the entry named like the text comes first, before the ones that only mention it
  await page.goto(`${base}/rules`);
  await page.locator('[data-test=rules-group]').first().waitFor({ timeout: 60000 });
  await page.locator('[data-test=rules-search]').fill('Paralizzato');
  await page.locator('[data-test=rules-tile]').first().waitFor({ timeout: 15000 });
  for (let i = 0; i < 50 && await page.locator('[data-test=rules-tile] .rf-glossary-tile-name').count() < 2; i++) await page.waitForTimeout(100);
  const paralyzedOrder = (await page.locator('[data-test=rules-tile] .rf-glossary-tile-name').allInnerTexts()).map((t) => t.trim());
  results.push(`INFO glossary search "Paralizzato": ${paralyzedOrder.slice(0, 5).join(', ')}`);
  if (paralyzedOrder[0] !== 'Paralizzato' || paralyzedOrder.length < 2) throw new Error(`the condition is not the first result: ${paralyzedOrder.join(', ')}`);
  ok('list search: "Paralizzato" shows the condition first, then the entries that mention it');

  // Rules terms in the other modules: Command 2024 links "prono" and "azione bonus", with a tooltip and a link to the glossary
  await page.goto(`${base}/spells`);
  await page.locator('[data-test=spell-level-group]').first().waitFor({ timeout: 60000 });
  await pickOption('spell-ruleset', '5.5e (2024)');
  await page.locator('[data-test=spell-search]').fill('comando');
  await page.locator('[data-test=spell-card]').filter({ has: page.locator('.rf-card-title', { hasText: /^Comando$/ }) }).first().click();
  await page.locator('[data-test=spell-detail]').waitFor({ timeout: 15000 });
  await page.locator('[data-test=spell-detail] a.rf-term').first().waitFor({ timeout: 30000 });
  const commandTerms = (await page.locator('[data-test=spell-detail] a.rf-term').allInnerTexts()).map((t) => t.trim());
  await page.locator('[data-test=spell-detail] a.rf-term', { hasText: 'prono' }).hover();
  await page.locator('.rf-term-tip.visible').waitFor({ timeout: 5000 });
  const tooltip = (await page.locator('.rf-term-tip').innerText()).replace(/\s+/g, ' ').trim();
  await page.locator('[data-test=spell-detail] a.rf-term', { hasText: 'prono' }).click();
  await page.locator('[data-test=rules-detail]').waitFor({ timeout: 15000 });
  const linkedEntry = (await page.locator('[data-test=rules-name]').textContent()).trim();
  results.push(`INFO glossary terms in Command 2024: ${JSON.stringify(commandTerms)} | tooltip="${tooltip.slice(0, 90)}" | link opens ${linkedEntry}`);
  if (commandTerms.join(',') !== 'prono,azione bonus' || !tooltip.startsWith('Prono Condizione Mentre ha la condizione di prono') || linkedEntry !== 'Prono') throw new Error('unexpected glossary links in spell texts');
  ok('glossary links: Command 2024 links "prono" and "azione bonus"; hover shows the Prone tooltip, click opens the glossary entry');


  await page.goto(`${base}/account`);
  await page.getByText('Non hai un account? Registrati').waitFor({ timeout: 30000 });
  const collapsedLinks = await page.locator('[data-test=nav-compendium] a').count();
  if (collapsedLinks !== 0) throw new Error(`compendium group should start collapsed outside the compendium (${collapsedLinks} links)`);
  await page.locator('[data-test=nav-compendium] button').click();
  await page.locator('[data-test=nav-compendium] a').first().waitFor({ timeout: 5000 });
  await page.locator('[data-test=nav-compendium] button').click();
  // The "Compendio" icon does not move when the group opens (the sidebar keeps room for its scrollbar)
  const compendiumIcon = () => page.locator('[data-test=nav-compendium] button svg').first().evaluate((el) => { const r = el.getBoundingClientRect(); return `${Math.round(r.left)},${Math.round(r.top)}`; });
  const iconClosed = await compendiumIcon();
  // Every menu icon sits inside its entry (not on the hover edge) and in the same column as the "Compendio" icon
  // (measured on the account page, where the group starts closed: open it, measure, close it again)
  await page.locator('[data-test=nav-compendium] button').click();
  await page.locator('[data-test=nav-compendium] a').first().waitFor({ timeout: 5000 });
  const iconOpen = await compendiumIcon();
  if (iconClosed !== iconOpen) throw new Error(`the compendium icon moves when the group opens: ${iconClosed} -> ${iconOpen}`);
  await page.locator('[data-test=nav-compendium] a').first().waitFor({ timeout: 5000 });
  const iconGaps = await page.evaluate(() => [...document.querySelectorAll('.sidebar .nav-link, .sidebar .rf-nav-group-toggle')].map((el) => {
    const icon = el.querySelector('svg').getBoundingClientRect();
    return { label: el.textContent.trim(), inset: Math.round(icon.left - el.getBoundingClientRect().left), left: Math.round(icon.left) };
  }));
  results.push(`INFO menu icons: ${iconGaps.map((g) => `${g.label}@${g.left}(+${g.inset})`).join(', ')}`);
  if (iconGaps.length !== 15 || iconGaps.some((g) => g.inset < 8) || new Set(iconGaps.map((g) => g.left)).size !== 1) throw new Error('menu icons are not padded or not aligned');
  await page.locator('[data-test=nav-compendium] button').click();
  ok('"Compendio" menu group: Specie, Background, Talenti, Incantesimi, Classi, Equipaggiamento, and Glossario next to it; collapsed elsewhere and toggles on click; icons padded and aligned');
  await page.getByText('Non hai un account? Registrati').click();
  await page.locator('input[type=email]').fill(email);
  // Own show / hide button: visible before the field is touched, not only while typing as the browser's eye
  const pwdToggle = page.locator('[data-test=auth-password-toggle]');
  if (!(await pwdToggle.isVisible())) throw new Error('the show password button is not visible on the sign-in form');
  await page.locator('input[type=password]').fill(throwawayCredential);
  await page.locator('[data-test=account-area]').click();
  const toggleAfterBlur = await pwdToggle.isVisible();
  await pwdToggle.click();
  const shown = await page.locator('[data-test=auth-password]').evaluate((el) => ({ type: el.type, value: el.value }));
  const pressed = await pwdToggle.getAttribute('aria-pressed');
  await pwdToggle.click();
  const hiddenType = await page.locator('[data-test=auth-password]').getAttribute('type');
  results.push(`INFO password toggle: visible after leaving the field=${toggleAfterBlur} shown=${shown.type} pressed=${pressed} hidden again=${hiddenType}`);
  if (!toggleAfterBlur || shown.type !== 'text' || shown.value !== throwawayCredential || pressed !== 'true' || hiddenType !== 'password') throw new Error('the show / hide password button does not work');
  ok('password field: own show / hide button, visible before and after typing, toggles plain text and back');
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
  await page.locator('[data-test=feat-group]').first().waitFor({ timeout: 30000 });
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
  const homebrewTitles = (await page.locator('.rf-card .rf-card-title').allTextContents()).map((t) => t.trim()); // textContent: titles are uppercased by CSS
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
  // Equipment ledger: plain lines without markers, the coin pouch with its value in gold on the right
  const ledger = await page.evaluate(() => {
    const items = [...document.querySelectorAll('[data-test=bg-equipment] li')];
    return {
      bullets: getComputedStyle(items[0]).listStyleType,
      marker: getComputedStyle(items[0], '::before').content,
      coins: items.filter((li) => li.classList.contains('rf-loadout-coins')).map((li) => li.textContent.replace(/\s+/g, ' ').trim()),
      title: getComputedStyle(document.querySelector('[data-test=bg-equipment] .rf-loadout-title')).color,
    };
  });
  results.push(`INFO equipment ledger: ${JSON.stringify(ledger)}`);
  if (ledger.bullets !== 'none' || (ledger.marker !== 'none' && ledger.marker !== 'normal') || ledger.coins.length !== 1 || !ledger.coins[0].endsWith('15 mo')) throw new Error('unexpected equipment ledger');
  const source = (await page.locator('[data-test=content-source]').first().innerText()).trim();
  const badge = (await page.locator('.rf-modal-dialog [data-test=content-badge]').first().textContent()).trim(); // textContent: the badge CSS uppercases the rendered text
  results.push(`INFO Acolyte badge='${badge}' source='${source}'`);
  if (badge !== 'Base' || source !== 'Fonte: SRD 5.1') throw new Error(`unexpected badge/source: ${badge} / ${source}`);
  await page.getByRole('button', { name: 'CHIUDI' }).click();
  ok('SRD Acolyte: four stacked characteristic tables (d8, d6, d6, d6), equipment as a ledger with the coin pouch value in gold, badge "Base", source SRD 5.1');

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
  await page.waitForTimeout(1000);
  const infoCallsBefore = authCalls.filter((c) => c.includes('/manage/info')).length;
  await page.locator('[data-test=species-search]').fill('nano');
  await page.locator('.rf-card .rf-card-title', { hasText: /^Nano$/ }).first().waitFor({ timeout: 10000 });
  const speciesFound = await page.locator('.rf-card').count();
  await page.locator('[data-test=species-search]').fill('zzzz');
  await page.locator('[data-test=species-empty]', { hasText: 'Nessuna specie corrisponde alla ricerca.' }).waitFor({ timeout: 10000 });
  const infoCallsWhileTyping = authCalls.filter((c) => c.includes('/manage/info')).length - infoCallsBefore;
  results.push(`INFO species search: total=${speciesTotal} "nano"=${speciesFound} account calls while typing=${infoCallsWhileTyping}`);
  if (speciesFound < 1 || speciesFound >= speciesTotal) throw new Error(`species search did not filter: ${speciesFound}/${speciesTotal}`);
  // The create button reads the cached sign-in state: typing in the search must not call the account API
  if (infoCallsWhileTyping !== 0) throw new Error(`${infoCallsWhileTyping} account API calls while typing in the search`);
  ok('species search filters by text and explains when nothing matches');

  // Global search: Italian and English names, results grouped by section with the edition
  await page.goto(`${base}/search?q=palla di fuoco`);
  await page.locator('[data-test=search-hit]').first().waitFor({ timeout: 30000 });
  const searchFireball = (await page.locator('[data-test=search-group][data-kind=spell] [data-test=search-hit]').first().innerText()).replace(/\s+/g, ' ').trim();
  await page.locator('[data-test=search-input]').fill('goblin');
  await page.locator('[data-test=search-group][data-kind=monster]').waitFor({ timeout: 15000 });
  const searchGroups = await page.locator('[data-test=search-group]').evaluateAll((els) => els.map((e) => e.getAttribute('data-kind')).join(','));
  await shot(page, 'search', 'main');
  await page.locator('[data-test=search-input]').fill('zzqqxx');
  await page.locator('[data-test=search-none]').waitFor({ timeout: 15000 });
  results.push(`INFO search: fireball='${searchFireball}' goblin groups=${searchGroups}`);
  if (!/Palla di Fuoco/i.test(searchFireball) || !/Fireball/.test(searchFireball) || !searchGroups.startsWith('monster')) throw new Error('unexpected global search results');
  ok('global search: "palla di fuoco" finds the spell with its English name, "goblin" the monsters first, nothing for nonsense');

  // Account page: profile, Homebrew counts (the UI created one background) and password change
  await page.goto(`${base}/account`);
  await page.locator('[data-test=account-role]').waitFor({ timeout: 30000 });
  const role = (await page.locator('[data-test=account-role]').innerText()).trim();
  const emailStatus = (await page.locator('[data-test=account-email-status]').innerText()).trim();
  if (emailStatus !== 'verificata' || await page.locator('[data-test=account-verify]').count() !== 0) throw new Error(`unexpected e-mail status: ${emailStatus}`);
  const stats = (await page.locator('[data-test=account-homebrew] .rf-account-stat').allInnerTexts()).map((t) => t.replace(/\s+/g, ' ').trim());
  results.push(`INFO account role='${role}' homebrew=[${stats.join(' | ')}]`);
  if (!/^utente$/i.test(role) || !stats.some((t) => /^0 talenti$/i.test(t)) || !stats.some((t) => /^1 background$/i.test(t))) throw new Error('unexpected account summary');
  // Base content per section and edition, moved here from the dashboard (Homebrew is not counted)
  await page.locator('[data-test=account-compendium-equipment]').waitFor({ timeout: 30000 });
  const compendium = await page.evaluate(() => Object.fromEntries([...document.querySelectorAll('[data-test=account-compendium] tbody tr')]
    .map((tr) => [tr.getAttribute('data-test').replace('account-compendium-', ''), [...tr.querySelectorAll('td.rf-num')].map((td) => td.textContent.trim()).join('/')])));
  results.push(`INFO account compendium (2024/2014): ${JSON.stringify(compendium)}`);
  if (JSON.stringify(compendium) !== JSON.stringify({ rules: '155/88', species: '10/9', backgrounds: '16/13', feats: '75/42', spells: '391/361', classes: '12/12', equipment: '208/242', monsters: '0/441' })) throw new Error('unexpected compendium counts in the account');
  ok('account: Base content per section and edition (glossary 155+88, species 10+9, backgrounds 16+13, feats 75+42, spells 391+361, classes 12+12, equipment 208+242)');
  const newCredential = ['Rf', crypto.randomUUID(), 'B!'].join('-');
  await page.locator('[data-test=pwd-current]').fill('wrong-password-1A!');
  await page.locator('[data-test=pwd-new]').fill(newCredential);
  // Live check of the repetition: silent while it is still a beginning of the new password, a warning on a typo, a confirmation when equal
  const matchHint = async () => (await page.locator('[data-test=pwd-match]').innerText()).trim();
  await page.locator('[data-test=pwd-repeat]').fill(newCredential.slice(0, 6));
  const whileTyping = await matchHint();
  await page.locator('[data-test=pwd-repeat]').fill(`${newCredential.slice(0, 6)}#`);
  await page.locator('[data-test=pwd-match]', { hasText: 'diversa' }).waitFor({ timeout: 5000 });
  const typo = await matchHint();
  const typoInvalid = await page.locator('[data-test=pwd-repeat]').getAttribute('aria-invalid');
  await page.locator('[data-test=pwd-repeat]').fill(newCredential);
  await page.locator('[data-test=pwd-match]', { hasText: 'coincidono' }).waitFor({ timeout: 5000 });
  const typoCleared = await page.locator('[data-test=pwd-repeat]').getAttribute('aria-invalid');
  results.push(`INFO repeat check: typing='${whileTyping}' typo='${typo}' (aria-invalid=${typoInvalid}) equal='${await matchHint()}'`);
  if (whileTyping !== '' || typoInvalid !== 'true' || typoCleared !== null) throw new Error('the repeated password check does not react as expected');
  ok('change password: the repeated password is checked while typing (silent, warning on a typo, confirmation when equal)');
  await page.getByRole('button', { name: 'Aggiorna password' }).click();
  await page.getByText('La password attuale non è corretta.').waitFor({ timeout: 15000 });
  await page.locator('[data-test=pwd-current]').fill(throwawayCredential);
  await page.getByRole('button', { name: 'Aggiorna password' }).click();
  await page.getByText('Password aggiornata.').waitFor({ timeout: 15000 });
  ok('account page: role "Utente", Homebrew counts (0 feats, 1 background), password change rejects a wrong current password and succeeds with the right one');
  // Account deletion asks for the password: a wrong one is refused and the account stays (the dialog is then closed)
  await page.locator('[data-test=account-delete-open]').click();
  await page.locator('[data-test=account-delete-confirm]').waitFor({ timeout: 5000 });
  await page.locator('[data-test=account-delete-password]').fill('wrong-password-1A!');
  await page.locator('[data-test=account-delete-yes]').click();
  await page.locator('[data-test=account-delete-error]', { hasText: 'Password non corretta' }).waitFor({ timeout: 15000 });
  await shot(page, 'account-delete', '[data-test=account-delete-confirm]');
  await page.locator('[data-test=account-delete-confirm]').getByRole('button', { name: 'Annulla' }).click();
  await page.locator('[data-test=account-delete-confirm]').waitFor({ state: 'detached', timeout: 5000 });
  await shot(page, 'account-danger', '[data-test=account-delete]');
  ok('account deletion: the dialog asks for the password, a wrong one is refused and nothing is deleted');

  // Passkey with Chromium's virtual authenticator (fingerprint simulated): added on the account page, then used to sign in
  const cdp = await context.newCDPSession(page);
  await cdp.send('WebAuthn.enable');
  const { authenticatorId } = await cdp.send('WebAuthn.addVirtualAuthenticator', { options: {
    protocol: 'ctap2', transport: 'internal', hasResidentKey: true, hasUserVerification: true, isUserVerified: true, automaticPresenceSimulation: true } });
  await page.locator('[data-test=account-passkey-name]').fill('Portatile CI');
  await page.locator('[data-test=account-passkey-add]').click();
  await page.locator('[data-test=account-passkey]', { hasText: 'Portatile CI' }).waitFor({ timeout: 15000 });
  const passkeyMessage = (await page.locator('[data-test=account-passkey-message]').innerText()).trim();
  await shot(page, 'account-passkeys', '[data-test=account-passkeys]');
  // The same device again: the browser refuses a second passkey for the account
  await page.locator('[data-test=account-passkey-add]').click();
  await page.locator('[data-test=account-passkey-message]', { hasText: 'già una passkey' }).waitFor({ timeout: 15000 });
  await page.locator('[data-test=account-logout]').click();
  await page.locator('[data-test=auth-passkey]').waitFor({ timeout: 15000 });
  await shot(page, 'login-passkey', 'main');
  // The errors handled on the account page (wrong password of the deletion, a refused passkey) do not raise the page banner
  const bannerOnLogin = await page.locator('[data-test=api-error]').count();
  await page.locator('[data-test=auth-passkey]').click();
  await page.locator('[data-test=account-area]', { hasText: email }).waitFor({ timeout: 30000 });
  const credentials = (await cdp.send('WebAuthn.getCredentials', { authenticatorId })).credentials.length;
  results.push(`INFO passkey: added='${passkeyMessage}' credentials on the device=${credentials}`);
  if (!/aggiunta/i.test(passkeyMessage) || credentials !== 1 || bannerOnLogin !== 0) throw new Error(`unexpected passkey flow (banner=${bannerOnLogin})`);
  ok('passkey: added from the account page with a (virtual) fingerprint, a second one on the same device refused, sign-out and sign-in with the passkey');

  // Administration (admin-ui@example.com is in Auth:AdminEmails in this job): figures, an account suspended,
  // reactivated and deleted, the Homebrew moderation; an ordinary account is turned away
  await page.goto(`${base}/admin`);
  await page.locator('[data-test=admin-denied]').waitFor({ timeout: 30000 });
  const apiBase = 'http://localhost:5080';
  const adminCredential = ['Rf', crypto.randomUUID(), 'A!'].join('-');
  const victim = `victim${Date.now()}@example.com`;
  for (const who of ['admin-ui@example.com', victim]) {
    await context.request.post(`${apiBase}/api/auth/register`, { data: { email: who, password: adminCredential } });
  }
  const adminLogin = await (await context.request.post(`${apiBase}/api/auth/login`, { data: { email: 'admin-ui@example.com', password: adminCredential } })).json();
  const adminContext = await browser.newContext({ viewport: { width: 1280, height: 900 } });
  await adminContext.addInitScript((tokens) => localStorage.setItem('realmforge.auth', tokens), JSON.stringify({
    AccessToken: adminLogin.accessToken, RefreshToken: adminLogin.refreshToken, ExpiresAt: new Date(Date.now() + adminLogin.expiresIn * 1000).toISOString() }));
  const admin = await adminContext.newPage();
  await admin.goto(`${base}/admin`);
  await admin.locator('[data-test=admin-stats]').waitFor({ timeout: 30000 });
  const adminStats = (await admin.locator('[data-test=admin-stats]').innerText()).replace(/\s+/g, ' ').trim();
  await admin.locator('[data-test=admin-user-search]').fill(victim);
  const victimRow = admin.locator('[data-test=admin-user]', { hasText: victim });
  await victimRow.waitFor({ timeout: 15000 });
  await victimRow.locator('[data-test=admin-user-suspend]').click();
  await admin.locator('[data-test=admin-suspend-7]').click();
  await admin.locator('[data-test=admin-suspend-yes]').click();
  await victimRow.locator('[data-test=admin-user-locked]').waitFor({ timeout: 15000 });
  const lockedLogin = (await context.request.post(`${apiBase}/api/auth/login`, { data: { email: victim, password: adminCredential } })).status();
  await shot(admin, 'admin-users', 'main');
  await victimRow.locator('[data-test=admin-user-reactivate]').click();
  await victimRow.locator('[data-test=admin-user-suspend]').waitFor({ timeout: 15000 });
  const unlockedLogin = (await context.request.post(`${apiBase}/api/auth/login`, { data: { email: victim, password: adminCredential } })).status();
  await victimRow.locator('[data-test=admin-user-delete]').click();
  await admin.locator('[data-test=admin-delete-yes]').click();
  await victimRow.waitFor({ state: 'detached', timeout: 15000 });
  await admin.locator('[data-test=admin-tab-homebrew]').click();
  await admin.locator('[data-test=admin-homebrew-filter] .rf-pill-btn').last().click();
  await admin.locator('[data-test=admin-homebrew-entry]').first().waitFor({ timeout: 15000 });
  const moderated = await admin.locator('[data-test=admin-homebrew-entry]').count();
  await shot(admin, 'admin-homebrew', 'main');
  await adminContext.close();
  results.push(`INFO admin: stats='${adminStats}' locked login=${lockedLogin} reactivated login=${unlockedLogin} homebrew rows=${moderated}`);
  if (lockedLogin !== 401 || unlockedLogin !== 200 || moderated < 1 || !/account/i.test(adminStats)) throw new Error('unexpected administration page');
  ok('administration: ordinary account turned away; figures, a suspended account cannot sign in until reactivated, then deleted; Homebrew listed for moderation');

  // Character creation at phone width (375 px): edition order, every step of the 2024 wizard (overflow checked),
  // the interactive sheet (damage saved on its own, rests, tabs, PDF), a level up into a second class and the list
  await page.setViewportSize({ width: 375, height: 812 });
  await page.goto(`${base}/characters`);
  await page.locator('[data-test=characters-empty]').waitFor({ timeout: 30000 });
  characterAudits.push(await overflowOf(page, '/characters'));
  await page.locator('[data-test=characters-empty] a').click();
  await page.locator('[data-test=wizard-name]').waitFor({ timeout: 60000 });
  const wizardStep = async (name) => {
    await page.locator(`[data-test=wizard-step-${name}]`).waitFor({ timeout: 20000 });
    await page.waitForTimeout(300);
    characterAudits.push(await overflowOf(page, `wizard ${name}`));
  };
  const next = async () => { await page.locator('[data-test=wizard-next]').click(); await page.waitForTimeout(150); };
  const choose = async (test, text) => {
    await page.locator(`[data-test=${test}] [data-test=selector-value]`).first().click();
    await page.locator(`[data-test=${test}] [role=option]`, { hasText: text }).first().click();
  };
  const nextOption = (test) => page.locator(`[data-test=${test}] [data-test=selector-next]`).first().click();
  const pickFree = async (selector, count) => { for (let k = 0; k < count; k++) await page.locator(`${selector}:not(.selected):not([disabled])`).first().click(); };
  const counter = async (locator) => (await locator.innerText()).match(/(\d+)\s*\/\s*(\d+)/).slice(1).map(Number);

  await wizardStep('identity');
  await next();
  await page.locator('[data-test=wizard-error]').waitFor({ timeout: 5000 });
  await page.locator('[data-test=wizard-name]').fill('Eroe di prova');
  await choose('wizard-advancement', 'narrativa');
  await page.locator('[data-test=wizard-advancement-hint]', { hasText: 'master' }).waitFor({ timeout: 5000 });
  await choose('wizard-advancement', 'punti esperienza');
  await page.locator('[data-test=wizard-advancement-hint]', { hasText: 'accumulando' }).waitFor({ timeout: 5000 });
  // 2014: the race comes right after the identity, with the 2014 terms
  await choose('wizard-edition', '2014');
  await page.locator('[data-test=character-wizard][data-ruleset="1"]').waitFor({ timeout: 30000 });
  await next();
  await wizardStep('species');
  const step2014 = (await page.locator('[data-test=wizard-step-title]').innerText()).trim();
  await page.locator('[data-test=wizard-racial-increases]').waitFor({ timeout: 10000 });
  await page.locator('[data-test=wizard-back]').click();
  await choose('wizard-edition', '2024');
  await page.locator('[data-test=character-wizard][data-ruleset="2"]').waitFor({ timeout: 30000 });
  await next();

  await wizardStep('class');
  const step2024 = (await page.locator('[data-test=wizard-step-title]').innerText()).trim();
  await choose('wizard-class', /^Mago$/);
  await page.locator('[data-test=wizard-class-panel]', { hasText: 'Mago' }).waitFor({ timeout: 15000 });
  await next();
  await page.locator('[data-test=wizard-error]').waitFor({ timeout: 5000 });
  // The preselected background is not "known" before its step: Insight (Acolyte) can be picked for the class
  const knownBeforeBackground = await page.locator('[data-test=wizard-skill] .rf-wizard-pill.known').count();
  await page.locator('[data-test=wizard-skill-option]', { hasText: 'Intuizione' }).click();
  await pickFree('[data-test=wizard-skill-option]', 1);
  await next();

  await wizardStep('background');
  await choose('wizard-background', /^Accolito$/);
  // Acolyte grants Insight: the class pick is given back and chosen again in this step
  await page.locator('[data-test=wizard-class-skill-fix]').waitFor({ timeout: 10000 });
  await next();
  await page.locator('[data-test=wizard-error]').waitFor({ timeout: 5000 });
  await pickFree('[data-test=wizard-skill-fix-option]', 1);
  const fixGone = await page.locator('[data-test=wizard-class-skill-fix]').count();
  if (knownBeforeBackground !== 0 || fixGone !== 0) throw new Error(`skill overlap not handled: known before background=${knownBeforeBackground} fix still shown=${fixGone}`);
  ok('wizard skills: the preselected background does not lock class skills, an overlap is re-picked in the background step');
  await page.locator('[data-test=wizard-feat-list]').waitFor({ timeout: 15000 });
  await nextOption('wizard-feat-list');
  await nextOption('wizard-feat-ability');
  await next();

  await wizardStep('species');
  await choose('wizard-species', /^Nano$/);
  await page.locator('[data-test=wizard-species-panel]').waitFor({ timeout: 15000 });
  await next();

  await wizardStep('abilities');
  await page.locator('[data-test=wizard-suggested]').click();
  await next();

  await wizardStep('progression');
  await next();

  await wizardStep('languages');
  const [, languageChoices] = await counter(page.locator('[data-test=wizard-language-count]'));
  await pickFree('[data-test=wizard-language]', languageChoices);
  await next();

  await wizardStep('equipment');
  const previewAc = (await page.locator('[data-test=wizard-preview-ac]').innerText()).trim();
  // Leaving the wizard (a link to the compendium) and coming back restores the draft at the same step
  await page.goto(`${base}/backgrounds`);
  await page.getByText('Accolito').first().waitFor({ timeout: 30000 });
  await page.goto(`${base}/characters/new`);
  await page.locator('[data-test=wizard-draft]').waitFor({ timeout: 60000 });
  await wizardStep('equipment');
  const draftAc = (await page.locator('[data-test=wizard-preview-ac]').innerText()).trim();
  if (draftAc !== previewAc) throw new Error(`the wizard draft was not restored: AC ${draftAc} vs ${previewAc}`);
  ok('wizard draft: leaving for the compendium and coming back keeps the choices and the step');
  await next();

  await wizardStep('spells');
  await next();
  await page.locator('[data-test=wizard-error]').waitFor({ timeout: 5000 });
  let chosenSpells = 0;
  for (const picker of await page.locator('[data-test=spell-picker]').all()) {
    const [have, want] = await counter(picker.locator('.rf-wizard-counter'));
    for (let k = have; k < want; k++) await picker.locator('button:not(.rf-spell-info):not(.selected):not([disabled])').first().click();
    chosenSpells += want;
  }
  await next();

  await wizardStep('details');
  await page.locator('[data-test=wizard-suggest-all]').click();
  const suggestedTraits = (await page.locator('[data-test=wizard-detail-traits]').inputValue()).trim();
  const suggestedStory = (await page.locator('[data-test=wizard-detail-backstory]').inputValue()).trim();
  if (suggestedTraits.length < 10 || !suggestedStory.includes('Eroe di prova')) throw new Error(`the suggestions did not fill the details: ${suggestedTraits} | ${suggestedStory}`);
  ok('wizard details: "suggest" fills traits and a backstory that names the character');
  await next();
  await wizardStep('summary');
  const summaryAc = (await page.locator('[data-test=summary-ac]').innerText()).trim();
  const summaryHp = (await page.locator('[data-test=summary-hp]').innerText()).trim();
  await page.locator('[data-test=wizard-forge]').click();

  // The sheet: computed like the summary, the hit points change and are saved without a save button
  await page.locator('[data-test=character-sheet]').waitFor({ timeout: 30000 });
  await page.waitForTimeout(500);
  characterAudits.push(await overflowOf(page, 'sheet'));
  const sheetName = (await page.locator('[data-test=sheet-name]').innerText()).trim();
  const sheetAc = (await page.locator('[data-test=sheet-ac]').innerText()).trim();
  const sheetSenses = (await page.locator('[data-test=sheet-senses]').innerText()).replace(/\s+/g, ' ').trim();
  const sheetHp = (await page.locator('[data-test=sheet-hp]').innerText()).trim();
  // Advancement type: chosen in the wizard only (no switch on the sheet); XP-based shows the bar, 300 XP make level 2 ready
  await page.locator('[data-test=sheet-xp]').waitFor({ timeout: 10000 });
  const milestoneXpBar = await page.locator('[data-test^=sheet-advancement]').count();
  await page.locator('[data-test=sheet-xp-amount]').fill('300');
  await page.locator('[data-test=sheet-xp-amount]').press('Tab');
  await page.locator('[data-test=sheet-xp-add]').click();
  const xpValue = (await page.locator('[data-test=sheet-xp-value]').innerText()).trim();
  const levelUpReady = await page.locator('[data-test=sheet-levelup].rf-pulse').count();
  if (milestoneXpBar !== 0 || xpValue !== '300 / 300' || levelUpReady !== 1) throw new Error(`advancement type: switches on the sheet=${milestoneXpBar} xp=${xpValue} ready=${levelUpReady}`);
  ok('advancement type: chosen in the wizard (hint for each), no switch on the sheet; XP-based shows the bar and highlights the level up at 300 XP');
  // Class resources computed on their own: the wizard's Arcane Recovery, spent with "use" and back after a long rest
  const classResources = await page.locator('[data-test=sheet-class-resource]').allInnerTexts();
  await page.locator('[data-test=sheet-class-resource-use]').first().click();
  const resourceSpent = await page.locator('[data-test=sheet-class-resource-use][disabled]').count();
  if (!/Recupero Arcano/.test(classResources.join('|')) || resourceSpent !== 1) throw new Error(`class resources: ${JSON.stringify(classResources)} spent=${resourceSpent}`);
  await page.locator('[data-test=sheet-hp-amount]').fill('3');
  await page.locator('[data-test=sheet-hp-amount]').press('Tab');
  await page.locator('[data-test=sheet-damage]').click();
  await page.locator('[data-test=sheet-save-status]', { hasText: 'Salvato' }).waitFor({ timeout: 15000 });
  await page.reload();
  await page.locator('[data-test=character-sheet]').waitFor({ timeout: 60000 });
  const afterReload = (await page.locator('[data-test=sheet-hp-current]').innerText()).trim();
  const xpAfterReload = (await page.locator('[data-test=sheet-xp-value]').innerText()).trim();
  if (xpAfterReload !== '300 / 300') throw new Error(`the advancement type or the XP were not saved: ${xpAfterReload}`);
  // Heroic inspiration: the star and the label on the same middle line
  const inspiration = await page.evaluate(() => {
    const button = document.querySelector('[data-test=sheet-inspiration]');
    const mid = (el) => { const r = el.getBoundingClientRect(); return r.top + r.height / 2; };
    return { star: mid(button.querySelector('svg')), label: mid(button.querySelector('span')), button: mid(button) };
  });
  results.push(`INFO inspiration: star ${(inspiration.star - inspiration.button).toFixed(1)}px, label ${(inspiration.label - inspiration.button).toFixed(1)}px from the middle`);
  if (Math.abs(inspiration.star - inspiration.button) > 1 || Math.abs(inspiration.label - inspiration.button) > 1.5) throw new Error(`inspiration not aligned: ${JSON.stringify(inspiration)}`);
  // Portrait: choosing a picture opens the crop; dragged and zoomed, it is saved as a square JPEG
  await page.setViewportSize({ width: 1280, height: 900 });
  const picture = await page.screenshot({ clip: { x: 0, y: 0, width: 900, height: 500 } });
  await page.locator('[data-test=sheet-portrait-upload] input[type=file]').setInputFiles({ name: 'ritratto.png', mimeType: 'image/png', buffer: picture });
  await page.locator('[data-test=portrait-crop]').waitFor({ timeout: 15000 });
  const frame = await page.locator('[data-test=portrait-crop-frame]').boundingBox();
  await page.mouse.move(frame.x + 128, frame.y + 128);
  await page.mouse.down();
  await page.mouse.move(frame.x + 64, frame.y + 128, { steps: 4 });
  await page.mouse.up();
  await page.locator('[data-test=portrait-crop-zoom]').fill('150');
  const cropStyle = await page.locator('[data-test=portrait-crop-frame]').getAttribute('style');
  await shot(page, 'portrait-crop', '[data-test=portrait-crop]');
  await page.locator('[data-test=portrait-crop-save]').click();
  await page.locator('[data-test=portrait-crop]').waitFor({ state: 'detached', timeout: 15000 });
  const portraitStyle = await page.locator('[data-test=sheet-portrait]').getAttribute('style');
  const portraitSize = await page.evaluate(async (style) => {
    const src = style.match(/url\(["']?(data:[^"')]+)/)[1];
    const img = new Image();
    await new Promise((r) => { img.onload = r; img.src = src; });
    return `${img.naturalWidth}x${img.naturalHeight}`;
  }, portraitStyle ?? '');
  await shot(page, 'sheet-hero', '.rf-hero');
  results.push(`INFO portrait: crop ${cropStyle?.match(/background-position:[^;]+/)?.[0]}, saved ${portraitSize}`);
  if (!/background-position: [0-9]+% 50%/.test(cropStyle ?? '') || /background-position: 50% 50%/.test(cropStyle ?? '') || portraitSize !== '320x320') throw new Error(`portrait crop: ${cropStyle} -> ${portraitSize}`);
  ok('portrait: a new picture opens the crop (drag and zoom), the sheet keeps the 320 px square; inspiration star and label aligned');
  await page.locator('[data-test=sheet-long-rest]').click();
  await page.locator('[data-test=sheet-long-rest-done]').click();
  const afterRest = (await page.locator('[data-test=sheet-hp-current]').innerText()).trim();
  const resourceBack = await page.locator('[data-test=sheet-class-resource-use]:not([disabled])').count();
  if (resourceBack !== 1) throw new Error('the long rest did not give back the class resource');
  ok('class resources: Arcane Recovery listed on its own, spent with "use", recovered by a long rest');
  // Turn summary with the edition's actions; death saving throws rolled by the sheet at 0 hit points
  const turn = (await page.locator('[data-test=sheet-turn]').innerText()).replace(/\s+/g, ' ');
  await shot(page, 'sheet-turn', '[data-test=sheet-turn]');
  // The sheet on a phone: the stats, the hit point controls and the turn
  await page.setViewportSize({ width: 390, height: 844 });
  await page.waitForTimeout(300);
  await shot(page, 'phone-stats', '[data-test=sheet-stats]');
  await shot(page, 'phone-hp', '[data-test=sheet-hp-box]');
  await page.setViewportSize({ width: 1280, height: 900 });
  const damage = async (value) => {
    await page.locator('[data-test=sheet-hp-amount]').fill(String(value));
    await page.locator('[data-test=sheet-hp-amount]').press('Tab');
    await page.locator('[data-test=sheet-damage]').click();
  };
  // Down to exactly 0, then a hit at 0 is a failed death save
  await damage(Number(sheetHp));
  await damage(1);
  const failuresAfterHit = await page.locator('[data-test=sheet-death-saves] .rf-death-box.fail.on').count();
  const hitNote = (await page.locator('[data-test=sheet-death-note]').innerText()).trim();
  await page.locator('[data-test=sheet-death-roll]').click();
  // The result shows on the sheet only after the dice have landed
  const marksWhileRolling = await page.locator('[data-test=sheet-death-saves] .rf-death-box.on').count();
  await page.locator('[data-test=dice-total]').filter({ hasNotText: '…' }).waitFor({ timeout: 5000 });
  await page.waitForTimeout(300);
  if (marksWhileRolling !== 1) throw new Error(`the death save result appeared before the dice landed (${marksWhileRolling} marks)`);
  const deathMarked = await page.locator('[data-test=sheet-death-saves] .rf-death-box.on').count();
  const revived = await page.locator('[data-test=sheet-death-saves]').count() === 0;
  // Damage of at least the maximum at 0 hit points: instant death
  let instantDeath = 'revived';
  if (!revived) {
    await damage(Number(sheetHp));
    instantDeath = (await page.locator('[data-test=sheet-death-note]').innerText()).trim();
  }
  await page.locator('[data-test=sheet-long-rest]').click();
  await page.locator('[data-test=sheet-long-rest-done]').click();
  if (!/Attacco/.test(turn) || !/Magia/.test(turn) || !/Colpo senz'armi/.test(turn) || !/Azione bonus/i.test(turn) || (!revived && deathMarked < 2)) throw new Error(`turn summary or death saves: turn="${turn.slice(0, 200)}" marked=${deathMarked} revived=${revived}`);
  if (failuresAfterHit !== 1 || !/fallimento/i.test(hitNote) || (!revived && !/Morte istantanea/.test(instantDeath))) throw new Error(`damage at 0 hit points: failures=${failuresAfterHit} note="${hitNote}" death="${instantDeath}"`);
  ok('turn summary with the 2024 actions; a hit at 0 HP is a failed death save, the roll marks its result after the dice land, massive damage kills');

  const tabs = {};
  for (const tab of ['spells', 'inventory', 'features', 'notes', 'overview']) {
    await page.locator(`[data-test=sheet-tab-${tab}]`).click();
    await page.waitForTimeout(300);
    characterAudits.push(await overflowOf(page, `sheet ${tab}`));
    if (tab === 'notes') {
      await page.locator('[data-test=sheet-adjustments] summary').click();
      await shot(page, 'sheet-mods', '[data-test=sheet-adjustments]');
    }
    if (tab === 'features') {
      await page.setViewportSize({ width: 390, height: 844 });
      await page.waitForTimeout(300);
      await shot(page, 'phone-resources', '.rf-res-form');
      await page.setViewportSize({ width: 1280, height: 900 });
    }
    if (tab === 'spells') {
      await shot(page, 'sheet-spells', '[data-test=sheet-spellcasting]');
      tabs.spells = await page.locator('[data-test=sheet-spells] a').count();
      // Casting from the spell: its details with the slot choice, the slot is spent and the details close
      const fullBefore = await page.locator('[data-test=sheet-slots] .rf-slot-dot.full').count();
      await page.locator('[data-test=sheet-spells][data-level="1"] a').first().click();
      await page.locator('[data-test=spell-detail-modal]').waitFor({ timeout: 15000 });
      await page.locator('[data-test=spell-cast-slot-1]').click();
      await page.locator('[data-test=spell-detail-modal]').waitFor({ state: 'detached', timeout: 5000 });
      tabs.slots = `${fullBefore}->${await page.locator('[data-test=sheet-slots] .rf-slot-dot.full').count()}`;
      await page.locator('[data-test=sheet-spells] a').first().click();
      await page.locator('[data-test=spell-cast-cantrip]').waitFor({ timeout: 15000 });
      await page.locator('[data-test=spell-detail-close]').click();
      // After the long rest the wizard can change the prepared spells; the spellbook gets the free spells of level 1
      tabs.changes = (await page.locator('[data-test=sheet-book-changes]').first().innerText()).trim();
      await page.locator('[data-test=sheet-book-open]').first().click();
      await page.locator('[data-test=spell-book]').waitFor({ timeout: 5000 });
      await page.locator('[data-test=spell-book-tab-book]').click();
      const freeBefore = await page.locator('[data-test=spell-book-add]').filter({ hasText: 'Scrivi' }).count();
      const addButton = page.locator('[data-test=spell-book-add]').first();
      const addInfo = await addButton.evaluate((el) => `${el.outerHTML.slice(0, 160)} rect=${JSON.stringify(el.getBoundingClientRect())} vh=${innerHeight}`);
      await addButton.click();
      await page.waitForTimeout(300);
      if (await page.locator('[data-test=spell-book]').count() === 0) throw new Error(`the spellbook closed after "write": ${addInfo}`);
      await page.locator('[data-test=spell-book-save]').click();
      await page.locator('[data-test=spell-book]').waitFor({ state: 'detached', timeout: 15000 });
      tabs.spellbook = freeBefore > 0 ? 'written' : 'none';
    }
    if (tab === 'inventory') {
      tabs.items = await page.locator('[data-test=sheet-item]').count();
      // A Ring of Protection from the rules: worn and attuned it adds 1 to AC
      await page.locator('[data-test=sheet-magic-add]').click();
      await page.locator('[data-test=magic-template]').selectOption('ring-of-protection');
      await page.locator('[data-test=magic-save]').click();
      const ring = page.locator('[data-test=sheet-item]', { hasText: 'Anello di Protezione' });
      // The dice tray of the earlier rolls floats over the bottom of the page: closed first
      if (await page.locator('[data-test=sheet-last-roll]').count() > 0) await page.locator('[data-test=sheet-last-roll] .rf-dice-tray-close').click();
      await ring.locator('[data-test=sheet-item-equip]').click();
      await page.locator('[data-test=sheet-item]', { hasText: 'Anello di Protezione' }).locator('[data-test=sheet-item-attune]').click();
      tabs.ringAc = (await page.locator('[data-test=sheet-ac]').innerText()).trim();
      tabs.attunement = (await page.locator('[data-test=sheet-attunement]').innerText()).trim();
    }
  }
  // Sharing the character: the dialog adds people by e-mail and says when no account has that address
  await page.locator('[data-test=sheet-share]').click();
  await page.locator('[data-test=sheet-share-dialog] [data-test=share-email]').fill('nobody@example.com');
  await page.locator('[data-test=sheet-share-dialog] [data-test=share-add]').click();
  const shareError = (await page.locator('[data-test=sheet-share-dialog] [data-test=share-error]').innerText({ timeout: 15000 })).trim();
  await page.locator('[data-test=sheet-share-dialog] button', { hasText: /chiudi/i }).click();
  if (!/Nessun account/.test(shareError)) throw new Error(`sharing with an unknown address: "${shareError}"`);
  ok('character sharing: the dialog adds people by e-mail and explains an unknown address');
  const sheetUrl = page.url();
  // Monsters: 441 statblocks of 2014 grouped by type, type filter, the Goblin's statblock, a Homebrew variant made from it (then deleted)
  await page.goto(`${base}/monsters`);
  await page.locator('[data-test=monster-group]').first().waitFor({ timeout: 60000 });
  const monsterCount = async (expected) => {
    for (let i = 0; i < 100 && (await page.locator('[data-test=monster-count]').innerText()).trim() !== expected; i++) await page.waitForTimeout(100);
    return (await page.locator('[data-test=monster-count]').innerText()).trim();
  };
  const monsterUi = { all: await monsterCount('441 mostri') };
  await pickOption('monster-type', 'Drago');
  monsterUi.dragons = await monsterCount('46 mostri');
  await pickOption('monster-type', 'Tutti i tipi');
  await page.locator('[data-test=monster-search]').fill('goblin');
  monsterUi.goblins = await monsterCount('7 mostri');
  await shot(page, 'monsters-goblins', 'main');
  await page.locator('[data-test=monster-card]').filter({ has: page.locator('.rf-card-title', { hasText: /^Goblin$/ }) }).click();
  await page.locator('[data-test=monster-statblock]').waitFor({ timeout: 15000 });
  const goblinBlock = (await page.locator('[data-test=monster-statblock]').innerText()).replace(/\s+/g, ' ');
  monsterUi.statblock = ['Classe Armatura 15 (armatura di cuoio, scudo)', 'Punti Ferita 7 (2d6)', 'Sfida 1/4 (50 PE)', 'Fuga agile'].filter((t) => goblinBlock.includes(t)).length;
  await page.locator('[data-test=monster-variant]').click();
  await page.locator('[data-test=monster-form]').waitFor({ timeout: 15000 });
  await page.locator('[data-test=monster-form-hp]').fill('12');
  await page.locator('[data-test=monster-form-save]').click();
  await page.locator('[data-test=monster-detail-name]', { hasText: 'Goblin (variante)' }).waitFor({ timeout: 15000 });
  monsterUi.variantOf = (await page.locator('[data-test=monster-variant-of]').innerText()).trim();
  monsterUi.variantHp = (await page.locator('[data-test=monster-statblock]').innerText()).includes('Punti Ferita 12');
  await page.locator('[data-test=monster-delete]').click();
  await page.locator('[data-test=monster-delete-yes]').click();
  await page.locator('[data-test=monster-detail]').waitFor({ state: 'detached', timeout: 15000 });
  results.push(`INFO monsters: ${JSON.stringify(monsterUi)}`);
  if (monsterUi.all !== '441 mostri' || monsterUi.dragons !== '46 mostri' || monsterUi.goblins !== '7 mostri' || monsterUi.statblock !== 4
    || !/Goblin/.test(monsterUi.variantOf) || !monsterUi.variantHp) throw new Error(`unexpected monsters page: ${JSON.stringify(monsterUi)}`);
  ok('monsters: 441 statblocks of 2014, 46 dragons, 7 goblinoids, the Goblin statblock, a Homebrew variant with its own hit points (then deleted)');
  // Homebrew magic item: a new wondrous item with a rule the sheet applies (+1 AC), its detail, then deleted
  await page.goto(`${base}/magic-items`);
  await page.locator('[data-test=magic-group]').first().waitFor({ timeout: 60000 });
  await page.locator('[data-test=magic-new]').click();
  await page.locator('[data-test=magic-form]').waitFor({ timeout: 15000 });
  await page.locator('[data-test=magic-form-name]').fill('Amuleto di prova');
  await page.locator('[data-test=magic-form-subtitle]').fill('Oggetto meraviglioso, non comune');
  await page.locator('[data-test=magic-form-description]').fill('Un amuleto che **protegge** chi lo indossa.');
  await page.locator('[data-test=magic-add-effect]').click();
  await shot(page, 'magic-form', '[data-test=magic-form]');
  await page.locator('[data-test=magic-form-save]').click();
  await page.locator('[data-test=magic-detail-name]', { hasText: 'Amuleto di prova' }).waitFor({ timeout: 15000 });
  const magicUi = {
    onSheet: (await page.locator('[data-test=magic-on-sheet]').innerText()).trim(),
    text: (await page.locator('[data-test=magic-description]').innerText()).trim(),
    edit: await page.locator('[data-test=magic-edit]').count()
  };
  await shot(page, 'magic-homebrew', '[data-test=magic-detail]');
  await page.locator('[data-test=magic-delete]').click();
  await page.locator('[data-test=magic-delete-yes]').click();
  await page.locator('[data-test=magic-detail]').waitFor({ state: 'detached', timeout: 15000 });
  results.push(`INFO magic homebrew: ${JSON.stringify(magicUi)}`);
  if (!/\+1/.test(magicUi.onSheet) || !/protegge/.test(magicUi.text) || magicUi.edit !== 1) throw new Error(`unexpected Homebrew magic item: ${JSON.stringify(magicUi)}`);
  ok('magic items: a Homebrew wondrous item with +1 AC applied by the sheet, its detail, then deleted');
  // Campaigns: a new campaign makes its creator the master, with the invite link; the character joins the table
  await page.goto(`${base}/campaigns`);
  await page.locator('[data-test=campaign-new]').click();
  await page.locator('[data-test=campaign-name]').fill('Tavola di prova');
  await page.locator('[data-test=campaign-create]').click();
  await page.locator('[data-test=campaign-title]', { hasText: 'Tavola di prova' }).waitFor({ timeout: 30000 });
  const campaignUrl = page.url();
  const campaignUi = {
    role: (await page.locator('[data-test=campaign-role]').innerText()).trim(),
    link: (await page.locator('[data-test=campaign-link-url]').inputValue()).includes('/campaigns/join/'),
  };
  await page.locator('[data-test=campaign-tab-characters]').click();
  await pickOption('campaign-bring-select', 'Eroe di prova');
  await page.locator('[data-test=campaign-bring-add]').click();
  await page.locator('[data-test=campaign-character]', { hasText: 'Eroe di prova' }).waitFor({ timeout: 15000 });
  await shot(page, 'campaign-characters', '[data-test=campaign-characters]');
  // The whole card opens the sheet (no "open" button), taking out is a small action on it
  campaignUi.cardButtons = await page.locator('[data-test=campaign-character] .btn').count();
  await page.locator('[data-test=campaign-character]').click({ position: { x: 24, y: 64 } });
  await page.waitForURL(/\/characters\/[0-9a-f-]+$/, { timeout: 15000 });
  campaignUi.cardOpens = true;
  // The list of characters shows the campaign on the card, with edit and delete
  await page.goto(`${base}/characters`);
  await page.locator('[data-test=character-campaign]', { hasText: 'Tavola di prova' }).waitFor({ timeout: 30000 });
  campaignUi.listActions = await page.locator('[data-test=character-card]', { hasText: 'Eroe di prova' }).locator('[data-test=character-edit], [data-test=character-delete]').count();
  await shot(page, 'characters-list', '[data-test=characters-grid]');
  // Deactivated, the character stays at the table marked as inactive; activated again for the encounter
  await page.goto(campaignUrl);
  await page.locator('[data-test=campaign-title]').waitFor({ timeout: 30000 });
  await page.locator('[data-test=campaign-tab-characters]').click();
  await page.locator('[data-test=campaign-character-active]').click();
  await page.locator('[data-test=campaign-character-inactive]').waitFor({ timeout: 15000 });
  await shot(page, 'campaign-characters-inactive', '[data-test=campaign-characters]');
  await page.locator('[data-test=campaign-character-active]').click();
  await page.locator('[data-test=campaign-character-inactive]').waitFor({ state: 'detached', timeout: 15000 });
  campaignUi.toggled = true;
  await page.locator('[data-test=campaign-tab-content]').click();
  campaignUi.share = await page.locator('[data-test=campaign-share]').count();
  // The shared journal: a page written by the master
  await page.locator('[data-test=campaign-tab-notes]').click();
  await page.locator('[data-test=campaign-note-new]').click();
  await page.locator('[data-test=campaign-note-title]').fill('Sessione 1');
  await page.locator('[data-test=campaign-note-body]').fill('Il gruppo parte da Valdoras.');
  await page.locator('[data-test=campaign-note-save]').click();
  await page.locator('[data-test=campaign-note]', { hasText: 'Sessione 1' }).waitFor({ timeout: 15000 });
  campaignUi.notes = await page.locator('[data-test=campaign-note]').count();
  campaignUi.noteKinds = (await page.locator('[data-test=campaign-notes-kinds] .rf-pill-btn').allInnerTexts()).map((t) => t.trim()).join(',');
  await shot(page, 'campaign-notes', 'main');
  // An encounter: three goblins and the party, its difficulty, the fight starts and the turn moves on
  await page.locator('[data-test=campaign-tab-encounters]').click();
  await page.locator('[data-test=encounter-new-name]').fill('Imboscata');
  await page.locator('[data-test=encounter-new-create]').click();
  await page.locator('[data-test=encounter-monster-search]').waitFor({ timeout: 15000 });
  await page.locator('[data-test=encounter-monster-search]').fill('goblin');
  const goblinPick = page.locator('.rf-monster-pick').filter({ has: page.locator('.rf-monster-pick-name', { hasText: /^Goblin$/ }) });
  await goblinPick.waitFor({ timeout: 30000 });
  await goblinPick.locator('input').fill('3');
  await goblinPick.locator('[data-test=encounter-monster-add]').click();
  await page.locator('[data-test=encounter-combatant]').nth(2).waitFor({ timeout: 15000 });
  await page.locator('[data-test=encounter-add-party]').click();
  // The names are in inputs (the master can rename them): the party arrives as a fourth combatant
  await page.locator('[data-test=encounter-combatant]').nth(3).waitFor({ timeout: 15000 });
  campaignUi.combatants = await page.locator('[data-test=encounter-combatant]').count();
  const combatantNames = await page.locator('[data-test=combatant-name]').evaluateAll((els) => els.map((e) => e.value));
  campaignUi.goblins = combatantNames.filter((n) => /^Goblin [123]$/.test(n)).length;
  campaignUi.hero = combatantNames.includes('Eroe di prova');
  for (let i = 0; i < 50 && await page.locator('[data-test=combatant-sheet]').count() === 0; i++) await page.waitForTimeout(100);
  campaignUi.sheetLink = await page.locator('[data-test=combatant-sheet]').count();
  campaignUi.rating = (await page.locator('[data-test=encounter-rating]').innerText()).trim();
  await page.locator('[data-test=encounter-start]').click();
  await page.locator('[data-test=encounter-round]', { hasText: 'Round 1' }).waitFor({ timeout: 15000 });
  for (let i = 0; i < 4; i++) await page.locator('[data-test=encounter-next]').click();
  await page.locator('[data-test=encounter-round]', { hasText: 'Round 2' }).waitFor({ timeout: 15000 });
  campaignUi.current = await page.locator('.rf-combatant.current').count();
  // Sessions: the master plans the next one (date, plan, notes behind the screen); the overview shows it
  await page.locator('[data-test=campaign-tab-sessions]').click();
  await page.locator('[data-test=session-new]').click();
  await page.locator('[data-test=session-title]').fill('La cripta');
  const sessionDay = new Date(Date.now() + 3 * 86400000);
  const pad = (n) => String(n).padStart(2, '0');
  await page.locator('[data-test=session-when]').fill(`${sessionDay.getFullYear()}-${pad(sessionDay.getMonth() + 1)}-${pad(sessionDay.getDate())}T21:00`);
  await page.locator('[data-test=session-plan]').fill('Portate i dadi e la mappa.');
  await page.locator('[data-test=session-master-notes]').fill('Il lich è il sindaco.');
  await page.locator('[data-test=session-save]').click();
  await page.locator('[data-test=session]', { hasText: 'La cripta' }).waitFor({ timeout: 15000 });
  campaignUi.session = (await page.locator('[data-test=session]').first().innerText()).replace(/\s+/g, ' ').trim();
  await shot(page, 'campaign-sessions', 'main');
  // The shared dice table: a roll of the roller, then one made on the sheet of the character at the table
  await page.locator('[data-test=campaign-tab-rolls]').click();
  await page.locator('[data-test=roll-expression]').fill('2d6+3');
  await page.locator('[data-test=roll-label]').fill('Danni della spada');
  await page.locator('[data-test=roll-go]').click();
  await page.locator('[data-test=roll]', { hasText: 'Danni della spada' }).waitFor({ timeout: 15000 });
  await page.goto(sheetUrl);
  await page.locator('[data-test=sheet-initiative]').click();
  campaignUi.sheetShared = await page.locator('[data-test=dice-shared]').count();
  await page.waitForTimeout(1500);
  await page.goto(campaignUrl);
  await page.locator('[data-test=campaign-title]').waitFor({ timeout: 30000 });
  campaignUi.nextSession = (await page.locator('[data-test=campaign-next-session]').innerText()).replace(/\s+/g, ' ').trim();
  await shot(page, 'campaign-next-session', '[data-test=campaign-next-session]');
  await page.locator('[data-test=campaign-tab-rolls]').click();
  await page.locator('[data-test=roll]', { hasText: 'Iniziativa' }).waitFor({ timeout: 15000 });
  campaignUi.rolls = (await page.locator('[data-test=roll] [data-test=roll-label-text]').allInnerTexts()).join(',');
  campaignUi.rollers = (await page.locator('[data-test=roll-roller]').allInnerTexts()).join(',');
  campaignUi.rollerColors = await page.locator('[data-test=roll-roller]').evaluateAll((els) => els.map((e) => getComputedStyle(e).color).join('|'));
  await shot(page, 'campaign-rolls', 'main');
  await page.setViewportSize({ width: 390, height: 844 });
  await page.waitForTimeout(300);
  await shot(page, 'phone-campaign-rolls', 'main');
  await page.setViewportSize({ width: 1280, height: 900 });
  // From the sheet, the owner takes the character out of the campaign
  await page.goto(sheetUrl);
  await page.locator('[data-test=sheet-campaign]').click();
  await page.locator('[data-test=sheet-campaign-leave]').click();
  await page.locator('[data-test=sheet-campaign-note]', { hasText: 'ha lasciato' }).waitFor({ timeout: 15000 });
  campaignUi.leftFromSheet = await page.locator('[data-test=sheet-campaign-bring]').count();
  await page.goto(campaignUrl);
  await page.locator('[data-test=campaign-title]').waitFor({ timeout: 30000 });
  await page.locator('[data-test=campaign-tab-characters]').click();
  await page.locator('[data-test=campaign-characters-empty]').waitFor({ timeout: 15000 });
  await page.locator('[data-test=campaign-tab-overview]').click();
  await page.locator('[data-test=campaign-delete]').click();
  await page.locator('[data-test=campaign-confirm-yes]').click();
  await page.waitForURL(/\/campaigns$/, { timeout: 15000 });
  // The bin: the deleted campaign is there, restored it opens again; deleted again, it is purged for good
  await page.goto(`${base}/account`);
  await page.locator('[data-test=account-trash-open]').click();
  const binRow = page.locator('[data-test=trash-entry]', { hasText: 'Tavola di prova' });
  await binRow.waitFor({ timeout: 30000 });
  campaignUi.binKind = (await binRow.locator('.rf-trash-kind').innerText()).trim();
  await shot(page, 'trash', 'main');
  await binRow.locator('[data-test=trash-restore]').click();
  await page.locator('[data-test=trash-message]', { hasText: 'ripristinato' }).waitFor({ timeout: 15000 });
  await page.locator('[data-test=trash-message] a').click();
  await page.locator('[data-test=campaign-title]', { hasText: 'Tavola di prova' }).waitFor({ timeout: 30000 });
  campaignUi.restored = true;
  await page.locator('[data-test=campaign-delete]').click();
  await page.locator('[data-test=campaign-confirm-yes]').click();
  await page.waitForURL(/\/campaigns$/, { timeout: 15000 });
  await page.goto(`${base}/trash`);
  await binRow.waitFor({ timeout: 30000 });
  await binRow.locator('[data-test=trash-purge]').click();
  await binRow.locator('[data-test=trash-purge-confirm]').click();
  await binRow.waitFor({ state: 'detached', timeout: 15000 });
  campaignUi.purged = true;
  results.push(`INFO campaign: ${JSON.stringify(campaignUi)}`);
  if (campaignUi.role !== 'Master' || !campaignUi.link || campaignUi.share !== 1 || campaignUi.notes !== 1
    || campaignUi.combatants !== 4 || campaignUi.goblins !== 3 || !campaignUi.hero || campaignUi.sheetLink !== 1 || !/^(Facile|Medio|Difficile|Mortale)$/.test(campaignUi.rating) || campaignUi.current !== 1
    || campaignUi.binKind !== 'CAMPAGNA' || !campaignUi.restored || !campaignUi.purged
    || campaignUi.cardButtons !== 0 || !campaignUi.cardOpens || campaignUi.listActions !== 2 || !campaignUi.toggled || campaignUi.noteKinds !== 'Diario di viaggio,Personali,Per i master' || campaignUi.leftFromSheet !== 1
    || !/Prossima sessione/i.test(campaignUi.session) || !/tra 3 giorni/.test(campaignUi.session) || !/Il lich/.test(campaignUi.session)
    || !/Sessione 1/i.test(campaignUi.nextSession) || !/21:00/.test(campaignUi.nextSession) || campaignUi.sheetShared !== 1
    || campaignUi.rolls !== 'Iniziativa,Danni della spada' || campaignUi.rollers !== 'Eroe di prova,Master') throw new Error(`unexpected campaign page: ${JSON.stringify(campaignUi)}`);
  ok('campaigns: the creator is the master with an invite link, the character joins the table (the whole card opens the sheet, deactivated and activated again; its card in the list shows the campaign), a journal page, an encounter with three goblins run to round 2, the character leaves from its sheet, the campaign is deleted, restored from the bin, deleted again and purged');
  await page.goto(sheetUrl);
  await page.locator('[data-test=character-sheet]').waitFor({ timeout: 30000 });
  const [download] = await Promise.all([page.waitForEvent('download', { timeout: 20000 }), page.locator('[data-test=sheet-pdf]').click()]);
  const pdfPath = await download.path();
  const pdfHead = readFileSync(pdfPath).subarray(0, 8).toString('latin1');
  const pdfSize = readFileSync(pdfPath).length;
  copyFileSync(pdfPath, 'shots/character.pdf');

  // Level up into fighter (multiclass): Fighting Style feat and three Weapon Masteries
  await page.locator('[data-test=sheet-levelup]').click();
  await wizardStep('progression');
  await choose('wizard-level-class', /^Guerriero/);
  await page.locator('[data-test=wizard-fighting-style]').waitFor({ timeout: 15000 });
  await nextOption('wizard-fighting-style');
  await pickFree('[data-test=wizard-mastery]', 3);
  for (let guard = 0; guard < 6 && await page.locator('[data-test=wizard-forge]').count() === 0; guard++) await next();
  await page.locator('[data-test=wizard-forge]').click();
  await page.locator('[data-test=character-sheet]').waitFor({ timeout: 30000 });
  const classes = (await page.locator('[data-test=sheet-classes]').innerText()).replace(/\s+/g, ' ').trim();
  const levelUpHp = (await page.locator('[data-test=sheet-hp]').innerText()).trim();
  await page.goto(`${base}/characters`);
  const characterCard = (await page.locator('[data-test=character-card]', { hasText: 'Eroe di prova' }).innerText({ timeout: 30000 })).replace(/\s+/g, ' ');
  await page.setViewportSize({ width: 1280, height: 720 });

  results.push(`INFO character: steps 2014="${step2014}" 2024="${step2024}" | spells=${chosenSpells} | AC preview=${previewAc} summary=${summaryAc} sheet=${sheetAc} | HP summary=${summaryHp} sheet=${sheetHp} after 3 damage and reload=${afterReload} after long rest=${afterRest} | tabs=${JSON.stringify(tabs)} | pdf=${pdfHead.trim()} ${pdfSize} bytes | level up: ${classes} HP=${levelUpHp} | card: ${characterCard}`);
  if (!/razza/i.test(step2014) || !/classe/i.test(step2024)) throw new Error('the wizard steps do not follow the edition');
  if (!/Scurovisione 36 m/.test(sheetSenses)) throw new Error(`dwarf darkvision missing on the sheet: ${sheetSenses}`);
  if (sheetName !== 'Eroe di prova' || sheetAc !== summaryAc || sheetHp !== summaryHp || previewAc !== summaryAc) throw new Error('the saved character does not match the wizard');
  if (Number(afterReload) !== Number(sheetHp) - 3 || afterRest !== sheetHp) throw new Error('damage or rest not applied and saved');
  if (tabs.spells !== chosenSpells || tabs.items < 4) throw new Error('spells or inventory missing on the sheet');
  if (tabs.slots !== '2->1') throw new Error(`"use" did not spend a spell slot: ${tabs.slots}`);
  if (!/cambiare tutti/.test(tabs.changes) || tabs.spellbook !== 'written') throw new Error(`spell changes after a long rest: "${tabs.changes}" spellbook=${tabs.spellbook}`);
  if (Number(tabs.ringAc) !== Number(sheetAc) + 1 || !/1\/3/.test(tabs.attunement)) throw new Error(`Ring of Protection: AC ${tabs.ringAc} (was ${sheetAc}), ${tabs.attunement}`);
  ok('magic items: a Ring of Protection worn and attuned adds 1 to AC (attunement 1/3); spells: the long rest opens the changes, the spellbook writes a free spell');
  if (!pdfHead.startsWith('%PDF') || pdfSize < 2000) throw new Error('the PDF download is not a PDF');
  if (!/Mago 1/.test(classes) || !/Guerriero 1/.test(classes) || Number(levelUpHp) <= Number(sheetHp)) throw new Error('the level up into fighter was not saved');
  if (!/Mago 1 \/ Guerriero 1/.test(characterCard)) throw new Error(`the list does not show the classes: ${characterCard}`);
  ok('characters: edition-specific steps, 2024 wizard to the end, sheet matches the summary, damage autosaved, long rest, tabs, PDF download, level up into a second class');

  // Rule modules: "Fortuna" written in the effects editor (an ability worth 10 in the array, its points coming back on a
  // long rest), picked for the character in the wizard: a seventh card in the abilities step and on the sheet
  await page.goto(`${base}/modules`);
  await page.locator('[data-test=module-add]').click();
  await page.locator('[data-test=module-editor]').waitFor({ timeout: 30000 });
  await page.locator('[data-test=module-name-it]').fill('Fortuna');
  await page.locator('[data-test=module-name-en]').fill('Luck');
  const effectRows = page.locator('[data-test=effect-row]');
  const pickKind = async (row, label) => {
    await row.locator('[data-test=effect-kind] .rf-custom-select-trigger').click();
    await row.locator('.rf-custom-select-option', { hasText: label }).first().click();
  };
  const typeIn = async (locator, text) => { await locator.fill(text); await locator.press('Tab'); };
  await page.locator('[data-test=effect-add]').click();
  await pickKind(effectRows.nth(0), 'Una caratteristica in più');
  await typeIn(effectRows.nth(0).locator('[data-test=effect-name-it]'), 'Fortuna');
  await typeIn(effectRows.nth(0).locator('[data-test=effect-name-en]'), 'Luck');
  await typeIn(effectRows.nth(0).locator('[data-test=effect-short-it]'), 'FRT');
  await page.locator('[data-test=effect-add]').click();
  await pickKind(effectRows.nth(1), 'Una risorsa con usi');
  await typeIn(effectRows.nth(1).locator('[data-test=effect-name-it]'), 'Punti Fortuna');
  const modulePreviews = await page.locator('[data-test=effect-preview]').allInnerTexts();
  await shot(page, 'module-editor', '[data-test=module-editor]');
  await page.locator('[data-test=module-save]').click();
  await page.locator('[data-test=module-card]', { hasText: 'Fortuna' }).click({ timeout: 30000 });
  await page.locator('[data-test=module-effects]').waitFor({ timeout: 15000 });
  const moduleEffects = (await page.locator('[data-test=module-effects]').innerText()).replace(/\s+/g, ' ').trim();
  await shot(page, 'module-detail', '[data-test=module-detail]');
  await page.goto(`${sheetUrl}/edit`);
  await page.locator('[data-test=wizard-module]', { hasText: 'Fortuna' }).click({ timeout: 60000 });
  for (let guard = 0; guard < 10 && await page.locator('[data-test=wizard-step-abilities]').count() === 0; guard++) await next();
  await page.locator('[data-test=wizard-stat-6]').waitFor({ timeout: 15000 });
  const fortunaPool = (await page.locator('[data-test=wizard-pool-die]').allInnerTexts()).join(',');
  await page.locator('[data-test=wizard-pool-die]').first().click();
  await page.locator('[data-test=wizard-stat-6] [data-test=wizard-assign]').click();
  const fortunaWizard = (await page.locator('[data-test=wizard-stat-6]').innerText()).replace(/\s+/g, ' ').trim();
  await shot(page, 'module-wizard', '[data-test=wizard-stats]');
  for (let guard = 0; guard < 10 && await page.locator('[data-test=wizard-forge]').count() === 0; guard++) await next();
  await page.locator('[data-test=wizard-forge]').click();
  await page.locator('[data-test=character-sheet]').waitFor({ timeout: 30000 });
  await page.locator('[data-test=sheet-extra-ability]').waitFor({ timeout: 15000 });
  const fortunaSheet = (await page.locator('[data-test=sheet-extra-ability]').innerText()).replace(/\s+/g, ' ').trim();
  const sheetModules = (await page.locator('[data-test=sheet-modules]').innerText()).replace(/\s+/g, ' ').trim();
  await shot(page, 'module-sheet', '[data-test=sheet-scores]');
  results.push(`INFO modules: previews=${JSON.stringify(modulePreviews)} detail="${moduleEffects}" pool=${fortunaPool} wizard="${fortunaWizard}" sheet="${fortunaSheet}" modules="${sheetModules}"`);
  if (!/Fortuna \(FRT\)/.test(modulePreviews[0] ?? '') || !/Punti Fortuna, 3 usi/.test(modulePreviews[1] ?? '') || !/riposo lungo/.test(moduleEffects)
    || fortunaPool !== '10' || !/fortuna/i.test(fortunaWizard) || !/10/.test(fortunaWizard) || !/fortuna/i.test(fortunaSheet) || !/\+0/.test(fortunaSheet) || !/fortuna/i.test(sheetModules)) {
    throw new Error('unexpected rule module flow');
  }
  ok('rule modules: Fortuna written in the effects editor (ability + resource), picked in the wizard, joins the array as a seventh value and shows next to the six on the sheet');
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
  const linkColor = await page.locator('[data-test=forgot-password-link]').evaluate(el => getComputedStyle(el).color);
  if (linkColor !== 'rgb(255, 140, 0)') throw new Error(`links should use the forge orange, "Password dimenticata?" is ${linkColor}`);
  ok('links use the forge orange instead of the Bootstrap blue');
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

  // Phone layout (375 px): no page or detail may be wider than the screen. Wide tables may scroll inside their own box,
  // anything else that sticks out of the window is reported with its class
  const phone = await browser.newContext({ viewport: { width: 375, height: 812 }, isMobile: true, hasTouch: true });
  const mobile = await phone.newPage();
  const overflow = (label) => overflowOf(mobile, label);
  const audits = [];
  const audit = async (path, ready, open) => {
    await mobile.goto(`${base}${path}`);
    await mobile.locator(ready).first().waitFor({ timeout: 60000 });
    await mobile.waitForTimeout(800);
    const expand = mobile.locator('[data-test$=expand-all]');
    if (await expand.count()) await expand.first().click();
    audits.push(await overflow(path));
    if (open) {
      await open();
      await mobile.locator('.rf-modal-dialog').first().waitFor({ timeout: 15000 });
      await mobile.waitForTimeout(500);
      audits.push(await overflow(`${path} detail`));
    }
  };
  await audit('/', '[data-test=home-intro]');
  await audit('/rules', '[data-test=rules-group]', () => mobile.locator('[data-test=rules-tile]').first().click());
  await audit('/species', '.rf-card', () => mobile.locator('.rf-card').first().click());
  await audit('/backgrounds', '.rf-card', () => mobile.locator('.rf-card').first().click());
  await audit('/feats', '[data-test=feat-group]', () => mobile.locator('.rf-card').first().click());
  await audit('/spells', '[data-test=spell-level-group]', () => mobile.locator('[data-test=spell-card]').first().click());
  await audit('/classes', '[data-test=class-card]', () => mobile.locator('[data-test=class-card]').first().click());
  await audit('/equipment', '[data-test=equipment-group]', () => mobile.locator('[data-test=equipment-row]').first().click());
  await audit('/account', 'input[type=email]');
  await phone.close();
  const wide = [...characterAudits, ...audits].filter(Boolean);
  results.push(`INFO phone layout: ${wide.length ? wide.join(' | ') : 'every page and detail fits 375 px'}`);
  if (wide.length) throw new Error(`content wider than a 375 px phone: ${wide.join(' | ').slice(0, 300)}`);
  ok('phone layout: dashboard, characters (list, every wizard step, sheet), glossary, species, backgrounds, feats, spells, classes, equipment and account (with their details) fit a 375 px screen');
} catch (e) {
  results.push(`FAIL ${e.message.split('\n').filter(Boolean).slice(0, 8).join(' | ').slice(0, 1500)}`);
  const lastOk = results.filter((r) => r.startsWith('OK')).at(-1) ?? '';
  const where = await page.evaluate(() => `${location.pathname}${location.search} step="${document.querySelector('[data-test=wizard-step-title]')?.textContent?.trim() ?? ''}" problems="${document.querySelector('[data-test=wizard-error]')?.textContent?.replace(/\s+/g, ' ').trim() ?? ''}"`).catch(() => 'n/a');
  results.push(`DEBUG after "${lastOk.slice(3, 120)}" at ${where}`);
  results.push(`DEBUG last console messages: ${consoleErrors.slice(-4).map((c) => c.replace(/\s+/g, ' ').slice(0, 400)).join(' || ')}`);
  const stored = await page.evaluate(() => localStorage.getItem('realmforge.auth')).catch(() => 'n/a');
  results.push(`DEBUG localStorage=${stored ? stored.slice(0, 60) : stored}`);
  results.push(`DEBUG auth calls: ${authCalls.join(' | ')}`);
  await page.screenshot({ path: 'ui-failure.png', fullPage: true });
} finally {
  // GitHub shows at most 10 annotations per step: one line per result in the log, one summary annotation
  for (const r of results) console.log(r);
  console.log(`::notice title=ui::${results.filter((r) => r.startsWith('OK')).length} checks passed — ${results.join(' · ')}`);
  for (const r of results.filter((r) => r.startsWith('INFO phone'))) console.log(`::notice title=phone::${r.slice(0, 4000)}`);
  for (const r of results.filter((r) => r.startsWith('INFO character'))) console.log(`::notice title=character::${r.slice(0, 2000)}`);
  for (const r of results.filter((r) => r.startsWith('FAIL') || r.startsWith('DEBUG'))) console.log(`::error title=ui-fail::${r.slice(0, 2000)}`);
  for (const c of consoleErrors.slice(0, 5)) console.log(`::warning title=ui-console::${c.slice(0, 200)}`);
  await browser.close();
  if (results.some((r) => r.startsWith('FAIL'))) process.exit(1);
}
