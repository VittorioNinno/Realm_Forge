using Microsoft.JSInterop;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Current UI language. The choice is saved in localStorage and restored at startup,
	///	and the page's &lt;html lang&gt; attribute is kept in sync.
	///	</summary>
	public class LanguageStateService
	{
		private const string StorageKey = "realmforge.lang";

		private readonly IJSRuntime _js;

		public LanguageStateService(IJSRuntime js)
		{
			_js = js;
		}

		public LanguageCode CurrentLanguage { get; private set; } = LanguageCode.It;

		//	Event raised to notify registered components when the language changes
		public event Action? OnLanguageChanged;

		///	<summary>
		///	Restores the saved language. Called once in Program.cs before the first render.
		///	</summary>
		public async Task InitializeAsync()
		{
			try
			{
				var saved = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
				if (Enum.TryParse<LanguageCode>(saved, ignoreCase: true, out var language) && Enum.IsDefined(language))
				{
					CurrentLanguage = language;
				}

				await ApplyHtmlLangAsync();
			}
			catch (JSException)
			{
				//	Storage unavailable (e.g. private mode with blocked storage): keep the default language
			}
		}

		public void SetLanguage(LanguageCode newLanguage)
		{
			if (CurrentLanguage == newLanguage)
			{
				return;
			}

			CurrentLanguage = newLanguage;
			OnLanguageChanged?.Invoke();
			_ = PersistAsync();
		}

		private async Task PersistAsync()
		{
			try
			{
				await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, CurrentLanguage.ToString());
				await ApplyHtmlLangAsync();
			}
			catch (JSException)
			{
			}
		}

		private ValueTask ApplyHtmlLangAsync() =>
			_js.InvokeVoidAsync("realmForge.setDocumentLanguage", CurrentLanguage == LanguageCode.It ? "it" : "en");
	}
}
