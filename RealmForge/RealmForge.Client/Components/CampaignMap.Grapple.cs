using System.Text.RegularExpressions;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	Grapples and shoves at the table: aimed like an attack at a creature next to it (one of the attacks of the Attack
	///	action), resolved by the server with the bonuses of the two sheets (2024: the other side's save against a DC; 2014:
	///	a contest of Athletics); a grappled creature moves with the one holding it, escapes with its action, is let go.
	///	</summary>
	public partial class CampaignMap
	{
		//	The shove being aimed: pushed away or knocked prone
		private string aimShove = "push";

		private async Task StartManeuverAsync(MapTokenDto t, string maneuver)
		{
			await LoadStatsAsync(t);
			var name = maneuver == "grapple" ? UiText.VttGrapple(Lang) : UiText.VttShove(Lang);
			await StartAimAsync(t, new SheetLine(name, string.Empty, null, null, Reach: AttackReach.Melee));
			aim = aim! with { Maneuver = maneuver };
			aimShove = "push";
		}

		//	The bonuses of a grapple, a shove or an escape, read from the two sheets
		private GrappleDto? ManeuverOf(MapTokenDto actor, MapTokenDto other, string kind)
		{
			if (StatsOf(actor)?.Body is not { } a || StatsOf(other)?.Body is not { } b)
			{
				return null;
			}
			var dto = new GrappleDto { TargetId = other.Id, Kind = kind, ActionAttacks = actor.CharacterId is null ? null : StatsOf(actor)?.ActionAttacks };
			if (kind == "escape")
			{
				dto.ActorBonus = Math.Max(a.Athletics, a.Acrobatics);
				if (b.Edition2024)
				{
					dto.Dc = 8 + b.Str + b.Prof;
				}
				else
				{
					dto.OtherBonus = b.Athletics;
				}
				return dto;
			}
			if (a.Edition2024)
			{
				dto.Dc = 8 + a.Str + a.Prof;
				var saves = StatsOf(other)?.SaveBonuses;
				dto.OtherBonus = saves is { Length: 6 } ? Math.Max(saves[0], saves[1]) : Math.Max(b.Str, b.Dex);
			}
			else
			{
				dto.ActorBonus = a.Athletics;
				dto.OtherBonus = Math.Max(b.Athletics, b.Acrobatics);
			}
			return dto;
		}

		private async Task ManeuverAsync(MapTokenDto actor, MapTokenDto other, string kind)
		{
			if (map is null)
			{
				return;
			}
			await LoadStatsAsync(actor);
			await LoadStatsAsync(other);
			var dto = kind == "release" ? new GrappleDto { TargetId = other.Id, Kind = kind } : ManeuverOf(actor, other, kind);
			if (dto is null)
			{
				turnNote = UiText.MapSaveFailed(Lang);
				return;
			}
			busy = true;
			turnNote = null;
			localEdits++;
			var (result, error) = await Campaigns.GrappleAsync(CampaignId, map.Id, actor.Id, dto, Lang);
			busy = false;
			aim = null;
			aimNote = null;
			if (result is null)
			{
				castNote = string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : error;
			}
			else
			{
				castNote = $"{actor.Label} → {other.Label}: {result.Text}";
				if (tray is not null && result.Dice.Count > 0)
				{
					await tray.ShowAsync(new DiceRollResult(castNote, result.Dice.Select(d => new DieFace(d.Sides, d.Value, d.Dropped)).ToList(), result.Bonus, result.Total, result.Text));
				}
			}
			foreach (var who in new[] { actor, other })
			{
				if (who.CharacterId is { } id)
				{
					InvalidateStats($"c:{id}");
					charVitals.Remove(id);
					_ = LoadStatsAsync(who);
				}
			}
			await RefreshAsync();
		}

		//	Who holds a creature, and the creatures a creature holds
		private MapTokenDto? HolderOf(MapTokenDto t) => t.Turn?.GrappledBy is { } holder ? tokens.FirstOrDefault(k => k.Id == holder) : null;

		private List<MapTokenDto> HeldBy(MapTokenDto t) => tokens.Where(k => k.Turn?.GrappledBy == t.Id).ToList();

		//	A monster's Athletics and Acrobatics from its skills line ("Atletica +5", "Athletics +5"), else its modifiers
		private static TokenBody MonsterBody(string? skills, IReadOnlyList<int> scores, int proficiency, bool edition2024)
		{
			int Mod(int i) => (int)Math.Floor(((i < scores.Count ? scores[i] : 10) - 10) / 2.0);
			int Skill(string pattern, int fallback) =>
				Regex.Match(skills ?? string.Empty, pattern + @"[a-zà-ÿ]*\s*([+−-])\s*(\d+)", RegexOptions.IgnoreCase) is { Success: true } m && int.TryParse(m.Groups[2].Value, out var v)
					? (m.Groups[1].Value == "+" ? v : -v) : fallback;
			return new TokenBody(Mod(0), Mod(1), Math.Max(2, proficiency), Skill(@"(?:atletic|athletic)", Mod(0)), Skill(@"(?:acrobaz|acrobatic)", Mod(1)), edition2024);
		}
	}
}
