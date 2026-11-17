using System.Text.Json;
using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;

namespace RealmForge.Client.Pages
{
	///	<summary>The character as a JSON file: a backup, or a way to take it to another RealmForge.</summary>
	public partial class CharacterSheet
	{
		private string? transferError;

		private static readonly JsonSerializerOptions FileJson = new(JsonSerializerDefaults.Web) { WriteIndented = true };

		private async Task DownloadJsonAsync()
		{
			if (character is null)
			{
				return;
			}
			var result = await Transfer.ExportCharacterAsync(character.Id);
			if (result.Value is null)
			{
				transferError = UiText.TransferFailed(Lang);
				return;
			}
			transferError = null;
			var bytes = JsonSerializer.SerializeToUtf8Bytes(result.Value, FileJson);
			await JS.InvokeVoidAsync("rfDownloadFile", SessionLogExport.FileName(character.Name, "realmforge", "json"), "application/json", Convert.ToBase64String(bytes));
		}
	}
}
