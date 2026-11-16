using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The masters' monster drawer: monsters gathered from the search with how many of each, placed on the map in one go
	///	around the middle of the view (hidden or not), or kept as a group of the campaign to place again (a goblin patrol).
	///	</summary>
	public partial class CampaignMap
	{
		private sealed record DrawerEntry(Guid MonsterId, string Name, int Count);

		private List<DrawerEntry> drawer = new();
		private List<MonsterGroupDto>? monsterGroups;
		private bool drawerHidden;
		private string groupName = string.Empty;

		private async Task LoadGroupsAsync()
		{
			if (monsterGroups is not null || !RunsTheTable)
			{
				return;
			}
			monsterGroups = await Campaigns.GetMonsterGroupsAsync(CampaignId, Lang) ?? new();
			StateHasChanged();
		}

		private void AddToDrawer(MonsterResponseDto m)
		{
			monsterSearch = string.Empty;
			monsterResults = new();
			var at = drawer.FindIndex(e => e.MonsterId == m.Id);
			if (at >= 0)
			{
				drawer[at] = drawer[at] with { Count = Math.Min(MonsterGroups.MaxCount, drawer[at].Count + 1) };
			}
			else if (drawer.Count < MonsterGroups.MaxEntries)
			{
				drawer.Add(new DrawerEntry(m.Id, m.Name, 1));
			}
			_ = LoadGroupsAsync();
		}

		private void CountInDrawer(DrawerEntry entry, int change)
		{
			var at = drawer.IndexOf(entry);
			if (at < 0)
			{
				return;
			}
			var count = entry.Count + change;
			if (count <= 0)
			{
				drawer.RemoveAt(at);
			}
			else
			{
				drawer[at] = entry with { Count = Math.Min(MonsterGroups.MaxCount, count) };
			}
		}

		private static List<MonsterGroupEntryDto> EntriesOf(IEnumerable<DrawerEntry> entries) =>
			entries.Select(e => new MonsterGroupEntryDto { MonsterId = e.MonsterId, Count = e.Count }).ToList();

		//	The monsters placed around the middle of the master's view (the middle of the map when there is no view)
		private async Task PlaceAsync(List<MonsterGroupEntryDto> entries)
		{
			if (map is null || entries.Count == 0 || busy)
			{
				return;
			}
			var (x, y) = (map.Width / 2.0, map.Height / 2.0);
			if (!string.IsNullOrEmpty(stageElement.Id))
			{
				try
				{
					var centre = await JS.InvokeAsync<double[]>("rfVtt.view", stageElement);
					(x, y) = (Math.Clamp(centre[0], 0, map.Width), Math.Clamp(centre[1], 0, map.Height));
				}
				catch (JSException)
				{
				}
			}
			busy = true;
			localEdits++;
			var (placed, error) = await Campaigns.PlaceMonstersAsync(CampaignId, map.Id, new PlaceMonstersDto { Entries = entries, X = x, Y = y, Hidden = drawerHidden }, Lang);
			busy = false;
			if (placed is null)
			{
				message = string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : UiText.VttNoRoom(Lang);
				return;
			}
			message = UiText.VttPlaced(placed.Count, Lang);
			await RefreshAsync();
		}

		private Task PlaceDrawerAsync() => PlaceAsync(EntriesOf(drawer));

		private async Task SaveGroupAsync()
		{
			var name = groupName.Trim();
			if (name.Length == 0 || drawer.Count == 0 || busy)
			{
				return;
			}
			busy = true;
			var (group, _) = await Campaigns.SaveMonsterGroupAsync(CampaignId, new SaveMonsterGroupDto { Name = name, Entries = EntriesOf(drawer) }, Lang);
			busy = false;
			if (group is null)
			{
				message = UiText.MapSaveFailed(Lang);
				return;
			}
			monsterGroups = (monsterGroups ?? new()).Where(g => g.Id != group.Id && g.Name != group.Name).Append(group).OrderBy(g => g.Name).ToList();
			groupName = string.Empty;
			message = null;
		}

		private async Task DeleteGroupAsync(MonsterGroupDto group)
		{
			if (busy)
			{
				return;
			}
			busy = true;
			var result = await Campaigns.DeleteMonsterGroupAsync(CampaignId, group.Id);
			busy = false;
			if (result.Ok)
			{
				monsterGroups?.Remove(group);
			}
			else
			{
				message = UiText.MapSaveFailed(Lang);
			}
		}

		//	A group put back in the drawer, to change it before placing it or saving it again
		private void LoadGroup(MonsterGroupDto group)
		{
			drawer = group.Entries.Select((e, i) => new DrawerEntry(e.MonsterId, i < group.Names.Count ? group.Names[i] : "?", e.Count)).ToList();
			groupName = group.Name;
		}

		private static string GroupLine(MonsterGroupDto group) =>
			string.Join(", ", group.Entries.Select((e, i) => $"{e.Count}× {(i < group.Names.Count ? group.Names[i] : "?")}"));
	}
}
