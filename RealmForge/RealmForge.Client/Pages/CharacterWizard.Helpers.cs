using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
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
