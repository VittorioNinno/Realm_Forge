using Microsoft.AspNetCore.Components.Authorization;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The campaigns whose virtual tabletop is open now, checked every half minute by LiveTableNotices (in the layout):
	///	the notices to the players and the campaign page read it.
	///	</summary>
	public sealed class LiveTableService
	{
		private readonly CampaignDataService _campaigns;
		private readonly AuthenticationStateProvider _auth;

		public LiveTableService(CampaignDataService campaigns, AuthenticationStateProvider auth)
		{
			_campaigns = campaigns;
			_auth = auth;
		}

		public IReadOnlyList<CampaignLiveTableDto> Tables { get; private set; } = Array.Empty<CampaignLiveTableDto>();

		public event Action? Changed;

		public CampaignLiveTableDto? Of(Guid campaignId) => Tables.FirstOrDefault(t => t.CampaignId == campaignId);

		public async Task RefreshAsync()
		{
			var state = await _auth.GetAuthenticationStateAsync();
			if (state.User.Identity?.IsAuthenticated != true)
			{
				Set(Array.Empty<CampaignLiveTableDto>());
				return;
			}
			//	A failed check keeps what was known
			if (await _campaigns.GetLiveTablesAsync() is { } tables)
			{
				Set(tables);
			}
		}

		//	A master opened or closed a table here: everyone on this page knows at once
		public void Update(Guid campaignId, CampaignLiveTableDto? table) =>
			Set(Tables.Where(t => t.CampaignId != campaignId).Concat(table is null ? Array.Empty<CampaignLiveTableDto>() : new[] { table }).ToList());

		private void Set(IReadOnlyList<CampaignLiveTableDto> tables)
		{
			var same = tables.Count == Tables.Count && tables.All(t => Tables.Any(o => o.CampaignId == t.CampaignId && o.OpenedAt == t.OpenedAt));
			Tables = tables;
			if (!same)
			{
				Changed?.Invoke();
			}
		}
	}
}
