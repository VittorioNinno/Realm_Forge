using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/rules. Keeps the glossary of each language in memory (it is small and read only) and builds,
	///	for each edition, the <see cref="GlossaryLinker"/> that links the rules terms in the other descriptions.
	///	</summary>
	public class GlossaryService
	{
		private readonly HttpClient _http;
		private readonly ILogger<GlossaryService> _logger;

		private readonly Dictionary<LanguageCode, Task<List<RuleEntryResponseDto>?>> _loads = new();
		private readonly Dictionary<(LanguageCode, RulesetVersion), GlossaryLinker> _linkers = new();

		public GlossaryService(HttpClient http, ILogger<GlossaryService> logger)
		{
			_http = http;
			_logger = logger;
		}

		///	<summary>
		///	Every entry of both editions in the language (cached; a failed load is retried on the next call).
		///	</summary>
		public async Task<List<RuleEntryResponseDto>> GetEntriesAsync(LanguageCode language)
		{
			if (!_loads.TryGetValue(language, out var load))
			{
				load = FetchAsync(language);
				_loads[language] = load;
			}

			var entries = await load;
			if (entries is null)
			{
				_loads.Remove(language);
				return new List<RuleEntryResponseDto>();
			}

			return entries;
		}

		///	<summary>
		///	Loads the glossary of the language, so that <see cref="Linker"/> can link its terms.
		///	</summary>
		public async Task EnsureLoadedAsync(LanguageCode language)
		{
			var entries = await GetEntriesAsync(language);

			foreach (var edition in entries.GroupBy(e => e.Ruleset))
			{
				if (!_linkers.ContainsKey((language, edition.Key)))
				{
					_linkers[(language, edition.Key)] = new GlossaryLinker(edition.Select(e => new GlossaryTerm(
						e.Id, e.Name, GlossaryCategoryLabel(e.Category, language), e.Summary, e.Aliases)));
				}
			}
		}

		///	<summary>
		///	Linker of the edition, or null while the glossary of the language is not loaded (texts are then shown as they are).
		///	</summary>
		public GlossaryLinker? Linker(LanguageCode language, RulesetVersion ruleset) =>
			_linkers.TryGetValue((language, ruleset), out var linker) ? linker : null;

		public async Task<RuleEntryDetailResponseDto?> GetEntryAsync(Guid id, LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<RuleEntryDetailResponseDto>($"api/rules/{id}?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load glossary entry {EntryId} for language {Language}", id, language);
				return null;
			}
		}

		private async Task<List<RuleEntryResponseDto>?> FetchAsync(LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<List<RuleEntryResponseDto>>($"api/rules?lang={(int)language}") ?? new List<RuleEntryResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the rules glossary for language {Language}", language);
				return null;
			}
		}

		//	Shown in the tooltip under the term name (e.g. "Condizione")
		private static string GlossaryCategoryLabel(RuleCategory category, LanguageCode language) =>
			RealmForge.Client.Localization.UiText.RuleCategoryName(category, language);
	}
}
