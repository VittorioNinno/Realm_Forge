using Microsoft.JSInterop;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The visual effects of the table (wwwroot/js/fx.js): an area of a spell blooms when it lands on the map, in its
	///	colour; the hits burst in the colour of their damage type (rfVtt.strike).
	///	</summary>
	public partial class CampaignMap
	{
		//	The areas just placed, bloomed once they are drawn
		private readonly List<(Guid Id, string Color)> areaBlooms = new();

		private static bool IsArea(MapShapeDto shape) => shape.Kind is ShapeKind.Cone or ShapeKind.Sphere or ShapeKind.Line or ShapeKind.Cube;

		//	The shapes changed: the areas that were not there before are waiting for their bloom
		private void NoteNewAreas(IReadOnlyCollection<MapShapeDto> before, IEnumerable<MapShapeDto> after)
		{
			var known = before.Select(s => s.Id).ToHashSet();
			foreach (var shape in after.Where(s => IsArea(s) && !known.Contains(s.Id)))
			{
				areaBlooms.Add((shape.Id, shape.Color));
			}
		}

		private async Task BloomAreasAsync()
		{
			if (areaBlooms.Count == 0)
			{
				return;
			}
			var blooms = areaBlooms.ToList();
			areaBlooms.Clear();
			foreach (var (id, color) in blooms)
			{
				try
				{
					await JS.InvokeVoidAsync("rfFx.areaShape", stageElement, id.ToString(), color);
				}
				catch (JSException)
				{
				}
			}
		}
	}
}
