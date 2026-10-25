using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Draft of the wizard kept in the browser (localStorage): leaving the page, following a link or reloading does
	///	not lose the choices. One draft for the new character and one per character being edited; cleared on save.
	///	</summary>
	public partial class CharacterWizard
	{
		private static readonly JsonSerializerOptions DraftJson = new(JsonSerializerDefaults.Web);

		[Inject] private IJSRuntime JS { get; set; } = default!;

		private CancellationTokenSource? draftDelay;
		private bool draftReady;
		public bool DraftRestored { get; private set; }

		private string DraftKey => Id is { } id ? $"realmforge.character-draft.{id}" : "realmforge.character-draft";

		public sealed class WizardDraft
		{
			public int Version { get; set; } = 1;
			public WizardMode Mode { get; set; }
			public CharacterInput Input { get; set; } = new();
			public WizardAbilityState.Snapshot Abilities { get; set; } = new();
			public int StepIndex { get; set; }
			public int FurthestIndex { get; set; }
			public int SavedLevels { get; set; }
			public DateTimeOffset SavedAt { get; set; }
		}

		private async Task<WizardDraft?> ReadDraftAsync()
		{
			try
			{
				var json = await JS.InvokeAsync<string?>("localStorage.getItem", DraftKey);
				var draft = string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.Deserialize<WizardDraft>(json, DraftJson);
				return draft is { Version: 1 } && draft.Mode == Mode && draft.Input.Build.Levels.Count > 0 ? draft : null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		///	<summary>
		///	Restores a draft of the same mode (and, when editing, of the same edition).
		///	</summary>
		private async Task<bool> TryRestoreDraftAsync()
		{
			var draft = await ReadDraftAsync();
			if (draft is null || (Mode != WizardMode.Create && draft.Input.Ruleset != Input.Ruleset))
			{
				return false;
			}

			Input = draft.Input;
			Abilities.Restore(draft.Abilities);
			stepIndex = draft.StepIndex;
			furthestIndex = Math.Max(draft.FurthestIndex, draft.StepIndex);
			if (Mode == WizardMode.LevelUp)
			{
				SavedLevels = draft.SavedLevels;
			}
			DraftRestored = true;
			return true;
		}

		//	Saved a moment after the last change
		private void ScheduleDraftSave()
		{
			if (!draftReady || saving)
			{
				return;
			}

			draftDelay?.Cancel();
			var delay = draftDelay = new CancellationTokenSource();
			_ = SaveDraftAsync(delay.Token);
		}

		private async Task SaveDraftAsync(CancellationToken token)
		{
			try
			{
				await Task.Delay(400, token);
				var draft = new WizardDraft
				{
					Mode = Mode,
					Input = Input,
					Abilities = Abilities.ToSnapshot(),
					StepIndex = stepIndex,
					FurthestIndex = furthestIndex,
					SavedLevels = SavedLevels,
					SavedAt = DateTimeOffset.UtcNow
				};
				await JS.InvokeVoidAsync("localStorage.setItem", DraftKey, JsonSerializer.Serialize(draft, DraftJson));
			}
			catch (Exception)
			{
				//	Private windows or full storage: the wizard still works, only without a draft
			}
		}

		private async Task ClearDraftAsync()
		{
			draftDelay?.Cancel();
			try
			{
				await JS.InvokeVoidAsync("localStorage.removeItem", DraftKey);
			}
			catch (Exception)
			{
			}
		}

		///	<summary>
		///	Drops the draft and starts again from the saved character (or a new one).
		///	</summary>
		public async Task DiscardDraftAsync()
		{
			await ClearDraftAsync();
			DraftRestored = false;
			draftReady = false;
			Input = new CharacterInput { Ruleset = RulesetVersion.Dnd5e_2024 };
			Abilities.Reset();
			stepIndex = furthestIndex = 0;
			stepProblems.Clear();
			await LoadAsync(useDraft: false);
			StateHasChanged();
		}
	}
}
