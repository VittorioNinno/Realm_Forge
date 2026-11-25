using Microsoft.JSInterop;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The language model of the backstory assistant, running in this browser (wwwroot/js/backstory.js, WebLLM on WebGPU):
	///	no tokens to run out of and nothing to pay. The model is downloaded only when the player asks for it, once.
	///	</summary>
	public sealed class BackstoryChatService
	{
		private readonly IJSRuntime _js;

		public BackstoryChatService(IJSRuntime js)
		{
			_js = js;
		}

		///	<summary>What this device can do: WebGPU, the model that fits it, its size, whether it is already downloaded.</summary>
		public sealed record Support(bool WebGpu, bool F16, string? Model, int SizeMb, bool Cached);

		public async Task<Support> SupportAsync()
		{
			try
			{
				return await _js.InvokeAsync<Support>("rfStory.support");
			}
			catch (JSException)
			{
				return new Support(false, false, null, 0, false);
			}
		}

		public async Task<bool> LoadAsync(string model, object listener)
		{
			try
			{
				return await _js.InvokeAsync<bool>("rfStory.load", TimeSpan.FromMinutes(30), model, listener);
			}
			catch (Exception ex) when (ex is JSException or TaskCanceledException)
			{
				return false;
			}
		}

		//	The answer arrives in pieces through the listener's Chunk method
		public async Task<bool> ChatAsync(IEnumerable<BackstoryPrompt.Message> messages, object listener, int maxTokens = 400)
		{
			try
			{
				var payload = messages.Select(m => new { role = m.Role, content = m.Content }).ToArray();
				return await _js.InvokeAsync<bool>("rfStory.chat", TimeSpan.FromMinutes(5), payload, listener, maxTokens);
			}
			catch (Exception ex) when (ex is JSException or TaskCanceledException)
			{
				return false;
			}
		}

		public async Task StopAsync()
		{
			try
			{
				await _js.InvokeVoidAsync("rfStory.stop");
			}
			catch (JSException)
			{
			}
		}

		public async Task<bool> RemoveAsync(string model)
		{
			try
			{
				return await _js.InvokeAsync<bool>("rfStory.remove", model);
			}
			catch (JSException)
			{
				return false;
			}
		}
	}
}
