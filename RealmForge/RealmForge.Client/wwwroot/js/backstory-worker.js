// The backstory assistant's model runs here, off the page: the interface never freezes while it writes
import { WebWorkerMLCEngineHandler } from '../lib/webllm/web-llm.js';

const handler = new WebWorkerMLCEngineHandler();
self.onmessage = (message) => handler.onmessage(message);
