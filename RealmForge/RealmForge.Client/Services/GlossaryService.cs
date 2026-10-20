using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client for /api/rules and /api/compendium/index. Keeps the glossary and the names of the Base content of each language
	///	in memory and builds, for each edition, the <see cref="GlossaryLinker"/> that links rules terms and spells in the texts.
	///	</summary>
	public class GlossaryService
	{
		private readonly HttpClient _http;
		private readonly ILogger<GlossaryService> _logger;

		private readonly Dictionary<LanguageCode, Task<List<RuleEntryResponseDto>?>> _loads = new();
		private readonly Dictionary<(LanguageCode, RulesetVersion), GlossaryLinker> _linkers = new();
		private readonly Dictionary<(LanguageCode, RulesetVersion), EquipmentNameMatcher> _equipment = new();
		private readonly Dictionary<LanguageCode, Task<CompendiumIndexDto?>> _indexes = new();

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
		///	Loads the glossary and the index of the Base content of the language, so that <see cref="Linker"/> can link
		///	rules terms and spell names, and <see cref="FindEquipment"/> can find the items of the starting equipment.
		///	</summary>
		public async Task EnsureLoadedAsync(LanguageCode language)
		{
			var entriesTask = GetEntriesAsync(language);
			var indexTask = GetIndexAsync(language);
			var entries = await entriesTask;
			var index = await indexTask;

			foreach (var ruleset in Enum.GetValues<RulesetVersion>())
			{
				if (_linkers.ContainsKey((language, ruleset)))
				{
					continue;
				}

				var terms = entries.Where(e => e.Ruleset == ruleset).Select(e => new GlossaryTerm(
					e.Id, e.Name, GlossaryCategoryLabel(e.Category, language), e.Summary, e.Aliases)).ToList();
				var spells = index?.Spells.Where(s => s.Ruleset == ruleset).Select(s => (s.Name, s.Id)).ToList();
				var linker = new GlossaryLinker(terms, spells);

				//	Kept only when complete: a failed load is retried on the next page
				if (terms.Count > 0 && index is not null)
				{
					_linkers[(language, ruleset)] = linker;
					_equipment[(language, ruleset)] = new EquipmentNameMatcher(index.Equipment.Where(e => e.Ruleset == ruleset).Select(e => (e.Name, e.Id)));
				}
			}
		}

		///	<summary>
		///	Linker of the edition, or null while the glossary of the language is not loaded (texts are then shown as they are).
		///	</summary>
		public GlossaryLinker? Linker(LanguageCode language, RulesetVersion ruleset) =>
			_linkers.TryGetValue((language, ruleset), out var linker) ? linker : null;

		///	<summary>
		///	Base item named in a line of starting equipment, if any.
		///	</summary>
		public Guid? FindEquipment(LanguageCode language, RulesetVersion ruleset, string text) =>
			_equipment.TryGetValue((language, ruleset), out var matcher) ? matcher.Find(text) : null;

		///	<summary>
		///	Base class that uses the spell list (for the links of a spell to its classes).
		///	</summary>
		public Guid? ClassOfSpellList(LanguageCode language, RulesetVersion ruleset, SpellcastingClass list) =>
			_indexes.TryGetValue(language, out var load) && load.IsCompletedSuccessfully && load.Result is { } index
				? index.Classes.FirstOrDefault(c => c.Ruleset == ruleset && c.SpellList == list)?.Id
				: null;

		///	<summary>
		///	Spell list used by a Base class (for the link of a class to its spells).
		///	</summary>
		public SpellcastingClass? SpellListOfClass(LanguageCode language, Guid classId) =>
			_indexes.TryGetValue(language, out var load) && load.IsCompletedSuccessfully && load.Result is { } index
				? index.Classes.FirstOrDefault(c => c.Id == classId)?.SpellList
				: null;

		///	<summary>
		///	Rules key of a Base class ("wizard", "monk"…), used by the character rules (Unarmored Defense, half casters).
		///	</summary>
		public string? ClassKey(LanguageCode language, Guid classId) =>
			_indexes.TryGetValue(language, out var load) && load.IsCompletedSuccessfully && load.Result is { } index
				? index.Classes.FirstOrDefault(c => c.Id == classId)?.Key
				: null;

		private async Task<CompendiumIndexDto?> GetIndexAsync(LanguageCode language)
		{
			if (!_indexes.TryGetValue(language, out var load))
			{
				load = FetchIndexAsync(language);
				_indexes[language] = load;
			}

			var index = await load;
			if (index is null)
			{
				_indexes.Remove(language);
			}

			return index;
		}

		private async Task<CompendiumIndexDto?> FetchIndexAsync(LanguageCode language)
		{
			try
			{
				return await _http.GetFromJsonAsync<CompendiumIndexDto>($"api/compendium/index?lang={(int)language}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load the compendium index for language {Language}", language);
				return null;
			}
		}

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
