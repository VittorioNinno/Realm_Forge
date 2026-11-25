// RealmForge visual effects: a light particle engine on one canvas over the page (no library). Hits spark in the
// colour of their damage type (fire embers, ice shards, lightning, acid, necrotic smoke…), criticals burst in gold
// with a shock ring, healing rises in green motes, an area spell blooms where it lands, a level up rains confetti.
// The reader chooses full, reduced (no particles, the CSS flashes stay) or off; reduced motion means reduced.
window.rfFx = (() => {
    const key = 'rf-fx';
    let canvas = null, ctx = null, parts = [], rings = [], bolts = [], running = false, last = 0, dpr = 1;

    function level() {
        let v = 'full';
        try { v = localStorage.getItem(key) || 'full'; } catch { }
        if (!['full', 'reduced', 'off'].includes(v)) v = 'full';
        if (v === 'full' && window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches) v = 'reduced';
        return v;
    }

    function particles() { return level() === 'full'; }

    // The look of each damage type: colours, how the bits move and how they are drawn
    const looks = {
        fire: { colors: ['#ffd166', '#ff8c00', '#ff4d00', '#c1121f'], rise: -60, spread: 140, size: [2, 5], life: [0.5, 1.1], shape: 'ember', glow: true },
        cold: { colors: ['#e0fbfc', '#9bd7f5', '#5fa8d3'], rise: 20, spread: 220, size: [2, 6], life: [0.5, 0.9], shape: 'shard' },
        lightning: { colors: ['#ffffff', '#cde7ff', '#7cc4ff'], rise: 0, spread: 260, size: [1, 3], life: [0.2, 0.5], shape: 'spark', glow: true, bolts: 3 },
        acid: { colors: ['#b5f44a', '#7ad03a', '#3f8f1f'], rise: 120, spread: 120, size: [3, 6], life: [0.6, 1.1], shape: 'drop' },
        poison: { colors: ['#9be564', '#6a994e', '#7b2cbf'], rise: -30, spread: 90, size: [6, 14], life: [0.8, 1.5], shape: 'smoke' },
        necrotic: { colors: ['#3c096c', '#5a189a', '#240046', '#10002b'], rise: -40, spread: 90, size: [6, 16], life: [0.8, 1.6], shape: 'smoke' },
        radiant: { colors: ['#fff3b0', '#ffd60a', '#ffc300'], rise: -20, spread: 200, size: [2, 4], life: [0.5, 1], shape: 'ray', glow: true },
        thunder: { colors: ['#e9ecef', '#adb5bd', '#ced4da'], rise: 0, spread: 160, size: [2, 4], life: [0.3, 0.7], shape: 'spark', rings: 2 },
        psychic: { colors: ['#ff7ad9', '#c77dff', '#f8bbd0'], rise: -30, spread: 120, size: [2, 5], life: [0.6, 1.2], shape: 'spiral', glow: true },
        force: { colors: ['#b8c0ff', '#8e94f2', '#ffffff'], rise: 0, spread: 160, size: [2, 4], life: [0.4, 0.8], shape: 'spark', rings: 1, glow: true },
        slashing: { colors: ['#ffffff', '#f87171', '#dc2626'], rise: 40, spread: 200, size: [1, 3], life: [0.3, 0.6], shape: 'streak' },
        piercing: { colors: ['#ffffff', '#fca5a5', '#ef4444'], rise: 40, spread: 240, size: [1, 3], life: [0.25, 0.5], shape: 'streak' },
        bludgeoning: { colors: ['#e5e7eb', '#f87171', '#9ca3af'], rise: 60, spread: 160, size: [2, 4], life: [0.3, 0.6], shape: 'spark', rings: 1 },
        hit: { colors: ['#ffffff', '#fca5a5', '#ef4444'], rise: 40, spread: 200, size: [1, 3], life: [0.3, 0.6], shape: 'spark' },
        miss: { colors: ['#a1a1aa', '#71717a', '#d4d4d8'], rise: -10, spread: 70, size: [4, 9], life: [0.4, 0.8], shape: 'smoke' },
        heal: { colors: ['#86efac', '#4ade80', '#bbf7d0', '#fef9c3'], rise: -70, spread: 60, size: [2, 4], life: [0.8, 1.6], shape: 'mote', glow: true },
        crit: { colors: ['#fff7cc', '#facc15', '#f59e0b', '#ffffff'], rise: 0, spread: 320, size: [2, 5], life: [0.5, 1.1], shape: 'ray', glow: true, rings: 2 },
        fumble: { colors: ['#7f1d1d', '#ef4444', '#3f3f46'], rise: 80, spread: 120, size: [2, 5], life: [0.4, 0.9], shape: 'shard' },
        // The trail of the special dice of starlight
        stardust: { colors: ['#ffffff', '#cfe3ff', '#a78bfa', '#fde68a', '#7dd3fc'], rise: -25, spread: 150, size: [1, 3], life: [0.5, 1.2], shape: 'ray', glow: true }
    };

    const rnd = (a, b) => a + Math.random() * (b - a);
    const pick = (list) => list[Math.floor(Math.random() * list.length)];

    function ensure() {
        if (canvas && document.body.contains(canvas)) return;
        canvas = document.createElement('canvas');
        canvas.className = 'rf-fx-layer';
        canvas.setAttribute('aria-hidden', 'true');
        document.body.appendChild(canvas);
        ctx = canvas.getContext('2d');
        resize();
        window.addEventListener('resize', resize);
    }

    function resize() {
        if (!canvas) return;
        dpr = Math.min(2, window.devicePixelRatio || 1);
        canvas.width = Math.round(window.innerWidth * dpr);
        canvas.height = Math.round(window.innerHeight * dpr);
    }

    function start() {
        if (running) return;
        running = true;
        last = performance.now();
        requestAnimationFrame(frame);
    }

    function spawn(x, y, look, count, power) {
        for (let i = 0; i < count; i++) {
            const angle = rnd(0, Math.PI * 2);
            const speed = rnd(0.25, 1) * look.spread * power;
            const life = rnd(look.life[0], look.life[1]);
            parts.push({
                x, y,
                vx: Math.cos(angle) * speed,
                vy: Math.sin(angle) * speed * (look.shape === 'mote' ? 0.4 : 1),
                g: look.rise,
                size: rnd(look.size[0], look.size[1]) * (power > 1 ? 1.2 : 1),
                color: pick(look.colors),
                life, age: 0,
                shape: look.shape,
                glow: !!look.glow,
                spin: rnd(-6, 6), rot: rnd(0, Math.PI * 2)
            });
        }
        for (let r = 0; r < (look.rings || 0); r++) {
            rings.push({ x, y, radius: 4, grow: look.spread * power * (1 + r * 0.6), life: 0.55 + r * 0.15, age: -r * 0.08, color: look.colors[0] });
        }
        for (let b = 0; b < (look.bolts || 0); b++) {
            const angle = rnd(0, Math.PI * 2), length = rnd(40, 90) * power;
            const points = [[x, y]];
            let px = x, py = y;
            for (let s = 1; s <= 6; s++) {
                px = x + Math.cos(angle) * length * s / 6 + rnd(-10, 10);
                py = y + Math.sin(angle) * length * s / 6 + rnd(-10, 10);
                points.push([px, py]);
            }
            bolts.push({ points, life: 0.25, age: b * 0.05, color: look.colors[1] });
        }
        if (parts.length > 900) parts.splice(0, parts.length - 900);
        start();
    }

    function drawPart(p, alpha) {
        ctx.globalAlpha = alpha;
        ctx.fillStyle = p.color;
        ctx.strokeStyle = p.color;
        const s = p.size;
        switch (p.shape) {
            case 'ember':
            case 'mote':
            case 'spark':
                ctx.beginPath();
                ctx.arc(p.x, p.y, s * (p.shape === 'ember' ? 1 - p.age / p.life * 0.6 : 1), 0, Math.PI * 2);
                ctx.fill();
                break;
            case 'smoke':
                ctx.globalAlpha = alpha * 0.45;
                ctx.beginPath();
                ctx.arc(p.x, p.y, s * (1 + p.age / p.life * 1.5), 0, Math.PI * 2);
                ctx.fill();
                break;
            case 'drop':
                ctx.beginPath();
                ctx.ellipse(p.x, p.y, s * 0.7, s, 0, 0, Math.PI * 2);
                ctx.fill();
                break;
            case 'shard':
                ctx.save();
                ctx.translate(p.x, p.y);
                ctx.rotate(p.rot);
                ctx.beginPath();
                ctx.moveTo(0, -s * 1.6);
                ctx.lineTo(s * 0.6, 0);
                ctx.lineTo(0, s * 1.6);
                ctx.lineTo(-s * 0.6, 0);
                ctx.closePath();
                ctx.fill();
                ctx.restore();
                break;
            case 'ray':
            case 'streak': {
                const len = Math.hypot(p.vx, p.vy) * (p.shape === 'ray' ? 0.06 : 0.04) + s * 2;
                const a = Math.atan2(p.vy, p.vx);
                ctx.lineWidth = s * (p.shape === 'ray' ? 0.9 : 0.7);
                ctx.lineCap = 'round';
                ctx.beginPath();
                ctx.moveTo(p.x, p.y);
                ctx.lineTo(p.x - Math.cos(a) * len, p.y - Math.sin(a) * len);
                ctx.stroke();
                break;
            }
            case 'spiral': {
                ctx.lineWidth = 1.5;
                ctx.beginPath();
                ctx.arc(p.x, p.y, s * 1.5, p.rot, p.rot + Math.PI * 1.3);
                ctx.stroke();
                break;
            }
        }
    }

    function frame(now) {
        const dt = Math.min(0.05, (now - last) / 1000);
        last = now;
        ctx.setTransform(dpr, 0, 0, dpr, 0, 0);
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.globalCompositeOperation = 'lighter';

        parts = parts.filter(p => (p.age += dt) < p.life);
        for (const p of parts) {
            p.vx *= 1 - 2.2 * dt;
            p.vy = p.vy * (1 - 2.2 * dt) + p.g * dt * 3;
            p.x += p.vx * dt;
            p.y += p.vy * dt;
            p.rot += p.spin * dt;
            const alpha = Math.max(0, 1 - p.age / p.life);
            if (p.glow && p.shape !== 'smoke') {
                ctx.shadowBlur = 8;
                ctx.shadowColor = p.color;
            } else {
                ctx.shadowBlur = 0;
            }
            if (p.shape === 'smoke') ctx.globalCompositeOperation = 'source-over';
            drawPart(p, alpha);
            if (p.shape === 'smoke') ctx.globalCompositeOperation = 'lighter';
        }
        ctx.shadowBlur = 0;

        rings = rings.filter(r => (r.age += dt) < r.life);
        for (const r of rings) {
            if (r.age < 0) continue;
            const t = r.age / r.life;
            ctx.globalAlpha = (1 - t) * 0.8;
            ctx.strokeStyle = r.color;
            ctx.lineWidth = 3 * (1 - t) + 1;
            ctx.beginPath();
            ctx.arc(r.x, r.y, r.radius + r.grow * t, 0, Math.PI * 2);
            ctx.stroke();
        }

        bolts = bolts.filter(b => (b.age += dt) < b.life);
        for (const b of bolts) {
            if (b.age < 0) continue;
            ctx.globalAlpha = 1 - b.age / b.life;
            ctx.strokeStyle = b.color;
            ctx.shadowBlur = 12;
            ctx.shadowColor = '#ffffff';
            ctx.lineWidth = 2;
            ctx.beginPath();
            b.points.forEach(([px, py], i) => i ? ctx.lineTo(px, py) : ctx.moveTo(px, py));
            ctx.stroke();
            ctx.shadowBlur = 0;
        }

        ctx.globalAlpha = 1;
        ctx.globalCompositeOperation = 'source-over';
        if (parts.length || rings.length || bolts.length) {
            requestAnimationFrame(frame);
        } else {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            running = false;
        }
    }

    function centerOf(el) {
        const r = el.getBoundingClientRect();
        return { x: r.left + r.width / 2, y: r.top + r.height / 2, size: Math.max(r.width, r.height) };
    }

    function shake(el, strong) {
        if (!el || level() === 'off') return;
        el.classList.remove('rf-fx-quake', 'rf-fx-quake-strong');
        void el.offsetWidth;
        el.classList.add(strong ? 'rf-fx-quake-strong' : 'rf-fx-quake');
        setTimeout(() => el.classList.remove('rf-fx-quake', 'rf-fx-quake-strong'), 500);
    }

    return {
        level,
        setLevel(v) {
            try { localStorage.setItem(key, v); } catch { }
            return this.applyLevel();
        },
        // What the reader chose (the reduced motion of the system aside)
        chosen() {
            let v = 'full';
            try { v = localStorage.getItem(key) || 'full'; } catch { }
            return ['full', 'reduced', 'off'].includes(v) ? v : 'full';
        },

        // A burst at a point of the screen: kind is a damage type (fire, cold…) or hit, crit, miss, heal, fumble
        burst(x, y, kind, power) {
            if (!particles()) return;
            ensure();
            const look = looks[kind] || looks.hit;
            const p = power || 1;
            spawn(x, y, look, Math.round((look.shape === 'smoke' ? 18 : 34) * p), p);
        },

        // On an element (a token, the dice tray): its centre, scaled to its size
        burstOn(el, kind, power) {
            if (!el || !particles()) return;
            const c = centerOf(el);
            this.burst(c.x, c.y, kind, (power || 1) * Math.max(0.6, Math.min(1.6, c.size / 64)));
        },

        // A hit on a token of the table: its damage type, gold for a critical (and the board shakes a little)
        strike(stage, tokenId, kind, damageType) {
            const el = stage && stage.querySelector(`.rf-vtt-token[data-token="${tokenId}"]`);
            if (!el) return;
            const type = kind === 'miss' ? 'miss' : kind === 'heal' ? 'heal' : (damageType && looks[damageType] ? damageType : 'hit');
            this.burstOn(el, type, kind === 'crit' ? 1.3 : 1);
            if (kind === 'crit') {
                this.burstOn(el, 'crit', 1.2);
                shake(stage, true);
            }
        },

        // An area spell landing: a bloom over the whole circle (screen coordinates and radius)
        area(x, y, radius, damageType) {
            if (!particles()) return;
            ensure();
            const look = looks[damageType] || looks.force;
            const r = Math.max(24, radius);
            const count = Math.min(220, Math.round(r * 0.9));
            for (let i = 0; i < count; i++) {
                const a = rnd(0, Math.PI * 2), d = Math.sqrt(Math.random()) * r;
                spawn(x + Math.cos(a) * d, y + Math.sin(a) * d, { ...look, rings: 0, bolts: 0, spread: look.spread * 0.35 }, 1, 1);
            }
            rings.push({ x, y, radius: r * 0.2, grow: r * 0.9, life: 0.7, age: 0, color: look.colors[0] });
            start();
        },

        // An area just placed on the table (its shape on the map), in the colour it was drawn with
        areaShape(stage, shapeId, color) {
            if (!particles()) return;
            const el = stage && stage.querySelector(`[data-shape="${shapeId}"]`);
            if (!el) return;
            const r = el.getBoundingClientRect();
            if (!r.width && !r.height) return;
            ensure();
            const hex = /^#[0-9a-f]{6}$/i.test(color || '') ? color : '#ff8c00';
            const look = { colors: [hex, '#ffffff', hex], rise: -20, spread: 120, size: [2, 4], life: [0.5, 1.1], shape: 'mote', glow: true };
            const radius = Math.max(r.width, r.height) / 2;
            const cx = r.left + r.width / 2, cy = r.top + r.height / 2;
            const count = Math.min(160, Math.round(radius * 0.8) + 20);
            for (let i = 0; i < count; i++) {
                const a = rnd(0, Math.PI * 2), d = Math.sqrt(Math.random());
                spawn(cx + Math.cos(a) * d * r.width / 2, cy + Math.sin(a) * d * r.height / 2, look, 1, 0.4);
            }
            rings.push({ x: cx, y: cy, radius: radius * 0.2, grow: radius * 0.9, life: 0.7, age: 0, color: hex });
            start();
        },

        // The dice: a natural 20 bursts in gold from the tray, a natural 1 cracks red and shakes it
        dice(el, outcome) {
            if (!el) return;
            if (outcome === 'crit') this.burstOn(el, 'crit', 1.4);
            if (outcome === 'fumble') {
                this.burstOn(el, 'fumble', 1);
                shake(el, false);
            }
        },

        // Confetti in the app's colours, falling from the top (a level up)
        celebrate() {
            if (!particles()) return;
            ensure();
            const w = window.innerWidth;
            const look = { colors: ['#ff8c00', '#ffd166', '#f5e6c8', '#4ade80', '#7cc4ff', '#c77dff'], rise: 90, spread: 90, size: [3, 6], life: [1.6, 2.6], shape: 'shard' };
            for (let i = 0; i < 140; i++) spawn(rnd(0, w), rnd(-40, 20), look, 1, 1);
        },

        // A short shake of an element (a strong hit on the board, a failed roll)
        shake,

        // A page opened: its content rises in softly (not with reduced effects)
        pageIn(selector) {
            if (level() !== 'full') return;
            const el = document.querySelector(selector);
            if (!el) return;
            el.classList.remove('rf-page-in');
            void el.offsetWidth;
            el.classList.add('rf-page-in');
            setTimeout(() => el.classList.remove('rf-page-in'), 450);
        },

        // The level on the page: "off" also stops the flashes of the tokens and the dice
        applyLevel() {
            const v = level();
            document.documentElement.classList.toggle('rf-fx-off', v === 'off');
            document.documentElement.classList.toggle('rf-fx-reduced', v === 'reduced');
            return v;
        }
    };
})();
window.rfFx.applyLevel();
