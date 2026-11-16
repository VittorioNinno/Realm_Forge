using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	Stairs and portals at the table: the creatures next to one go through (to the other end, on this map or another
	///	floor); the masters link each to another one (both ways by default).
	///	</summary>
	public partial class CampaignMap
	{
		private List<MapLinkDto>? mapLinks;
		private bool linkBothWays = true;

		//	Where the master who sent a creature to another map can follow it
		private TravelResultDto? travelled;

		//	The creatures that can go through: next to it, the account's own (any for a master)
		private List<MapTokenDto> TravellersAt(MapTokenDto way) => tokens
			.Where(t => t.Kind is TokenKind.Character or TokenKind.Npc or TokenKind.Monster && t.Layer == TokenLayer.Tokens)
			.Where(t => RunsTheTable || t.Controlled)
			.Where(t => GapOf(t, way) <= 1)
			.ToList();

		private async Task TravelAsync(MapTokenDto way, MapTokenDto who)
		{
			if (map is null || busy)
			{
				return;
			}
			busy = true;
			localEdits++;
			var (result, error) = await Campaigns.TravelAsync(CampaignId, map.Id, way.Id, new TravelDto { TokenId = who.Id });
			busy = false;
			if (result is null)
			{
				propMessage = UiText.VttTravelFailed(TravelReason(error), Lang);
				return;
			}
			CloseToolbar();
			travelled = result.MapId == map.Id ? null : result;
			castNote = UiText.VttTravelled(who.Label, result.MapName, Lang) + (result.Displayed ? $" {UiText.VttTravelShown(Lang)}" : null);
			if (result.MapId != map.Id && (!RunsTheTable || result.Displayed))
			{
				//	The players follow the map shown; a master follows the table when it moved
				await LoadMapsAsync(result.MapId);
				return;
			}
			await RefreshAsync();
		}

		//	The server's reasons, as the keys of their texts
		private static string? TravelReason(string? error) => error switch
		{
			null or "" => null,
			_ when error.Contains("anywhere now", StringComparison.Ordinal) => "inactive",
			_ when error.Contains("Too far", StringComparison.Ordinal) => "far",
			_ when error.Contains("turn", StringComparison.Ordinal) => "turn",
			_ when error.Contains("nowhere", StringComparison.Ordinal) => "nowhere",
			_ when error.Contains("No room", StringComparison.Ordinal) => "full",
			_ => null
		};

		private async Task FollowTravelAsync()
		{
			if (travelled is { } where)
			{
				travelled = null;
				castNote = null;
				await LoadMapsAsync(where.MapId);
			}
		}

		private async Task LoadLinksAsync()
		{
			mapLinks = await Campaigns.GetMapLinksAsync(CampaignId) ?? new();
			StateHasChanged();
		}

		private async Task SaveLinkAsync(MapTokenDto way, string? value)
		{
			if (map is null)
			{
				return;
			}
			Guid? target = Guid.TryParse(value, out var id) ? id : null;
			busy = true;
			localEdits++;
			var result = await Campaigns.SaveLinkAsync(CampaignId, map.Id, way.Id, new SaveLinkDto { TargetId = target, BothWays = linkBothWays });
			busy = false;
			propMessage = result.Ok ? null : UiText.MapSaveFailed(Lang);
			await RefreshAsync();
		}
	}
}
