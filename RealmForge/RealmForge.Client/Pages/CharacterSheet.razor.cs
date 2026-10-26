using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Pages
{
	public enum SheetTab
	{
		Overview = 1,
		Spells = 2,
		Inventory = 3,
		Features = 4,
		Notes = 5
	}

	public enum RollMode
	{
		Normal = 1,
		Advantage = 2,
		Disadvantage = 3
	}

	///	<summary>
	///	Character sheet: computed with <see cref="CharacterCalculator"/> from the saved choices, in the reader's language.
	///	The play state (hit points, rests, slots, conditions, inventory, coins, notes) changes in place and is saved
	///	automatically; the rules choices change through the wizard (edit, level up). The sheet downloads as a PDF.
	///	</summary>
	public partial class CharacterSheet : IDisposable
	{
		[Parameter] public Guid Id { get; set; }

		[Inject] private CharacterDataService Characters { get; set; } = default!;
		[Inject] private LanguageStateService LanguageState { get; set; } = default!;
		[Inject] private GlossaryService Glossary { get; set; } = default!;
		[Inject] private ClassDataService ClassService { get; set; } = default!;
		[Inject] private SpeciesDataService SpeciesService { get; set; } = default!;
		[Inject] private BackgroundDataService BackgroundService { get; set; } = default!;
		[Inject] private NavigationManager Navigation { get; set; } = default!;
		[Inject] private IJSRuntime JS { get; set; } = default!;

		private LanguageCode Lang => LanguageState.CurrentLanguage;

		private CharacterDto? character;
		private CharacterContextDto? context;
		private ComputedCharacter? computed;
		private List<RuleEntryResponseDto> conditions = new();
		private readonly Dictionary<Guid, ClassDetailResponseDto> classDetails = new();
		private SpeciesDetailResponseDto? speciesDetail;
		private BackgroundDetailResponseDto? backgroundDetail;

		private bool loading = true;
		private bool deleteOpen;
		private bool shortRestOpen;
		private bool longRestOpen;
		private SheetTab tab = SheetTab.Overview;
		private RollMode rollMode = RollMode.Normal;
		private string? lastRoll;
		private int amount = 1;
		private string itemSearch = string.Empty;
		private string newResource = string.Empty;
		private bool newResourceShort;
		private int newResourceMax = 1;

		// Autosave
		private enum SaveStatus { Idle, Pending, Saving, Saved, Failed }
		private SaveStatus saveStatus = SaveStatus.Idle;
		private CancellationTokenSource? saveDelay;

		private CharacterSheetState Sheet => character!.Sheet;
		private RulesetVersion Ruleset => character?.Ruleset ?? RulesetVersion.Dnd5e_2024;

		protected override async Task OnInitializedAsync()
		{
			LanguageState.OnLanguageChanged += OnLanguageChanged;
			await LoadAsync();
		}

		protected override async Task OnParametersSetAsync()
		{
			if (character is not null && character.Id != Id)
			{
				await LoadAsync();
			}
		}

		private void OnLanguageChanged() => _ = InvokeAsync(async () =>
		{
			if (character is not null)
			{
				await LoadContextAsync();
				StateHasChanged();
			}
		});

		public void Dispose()
		{
			LanguageState.OnLanguageChanged -= OnLanguageChanged;
			saveDelay?.Cancel();
		}

		private async Task LoadAsync()
		{
			loading = true;
			character = await Characters.GetCharacterAsync(Id);
			if (character is not null)
			{
				await LoadContextAsync();
			}
			loading = false;
		}

		private async Task LoadContextAsync()
		{
			var lang = Lang;
			await Glossary.EnsureLoadedAsync(lang);
			context = await Characters.GetContextAsync(character!.Ruleset, lang);
			var entries = await Glossary.GetEntriesAsync(lang);
			conditions = entries
				.Where(e => e.Ruleset == character.Ruleset && e.Category == RuleCategory.Condition && e.Key != "exhaustion")
				.OrderBy(e => e.Name)
				.ToList();
			ruleEntries = entries.Where(e => e.Ruleset == character.Ruleset).ToList();
			Recompute();
			_ = LoadCastingTimesAsync(lang);

			classDetails.Clear();
			var loads = character.Build.Classes.Select(c => c.ClassId).Distinct().Select(async id =>
			{
				if (await ClassService.GetClassDetailAsync(id, lang) is { } detail)
				{
					classDetails[id] = detail;
				}
			}).ToList();
			var species = SpeciesService.GetSpeciesDetailAsync(character.SpeciesId, lang);
			var background = BackgroundService.GetBackgroundAsync(character.BackgroundId, lang);
			await Task.WhenAll(loads.Append(species).Append(background));
			speciesDetail = await species;
			backgroundDetail = await background;
			TrackLevelUps();
		}

		private void Recompute()
		{
			if (character is null || context is null)
			{
				return;
			}

			computed = CharacterCalculator.Compute(new CharacterInput
			{
				Name = character.Name,
				Ruleset = character.Ruleset,
				SpeciesId = character.SpeciesId,
				SubspeciesId = character.SubspeciesId,
				BackgroundId = character.BackgroundId,
				Build = character.Build,
				Sheet = character.Sheet
			}, context);
		}

		// ===== Changes of the play state =====

		///	<summary>
		///	Recomputes after a change and saves it a moment later (several quick changes make one save).
		///	</summary>
		private void Changed()
		{
			Recompute();
			saveStatus = SaveStatus.Pending;
			saveDelay?.Cancel();
			var delay = saveDelay = new CancellationTokenSource();
			_ = SaveLaterAsync(delay.Token);
		}

		private async Task SaveLaterAsync(CancellationToken token)
		{
			try
			{
				await Task.Delay(700, token);
			}
			catch (TaskCanceledException)
			{
				return;
			}

			await SaveNowAsync();
		}

		private async Task SaveNowAsync()
		{
			if (character is null)
			{
				return;
			}

			saveStatus = SaveStatus.Saving;
			await InvokeAsync(StateHasChanged);
			var saved = await Characters.SaveSheetAsync(character.Id, character.Sheet);
			saveStatus = saved is null ? SaveStatus.Failed : SaveStatus.Saved;
			await InvokeAsync(StateHasChanged);
		}

		private int MaxHp => computed?.MaxHitPoints ?? character?.MaxHitPoints ?? 1;
		private int CurrentHp => Math.Clamp(Sheet.CurrentHitPoints ?? MaxHp, 0, MaxHp);

		//	Damage: temporary hit points first; at 0 hit points a hit is a failed death save (two on a critical hit) and
		//	damage of at least the maximum is instant death, as is the damage left over when a hit drops the character to 0
		private void Damage()
		{
			var value = Math.Max(0, amount);
			if (value == 0)
			{
				return;
			}
			var wasDown = CurrentHp == 0;
			var fromTemp = Math.Min(Sheet.TemporaryHitPoints, value);
			Sheet.TemporaryHitPoints -= fromTemp;
			var rest = value - fromTemp;
			deathNote = null;

			if (wasDown)
			{
				if (rest >= MaxHp)
				{
					Sheet.DeathSaveFailures = 3;
					deathNote = UiText.InstantDeath(Lang);
				}
				else if (rest > 0)
				{
					//	A stable character is no longer stable
					if (Stable)
					{
						Sheet.DeathSaveSuccesses = 0;
					}
					Sheet.DeathSaveFailures = Math.Min(3, Sheet.DeathSaveFailures + (criticalHit ? 2 : 1));
					deathNote = UiText.DamageAtZero(criticalHit, Lang);
				}
			}
			else
			{
				var left = CurrentHp - rest;
				Sheet.CurrentHitPoints = Math.Max(0, left);
				if (left <= 0)
				{
					//	Falling unconscious ends concentration
					Sheet.Concentration = null;
					concentrationDc = null;
					Sheet.DeathSaveSuccesses = 0;
					Sheet.DeathSaveFailures = 0;
					if (-left >= MaxHp)
					{
						Sheet.DeathSaveFailures = 3;
						deathNote = UiText.InstantDeath(Lang);
					}
				}
				else if (Sheet.Concentration is not null)
				{
					//	Constitution save to keep concentrating: half the damage, at least 10 (2024: at most 30)
					var dc = Math.Max(10, value / 2);
					concentrationDc = Ruleset == RulesetVersion.Dnd5e_2024 ? Math.Min(30, dc) : dc;
				}
			}
			criticalHit = false;
			Changed();
		}

		private void Heal()
		{
			var wasDown = CurrentHp == 0;
			Sheet.CurrentHitPoints = Math.Min(MaxHp, CurrentHp + Math.Max(0, amount));
			if (wasDown && Sheet.CurrentHitPoints > 0)
			{
				Sheet.DeathSaveSuccesses = 0;
				Sheet.DeathSaveFailures = 0;
			}
			Changed();
		}

		private void SetTemp()
		{
			//	Temporary hit points do not stack: the higher value stays
			Sheet.TemporaryHitPoints = Math.Max(Sheet.TemporaryHitPoints, Math.Max(0, amount));
			Changed();
		}

		private void SetDeathSaves(bool success, int value)
		{
			if (success)
			{
				Sheet.DeathSaveSuccesses = Sheet.DeathSaveSuccesses == value ? value - 1 : value;
			}
			else
			{
				Sheet.DeathSaveFailures = Sheet.DeathSaveFailures == value ? value - 1 : value;
			}
			Changed();
		}

		private void ToggleCondition(string key)
		{
			if (!Sheet.Conditions.Remove(key))
			{
				Sheet.Conditions.Add(key);
			}
			Changed();
		}

		private const int ExhaustionMax = 6;

		private void SetExhaustion(int value)
		{
			Sheet.Exhaustion = Math.Clamp(Sheet.Exhaustion == value ? value - 1 : value, 0, ExhaustionMax);
			Changed();
		}

		private void ToggleInspiration()
		{
			Sheet.Inspiration = !Sheet.Inspiration;
			Changed();
		}

		private int SpentSlots(int level) => level - 1 < Sheet.SpentSlots.Count ? Sheet.SpentSlots[level - 1] : 0;

		private void ToggleSlot(int level, int index)
		{
			while (Sheet.SpentSlots.Count < level)
			{
				Sheet.SpentSlots.Add(0);
			}
			var spent = Sheet.SpentSlots[level - 1];
			Sheet.SpentSlots[level - 1] = index < spent ? index : index + 1;
			Changed();
		}

		private void TogglePactSlot(int index)
		{
			Sheet.SpentPactSlots = index < Sheet.SpentPactSlots ? index : index + 1;
			Changed();
		}

		private int HitDiceSpent(int die) => Sheet.HitDiceSpent.GetValueOrDefault(die);

		//	Short rest: a hit die spent heals die + Constitution modifier (at least 0)
		private void SpendHitDie(int die, int available)
		{
			if (HitDiceSpent(die) >= available || computed is null)
			{
				return;
			}

			var roll = Random.Shared.Next(1, die + 1);
			var healed = Math.Max(0, roll + computed.Modifier(AbilityScore.Constitution));
			Sheet.HitDiceSpent[die] = HitDiceSpent(die) + 1;
			Sheet.CurrentHitPoints = Math.Min(MaxHp, CurrentHp + healed);
			lastRoll = $"d{die}: {roll} {CharacterMath.FormatModifier(computed.Modifier(AbilityScore.Constitution))} = +{healed} {UiText.SheetHitPointsShort(Lang)}";
			_ = diceTray?.ShowAsync(new DiceRollResult(UiText.BtnSpendHitDie(die, Lang), new List<DieFace> { new(die, roll) }, computed.Modifier(AbilityScore.Constitution), healed));
			Changed();
		}

		private void FinishShortRest()
		{
			Sheet.SpentPactSlots = 0;
			RechargeItems(longRest: false);
			foreach (var resource in ClassResources)
			{
				Sheet.ResourceUses[resource.Key] = CharacterResources.SpentAfterRest(resource, ResourceSpent(resource), longRest: false);
			}
			foreach (var resource in Sheet.Resources.Where(r => r.ShortRest))
			{
				resource.Used = 0;
			}
			shortRestOpen = false;
			Changed();
		}

		//	Long rest: all hit points and slots; hit dice: half the total (2014) or all (2024); exhaustion -1
		private void LongRest()
		{
			Sheet.CurrentHitPoints = null;
			Sheet.TemporaryHitPoints = 0;
			Sheet.DeathSaveSuccesses = 0;
			Sheet.DeathSaveFailures = 0;
			Sheet.SpentSlots.Clear();
			Sheet.SpentPactSlots = 0;
			Sheet.ResourceUses.Clear();
			RechargeItems(longRest: true);
			GrantLongRestChanges();
			foreach (var resource in Sheet.Resources)
			{
				resource.Used = 0;
			}

			if (Ruleset == RulesetVersion.Dnd5e_2024)
			{
				Sheet.HitDiceSpent.Clear();
			}
			else if (computed is not null)
			{
				var recover = Math.Max(1, computed.Level / 2);
				foreach (var (die, _) in computed.HitDice)
				{
					var back = Math.Min(recover, HitDiceSpent(die));
					Sheet.HitDiceSpent[die] = HitDiceSpent(die) - back;
					recover -= back;
				}
			}
			Sheet.Exhaustion = Math.Max(0, Sheet.Exhaustion - 1);
			longRestOpen = false;
			Changed();
		}

		// ===== Dice =====

		private void Roll(string label, int modifier)
		{
			var (die, dice) = RollD20();
			var note = die == 20 ? UiText.RollCritical(Lang) : die == 1 ? UiText.RollFumble(Lang) : null;
			ShowRoll(new DiceRollResult(label, dice, modifier, die + modifier, note));
		}

		//	A d20 with the roll mode: two dice for advantage or disadvantage, the other one dropped
		private (int Die, List<DieFace> Dice) RollD20()
		{
			var first = Random.Shared.Next(1, 21);
			if (rollMode == RollMode.Normal)
			{
				return (first, new List<DieFace> { new(20, first) });
			}
			var second = Random.Shared.Next(1, 21);
			var keepFirst = rollMode == RollMode.Advantage ? first >= second : first <= second;
			return (keepFirst ? first : second, new List<DieFace> { new(20, first, !keepFirst), new(20, second, keepFirst) });
		}

		private void RollDamage(string label, string dice)
		{
			//	"1d8+3", "2d6", "1d10−1"
			var match = System.Text.RegularExpressions.Regex.Match(dice.Replace('−', '-'), @"^(\d+)d(\d+)\s*([+-]\s*\d+)?");
			if (!match.Success)
			{
				//	Flat damage (an Unarmed Strike: 1 + Strength)
				if (int.TryParse(dice.Replace('−', '-'), out var flat))
				{
					ShowRoll(new DiceRollResult(label, new List<DieFace>(), 0, Math.Max(0, flat)));
				}
				return;
			}

			var count = int.Parse(match.Groups[1].Value);
			var size = int.Parse(match.Groups[2].Value);
			var bonus = match.Groups[3].Success ? int.Parse(match.Groups[3].Value.Replace(" ", string.Empty)) : 0;
			var rolls = Enumerable.Range(0, Math.Min(count, 20)).Select(_ => Random.Shared.Next(1, size + 1)).ToList();
			ShowRoll(new DiceRollResult($"{label} · {dice}", rolls.Select(r => new DieFace(size, r)).ToList(), bonus, Math.Max(0, rolls.Sum() + bonus)));
		}

		// ===== Inventory =====

		private IEnumerable<ContextItem> SearchResults => string.IsNullOrWhiteSpace(itemSearch) || context is null
			? Enumerable.Empty<ContextItem>()
			: context.Items.Where(i => i.Name.Contains(itemSearch.Trim(), StringComparison.OrdinalIgnoreCase)).Take(8);

		private void AddItem(ContextItem item)
		{
			var existing = Sheet.Inventory.FirstOrDefault(i => i.EquipmentId == item.Id);
			if (existing is not null)
			{
				existing.Quantity++;
			}
			else
			{
				Sheet.Inventory.Add(new InventoryItem { EquipmentId = item.Id, Quantity = 1 });
			}
			itemSearch = string.Empty;
			Changed();
		}

		private void AddFreeItem()
		{
			var name = itemSearch.Trim();
			if (name.Length == 0)
			{
				return;
			}
			Sheet.Inventory.Add(new InventoryItem { Name = name.Length > 150 ? name[..150] : name, Quantity = 1 });
			itemSearch = string.Empty;
			Changed();
		}

		private void RemoveItem(InventoryItem item)
		{
			Sheet.Inventory.Remove(item);
			Changed();
		}

		private void SetQuantity(InventoryItem item, string? value)
		{
			if (int.TryParse(value, out var quantity))
			{
				item.Quantity = Math.Clamp(quantity, 0, 99999);
				Changed();
			}
		}

		//	One body armor and one shield at a time
		private void ToggleEquipped(InventoryItem item)
		{
			item.Equipped = !item.Equipped;
			if (item.Equipped && ItemOf(item)?.ArmorCategory is { } category)
			{
				var shield = category == ArmorCategory.Shield;
				foreach (var other in Sheet.Inventory.Where(i => i != item && i.Equipped))
				{
					if (ItemOf(other)?.ArmorCategory is { } otherCategory && (otherCategory == ArmorCategory.Shield) == shield)
					{
						other.Equipped = false;
					}
				}
			}
			Changed();
		}

		//	At most three attuned items (both editions)
		private void ToggleAttuned(InventoryItem item)
		{
			attuneError = null;
			if (!item.Attuned && MagicItemRules.AttunedCount(Sheet) >= MagicItemRules.MaxAttuned)
			{
				attuneError = UiText.AttunementLimit(MagicItemRules.MaxAttuned, Lang);
				return;
			}
			item.Attuned = !item.Attuned;
			Changed();
		}

		private ContextItem? ItemOf(InventoryItem item) =>
			item.EquipmentId is { } id ? context?.Items.FirstOrDefault(i => i.Id == id) : null;

		private string ItemName(InventoryItem item) => ItemOf(item)?.Name ?? item.Name ?? string.Empty;

		private decimal CarriedWeight => Sheet.Inventory.Sum(i => (ItemOf(i)?.WeightInPounds ?? 0) * i.Quantity)
			+ (Sheet.Coins.Cp + Sheet.Coins.Sp + Sheet.Coins.Ep + Sheet.Coins.Gp + Sheet.Coins.Pp) / 50m;

		//	Strength × 15 lb., doubled for Large creatures and halved for Tiny ones
		private decimal CarryingCapacity => (computed?.Score(AbilityScore.Strength) ?? 10) * 15m * (character?.Build.Size switch
		{
			CreatureSize.Tiny => 0.5m,
			CreatureSize.Large or CreatureSize.Huge or CreatureSize.Gargantuan => 2m,
			_ => 1m
		});

		private void SetCoin(CoinType type, string? value)
		{
			if (!int.TryParse(value, out var coins))
			{
				return;
			}
			coins = Math.Clamp(coins, 0, 9_999_999);
			switch (type)
			{
				case CoinType.Cp: Sheet.Coins.Cp = coins; break;
				case CoinType.Sp: Sheet.Coins.Sp = coins; break;
				case CoinType.Ep: Sheet.Coins.Ep = coins; break;
				case CoinType.Gp: Sheet.Coins.Gp = coins; break;
				default: Sheet.Coins.Pp = coins; break;
			}
			Changed();
		}

		private int Coin(CoinType type) => type switch
		{
			CoinType.Cp => Sheet.Coins.Cp,
			CoinType.Sp => Sheet.Coins.Sp,
			CoinType.Ep => Sheet.Coins.Ep,
			CoinType.Gp => Sheet.Coins.Gp,
			_ => Sheet.Coins.Pp
		};

		// ===== Resources and notes =====

		private void AddResource()
		{
			if (string.IsNullOrWhiteSpace(newResource))
			{
				return;
			}
			Sheet.Resources.Add(new ResourceCounter { Name = newResource.Trim(), Maximum = Math.Clamp(newResourceMax, 1, 99), ShortRest = newResourceShort });
			newResource = string.Empty;
			newResourceMax = 1;
			newResourceShort = false;
			Changed();
		}

		private void UseResource(ResourceCounter resource, int index)
		{
			resource.Used = index < resource.Used ? index : index + 1;
			Changed();
		}

		private void RemoveResource(ResourceCounter resource)
		{
			Sheet.Resources.Remove(resource);
			Changed();
		}

		private void SetText(Action<string?> set, ChangeEventArgs e)
		{
			set(e.Value?.ToString());
			Changed();
		}

		private void SetNumber(Action<int> set, ChangeEventArgs e)
		{
			if (int.TryParse(e.Value?.ToString(), out var value))
			{
				set(value);
				Changed();
			}
		}

		private void ToggleExtra<T>(List<T> list, T value)
		{
			if (!list.Remove(value))
			{
				list.Add(value);
			}
			Changed();
		}

		// ===== Actions =====

		private async Task DeleteAsync()
		{
			if (await Characters.DeleteCharacterAsync(Id))
			{
				Navigation.NavigateTo("characters");
			}
			deleteOpen = false;
		}

		private async Task DownloadPdfAsync()
		{
			if (character is null || computed is null || context is null)
			{
				return;
			}

			var data = CharacterPdfBuilder.Build(character, computed, context, conditions, classDetails, Lang);
			var bytes = Shared.Pdf.CharacterPdf.Create(data);
			var file = string.Concat(character.Name.Select(ch => char.IsLetterOrDigit(ch) ? ch : '_')).Trim('_');
			await JS.InvokeVoidAsync("rfDownloadFile", $"{(file.Length == 0 ? "character" : file)}.pdf", "application/pdf", Convert.ToBase64String(bytes));
		}

		private string SaveText => saveStatus switch
		{
			SaveStatus.Pending or SaveStatus.Saving => UiText.SheetSaving(Lang),
			SaveStatus.Saved => UiText.SheetSaved(Lang),
			SaveStatus.Failed => UiText.SheetSaveFailed(Lang),
			_ => string.Empty
		};

		private string ClassLine => computed is null ? string.Empty : string.Join(" / ", computed.Classes.Select(c =>
			c.Subclass is null ? $"{c.Class.Name} {c.Level}" : $"{c.Class.Name} {c.Level} ({c.Subclass.Name})"));
	}
}
