using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	A handout revealed by the masters opens on the players' screens at the table: when it comes with the table, or on
	///	opening the table when it was revealed in the last quarter of an hour; each reveal once.
	///	</summary>
	public partial class CampaignMap
	{
		private CampaignHandoutDto? popupHandout;
		private readonly HashSet<string> handoutsSeen = new();
		private bool handoutsStarted;

		private async Task ShowHandoutAsync(HandoutShownDto? shown)
		{
			var first = !handoutsStarted;
			handoutsStarted = true;
			if (shown is null || RunsTheTable || !Table || !handoutsSeen.Add($"{shown.Id}|{shown.RevealedAt:O}"))
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
