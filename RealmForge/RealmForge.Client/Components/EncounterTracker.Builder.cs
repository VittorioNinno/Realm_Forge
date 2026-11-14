using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Monsters;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The builder of an encounter: the verdict of its difficulty, the generator that fills it with monsters of a kind
	///	for a target difficulty, one more of a monster already there, the starting cells on a map of the campaign.
	///	</summary>
	public partial class EncounterTracker
	{
		//	The last change was saved
		private bool saved;

		// ===== Difficulty =====

		//	none, low, mid, high: the colour of the verdict and of the meter
		private static string VerdictLevel(EncounterBudget budget) => budget.Thresholds.Length == 0 || budget.TotalXp == 0 ? "none"
			: budget.Ruleset == RulesetVersion.Dnd5e_2014
				? budget.Rating switch { 0 or 1 => "low", 2 => "mid", _ => "high" }
				: budget.Rating switch { 0 or 1 => "low", 2 => "mid", _ => "high" };

		// ===== The generator =====

		private CreatureType? genType;
		private int genLevel = 2;
		private bool generating;

		private List<RfSelect<CreatureType?>.OptionItem> ThemeOptions => new List<RfSelect<CreatureType?>.OptionItem> { new(null, UiText.EncounterGenAny(Lang)) }
			.Concat(Enum.GetValues<CreatureType>()
				.Select(t => new RfSelect<CreatureType?>.OptionItem(t, UiText.FormatCreatureType(t, Lang)))
				.OrderBy(o => o.Label, StringComparer.CurrentCultureIgnoreCase))
			.ToList();

		//	The thresholds of the edition: the difficulty to aim at
		private List<RfSelect<int>.OptionItem> TargetOptions(EncounterBudget budget) =>
			Enumerable.Range(1, budget.Ruleset == RulesetVersion.Dnd5e_2014 ? 4 : 3)
				.Select(i => new RfSelect<int>.OptionItem(i, UiText.EncounterRating(budget.Ruleset, i, Lang)))
				.ToList();

		//	The outcome of the last generation, under the button: what came out, or why nothing did
		private string? genNote;
		private bool genFailed;

		//	A leader near half the budget, then lesser monsters of the same kind, until one more would go past the
		//	difficulty aimed at (the next threshold is never reached); the party joins if it is not on the field yet
		private async Task GenerateAsync()
		{
			if (PartyLevels.Count == 0 || generating)
			{
				return;
			}
			generating = true;
			genNote = null;
			genFailed = false;
			StateHasChanged();
			try
			{
				await EnsureMonstersAsync();
				var picked = Pick();
				if (picked.Count == 0)
				{
					genFailed = true;
					genNote = (monsters?.Count ?? 0) == 0 ? UiText.EncounterGenNoList(Lang) : UiText.EncounterGenNone(Lang);
					return;
				}
				Apply(picked);
				saved = false;
				message = null;
				await SaveAsync();
				if (!saved || message is not null)
				{
					//	Someone saved meanwhile: the monsters go on the encounter as it is now
					await LoadAsync();
					Apply(picked);
					message = null;
					await SaveAsync();
				}
				genFailed = message is not null;
				genNote = genFailed ? message : UiText.EncounterGenDone(string.Join(", ", picked.GroupBy(m => m.Id).Select(g => $"{g.Count()} × {g.First().Name}")),
					UiText.EncounterRating(Budget.Ruleset, Budget.Rating, Lang), Lang);
			}
			catch (Exception)
			{
				genFailed = true;
				genNote = UiText.EncounterGenError(Lang);
			}
			finally
			{
				generating = false;
				StateHasChanged();
			}
		}

		private List<MonsterResponseDto> Pick()
		{
			var thresholds = EncounterMath.Thresholds(difficultyRuleset, PartyLevels);
			if (thresholds.Length == 0)
			{
				return new();
			}
			var level = Math.Clamp(genLevel, 1, thresholds.Length);
			var target = thresholds[level - 1];
			var ceiling = level < thresholds.Length ? thresholds[level] - 1 : (int)(target * 1.5);
			var all = (monsters ?? new()).Where(m => !m.IsNpc && m.Xp > 0 && (genType is null || m.Type == genType)).ToList();

			//	The monsters of the campaign's edition first, the others when it has none of that kind
			var pool = all.Where(m => Campaign.Ruleset is null || m.Ruleset == Campaign.Ruleset).ToList();
			if (pool.Count == 0)
			{
				pool = all;
			}
			var picked = new List<MonsterResponseDto>();
			int Adjusted(IEnumerable<MonsterResponseDto> list) => EncounterMath.Evaluate(difficultyRuleset, PartyLevels, list.Select(m => m.Xp).ToList()).AdjustedXp;
			var leaders = pool.Where(m => Adjusted(new[] { m }) <= ceiling && m.Xp >= target * 0.3).ToList();
			if (leaders.Count == 0)
			{
				leaders = pool.Where(m => Adjusted(new[] { m }) <= ceiling).ToList();
			}
			if (leaders.Count == 0)
			{
				return picked;
			}
			var leader = leaders.OrderBy(_ => Random.Shared.Next()).First();
			picked.Add(leader);
			var minions = pool.Where(m => m.Xp <= Math.Max(25, leader.Xp / 2) && m.Id != leader.Id).OrderBy(_ => Random.Shared.Next()).Take(2).ToList();
			if (minions.Count == 0)
			{
				minions.Add(leader);
			}
			for (var i = 0; picked.Count < 8 && i < 16 && Adjusted(picked) < target; i++)
			{
				var next = minions[i % minions.Count];
				if (Adjusted(picked.Append(next)) > ceiling)
				{
					break;
				}
				picked.Add(next);
			}
			return picked;
		}

		//	The monsters there before go; the party stays (and joins when missing)
		private void Apply(List<MonsterResponseDto> picked)
		{
			draft.Combatants.RemoveAll(c => c.Kind == CombatantKind.Monster);
			foreach (var entry in Campaign.Characters.Where(e => draft.PartyIds.Contains(e.Character.Id) && draft.Combatants.All(c => c.CharacterId != e.Character.Id)))
			{
				draft.Combatants.Add(CharacterCombatant(entry));
			}
			foreach (var group in picked.GroupBy(m => m.Id))
			{
				var m = group.First();
				var count = group.Count();
				for (var n = 1; n <= count; n++)
				{
					var hp = rollHp ? Roll(m.HitDice) ?? m.HitPoints : m.HitPoints;
					draft.Combatants.Add(new EncounterCombatant
					{
						Kind = CombatantKind.Monster,
						MonsterId = m.Id,
						Name = count > 1 ? $"{m.Name} {n}" : m.Name,
						InitiativeBonus = MonsterMath.Modifier(m.Dexterity),
						ArmorClass = m.ArmorClass,
						MaxHp = Math.Max(1, hp),
						Hp = Math.Max(1, hp),
						Xp = m.Xp,
						ChallengeRating = m.ChallengeRating
					});
				}
			}
			if (map is not null)
			{
				Spread();
			}
		}

		// ===== Pictures =====

		//	The account's picture of each monster (chosen in the bestiary)
		private Dictionary<Guid, Guid> pictures = new();

		private async Task LoadPicturesAsync()
		{
			try
			{
				pictures = await Images.GetChoicesAsync();
				if (draft.Combatants.Any(c => c.MonsterId is not null))
				{
					await EnsureMonstersAsync();
				}
			}
			catch (Exception)
			{
				//	Without pictures the initials stay
			}
		}

		//	The portrait of a character, the picture chosen for a monster or the portrait of an NPC; null: the initials
		private string? AvatarOf(EncounterCombatant c)
		{
			if (c.CharacterId is { } characterId)
			{
				return Campaign.Characters.FirstOrDefault(e => e.Character.Id == characterId)?.Character.Portrait;
			}
			if (c.MonsterId is { } monsterId)
			{
				return pictures.TryGetValue(monsterId, out var imageId) ? Images.FileUrl(imageId) : monsters?.FirstOrDefault(m => m.Id == monsterId)?.Portrait;
			}
			return null;
		}

		private async Task ClearMonstersAsync()
		{
			draft.Combatants.RemoveAll(c => c.Kind == CombatantKind.Monster);
			await SaveAsync();
		}

		// ===== One more of the same =====

		//	The kinds of monster already on the field, for one click more
		private List<MonsterResponseDto> QuickMonsters => monsters is null
			? new()
			: draft.Combatants.Where(c => c.MonsterId is not null).Select(c => c.MonsterId!.Value).Distinct()
				.Select(id => monsters.FirstOrDefault(m => m.Id == id)).OfType<MonsterResponseDto>().Take(6).ToList();

		private async Task AddOneMoreAsync(MonsterResponseDto m)
		{
			addCounts[m.Id] = 1;
			await AddMonsterAsync(m);
		}

		//	"Goblin 2" → "G2", "Eroe di prova" → "EP"
		private static string Code(string name)
		{
			var words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (words.Length == 0)
			{
				return "?";
			}
			var number = words[^1].All(char.IsDigit) ? words[^1] : null;
			var letters = words.Where(w => !w.All(char.IsDigit)).ToList();
			var head = letters.Count switch
			{
				0 => string.Empty,
				1 => letters[0][..Math.Min(number is null ? 2 : 1, letters[0].Length)],
				_ => $"{letters[0][0]}{(number is null ? letters[^1][0].ToString() : string.Empty)}"
			};
			return (head + number).ToUpperInvariant();
		}

		// ===== The starting cells =====

		private List<CampaignMapSummaryDto>? maps;
		private CampaignMapDto? map;
		private Guid? placing;

		private async Task LoadMapsAsync()
		{
			maps = await Campaigns.GetMapsAsync(CampaignId) ?? new();
			if (draft.MapId is { } id && maps.Any(m => m.Id == id))
			{
				map = await Campaigns.GetMapAsync(CampaignId, id);
			}
			await InvokeAsync(StateHasChanged);
		}

		private List<RfSelect<Guid?>.OptionItem> MapOptions => new List<RfSelect<Guid?>.OptionItem> { new(null, UiText.EncounterNoMap(Lang)) }
			.Concat((maps ?? new()).Select(m => new RfSelect<Guid?>.OptionItem(m.Id, m.Name)))
			.ToList();

		private async Task SetMapAsync(Guid? id)
		{
			draft.MapId = id;
			map = id is { } mapId ? await Campaigns.GetMapAsync(CampaignId, mapId) : null;
			placing ??= draft.Combatants.FirstOrDefault()?.Id;
			await SaveAsync();
		}

		//	The cells of the map (at most 2500, the rest is not offered)
		private IEnumerable<(int Col, int Row)> Cells
		{
			get
			{
				if (map is null)
				{
					yield break;
				}
				var count = 0;
				for (var row = 0; row < 200; row++)
				{
					var any = false;
					for (var col = 0; col < 200; col++)
					{
						if (!MapGeometry.Inside(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, col, row, 1, map.Width, map.Height))
						{
							if (col > 0)
							{
								break;
							}
							continue;
						}
						any = true;
						if (++count > 2500)
						{
							yield break;
						}
						yield return (col, row);
					}
					if (!any && row > 0)
					{
						yield break;
					}
				}
			}
		}

		private string Points(int col, int row) => map is null ? string.Empty
			: string.Join(' ', MapAreas.Corners(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, col, row).Select(p => $"{N(p.X)},{N(p.Y)}"));

		//	"C4": the column as a letter (AA after Z), the row from 1
		private static string CellName(int col, int row)
		{
			var letters = string.Empty;
			var n = col + 1;
			while (n > 0)
			{
				var r = (n - 1) % 26;
				letters = (char)('A' + r) + letters;
				n = (n - 1) / 26;
			}
			return $"{letters}{row + 1}";
		}

		private async Task PlaceAtAsync(int col, int row)
		{
			if (placing is not { } id || draft.Combatants.FirstOrDefault(c => c.Id == id) is not { } who)
			{
				return;
			}
			//	Someone already there swaps cells with it
			if (draft.Combatants.FirstOrDefault(c => c.Id != id && c.X == col && c.Y == row) is { } other)
			{
				(other.X, other.Y) = (who.X, who.Y);
			}
			(who.X, who.Y) = (col, row);
			//	The next one without a cell is chosen
			placing = draft.Combatants.FirstOrDefault(c => c.X is null)?.Id ?? id;
			await SaveAsync();
		}

		//	The characters on the left of the map, the others on the right, a cell apart
		private void Spread()
		{
			if (map is null)
			{
				return;
			}
			var cells = Cells.ToList();
			if (cells.Count == 0)
			{
				return;
			}
			var columns = cells.Max(c => c.Col) + 1;
			var rows = cells.Max(c => c.Row) + 1;
			void Line(IEnumerable<EncounterCombatant> who, int startCol, int step)
			{
				var list = who.ToList();
				var row = Math.Max(0, rows / 2 - list.Count);
				var col = startCol;
				foreach (var c in list)
				{
					if (row >= rows)
					{
						row = 0;
						col += step;
					}
					(c.X, c.Y) = (Math.Clamp(col, 0, columns - 1), Math.Clamp(row, 0, rows - 1));
					row += 2;
				}
			}
			Line(draft.Combatants.Where(c => c.Kind == CombatantKind.Character), Math.Min(1, columns - 1), 1);
			Line(draft.Combatants.Where(c => c.Kind != CombatantKind.Character), Math.Max(0, columns - 2), -1);
		}

		private async Task SpreadAsync()
		{
			Spread();
			await SaveAsync();
		}
	}
}
