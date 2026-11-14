using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The turn of a token in a fight: the action, the bonus action, the reaction and the free interaction left, the
	///	standard actions (Dash doubles the movement, Disengage lets it leave a reach freely, Dodge puts attacks against it at
	///	a disadvantage), the weapon in hand (melee or ranged) and the attacks of opportunity offered to its controller.
	///	</summary>
	public partial class CampaignMap
	{
		private string? turnNote;

		private TokenTurnDto? TurnOf(MapTokenDto t) => combat is not null && combat.Round > 0 && t.CharacterId is not null ? t.Turn : null;

		private bool IsTurnOf(MapTokenDto t) => combat?.Order.FirstOrDefault(o => o.Id == combat.CurrentId)?.TokenId == t.Id;

		//	Melee and ranged attacks on the sheet: the weapon in hand can be changed
		private bool HasBothKinds(MapTokenDto t)
		{
			var attacks = StatsOf(t)?.Sheet?.Attacks;
			if (attacks is null)
			{
				return false;
			}
			var ranged = attacks.Count(a => a.Reach is { } r && r.Range > 0 && r.Reach <= 0);
			return ranged > 0 && ranged < attacks.Count;
		}

		private async Task TurnActionAsync(MapTokenDto t, string kind, string? wield)
		{
			if (map is null)
			{
				return;
			}
			busy = true;
			turnNote = null;
			localEdits++;
			var (_, error) = await Campaigns.TurnActionAsync(CampaignId, map.Id, t.Id, new TurnActionDto { Kind = kind, Wield = wield }, Lang);
			busy = false;
			if (error is not null)
			{
				turnNote = error.Length > 0 ? error : UiText.MapSaveFailed(Lang);
			}
			await RefreshAsync();
		}

		//	(reactor, the token that left its reach), for the creatures this account rolls for
		private List<(MapTokenDto Reactor, MapTokenDto Target)> Opportunities => combat is null || combat.Round <= 0 ? new()
			: tokens.Where(t => t.Turn?.OpportunityOn is not null && CanRoll(t))
				.Select(t => (Reactor: t, Target: tokens.FirstOrDefault(k => k.Id == t.Turn!.OpportunityOn)))
				.Where(p => p.Target is not null)
				.Select(p => (p.Reactor, p.Target!))
				.ToList();

		//	The first melee attack of the creature, aimed at the token at once (the reaction is spent by the attack)
		private async Task TakeOpportunityAsync(MapTokenDto reactor, MapTokenDto target)
		{
			await LoadStatsAsync(reactor);
			var attacks = StatsOf(reactor)?.Sheet?.Attacks ?? new();
			var attack = attacks.FirstOrDefault(a => a.Reach is not { } r || r.Reach > 0) ?? attacks.FirstOrDefault();
			if (attack is null)
			{
				turnNote = UiText.VttOpportunityNoAttack(Lang);
				await TurnActionAsync(reactor, "pass", null);
				return;
			}
			await StartAimAsync(reactor, attack);
			await AimAtAsync(target.Id);
			StateHasChanged();
		}
	}
}
