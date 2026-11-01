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
			Context = await ContextAsync(Ruleset);
			await Glossary.EnsureLoadedAsync(Lang);
			Update();
			await LoadDetailsAsync();
			StateHasChanged();
		});

		public void Dispose() => LanguageState.OnLanguageChanged -= OnLanguageChanged;

		//	A character of a campaign I run (edited as master): its rules come from the compendium its owner sees
		private Guid? ownerContextOf;

		private Task<CharacterContextDto?> ContextAsync(RulesetVersion ruleset) => ownerContextOf is { } characterId
			? Characters.GetCharacterContextAsync(characterId, ruleset, Lang)
			: Characters.GetContextAsync(ruleset, Lang);

		private async Task LoadAsync(bool useDraft = true)
		{
			loading = true;
			draftReady = false;
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
					Sheet = character.Sheet,
					CampaignModuleIds = character.CampaignModuleIds ?? new()
				};
				Abilities.LoadFrom(Build);
				SavedLevels = Build.Levels.Count;
				ownerContextOf = character.IsOwner ? null : character.Id;
			}

			Context = await ContextAsync(Ruleset);
			if (Context is null)
			{
				loadFailed = true;
				loading = false;
				return;
			}

			var restored = useDraft && await TryRestoreDraftAsync();
			if (restored)
			{
				//	The draft may be of the other edition
				if (Context.Ruleset != Ruleset)
				{
					Context = await ContextAsync(Ruleset);
					if (Context is null)
					{
						loadFailed = true;
						loading = false;
						return;
					}
				}
			}
			else if (Mode == WizardMode.Create)
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

			draftReady = true;
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
			var advancement = Input.Sheet.Advancement;
			Input = new CharacterInput { Name = name, Ruleset = ruleset };
			Input.Sheet.Advancement = advancement;
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
			ResolveSkillOverlaps();
			RefreshPreview();
			Computed = CharacterCalculator.Compute(Input, Context, checkEquipment: Mode == WizardMode.Create);

			//	A module added or removed an ability: its slot joins the method, and the character is computed again
			if (Abilities.SyncExtras(Computed.ExtraAbilities.Select(e => e.Definition).ToList(), Build))
			{
				var keys = Abilities.Extras.Select(e => e.Key).ToHashSet(StringComparer.OrdinalIgnoreCase);
				foreach (var level in Build.Levels)
				{
					level.ExtraIncreases.RemoveAll(k => !keys.Contains(k));
					level.Feat.ExtraIncreases.RemoveAll(k => !keys.Contains(k));
				}
				Abilities.WriteTo(Build);
				Computed = CharacterCalculator.Compute(Input, Context, checkEquipment: Mode == WizardMode.Create);
			}
			ScheduleDraftSave();
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

			//	Wizard with a spellbook: a spell prepared here (level up) is written in the book
			foreach (var entry in build.Classes.Where(e => e.Spellbook.Count > 0))
			{
				entry.Spellbook.AddRange(entry.Spells.Where(id => !entry.Spellbook.Contains(id)).ToList());
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
					level.ExtraIncreases.Clear();
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
			Build.SpeciesOption = null;
			Build.SpeciesSpellAbility = null;
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
				level.ExtraIncreases.Clear();
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
			level.ExtraIncreases.Clear();
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

			if (step == WizardStep.Class && (!Reached(WizardStep.Background) || !Reached(WizardStep.Species)) && StartingClassSkillsFine())
			{
				issues.RemoveAll(i => i.Code == IssueCodes.Skills);
			}

			//	A class skill given back by this step is picked again here
			if ((step == WizardStep.Background || step == WizardStep.Species) && step == CurrentStep && ClassSkillsShort)
			{
				issues.AddRange(Computed.Issues.Where(i => i.Area == AreaOf(WizardStep.Class) && i.Code == IssueCodes.SkillsMissing));
			}
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
			Update();
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
				Sheet = Mode == WizardMode.Create ? Input.Sheet : null,
				Advancement = Input.Sheet.Advancement
			};

			var (saved, error) = await Characters.SaveCharacterAsync(Mode == WizardMode.Create ? null : Id, dto);
			saving = false;
			if (saved is not null)
			{
				await ClearDraftAsync();
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

		//	One slot per ability: the six, then the ones added by rule modules (index 6 + i of Extras)
		public List<int?> Assigned { get; } = Enumerable.Repeat<int?>(null, 6).ToList();
		public List<int> PointBuy { get; } = Enumerable.Repeat(8, 6).ToList();
		public List<int> Pool { get; set; } = CharacterMath.StandardArray.ToList();
		public int? SelectedPool { get; set; }
		public List<int> Rolled { get; set; } = new();
		public List<int?> RolledAssigned { get; } = Enumerable.Repeat<int?>(null, 6).ToList();
		public int RollsLeft { get; set; } = 3;
		public bool Rolling { get; set; }
		public List<DiceRow> DiceRows { get; set; } = new();

		//	Definitions of the abilities added by the active rule modules (Fortuna…), in the calculator's order
		public List<RuleEffect> Extras { get; private set; } = new();

		public int Count => 6 + Extras.Count;

		//	The standard array with one more value per added ability, and the point buy budget with their points
		public List<int> ArrayValues => CharacterMath.StandardArray.Concat(Extras.Select(RuleModules.ArrayValue)).OrderByDescending(v => v).ToList();
		public int PointBudget => CharacterMath.PointBuyBudget + Extras.Sum(e => Math.Max(0, e.Points));

		public sealed class DiceRow
		{
			public int[] Dice { get; } = new int[4];
			public int Dropped { get; set; } = -1;
			public int Total => Dropped < 0 ? 0 : Dice.Where((_, i) => i != Dropped).Sum();
		}

		private static void Fill<T>(List<T> list, int count, T value)
		{
			list.Clear();
			list.AddRange(Enumerable.Repeat(value, count));
		}

		public void Reset()
		{
			Method = AbilityMethod.StandardArray;
			Fill(Assigned, Count, null);
			Fill(PointBuy, Count, 8);
			Pool = ArrayValues;
			SelectedPool = null;
			Rolled = new();
			Fill(RolledAssigned, Count, null);
			RollsLeft = 3;
			DiceRows = new();
		}

		//	Edit mode: the saved scores, already assigned (no new rolls); the added abilities follow in SyncExtras
		public void LoadFrom(CharacterBuild build)
		{
			Extras = new();
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

		///	<summary>
		///	Follows the abilities the active modules add (a module chosen or removed): their slots appear or go, the saved
		///	values of the build fill the new ones, the pool of the array and the rolls follow. True when something changed.
		///	</summary>
		public bool SyncExtras(List<RuleEffect> definitions, CharacterBuild build)
		{
			var oldKeys = Extras.Select(e => e.Key).ToList();
			var newKeys = definitions.Select(e => e.Key).ToList();
			if (oldKeys.SequenceEqual(newKeys, StringComparer.OrdinalIgnoreCase))
			{
				Extras = definitions;
				return false;
			}

			int? Saved(string? key) => build.ExtraScores.FirstOrDefault(kv => string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase)) is { Key: not null } kv ? kv.Value : null;
			int? Old<T>(List<T> list, string? key, Func<T, int?> value)
			{
				var index = oldKeys.FindIndex(k => string.Equals(k, key, StringComparison.OrdinalIgnoreCase));
				return index >= 0 && 6 + index < list.Count ? value(list[6 + index]) : null;
			}

			var assigned = newKeys.Select(k => Old(Assigned, k, v => v) ?? (Method == AbilityMethod.StandardArray ? Saved(k) : null)).ToList();
			var points = newKeys.Select(k => Old(PointBuy, k, v => v) ?? Math.Clamp(Saved(k) ?? 8, 8, 15)).ToList();
			var rolled = newKeys.Select(k => Old(RolledAssigned, k, v => v) ?? (Method == AbilityMethod.Roll ? Saved(k) : null)).ToList();
			var hadRolls = Rolled.Count;

			Extras = definitions;
			Resize(Assigned, assigned);
			Resize(PointBuy, points);
			Resize(RolledAssigned, rolled);

			//	The array: its values minus the assigned ones (a value no longer in the array leaves its ability)
			if (Method == AbilityMethod.StandardArray)
			{
				var left = ArrayValues;
				for (var i = 0; i < Count; i++)
				{
					if (Assigned[i] is { } value && !left.Remove(value))
					{
						Assigned[i] = null;
					}
				}
				Pool = left;
			}

			//	Rolls: the saved values of an edited character join them; new rolls otherwise (one row per ability)
			if (Method == AbilityMethod.Roll && hadRolls > 0)
			{
				if (RollsLeft == 0 && rolled.All(v => v is not null) && hadRolls == 6)
				{
					Rolled = Rolled.Concat(rolled.Select(v => v!.Value)).OrderByDescending(v => v).ToList();
				}
				else if (hadRolls != Count)
				{
					Rolled = new();
					Fill(RolledAssigned, Count, null);
					DiceRows = new();
					RollsLeft = Math.Max(RollsLeft, 1);
				}
			}
			SelectedPool = null;
			return true;
		}

		private static void Resize<T>(List<T> list, List<T> extras)
		{
			if (list.Count > 6)
			{
				list.RemoveRange(6, list.Count - 6);
			}
			list.AddRange(extras);
		}

		public sealed class Snapshot
		{
			public AbilityMethod Method { get; set; } = AbilityMethod.StandardArray;
			public List<int?> Assigned { get; set; } = new();
			public List<int> PointBuy { get; set; } = new();
			public List<int> Pool { get; set; } = new();
			public List<int> Rolled { get; set; } = new();
			public List<int?> RolledAssigned { get; set; } = new();
			public int RollsLeft { get; set; } = 3;
			public List<string> ExtraKeys { get; set; } = new();
		}

		public Snapshot ToSnapshot() => new()
		{
			Method = Method,
			Assigned = Assigned.ToList(),
			PointBuy = PointBuy.ToList(),
			Pool = Pool.ToList(),
			Rolled = Rolled.ToList(),
			RolledAssigned = RolledAssigned.ToList(),
			RollsLeft = RollsLeft,
			ExtraKeys = Extras.Select(e => e.Key ?? string.Empty).ToList()
		};

		//	A draft: the added abilities come back as keys, SyncExtras puts their definitions back
		public void Restore(Snapshot snapshot)
		{
			Extras = snapshot.ExtraKeys.Take(RuleEffectRules.MaxExtraAbilities * 4).Select(k => new RuleEffect { Kind = RuleEffectKind.ExtraAbility, Key = k, Value = 10 }).ToList();
			Reset();
			Method = snapshot.Method;
			for (var i = 0; i < Count; i++)
			{
				Assigned[i] = i < snapshot.Assigned.Count ? snapshot.Assigned[i] : null;
				PointBuy[i] = i < snapshot.PointBuy.Count ? Math.Clamp(snapshot.PointBuy[i], 8, 15) : 8;
				RolledAssigned[i] = i < snapshot.RolledAssigned.Count ? snapshot.RolledAssigned[i] : null;
			}
			Pool = snapshot.Pool.ToList();
			Rolled = snapshot.Rolled.ToList();
			RollsLeft = Math.Clamp(snapshot.RollsLeft, 0, 3);
		}

		public int? Base(int index) => Method switch
		{
			AbilityMethod.PointBuy => PointBuy[index],
			AbilityMethod.Roll => RolledAssigned[index],
			_ => Assigned[index]
		};

		//	Writes the scores into the build when all of them are set (otherwise none)
		public void WriteTo(CharacterBuild build)
		{
			build.AbilityMethod = Method;
			var values = Enumerable.Range(0, Count).Select(Base).ToList();
			var complete = values.All(v => v is not null);
			build.BaseScores = complete ? values.Take(6).Select(v => v!.Value).ToList() : new List<int>();
			build.ExtraScores = complete
				? Extras.Select((e, i) => (e.Key, Value: values[6 + i]!.Value)).Where(x => x.Key is not null).ToDictionary(x => x.Key!, x => x.Value)
				: new Dictionary<string, int>();
		}
	}
}
