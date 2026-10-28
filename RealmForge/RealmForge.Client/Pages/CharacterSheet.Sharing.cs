namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Sharing a character: the owner picks the accounts that can read the sheet (the game master); they open it
	///	read-only, can refresh it and stop following it.
	///	</summary>
	public partial class CharacterSheet
	{
		private bool shareOpen;

		private bool ReadOnly => character?.ReadOnly == true;

		private async Task ReloadAsync()
		{
			character = await Characters.GetCharacterAsync(Id);
			if (character is not null)
			{
				Recompute();
			}
		}

		private async Task StopFollowingAsync()
		{
			if (character is not null && await Characters.UnshareCharacterAsync(character.Id, "me"))
			{
				Navigation.NavigateTo("characters");
			}
		}
	}
}
