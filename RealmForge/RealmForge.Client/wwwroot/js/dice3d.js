// RealmForge 3D dice: real dice thrown across the screen (three.js and cannon-es physics, the dice-box-threejs
// library) that land on the faces the app already decided. The roll is never decided here: the dice only show it.
// The library is prepared while the page is idle, so the first roll does not wait for it; without WebGL, with
// reduced motion asked or switched off by the reader, the app keeps its flat animation.
//
// The look of the dice: resin, in a colour of the palette or any colour (RGB), for everyone; and special dice
// unlocked with a code (an easter egg, checked by the server), each with its own material and texture, a glow that
// breathes while they are on the screen and, on a natural 20 or 1 of the d20, an effect of its own.
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

    // The special dice: their own colours, a texture painted here (no image files), a material, a glow that breathes
    // with the texture while they are on the screen (pulse) and, on a natural 1 or 20 of the d20, an effect of their own
    // (fx). Ember and stardust are shown locked until found; the others are secret: shown nowhere until unlocked
    const specials = {
        ember: { foreground: '#fff0b8', outline: '#3a0c00', background: '#5a1a08', material: 'metal', glow: '#ff6a10', glowIntensity: 0.85, pulse: 'lava', fx: { style: 'ember', colors: ['#ffe9a0', '#ff8a2a', '#ff4d00', '#ffd166'], dark: '#3a0c00' } },
        stardust: { foreground: '#ffffff', outline: '#1b0f4a', background: '#1d1a5a', material: 'glass', glow: '#8f7dff', glowIntensity: 0.55, pulse: 'twinkle', fx: { style: 'star', colors: ['#ffffff', '#fde68a', '#a5b4fc', '#f0abfc'], dark: '#1b0f4a' } },
        frost: { foreground: '#0b2a44', outline: '#e8f8ff', background: '#a8dcf5', material: 'glass', glow: '#9fe3ff', glowIntensity: 0.35, pulse: 'shimmer', fx: { style: 'shard', colors: ['#ffffff', '#c9f0ff', '#7fd3ff', '#e0fbff'], dark: '#1d4a66' } },
        storm: { foreground: '#e6f6ff', outline: '#04070c', background: '#1d2533', material: 'metal', glow: '#55d6ff', glowIntensity: 0.4, pulse: 'flicker', fx: { style: 'bolt', colors: ['#ffffff', '#9be7ff', '#55d6ff', '#c4b5fd'], dark: '#0b1220' } },
        bone: { foreground: '#173d1a', outline: '#c9ffd6', background: '#e6dcc3', material: 'none', glow: '#58ff8a', glowIntensity: 0.3, pulse: 'breath', fx: { style: 'wisp', colors: ['#b6ffcb', '#58ff8a', '#1fd65f', '#e6dcc3'], dark: '#0f2a14' } },
        hoard: { foreground: '#3a2300', outline: '#fff2b0', background: '#c8961e', material: 'metal', glow: '#ffcf4a', glowIntensity: 0.45, pulse: 'glint', fx: { style: 'coin', colors: ['#fff2b0', '#ffd34d', '#e5a91a', '#ffffff'], dark: '#4a3000' } },
        abyss: { foreground: '#d7c2ff', outline: '#000000', background: '#0b0912', material: 'none', glow: '#7b3cff', glowIntensity: 0.6, pulse: 'throb', fx: { style: 'void', colors: ['#c4a1ff', '#7b3cff', '#4c1d95', '#f0e6ff'], dark: '#05030a' } },
        fey: { foreground: '#f6ffd9', outline: '#1d2a10', background: '#4a6b2c', material: 'wood', glow: '#c6ff6a', glowIntensity: 0.35, pulse: 'firefly', fx: { style: 'firefly', colors: ['#f7ff9e', '#c6ff6a', '#ffe5f4', '#a7f3d0'], dark: '#1d2a10' } },
        acid: { foreground: '#0d2b06', outline: '#d9ffcf', background: '#3fd14a', material: 'glass', glow: '#7dff3a', glowIntensity: 0.5, pulse: 'bubble', fx: { style: 'drop', colors: ['#d9ffcf', '#7dff3a', '#3fd14a', '#e8ff7a'], dark: '#12300a' } },
        arcane: { foreground: '#ffe9a8', outline: '#120a30', background: '#2a1a5e', material: 'glass', glow: '#b48bff', glowIntensity: 0.5, pulse: 'rune', fx: { style: 'rune', colors: ['#ffe9a8', '#ffd166', '#b48bff', '#ffffff'], dark: '#120a30' } }
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

    const TEX = 256;

    function canvas(size) {
        const c = document.createElement('canvas');
        c.width = c.height = size;
        return c;
    }

    function rnd(seed) {
        let s = seed >>> 0;
        return () => (s = (s * 1664525 + 1013904223) >>> 0) / 4294967296;
    }

    // A ground of two or three colours across the face
    function ground(g, stops, radial) {
        const f = radial ? g.createRadialGradient(TEX / 2, TEX / 2, 20, TEX / 2, TEX / 2, TEX * 0.75) : g.createLinearGradient(0, 0, TEX, TEX);
        stops.forEach((c, i) => f.addColorStop(i / Math.max(1, stops.length - 1), c));
        g.fillStyle = f;
        g.fillRect(0, 0, TEX, TEX);
    }

    function speckle(g, r, count, color, size) {
        for (let i = 0; i < count; i++) {
            g.fillStyle = typeof color === 'function' ? color() : color;
            g.fillRect(r() * TEX, r() * TEX, size, size);
        }
    }

    // A wandering line (a crack, a vein, a bolt): its points
    function walk(r, steps, reach, start) {
        let [x, y] = start || [r() * TEX, r() * TEX];
        const path = [[x, y]];
        for (let s = 0; s < steps; s++) {
            x += (r() - 0.5) * reach;
            y += (r() - 0.5) * reach;
            path.push([x, y]);
        }
        return path;
    }

    function stroke(g, path, width, color, glow, blur) {
        g.save();
        g.strokeStyle = color;
        g.lineWidth = width;
        g.lineJoin = 'round';
        g.lineCap = 'round';
        if (glow) { g.shadowColor = glow; g.shadowBlur = blur || 8; }
        g.beginPath();
        path.forEach(([px, py], i) => i ? g.lineTo(px, py) : g.moveTo(px, py));
        g.stroke();
        g.restore();
    }

    // Ember: dark basalt split by glowing cracks of lava
    function emberTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(7);
        ground(g, ['#7a2a0c', '#3a0e04'], true);
        speckle(g, r, 400, () => `rgba(0,0,0,${0.15 + r() * 0.25})`, 2);
        const bump = canvas(TEX), bg = bump.getContext('2d');
        bg.fillStyle = '#ffffff';
        bg.fillRect(0, 0, TEX, TEX);
        for (let k = 0; k < 9; k++) {
            const path = walk(r, 7, 70);
            stroke(g, path, 11, 'rgba(255,90,0,0.45)', '#ff5a00', 16);
            stroke(g, path, 4.5, '#ff8a2a', '#ff5a00', 8);
            stroke(g, path, 1.8, '#ffe9a0', '#ff5a00', 3);
            stroke(bg, path, 3, '#000000');
        }
        return { name: 'rf-ember', composite: 'source-over', texture: c, bump, material: 'metal' };
    }

    // Stardust: a night of deep blue and violet nebulae, scattered with stars
    function stardustTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(11);
        ground(g, ['#1a2160', '#33208a', '#103e6e']);
        for (const [x, y, rad, color] of [[70, 80, 90, 'rgba(155,93,229,0.35)'], [190, 170, 100, 'rgba(0,187,249,0.22)'], [150, 60, 60, 'rgba(241,91,181,0.18)']]) {
            const n = g.createRadialGradient(x, y, 0, x, y, rad);
            n.addColorStop(0, color);
            n.addColorStop(1, 'rgba(0,0,0,0)');
            g.fillStyle = n;
            g.fillRect(0, 0, TEX, TEX);
        }
        for (let i = 0; i < 160; i++) {
            const x = r() * TEX, y = r() * TEX, big = r() > 0.93;
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

    // Frost: pale ice with branching rime
    function frostTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(23);
        ground(g, ['#e6f8ff', '#a8dcf5', '#6fb8e0']);
        const branch = (x, y, angle, length, depth) => {
            if (depth <= 0 || length < 4) return;
            const x2 = x + Math.cos(angle) * length, y2 = y + Math.sin(angle) * length;
            stroke(g, [[x, y], [x2, y2]], depth * 0.6, `rgba(255,255,255,${0.35 + depth * 0.1})`, '#ffffff', 4);
            branch(x2, y2, angle, length * 0.7, depth - 1);
            branch(x + Math.cos(angle) * length * 0.5, y + Math.sin(angle) * length * 0.5, angle + 1.05, length * 0.5, depth - 1);
            branch(x + Math.cos(angle) * length * 0.5, y + Math.sin(angle) * length * 0.5, angle - 1.05, length * 0.5, depth - 1);
        };
        for (let k = 0; k < 6; k++) branch(r() * TEX, r() * TEX, r() * Math.PI * 2, 36 + r() * 30, 4);
        speckle(g, r, 120, () => `rgba(255,255,255,${0.4 + r() * 0.6})`, 1.5);
        return { name: 'rf-frost', composite: 'source-over', texture: c, material: 'glass' };
    }

    // Storm: dark slate, forks of lightning
    function stormTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(31);
        ground(g, ['#2b3547', '#1d2533', '#111722'], true);
        for (let i = 0; i < 6; i++) {
            const n = g.createRadialGradient(r() * TEX, r() * TEX, 0, r() * TEX, r() * TEX, 90);
            n.addColorStop(0, 'rgba(120,140,170,0.18)');
            n.addColorStop(1, 'rgba(0,0,0,0)');
            g.fillStyle = n;
            g.fillRect(0, 0, TEX, TEX);
        }
        for (let k = 0; k < 5; k++) {
            const path = walk(r, 8, 46);
            stroke(g, path, 6, 'rgba(85,214,255,0.35)', '#55d6ff', 14);
            stroke(g, path, 1.6, '#e6f6ff', '#9be7ff', 6);
            const fork = walk(r, 4, 30, path[3]);
            stroke(g, fork, 1, '#c9efff', '#55d6ff', 5);
        }
        return { name: 'rf-storm', composite: 'source-over', texture: c, material: 'metal' };
    }

    // Bone: old ivory, cracked, with faint green runes
    function boneTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(41);
        ground(g, ['#f2ead6', '#e6dcc3', '#c9bc9a'], true);
        speckle(g, r, 300, () => `rgba(90,70,40,${0.05 + r() * 0.12})`, 2);
        for (let k = 0; k < 7; k++) stroke(g, walk(r, 5, 40), 1.2, 'rgba(70,55,30,0.55)');
        for (let k = 0; k < 10; k++) {
            const x = r() * TEX, y = r() * TEX, s = 6 + r() * 6;
            g.save();
            g.strokeStyle = 'rgba(40,200,90,0.8)';
            g.shadowColor = '#58ff8a';
            g.shadowBlur = 6;
            g.lineWidth = 1.4;
            g.beginPath();
            g.moveTo(x, y - s); g.lineTo(x, y + s);
            g.moveTo(x - s * 0.6, y - s * 0.3); g.lineTo(x + s * 0.6, y + s * 0.3);
            if (r() > 0.5) { g.moveTo(x - s * 0.5, y + s * 0.5); g.lineTo(x + s * 0.5, y + s * 0.5); }
            g.stroke();
            g.restore();
        }
        return { name: 'rf-bone', composite: 'source-over', texture: c, material: 'none' };
    }

    // Hoard: hammered gold, engraved with scales
    function hoardTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(53);
        ground(g, ['#ffe08a', '#d9a426', '#9c6a10']);
        g.strokeStyle = 'rgba(110,70,0,0.35)';
        g.lineWidth = 1.2;
        for (let y = 0; y < TEX + 16; y += 14) {
            for (let x = (y / 14) % 2 ? 7 : 0; x < TEX + 16; x += 14) {
                g.beginPath();
                g.arc(x, y, 7, 0, Math.PI);
                g.stroke();
            }
        }
        speckle(g, r, 140, () => `rgba(255,250,220,${0.4 + r() * 0.6})`, 1.5);
        return { name: 'rf-hoard', composite: 'source-over', texture: c, material: 'metal' };
    }

    // Abyss: black, a violet whirl at the edges
    function abyssTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(61);
        const f = g.createRadialGradient(TEX / 2, TEX / 2, 10, TEX / 2, TEX / 2, TEX * 0.72);
        f.addColorStop(0, '#000000');
        f.addColorStop(0.6, '#0b0912');
        f.addColorStop(1, '#3b1a7a');
        g.fillStyle = f;
        g.fillRect(0, 0, TEX, TEX);
        g.save();
        g.translate(TEX / 2, TEX / 2);
        for (let a = 0; a < 3; a++) {
            g.beginPath();
            for (let t = 0; t < 40; t += 0.2) {
                const rad = 4 + t * 3.2, ang = t * 0.55 + a * 2.09;
                const x = Math.cos(ang) * rad, y = Math.sin(ang) * rad;
                t ? g.lineTo(x, y) : g.moveTo(x, y);
            }
            g.strokeStyle = 'rgba(123,60,255,0.28)';
            g.lineWidth = 2;
            g.shadowColor = '#7b3cff';
            g.shadowBlur = 8;
            g.stroke();
        }
        g.restore();
        speckle(g, r, 50, () => `rgba(200,170,255,${0.2 + r() * 0.5})`, 1);
        return { name: 'rf-abyss', composite: 'source-over', texture: c, material: 'none' };
    }

    // Fey: living wood, moss and tiny lights
    function feyTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(71);
        ground(g, ['#6b8a3a', '#4a6b2c', '#34501d']);
        for (let y = 0; y < TEX; y += 5) {
            g.beginPath();
            for (let x = 0; x <= TEX; x += 8) g.lineTo(x, y + Math.sin(x / 30 + y / 17) * 3);
            g.strokeStyle = `rgba(30,45,15,${0.15 + r() * 0.2})`;
            g.lineWidth = 1;
            g.stroke();
        }
        for (let i = 0; i < 9; i++) {
            const n = g.createRadialGradient(r() * TEX, r() * TEX, 0, r() * TEX, r() * TEX, 40);
            n.addColorStop(0, 'rgba(160,220,90,0.35)');
            n.addColorStop(1, 'rgba(0,0,0,0)');
            g.fillStyle = n;
            g.fillRect(0, 0, TEX, TEX);
        }
        for (let i = 0; i < 26; i++) {
            g.save();
            g.fillStyle = r() > 0.5 ? '#f7ff9e' : '#ffe5f4';
            g.shadowColor = '#f7ff9e';
            g.shadowBlur = 6;
            g.beginPath();
            g.arc(r() * TEX, r() * TEX, 1 + r() * 1.4, 0, Math.PI * 2);
            g.fill();
            g.restore();
        }
        return { name: 'rf-fey', composite: 'source-over', texture: c, material: 'wood' };
    }

    // Acid: green glass full of bubbles
    function acidTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(83);
        ground(g, ['#8cff6a', '#3fd14a', '#1f8a24']);
        for (let i = 0; i < 45; i++) {
            const x = r() * TEX, y = r() * TEX, rad = 2 + r() * 9;
            g.beginPath();
            g.arc(x, y, rad, 0, Math.PI * 2);
            g.strokeStyle = 'rgba(230,255,210,0.55)';
            g.lineWidth = 1.2;
            g.stroke();
            g.beginPath();
            g.arc(x - rad * 0.35, y - rad * 0.35, rad * 0.25, 0, Math.PI * 2);
            g.fillStyle = 'rgba(255,255,255,0.6)';
            g.fill();
        }
        return { name: 'rf-acid', composite: 'source-over', texture: c, material: 'glass' };
    }

    // Arcane: indigo crystal, circles of golden runes
    function arcaneTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(97);
        ground(g, ['#3b2680', '#2a1a5e', '#160d38'], true);
        for (let k = 0; k < 4; k++) {
            const x = r() * TEX, y = r() * TEX, rad = 24 + r() * 26;
            g.save();
            g.strokeStyle = 'rgba(255,209,102,0.7)';
            g.shadowColor = '#ffd166';
            g.shadowBlur = 6;
            g.lineWidth = 1.2;
            g.beginPath();
            g.arc(x, y, rad, 0, Math.PI * 2);
            g.arc(x, y, rad * 0.78, 0, Math.PI * 2);
            g.stroke();
            for (let i = 0; i < 8; i++) {
                const a = i / 8 * Math.PI * 2, gx = x + Math.cos(a) * rad * 0.89, gy = y + Math.sin(a) * rad * 0.89;
                g.beginPath();
                g.moveTo(gx - 2.5, gy - 2.5); g.lineTo(gx + 2.5, gy + 2.5);
                g.moveTo(gx + 2.5, gy - 2.5); g.lineTo(gx, gy);
                g.stroke();
            }
            g.beginPath();
            for (let i = 0; i <= 3; i++) {
                const a = i / 3 * Math.PI * 2 - Math.PI / 2;
                const px = x + Math.cos(a) * rad * 0.7, py = y + Math.sin(a) * rad * 0.7;
                i ? g.lineTo(px, py) : g.moveTo(px, py);
            }
            g.stroke();
            g.restore();
        }
        speckle(g, r, 60, () => `rgba(255,233,168,${0.3 + r() * 0.5})`, 1.2);
        return { name: 'rf-arcane', composite: 'source-over', texture: c, material: 'glass' };
    }

    const painters = { ember: emberTexture, stardust: stardustTexture, frost: frostTexture, storm: stormTexture, bone: boneTexture, hoard: hoardTexture, abyss: abyssTexture, fey: feyTexture, acid: acidTexture, arcane: arcaneTexture };

    function textureOf(skin) {
        return textures[skin] ??= painters[skin]();
    }

    // ----- The texture breathing while the dice are on the screen: their glow follows a rhythm of their own -----

    const pulses = {
        lava: (t) => 0.75 + 0.25 * Math.sin(t * 2.2) + 0.08 * Math.sin(t * 7.3),
        twinkle: (t) => 0.85 + 0.2 * Math.sin(t * 9) * Math.sin(t * 3.1),
        shimmer: (t) => 0.8 + 0.25 * Math.sin(t * 1.6),
        flicker: (t, st) => {
            if (t > st.until && Math.random() < 0.025) { st.until = t + 0.08 + Math.random() * 0.1; st.peak = 1.8 + Math.random(); }
            return t < st.until ? st.peak : 0.6;
        },
        breath: (t) => 0.55 + 0.55 * (0.5 + 0.5 * Math.sin(t * 1.6)),
        glint: (t) => 0.8 + 1.4 * Math.pow(Math.max(0, Math.sin(t * 1.4)), 14),
        throb: (t) => 0.5 + 0.9 * Math.pow(0.5 + 0.5 * Math.sin(t * 1.1), 2),
        firefly: (t) => 0.75 + 0.3 * Math.sin(t * 2.7 + Math.sin(t * 1.3) * 2),
        bubble: (t) => 0.85 + 0.15 * Math.sin(t * 5) + 0.12 * Math.sin(t * 8.3 + 1),
        rune: (t) => 0.6 + 0.8 * Math.pow(Math.max(0, Math.sin(t * 2.4)), 4)
    };

    let pulseOn = false;

    function startPulse(b, special) {
        const f = pulses[special.pulse];
        if (!f || pulseOn) return;
        pulseOn = true;
        const st = { until: 0, peak: 1 };
        const step = (now) => {
            if (!pulseOn) return;
            const k = Math.max(0.1, f(now / 1000, st));
            for (const die of b.diceList || []) {
                const list = Array.isArray(die.material) ? die.material : [die.material];
                for (const m of list) if (m && m.emissive) m.emissiveIntensity = special.glowIntensity * k;
            }
            requestAnimationFrame(step);
        };
        requestAnimationFrame(step);
    }

    function stopPulse() {
        pulseOn = false;
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

    // "1d20+2d6@17,3,5": the dice grouped by kind, the faces in the same order (and the dice in that order, to find
    // the d20 of a critical on the screen). A d100 is thrown as at the table: the
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
            groups.get(d.sides).push(d);
        }
        const parts = [], values = [], ordered = [];
        for (const [n, faces] of groups) {
            parts.push(`${faces.length}d${n}`);
            values.push(...faces.map(f => f.value));
            ordered.push(...faces);
        }
        return { text: `${parts.join('+')}@${values.join(',')}`, thrown: ordered };
    }

    // Where a die is on the screen
    function onScreen(b, die) {
        try {
            const p = die.position.clone().project(b.camera);
            const r = layer.getBoundingClientRect();
            return { x: r.left + (p.x + 1) / 2 * r.width, y: r.top + (1 - p.y) / 2 * r.height };
        } catch { return null; }
    }

    // ----- The critical moment: a natural 20 or 1 of the d20 of a special die -----
    //
    // Drawn on a canvas of its own over the dice, for about three seconds. A natural 20: a flash, a column of light,
    // rings of shock and the die's own burst (embers, stars, shards of ice, bolts, wisps, gold coins, a vortex,
    // fireflies, drops of acid, a circle of runes), then motes that drift away. A natural 1: the light dies: a
    // dark pulse, cracks running out of the die, smoke and a few falling sparks.

    let fxCanvas = null;

    function fxLayer() {
        if (fxCanvas && document.body.contains(fxCanvas)) return fxCanvas;
        fxCanvas = document.createElement('canvas');
        fxCanvas.className = 'rf-dice3d-fx';
        fxCanvas.setAttribute('aria-hidden', 'true');
        fxCanvas.dataset.test = 'dice3d-crit';
        document.body.appendChild(fxCanvas);
        return fxCanvas;
    }

    const TAU = Math.PI * 2;
    const ease = (t) => 1 - Math.pow(1 - Math.min(1, Math.max(0, t)), 3);
    const pick = (list) => list[Math.floor(Math.random() * list.length)];

    function rgba(hex, a) {
        const n = parseInt(hex.slice(1), 16);
        return `rgba(${n >> 16},${(n >> 8) & 255},${n & 255},${Math.max(0, Math.min(1, a))})`;
    }

    // A particle drawn in the style of the die
    function drawParticle(g, p, style, life) {
        const a = p.alpha * (1 - life);
        g.save();
        g.translate(p.x, p.y);
        g.rotate(p.spin);
        g.globalAlpha = Math.max(0, a);
        g.fillStyle = p.color;
        g.strokeStyle = p.color;
        g.shadowColor = p.color;
        g.shadowBlur = 10;
        const s = p.size;
        switch (style) {
            case 'star': {
                g.beginPath();
                for (let i = 0; i < 8; i++) {
                    const r = i % 2 ? s * 0.35 : s * 1.3, ang = i / 8 * TAU;
                    g.lineTo(Math.cos(ang) * r, Math.sin(ang) * r);
                }
                g.closePath();
                g.fill();
                break;
            }
            case 'shard':
                g.beginPath();
                g.moveTo(0, -s * 1.8); g.lineTo(s * 0.5, 0); g.lineTo(0, s * 1.8); g.lineTo(-s * 0.5, 0);
                g.closePath();
                g.fill();
                break;
            case 'coin': {
                const w = Math.abs(Math.cos(p.flip)) * s * 1.4 + 1;
                g.beginPath();
                g.ellipse(0, 0, w, s * 1.4, 0, 0, TAU);
                g.fill();
                g.globalAlpha = Math.max(0, a * 0.7);
                g.fillStyle = '#fffbe6';
                g.beginPath();
                g.ellipse(-w * 0.3, -s * 0.4, w * 0.25, s * 0.35, 0, 0, TAU);
                g.fill();
                break;
            }
            case 'drop':
                g.beginPath();
                g.moveTo(0, -s * 1.6);
                g.quadraticCurveTo(s, 0, 0, s);
                g.quadraticCurveTo(-s, 0, 0, -s * 1.6);
                g.fill();
                break;
            case 'rune':
                g.lineWidth = 1.6;
                g.beginPath();
                g.moveTo(-s, -s); g.lineTo(s, s); g.moveTo(s, -s); g.lineTo(0, 0); g.moveTo(-s, s * 0.2); g.lineTo(s * 0.4, s * 1.1);
                g.stroke();
                break;
            case 'wisp':
            case 'smoke': {
                const grad = g.createRadialGradient(0, 0, 0, 0, 0, s * 2.4);
                grad.addColorStop(0, rgba(p.color, 0.9));
                grad.addColorStop(1, rgba(p.color, 0));
                g.fillStyle = grad;
                g.shadowBlur = 0;
                g.beginPath();
                g.arc(0, 0, s * 2.4, 0, TAU);
                g.fill();
                break;
            }
            default:
                g.beginPath();
                g.arc(0, 0, s, 0, TAU);
                g.fill();
        }
        g.restore();
    }

    // A jagged line from a point (a bolt, a crack)
    function jagged(x, y, angle, length, roughness) {
        const pts = [[x, y]];
        const steps = 7;
        for (let i = 1; i <= steps; i++) {
            const d = length * i / steps;
            const off = (Math.random() - 0.5) * roughness;
            pts.push([x + Math.cos(angle) * d - Math.sin(angle) * off, y + Math.sin(angle) * d + Math.cos(angle) * off]);
        }
        return pts;
    }

    function polyline(g, pts, width, color, glow) {
        g.save();
        g.strokeStyle = color;
        g.lineWidth = width;
        g.lineJoin = 'round';
        g.shadowColor = glow || color;
        g.shadowBlur = glow ? 14 : 0;
        g.beginPath();
        pts.forEach(([px, py], i) => i ? g.lineTo(px, py) : g.moveTo(px, py));
        g.stroke();
        g.restore();
    }

    // The particles of a natural 20, by style: where they start, how they move
    function burstParticles(x, y, fx) {
        const list = [];
        const style = fx.style;
        const count = style === 'void' ? 90 : style === 'coin' ? 46 : 70;
        for (let i = 0; i < count; i++) {
            const ang = Math.random() * TAU;
            const speed = 2 + Math.random() * 6;
            const p = { x, y, vx: Math.cos(ang) * speed, vy: Math.sin(ang) * speed, size: 2.5 + Math.random() * 4, color: pick(fx.colors), alpha: 1, spin: Math.random() * TAU, vs: (Math.random() - 0.5) * 0.3, flip: Math.random() * TAU, delay: 0, life: 1.6 + Math.random() * 1.1, gravity: 0, drag: 0.95 };
            switch (style) {
                case 'ember': p.vy -= 3; p.gravity = -0.06; p.size *= 0.8; break;
                case 'coin': p.vy = -6 - Math.random() * 8; p.vx *= 0.7; p.gravity = 0.38; p.drag = 0.99; p.size = 4 + Math.random() * 3; break;
                case 'drop': p.vy = -4 - Math.random() * 6; p.gravity = 0.3; p.drag = 0.98; break;
                case 'shard': p.size = 3 + Math.random() * 3; p.drag = 0.92; break;
                case 'wisp': p.vx *= 0.4; p.vy = -1.5 - Math.random() * 2.5; p.size = 5 + Math.random() * 5; p.drag = 0.97; p.alpha = 0.5; break;
                case 'firefly': p.orbit = 30 + Math.random() * 110; p.angle = ang; p.av = (Math.random() > 0.5 ? 1 : -1) * (0.02 + Math.random() * 0.04); p.size = 2 + Math.random() * 2; break;
                case 'void': {
                    // Drawn in from far away, then thrown out
                    const far = 160 + Math.random() * 160;
                    p.x = x + Math.cos(ang) * far; p.y = y + Math.sin(ang) * far;
                    p.home = { x, y }; p.angle = ang; p.far = far; p.size = 2.5 + Math.random() * 3; p.color = pick([fx.colors[0], fx.colors[3], fx.colors[0]]);
                    break;
                }
                case 'rune': p.size = 4 + Math.random() * 3; p.drag = 0.95; break;
                default: break;
            }
            list.push(p);
        }
        return list;
    }

    function stepParticle(p, style, t, x, y) {
        if (style === 'firefly') {
            p.angle += p.av;
            p.orbit += 0.6;
            p.x = x + Math.cos(p.angle) * p.orbit + Math.sin(t * 7 + p.spin) * 4;
            p.y = y + Math.sin(p.angle) * p.orbit * 0.6 - t * 30;
            p.alpha = 0.5 + 0.5 * Math.abs(Math.sin(t * 9 + p.spin));
            return;
        }
        if (style === 'void') {
            if (t < 0.7) {
                // The spiral inwards
                const k = 1 - ease(t / 0.7);
                p.angle += 0.08;
                p.x = p.home.x + Math.cos(p.angle) * p.far * k;
                p.y = p.home.y + Math.sin(p.angle) * p.far * k;
                return;
            }
            if (!p.out) {
                p.out = true;
                const sp = 4 + Math.random() * 8;
                p.vx = Math.cos(p.angle) * sp;
                p.vy = Math.sin(p.angle) * sp;
            }
        }
        p.vx *= p.drag;
        p.vy = p.vy * p.drag + p.gravity;
        p.x += p.vx;
        p.y += p.vy;
        p.spin += p.vs;
        p.flip += 0.25;
    }

    function critical(x, y, fx, high) {
        const c = fxLayer(), g = c.getContext('2d');
        const dpr = Math.min(2, window.devicePixelRatio || 1);
        c.width = Math.round(innerWidth * dpr);
        c.height = Math.round(innerHeight * dpr);
        c.classList.add('shown');
        const main = fx.colors[1], light = fx.colors[0], dark = fx.dark;
        const particles = high ? burstParticles(x, y, fx) : [];
        const smoke = high ? [] : Array.from({ length: 34 }, () => ({ x: x + (Math.random() - 0.5) * 30, y: y + (Math.random() - 0.5) * 20, vx: (Math.random() - 0.5) * 0.8, vy: -0.4 - Math.random() * 1.1, size: 6 + Math.random() * 8, color: Math.random() > 0.4 ? '#3a3a3a' : dark, alpha: 0.55, spin: 0, vs: 0, drag: 0.99, gravity: -0.004 }));
        const sparks = high ? [] : Array.from({ length: 16 }, () => ({ x, y, vx: (Math.random() - 0.5) * 5, vy: -2 - Math.random() * 3, size: 1.5 + Math.random() * 1.5, color: main, alpha: 0.9, spin: 0, vs: 0, drag: 0.98, gravity: 0.22 }));
        const cracks = high ? [] : Array.from({ length: 7 }, (_, i) => jagged(x, y, i / 7 * TAU + Math.random() * 0.5, 50 + Math.random() * 70, 18));
        const motes = [];
        let bolts = [], boltAt = 0;
        const duration = high ? 3 : 2;
        const start = performance.now();
        return new Promise((done) => {
            const frame = (now) => {
                const t = (now - start) / 1000;
                g.setTransform(dpr, 0, 0, dpr, 0, 0);
                g.clearRect(0, 0, innerWidth, innerHeight);
                g.globalCompositeOperation = high ? 'lighter' : 'source-over';
                if (high) {
                    // The flash
                    const fl = Math.max(0, 1 - t / 0.6);
                    if (fl > 0) {
                        const rad = 40 + ease(t / 0.6) * 300;
                        const grad = g.createRadialGradient(x, y, 0, x, y, rad);
                        grad.addColorStop(0, rgba(light, 0.95 * fl));
                        grad.addColorStop(0.4, rgba(main, 0.55 * fl));
                        grad.addColorStop(1, rgba(main, 0));
                        g.fillStyle = grad;
                        g.fillRect(x - rad, y - rad, rad * 2, rad * 2);
                    }
                    // The column of light (the vortex for the abyss)
                    const col = Math.sin(Math.min(1, t / 1.6) * Math.PI);
                    if (col > 0 && fx.style !== 'void') {
                        const w = 30 + 40 * col;
                        const grad = g.createLinearGradient(x - w, 0, x + w, 0);
                        grad.addColorStop(0, rgba(main, 0));
                        grad.addColorStop(0.5, rgba(light, 0.55 * col));
                        grad.addColorStop(1, rgba(main, 0));
                        g.fillStyle = grad;
                        g.fillRect(x - w, 0, w * 2, y + 20);
                    } else if (fx.style === 'void' && t < 1.6) {
                        const k = t < 0.7 ? ease(t / 0.7) : 1 - ease((t - 0.7) / 0.9);
                        const rad = 20 + 70 * k;
                        const grad = g.createRadialGradient(x, y, 0, x, y, rad);
                        grad.addColorStop(0, 'rgba(0,0,0,0.95)');
                        grad.addColorStop(0.7, rgba(dark, 0.8 * k));
                        grad.addColorStop(1, rgba(main, 0));
                        g.globalCompositeOperation = 'source-over';
                        g.fillStyle = grad;
                        g.beginPath();
                        g.arc(x, y, rad, 0, TAU);
                        g.fill();
                        g.globalCompositeOperation = 'lighter';
                        // Its rim of violet light, turning
                        g.save();
                        g.strokeStyle = rgba(light, 0.85 * k);
                        g.shadowColor = main;
                        g.shadowBlur = 24;
                        g.lineWidth = 3;
                        g.beginPath();
                        g.arc(x, y, rad, t * 6, t * 6 + TAU * 0.8);
                        g.stroke();
                        g.lineWidth = 1.5;
                        g.beginPath();
                        g.arc(x, y, rad * 1.35, -t * 4, -t * 4 + TAU * 0.6);
                        g.stroke();
                        g.restore();
                    }
                    // The rings
                    for (let i = 0; i < 3; i++) {
                        const rt = (t - 0.08 - i * 0.2) / 1.2;
                        if (rt <= 0 || rt >= 1) continue;
                        g.save();
                        g.strokeStyle = rgba(i === 1 ? light : main, 0.8 * (1 - rt));
                        g.lineWidth = 7 * (1 - rt) + 1;
                        g.shadowColor = main;
                        g.shadowBlur = 18;
                        g.beginPath();
                        g.ellipse(x, y, 20 + ease(rt) * 280, (20 + ease(rt) * 280) * 0.55, 0, 0, TAU);
                        g.stroke();
                        g.restore();
                    }
                    // The bolts of the storm, struck again every few frames
                    if (fx.style === 'bolt' && t < 1.8) {
                        if (now - boltAt > 70) {
                            boltAt = now;
                            bolts = Array.from({ length: 5 }, () => jagged(x, y, Math.random() * TAU, 120 + Math.random() * 180, 40));
                        }
                        for (const b of bolts) {
                            polyline(g, b, 5, rgba(main, 0.35), main);
                            polyline(g, b, 1.8, rgba('#ffffff', 0.9), main);
                        }
                    }
                    // The circle of runes, turning as it grows
                    if (fx.style === 'rune' && t < 2.8) {
                        const k = ease(t / 0.8), fade = t < 2 ? 1 : 1 - (t - 2) / 0.8;
                        g.save();
                        g.translate(x, y);
                        g.scale(1, 0.55);
                        g.rotate(t * 1.4);
                        g.strokeStyle = rgba(light, 0.85 * fade);
                        g.shadowColor = main;
                        g.shadowBlur = 16;
                        g.lineWidth = 2;
                        for (const rad of [90 * k, 70 * k]) { g.beginPath(); g.arc(0, 0, rad, 0, TAU); g.stroke(); }
                        for (let i = 0; i < 12; i++) {
                            const ang = i / 12 * TAU;
                            g.save();
                            g.rotate(ang);
                            g.translate(80 * k, 0);
                            g.beginPath();
                            g.moveTo(-4, -5); g.lineTo(4, 5); g.moveTo(4, -5); g.lineTo(0, 0); g.moveTo(-4, 2); g.lineTo(2, 6);
                            g.stroke();
                            g.restore();
                        }
                        g.beginPath();
                        for (let i = 0; i <= 5; i++) {
                            const ang = (i * 2) / 5 * TAU - Math.PI / 2;
                            const px = Math.cos(ang) * 60 * k, py = Math.sin(ang) * 60 * k;
                            i ? g.lineTo(px, py) : g.moveTo(px, py);
                        }
                        g.stroke();
                        g.restore();
                    }
                    for (const p of particles) {
                        stepParticle(p, fx.style, t, x, y);
                        const life = Math.min(1, t / p.life);
                        if (life < 1) drawParticle(g, p, fx.style === 'void' || fx.style === 'firefly' || fx.style === 'ember' ? 'dot' : fx.style, life);
                    }
                    // Motes drifting up as it all fades
                    if (t > 0.6 && t < 2.2 && Math.random() < 0.7) {
                        motes.push({ x: x + (Math.random() - 0.5) * 160, y: y + (Math.random() - 0.5) * 60, vx: 0, vy: -0.6 - Math.random(), size: 1 + Math.random() * 1.8, color: pick(fx.colors), alpha: 0.8, spin: 0, vs: 0, drag: 1, gravity: 0, born: t });
                    }
                    for (const m of motes) {
                        m.y += m.vy;
                        m.x += Math.sin(t * 3 + m.size) * 0.4;
                        drawParticle(g, m, 'dot', Math.min(1, (t - m.born) / 1.1));
                    }
                } else {
                    // The light dies: a dark pulse, the cracks, the smoke, a few sparks falling
                    const pl = Math.sin(Math.min(1, t / 0.9) * Math.PI);
                    const grad = g.createRadialGradient(x, y, 0, x, y, 140);
                    grad.addColorStop(0, `rgba(0,0,0,${0.55 * pl})`);
                    grad.addColorStop(0.6, rgba(dark, 0.35 * pl));
                    grad.addColorStop(1, 'rgba(0,0,0,0)');
                    g.fillStyle = grad;
                    g.fillRect(x - 140, y - 140, 280, 280);
                    const ck = Math.min(1, t / 0.35), cf = t < 0.9 ? 1 : Math.max(0, 1 - (t - 0.9) / 0.6);
                    for (const crack of cracks) {
                        const n = Math.max(2, Math.round(crack.length * ck));
                        polyline(g, crack.slice(0, n), 3, rgba('#000000', 0.7 * cf));
                        polyline(g, crack.slice(0, n), 1.2, rgba(main, 0.55 * cf), main);
                    }
                    for (const p of smoke) {
                        stepParticle(p, 'smoke', t, x, y);
                        p.size += 0.15;
                        drawParticle(g, p, 'smoke', Math.min(1, t / duration));
                    }
                    for (const p of sparks) {
                        stepParticle(p, 'dot', t, x, y);
                        drawParticle(g, p, 'dot', Math.min(1, t / 0.9));
                    }
                }
                if (t < duration) {
                    requestAnimationFrame(frame);
                } else {
                    g.setTransform(1, 0, 0, 1, 0, 0);
                    g.clearRect(0, 0, c.width, c.height);
                    c.classList.remove('shown');
                    done();
                }
            };
            requestAnimationFrame(frame);
        });
    }

    // The d20s of a throw, on the screen, with their natural result: the dice of the library in the order thrown
    function d20s(b, thrown) {
        const list = (b.diceList || []).filter(d => (d.shape || d.notation?.type || '') === 'd20');
        const faces = thrown.filter(d => d.sides === 20);
        return faces.map((f, i) => ({ face: f, die: list[i] || null }));
    }

    function hideLater(ms) {
        clearTimeout(hideTimer);
        hideTimer = setTimeout(() => {
            if (!layer) return;
            layer.classList.add('fading');
            stopPulse();
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
        const { text, thrown } = notation(dice);
        // The physics settles in one or two seconds; never wait longer than six
        const rolled = b.roll(text);
        if (special) startPulse(b, special);
        await Promise.race([rolled, new Promise(r => setTimeout(r, 6000))]);
        // A natural 20 or 1 of a d20 that counts (not the one set aside by advantage or disadvantage)
        const crits = special ? d20s(b, thrown).filter(x => !x.face.dropped && (x.face.value === 20 || x.face.value === 1)) : [];
        if (crits.length > 0) {
            const shown = crits.find(x => x.face.value === 20) || crits[0];
            const at = (shown.die && onScreen(b, shown.die)) || { x: innerWidth / 2, y: innerHeight / 2 };
            hideLater(3300);
            await critical(at.x, at.y, special.fx, shown.face.value === 20);
            return true;
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
        // The effect of a natural 20 (or 1) of a special die, in the middle of the screen: to see it in the settings
        critical(skin, high) {
            const special = specials[skin];
            if (!special || !available()) return Promise.resolve(false);
            return critical(innerWidth / 2, innerHeight / 2, special.fx, high !== false).then(() => true);
        },
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
