using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Text;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Helpers the wizard steps use: list toggles, class levels, the starting equipment preview, names.
	///	</summary>
	public partial class CharacterWizard
	{
		//	Levels the character had when the wizard opened (level up: they stay)
		public int SavedLevels { get; private set; }

		public List<InventoryItem> PreviewInventory { get; private set; } = new();
		public CoinPurse? PreviewCoins { get; private set; }

		public GlossaryLinker? Terms => Glossary.Linker(Lang, Ruleset);

		///	<summary>
		///	Adds or removes a value of a choice list, up to a maximum, and recomputes.
		///	</summary>
		public void Toggle<T>(List<T> list, T value, int maximum)
		{
			if (!list.Remove(value) && list.Count < maximum)
			{
				list.Add(value);
			}
			Update();
		}

		public int ClassLevelOf(Guid classId) => Build.Levels.Count(l => l.ClassId == classId);

		//	"Mago 3 / Guerriero 2"
		public string ClassLine => string.Join(" / ", Build.Levels
			.GroupBy(l => l.ClassId)
			.Select(g => $"{Class(g.Key)?.Name} {g.Count()}"));

		///	<summary>
		///	Where a skill the character already has comes from (background, species, a class, a feat).
		///	</summary>
		//	A step the player has already reached: what it grants counts as known (a default background preselected
		//	at the start does not hide class skills before the player even sees it)
		public bool Reached(WizardStep step)
		{
			var index = Steps.IndexOf(step);
			return index < 0 || index <= furthestIndex;
		}

		private IReadOnlyList<Skill> SpeciesFixedSkills => CharacterRules.SpeciesSkills(Ruleset, Species, Subspecies).Fixed;

		///	<summary>
		///	Skills the character already has from the steps reached so far: they cannot be picked twice.
		///	</summary>
		public IReadOnlyCollection<Skill> KnownSkills
		{
			get
			{
				var known = new HashSet<Skill>();
				if (Reached(WizardStep.Background) && Background is not null)
				{
					known.UnionWith(Background.Skills);
				}
				if (Reached(WizardStep.Species))
				{
					known.UnionWith(SpeciesFixedSkills);
					known.UnionWith(Build.SpeciesSkills);
				}
				foreach (var entry in Build.Classes)
				{
					known.UnionWith(entry.Skills);
				}
				foreach (var feat in Computed.Feats)
				{
					known.UnionWith(feat.Choice.Skills);
				}
				known.UnionWith(Input.Sheet.ExtraSkills);
				if (Reached(WizardStep.Background) && Reached(WizardStep.Species))
				{
					known.UnionWith(Computed.SkillProficiencies);
				}
				return known;
			}
		}

		///	<summary>
		///	A background or species reached after the class may grant a skill already picked for a class: the pick is
		///	given back so the player chooses another one (the step shows where).
		///	</summary>
		private void ResolveSkillOverlaps()
		{
			//	Saved characters keep their choices: only a character being created is adjusted
			if (Mode != WizardMode.Create)
			{
				return;
			}
			var granted = new HashSet<Skill>();
			if (Reached(WizardStep.Background) && Background is not null)
			{
				granted.UnionWith(Background.Skills);
			}
			if (Reached(WizardStep.Species))
			{
				granted.UnionWith(SpeciesFixedSkills);
			}
			if (granted.Count == 0)
			{
				return;
			}
			foreach (var entry in Build.Classes)
			{
				entry.Skills.RemoveAll(granted.Contains);
			}
			if (Reached(WizardStep.Background) && Background is not null)
			{
				Build.SpeciesSkills.RemoveAll(s => Background.Skills.Contains(s));
			}
		}

		//	The starting class lost a skill to a later step: shown again in that step
		public bool ClassSkillsShort => StartingClass is { } cls && StartingClassBuild is { } entry
			&& entry.Skills.Count < cls.SkillChoiceCount && Steps.IndexOf(WizardStep.Class) < stepIndex;

		public string SkillSource(Skill skill)
		{
			if (Reached(WizardStep.Background) && Background?.Skills.Contains(skill) == true)
			{
				return Background.Name;
			}
			if (SpeciesFixedSkills.Contains(skill) || Build.SpeciesSkills.Contains(skill))
			{
				return Subspecies?.Name ?? Species?.Name ?? string.Empty;
			}
			foreach (var entry in Build.Classes.Where(c => c.Skills.Contains(skill)))
			{
				return Class(entry.ClassId)?.Name ?? string.Empty;
			}
			foreach (var feat in Computed.Feats.Where(f => f.Choice.Skills.Contains(skill)))
			{
				return feat.Feat.Name;
			}
			return UiText.SourceSheet(Lang);
		}

		//	Why a skill cannot take Expertise: not proficient, or Expertise already
		public string ExpertiseBlock(Skill skill) => Computed.SkillProficiencies.Contains(skill)
			? UiText.AlreadyExpertise(Lang)
			: UiText.NotProficient(Lang);

		public string ItemName(InventoryItem item) =>
			item.EquipmentId is { } id && Context?.Items.FirstOrDefault(i => i.Id == id) is { } entry ? entry.Name : item.Name ?? string.Empty;

		///	<summary>
		///	New character: the chosen starting equipment as it will be in the inventory, so the wizard shows the same
		///	Armor Class and attacks as the saved sheet.
		///	</summary>
		private void RefreshPreview()
		{
			if (Mode != WizardMode.Create || Context is null)
			{
				return;
			}

			var (items, coins) = StartingEquipment.Build(Build, Context, Input.BackgroundId);
			PreviewInventory = items;
			PreviewCoins = coins;
			Input.Sheet.Inventory = items;
			Input.Sheet.Coins = coins;
		}

		public string AreaName(string area) => Steps.FirstOrDefault(s => AreaOf(s) == area) is var step && AreaOf(step) == area
			? UiText.WizardStepName(step, Ruleset, Lang)
			: area;

		public void JumpToArea(string area)
		{
			var index = Steps.FindIndex(s => AreaOf(s) == area);
			if (index >= 0)
			{
				stepProblems.Clear();
				stepIndex = index;
				StateHasChanged();
			}
		}

		private static string? AreaOf(WizardStep step) => step switch
		{
			WizardStep.Identity => IssueAreas.Identity,
			WizardStep.Species => IssueAreas.Species,
			WizardStep.Class => IssueAreas.Class,
			WizardStep.Background => IssueAreas.Background,
			WizardStep.Abilities => IssueAreas.Abilities,
			WizardStep.Progression => IssueAreas.Progression,
			WizardStep.Languages => IssueAreas.Languages,
			WizardStep.Equipment => IssueAreas.Equipment,
			WizardStep.Spells => IssueAreas.Spells,
			_ => null
		};
	}
}
