using Microsoft.AspNetCore.Components;
using RealmForge.Client.Components.Wizard;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Pages
{
	public enum WizardMode
	{
		Create = 1,
		Edit = 2,
		LevelUp = 3
	}

	///	<summary>
	///	Character wizard: creation (/characters/new), edit and level up (/characters/{id}/edit). The steps follow the
	///	order of the Player's Handbook of the edition; every change recomputes the character with
	///	<see cref="CharacterCalculator"/>, and a step can be left only when its choices are complete.
	///	</summary>
	public partial class CharacterWizard : IDisposable
	{
		[Parameter] public Guid? Id { get; set; }

		[SupplyParameterFromQuery(Name = "levelup")]
		public bool LevelUpQuery { get; set; }

		[Inject] public LanguageStateService LanguageState { get; set; } = default!;
		[Inject] public CharacterDataService Characters { get; set; } = default!;
		[Inject] public SpeciesDataService SpeciesService { get; set; } = default!;
		[Inject] public BackgroundDataService BackgroundService { get; set; } = default!;
		[Inject] public ClassDataService ClassService { get; set; } = default!;
		[Inject] public GlossaryService Glossary { get; set; } = default!;
		[Inject] private NavigationManager Navigation { get; set; } = default!;

		public LanguageCode Lang => LanguageState.CurrentLanguage;
		public WizardMode Mode { get; private set; } = WizardMode.Create;

		public CharacterInput Input { get; private set; } = new();
		public CharacterContextDto? Context { get; private set; }
		public ComputedCharacter Computed { get; private set; } = null!;
		public WizardAbilityState Abilities { get; } = new();

		public RulesetVersion Ruleset => Input.Ruleset;
		public CharacterBuild Build => Input.Build;
		public bool Is2024 => Input.Ruleset == RulesetVersion.Dnd5e_2024;

		private bool loading = true;
		private bool loadFailed;
		private bool saving;
		private string? saveError;
		private List<string> stepProblems = new();
		private int stepIndex;
		private int furthestIndex;

		//	Details loaded on demand (descriptions, traits, features)
		public Dictionary<Guid, SpeciesDetailResponseDto> SpeciesDetails { get; } = new();
		public Dictionary<Guid, BackgroundDetailResponseDto> BackgroundDetails { get; } = new();
		public Dictionary<Guid, ClassDetailResponseDto> ClassDetails { get; } = new();

		public List<WizardStep> Steps => (Is2024
				? new[] { WizardStep.Identity, WizardStep.Class, WizardStep.Background, WizardStep.Species, WizardStep.Abilities, WizardStep.Progression, WizardStep.Languages, WizardStep.Equipment, WizardStep.Spells, WizardStep.Details, WizardStep.Summary }
				: new[] { WizardStep.Identity, WizardStep.Species, WizardStep.Class, WizardStep.Abilities, WizardStep.Background, WizardStep.Progression, WizardStep.Languages, WizardStep.Equipment, WizardStep.Spells, WizardStep.Details, WizardStep.Summary })
			.Where(s => Mode == WizardMode.Create || s != WizardStep.Equipment)
			.ToList();

		public WizardStep CurrentStep => Steps[Math.Clamp(stepIndex, 0, Steps.Count - 1)];

		protected override async Task OnInitializedAsync()
		{
			LanguageState.OnLanguageChanged += OnLanguageChanged;
			await LoadAsync();
		}

		private void OnLanguageChanged() => _ = InvokeAsync(async () =>
		{
			//	Same choices, names in the new language
			SpeciesDetails.Clear();
			BackgroundDetails.Clear();
			ClassDetails.Clear();
			Context = await Characters.GetContextAsync(Ruleset, Lang);
			await Glossary.EnsureLoadedAsync(Lang);
			Update();
			await LoadDetailsAsync();
			StateHasChanged();
		});

		public void Dispose() => LanguageState.OnLanguageChanged -= OnLanguageChanged;

		private async Task LoadAsync()
		{
			loading = true;
			await Glossary.EnsureLoadedAsync(Lang);

			if (Id is { } id)
			{
				var character = await Characters.GetCharacterAsync(id);
				if (character is null)
				{
					loadFailed = true;
					loading = false;
					return;
				}

				Mode = LevelUpQuery ? WizardMode.LevelUp : WizardMode.Edit;
				Input = new CharacterInput
				{
					Name = character.Name,
					Ruleset = character.Ruleset,
					SpeciesId = character.SpeciesId,
					SubspeciesId = character.SubspeciesId,
					BackgroundId = character.BackgroundId,
					Build = character.Build,
					Sheet = character.Sheet
				};
				Abilities.LoadFrom(Build);
				SavedLevels = Build.Levels.Count;
			}

			Context = await Characters.GetContextAsync(Ruleset, Lang);
			if (Context is null)
			{
				loadFailed = true;
				loading = false;
				return;
			}

			if (Mode == WizardMode.Create)
			{
				ApplyDefaults();
			}
			else if (Mode == WizardMode.LevelUp && Build.Levels.Count < 20)
			{
				AddLevel(Build.Levels[^1].ClassId);
				stepIndex = furthestIndex = Steps.IndexOf(WizardStep.Progression);
			}
			else
			{
				furthestIndex = Steps.Count - 1;
			}

			Update();
			await LoadDetailsAsync();
			loading = false;
		}

		///	<summary>
		///	A new character of the edition: the first class, species and background, level 1.
		///	</summary>
		private void ApplyDefaults()
		{
			var context = Context!;
			Input.SpeciesId = context.Species.FirstOrDefault(s => s.Key is not null)?.Id ?? context.Species.FirstOrDefault()?.Id ?? Guid.Empty;
			Input.BackgroundId = context.Backgrounds.FirstOrDefault(b => b.Key is not null)?.Id ?? context.Backgrounds.FirstOrDefault()?.Id ?? Guid.Empty;
			var cls = context.Classes.FirstOrDefault(c => c.Key == "fighter") ?? context.Classes.FirstOrDefault();
			Build.Classes = cls is null ? new() : new() { new CharacterClassBuild { ClassId = cls.Id } };
			Build.Levels = cls is null ? new() : new() { new CharacterLevelBuild { ClassId = cls.Id } };
			Build.BaseScores = new();
			Build.Languages = new();
			Build.BonusChoices = new();
			Build.BonusMode = AbilityBonusMode.TwoAndOne;
			FixSpecies();
			FixBackground();
			FixClassEquipment();
		}

		public async Task ChangeRulesetAsync(RulesetVersion ruleset)
		{
			if (Mode != WizardMode.Create || ruleset == Input.Ruleset)
			{
				return;
			}

			var name = Input.Name;
			Input = new CharacterInput { Name = name, Ruleset = ruleset };
			Abilities.Reset();
			loading = true;
			StateHasChanged();
			Context = await Characters.GetContextAsync(ruleset, Lang);
			if (Context is null)
			{
				loadFailed = true;
			}
			else
			{
				ApplyDefaults();
				Update();
				await LoadDetailsAsync();
			}
			loading = false;
			StateHasChanged();
		}

		// ===== Recompute =====

		///	<summary>
		///	Recomputes the character after a change and re-renders the wizard.
		///	</summary>
		public void Update()
		{
			if (Context is null)
			{
				return;
			}

			Normalize();
			RefreshPreview();
			Computed = CharacterCalculator.Compute(Input, Context, checkEquipment: Mode == WizardMode.Create);
			stepProblems = stepProblems.Count > 0 ? ProblemsOf(CurrentStep) : stepProblems;
			StateHasChanged();
		}

		public async Task UpdateAsync()
		{
			Update();
			await LoadDetailsAsync();
			StateHasChanged();
		}

		///	<summary>
		///	Keeps the build consistent: the first class is the one of level 1, classes without levels disappear,
		///	choices that the levels no longer allow are dropped.
		///	</summary>
		private void Normalize()
		{
			var build = Build;
			if (build.Levels.Count == 0)
			{
				return;
			}

			var startingId = build.Levels[0].ClassId;
			var withLevels = build.Levels.Select(l => l.ClassId).Distinct().ToHashSet();
			build.Classes.RemoveAll(c => !withLevels.Contains(c.ClassId));
			foreach (var id in withLevels.Where(id => build.Classes.All(c => c.ClassId != id)))
			{
				build.Classes.Add(new CharacterClassBuild { ClassId = id });
			}
			var starting = build.Classes.First(c => c.ClassId == startingId);
			build.Classes.Remove(starting);
			build.Classes.Insert(0, starting);

			build.Levels[0].HitPointRoll = null;
			var counts = new Dictionary<Guid, int>();
			foreach (var level in build.Levels)
			{
				counts[level.ClassId] = counts.GetValueOrDefault(level.ClassId) + 1;
				var cls = Class(level.ClassId);
				if (cls is null)
				{
					continue;
				}

				var classLevel = counts[level.ClassId];
				var improvement = CharacterRules.ImprovementLevels(cls, Ruleset).Contains(classLevel) || CharacterRules.EpicBoonLevel(Ruleset) == classLevel;
				if (!improvement)
				{
					level.FeatId = null;
					level.Feat = new FeatChoice();
					level.Increases.Clear();
				}
				if (level.HitPointRoll is { } roll && (roll < 1 || roll > cls.HitDie))
				{
					level.HitPointRoll = null;
				}
			}

			foreach (var entry in build.Classes)
			{
				var cls = Class(entry.ClassId);
				var level = counts.GetValueOrDefault(entry.ClassId);
				if (cls is null)
				{
					continue;
				}
				if (entry.SubclassId is not null && (level < cls.SubclassLevel || cls.Subclasses.All(s => s.Id != entry.SubclassId)))
				{
					entry.SubclassId = null;
				}
				if (CharacterRules.FightingStyleLevel(cls) is not { } styleLevel || level < styleLevel)
				{
					entry.FightingStyle = null;
					entry.FightingStyleFeatId = null;
					entry.StyleCantrips.Clear();
				}
				if (!Is2024 || CharacterRules.Orders2024(cls).Count == 0)
				{
					entry.Order = null;
				}
				var masteries = CharacterRules.WeaponMasteries(cls, Ruleset, level);
				if (entry.WeaponMasteries.Count > masteries)
				{
					entry.WeaponMasteries.RemoveRange(masteries, entry.WeaponMasteries.Count - masteries);
				}
				var expertise = CharacterRules.ExpertiseCount(cls, Ruleset, level);
				if (entry.Expertise.Count > expertise)
				{
					entry.Expertise.RemoveRange(expertise, entry.Expertise.Count - expertise);
				}
			}
		}

		// ===== Lookups =====

		public ContextClass? Class(Guid id) => Context?.Classes.FirstOrDefault(c => c.Id == id);
		public ContextSpecies? Species => Context?.Species.FirstOrDefault(s => s.Id == Input.SpeciesId);
		public ContextSubspecies? Subspecies => Species?.Subspecies.FirstOrDefault(s => s.Id == Input.SubspeciesId);
		public ContextBackground? Background => Context?.Backgrounds.FirstOrDefault(b => b.Id == Input.BackgroundId);
		public ContextClass? StartingClass => Build.Levels.Count > 0 ? Class(Build.Levels[0].ClassId) : null;
		public CharacterClassBuild? StartingClassBuild => Build.Classes.FirstOrDefault();
		public ContextFeat? Feat(Guid? id) => id is null ? null : Context?.Feats.FirstOrDefault(f => f.Id == id);
		public ContextSpell? Spell(Guid id) => Context?.Spells.FirstOrDefault(s => s.Id == id);

		public async Task LoadDetailsAsync()
		{
			var tasks = new List<Task>();
			if (Input.SpeciesId != Guid.Empty && !SpeciesDetails.ContainsKey(Input.SpeciesId))
			{
				var id = Input.SpeciesId;
				tasks.Add(Run(async () =>
				{
					if (await SpeciesService.GetSpeciesDetailAsync(id, Lang) is { } detail)
					{
						SpeciesDetails[id] = detail;
					}
				}));
			}
			if (Input.BackgroundId != Guid.Empty && !BackgroundDetails.ContainsKey(Input.BackgroundId))
			{
				var id = Input.BackgroundId;
				tasks.Add(Run(async () =>
				{
					if (await BackgroundService.GetBackgroundAsync(id, Lang) is { } detail)
					{
						BackgroundDetails[id] = detail;
					}
				}));
			}
			foreach (var id in Build.Classes.Select(c => c.ClassId).Where(id => !ClassDetails.ContainsKey(id)).ToList())
			{
				tasks.Add(Run(async () =>
				{
					if (await ClassService.GetClassDetailAsync(id, Lang) is { } detail)
					{
						ClassDetails[id] = detail;
					}
				}));
			}

			if (tasks.Count > 0)
			{
				await Task.WhenAll(tasks);
				StateHasChanged();
			}

			static Task Run(Func<Task> load) => load();
		}

		// ===== Changes =====

		public async Task SetSpeciesAsync(Guid id)
		{
			Input.SpeciesId = id;
			Input.SubspeciesId = null;
			Build.SpeciesSkills.Clear();
			Build.SpeciesFeatId = null;
			Build.SpeciesFeat = new FeatChoice();
			Build.SpeciesCantrips.Clear();
			if (!Is2024)
			{
				Build.BonusChoices.Clear();
			}
			FixSpecies();
			await UpdateAsync();
		}

		public void SetSubspecies(Guid? id)
		{
			Input.SubspeciesId = id;
			Build.SpeciesCantrips.Clear();
			if (!Is2024)
			{
				Build.BonusChoices.Clear();
				Build.SpeciesSkills.Clear();
				Build.SpeciesFeatId = null;
				Build.SpeciesFeat = new FeatChoice();
			}
			Update();
		}

		private void FixSpecies()
		{
			var species = Species;
			if (species is null)
			{
				return;
			}
			if (Input.SubspeciesId is null && species.Subspecies.Count > 0 && species.Key is not null)
			{
				Input.SubspeciesId = species.Subspecies[0].Id;
			}
			if (!species.Sizes.Contains(Build.Size))
			{
				Build.Size = species.Sizes.Contains(CreatureSize.Medium) ? CreatureSize.Medium : species.Sizes.FirstOrDefault();
			}
		}

		public async Task SetBackgroundAsync(Guid id)
		{
			Input.BackgroundId = id;
			Build.OriginFeat = new FeatChoice();
			if (Is2024)
			{
				Build.BonusChoices.Clear();
			}
			Build.BackgroundEquipment = null;
			Build.EquipmentPicks.RemoveAll(p => p.Slot.StartsWith("background/"));
			FixBackground();
			await UpdateAsync();
		}

		private void FixBackground()
		{
			var background = Background;
			if (background is null)
			{
				return;
			}

			Build.BackgroundEquipment = background.Equipment.Kits.Count > 0 ? background.Equipment.Kits[0].Letter : null;

			//	The skills of the background cannot be chosen again elsewhere
			foreach (var entry in Build.Classes)
			{
				entry.Skills.RemoveAll(background.Skills.Contains);
			}
			Build.SpeciesSkills.RemoveAll(background.Skills.Contains);

			//	2024: start from +2/+1 on the first two abilities of the background
			if (Is2024 && Build.BonusChoices.Count == 0 && background.AbilityOptions.Count >= 2)
			{
				Build.BonusMode = AbilityBonusMode.TwoAndOne;
				Build.BonusChoices = background.AbilityOptions.Take(2).ToList();
			}
		}

		public async Task SetStartingClassAsync(Guid id)
		{
			if (Build.Levels.Count == 0 || Build.Levels[0].ClassId == id)
			{
				return;
			}

			var old = Build.Levels[0].ClassId;
			foreach (var level in Build.Levels.Where(l => l.ClassId == old))
			{
				level.ClassId = id;
				level.FeatId = null;
				level.Feat = new FeatChoice();
				level.Increases.Clear();
				level.HitPointRoll = null;
			}
			Build.Classes.RemoveAll(c => c.ClassId == old || c.ClassId == id);
			Build.Classes.Insert(0, new CharacterClassBuild { ClassId = id });
			Build.ClassEquipment.Clear();
			Build.EquipmentPicks.RemoveAll(p => p.Slot.StartsWith("class/"));
			FixClassEquipment();
			await UpdateAsync();
		}

		public void FixClassEquipment()
		{
			var loadout = StartingClass?.Equipment ?? ContextLoadout.Empty;
			var valid = loadout.IsEmpty
				? Build.ClassEquipment.Count == 0
				: loadout.Kits.Count > 0
					? Build.ClassEquipment.Count == 1 && loadout.Kits.Any(k => k.Letter == Build.ClassEquipment[0])
					: Build.ClassEquipment.Count == loadout.Rows.Count;
			if (!valid)
			{
				Build.ClassEquipment = loadout.Kits.Count > 0
					? new List<string> { loadout.Kits[0].Letter }
					: loadout.Rows.Select(r => r.Options.Count == 1 ? string.Empty : r.Options[0].Letter).ToList();
			}
		}

		public void SetLevelCount(int count)
		{
			count = Math.Clamp(count, 1, 20);
			while (Build.Levels.Count < count)
			{
				Build.Levels.Add(new CharacterLevelBuild { ClassId = Build.Levels[0].ClassId });
			}
			while (Build.Levels.Count > count)
			{
				Build.Levels.RemoveAt(Build.Levels.Count - 1);
			}
			Update();
		}

		public void AddLevel(Guid classId)
		{
			if (Build.Levels.Count >= 20)
			{
				return;
			}
			Build.Levels.Add(new CharacterLevelBuild { ClassId = classId });
			Update();
		}

		public void RemoveLastLevel()
		{
			if (Build.Levels.Count > 1)
			{
				Build.Levels.RemoveAt(Build.Levels.Count - 1);
				Update();
			}
		}

		public async Task SetLevelClassAsync(int index, Guid classId)
		{
			if (index <= 0 || index >= Build.Levels.Count)
			{
				return;
			}
			var level = Build.Levels[index];
			level.ClassId = classId;
			level.HitPointRoll = null;
			level.FeatId = null;
			level.Feat = new FeatChoice();
			level.Increases.Clear();
			await UpdateAsync();
		}

		public CharacterClassBuild ClassBuild(Guid classId) => Build.Classes.First(c => c.ClassId == classId);

		// ===== Navigation =====

		private List<string> ProblemsOf(WizardStep step)
		{
			var area = AreaOf(step);
			if (area is null || Computed is null)
			{
				return new List<string>();
			}

			//	Scores are needed by the later steps: the ability step must have all six
			var issues = Computed.Issues.Where(i => i.Area == area).ToList();
			if (step == WizardStep.Abilities && Build.BaseScores.Count != 6 && issues.All(i => i.Code != IssueCodes.BaseScores))
			{
				issues.Add(new CharacterIssue(IssueCodes.BaseScores, true, IssueAreas.Abilities, Array.Empty<string>()));
			}

			return issues.Select(i => UiText.Issue(i, Ruleset, Lang)).Distinct().ToList();
		}

		private async Task NextAsync()
		{
			stepProblems = ProblemsOf(CurrentStep);
			if (stepProblems.Count > 0 || stepIndex >= Steps.Count - 1)
			{
				return;
			}

			stepIndex++;
			furthestIndex = Math.Max(furthestIndex, stepIndex);
			await LoadDetailsAsync();
		}

		private void Back()
		{
			stepProblems.Clear();
			if (stepIndex > 0)
			{
				stepIndex--;
			}
		}

		private void GoTo(int index)
		{
			if (index == stepIndex || index > furthestIndex)
			{
				return;
			}
			for (var i = stepIndex; i < index; i++)
			{
				var problems = ProblemsOf(Steps[i]);
				if (problems.Count > 0)
				{
					stepIndex = i;
					stepProblems = problems;
					return;
				}
			}

			stepProblems.Clear();
			stepIndex = index;
		}

		private async Task SaveAsync()
		{
			for (var i = 0; i < Steps.Count - 1; i++)
			{
				var problems = ProblemsOf(Steps[i]);
				if (problems.Count > 0)
				{
					stepIndex = i;
					stepProblems = problems;
					return;
				}
			}

			saving = true;
			saveError = null;
			var dto = new SaveCharacterDto
			{
				Name = Input.Name.Trim(),
				Ruleset = Input.Ruleset,
				SpeciesId = Input.SpeciesId,
				SubspeciesId = Input.SubspeciesId,
				BackgroundId = Input.BackgroundId,
				Language = Lang,
				Build = Build,
				Sheet = Mode == WizardMode.Create ? Input.Sheet : null
			};

			var (saved, error) = await Characters.SaveCharacterAsync(Mode == WizardMode.Create ? null : Id, dto);
			saving = false;
			if (saved is not null)
			{
				Navigation.NavigateTo($"characters/{saved.Id}");
				return;
			}

			saveError = error;
		}

		private string Title => Mode switch
		{
			WizardMode.Edit => UiText.WizardEditTitle(Lang),
			WizardMode.LevelUp => UiText.WizardLevelUpTitle(Lang),
			_ => UiText.WizardTitle(Lang)
		};
	}

	///	<summary>
	///	State of the ability score step that outlives it: the values to assign, the dice rolled and the attempts left.
	///	</summary>
	public sealed class WizardAbilityState
	{
		public AbilityMethod Method { get; set; } = AbilityMethod.StandardArray;
		public int?[] Assigned { get; } = new int?[6];
		public int[] PointBuy { get; } = { 8, 8, 8, 8, 8, 8 };
		public List<int> Pool { get; set; } = CharacterMath.StandardArray.ToList();
		public int? SelectedPool { get; set; }
		public List<int> Rolled { get; set; } = new();
		public int?[] RolledAssigned { get; } = new int?[6];
		public int RollsLeft { get; set; } = 3;
		public bool Rolling { get; set; }
		public List<DiceRow> DiceRows { get; set; } = new();

		public sealed class DiceRow
		{
			public int[] Dice { get; } = new int[4];
			public int Dropped { get; set; } = -1;
			public int Total => Dropped < 0 ? 0 : Dice.Where((_, i) => i != Dropped).Sum();
		}

		public void Reset()
		{
			Method = AbilityMethod.StandardArray;
			Array.Clear(Assigned);
			Array.Fill(PointBuy, 8);
			Pool = CharacterMath.StandardArray.ToList();
			SelectedPool = null;
			Rolled = new();
			Array.Clear(RolledAssigned);
			RollsLeft = 3;
			DiceRows = new();
		}

		//	Edit mode: the saved scores, already assigned (no new rolls)
		public void LoadFrom(CharacterBuild build)
		{
			Reset();
			Method = build.AbilityMethod;
			if (build.BaseScores.Count != 6)
			{
				return;
			}

			for (var i = 0; i < 6; i++)
			{
				switch (Method)
				{
					case AbilityMethod.PointBuy: PointBuy[i] = build.BaseScores[i]; break;
					case AbilityMethod.Roll: RolledAssigned[i] = build.BaseScores[i]; break;
					default: Assigned[i] = build.BaseScores[i]; break;
				}
			}
			if (Method == AbilityMethod.Roll)
			{
				Rolled = build.BaseScores.OrderByDescending(v => v).ToList();
				RollsLeft = 0;
			}
			Pool = Method == AbilityMethod.StandardArray ? new List<int>() : CharacterMath.StandardArray.ToList();
		}

		public int? Base(int index) => Method switch
		{
			AbilityMethod.PointBuy => PointBuy[index],
			AbilityMethod.Roll => RolledAssigned[index],
			_ => Assigned[index]
		};

		//	Writes the scores into the build when all six are set (otherwise none)
		public void WriteTo(CharacterBuild build)
		{
			build.AbilityMethod = Method;
			var values = Enumerable.Range(0, 6).Select(Base).ToList();
			build.BaseScores = values.All(v => v is not null) ? values.Select(v => v!.Value).ToList() : new List<int>();
		}
	}
}
