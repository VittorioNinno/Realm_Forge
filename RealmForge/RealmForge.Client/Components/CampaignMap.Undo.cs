using Microsoft.JSInterop;
using RealmForge.Client.Localization;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	A master takes back their last edit of the map (the button, or Ctrl+Z): a token placed, moved, changed or removed,
	///	a door opened, a drawing, the terrain or the fog painted. The server keeps the steps (the last 40 of each master).
	///	</summary>
	public partial class CampaignMap
	{
		private int undoLeft;

		[JSInvokable]
		public Task UndoPressed() => RunsTheTable && Table ? UndoAsync() : Task.CompletedTask;

		private async Task UndoAsync()
		{
			if (map is null || busy || undoLeft <= 0)
			{
				return;
			}
			busy = true;
			localEdits++;
			var (result, error) = await Campaigns.UndoAsync(CampaignId, map.Id);
			busy = false;
			if (result is null)
			{
				castNote = string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : UiText.VttNothingToUndo(Lang);
				undoLeft = 0;
			}
			else
			{
				undoLeft = result.Left;
				castNote = UiText.VttUndone(result.Kind, Lang);
			}
			await RefreshAsync();
		}
	}
}
