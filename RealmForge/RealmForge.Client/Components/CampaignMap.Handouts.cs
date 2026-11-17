using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	A handout revealed by the masters opens on the players' screens at the table: when it comes with the table, or on
	///	opening the table when it was revealed in the last quarter of an hour; each reveal once.
	///	</summary>
	public partial class CampaignMap
	{
		//	The clock of the campaign (game minutes), shown in the bar of the table
		private long? gameClock;

		private CampaignHandoutDto? popupHandout;

		//	The handout shown to the whole table in place of the map
		private Guid? sceneId;
		private CampaignHandoutDto? sceneHandout;

		private async Task ShowSceneAsync(Guid? scene)
		{
			if (scene == sceneId)
			{
				return;
			}
			sceneId = scene;
			sceneHandout = scene is { } id ? await Campaigns.GetHandoutAsync(CampaignId, id, Lang) : null;
			await InvokeAsync(StateHasChanged);
		}

		private async Task EndSceneAsync()
		{
			busy = true;
			localEdits++;
			await Campaigns.EndSceneAsync(CampaignId);
			busy = false;
			await RefreshAsync();
		}
		private readonly HashSet<string> handoutsSeen = new();
		private bool handoutsStarted;

		private async Task ShowHandoutAsync(HandoutShownDto? shown)
		{
			var first = !handoutsStarted;
			handoutsStarted = true;
			if (shown is null || RunsTheTable || !Table || !handoutsSeen.Add($"{shown.Id}|{shown.RevealedAt:O}") || shown.Id == sceneId)
			{
				return;
			}
			if (first && DateTimeOffset.UtcNow - shown.RevealedAt > TimeSpan.FromMinutes(15))
			{
				return;
			}
			if (await Campaigns.GetHandoutAsync(CampaignId, shown.Id, Lang) is { } handout)
			{
				popupHandout = handout;
				await InvokeAsync(StateHasChanged);
			}
		}
	}
}
