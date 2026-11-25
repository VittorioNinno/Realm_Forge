// The backstory assistant: a small language model that runs in the player's browser (WebLLM, WebGPU), so it has no
// tokens to run out of and costs nothing. The model is downloaded once, when the player asks for it, and stays in the
// browser's cache. Without WebGPU the page uses the rule-based assistant written in C#.
window.rfStory = (() => {
    // Qwen 2.5 1.5B: small, good in Italian and English; the f32 variant for GPUs without 16-bit shaders
    const models = { f16: 'Qwen2.5-1.5B-Instruct-q4f16_1-MLC', f32: 'Qwen2.5-1.5B-Instruct-q4f32_1-MLC' };
    const sizeMb = { f16: 1100, f32: 1300 };
    let webllm = null, engine = null, loading = null, modelId = null, busy = false;

    const lib = () => webllm ??= import(new URL('lib/webllm/web-llm.js', document.baseURI).href);

    async function support() {
        try {
            // Automated browsers (the UI tests) use the rule-based assistant, unless a test asks for the model
            let forced = false;
            try { forced = localStorage.getItem('rf-story-test') === '1'; } catch { }
            if (navigator.webdriver && !forced) return { webgpu: false, f16: false, model: null, sizeMb: 0, cached: false };
            if (!('gpu' in navigator)) return { webgpu: false, f16: false, model: null, sizeMb: 0, cached: false };
            const adapter = await navigator.gpu.requestAdapter();
            if (!adapter) return { webgpu: false, f16: false, model: null, sizeMb: 0, cached: false };
            const f16 = adapter.features.has('shader-f16');
            const kind = f16 ? 'f16' : 'f32';
            let cached = false;
            try { cached = await (await lib()).hasModelInCache(models[kind]); } catch { }
            return { webgpu: true, f16, model: models[kind], sizeMb: sizeMb[kind], cached };
        } catch {
            return { webgpu: false, f16: false, model: null, sizeMb: 0, cached: false };
        }
    }

    // Downloads (the first time) and starts the model; progress goes to the component as 0..1 with a short text
    async function load(model, dotnet) {
        if (engine && modelId === model) return true;
        if (loading) return loading;
        loading = (async () => {
            try {
                const { CreateWebWorkerMLCEngine } = await lib();
                const worker = new Worker(new URL('js/backstory-worker.js', document.baseURI), { type: 'module' });
                engine = await CreateWebWorkerMLCEngine(worker, model, {
                    initProgressCallback: (report) => {
                        dotnet?.invokeMethodAsync('Progress', report.progress ?? 0, report.text ?? '').catch(() => { });
                    }
                });
                modelId = model;
                return true;
            } catch (error) {
                engine = null;
                dotnet?.invokeMethodAsync('Failed', String(error?.message ?? error)).catch(() => { });
                return false;
            } finally {
                loading = null;
            }
        })();
        return loading;
    }

    // One answer, streamed piece by piece to the component; messages: [{role, content}]
    async function chat(messages, dotnet, maxTokens) {
        if (!engine || busy) return false;
        busy = true;
        try {
            const stream = await engine.chat.completions.create({
                messages, stream: true, temperature: 0.8, top_p: 0.9, max_tokens: maxTokens || 400
            });
            for await (const chunk of stream) {
                const piece = chunk.choices?.[0]?.delta?.content;
                if (piece) await dotnet.invokeMethodAsync('Chunk', piece);
            }
            return true;
        } catch (error) {
            dotnet?.invokeMethodAsync('Failed', String(error?.message ?? error)).catch(() => { });
            return false;
        } finally {
            busy = false;
            try { await engine?.resetChat(); } catch { }
        }
    }

    function stop() {
        try { engine?.interruptGenerate(); } catch { }
    }

    // Frees the space the model takes in the browser
    async function remove(model) {
        try {
            stop();
            try { await engine?.unload(); } catch { }
            engine = null; modelId = null;
            await (await lib()).deleteModelAllInfoInCache(model);
            return true;
        } catch {
            return false;
        }
    }

    return { support, load, chat, stop, remove };
})();
