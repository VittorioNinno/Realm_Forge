using Microsoft.AspNetCore.Components;
using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;
using RealmForge.Shared.Rules;
using RealmForge.Shared.Text;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Character creation wizard, ported from the Obsidian "Hero Generator": identity, origins, class, ability scores,
	///	increases, equipment, spells and summary. Every choice is checked again by the API when the character is saved.
	///	</summary>
	public partial class CharacterCreate : IDisposable
	{
		public const int StepCount = 8;

		[Inject] private LanguageStateService LanguageState { get; set; } = default!;
		[Inject] private SpeciesDataService SpeciesService { get; set; } = default!;
		[Inject] private BackgroundDataService BackgroundService { get; set; } = default!;
		[Inject] private ClassDataService ClassService { get; set; } = default!;
		[Inject] private SpellDataService SpellService { get; set; } = default!;
		[Inject] private EquipmentDataService EquipmentService { get; set; } = default!;
		[Inject] private CharacterDataService CharacterService { get; set; } = default!;
		[Inject] private GlossaryService Glossary { get; set; } = default!;
		[Inject] private NavigationManager Navigation { get; set; } = default!;

		private LanguageCode Lang => LanguageState.CurrentLanguage;

		private int step = 1;
		private int furthestStep = 1;
		private bool loading = true;
		private bool saving;
		private string? stepError;
		private string? saveError;

		//	Compendium of the edition
		private List<SpeciesResponseDto> speciesList = new();
		private List<BackgroundResponseDto> backgroundList = new();
		private List<ClassResponseDto> classList = new();
		private List<SpellResponseDto> spellList = new();
		private Dictionary<Guid, EquipmentResponseDto> equipment = new();

		private SpeciesDetailResponseDto? species;
		private BackgroundDetailResponseDto? background;
		private ClassDetailResponseDto? cls;

		//	1. Identity
		private RulesetVersion ruleset = RulesetVersion.Dnd5e_2024;
		private string name = string.Empty;
		private int level = 1;
		private Alignment alignment = Alignment.Neutral;

		//	2. Origins
		private Guid speciesId;
		private Guid? subspeciesId;
		private CreatureSize size = CreatureSize.Medium;
		private Guid backgroundId;
		private string languageOne = string.Empty;
		private string languageTwo = string.Empty;

		//	3. Class
		private Guid classId;
		private Guid? subclassId;
		private readonly List<Skill> classSkills = new();

		//	4. Ability scores
		private AbilityMethod method = AbilityMethod.StandardArray;
		private readonly int?[] assigned = new int?[6];
		private readonly int[] pointBuy = { 8, 8, 8, 8, 8, 8 };
		private List<int> pool = CharacterMath.StandardArray.ToList();
		private int? selectedPool;
		private List<int> rolledResults = new();
		private readonly int?[] rolledAssigned = new int?[6];
		private int rollsLeft = 3;
		private bool rolling;
		private bool rerollConfirmOpen;
		private List<DiceRow> diceRows = new();

		//	5. Increases
		private AbilityBonusMode bonusMode = AbilityBonusMode.TwoAndOne;
		private readonly AbilityScore[] picks = { AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Constitution };

		//	6. Equipment
		private string? backgroundChoice;
		private List<string> classChoice = new();

		//	7. Spells
		private readonly HashSet<Guid> spellIds = new();
		private string spellSearch = string.Empty;

		private sealed class DiceRow
		{
			public int[] Dice { get; } = new int[4];
			public int Dropped { get; set; } = -1;
			public int Total => Dropped < 0 ? 0 : Dice.Where((_, i) => i != Dropped).Sum();
		}

		protected override async Task OnInitializedAsync()
		{
			LanguageState.OnLanguageChanged += OnLanguageChanged;
			await LoadEditionAsync(keepChoices: false);
		}

		//	Same choices, names in the new language
		private void OnLanguageChanged() => _ = InvokeAsync(async () =>
		{
			await LoadEditionAsync(keepChoices: true);
			StateHasChanged();
		});

		public void Dispose() => LanguageState.OnLanguageChanged -= OnLanguageChanged;

		// ===== Loading =====

		private async Task LoadEditionAsync(bool keepChoices)
		{
			loading = true;
			var lang = Lang;
			var speciesLoad = SpeciesService.GetSpeciesAsync(lang, ruleset);
			var backgroundsLoad = BackgroundService.GetBackgroundsAsync(lang, ruleset);
			var classesLoad = ClassService.GetClassesAsync(lang, ruleset);
			var spellsLoad = SpellService.GetSpellsAsync(lang, ruleset);
			var equipmentLoad = EquipmentService.GetEquipmentAsync(lang, ruleset);
			await Task.WhenAll(speciesLoad, backgroundsLoad, classesLoad, spellsLoad, equipmentLoad, Glossary.EnsureLoadedAsync(lang));

			speciesList = (await speciesLoad).Where(s => s.Ruleset == ruleset).OrderBy(s => s.Name).ToList();
			backgroundList = (await backgroundsLoad).Where(b => b.Ruleset == ruleset).OrderBy(b => b.Name).ToList();
			classList = (await classesLoad).Where(c => c.Ruleset == ruleset).OrderBy(c => c.Name).ToList();
			spellList = (await spellsLoad).Where(s => s.Ruleset == ruleset).OrderBy(s => s.Level).ThenBy(s => s.Name).ToList();
			equipment = (await equipmentLoad).Where(e => e.Ruleset == ruleset).GroupBy(e => e.Id).ToDictionary(g => g.Key, g => g.First());

			if (!keepChoices || speciesList.All(s => s.Id != speciesId))
			{
				speciesId = speciesList.FirstOrDefault()?.Id ?? Guid.Empty;
				subspeciesId = null;
			}
			if (!keepChoices || backgroundList.All(b => b.Id != backgroundId))
			{
				backgroundId = backgroundList.FirstOrDefault()?.Id ?? Guid.Empty;
			}
			if (!keepChoices || classList.All(c => c.Id != classId))
			{
				classId = classList.FirstOrDefault()?.Id ?? Guid.Empty;
			}

			await Task.WhenAll(LoadSpeciesAsync(keepChoices), LoadBackgroundAsync(keepChoices), LoadClassAsync(keepChoices));

			var languages = UiText.StandardLanguages(ruleset, lang);
			if (!keepChoices || !languages.Contains(languageOne) || !languages.Contains(languageTwo) || languageOne == languageTwo)
			{
				languageOne = languages.ElementAtOrDefault(0) ?? string.Empty;
				languageTwo = languages.ElementAtOrDefault(1) ?? string.Empty;
			}

			loading = false;
		}

		private async Task LoadSpeciesAsync(bool keepChoices)
		{
			species = speciesId == Guid.Empty ? null : await SpeciesService.GetSpeciesDetailAsync(speciesId, Lang);
			if (species is null)
			{
				subspeciesId = null;
				return;
			}

			if (!keepChoices || species.Subspecies.All(s => s.Id != subspeciesId))
			{
				subspeciesId = species.Subspecies.FirstOrDefault()?.Id;
			}
			if (!species.AllowedSizes.Contains(size))
			{
				size = species.AllowedSizes.Contains(CreatureSize.Medium) ? CreatureSize.Medium : species.AllowedSizes.FirstOrDefault();
			}
		}

		private async Task LoadBackgroundAsync(bool keepChoices)
		{
			background = backgroundId == Guid.Empty ? null : await BackgroundService.GetBackgroundAsync(backgroundId, Lang);
			var hasGold = background?.EquipmentGoldAlternative is not null;
			if (!keepChoices || (hasGold && backgroundChoice is not ("A" or "B")) || (!hasGold && backgroundChoice is not null))
			{
				backgroundChoice = hasGold ? "A" : null;
			}

			//	The class skills cannot repeat the background ones
			if (background is not null)
			{
				classSkills.RemoveAll(s => background.SkillProficiencies.Contains(s));
			}
			if (!keepChoices)
			{
				ResetBonusPicks();
			}
		}

		private async Task LoadClassAsync(bool keepChoices)
		{
			cls = classId == Guid.Empty ? null : await ClassService.GetClassDetailAsync(classId, Lang);
			if (!keepChoices)
			{
				classSkills.Clear();
				subclassId = null;
				spellIds.Clear();
			}

			var loadout = ClassLoadout;
			var valid = loadout.Kits.Count > 0
				? classChoice.Count == 1 && loadout.Kits.Any(k => k.Letter == classChoice[0])
				: classChoice.Count == loadout.Rows.Count;
			if (!keepChoices || !valid)
			{
				classChoice = loadout.Kits.Count > 0
					? new List<string> { loadout.Kits[0].Letter ?? "A" }
					: loadout.Rows.Select(r => r.Options.Count == 1 ? string.Empty : r.Options[0].Letter ?? string.Empty).ToList();
			}

			FixSubclass();
		}

		// ===== Changes =====

		private async Task OnRulesetChanged(RulesetVersion value)
		{
			ruleset = value;
			bonusMode = AbilityBonusMode.TwoAndOne;
			await LoadEditionAsync(keepChoices: false);
		}

		private void OnLevelChanged(ChangeEventArgs e)
		{
			if (int.TryParse(e.Value?.ToString(), out var value))
			{
				level = Math.Clamp(value, 1, 20);
				FixSubclass();
			}
		}

		private void FixSubclass()
		{
			if (cls is null || level < cls.SubclassLevel || cls.Subclasses.All(s => s.Id != subclassId))
			{
				subclassId = cls is not null && level >= cls.SubclassLevel ? cls.Subclasses.FirstOrDefault()?.Id : null;
			}
		}

		private async Task OnSpeciesChanged(Guid value)
		{
			speciesId = value;
			subspeciesId = null;
			await LoadSpeciesAsync(keepChoices: false);
		}

		private async Task OnBackgroundChanged(Guid value)
		{
			backgroundId = value;
			await LoadBackgroundAsync(keepChoices: false);
		}

		private async Task OnClassChanged(Guid value)
		{
			classId = value;
			await LoadClassAsync(keepChoices: false);
		}

		private void ToggleSkill(Skill skill)
		{
			if (!classSkills.Remove(skill) && cls is not null && classSkills.Count < cls.SkillChoiceCount)
			{
				classSkills.Add(skill);
			}
		}

		// ===== Ability scores =====

		private void OnMethodChanged(AbilityMethod value)
		{
			method = value;
			selectedPool = null;
			if (method == AbilityMethod.StandardArray)
			{
				Array.Clear(assigned);
				pool = CharacterMath.StandardArray.ToList();
			}
		}

		private int?[] CurrentAssigned => method == AbilityMethod.Roll ? rolledAssigned : assigned;

		private List<int> CurrentPool => method == AbilityMethod.Roll ? RolledPool : pool;

		//	Rolled results still to assign (each assigned value removes one occurrence)
		private List<int> RolledPool
		{
			get
			{
				var left = rolledResults.ToList();
				foreach (var value in rolledAssigned.Where(v => v is not null))
				{
					left.Remove(value!.Value);
				}

				return left;
			}
		}

		private void SelectPool(int index) => selectedPool = selectedPool == index ? null : index;

		private void AssignTo(int abilityIndex)
		{
			var target = CurrentAssigned;
			var available = CurrentPool;

			if (selectedPool is { } poolIndex && poolIndex < available.Count)
			{
				var value = available[poolIndex];
				if (method == AbilityMethod.StandardArray)
				{
					pool.RemoveAt(poolIndex);
					if (target[abilityIndex] is { } previous)
					{
						pool.Add(previous);
					}
					pool = pool.OrderByDescending(v => v).ToList();
				}

				target[abilityIndex] = value;
				selectedPool = null;
				return;
			}

			//	No value selected: give the assigned one back to the pool
			if (target[abilityIndex] is { } current)
			{
				if (method == AbilityMethod.StandardArray)
				{
					pool.Add(current);
					pool = pool.OrderByDescending(v => v).ToList();
				}
				target[abilityIndex] = null;
			}
		}

		//	Highest values to the primary abilities of the class, then Constitution and Dexterity
		private void ApplySuggestedArray()
		{
			var order = (cls?.PrimaryAbilities ?? new List<AbilityScore>())
				.Concat(new[] { AbilityScore.Constitution, AbilityScore.Dexterity })
				.Concat(CharacterMath.Abilities)
				.Distinct()
				.ToList();

			var values = CharacterMath.StandardArray.OrderByDescending(v => v).ToList();
			for (var i = 0; i < order.Count; i++)
			{
				assigned[(int)order[i] - 1] = values[i];
			}
			pool.Clear();
			selectedPool = null;
		}

		private int PointsLeft => CharacterMath.PointBuyBudget - pointBuy.Sum(s => CharacterMath.PointBuyCost(s) ?? 0);

		private bool CanRaise(int index) =>
			pointBuy[index] < 15 && (CharacterMath.PointBuyCost(pointBuy[index] + 1) ?? 99) - (CharacterMath.PointBuyCost(pointBuy[index]) ?? 0) <= PointsLeft;

		private void Raise(int index)
		{
			if (CanRaise(index))
			{
				pointBuy[index]++;
			}
		}

		private void Lower(int index)
		{
			if (pointBuy[index] > 8)
			{
				pointBuy[index]--;
			}
		}

		private void RequestRoll()
		{
			if (rolling || rollsLeft == 0)
			{
				return;
			}
			if (rolledResults.Count > 0)
			{
				rerollConfirmOpen = true;
				return;
			}

			_ = RollAsync();
		}

		private void ConfirmReroll()
		{
			rerollConfirmOpen = false;
			_ = RollAsync();
		}

		//	Six rows of 4d6: the dice tumble for a moment, then the lowest one of each row is dropped
		private async Task RollAsync()
		{
			rolling = true;
			rollsLeft--;
			rolledResults.Clear();
			Array.Clear(rolledAssigned);
			selectedPool = null;
			diceRows = Enumerable.Range(0, 6).Select(_ => new DiceRow()).ToList();

			for (var frame = 0; frame < 10; frame++)
			{
				foreach (var row in diceRows)
				{
					for (var d = 0; d < 4; d++)
					{
						row.Dice[d] = Random.Shared.Next(1, 7);
					}
				}
				StateHasChanged();
				await Task.Delay(70);
			}

			foreach (var row in diceRows)
			{
				row.Dropped = Array.IndexOf(row.Dice, row.Dice.Min());
			}

			rolledResults = diceRows.Select(r => r.Total).OrderByDescending(v => v).ToList();
			rolling = false;
			StateHasChanged();
		}

		private int? BaseScore(int index) => method switch
		{
			AbilityMethod.PointBuy => pointBuy[index],
			AbilityMethod.Roll => rolledAssigned[index],
			_ => assigned[index]
		};

		private bool ScoresComplete => Enumerable.Range(0, 6).All(i => BaseScore(i) is not null);

		private List<int> BaseScores => Enumerable.Range(0, 6).Select(i => BaseScore(i) ?? 8).ToList();

		// ===== Increases =====

		private bool Is2024 => ruleset == RulesetVersion.Dnd5e_2024;

		//	2024: the three abilities of the background (any ability for a background that lists none); 2014: any ability
		private IReadOnlyList<AbilityScore> AllowedIncreases =>
			Is2024 && background is { AbilityOptions.Count: > 0 } ? background.AbilityOptions : CharacterMath.Abilities;

		private IEnumerable<AbilityBonusMode> BonusModes => Is2024
			? new[] { AbilityBonusMode.TwoAndOne, AbilityBonusMode.ThreeOnes }
			: new[] { AbilityBonusMode.TwoAndOne, AbilityBonusMode.ThreeOnes, AbilityBonusMode.AllOnes };

		private void ResetBonusPicks()
		{
			var allowed = AllowedIncreases;
			for (var i = 0; i < picks.Length; i++)
			{
				picks[i] = i < allowed.Count ? allowed[i] : CharacterMath.Abilities[i];
			}
		}

		private void OnBonusModeChanged(AbilityBonusMode value)
		{
			bonusMode = value;
			ResetBonusPicks();
		}

		//	Choices for the n-th pick: the allowed abilities not taken by the other picks of the mode
		private List<ForgeSelector<AbilityScore>.Option> PickOptions(int index)
		{
			var used = Enumerable.Range(0, PickCount).Where(i => i != index).Select(i => picks[i]).ToHashSet();
			return AllowedIncreases.Where(a => !used.Contains(a))
				.Select(a => new ForgeSelector<AbilityScore>.Option(a, FeatPrerequisiteFormatter.AbilityName(a, Lang)))
				.ToList();
		}

		private int PickCount => bonusMode switch
		{
			AbilityBonusMode.TwoAndOne => 2,
			AbilityBonusMode.ThreeOnes => 3,
			_ => 0
		};

		private void SetPick(int index, AbilityScore value) => picks[index] = value;

		private List<int> Bonuses
		{
			get
			{
				var bonuses = new int[6];
				switch (bonusMode)
				{
					case AbilityBonusMode.TwoAndOne:
						bonuses[(int)picks[0] - 1] += 2;
						bonuses[(int)picks[1] - 1] += 1;
						break;
					case AbilityBonusMode.ThreeOnes:
						for (var i = 0; i < 3; i++)
						{
							bonuses[(int)picks[i] - 1] += 1;
						}
						break;
					default:
						Array.Fill(bonuses, 1);
						break;
				}

				return bonuses.ToList();
			}
		}

		private bool BonusesValid =>
			CharacterMath.AreValidBonuses(bonusMode, Bonuses, Is2024 && background is not null ? background.AbilityOptions : new List<AbilityScore>());

		private int[] FinalScores => CharacterMath.FinalScores(BaseScores, Bonuses);

		private int Mod(AbilityScore ability) => CharacterMath.Modifier(CharacterMath.Score(FinalScores, ability));

		//	2014: the species trait that lists the increases
		private TraitResponseDto? IncreaseTrait =>
			species?.BaseTraits.Concat(ActiveSubspecies?.Traits ?? new List<TraitResponseDto>())
				.FirstOrDefault(t => t.Name.Contains("Ability Score", StringComparison.OrdinalIgnoreCase)
					|| t.Name.Contains("Punteggi di Caratteristica", StringComparison.OrdinalIgnoreCase)
					|| t.Name.Contains("Punteggio di Caratteristica", StringComparison.OrdinalIgnoreCase));

		// ===== Equipment =====

		private string? GoldText => background?.EquipmentGoldAlternative is int gold ? (Lang == LanguageCode.It ? $"{gold} mo" : $"{gold} GP") : null;

		private EquipmentLoadout BackgroundLoadout => EquipmentLoadout.FromBackground(background?.Equipment, GoldText);

		private EquipmentLoadout ClassLoadout => EquipmentLoadout.FromClassText(cls?.StartingEquipment);

		private void SetClassChoice(int index, string letter)
		{
			if (index < classChoice.Count)
			{
				classChoice[index] = letter;
			}
		}

		private IEnumerable<LoadoutItem> ChosenItems()
		{
			var bg = BackgroundLoadout;
			var bgItems = bg.Kits.Count > 0
				? bg.Kits.FirstOrDefault(k => k.Letter == backgroundChoice)?.Items ?? Array.Empty<LoadoutItem>()
				: bg.Rows.SelectMany(r => r.Options[0].Items);

			var loadout = ClassLoadout;
			var classItems = loadout.Kits.Count > 0
				? loadout.Kits.FirstOrDefault(k => classChoice.Count > 0 && k.Letter == classChoice[0])?.Items ?? Array.Empty<LoadoutItem>()
				: loadout.Rows.SelectMany((row, i) => row.Options.Count == 1
					? row.Options[0].Items
					: row.Options.FirstOrDefault(o => i < classChoice.Count && o.Letter == classChoice[i])?.Items ?? Array.Empty<LoadoutItem>());

			return bgItems.Concat(classItems);
		}

		private static string ItemLine(LoadoutItem item) =>
			string.Join(" ", new[] { item.Quantity is > 1 ? $"{item.Quantity}" : null, item.Text, item.Coins }.Where(p => !string.IsNullOrWhiteSpace(p)));

		private static string OptionSummary(LoadoutOption option) => string.Join(", ", option.Items.Select(ItemLine));

		private Guid? ItemId(LoadoutItem item) => item.Coins is null ? Glossary.FindEquipment(Lang, ruleset, item.Text) : null;

		// ===== Spells =====

		private SpellcastingClass? SpellListOfClass => cls is null ? null : Glossary.SpellListOfClass(Lang, cls.Id);

		private SubclassResponseDto? Subclass => cls?.Subclasses.FirstOrDefault(s => s.Id == subclassId);

		private AbilityScore? SpellcastingAbility => Subclass?.SpellcastingAbility ?? cls?.SpellcastingAbility;

		private string? ClassKey => cls is null ? null : Glossary.ClassKey(Lang, cls.Id);

		private SpellAllowance Allowance => SpellListOfClass is null || cls is null
			? SpellAllowance.None
			: CharacterMath.Spells(cls.ProgressionTable, level, SpellcastingAbility is { } a ? Mod(a) : 0, ClassKey == "paladin");

		private IEnumerable<SpellResponseDto> ClassSpells => SpellListOfClass is { } list
			? spellList.Where(s => s.Classes.Contains(list))
			: Enumerable.Empty<SpellResponseDto>();

		private List<SpellResponseDto> AvailableCantrips => Allowance.Cantrips > 0 ? ClassSpells.Where(s => s.Level == 0).ToList() : new();

		private List<SpellResponseDto> AvailableSpells => Allowance.Spells > 0
			? ClassSpells.Where(s => s.Level >= 1 && s.Level <= Allowance.MaxSpellLevel).ToList()
			: new();

		private bool MatchesSearch(SpellResponseDto spell) =>
			string.IsNullOrWhiteSpace(spellSearch) || spell.Name.Contains(spellSearch.Trim(), StringComparison.OrdinalIgnoreCase);

		private int SelectedCantrips => AvailableCantrips.Count(s => spellIds.Contains(s.Id));

		private int SelectedSpells => AvailableSpells.Count(s => spellIds.Contains(s.Id));

		private int CantripTarget => Math.Min(Allowance.Cantrips, AvailableCantrips.Count);

		private int SpellTarget => Math.Min(Allowance.Spells, AvailableSpells.Count);

		private void ToggleSpell(SpellResponseDto spell)
		{
			if (spellIds.Remove(spell.Id))
			{
				return;
			}

			var full = spell.Level == 0 ? SelectedCantrips >= Allowance.Cantrips : SelectedSpells >= Allowance.Spells;
			if (!full)
			{
				spellIds.Add(spell.Id);
			}
		}

		//	Drops the spells the current class, level and scores no longer allow
		private void PruneSpells()
		{
			var valid = AvailableCantrips.Concat(AvailableSpells).Select(s => s.Id).ToHashSet();
			spellIds.RemoveWhere(id => !valid.Contains(id));

			foreach (var extra in AvailableCantrips.Where(s => spellIds.Contains(s.Id)).Skip(Allowance.Cantrips).ToList())
			{
				spellIds.Remove(extra.Id);
			}
			foreach (var extra in AvailableSpells.Where(s => spellIds.Contains(s.Id)).Skip(Allowance.Spells).ToList())
			{
				spellIds.Remove(extra.Id);
			}
		}

		// ===== Derived values (summary) =====

		private SubspeciesResponseDto? ActiveSubspecies => species?.Subspecies.FirstOrDefault(s => s.Id == subspeciesId);

		private int Speed => ActiveSubspecies?.BaseSpeedOverrideInFeet ?? species?.BaseSpeedInFeet ?? 30;

		private int ProficiencyBonus => CharacterMath.ProficiencyBonus(level);

		private int MaxHitPoints => CharacterMath.MaxHitPoints(cls?.HitDie ?? 8, level, Mod(AbilityScore.Constitution));

		private int ArmorClass
		{
			get
			{
				var worn = ChosenItems()
					.Select(ItemId)
					.Where(id => id is not null && equipment.ContainsKey(id.Value))
					.Select(id => equipment[id!.Value].Stats)
					.Where(s => s.Category == EquipmentCategory.Armor && s.ArmorCategory is not null && s.ArmorClass is not null)
					.Select(s => new WornArmor(s.ArmorCategory!.Value, s.ArmorClass!.Value, s.ArmorAddsDexterity, s.ArmorMaxDexterityBonus));

				var scores = FinalScores;
				return CharacterMath.ArmorClass(worn,
					CharacterMath.Score(scores, AbilityScore.Dexterity), CharacterMath.Score(scores, AbilityScore.Constitution),
					CharacterMath.Score(scores, AbilityScore.Wisdom), ClassKey);
			}
		}

		private List<Skill> AllSkills => (background?.SkillProficiencies ?? new List<Skill>()).Concat(classSkills).Distinct().ToList();

		private int PassivePerception => 10 + Mod(AbilityScore.Wisdom) + (AllSkills.Contains(Skill.Perception) ? ProficiencyBonus : 0);

		private List<string> Languages => new[] { UiText.CommonLanguage(Lang), languageOne, languageTwo }
			.Where(l => !string.IsNullOrWhiteSpace(l)).Distinct().ToList();

		// ===== Navigation =====

		private string? StepProblem(int number)
		{
			switch (number)
			{
				case 1:
					return string.IsNullOrWhiteSpace(name) ? UiText.ErrName(Lang) : null;
				case 2:
					return species is null || background is null ? UiText.WizardLoading(Lang) : null;
				case 3:
					if (cls is null)
					{
						return UiText.WizardLoading(Lang);
					}
					var options = cls.SkillOptions.Count(s => background?.SkillProficiencies.Contains(s) != true);
					var needed = Math.Min(cls.SkillChoiceCount, options);
					return classSkills.Count < needed ? UiText.ErrSkills(needed, Lang) : null;
				case 4:
					if (!ScoresComplete)
					{
						return UiText.ErrScores(Lang);
					}
					return method == AbilityMethod.PointBuy && PointsLeft > 0 ? UiText.ErrPoints(Lang) : null;
				case 5:
					return BonusesValid ? null : UiText.LabelAbilityIncreases(Lang);
				case 7:
					return SelectedCantrips < CantripTarget || SelectedSpells < SpellTarget ? UiText.ErrSpells(Lang) : null;
				default:
					return null;
			}
		}

		private void Next()
		{
			stepError = StepProblem(step);
			if (stepError is not null || step >= StepCount)
			{
				return;
			}

			step++;
			furthestStep = Math.Max(furthestStep, step);
			if (step == 7)
			{
				PruneSpells();
			}
		}

		private void Back()
		{
			stepError = null;
			if (step > 1)
			{
				step--;
			}
		}

		//	The dots go back to any step already reached, or forward when every step in between is complete
		private void GoTo(int target)
		{
			if (target == step || target > furthestStep)
			{
				return;
			}
			for (var i = step; i < target; i++)
			{
				if (StepProblem(i) is { } problem)
				{
					stepError = problem;
					return;
				}
			}

			stepError = null;
			step = target;
			if (step == 7)
			{
				PruneSpells();
			}
		}

		private async Task SaveAsync()
		{
			for (var i = 1; i < StepCount; i++)
			{
				if (StepProblem(i) is { } problem)
				{
					step = i;
					stepError = problem;
					return;
				}
			}

			PruneSpells();
			saving = true;
			saveError = null;

			var dto = new SaveCharacterDto
			{
				Name = name.Trim(),
				Ruleset = ruleset,
				Level = level,
				Alignment = alignment,
				SpeciesId = speciesId,
				SubspeciesId = subspeciesId,
				Size = size,
				BackgroundId = backgroundId,
				Languages = Languages,
				ClassId = classId,
				SubclassId = subclassId,
				ClassSkills = classSkills.ToList(),
				AbilityMethod = method,
				BaseScores = BaseScores,
				BonusMode = bonusMode,
				AbilityBonuses = Bonuses,
				BackgroundEquipment = backgroundChoice,
				ClassEquipment = classChoice.ToList(),
				SpellIds = spellIds.ToList()
			};

			var (id, error) = await CharacterService.CreateCharacterAsync(dto);
			saving = false;
			if (id is { } created)
			{
				Navigation.NavigateTo($"characters/{created}");
				return;
			}

			saveError = error;
		}

		// ===== Selector options =====

		private static List<ForgeSelector<RulesetVersion>.Option> EditionOptions => new()
		{
			new(RulesetVersion.Dnd5e_2024, "D&D 5.5e (2024)"),
			new(RulesetVersion.Dnd5e_2014, "D&D 5e (2014)")
		};

		private List<ForgeSelector<Alignment>.Option> AlignmentOptions =>
			Enum.GetValues<Alignment>().Select(a => new ForgeSelector<Alignment>.Option(a, UiText.AlignmentName(a, Lang))).ToList();

		private List<ForgeSelector<Guid>.Option> SpeciesOptions => speciesList.Select(s => new ForgeSelector<Guid>.Option(s.Id, s.Name)).ToList();

		private List<ForgeSelector<Guid?>.Option> SubspeciesOptions =>
			species?.Subspecies.Select(s => new ForgeSelector<Guid?>.Option(s.Id, s.Name)).ToList() ?? new();

		private List<ForgeSelector<CreatureSize>.Option> SizeOptions =>
			species?.AllowedSizes.Select(s => new ForgeSelector<CreatureSize>.Option(s, UiText.FormatSizeSingle(s, Lang))).ToList() ?? new();

		private List<ForgeSelector<Guid>.Option> BackgroundOptions => backgroundList.Select(b => new ForgeSelector<Guid>.Option(b.Id, b.Name)).ToList();

		private List<ForgeSelector<string>.Option> LanguageOptions(string other) =>
			UiText.StandardLanguages(ruleset, Lang).Where(l => l != other).Select(l => new ForgeSelector<string>.Option(l, l)).ToList();

		private List<ForgeSelector<Guid>.Option> ClassOptions => classList.Select(c => new ForgeSelector<Guid>.Option(c.Id, c.Name)).ToList();

		private List<ForgeSelector<Guid?>.Option> SubclassOptions =>
			cls?.Subclasses.Select(s => new ForgeSelector<Guid?>.Option(s.Id, s.Name)).ToList() ?? new();

		private List<ForgeSelector<AbilityMethod>.Option> MethodOptions =>
			Enum.GetValues<AbilityMethod>().Select(m => new ForgeSelector<AbilityMethod>.Option(m, UiText.AbilityMethodName(m, Lang))).ToList();

		private List<ForgeSelector<AbilityBonusMode>.Option> BonusModeOptions =>
			BonusModes.Select(m => new ForgeSelector<AbilityBonusMode>.Option(m, UiText.BonusModeName(m, Lang))).ToList();

		private List<ForgeSelector<string>.Option> LetterOptions(IEnumerable<LoadoutOption> options) =>
			options.Select(o => new ForgeSelector<string>.Option(o.Letter ?? string.Empty, UiText.OptionLetter(o.Letter ?? "?", Lang))).ToList();

		private GlossaryLinker? Terms => Glossary.Linker(Lang, ruleset);
	}
}
