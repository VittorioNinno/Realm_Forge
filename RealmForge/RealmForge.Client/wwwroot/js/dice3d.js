// RealmForge 3D dice: real dice thrown across the screen (three.js and cannon-es physics, the dice-box-threejs
// library) that land on the faces the app already decided. The roll is never decided here: the dice only show it.
// The library is prepared while the page is idle, so the first roll does not wait for it; without WebGL, with
// reduced motion asked or switched off by the reader, the app keeps its flat animation.
//
// The look of the dice: resin, in a colour of the palette or any colour (RGB), for everyone; and special dice
// unlocked with a code (an easter egg, checked by the server), each with its own material, texture and effects.
window.rfDice3d = (() => {
    const key = 'rf-dice3d';
    const sides = new Set([4, 6, 8, 10, 12, 20, 100]);

    // The palette of resin: bright enough to read on the dark pages, numbers in a contrasting ink
    const colors = {
        forge: { background: '#ff8c00', foreground: '#141414', outline: '#7a4300' },
        ivory: { background: '#efe6d2', foreground: '#2a2117', outline: '#b9ab8c' },
        graphite: { background: '#4a4a52', foreground: '#ffb347', outline: '#1c1c20' },
        ruby: { background: '#c0262d', foreground: '#fff4dc', outline: '#4d0a0d' },
        emerald: { background: '#1f9d61', foreground: '#fff4dc', outline: '#0a3a23' },
        sapphire: { background: '#2f6fe0', foreground: '#fff4dc', outline: '#0d2659' },
        amethyst: { background: '#8e4fd6', foreground: '#fff4dc', outline: '#32125a' },
        teal: { background: '#13a3a8', foreground: '#06292a', outline: '#063d3f' }
    };
    // Earlier names of the palette, kept for the settings saved before
    const renamed = { obsidian: 'graphite' };

    // The special dice: their own colours, a texture painted here (no image files), a material and the effects of the
    // throw (the particle look of rfFx while they roll and where they land)
    const specials = {
        ember: { foreground: '#fff0b8', outline: '#3a0c00', background: '#5a1a08', material: 'metal', trail: 'fire', land: 'fire', glow: '#ff6a10', glowIntensity: 0.85 },
        stardust: { foreground: '#ffffff', outline: '#1b0f4a', background: '#1d1a5a', material: 'glass', trail: 'stardust', land: 'stardust', glow: '#8f7dff', glowIntensity: 0.55 }
    };

    let unlocked = new Set();
    let box = null, boxSound = null, look = null, layer = null, loading = null, hideTimer = null, queue = Promise.resolve();
    const textures = {};

    function hexColor(value) {
        return /^#[0-9a-f]{6}$/i.test(value || '') ? value.toLowerCase() : null;
    }

    function read() {
        let s = {};
        try { s = JSON.parse(localStorage.getItem(key) || '{}') || {}; } catch { s = {}; }
        const color = renamed[s.color] || s.color;
        const skin = specials[s.skin] && unlocked.has(s.skin) ? s.skin : 'resin';
        return {
            enabled: s.enabled !== false,
            skin,
            color: colors[color] ? color : hexColor(color) || 'forge',
            sound: s.sound !== false,
            others: s.others !== false
        };
    }

    // The ink and outline that read on a colour chosen freely
    function inkFor(hex) {
        const n = parseInt(hex.slice(1), 16), r = n >> 16, g = (n >> 8) & 255, b = n & 255;
        const light = (0.299 * r + 0.587 * g + 0.114 * b) / 255 > 0.55;
        return { foreground: light ? '#141414' : '#fff4dc', outline: light ? '#3a3a3a' : '#000000' };
    }

    // A resin colour set: a colour of the palette, or of the reader, or of a player at the table
    function resin(color) {
        const preset = colors[color];
        if (preset) return { name: `rf-resin-${color}`, ...preset };
        const hex = hexColor(color) || colors.forge.background;
        return { name: `rf-resin-${hex.slice(1)}`, background: hex, ...inkFor(hex) };
    }

    // ----- Textures of the special dice, painted on a canvas -----

    function canvas(size) {
        const c = document.createElement('canvas');
        c.width = c.height = size;
        return c;
    }

    function rnd(seed) {
        let s = seed >>> 0;
        return () => (s = (s * 1664525 + 1013904223) >>> 0) / 4294967296;
    }

    // Ember: dark basalt split by glowing cracks of lava
    function emberTexture() {
        const size = 256, c = canvas(size), g = c.getContext('2d'), r = rnd(7);
        const base = g.createRadialGradient(size / 2, size / 2, 20, size / 2, size / 2, size * 0.75);
        base.addColorStop(0, '#7a2a0c');
        base.addColorStop(1, '#3a0e04');
        g.fillStyle = base;
        g.fillRect(0, 0, size, size);
        for (let i = 0; i < 400; i++) {
            g.fillStyle = `rgba(0,0,0,${0.15 + r() * 0.25})`;
            g.fillRect(r() * size, r() * size, 2, 2);
        }
        const bump = canvas(size), bg = bump.getContext('2d');
        bg.fillStyle = '#ffffff';
        bg.fillRect(0, 0, size, size);
        for (let k = 0; k < 9; k++) {
            let x = r() * size, y = r() * size;
            const path = [[x, y]];
            for (let s = 0; s < 7; s++) {
                x += (r() - 0.5) * 70;
                y += (r() - 0.5) * 70;
                path.push([x, y]);
            }
            for (const [width, color, blur] of [[11, 'rgba(255,90,0,0.45)', 16], [4.5, '#ff8a2a', 8], [1.8, '#ffe9a0', 3]]) {
                g.save();
                g.strokeStyle = color;
                g.lineWidth = width;
                g.shadowColor = '#ff5a00';
                g.shadowBlur = blur;
                g.lineJoin = 'round';
                g.beginPath();
                path.forEach(([px, py], i) => i ? g.lineTo(px, py) : g.moveTo(px, py));
                g.stroke();
                g.restore();
            }
            bg.strokeStyle = '#000000';
            bg.lineWidth = 3;
            bg.beginPath();
            path.forEach(([px, py], i) => i ? bg.lineTo(px, py) : bg.moveTo(px, py));
            bg.stroke();
        }
        return { name: 'rf-ember', composite: 'source-over', texture: c, bump, material: 'metal' };
    }

    // Stardust: a night of deep blue and violet nebulae, scattered with stars
    function stardustTexture() {
        const size = 256, c = canvas(size), g = c.getContext('2d'), r = rnd(11);
        const base = g.createLinearGradient(0, 0, size, size);
        base.addColorStop(0, '#1a2160');
        base.addColorStop(0.55, '#33208a');
        base.addColorStop(1, '#103e6e');
        g.fillStyle = base;
        g.fillRect(0, 0, size, size);
        for (const [x, y, rad, color] of [[70, 80, 90, 'rgba(155,93,229,0.35)'], [190, 170, 100, 'rgba(0,187,249,0.22)'], [150, 60, 60, 'rgba(241,91,181,0.18)']]) {
            const n = g.createRadialGradient(x, y, 0, x, y, rad);
            n.addColorStop(0, color);
            n.addColorStop(1, 'rgba(0,0,0,0)');
            g.fillStyle = n;
            g.fillRect(0, 0, size, size);
        }
        for (let i = 0; i < 160; i++) {
            const x = r() * size, y = r() * size, big = r() > 0.93;
            g.fillStyle = r() > 0.8 ? '#fde68a' : '#ffffff';
            g.globalAlpha = 0.5 + r() * 0.5;
            g.beginPath();
            g.arc(x, y, big ? 1.6 : 0.4 + r() * 0.8, 0, Math.PI * 2);
            g.fill();
            if (big) {
                g.globalAlpha = 0.6;
                g.fillRect(x - 5, y - 0.4, 10, 0.8);
                g.fillRect(x - 0.4, y - 5, 0.8, 10);
            }
        }
        g.globalAlpha = 1;
        return { name: 'rf-stardust', composite: 'source-over', texture: c, material: 'glass' };
    }

    function textureOf(skin) {
        return textures[skin] ??= skin === 'ember' ? emberTexture() : stardustTexture();
    }

    // ----- The box -----

    function webgl() {
        try {
            const c = document.createElement('canvas');
            return !!(window.WebGLRenderingContext && (c.getContext('webgl2') || c.getContext('webgl')));
        } catch { return false; }
    }

    // Automated browsers keep the flat dice (the tests read the result at once), unless a test asks for them
    function automated() {
        let forced = false;
        try { forced = localStorage.getItem('rf-dice3d-test') === '1'; } catch { }
        return !!navigator.webdriver && !forced;
    }

    function reducedMotion() {
        return !!(window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches);
    }

    function available() {
        return !automated() && !reducedMotion() && webgl();
    }

    function ensureLayer() {
        if (layer && document.body.contains(layer)) return layer;
        layer = document.createElement('div');
        layer.id = 'rf-dice3d';
        layer.className = 'rf-dice3d-layer';
        layer.setAttribute('aria-hidden', 'true');
        document.body.appendChild(layer);
        return layer;
    }

    // The dice settle sooner than the library's default: still for a fifth of a second instead of nine tenths, a
    // little more damping, a little more gravity; the faces shown are the same
    function quicken(b) {
        const spawn = b.spawnDice.bind(b);
        b.spawnDice = (vectors, reset) => {
            const die = spawn(vectors, reset);
            const target = die || reset || b.diceList[b.diceList.length - 1];
            if (target && target.body) {
                target.body.sleepTimeLimit = 0.2;
                target.body.linearDamping = 0.35;
                target.body.angularDamping = 0.35;
            }
            return die;
        };
        // The dice light up a little with their own colour, more when it is dark: every colour reads on the dark pages
        // (inside the scene: a CSS filter on the canvas can stop it being drawn under the particles). The special dice
        // glow with the colour of their texture
        const factory = b.DiceFactory;
        const create = factory.createMaterials.bind(factory);
        factory.createMaterials = (...args) => {
            const materials = create(...args);
            const special = look && specials[look.skin];
            if (!special && look && look.background) {
                const n = parseInt(look.background.slice(1), 16);
                const luma = (0.299 * (n >> 16) + 0.587 * ((n >> 8) & 255) + 0.114 * (n & 255)) / 255;
                for (const m of materials) {
                    if (m && m.emissive) {
                        m.emissive.set(look.background);
                        m.emissiveIntensity = luma < 0.25 ? 0.55 : luma < 0.45 ? 0.3 : 0.12;
                    }
                }
            }
            if (special) {
                for (const m of materials) {
                    if (m && m.emissive) {
                        m.emissive.set(special.glow);
                        m.emissiveIntensity = special.glowIntensity;
                        if (m.map) m.emissiveMap = m.map;
                    }
                    // Satin metal: without a reflected environment a true metal turns black
                    if (special.material === 'metal' && 'metalness' in m) { m.metalness = 0.3; m.roughness = 0.45; }
                    if (special.material === 'glass' && 'roughness' in m) { m.roughness = 0.05; m.metalness = 0.1; }
                }
            }
            return materials;
        };
    }

    async function ensureBox(sound) {
        if (box && boxSound === sound && layer && layer.firstChild) return box;
        if (loading) await loading;
        if (box && boxSound === sound && layer && layer.firstChild) return box;
        loading = (async () => {
            const lib = await import(new URL('lib/dice3d/dice-box-threejs.es.js', document.baseURI).href);
            const DiceBox = lib.default;
            const host = ensureLayer();
            host.innerHTML = '';
            const next = new DiceBox('#rf-dice3d', {
                assetPath: new URL('lib/dice3d/', document.baseURI).href,
                sounds: sound,
                volume: 60,
                shadows: true,
                strength: 0.8,
                gravity_multiplier: 800,
                light_intensity: 1.1,
                theme_surface: 'green-felt',
                theme_customColorset: resin('forge')
            });
            await next.initialize();
            quicken(next);
            box = next;
            boxSound = sound;
            look = { skin: 'resin', name: 'rf-resin-forge', background: colors.forge.background };
        })();
        try { await loading; } finally { loading = null; }
        return box;
    }

    // The look of the next throw: a resin colour set, or a special die (its colours, texture and material set on the
    // library's dice factory, whose material cache is emptied so the dice are painted again)
    async function applyLook(b, skin, color) {
        const special = specials[skin];
        const set = special ? null : resin(color);
        const name = special ? `rf-${skin}` : set.name;
        if (look && look.name === name) return;
        if (special) {
            await b.updateConfig({ theme_customColorset: { name, background: special.background, foreground: special.foreground, outline: special.outline } });
            const f = b.DiceFactory;
            const tex = textureOf(skin);
            f.dice_texture = tex;
            f.dice_material = tex.material;
        } else {
            await b.updateConfig({ theme_customColorset: set });
        }
        look = { skin: special ? skin : 'resin', name, background: special ? special.background : set.background };
        b.DiceFactory.materials_cache = {};
    }

    // "1d20+2d6@17,3,5": the dice grouped by kind, the faces in the same order. A d100 is thrown as at the table: the
    // tens die and a d10 for the units (73: 70 and 3; 100: 00 and 0)
    function notation(dice) {
        const groups = new Map();
        const thrown = [];
        for (const d of dice) {
            if (d.sides === 100) {
                const v = Math.min(100, Math.max(1, d.value));
                thrown.push({ sides: 100, value: v === 100 ? 100 : Math.floor(v / 10) * 10 || 100 });
                thrown.push({ sides: 10, value: v % 10 || 10 });
            } else {
                thrown.push(d);
            }
        }
        for (const d of thrown) {
            if (!groups.has(d.sides)) groups.set(d.sides, []);
            groups.get(d.sides).push(d.value);
        }
        const parts = [], values = [];
        for (const [n, faces] of groups) {
            parts.push(`${faces.length}d${n}`);
            values.push(...faces);
        }
        return `${parts.join('+')}@${values.join(',')}`;
    }

    // Where a die is on the screen
    function onScreen(b, die) {
        try {
            const p = die.position.clone().project(b.camera);
            const r = layer.getBoundingClientRect();
            return { x: r.left + (p.x + 1) / 2 * r.width, y: r.top + (1 - p.y) / 2 * r.height };
        } catch { return null; }
    }

    // The trail of the special dice while they roll, a few particles at a time
    function trail(b, kind) {
        if (!window.rfFx) return () => { };
        let on = true, last = 0;
        const step = (now) => {
            if (!on) return;
            if (now - last > 70) {
                last = now;
                for (const die of b.diceList || []) {
                    const at = onScreen(b, die);
                    if (at) window.rfFx.burst(at.x, at.y, kind, 0.12);
                }
            }
            requestAnimationFrame(step);
        };
        requestAnimationFrame(step);
        return () => { on = false; };
    }

    function hideLater(ms) {
        clearTimeout(hideTimer);
        hideTimer = setTimeout(() => {
            if (!layer) return;
            layer.classList.add('fading');
            setTimeout(() => {
                layer.classList.remove('shown', 'fading');
                try { box && box.clearDice(); } catch { }
            }, 350);
        }, ms);
    }

    async function throwDice(dice, colorOverride) {
        const s = read();
        // The dice of another player are resin in their colour
        const skin = colorOverride ? 'resin' : s.skin;
        const b = await ensureBox(s.sound);
        await applyLook(b, skin, colorOverride || s.color);
        clearTimeout(hideTimer);
        layer.classList.remove('fading');
        layer.classList.add('shown');
        layer.dataset.skin = skin;
        try { b.clearDice(); } catch { }
        const special = specials[skin];
        const stopTrail = special ? trail(b, special.trail) : () => { };
        // The physics settles in one or two seconds; never wait longer than six
        await Promise.race([b.roll(notation(dice)), new Promise(r => setTimeout(r, 6000))]);
        stopTrail();
        if (special && window.rfFx) {
            for (const die of b.diceList || []) {
                const at = onScreen(b, die);
                if (at) window.rfFx.burst(at.x, at.y, special.land, 0.7);
            }
        }
        hideLater(1100);
        return true;
    }

    // Prepares the box while the page is idle: the library, the scene and the sounds are ready before the first roll
    function prepare() {
        const s = read();
        if (!s.enabled || !available()) return Promise.resolve(false);
        return ensureBox(s.sound).then(() => true, () => false);
    }

    function idle(fn) {
        if ('requestIdleCallback' in window) requestIdleCallback(fn, { timeout: 6000 });
        else setTimeout(fn, 2500);
    }

    if (document.readyState === 'complete') idle(prepare);
    else window.addEventListener('load', () => setTimeout(() => idle(prepare), 1500), { once: true });

    return {
        // The settings of this device: { enabled, skin, color (a palette name or "#rrggbb"), sound, others }
        settings: () => read(),
        save(s) {
            let now = {};
            try { now = JSON.parse(localStorage.getItem(key) || '{}') || {}; } catch { now = {}; }
            const next = { ...now, ...(s || {}) };
            try { localStorage.setItem(key, JSON.stringify(next)); } catch { }
            return read();
        },
        colors: () => Object.keys(colors),
        skins: () => ['resin', ...Object.keys(specials)],
        // The special dice the account has unlocked (from the server)
        unlocked(list) {
            unlocked = new Set((list || []).filter(x => specials[x]));
            return read();
        },
        available,
        prepare,

        // Throws the dice of a roll already decided ([{ sides, value }]) and resolves when they rest: true when they
        // were shown, false when the flat animation is to be used (switched off, no WebGL, a die it cannot draw).
        // Rolls arriving together are thrown one after the other.
        roll(dice, options) {
            const s = read();
            const list = (dice || []).filter(d => d && sides.has(d.sides));
            if (!s.enabled || !available() || list.length === 0 || list.length !== (dice || []).length || list.length > 20) {
                return Promise.resolve(false);
            }
            if (options && options.remote && !s.others) return Promise.resolve(false);
            const run = queue.then(() => throwDice(list, options && options.color)).catch(() => false);
            queue = run.then(() => { }, () => { });
            return run;
        },

        clear() {
            clearTimeout(hideTimer);
            if (layer) layer.classList.remove('shown', 'fading');
            try { box && box.clearDice(); } catch { }
        }
    };
})();
