// RealmForge 3D dice: real dice thrown across the screen (three.js and cannon-es physics, the dice-box-threejs
// library) that land on the faces the app already decided. The roll is never decided here: the dice only show it.
// The library is loaded the first time it is needed; without WebGL, with reduced motion asked or switched off by
// the reader, the app keeps its flat animation.
window.rfDice3d = (() => {
    const key = 'rf-dice3d';
    const sides = new Set([4, 6, 8, 10, 12, 20, 100]);

    // The colours of the dice (the app's own palette; numbers in a contrasting ink)
    const colors = {
        forge: { background: '#ff8c00', foreground: '#141414', outline: '#7a4300' },
        ivory: { background: '#efe6d2', foreground: '#2a2117', outline: '#b9ab8c' },
        obsidian: { background: '#1d1d1f', foreground: '#ff8c00', outline: '#000000' },
        ruby: { background: '#8b1a1a', foreground: '#f5e6c8', outline: '#3d0909' },
        emerald: { background: '#1f6b45', foreground: '#f5e6c8', outline: '#0c2e1d' },
        sapphire: { background: '#1f3f8b', foreground: '#f5e6c8', outline: '#0b1a3d' },
        amethyst: { background: '#5b2a86', foreground: '#f5e6c8', outline: '#25103a' }
    };
    const materials = new Set(['plastic', 'metal', 'wood', 'glass']);

    let box = null, boxKey = null, boxColors = null, layer = null, loading = null, hideTimer = null, queue = Promise.resolve();

    // The colour set of the dice: a preset of the app, or the colour of a player at the table ("#4fc3f7") with an ink
    // that reads on it
    function colorset(color, material) {
        if (colors[color]) {
            const c = colors[color];
            return { name: `rf-${color}-${material}`, background: c.background, foreground: c.foreground, outline: c.outline, texture: 'none', material };
        }
        const hex = /^#([0-9a-f]{6})$/i.exec(color || '');
        if (!hex) return colorset('forge', material);
        const n = parseInt(hex[1], 16), r = n >> 16, g = (n >> 8) & 255, b = n & 255;
        const light = (0.299 * r + 0.587 * g + 0.114 * b) / 255 > 0.55;
        return { name: `rf-${hex[1]}-${material}`, background: color, foreground: light ? '#141414' : '#f5e6c8', outline: light ? '#3a3a3a' : '#000000', texture: 'none', material };
    }

    function read() {
        let s = {};
        try { s = JSON.parse(localStorage.getItem(key) || '{}') || {}; } catch { s = {}; }
        return {
            enabled: s.enabled !== false,
            color: colors[s.color] ? s.color : 'forge',
            material: materials.has(s.material) ? s.material : 'plastic',
            sound: s.sound !== false,
            others: s.others !== false
        };
    }

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

    async function ensureBox(s) {
        const wanted = `${s.material}|${s.sound}`;
        if (box && boxKey === wanted && layer && layer.firstChild) return box;
        if (loading) await loading;
        if (box && boxKey === wanted && layer && layer.firstChild) return box;
        loading = (async () => {
            const lib = await import(new URL('lib/dice3d/dice-box-threejs.es.js', document.baseURI).href);
            const DiceBox = lib.default;
            const host = ensureLayer();
            host.innerHTML = '';
            const set = colorset(s.color, s.material);
            const next = new DiceBox('#rf-dice3d', {
                assetPath: new URL('lib/dice3d/', document.baseURI).href,
                sounds: s.sound,
                volume: 60,
                shadows: true,
                strength: 1.3,
                gravity_multiplier: 420,
                light_intensity: 0.85,
                theme_surface: 'green-felt',
                theme_customColorset: set
            });
            await next.initialize();
            box = next;
            boxKey = wanted;
            boxColors = set.name;
        })();
        try { await loading; } finally { loading = null; }
        return box;
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

    function hideLater(ms) {
        clearTimeout(hideTimer);
        hideTimer = setTimeout(() => {
            if (!layer) return;
            layer.classList.add('fading');
            setTimeout(() => {
                layer.classList.remove('shown', 'fading');
                try { box && box.clearDice(); } catch { }
            }, 450);
        }, ms);
    }

    async function throwDice(dice, colorOverride) {
        const s = read();
        if (colorOverride) s.color = colorOverride;
        const b = await ensureBox(s);
        const set = colorset(s.color, s.material);
        if (set.name !== boxColors) {
            await b.updateConfig({ theme_customColorset: set });
            boxColors = set.name;
        }
        clearTimeout(hideTimer);
        layer.classList.remove('fading');
        layer.classList.add('shown');
        try { b.clearDice(); } catch { }
        // The physics settles in two or three seconds; never wait longer than eight
        await Promise.race([b.roll(notation(dice)), new Promise(r => setTimeout(r, 8000))]);
        hideLater(1400);
        return true;
    }

    return {
        // The settings of this device: { enabled, color, material, sound, others }
        settings: () => read(),
        save(s) {
            const now = read();
            const next = { ...now, ...(s || {}) };
            try { localStorage.setItem(key, JSON.stringify(next)); } catch { }
            return read();
        },
        colors: () => Object.keys(colors),
        available,

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
