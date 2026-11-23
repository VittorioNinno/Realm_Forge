using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	While an attack or a spell is aimed: on each possible target, its distance from the attacker, whether it is in
	///	normal range, at long range (disadvantage) or out of reach, and the cover the walls of the map give it.
	///	</summary>
	public partial class CampaignMap
	{
		private sealed record AimTagInfo(string Text, string Css, string Title);

		private AimTagInfo? AimTag(MapTokenDto t)
		{
			if (aim is null || tokens.FirstOrDefault(k => k.Id == aim.AttackerId) is not { } attacker || t.Id == attacker.Id || !IsTarget(t))
			{
				return null;
			}
			var gap = GapOf(attacker, t);
			var reach = aim.Attack.Reach ?? AttackReach.Melee;
			var (can, far) = reach.At(gap);
			var cover = terrainCells.Count == 0 ? 0
				: MapTerrain.Cover(gridType, grid, offsetX, offsetY, terrainCells, ClosedDoors().ToHashSet(), (attacker.X, attacker.Y, attacker.Size), (t.X, t.Y, t.Size));
			var parts = new List<string> { DistanceText(gap) };
			var titles = new List<string> { UiText.VttAimDistance(DistanceText(gap), Lang) };
			if (!can)
			{
				parts.Add(UiText.VttAimOut(Lang));
				titles.Add(UiText.VttAimOutHint(Lang));
			}
			else if (far)
			{
				parts.Add(UiText.VttAimLong(Lang));
				titles.Add(UiText.VttAimLongHint(Lang));
			}
			if (cover >= MapTerrain.TotalCover)
			{
				parts.Add(UiText.VttAimCoverTotal(Lang));
				titles.Add(UiText.VttAimCoverTotalHint(Lang));
			}
			else if (cover > 0)
			{
				parts.Add(UiText.VttAimCover(cover, Lang));
				titles.Add(UiText.VttAimCoverHint(cover, Lang));
			}
			var css = !can || cover >= MapTerrain.TotalCover ? "out" : far ? "far" : cover > 0 ? "cover" : "in";
			return new AimTagInfo(string.Join(" · ", parts), css, string.Join(" · ", titles));
		}

		//	A distance of the grid in the reader's unit (metres in Italian, feet in English)
		private string DistanceText(int cells)
		{
			var value = (cells * UiText.VttPerCell(Lang)).ToString("0.#", System.Globalization.CultureInfo.GetCultureInfo(Lang == Shared.Enums.LanguageCode.It ? "it-IT" : "en-GB"));
			return $"{value} {UiText.VttUnit(Lang)}";
		}
	}
}
