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

		//	Every creature of the fight has its turn (the characters, the monsters, the others the master runs)
		private TokenTurnDto? TurnOf(MapTokenDto t) => combat is not null && combat.Round > 0 && t.Kind != TokenKind.Prop ? t.Turn : null;

		//	Nothing left for an attack: on its turn the action used otherwise or its attacks over (a character's Extra Attack;
		//	a monster's multiattack is one action), outside it the reaction used
		private bool AttacksGone(MapTokenDto t)
		{
			if (TurnOf(t) is not { } turn)
			{
				return false;
			}
			if (!IsTurnOf(t))
			{
				return t.ReactionUsed && turn.OpportunityOn is null;
			}
			var most = t.CharacterId is not null ? StatsOf(t)?.ActionAttacks ?? 1 : int.MaxValue;
			return t.ActionSpent == TableCombat.SpentOther || (t.ActionSpent == TableCombat.SpentAttack && turn.AttacksMade >= most);
		}

		//	The part of the turn a feature takes is used already (on its own turn; the reaction at any time)
		private bool SlotGone(MapTokenDto t, RealmForge.Shared.Characters.FeatureSlot slot) => TurnOf(t) is { } turn && slot switch
		{
			RealmForge.Shared.Characters.FeatureSlot.Action => IsTurnOf(t) && t.ActionSpent is not null,
			RealmForge.Shared.Characters.FeatureSlot.Bonus => IsTurnOf(t) && turn.BonusUsed,
			RealmForge.Shared.Characters.FeatureSlot.Reaction => t.ReactionUsed,
			_ => false
		};

		//	A creature of the fight whose turn it is not (the round started)
		private bool OffTurn(MapTokenDto t) => t.Kind != TokenKind.Prop && combat is { Round: > 0 } && combat.Order.Any(o => o.TokenId == t.Id) && !IsTurnOf(t);

		private bool IsTurnOf(MapTokenDto t) => combat?.Order.FirstOrDefault(o => o.Id == combat.CurrentId)?.TokenId == t.Id;

		//	The weapons of each kind on the sheet (the spells left out): the one in hand can be changed to the other kind
		private (int Melee, int Ranged) WeaponKinds(MapTokenDto t)
		{
			var attacks = StatsOf(t)?.Sheet?.Attacks?.Where(a => !a.Spell).ToList();
			if (attacks is null)
			{
				return (0, 0);
			}
			var ranged = attacks.Count(a => a.Reach is { } r && r.Range > 0 && r.Reach <= 0);
			return (attacks.Count - ranged, ranged);
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

		// ===== Features used from the table =====

		private string? featureNote;
		private readonly Dictionary<string, int> poolAmounts = new();

		private int PoolAmount(string key, int left) => Math.Clamp(poolAmounts.GetValueOrDefault(key, Math.Min(5, Math.Max(1, left))), 1, Math.Max(1, left));

		//	The dice go to the log, the resource is spent on the sheet with what the roll does (hit points back, temporary
		//	hit points), and in a fight on its own turn the action or bonus action it takes is marked
		private async Task UseFeatureAsync(MapTokenDto t, RealmForge.Shared.Characters.FeatureUse use)
		{
			featureNote = null;
			var stats = StatsOf(t);
			var resource = use.ResourceKey is { } key ? stats?.Resources?.FirstOrDefault(r => r.Key == key) : null;
			var left = resource is null ? int.MaxValue : resource.Maximum - (stats?.Spent?.GetValueOrDefault(resource.Key) ?? 0);
			if (left <= 0)
			{
				return;
			}
			var amount = resource is { Pool: true } ? PoolAmount(use.Key, left) : 1;
			int? rolled = null;
			if (use.Roll is { } dice)
			{
				var result = await RollForAsync(t, new TokenRoll(use.Name, string.Empty, dice, false));
				if (result is null)
				{
					return;
				}
				rolled = result.Total;
			}
			if (resource is not null || use.Effect is "heal" or "temp" or "pool-heal" or "pool-level")
			{
				var proficiency = 0;
				await ChangeCharacterAsync(t, (sheet, computed) =>
				{
					proficiency = computed.ProficiencyBonus;
					var max = Math.Max(1, computed.MaxHitPoints);
					if (resource is not null)
					{
						sheet.ResourceUses[resource.Key] = Math.Min(resource.Maximum, sheet.ResourceUses.GetValueOrDefault(resource.Key) + amount);
					}
					switch (use.Effect)
					{
						case "heal" when rolled is { } healed:
							RealmForge.Shared.Characters.CharacterVitals.Heal(sheet, max, healed);
							break;
						case "pool-heal":
							RealmForge.Shared.Characters.CharacterVitals.Heal(sheet, max, amount);
							break;
						case "pool-level":
							RealmForge.Shared.Characters.CharacterVitals.Heal(sheet, max, computed.Level);
							break;
						case "temp":
							sheet.TemporaryHitPoints = Math.Max(sheet.TemporaryHitPoints, computed.ProficiencyBonus);
							break;
					}
				});
				featureNote = use.Effect switch
				{
					"heal" when rolled is { } h => UiText.VttFeatureHealed(use.Name, h, Lang),
					"pool-heal" => UiText.VttFeatureHealed(use.Name, amount, Lang),
					"temp" => UiText.VttFeatureTemp(use.Name, proficiency, Lang),
					_ => UiText.VttFeatureUsed(use.Name, Lang)
				};
			}
			else
			{
				featureNote = UiText.VttFeatureUsed(use.Name, Lang);
			}
			if (TurnOf(t) is not null && IsTurnOf(t))
			{
				var kind = use.Effect == "surge" ? "surge" : use.Slot switch
				{
					RealmForge.Shared.Characters.FeatureSlot.Action => "other",
					RealmForge.Shared.Characters.FeatureSlot.Bonus => "bonus",
					_ => null
				};
				if (kind is not null)
				{
					var note = featureNote;
					await TurnActionAsync(t, kind, null);
					featureNote = turnNote is null ? note : $"{note} · {turnNote}";
				}
			}
			StateHasChanged();
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
