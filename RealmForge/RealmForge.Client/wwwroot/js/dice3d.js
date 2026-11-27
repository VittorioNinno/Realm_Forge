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
    // (fx). Ember, stardust and dawn are shown locked until found; the others are secret: shown nowhere until unlocked
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
        arcane: { foreground: '#ffe9a8', outline: '#120a30', background: '#2a1a5e', material: 'glass', glow: '#b48bff', glowIntensity: 0.5, pulse: 'rune', fx: { style: 'rune', colors: ['#ffe9a8', '#ffd166', '#b48bff', '#ffffff'], dark: '#120a30' } },
        dawn: { foreground: '#5a3a00', outline: '#fffbe8', background: '#f3d27a', material: 'metal', glow: '#ffd76a', glowIntensity: 0.4, pulse: 'sunrise', fx: { style: 'sun', colors: ['#ffffff', '#fff1b8', '#ffd76a', '#ffb347'], dark: '#4a3000' } },
        tide: { foreground: '#e6fbff', outline: '#031522', background: '#0e5a78', material: 'glass', glow: '#38d6ff', glowIntensity: 0.4, pulse: 'wave', fx: { style: 'wave', colors: ['#e6fbff', '#7fe3ff', '#1fb6e0', '#a7f3d0'], dark: '#031522' } }
    };

    let unlocked = new Set();
    let box = null, boxSound = null, look = null, layer = null, loading = null, hideTimer = null, fadeTimer = null, queue = Promise.resolve();
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

    // Dawn: pearl and gold, soft veins of light
    function dawnTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(131);
        ground(g, ['#fff6dc', '#f3d27a', '#d9a441'], true);
        for (let k = 0; k < 7; k++) {
            const path = walk(r, 6, 60);
            stroke(g, path, 6, 'rgba(255,255,255,0.35)', '#fff1b8', 10);
            stroke(g, path, 1.6, 'rgba(200,138,30,0.55)');
        }
        speckle(g, r, 120, () => `rgba(255,255,255,${0.4 + r() * 0.5})`, 1.5);
        return { name: 'rf-dawn', composite: 'source-over', texture: c, material: 'metal' };
    }

    // Tide: deep water with the light of the surface playing on it, a little foam
    function tideTexture() {
        const c = canvas(TEX), g = c.getContext('2d'), r = rnd(173);
        ground(g, ['#1a7a9a', '#0e5a78', '#062a44'], true);
        for (let k = 0; k < 16; k++) {
            const path = walk(r, 5, 46);
            stroke(g, path, 1.4, 'rgba(127,227,255,0.45)', '#38d6ff', 6);
        }
        speckle(g, r, 140, () => `rgba(230,251,255,${0.2 + r() * 0.5})`, 1.4);
        return { name: 'rf-tide', composite: 'source-over', texture: c, material: 'glass' };
    }

    const painters = { dawn: dawnTexture, tide: tideTexture, ember: emberTexture, stardust: stardustTexture, frost: frostTexture, storm: stormTexture, bone: boneTexture, hoard: hoardTexture, abyss: abyssTexture, fey: feyTexture, acid: acidTexture, arcane: arcaneTexture };

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
        rune: (t) => 0.6 + 0.8 * Math.pow(Math.max(0, Math.sin(t * 2.4)), 4),
        sunrise: (t) => 0.8 + 0.3 * Math.sin(t * 1.2),
        wave: (t) => 0.75 + 0.25 * Math.sin(t * 2) + 0.1 * Math.sin(t * 3.7)
    };

    let pulseOn = false;

    function startPulse(b, special) {
        const f = pulses[special.pulse];
        if (!f || pulseOn) return;
        pulseOn = true;
        const st = { until: 0, peak: 1 };
        const step = (now) => {
            if (!pulseOn) return;
            const k = Math.max(0.1, f(now / 1000, st) + critFlare);
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

    // ----- The critical moment: a natural 20 or 1 of the d20 of a special die -----
    //
    // Played in the space of the dice, not flat on the page: every point of the effect lives on the table or above it
    // (the box looks down on its table, z up) and is drawn through the camera of the dice, so the rings lie on the
    // table around the die, the light rises from the die towards the eye and the sparks grow as they come closer;
    // the die itself flares with the colour of the effect. A natural 20: the flare, rings across the table, a pillar of
    // light, the die's own burst (embers, stars, shards of ice, bolts, wisps, gold coins, a vortex, fireflies, drops of
    // acid, a magic circle drawn on the table), motes drifting up. A natural 1: the light dies: a shadow on the table,
    // cracks running out of the die, smoke rising, sparks falling back. About three seconds, on a canvas of its own.

    let fxCanvas = null;
    let critFlare = 0;
    let fxUnit = 34;
    let fxDie = false;

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
        // Rounded: a tiny alpha in exponent form (1e-17) is not a colour, and a gradient stop would throw
        return `rgba(${n >> 16},${(n >> 8) & 255},${n & 255},${(Math.max(0, Math.min(1, a)) || 0).toFixed(3)})`;
    }

    // The space of the effect: world points (in die radii, z up from the table under the die) to the screen, with the
    // scale of a point at that height. Through the camera of the box when there is a die; else a view from above in
    // the middle of the screen (the preview of the settings)
    function space(b, die) {
        try {
            if (b && die && b.camera && die.position) {
                const V = die.position.constructor;
                const geo = die.geometry;
                if (geo && !geo.boundingSphere && geo.computeBoundingSphere) geo.computeBoundingSphere();
                const R = (geo && geo.boundingSphere ? geo.boundingSphere.radius : 40) * (die.scale ? die.scale.x : 1);
                const rect = layer.getBoundingClientRect();
                const cam = b.camera.position;
                const base = { x: die.position.x, y: die.position.y, z: die.position.z - R * 0.9 };
                const toScreen = (x, y, z) => {
                    const v = new V(base.x + x * R, base.y + y * R, base.z + z * R).project(b.camera);
                    const dist = Math.max(1, cam.z - (base.z + z * R));
                    return { x: rect.left + (v.x + 1) / 2 * rect.width, y: rect.top + (1 - v.y) / 2 * rect.height, k: (cam.z - base.z) / dist };
                };
                const o = toScreen(0, 0, 0), e = toScreen(1, 0, 0);
                const px = Math.max(8, Math.hypot(e.x - o.x, e.y - o.y));
                return { P: toScreen, px };
            }
        } catch { }
        const cx = innerWidth / 2, cy = innerHeight / 2, px = 34, eye = 14;
        return { P: (x, y, z) => { const k = eye / Math.max(1, eye - z); return { x: cx + x * px * k, y: cy - y * px * k, k }; }, px };
    }

    // A shape lying on the table (z = 0): its outline through the camera
    function onTable(P, points, z = 0) {
        return points.map(([x, y]) => P(x, y, z));
    }

    function circle(r, n = 56) {
        return Array.from({ length: n + 1 }, (_, i) => [Math.cos(i / n * TAU) * r, Math.sin(i / n * TAU) * r]);
    }

    function path(g, pts, close) {
        g.beginPath();
        pts.forEach((q, i) => i ? g.lineTo(q.x, q.y) : g.moveTo(q.x, q.y));
        if (close) g.closePath();
    }

    function glowLine(g, pts, width, color, glow) {
        g.save();
        g.strokeStyle = color;
        g.lineWidth = width;
        g.lineJoin = 'round';
        g.lineCap = 'round';
        g.shadowColor = glow || color;
        g.shadowBlur = glow ? 16 : 0;
        path(g, pts);
        g.stroke();
        g.restore();
    }

    // A jagged line on the table or in the air, in die radii
    function jagged3(from, to, roughness, steps = 8) {
        const out = [];
        for (let i = 0; i <= steps; i++) {
            const t = i / steps, off = i === 0 || i === steps ? 0 : (Math.random() - 0.5) * roughness;
            out.push([from[0] + (to[0] - from[0]) * t + off, from[1] + (to[1] - from[1]) * t + off * 0.7, from[2] + (to[2] - from[2]) * t]);
        }
        return out;
    }

    // A particle drawn at its place on the screen, its size following its height
    function drawParticle(g, q, p, style, life) {
        const a = p.alpha * (1 - life);
        if (a <= 0.01) return;
        const s = Math.max(0.5, p.size * q.k);
        g.save();
        g.translate(q.x, q.y);
        g.rotate(p.spin);
        g.globalAlpha = Math.min(1, a);
        g.fillStyle = p.color;
        g.strokeStyle = p.color;
        g.shadowColor = p.color;
        g.shadowBlur = 12;
        switch (style) {
            case 'star':
                g.beginPath();
                for (let i = 0; i < 8; i++) {
                    const r = i % 2 ? s * 0.35 : s * 1.4, ang = i / 8 * TAU;
                    g.lineTo(Math.cos(ang) * r, Math.sin(ang) * r);
                }
                g.closePath();
                g.fill();
                break;
            case 'shard':
                g.beginPath();
                g.moveTo(0, -s * 2); g.lineTo(s * 0.55, 0); g.lineTo(0, s * 2); g.lineTo(-s * 0.55, 0);
                g.closePath();
                g.fill();
                break;
            case 'coin': {
                const w = Math.abs(Math.cos(p.flip)) * s * 1.4 + 0.8;
                g.beginPath();
                g.ellipse(0, 0, w, s * 1.4, 0, 0, TAU);
                g.fill();
                g.globalAlpha = Math.min(1, a * 0.8);
                g.fillStyle = '#fffbe6';
                g.beginPath();
                g.ellipse(-w * 0.3, -s * 0.4, w * 0.25, s * 0.35, 0, 0, TAU);
                g.fill();
                break;
            }
            case 'drop':
                g.beginPath();
                g.moveTo(0, -s * 1.7);
                g.quadraticCurveTo(s, 0, 0, s);
                g.quadraticCurveTo(-s, 0, 0, -s * 1.7);
                g.fill();
                break;
            case 'wisp':
            case 'smoke': {
                const grad = g.createRadialGradient(0, 0, 0, 0, 0, s * 2.6);
                grad.addColorStop(0, rgba(p.color, 0.85));
                grad.addColorStop(1, rgba(p.color, 0));
                g.fillStyle = grad;
                g.shadowBlur = 0;
                g.beginPath();
                g.arc(0, 0, s * 2.6, 0, TAU);
                g.fill();
                break;
            }
            case 'ring':
                g.lineWidth = 1.2;
                g.shadowBlur = 4;
                g.beginPath();
                g.arc(0, 0, s, 0, TAU);
                g.stroke();
                break;
            default:
                g.beginPath();
                g.arc(0, 0, s, 0, TAU);
                g.fill();
        }
        g.restore();
    }

    const clamp01 = (t) => Math.min(1, Math.max(0, t));
    const lerp = (a, b, t) => a + (b - a) * t;
    // 0 before a, rising to 1 by b, 1 until c, falling to 0 by d
    const span = (t, a, b, c, d) => t < a ? 0 : t < b ? (t - a) / (b - a) : t < c ? 1 : t < d ? 1 - (t - c) / (d - c) : 0;
    const turn = (a) => ([x, y]) => [x * Math.cos(a) - y * Math.sin(a), x * Math.sin(a) + y * Math.cos(a)];
    const shift = (dx, dy) => ([x, y]) => [x + dx, y + dy];

    // A soft light (or shadow) lying on the table
    function pool(g, P, x, y, r, inner, outer, z = 0) {
        const o = P(x, y, z), e = P(x + r, y, z);
        const rr = Math.max(1, Math.hypot(e.x - o.x, e.y - o.y));
        const grad = g.createRadialGradient(o.x, o.y, 0, o.x, o.y, rr);
        grad.addColorStop(0, inner);
        grad.addColorStop(1, outer);
        g.fillStyle = grad;
        path(g, onTable(P, circle(r, 40).map(shift(x, y)), z), true);
        g.fill();
    }

    // A glowing blob at a point of the space, its size in die radii
    function blob(g, q, r, color, a) {
        const rr = Math.max(0.5, r * fxUnit * q.k);
        const grad = g.createRadialGradient(q.x, q.y, 0, q.x, q.y, rr);
        grad.addColorStop(0, rgba(color, a));
        grad.addColorStop(1, rgba(color, 0));
        g.fillStyle = grad;
        g.fillRect(q.x - rr, q.y - rr, rr * 2, rr * 2);
    }

    // Clears the effect drawn so far where the die stands, so what lies on the table passes under the die
    function hole(g, P) {
        if (!fxDie) return;
        const q = P(0, 0, 1.2), r = fxUnit * q.k * 1.05;
        g.save();
        g.globalCompositeOperation = 'destination-out';
        const grad = g.createRadialGradient(q.x, q.y, r * 0.6, q.x, q.y, r);
        grad.addColorStop(0, 'rgba(0,0,0,1)');
        grad.addColorStop(1, 'rgba(0,0,0,0)');
        g.fillStyle = grad;
        g.fillRect(q.x - r, q.y - r, r * 2, r * 2);
        g.restore();
    }

    function line3(g, P, pts, width, color, glow) {
        glowLine(g, pts.map(([x, y, z]) => P(x, y, z)), width, color, glow);
    }

    function particle(o) {
        return { x: 0, y: 0, z: 1, vx: 0, vy: 0, vz: 0, g: 0, drag: 1, size: 2, color: '#ffffff', alpha: 1, spin: Math.random() * TAU, vs: 0, flip: Math.random() * TAU, life: 1, born: 0, bounce: false, ...o };
    }

    function step(p, dt) {
        const d = Math.pow(p.drag, dt);
        p.vx *= d; p.vy *= d;
        p.vz += p.g * dt;
        p.x += p.vx * dt; p.y += p.vy * dt; p.z += p.vz * dt;
        if (p.z < 0) {
            p.z = 0;
            if (p.bounce && p.vz < -1.5) { p.vz = -p.vz * 0.35; p.vx *= 0.6; p.vy *= 0.6; }
            else { p.vz = 0; p.vx *= 0.85; p.vy *= 0.85; }
        }
        p.spin += p.vs * dt;
        p.flip += 9 * dt;
    }

    // Steps and draws a list of particles, dropping the spent ones
    function run(g, P, list, t, dt, style) {
        for (let i = list.length - 1; i >= 0; i--) {
            const p = list[i], life = (t - p.born) / p.life;
            if (life >= 1) { list.splice(i, 1); continue; }
            step(p, dt);
            drawParticle(g, P(p.x, p.y, p.z), p, p.style || style, life);
        }
    }

    // A small rune of strokes, in the plane, around (cx, cy)
    function glyph(seed, cx, cy, s) {
        const r = (n) => { const v = Math.sin(seed * 12.9898 + n * 78.233) * 43758.5453; return v - Math.floor(v); };
        const pts = [[cx, cy - s]];
        for (let i = 0; i < 3; i++) pts.push([cx + (r(i) - 0.5) * s * 2, cy + (r(i + 7) - 0.5) * s * 2]);
        pts.push([cx, cy + s]);
        return pts;
    }

    // A soft round light of a colour, painted once and stamped many times: fire and mist are hundreds of them
    const sprites = {};
    function glowSprite(color) {
        if (sprites[color]) return sprites[color];
        const c = document.createElement('canvas');
        c.width = c.height = 64;
        const x = c.getContext('2d');
        const grad = x.createRadialGradient(32, 32, 0, 32, 32, 32);
        grad.addColorStop(0, rgba(color, 1));
        grad.addColorStop(0.35, rgba(color, 0.55));
        grad.addColorStop(1, rgba(color, 0));
        x.fillStyle = grad;
        x.fillRect(0, 0, 64, 64);
        return (sprites[color] = c);
    }

    function stamp(g, q, r, color, a) {
        if (a <= 0.005 || r < 0.5) return;
        g.globalAlpha = Math.min(1, a);
        g.drawImage(glowSprite(color), q.x - r, q.y - r, r * 2, r * 2);
        g.globalAlpha = 1;
    }

    // A tongue of fire standing at q (on the screen), h high and w wide in pixels, its tip leaning by wob
    function tongue(g, q, h, w, wob, a, fx) {
        if (h < 1 || a <= 0.01) return;
        g.save();
        g.translate(q.x, q.y);
        g.globalAlpha = Math.min(1, a);
        const grad = g.createLinearGradient(0, 0, 0, -h);
        grad.addColorStop(0, rgba(fx.colors[0], 0.95));
        grad.addColorStop(0.3, rgba(fx.colors[3], 0.9));
        grad.addColorStop(0.65, rgba(fx.colors[1], 0.75));
        grad.addColorStop(1, rgba(fx.colors[2], 0));
        g.fillStyle = grad;
        g.beginPath();
        g.moveTo(-w / 2, 0);
        g.bezierCurveTo(-w / 2, -h * 0.45, wob * w - w * 0.2, -h * 0.65, wob * w, -h);
        g.bezierCurveTo(wob * w + w * 0.2, -h * 0.65, w / 2, -h * 0.45, w / 2, 0);
        g.quadraticCurveTo(0, w * 0.3, -w / 2, 0);
        g.fill();
        g.restore();
    }

    // A star of four long rays and a soft halo, at a point of the screen
    function sparkle(g, x, y, s, color, a) {
        if (a <= 0.01 || s <= 0) return;
        g.save();
        g.translate(x, y);
        g.globalAlpha = Math.min(1, a);
        const grad = g.createRadialGradient(0, 0, 0, 0, 0, s * 2.4);
        grad.addColorStop(0, rgba(color, 0.6));
        grad.addColorStop(1, rgba(color, 0));
        g.fillStyle = grad;
        g.fillRect(-s * 2.4, -s * 2.4, s * 4.8, s * 4.8);
        g.fillStyle = '#ffffff';
        g.beginPath();
        g.moveTo(0, -s * 2); g.lineTo(s * 0.2, -s * 0.2); g.lineTo(s * 2, 0); g.lineTo(s * 0.2, s * 0.2);
        g.lineTo(0, s * 2); g.lineTo(-s * 0.2, s * 0.2); g.lineTo(-s * 2, 0); g.lineTo(-s * 0.2, -s * 0.2);
        g.closePath();
        g.fill();
        g.restore();
    }

    // A bolt on the screen from a to b: each segment split, its middle pushed aside, the push halving at each level;
    // a few branches leave it. Lines of points; a branch is marked
    function bolt2(a, b, spread, depth, branches) {
        let pts = [a, b];
        for (let d = 0; d < depth; d++) {
            const next = [pts[0]];
            for (let i = 1; i < pts.length; i++) {
                const p = pts[i - 1], q = pts[i], len = Math.hypot(q.x - p.x, q.y - p.y) || 1;
                const off = (Math.random() - 0.5) * spread * len;
                next.push({ x: (p.x + q.x) / 2 - (q.y - p.y) / len * off, y: (p.y + q.y) / 2 + (q.x - p.x) / len * off }, q);
            }
            pts = next;
        }
        const out = [pts];
        for (let i = 0; i < branches; i++) {
            const from = pts[Math.floor(pts.length * (0.2 + Math.random() * 0.55))];
            const ang = Math.atan2(b.y - a.y, b.x - a.x) + (Math.random() > 0.5 ? 1 : -1) * (0.35 + Math.random() * 0.5);
            const len = Math.hypot(b.x - a.x, b.y - a.y) * (0.15 + Math.random() * 0.25);
            const branch = bolt2(from, { x: from.x + Math.cos(ang) * len, y: from.y + Math.sin(ang) * len }, spread, Math.max(2, depth - 2), 0)[0];
            branch.branch = true;
            out.push(branch);
        }
        return out;
    }

    // A bolt drawn as light: a wide faint aura, a coloured glow, a white core
    function drawBolt(g, lines, fx, a) {
        if (a <= 0.01) return;
        for (const [w, color, blur] of [[10, rgba(fx.colors[2], 0.16 * a), 0], [4, rgba(fx.colors[1], 0.55 * a), 14], [1.6, rgba('#ffffff', 0.95 * a), 6]]) {
            g.save();
            g.strokeStyle = color;
            g.lineJoin = 'round';
            g.lineCap = 'round';
            g.shadowColor = fx.colors[2];
            g.shadowBlur = blur;
            for (const l of lines) {
                g.lineWidth = l.branch ? w * 0.5 : w;
                path(g, l);
                g.stroke();
            }
            g.restore();
        }
    }

    // ----- One effect for each die: (ctx) => a frame (t, dt) drawn in the space of the die -----
    // ctx: g (the canvas), P (world → screen), fx (the colours), high (a natural 20, else a natural 1)

    const effects = {
        // The breath of the dragon: fire pours out of the die across the table in a cone that sweeps from one side to the
        // other. A flame is many small soft lights, white-hot where they leave, cooling to yellow, orange and a dark red
        // as they spread, slow down and rise; smoke and sparks come off it and the table is scorched where it passed.
        // A 1: the flame sputters out in a puff of black smoke and ash
        ember({ g, P, fx, high }) {
            const flames = [], embers = [], smoke = [], scorch = [];
            const a0 = Math.random() * TAU;
            const heat = ['#fff4d6', '#ffd257', '#ff8a1f', '#e2460c', '#7a1a06'];
            const heatAt = (age) => heat[Math.min(heat.length - 1, Math.floor(Math.pow(age, 0.8) * heat.length))];
            if (!high) {
                for (let i = 0; i < 26; i++) smoke.push(particle({ x: (Math.random() - 0.5) * 0.6, y: (Math.random() - 0.5) * 0.6, z: 1, vx: (Math.random() - 0.5) * 0.6, vy: (Math.random() - 0.5) * 0.6, vz: 1 + Math.random() * 1.5, drag: 0.6, size: 5 + Math.random() * 5, color: Math.random() > 0.3 ? '#a39a93' : '#b08a6a', alpha: 0.55, born: 0.25 + Math.random() * 0.4, life: 1.6 }));
                for (let i = 0; i < 30; i++) embers.push(particle({ x: (Math.random() - 0.5) * 5, y: (Math.random() - 0.5) * 5, z: 4 + Math.random() * 4, vz: -1.2 - Math.random(), vx: (Math.random() - 0.5) * 0.6, drag: 0.8, size: 0.9, color: Math.random() > 0.7 ? fx.colors[2] : '#6b6460', alpha: 0.8, born: 0.3, life: 1.8 }));
            }
            return (t, dt) => {
                if (high) {
                    const sweep = ease(clamp01((t - 0.12) / 1.35)), dir = a0 - 0.6 + sweep * 1.2;
                    const breathing = t > 0.1 && t < 1.5;
                    // The table scorched where the fire passed: soft dark marks where the flames died down
                    const burn = span(t, 0.25, 0.7, 2.3, 2.95);
                    if (burn > 0) {
                        g.globalCompositeOperation = 'source-over';
                        for (const m of scorch) {
                            const q = P(m.x, m.y, 0);
                            stamp(g, q, m.r * fxUnit * q.k, '#140600', 0.16 * burn);
                        }
                    }
                    g.globalCompositeOperation = 'screen';
                    if (breathing) pool(g, P, Math.cos(dir) * 2.6, Math.sin(dir) * 2.6, 3.2, 'rgba(255,110,20,0.12)', 'rgba(255,60,0,0)');
                    hole(g, P);
                    // The jet: each flame is a disc (and a faint halo three times wider) that leaves the die along the line
                    // of the breath, shrinks as it goes and rises, its colour cooling from yellow to red; pulled back to a
                    // line that writhes, so the fire has a body that tapers into ragged tongues, not a round glow
                    // The light the fire throws on the table, following where it reaches
                    if (breathing) pool(g, P, Math.cos(dir) * 4.2, Math.sin(dir) * 4.2, 3.6, 'rgba(255,120,30,0.1)', 'rgba(255,60,0,0)');
                    if (breathing) {
                        // The core: smaller, faster, white-hot, dying young; and now and then a flame that peels off the
                        // side of the jet and curls upward on its own
                        for (let i = 0; i < 7; i++) {
                            flames.push({ d: 0.8, o: (Math.random() - 0.5) * 0.15, z: 1.1, vd: 12 + Math.random() * 3, vo: (Math.random() - 0.5) * 0.6, vz: 0, dir, born: t, life: 0.25 + Math.random() * 0.15, r: 0.2 + Math.random() * 0.08, h: 4, ta: 0.9, ph: 0, core: true });
                        }
                        if (Math.random() < 0.35) {
                            const side = Math.random() > 0.5 ? 1 : -1;
                            flames.push({ d: 1.5 + Math.random() * 2, o: side * (0.4 + Math.random() * 0.3), z: 1.2, vd: 3, vo: side * 2.2, vz: 2.2, dir, born: t, life: 0.7, r: 0.4, h: -4, ta: 0.75, ph: 0, curl: true });
                        }
                        for (let i = 0; i < 18; i++) {
                            flames.push({ d: 0.8 + Math.random() * 0.3, o: (Math.random() - 0.5) * 0.4, z: 1 + Math.random() * 0.3, vd: 9 + Math.random() * 4, vo: (Math.random() - 0.5) * 2, vz: Math.random() * 0.4, dir, born: t, life: 0.6 + Math.random() * 0.4, r: 0.36 + Math.random() * 0.22, h: Math.random() * 10 - 5, ta: 0.8 + Math.random() * 0.1, ph: Math.random() * TAU });
                        }
                    }
                    const drag = Math.pow(0.42, dt);
                    for (let i = flames.length - 1; i >= 0; i--) {
                        const f = flames[i], age = (t - f.born) / f.life;
                        const fx0 = Math.cos(f.dir), fy0 = Math.sin(f.dir);
                        const x = fx0 * f.d - fy0 * f.o, y = fy0 * f.d + fx0 * f.o;
                        if (age >= 1) {
                            flames.splice(i, 1);
                            if (scorch.length < 140 && Math.random() < 0.25) scorch.push({ x, y, r: 0.6 + Math.random() * 0.5 });
                            if (smoke.length < 70 && Math.random() < 0.08) smoke.push(particle({ x, y, z: f.z, vx: fx0 * f.vd * 0.15, vy: fy0 * f.vd * 0.15, vz: 0.8 + Math.random(), drag: 0.6, size: 6 + Math.random() * 6, color: '#3d3531', alpha: 0.3, born: t, life: 1.4 }));
                            continue;
                        }
                        // The line it is pulled to writhes, and splits into a few tongues further out
                        const axis = Math.sin(f.d * 1.5 - t * 8) * 0.3 * f.d + Math.sin(f.ph) * Math.max(0, f.d - 2) * 0.35;
                        if (!f.curl) f.vo += (axis - f.o) * 6 / (1 + f.d * 0.6) * dt + (Math.random() - 0.5) * (6 + f.d * 5) * dt;
                        else f.vo *= Math.pow(0.4, dt);
                        f.vd *= drag;
                        f.vz += 2.6 * dt;
                        f.d += f.vd * dt; f.o += f.vo * dt; f.z += f.vz * dt;
                        const q = P(x, y, f.z), r = f.r * (1 - age * 0.85) * (0.7 + Math.min(1, f.d / 3) * 0.5) * fxUnit * q.k;
                        if (r < 0.4) continue;
                        const a = (age < 0.15 ? age / 0.15 : age > 0.75 ? (1 - age) / 0.25 : 1) * f.ta;
                        const hue = Math.min(40, Math.max(0, 36 - age * 36 + f.h)), light = (f.core ? 66 : 54) - age * 12;
                        g.fillStyle = `hsla(${hue.toFixed(0)},100%,${light.toFixed(0)}%,${(a / 40).toFixed(3)})`;
                        g.beginPath(); g.arc(q.x, q.y, r * 3, 0, TAU); g.fill();
                        g.fillStyle = `hsla(${hue.toFixed(0)},100%,${light.toFixed(0)}%,${(a * 0.22).toFixed(3)})`;
                        g.beginPath(); g.arc(q.x, q.y, r, 0, TAU); g.fill();
                        if (embers.length < 90 && Math.random() < 0.01) embers.push(particle({ x, y, z: f.z, vx: fx0 * f.vd * 0.3 + (Math.random() - 0.5), vy: fy0 * f.vd * 0.3 + (Math.random() - 0.5), vz: 1.5 + Math.random() * 2, g: -1.5, drag: 0.7, size: 0.9 + Math.random() * 0.8, color: pick(['#ffd27a', '#ff9a3c', '#ff6a1a']), born: t, life: 0.8 + Math.random() * 0.8 }));
                    }
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, smoke, t, dt, 'smoke');
                    g.globalCompositeOperation = 'lighter';
                    run(g, P, embers, t, dt, 'dot');
                } else {
                    g.globalCompositeOperation = 'lighter';
                    // A ring of fire round the die gutters out, cooling from orange to grey ash
                    const cool = clamp01(t / 1.1), ringFade = 1 - clamp01((t - 1.1) / 0.8);
                    if (ringFade > 0) {
                        const ring = circle(2.4 - cool * 0.6, 48).map(([x, y]) => [x * (1 + (Math.random() - 0.5) * 0.06), y * (1 + (Math.random() - 0.5) * 0.06), 0]);
                        g.globalCompositeOperation = 'source-over';
                        line3(g, P, ring, 5, rgba('#2a2320', 0.7 * ringFade));
                        g.globalCompositeOperation = 'lighter';
                        line3(g, P, ring, 2.2, rgba(cool < 0.6 ? fx.colors[1] : '#8a7f78', (1 - cool * 0.7) * ringFade), cool < 0.6 ? fx.colors[2] : null);
                    }
                    const flick = t < 0.8 ? (0.4 + Math.random() * 0.6) * (1 - t / 0.8) : 0;
                    if (flick > 0) { blob(g, P(0, 0, 1.4), 1.1, fx.colors[1], flick); blob(g, P(0, 0, 1.8 + Math.random() * 0.4), 0.5, fx.colors[0], flick); }
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, smoke, t, dt, 'smoke');
                    run(g, P, embers, t, dt, 'dot');
                }
            };
        },

        // The Plough lights up above the die, star by star, its lines drawn between them, while little lights crackle
        // round the die; it flares, and a falling star leaves it and strikes the die in a burst of stars. A 1: the stars come out dim and fall one after another
        stardust({ g, P, fx, high }) {
            // Three stars of the handle, four of the bowl (in die radii, y up, above the die)
            const plough = [[-3.3, 1.3], [-2.25, 1.05], [-1.25, 0.75], [-0.25, 0.85], [0.05, -0.35], [1.65, -0.5], [1.85, 0.75]];
            const links = [[0, 1], [1, 2], [2, 3], [3, 4], [4, 5], [5, 6], [6, 3]];
            const sky = Array.from({ length: 36 }, () => ({ x: (Math.random() - 0.5) * 12, y: (Math.random() - 0.5) * 8, ph: Math.random() * TAU, s: 0.6 + Math.random() * 0.8 }));
            const falls = plough.map((_, i) => ({ at: 0.75 + i * 0.12, vy: 0, dy: 0 }));
            const sparks = [], pops = [];
            let struck = false, next = 0.15;
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                const o = P(0, 0, 1.2), u = fxUnit * o.k;
                const at = ([x, y], dy = 0) => ({ x: o.x + x * u, y: o.y - (y + 2.9) * u + dy });
                const fade = 1 - clamp01((t - (high ? 2.2 : 1.8)) / 0.6);
                // A faint sky behind
                for (const s of sky) {
                    const a = (0.25 + 0.25 * Math.sin(t * 5 + s.ph)) * clamp01(t / 0.4) * fade * (high ? 1 : 0.5);
                    g.fillStyle = rgba(fx.colors[2], a);
                    g.beginPath(); g.arc(o.x + s.x * u, o.y + s.y * u - 1.5 * u, s.s, 0, TAU); g.fill();
                }
                if (high) {
                    // The crackle: little stars popping round the die, each throwing a few sparks
                    if (t < 1.4 && t >= next) {
                        next = t + 0.09 + Math.random() * 0.08;
                        const a = Math.random() * TAU, d = 1.3 + Math.random() * 2.6, z = 0.5 + Math.random() * 2.2, color = pick(fx.colors);
                        pops.push({ x: Math.cos(a) * d, y: Math.sin(a) * d, z, born: t, color, size: 2.4 + Math.random() * 2 });
                        for (let i = 0; i < 7; i++) {
                            const b = Math.random() * TAU, sp = 1 + Math.random() * 2;
                            sparks.push(particle({ x: Math.cos(a) * d, y: Math.sin(a) * d, z, vx: Math.cos(b) * sp, vy: Math.sin(b) * sp, vz: (Math.random() - 0.3) * sp, g: -3, drag: 0.35, size: 1 + Math.random() * 0.6, color: Math.random() > 0.4 ? color : '#ffffff', born: t, life: 0.4 + Math.random() * 0.25 }));
                        }
                    }
                    for (let i = pops.length - 1; i >= 0; i--) {
                        const p = pops[i], k = (t - p.born) / 0.28;
                        if (k >= 1) { pops.splice(i, 1); continue; }
                        const q = P(p.x, p.y, p.z);
                        sparkle(g, q.x, q.y, p.size * (0.6 + 0.6 * ease(k)) * q.k, p.color, k < 0.2 ? k / 0.2 : 1 - (k - 0.2) / 0.8);
                    }
                    const flare = span(t, 1.15, 1.3, 1.4, 1.7);
                    links.forEach(([a, b], i) => {
                        const k = clamp01((t - 0.55 - i * 0.09) / 0.2);
                        if (k <= 0) return;
                        const A = at(plough[a]), B = at(plough[b]);
                        glowLine(g, [A, { x: lerp(A.x, B.x, k), y: lerp(A.y, B.y, k) }], 1.3 + flare, rgba(fx.colors[2], (0.7 + 0.3 * flare) * fade), fx.colors[2]);
                    });
                    plough.forEach((p, i) => {
                        const k = ease(clamp01((t - 0.1 - i * 0.08) / 0.2));
                        const q = at(p), tw = 0.85 + 0.15 * Math.sin(t * 9 + i);
                        sparkle(g, q.x, q.y, (3.2 + flare * 2.5) * k * (i === 6 ? 1.25 : 1), fx.colors[i % 2 ? 3 : 1], tw * k * fade);
                    });
                    // The falling star: from the end of the bowl down to the die
                    const k = clamp01((t - 1.4) / 0.3);
                    if (k > 0 && k < 1) {
                        const A = at(plough[6]);
                        const pos = (v) => ({ x: lerp(A.x, o.x, ease(v)), y: lerp(A.y, o.y, v * v) });
                        glowLine(g, Array.from({ length: 10 }, (_, i) => pos(Math.max(0, k - i * 0.035))), 3, rgba(fx.colors[0], 0.95), fx.colors[3]);
                        const h = pos(k);
                        sparkle(g, h.x, h.y, 5, fx.colors[1], 1);
                    }
                    if (k >= 1 && !struck) {
                        struck = true;
                        for (let i = 0; i < 46; i++) {
                            const a = Math.random() * TAU, sp = 2 + Math.random() * 5;
                            sparks.push(particle({ vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 2 + Math.random() * 5, g: -5, drag: 0.5, size: 1.4 + Math.random() * 1.4, color: pick(fx.colors), born: t, life: 1 + Math.random() * 0.6 }));
                        }
                    }
                    const ring = clamp01((t - 1.72) / 0.9);
                    if (ring > 0 && ring < 1) line3(g, P, circle(0.8 + ease(ring) * 5.5).map(([x, y]) => [x, y, 0]), 3 * (1 - ring) + 0.5, rgba(fx.colors[3], 0.8 * (1 - ring)), fx.colors[2]);
                    hole(g, P);
                    run(g, P, sparks, t, dt, 'star');
                } else {
                    plough.forEach((p, i) => {
                        const f = falls[i];
                        if (t > f.at) { f.vy += 900 * dt; f.dy += f.vy * dt; }
                        const q = at(p, f.dy), k = clamp01((t - 0.1 - i * 0.06) / 0.2);
                        const a = k * 0.6 * fade * (1 - clamp01(f.dy / (u * 6)));
                        if (f.dy > 0) glowLine(g, [q, { x: q.x, y: q.y - Math.min(40, f.vy * 0.05) }], 1.5, rgba(fx.colors[2], a * 0.6));
                        sparkle(g, q.x, q.y, 2.4 * k, fx.colors[2], a);
                    });
                }
            };
        },

        // A snowflake of frost grows on the table out of the die, its six arms branching alike; snow falls.
        // A 1: a ring of ice forms, cracks and bursts into shards
        frost({ g, P, fx, high }) {
            const segs = [];
            const grow = (x, y, a, len, depth, t0) => {
                const x2 = x + Math.cos(a) * len, y2 = y + Math.sin(a) * len;
                segs.push({ a: [x, y], b: [x2, y2], t0, d: depth });
                if (depth < 3) {
                    grow(x2, y2, a + 0.62, len * 0.55, depth + 1, t0 + 0.12);
                    grow(x2, y2, a - 0.62, len * 0.55, depth + 1, t0 + 0.12);
                    grow(x2, y2, a, len * 0.7, depth + 1, t0 + 0.12);
                }
            };
            // One arm, the same six times round the die: a snowflake, not a thicket
            grow(0.7, 0, 0, 1.45, 0, 0.05);
            const arm = segs.splice(0, segs.length);
            for (let i = 0; i < 6; i++) {
                const r = turn(i / 6 * TAU);
                for (const sg of arm) segs.push({ a: r(sg.a), b: r(sg.b), t0: sg.t0, d: sg.d });
            }
            const snow = high ? Array.from({ length: 60 }, () => particle({ x: (Math.random() - 0.5) * 12, y: (Math.random() - 0.5) * 9, z: 3 + Math.random() * 5, vz: -1.2 - Math.random() * 0.8, size: 1.2 + Math.random() * 1.2, color: '#ffffff', alpha: 0.85, vs: 1, born: 0.2, life: 2.7 })) : [];
            const cracks = Array.from({ length: 9 }, (_, i) => { const a = i / 9 * TAU + Math.random() * 0.3; return jagged3([Math.cos(a) * 0.8, Math.sin(a) * 0.8, 0], [Math.cos(a) * 2.9, Math.sin(a) * 2.9, 0], 0.4, 6); });
            const shards = [], mist = [];
            let burst = false;
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                if (high) {
                    const fade = 1 - clamp01((t - 2.2) / 0.7);
                    pool(g, P, 0, 0, 4.5, rgba(fx.colors[2], 0.35 * fade), rgba(fx.colors[2], 0));
                    // One stroke for each depth of the ferns (a glow on each of hundreds of strokes is too slow)
                    for (let d = 0; d <= 3; d++) {
                        g.save();
                        g.strokeStyle = rgba(fx.colors[1], 0.85 * fade);
                        g.lineWidth = 2.2 - d * 0.45;
                        g.lineCap = 'round';
                        g.shadowColor = fx.colors[2];
                        g.shadowBlur = d < 2 ? 12 : 0;
                        g.beginPath();
                        for (const sgm of segs) {
                            if (sgm.d !== d) continue;
                            const k = clamp01((t - sgm.t0) / 0.14);
                            if (k <= 0) continue;
                            const a = P(sgm.a[0], sgm.a[1], 0), b = P(lerp(sgm.a[0], sgm.b[0], k), lerp(sgm.a[1], sgm.b[1], k), 0);
                            g.moveTo(a.x, a.y);
                            g.lineTo(b.x, b.y);
                        }
                        g.stroke();
                        g.restore();
                    }
                    hole(g, P);
                    g.globalCompositeOperation = 'lighter';
                    for (const p of snow) { p.x += Math.sin(t * 2 + p.spin) * 0.6 * dt; }
                    run(g, P, snow, t, dt, 'dot');
                } else {
                    const ring = ease(clamp01(t / 0.35)), fade = 1 - clamp01((t - 0.55) / 0.2);
                    if (fade > 0) {
                        g.globalCompositeOperation = 'source-over';
                        g.fillStyle = rgba(fx.colors[3], 0.35 * fade);
                        path(g, onTable(P, circle(2.9 * ring)), true); g.fill();
                        line3(g, P, circle(2.9 * ring).map(([x, y]) => [x, y, 0]), 2, rgba('#ffffff', 0.9 * fade), fx.colors[2]);
                        if (t > 0.35) for (const c of cracks) line3(g, P, c.slice(0, Math.max(2, Math.round(c.length * clamp01((t - 0.35) / 0.15)))), 1.6, rgba(fx.dark, 0.9 * fade));
                    }
                    if (t > 0.6 && !burst) {
                        burst = true;
                        for (let i = 0; i < 40; i++) {
                            const a = Math.random() * TAU, r = 0.8 + Math.random() * 2, sp = 2 + Math.random() * 4;
                            shards.push(particle({ x: Math.cos(a) * r, y: Math.sin(a) * r, z: 0.2, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 2 + Math.random() * 4, g: -14, bounce: true, drag: 0.5, size: 1.6 + Math.random() * 1.5, vs: (Math.random() - 0.5) * 10, color: pick(fx.colors), born: t, life: 1.3 }));
                        }
                        for (let i = 0; i < 14; i++) mist.push(particle({ x: (Math.random() - 0.5) * 4, y: (Math.random() - 0.5) * 4, z: 0.3, vz: 0.5, drag: 0.6, size: 4, color: fx.colors[3], alpha: 0.25, born: t, life: 1.4 }));
                    }
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, mist, t, dt, 'smoke');
                    run(g, P, shards, t, dt, 'shard');
                }
            };
        },

        // Branched lightning strikes the die from the sky four times, the scene flashing, and runs over the table in
        // crackling arcs; small arcs crawl over the die between the strikes. A 1: rain, and the one bolt misses the die
        storm({ g, P, fx, high }) {
            const strikes = high ? [0.05, 0.42, 0.85, 1.35] : [0.45];
            const target = high ? [0, 0] : [2.6 + Math.random(), -2 + Math.random()];
            const sparks = [], splashes = [];
            const rain = high ? [] : Array.from({ length: 160 }, () => ({ x: (Math.random() - 0.5) * 9, y: (Math.random() - 0.5) * 7, z: Math.random() * 10, v: 16 + Math.random() * 6 }));
            const cloud = high ? [] : Array.from({ length: 9 }, () => ({ x: (Math.random() - 0.5) * 5 - 1, y: (Math.random() - 0.5) * 4, z: 7 + Math.random() * 2, r: 2.2 + Math.random() * 1.6 }));
            let lines = [], at = -1, flash = 0;
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                const live = strikes.find(s => t >= s && t < s + 0.2);
                if (live !== undefined) {
                    // A new shape every 60 ms while it lasts: the bolt flickers
                    if (performance.now() - at > 60) {
                        at = performance.now();
                        const q = P(target[0], target[1], high ? 1.2 : 0);
                        const from = { x: q.x + (Math.random() - 0.5) * Math.min(innerWidth, 700) * 0.35, y: -20 };
                        lines = bolt2(from, { x: q.x, y: q.y }, 0.42, 7, high ? 3 : 1);
                        if (high) for (let i = 0; i < 4; i++) {
                            const a = Math.random() * TAU, l = 2.4 + Math.random() * 2.4;
                            lines.push(...bolt2(P(0, 0, 0.3), P(Math.cos(a) * l, Math.sin(a) * l, 0), 0.5, 5, 1).map(x => (x.branch = true, x)));
                        }
                        if (sparks.length < 120) for (let i = 0; i < 10; i++) { const a = Math.random() * TAU, sp = 2 + Math.random() * 5; sparks.push(particle({ x: target[0], y: target[1], z: 0.5, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 2 + Math.random() * 4, g: -14, bounce: true, drag: 0.5, size: 1, color: pick(fx.colors), born: t, life: 0.7 })); }
                        flash = 1;
                    }
                    pool(g, P, target[0], target[1], high ? 5 : 3, rgba(fx.colors[2], 0.4), rgba(fx.colors[2], 0));
                    drawBolt(g, lines, fx, 1 - (t - live) / 0.25);
                }
                // The whole scene lights for an instant at each strike
                flash = Math.max(0, flash - dt * 7);
                if (flash > 0.01) {
                    g.fillStyle = rgba(fx.colors[1], 0.1 * flash);
                    g.fillRect(0, 0, innerWidth, innerHeight);
                }
                if (high) {
                    const k = span(t, 0.1, 0.3, 1.8, 2.5);
                    if (k > 0) {
                        pool(g, P, 0, 0, 3, rgba(fx.colors[2], 0.2 * k), rgba(fx.colors[2], 0));
                        hole(g, P);
                        if (Math.random() < 0.45) {
                            const a = Math.random() * TAU;
                            drawBolt(g, bolt2(P(Math.cos(a) * 1.05, Math.sin(a) * 1.05, 0.7), P(Math.cos(a + 1) * 1.05, Math.sin(a + 1) * 1.05, 1.1), 0.7, 4, 0), fx, 0.7 * k);
                        }
                    }
                } else {
                    g.globalCompositeOperation = 'source-over';
                    const fade = 1 - clamp01((t - 1.6) / 0.6);
                    pool(g, P, 0, 0, 4.5, `rgba(0,0,0,${(0.5 * fade).toFixed(3)})`, 'rgba(0,0,0,0)');
                    hole(g, P);
                    // The cloud: heavy, drifting just above the die
                    for (const c of cloud) {
                        c.x += 0.4 * dt;
                        const q = P(c.x, c.y, c.z), r = c.r * fxUnit * q.k, a = 0.4 * fade * clamp01(t / 0.3);
                        const grad = g.createRadialGradient(q.x, q.y, 0, q.x, q.y, r);
                        grad.addColorStop(0, `rgba(40,48,62,${a.toFixed(3)})`);
                        grad.addColorStop(1, 'rgba(40,48,62,0)');
                        g.fillStyle = grad;
                        g.fillRect(q.x - r, q.y - r, r * 2, r * 2);
                    }
                    g.globalCompositeOperation = 'lighter';
                    // Zapped: after the miss, small arcs crawl over the die and fizzle
                    if (t > 0.6 && t < 1.5 && Math.random() < 0.6) {
                        const a = Math.random() * TAU;
                        drawBolt(g, bolt2(P(Math.cos(a) * 0.9, Math.sin(a) * 0.9, 1.2), P(Math.cos(a + 1.4) * 0.9, Math.sin(a + 1.4) * 0.9, 1.4), 0.6, 4, 0), fx, 0.7);
                    }
                    for (const d of rain) {
                        d.z -= d.v * dt;
                        if (d.z < 0) { if (splashes.length < 80) splashes.push({ x: d.x, y: d.y, born: t }); d.z += 10; }
                        line3(g, P, [[d.x, d.y, d.z], [d.x, d.y, d.z + 2.4]], 1.2, rgba(fx.colors[1], 0.6 * fade));
                    }
                    for (let i = splashes.length - 1; i >= 0; i--) {
                        const sp = splashes[i], k = (t - sp.born) / 0.35;
                        if (k >= 1) { splashes.splice(i, 1); continue; }
                        line3(g, P, circle(0.08 + k * 0.32, 12).map(([x, y]) => [x + sp.x, y + sp.y, 0]), 1.2, rgba(fx.colors[1], 0.6 * (1 - k) * fade));
                    }
                }
                run(g, P, sparks, t, dt, 'dot');
            };
        },

        // The dead answer: souls rise out of the table round the die, pale wisps of light with long tails that sway and
        // spiral upward through a low mist, shedding motes, and fade into the dark. A 1: the ground cracks and the souls
        // are dragged down into it, bone chips flying
        bone({ g, P, fx, high }) {
            const pale = '#eefff8', mid = '#a8f2d6', tail = '#4fcfa4';
            const count = high ? 9 : 6;
            const souls = Array.from({ length: count }, (_, i) => ({
                a: i / count * TAU + Math.random() * 0.5, r: 1.5 + Math.random() * 1.5, at: 0.05 + i * (high ? 0.11 : 0.08) + Math.random() * 0.08,
                spin: (Math.random() > 0.5 ? 1 : -1) * (0.8 + Math.random() * 0.6), rise: 1.5 + Math.random() * 0.9, sway: Math.random() * TAU, trail: []
            }));
            const mist = Array.from({ length: 14 }, () => ({ a: Math.random() * TAU, d: 0.9 + Math.random() * 3.2, s: 1.3 + Math.random() * 1.2, ph: Math.random() * TAU }));
            const motes = [], chips = [];
            const cracks = high ? [] : Array.from({ length: 7 }, (_, i) => { const a = i / 7 * TAU + Math.random() * 0.4; return jagged3([Math.cos(a) * 0.7, Math.sin(a) * 0.7, 0], [Math.cos(a) * 3.2, Math.sin(a) * 3.2, 0], 0.5, 7); });
            let chipped = false;
            // Where a soul is, u seconds after it left the ground (or, on a 1, after it started down)
            const soulAt = (sl, u) => {
                if (high) {
                    const a = sl.a + sl.spin * u, r = sl.r * (1 - 0.3 * Math.min(1, u)) + 0.25 * Math.sin(u * 3 + sl.sway);
                    return [Math.cos(a) * r, Math.sin(a) * r, 0.15 + sl.rise * u + 0.25 * Math.sin(u * 4 + sl.sway)];
                }
                const a = sl.a - sl.spin * u * 1.6, r = sl.r * Math.max(0.15, 1 - u * 0.7);
                return [Math.cos(a) * r, Math.sin(a) * r, Math.max(-0.4, 3 - u * 3.4)];
            };
            return (t, dt) => {
                const fade = 1 - clamp01((t - (high ? 2.2 : 1.6)) / 0.6);
                // A low mist, drifting
                g.globalCompositeOperation = 'screen';
                for (const m of mist) {
                    const q = P(Math.cos(m.a + t * 0.15) * m.d, Math.sin(m.a + t * 0.15) * m.d, 0.1);
                    stamp(g, q, m.s * fxUnit * q.k, tail, 0.06 * fade * clamp01(t / 0.5) * (0.7 + 0.3 * Math.sin(t * 2 + m.ph)));
                }
                if (!high) {
                    g.globalCompositeOperation = 'source-over';
                    pool(g, P, 0, 0, 3.6, `rgba(0,0,0,${(0.5 * fade).toFixed(3)})`, 'rgba(0,0,0,0)');
                    hole(g, P);
                    g.globalCompositeOperation = 'lighter';
                    const ck = clamp01(t / 0.3);
                    for (const c of cracks) line3(g, P, c.slice(0, Math.max(2, Math.round(c.length * ck))), 2, rgba(tail, 0.7 * fade), tail);
                    if (t > 0.1 && !chipped) {
                        chipped = true;
                        for (let i = 0; i < 16; i++) { const a = Math.random() * TAU, sp = 1 + Math.random() * 3; chips.push(particle({ z: 0.6, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 3 + Math.random() * 3, g: -14, bounce: true, drag: 0.5, size: 1.4, vs: 8, color: fx.colors[3], born: t, life: 1.6 })); }
                    }
                }
                g.globalCompositeOperation = 'screen';
                for (const sl of souls) {
                    if (t < sl.at) continue;
                    const u = t - sl.at;
                    const life = high ? 1 - clamp01((u - 1.4) / 0.7) : 1 - clamp01((u - 0.95) / 0.25);
                    if (life <= 0) continue;
                    sl.trail.unshift(soulAt(sl, u));
                    if (sl.trail.length > 34) sl.trail.pop();
                    const appear = clamp01(u / 0.35) * life * fade;
                    // The tail: where it has been, thinner and fainter further back
                    for (let k = sl.trail.length - 1; k >= 1; k--) {
                        const v = k / 34, q = P(...sl.trail[k]);
                        stamp(g, q, (0.46 - v * 0.38) * fxUnit * q.k, v < 0.3 ? mid : tail, (1 - v) * 0.17 * appear);
                    }
                    // The head: a pale heart in a soft halo, flickering
                    const h = P(...sl.trail[0]), fl = 0.8 + 0.2 * Math.sin(t * 11 + sl.sway);
                    stamp(g, h, 1 * fxUnit * h.k, tail, 0.16 * appear * fl);
                    stamp(g, h, 0.45 * fxUnit * h.k, mid, 0.35 * appear * fl);
                    stamp(g, h, 0.2 * fxUnit * h.k, pale, 0.85 * appear * fl);
                    if (high && motes.length < 120 && Math.random() < 0.35 * life) {
                        const [x, y, z] = sl.trail[Math.min(sl.trail.length - 1, 3)];
                        motes.push(particle({ x, y, z, vx: (Math.random() - 0.5) * 0.5, vy: (Math.random() - 0.5) * 0.5, vz: 0.2 + Math.random() * 0.4, drag: 0.8, size: 0.7 + Math.random() * 0.7, color: Math.random() > 0.5 ? pale : mid, alpha: 0.65, born: t, life: 0.6 + Math.random() * 0.6 }));
                    }
                }
                g.globalCompositeOperation = 'lighter';
                run(g, P, motes, t, dt, 'dot');
                if (!high) {
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, chips, t, dt, 'shard');
                }
            };
        },

        // The hoard spills: a fountain of gold coins and gems rains on the table and glints.
        // A 1: it was a mimic: a toothed mouth opens in the table and bites down on the die
        hoard({ g, P, fx, high }) {
            const coins = [], glints = [];
            const gems = ['#ff4d6d', '#4dabf7', '#51cf66', '#cc5de8'];
            const copper = [];
            let spat = false;
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                if (high) {
                    pool(g, P, 0, 0, 5, rgba(fx.colors[1], 0.4 * span(t, 0, 0.3, 1.8, 2.8)), rgba(fx.colors[1], 0));
                    if (t < 1 && coins.length < 150) {
                        for (let i = 0; i < 5; i++) {
                            const a = Math.random() * TAU, sp = 1 + Math.random() * 3.5, gem = Math.random() < 0.15;
                            coins.push(particle({ z: 1.2, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 9 + Math.random() * 6, g: -22, bounce: true, drag: 0.6, size: gem ? 1.8 : 2.6 + Math.random() * 1.2, vs: (Math.random() - 0.5) * 8, color: gem ? pick(gems) : pick(fx.colors.slice(1, 3)), style: gem ? 'shard' : 'coin', born: t, life: 2.9 - t }));
                        }
                    }
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, coins, t, dt, 'coin');
                    g.globalCompositeOperation = 'lighter';
                    if (t > 0.6 && coins.length && Math.random() < 0.5) { const c = pick(coins); if (c.z < 0.1) glints.push(particle({ x: c.x, y: c.y, z: 0.2, size: 2.8, color: '#ffffff', born: t, life: 0.35 })); }
                    run(g, P, glints, t, dt, 'star');
                } else {
                    // The mimic: a mouth opens in the table under the die, a ring of teeth rising out of it and another
                    // coming down from above; it bites twice, then spits a few coppers out and sinks away
                    const open = ease(clamp01(t / 0.45)), gone = clamp01((t - 2.1) / 0.6);
                    const bite = (c) => Math.exp(-Math.pow((t - c) / 0.09, 2));
                    const shut = Math.max(bite(0.95), bite(1.45) * 0.8);
                    const R = (2.2 + 0.8 * open) * (1 - 0.35 * shut) * (1 - gone);
                    const H = 1.6 + 4.5 * (1 - shut) * open;
                    if (R > 0.05) {
                        g.globalCompositeOperation = 'source-over';
                        g.fillStyle = 'rgba(12,0,2,0.92)';
                        path(g, onTable(P, circle(R * 1.05)), true); g.fill();
                        pool(g, P, Math.sin(t * 7) * 0.5, Math.cos(t * 5) * 0.4, R * 0.7, 'rgba(160,20,40,0.65)', 'rgba(120,10,30,0)');
                        const n = 13;
                        const tooth = (i, top) => {
                            const a = (i + (top ? 0.5 : 0)) / n * TAU, w = 0.45 / n * TAU;
                            const z0 = top ? H : 0, z1 = top ? H - 1.3 : 1.3;
                            const pts = [
                                P(Math.cos(a - w) * R, Math.sin(a - w) * R, z0),
                                P(Math.cos(a) * R * 0.78, Math.sin(a) * R * 0.78, z1),
                                P(Math.cos(a + w) * R, Math.sin(a + w) * R, z0)
                            ];
                            g.fillStyle = '#f1e6c8';
                            g.strokeStyle = '#4a3a20';
                            g.lineWidth = 1.2;
                            path(g, pts, true); g.fill(); g.stroke();
                        };
                        for (let i = 0; i < n; i++) tooth(i, false);
                        hole(g, P);
                        // The gums of the upper jaw, then its teeth
                        line3(g, P, circle(R, 48).map(([x, y]) => [x, y, H]), 5, 'rgba(110,40,30,0.95)');
                        for (let i = 0; i < n; i++) tooth(i, true);
                    }
                    if (t > 1.55 && !spat) {
                        spat = true;
                        for (let i = 0; i < 6; i++) { const a = Math.random() * TAU, sp = 2 + Math.random() * 3; copper.push(particle({ z: 1, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 5 + Math.random() * 3, g: -20, bounce: true, drag: 0.4, size: 3.5, color: '#b87333', alpha: 0.95, born: t, life: 1.4 })); }
                    }
                    g.globalCompositeOperation = 'source-over';
                    run(g, P, copper, t, dt, 'coin');
                }
            };
        },

        // The eye of the abyss opens on the table round the die, looks about, drawing the light in, and closes.
        // A 1: darkness spreads under the die and black tendrils reach up out of it
        abyss({ g, P, fx, high }) {
            const rot = Math.random() * TAU, L = 4.6, H = 1.9;
            const motes = Array.from({ length: 60 }, () => ({ a: Math.random() * TAU, r: 5 + Math.random() * 5, z: 0.2 + Math.random() * 2, s: 1 + Math.random() * 1.5 }));
            const tendrils = Array.from({ length: 9 }, (_, i) => ({ a: i / 9 * TAU + Math.random() * 0.3, h: 1.5 + Math.random() * 2, ph: Math.random() * TAU }));
            return (t, dt) => {
                if (high) {
                    const open = ease(span(t, 0.1, 0.55, 2.0, 2.5));
                    const lid = (sign) => Array.from({ length: 25 }, (_, i) => { const x = -L + i / 24 * 2 * L; return [x, sign * H * (1 - (x / L) ** 2) * open]; }).map(turn(rot));
                    const upper = lid(1), lower = lid(-1).reverse();
                    const eye = onTable(P, [...upper, ...lower]);
                    // Light drawn into the eye
                    g.globalCompositeOperation = 'lighter';
                    for (const m of motes) {
                        m.a += 2.2 * dt;
                        m.r = Math.max(0, m.r - (2 + (6 - m.r) * 0.8) * dt * (t < 2 ? 1 : 0));
                        if (m.r > 0.3) drawParticle(g, P(Math.cos(m.a) * m.r, Math.sin(m.a) * m.r, m.z * m.r / 8), particle({ size: m.s, color: fx.colors[0], alpha: 0.9 }), 'dot', 0);
                    }
                    if (open > 0.02) {
                        g.globalCompositeOperation = 'source-over';
                        g.fillStyle = 'rgba(2,0,8,0.92)';
                        path(g, eye, true); g.fill();
                        g.save();
                        path(g, eye, true); g.clip();
                        const look = [Math.sin(t * 2.4) * 0.9, Math.cos(t * 1.7) * 0.3];
                        const [ix, iy] = turn(rot)(look);
                        g.globalCompositeOperation = 'lighter';
                        pool(g, P, ix, iy, 1.7, rgba(fx.colors[0], 0.95), rgba(fx.colors[1], 0.2));
                        line3(g, P, circle(1.7, 40).map(shift(ix, iy)).map(([x, y]) => [x, y, 0]), 2, rgba(fx.colors[3], 0.9), fx.colors[1]);
                        g.globalCompositeOperation = 'source-over';
                        g.fillStyle = '#000';
                        const slit = Array.from({ length: 21 }, (_, i) => { const a = i / 20 * TAU; return [Math.cos(a) * 0.32, Math.sin(a) * 1.35]; }).map(turn(rot)).map(shift(ix, iy));
                        path(g, onTable(P, slit), true); g.fill();
                        g.restore();
                        g.globalCompositeOperation = 'lighter';
                        glowLine(g, onTable(P, upper), 2.5, rgba(fx.colors[0], 0.9), fx.colors[1]);
                        glowLine(g, onTable(P, lower), 2.5, rgba(fx.colors[0], 0.9), fx.colors[1]);
                        // Lashes of shadow
                        g.globalCompositeOperation = 'source-over';
                        for (let i = 2; i < 23; i += 3) {
                            const [x, y] = upper[i], d = turn(rot)([0, 1])[0], e = turn(rot)([0, 1])[1];
                            line3(g, P, [[x, y, 0], [x + d * 0.8 * open, y + e * 0.8 * open, 0.3]], 2, rgba(fx.dark, 0.9));
                        }
                        hole(g, P);
                    }
                } else {
                    const grow = ease(clamp01(t / 0.6)), fade = 1 - clamp01((t - 1.6) / 0.6);
                    g.globalCompositeOperation = 'source-over';
                    pool(g, P, 0, 0, 0.5 + grow * 4, `rgba(0,0,0,${(0.85 * fade).toFixed(3)})`, `rgba(0,0,0,${(0.3 * fade).toFixed(3)})`);
                    hole(g, P);
                    g.globalCompositeOperation = 'lighter';
                    line3(g, P, circle(0.5 + grow * 4, 48).map(([x, y]) => [x, y, 0]), 1.5, rgba(fx.colors[2], 0.6 * fade), fx.colors[1]);
                    g.globalCompositeOperation = 'source-over';
                    const reach = span(t, 0.3, 0.8, 1.2, 1.8);
                    for (const td of tendrils) {
                        const r = 0.5 + grow * 4;
                        const pts = Array.from({ length: 10 }, (_, i) => { const u = i / 9; return [Math.cos(td.a) * r * (1 - u * 0.5) + Math.sin(t * 5 + td.ph + u * 4) * 0.3 * u, Math.sin(td.a) * r * (1 - u * 0.5), td.h * u * reach]; });
                        line3(g, P, pts, 4, rgba(fx.dark, 0.95 * fade), fx.colors[2]);
                    }
                }
            };
        },

        // The wood wakes: vines curl out of the die across the table and small flowers bloom along them, fireflies dancing.
        // A 1: wilted petals drift down and the fireflies go out
        fey({ g, P, fx, high }) {
            const vines = Array.from({ length: 6 }, (_, i) => ({ a: i / 6 * TAU + Math.random() * 0.3, dir: Math.random() > 0.5 ? 1 : -1, len: 3 + Math.random() * 1.5 }));
            const vinePt = (v, u) => { const r = 0.6 + u * v.len, a = v.a + v.dir * u * 1.6; return [Math.cos(a) * r, Math.sin(a) * r]; };
            const petals = ['#ffe5f4', '#ffd1ea', '#fff7c2', '#f0abfc'];
            const flies = Array.from({ length: 22 }, () => ({ a: Math.random() * TAU, r: 1.5 + Math.random() * 3.5, z: 0.6 + Math.random() * 2.5, av: (Math.random() > 0.5 ? 1 : -1) * (0.8 + Math.random() * 1.4), ph: Math.random() * TAU, out: 0.4 + Math.random() * 1.2 }));
            const falling = high ? [] : Array.from({ length: 30 }, () => ({ x: (Math.random() - 0.5) * 9, y: (Math.random() - 0.5) * 7, z: 5 + Math.random() * 6, v: 1.6 + Math.random(), ph: Math.random() * TAU, c: pick(['#9c7a5b', '#8a8f6a', '#b9a58c', '#6e5a48']), rot: Math.random() * TAU }));
            const petal = (cx, cy, a, len, wid) => Array.from({ length: 13 }, (_, i) => { const u = i / 12 * TAU; return [Math.cos(u) * len * 0.5 + len * 0.5, Math.sin(u) * wid]; }).map(turn(a)).map(shift(cx, cy));
            return (t, dt) => {
                const fade = 1 - clamp01((t - (high ? 2.3 : 1.7)) / 0.6);
                if (high) {
                    g.globalCompositeOperation = 'source-over';
                    const grow = ease(clamp01((t - 0.05) / 0.9));
                    for (const v of vines) {
                        const pts = Array.from({ length: 20 }, (_, i) => vinePt(v, i / 19 * grow));
                        glowLine(g, onTable(P, pts), 2.6, rgba('#3f6b22', 0.95 * fade));
                        for (let i = 4; i < 20; i += 5) {
                            if (i / 19 > grow) break;
                            const [x, y] = pts[i], a = v.a + v.dir * (i / 19) * 1.6 + (i % 2 ? 1.2 : -1.2);
                            g.fillStyle = rgba(fx.colors[1], 0.85 * fade);
                            path(g, onTable(P, petal(x, y, a, 0.6, 0.18)), true); g.fill();
                        }
                        // Small flowers along the vine and at its end
                        for (const [along, size, delay] of [[0.5, 0.26, 0.55], [0.78, 0.3, 0.7], [1, 0.4, 0.85]]) {
                            const bloom = ease(clamp01((t - delay - v.a * 0.02) / 0.45));
                            if (bloom <= 0 || along > grow + 0.001) continue;
                            const [x, y] = vinePt(v, along);
                            for (let k = 0; k < 5; k++) {
                                g.fillStyle = rgba(petals[(k + Math.round(along * 4)) % petals.length], 0.92 * fade);
                                path(g, onTable(P, petal(x, y, k / 5 * TAU + v.a + t * 0.3, size * bloom, size * 0.4 * bloom)), true); g.fill();
                            }
                            g.globalCompositeOperation = 'lighter';
                            blob(g, P(x, y, 0.05), 0.18, '#ffe066', 0.9 * bloom * fade);
                            g.globalCompositeOperation = 'source-over';
                        }
                    }
                    hole(g, P);
                }
                g.globalCompositeOperation = 'lighter';
                for (const f of flies) {
                    f.a += f.av * dt;
                    const on = high ? fade : clamp01(1 - (t - f.out) / 0.3);
                    if (on <= 0) continue;
                    const z = f.z + Math.sin(t * 3 + f.ph) * 0.4 + (high ? t * 0.3 : 0);
                    const a = (0.5 + 0.5 * Math.abs(Math.sin(t * 8 + f.ph))) * on * (high ? 1 : 0.5);
                    blob(g, P(Math.cos(f.a) * f.r, Math.sin(f.a) * f.r, z), 0.3, fx.colors[0], a);
                }
                if (!high) {
                    g.globalCompositeOperation = 'source-over';
                    for (const p of falling) {
                        p.z = Math.max(0, p.z - p.v * dt);
                        const sway = Math.sin(t * 3 + p.ph) * 0.5;
                        g.fillStyle = rgba(p.c, 0.85 * fade);
                        path(g, onTable(P, petal(p.x + sway, p.y, p.rot + t * (p.z > 0 ? 2 : 0), 0.7, 0.26), p.z), true); g.fill();
                    }
                }
            };
        },

        // Acid eats into the table: a pool spreads slowly out of the die, a few bubbles swell and burst, thin fumes rise.
        // A 1: the acid hisses, steams and dries into a dark stain
        acid({ g, P, fx, high }) {
            const bubbles = [], fumes = [], drops = [];
            const size = high ? 3.4 : 1.8;
            if (high) for (let i = 0; i < 9; i++) { const a = Math.random() * TAU, sp = 1.5 + Math.random() * 2.5; drops.push(particle({ z: 1, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 3 + Math.random() * 3, g: -18, drag: 0.5, size: 1.2 + Math.random() * 0.8, color: pick(fx.colors), alpha: 0.8, born: 0, life: 0.9 })); }
            const blobAt = (r, t) => Array.from({ length: 49 }, (_, i) => { const a = i / 48 * TAU; const k = 1 + 0.05 * Math.sin(5 * a + t * 1.2) + 0.025 * Math.sin(9 * a - t * 1.6); return [Math.cos(a) * r * k, Math.sin(a) * r * k]; });
            return (t, dt) => {
                const r = size * ease(clamp01(t / 0.6)) * (high ? 1 : 1 - clamp01((t - 0.9) / 0.9) * 0.3);
                const fade = 1 - clamp01((t - (high ? 2.3 : 1.7)) / 0.5);
                const dry = high ? 0 : clamp01((t - 0.6) / 1);
                if (r > 0.05) {
                    g.globalCompositeOperation = 'source-over';
                    g.fillStyle = `rgba(10,20,4,${(0.35 * fade).toFixed(3)})`;
                    path(g, onTable(P, blobAt(r * 1.08, t)), true); g.fill();
                    g.globalCompositeOperation = 'lighter';
                    pool(g, P, 0, 0, r * 1.15, rgba(fx.colors[3], (0.16 - dry * 0.14) * fade), rgba(fx.colors[2], (0.11 - dry * 0.1) * fade));
                    g.save(); path(g, onTable(P, blobAt(r, t)), true); g.clip();
                    pool(g, P, 0, 0, r * 1.2, rgba(fx.colors[2], (0.22 - dry * 0.18) * fade), rgba(fx.colors[2], 0.06 * fade));
                    g.restore();
                    glowLine(g, onTable(P, blobAt(r, t)), 1.6, rgba(fx.colors[1], (0.6 - dry * 0.5) * fade));
                    hole(g, P);
                }
                // Bubbles swell and burst into rings
                if (t < (high ? 2.1 : 1) && Math.random() < (high ? 0.22 : 0.12)) {
                    const a = Math.random() * TAU, d = Math.sqrt(Math.random()) * r * 0.85;
                    bubbles.push({ x: Math.cos(a) * d, y: Math.sin(a) * d, s: 0.15 + Math.random() * 0.3, born: t });
                }
                g.globalCompositeOperation = 'lighter';
                for (let i = bubbles.length - 1; i >= 0; i--) {
                    const bb = bubbles[i], k = (t - bb.born) / 0.5;
                    if (k >= 1) { bubbles.splice(i, 1); continue; }
                    if (k < 0.7) {
                        const q = P(bb.x, bb.y, bb.s * k);
                        blob(g, q, bb.s * 1.6 * (k / 0.7) + 0.15, fx.colors[0], 0.45 * fade);
                    } else {
                        const u = (k - 0.7) / 0.3;
                        line3(g, P, circle(bb.s * (1 + u * 1.6), 14).map(([x, y]) => [x + bb.x, y + bb.y, 0.05]), 1.2, rgba(fx.colors[0], 0.8 * (1 - u) * fade));
                        if (high && fumes.length < 20 && Math.random() < 0.3) fumes.push(particle({ x: bb.x, y: bb.y, z: 0.2, vz: 0.6 + Math.random() * 0.6, vx: (Math.random() - 0.5) * 0.3, drag: 0.7, size: 2.5, color: fx.colors[1], alpha: 0.14, born: t, life: 1.2 }));
                    }
                }
                if (!high && t > 0.4 && fumes.length < 40 && Math.random() < 0.6) fumes.push(particle({ x: (Math.random() - 0.5) * r * 1.4, y: (Math.random() - 0.5) * r * 1.4, z: 0.2, vz: 1.4 + Math.random(), drag: 0.7, size: 3, color: '#e9f5e0', alpha: 0.3, born: t, life: 1.1 }));
                run(g, P, fumes, t, dt, 'smoke');
                run(g, P, drops, t, dt, 'drop');
            };
        },

        // A ritual: the magic circle is drawn on the table round the die, a star inside it, runes orbiting, a shaft of
        // light rising. A 1: the circle is half drawn, flickers and shatters, its pieces falling away
        arcane({ g, P, fx, high }) {
            const frags = [];
            let broke = false;
            const runeRing = (r, z, rot, n, k, a) => {
                for (let i = 0; i < n; i++) {
                    const ang = i / n * TAU + rot, cx = Math.cos(ang) * r, cy = Math.sin(ang) * r;
                    line3(g, P, glyph(i + n, cx, cy, 0.2 * k).map(turn(0)).map(([x, y]) => [x, y, z]), 1.4, rgba(fx.colors[0], a), fx.colors[2]);
                }
            };
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                if (high) {
                    const fade = 1 - clamp01((t - 2.2) / 0.7), k = ease(clamp01(t / 0.6));
                    pool(g, P, 0, 0, 4.4, rgba(fx.colors[2], 0.3 * fade), rgba(fx.colors[2], 0));
                    // The ground circle, drawn round as it appears
                    const drawn = circle(3.7, 64).slice(0, Math.max(2, Math.round(65 * k)));
                    line3(g, P, drawn.map(turn(t * 0.5)).map(([x, y]) => [x, y, 0]), 2.4, rgba(fx.colors[0], 0.9 * fade), fx.colors[2]);
                    line3(g, P, circle(3.1, 64).map(turn(t * 0.5)).map(([x, y]) => [x, y, 0]), 1.4, rgba(fx.colors[1], 0.8 * fade * k), fx.colors[2]);
                    const star = Array.from({ length: 6 }, (_, i) => { const a = (i * 2) / 5 * TAU - Math.PI / 2; return [Math.cos(a) * 3.0, Math.sin(a) * 3.0]; }).map(turn(t * 0.5));
                    line3(g, P, star.map(([x, y]) => [x, y, 0]), 1.6, rgba(fx.colors[0], 0.75 * fade * k), fx.colors[2]);
                    runeRing(3.4, 0, t * 0.5, 12, k, 0.85 * fade);
                    hole(g, P);
                    // A shaft of light out of the die
                    const beam = span(t, 0.9, 1.2, 1.7, 2.4);
                    for (let i = 0; i < 8 && beam > 0; i++) blob(g, P(0, 0, 1 + i * 0.7), 1.2 - i * 0.08, fx.colors[3], 0.18 * beam);
                } else {
                    const k = ease(clamp01(t / 0.45)) * 0.62;
                    const pts = circle(3.4, 64).slice(0, Math.max(2, Math.round(65 * k)));
                    const flick = t > 0.45 ? (Math.random() > 0.4 ? 1 : 0.2) : 1;
                    if (t < 0.75) line3(g, P, pts.map(([x, y]) => [x, y, 0]), 2.2, rgba(fx.colors[2], 0.85 * flick), fx.colors[2]);
                    if (t >= 0.75 && !broke) {
                        broke = true;
                        for (let i = 0; i + 4 < pts.length; i += 4) {
                            const [x, y] = pts[i], [x2, y2] = pts[i + 4], a = Math.atan2(y, x), sp = 1.5 + Math.random() * 2.5;
                            frags.push(particle({ x, y, z: 0.1, vx: Math.cos(a) * sp, vy: Math.sin(a) * sp, vz: 2 + Math.random() * 3, g: -10, drag: 0.6, dx: x2 - x, dy: y2 - y, vs: (Math.random() - 0.5) * 6, color: fx.colors[2], born: t, life: 1.2 }));
                        }
                    }
                    for (let i = frags.length - 1; i >= 0; i--) {
                        const f = frags[i], life = (t - f.born) / f.life;
                        if (life >= 1) { frags.splice(i, 1); continue; }
                        step(f, dt);
                        const c = Math.cos(f.spin), sn = Math.sin(f.spin);
                        line3(g, P, [[f.x, f.y, f.z], [f.x + f.dx * c - f.dy * sn, f.y + f.dx * sn + f.dy * c, f.z]], 2, rgba(fx.colors[2], 0.9 * (1 - life)), fx.colors[2]);
                    }
                }
            };
        },

        // Dawn breaks on the die: rays of gold turn round it, two rings of light run over the table, motes of light
        // rise. A 1: an eclipse: a dark disc slides over the light on the table and only a thin corona is left
        dawn({ g, P, fx, high }) {
            const rays = Array.from({ length: 18 }, (_, i) => ({ a: i / 18 * TAU, l: i % 2 ? 0.6 : 1, w: i % 2 ? 0.06 : 0.1 }));
            const motes = [];
            return (t, dt) => {
                const o = P(0, 0, 1.2), u = fxUnit * o.k;
                g.globalCompositeOperation = 'lighter';
                if (high) {
                    const k = span(t, 0, 0.4, 2.0, 2.8), rise = ease(clamp01(t / 0.7));
                    pool(g, P, 0, 0, 4.6 * rise + 0.5, rgba(fx.colors[2], 0.32 * k), rgba(fx.colors[3], 0));
                    for (const r of rays) {
                        const a = r.a + t * 0.22, len = (1.4 + 3.4 * r.l * rise) * u;
                        const grad = g.createLinearGradient(o.x, o.y, o.x + Math.cos(a) * len, o.y + Math.sin(a) * len);
                        grad.addColorStop(0, rgba(fx.colors[1], 0.5 * k));
                        grad.addColorStop(1, rgba(fx.colors[2], 0));
                        g.fillStyle = grad;
                        g.beginPath();
                        g.moveTo(o.x + Math.cos(a - r.w) * u, o.y + Math.sin(a - r.w) * u);
                        g.lineTo(o.x + Math.cos(a) * len, o.y + Math.sin(a) * len);
                        g.lineTo(o.x + Math.cos(a + r.w) * u, o.y + Math.sin(a + r.w) * u);
                        g.closePath();
                        g.fill();
                    }
                    for (const [from, reach] of [[0.15, 4.4], [0.6, 5.6]]) {
                        const v = clamp01((t - from) / 0.9);
                        if (v > 0 && v < 1) line3(g, P, circle(1 + ease(v) * reach).map(([x, y]) => [x, y, 0]), 3 * (1 - v) + 0.6, rgba(fx.colors[1], 0.8 * (1 - v)), fx.colors[2]);
                    }
                    hole(g, P);
                    if (t < 2 && Math.random() < 0.8) {
                        const a = Math.random() * TAU, d = 1.2 + Math.random() * 3;
                        motes.push(particle({ x: Math.cos(a) * d, y: Math.sin(a) * d, z: 0.2, vz: 1 + Math.random() * 1.5, drag: 0.9, size: 1.2 + Math.random(), color: pick(fx.colors), born: t, life: 1.3 }));
                    }
                    run(g, P, motes, t, dt, 'dot');
                } else {
                    const k = span(t, 0, 0.3, 1.5, 2.2), cover = ease(clamp01((t - 0.25) / 1));
                    pool(g, P, 0, 0, 3.4, rgba(fx.colors[2], 0.3 * k * (1 - cover * 0.7)), rgba(fx.colors[3], 0));
                    line3(g, P, circle(3.2, 64).map(([x, y]) => [x, y, 0]), 2 + 2 * cover, rgba(fx.colors[1], 0.75 * k), fx.colors[2]);
                    g.globalCompositeOperation = 'source-over';
                    const dx = (1 - cover) * 7;
                    g.fillStyle = `rgba(10,7,2,${(0.88 * k).toFixed(3)})`;
                    path(g, onTable(P, circle(3.05, 56).map(shift(dx, -dx * 0.25))), true);
                    g.fill();
                    hole(g, P);
                }
            };
        },

        // The deep rises: a shower of rain falls round the die, each drop a streak that ends in a little ring where it
        // lands, and slow wide rings of water run out from the die. A 1: a whirlpool opens under the die and drains everything away
        tide({ g, P, fx, high }) {
            const rain = [], ripples = [];
            return (t, dt) => {
                g.globalCompositeOperation = 'lighter';
                if (high) {
                    const k = 1 - clamp01((t - 2.2) / 0.7);
                    pool(g, P, 0, 0, 5, rgba(fx.colors[2], 0.2 * k), rgba(fx.colors[2], 0));
                    for (let i = 0; i < 3; i++) {
                        const v = (t - 0.05 - i * 0.55) / 1.8;
                        if (v <= 0 || v >= 1) continue;
                        const R = 1 + ease(v) * 5;
                        line3(g, P, circle(R, 72).map(([x, y]) => [x, y, 0]), 2 * (1 - v) + 0.6, rgba(fx.colors[1], 0.7 * (1 - v) * k), fx.colors[2]);
                    }
                    hole(g, P);
                    // The rain: streaks falling, a ring where each lands
                    if (t < 2.2) {
                        if (Math.random() < 0.9) {
                            const a = Math.random() * TAU, d = 0.9 + Math.sqrt(Math.random()) * 4.6;
                            rain.push({ x: Math.cos(a) * d, y: Math.sin(a) * d, z: 2.5 + Math.random() * 2.5, v: 9 + Math.random() * 4 });
                        }
                    }
                    for (let i = rain.length - 1; i >= 0; i--) {
                        const d = rain[i];
                        d.z -= d.v * dt;
                        if (d.z <= 0) {
                            rain.splice(i, 1);
                            ripples.push({ x: d.x, y: d.y, born: t, s: 0.25 + Math.random() * 0.25 });
                            continue;
                        }
                        line3(g, P, [[d.x, d.y, d.z], [d.x, d.y, d.z + 0.35]], 1.2, rgba(fx.colors[0], 0.6 * k));
                    }
                    for (let i = ripples.length - 1; i >= 0; i--) {
                        const rp = ripples[i], u = (t - rp.born) / 0.7;
                        if (u >= 1) { ripples.splice(i, 1); continue; }
                        line3(g, P, circle(0.05 + ease(u) * rp.s, 20).map(([x, y]) => [x + rp.x, y + rp.y, 0]), 1.2, rgba(fx.colors[1], 0.75 * (1 - u) * k));
                        if (u < 0.5) line3(g, P, circle(0.02 + ease(u * 2) * rp.s * 0.45, 14).map(([x, y]) => [x + rp.x, y + rp.y, 0]), 1, rgba(fx.colors[0], 0.5 * (1 - u * 2) * k));
                    }
                } else {
                    const k = span(t, 0, 0.3, 1.5, 2.2);
                    g.globalCompositeOperation = 'source-over';
                    pool(g, P, 0, 0, 3.6, `rgba(2,14,22,${(0.6 * k).toFixed(3)})`, 'rgba(2,14,22,0)');
                    g.globalCompositeOperation = 'lighter';
                    for (let arm = 0; arm < 5; arm++) {
                        const pts = Array.from({ length: 41 }, (_, s) => { const v = s / 40, r = 3.3 * (1 - v) + 0.9, a = arm / 5 * TAU + v * 4.2 + t * 3.2; return [Math.cos(a) * r, Math.sin(a) * r, 0]; });
                        line3(g, P, pts, 1.8, rgba(fx.colors[2], 0.65 * k), fx.colors[2]);
                    }
                    hole(g, P);
                }
            };
        }
    };

    // A natural 20 (high) or 1 of a special die; with the box and the die it is played where the die rests
    function critical(fx, high, b, die, skin) {
        const c = fxLayer(), g = c.getContext('2d');
        const dpr = Math.min(2, window.devicePixelRatio || 1);
        c.width = Math.round(innerWidth * dpr);
        c.height = Math.round(innerHeight * dpr);
        c.classList.add('shown');
        const { P, px } = space(b, die);
        fxUnit = px;
        fxDie = !!(b && die);
        const make = effects[skin] || effects.ember;
        const frameOf = make({ g, P, px, fx, high });
        const duration = high ? 3 : 2.3;
        const start = performance.now();
        let last = start;
        return new Promise((done) => {
            const frame = () => {
                const now = performance.now();
                const t = (now - start) / 1000, dt = Math.min(0.05, Math.max(0, (now - last) / 1000));
                last = now;
                // The die flares with the colour of the effect, or dims on a 1 (the pulse of its texture multiplies it)
                critFlare = high ? Math.max(0, 1 - t / 1.4) * 3 : -Math.min(0.8, Math.sin(Math.min(1, t / 1.2) * Math.PI) * 0.8);
                g.setTransform(dpr, 0, 0, dpr, 0, 0);
                g.clearRect(0, 0, innerWidth, innerHeight);
                g.globalAlpha = 1;
                // The first light (or shadow) on the table, under every effect
                try {
                    if (high) {
                        g.globalCompositeOperation = 'lighter';
                        const fl = Math.max(0, 1 - t / 0.7);
                        if (fl > 0.01) pool(g, P, 0, 0, 2 + ease(t / 0.7) * 4, rgba(fx.colors[0], 0.7 * fl), rgba(fx.colors[1], 0));
                    }
                    frameOf(t, dt);
                } catch { }
                g.globalCompositeOperation = 'source-over';
                g.globalAlpha = 1;
                if (t < duration) {
                    requestAnimationFrame(frame);
                } else {
                    critFlare = 0;
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

    // The dice fade away a while after they rest. A throw that starts meanwhile cancels both steps: before, the fading
    // of the previous throw could still empty the box under the new dice, which vanished in the middle of their roll
    function hideLater(ms) {
        keepShown();
        hideTimer = setTimeout(() => {
            if (!layer) return;
            layer.classList.add('fading');
            stopPulse();
            fadeTimer = setTimeout(() => {
                layer.classList.remove('shown', 'fading');
                try { box && box.clearDice(); } catch { }
            }, 350);
        }, ms);
    }

    function keepShown() {
        clearTimeout(hideTimer);
        clearTimeout(fadeTimer);
        hideTimer = fadeTimer = null;
    }

    async function throwDice(dice, colorOverride) {
        const s = read();
        // The dice of another player are resin in their colour
        const skin = colorOverride ? 'resin' : s.skin;
        keepShown();
        const b = await ensureBox(s.sound);
        await applyLook(b, skin, colorOverride || s.color);
        layer.classList.remove('fading');
        layer.classList.add('shown');
        layer.dataset.skin = skin;
        try { b.clearDice(); } catch { }
        const special = specials[skin];
        const { text, thrown } = notation(dice);
        // The physics settles in one or two seconds; never wait longer than ten (a slow device painting new dice)
        const rolled = b.roll(text);
        if (special) startPulse(b, special);
        await Promise.race([rolled, new Promise(r => setTimeout(r, 10000))]);
        // A natural 20 or 1 of a d20 that counts (not the one set aside by advantage or disadvantage)
        const crits = special ? d20s(b, thrown).filter(x => !x.face.dropped && (x.face.value === 20 || x.face.value === 1)) : [];
        if (crits.length > 0) {
            const shown = crits.find(x => x.face.value === 20) || crits[0];
            hideLater(3300);
            await critical(special.fx, shown.face.value === 20, b, shown.die, skin);
            return true;
        }
        hideLater(1100);
        return true;
    }

    // The look chosen made ready before it is thrown: the box, the colours or the texture of the special die, and the
    // faces of every kind of die painted once (the slow part on the first throw of a new look). Queued with the throws,
    // so a throw asked meanwhile waits for it instead of starting half ready
    function ready() {
        const s = read();
        if (!s.enabled || !available()) return Promise.resolve(false);
        const run = queue.then(async () => {
            const b = await ensureBox(s.sound);
            await applyLook(b, s.skin, s.color);
            const f = b.DiceFactory;
            for (const type of ['d4', 'd6', 'd8', 'd10', 'd12', 'd20', 'd100']) {
                try { f.create(type); } catch { }
            }
            await new Promise(r => setTimeout(r, 0));
            return true;
        }).catch(() => false);
        queue = run.then(() => { }, () => { });
        return run;
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

    // While the page is idle: the box, then the look chosen (the first throw does not paint the dice)
    const warm = () => prepare().then(ok => ok && ready());
    if (document.readyState === 'complete') idle(warm);
    else window.addEventListener('load', () => setTimeout(() => idle(warm), 1500), { once: true });

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
            return critical(special.fx, high !== false, null, null, skin).then(() => true);
        },
        // The special dice the account has unlocked (from the server)
        unlocked(list) {
            unlocked = new Set((list || []).filter(x => specials[x]));
            return read();
        },
        available,
        prepare,
        ready,

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
            keepShown();
            if (layer) layer.classList.remove('shown', 'fading');
            try { box && box.clearDice(); } catch { }
        }
    };
})();
