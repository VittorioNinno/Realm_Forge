using RealmForge.Client.Localization;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	A character in a campaign follows the encounters: while the sheet is open it reads every few seconds the hit
	///	points and the conditions, and shows what a master changed from an encounter (a save made from an older copy
	///	gets the same values back from the server).
	///	</summary>
	public partial class CharacterSheet
	{
		private const int VitalsSeconds = 10;

		private System.Threading.Timer? vitalsTimer;
		private string? vitalsNote;

		private void WatchVitals()
		{
			vitalsTimer?.Dispose();
			vitalsTimer = null;
			if (character is null || ReadOnly || character.Campaigns is not { Count: > 0 })
			{
				return;
			}
			vitalsTimer = new System.Threading.Timer(_ => InvokeAsync(CheckVitalsAsync), null,
				TimeSpan.FromSeconds(VitalsSeconds), TimeSpan.FromSeconds(VitalsSeconds));
		}

		private async Task CheckVitalsAsync()
		{
			//	A change of mine still to be saved: the save answers with the encounter's values when they win
			if (character is null || saveStatus is SaveStatus.Pending or SaveStatus.Saving)
			{
				return;
			}
			var vitals = await Characters.GetVitalsAsync(character.Id);
			if (vitals is not null && vitals.VitalsStamp != Sheet.VitalsStamp)
			{
				ApplyVitals(vitals);
				StateHasChanged();
			}
		}

		private void ApplyVitals(SheetVitalsDto vitals)
		{
			if (character is null)
			{
				return;
			}
			vitals.ApplyTo(Sheet);
			deathNote = null;
			vitalsNote = UiText.SheetVitalsFromEncounter(vitals.UpdatedBy, Lang);
			Recompute();
		}

		private void StopWatchingVitals()
		{
			vitalsTimer?.Dispose();
			vitalsTimer = null;
		}
	}
}
