using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Bringing the character to one of my campaigns (the server checks the campaign's requirements and lists what does
	///	not fit) or taking it out, and the portrait: a new picture opens the crop, which saves the square chosen.
	///	</summary>
	public partial class CharacterSheet
	{
		[Inject] private CampaignDataService Campaigns { get; set; } = default!;

		private bool campaignOpen;
		private List<CampaignSummaryDto>? myCampaigns;
		private Guid? campaignBusy;
		private CampaignCharacterCheckDto? campaignCheck;
		private Guid? campaignCheckFor;
		private string? campaignNote;

		private bool InCampaign(Guid campaignId) => character?.Campaigns?.Contains(campaignId) == true;

		private async Task OpenCampaignsAsync()
		{
			campaignOpen = true;
			campaignCheck = null;
			campaignNote = null;
			myCampaigns = await Campaigns.GetCampaignsAsync() ?? new List<CampaignSummaryDto>();
		}

		private async Task BringToCampaignAsync(CampaignSummaryDto campaign)
		{
			if (character is null)
			{
				return;
			}
			campaignBusy = campaign.Id;
			campaignCheck = null;
			campaignNote = null;
			var (result, check) = await Campaigns.AddCharacterAsync(campaign.Id, character.Id, Lang);
			campaignBusy = null;
			if (result.Ok)
			{
				character = character with { Campaigns = (character.Campaigns ?? new List<Guid>()).Append(campaign.Id).Distinct().ToList() };
				campaignNote = UiText.SheetCampaignJoined(campaign.Name, Lang);
				return;
			}
			campaignCheck = check;
			campaignCheckFor = campaign.Id;
			if (check is null)
			{
				campaignNote = UiText.CampaignActionFailed(result.Status, Lang);
			}
		}

		//	Taking the character out of a campaign from its sheet (the owner can always leave a table)
		private async Task LeaveCampaignAsync(CampaignSummaryDto campaign)
		{
			if (character is null)
			{
				return;
			}
			campaignBusy = campaign.Id;
			campaignCheck = null;
			campaignNote = null;
			var result = await Campaigns.RemoveCharacterAsync(campaign.Id, character.Id);
			campaignBusy = null;
			if (result.Ok)
			{
				character = character with { Campaigns = (character.Campaigns ?? new List<Guid>()).Where(id => id != campaign.Id).ToList() };
				campaignNote = UiText.SheetCampaignLeft(campaign.Name, Lang);
				return;
			}
			campaignNote = UiText.CampaignActionFailed(result.Status, Lang);
		}

		// ===== Portrait: choosing a picture opens the crop, which saves a square image =====

		//	Side of the crop frame in CSS pixels and of the saved picture in pixels
		private const double CropFrame = 256;
		private const int PortraitSize = 320;

		private string? cropSource;
		private double cropWidth;
		private double cropHeight;
		private int cropX = 50;
		private int cropY = 50;
		private int cropZoom = 100;
		private bool cropDragging;
		private double cropStartX;
		private double cropStartY;
		private int cropFromX;
		private int cropFromY;

		//	Old portraits saved before the crop keep the position chosen by dragging them in the frame
		private string? PortraitStyle => Sheet.Portrait is { } src
			? $"background-image: url('{src}'); background-position: {Sheet.PortraitX ?? 50}% {Sheet.PortraitY ?? 50}%;"
			: null;

		//	The picture covers the frame at zoom 100% (its short side as long as the frame), and grows from there
		private double CropScale => cropWidth <= 0 || cropHeight <= 0 ? 1 : CropFrame / Math.Min(cropWidth, cropHeight) * cropZoom / 100.0;
		private double CropShownWidth => cropWidth * CropScale;
		private double CropShownHeight => cropHeight * CropScale;

		private string CropStyle => FormattableString.Invariant(
			$"background-image: url('{cropSource}'); background-size: {CropShownWidth:0.##}px {CropShownHeight:0.##}px; background-position: {cropX}% {cropY}%;");

		private async Task UploadPortraitAsync(InputFileChangeEventArgs e)
		{
			portraitError = null;
			try
			{
				//	Read at a size good enough to crop, then shown in the crop dialog
				var image = await e.File.RequestImageFileAsync("image/jpeg", 1024, 1024);
				await using var stream = image.OpenReadStream(maxAllowedSize: 5_000_000);
				using var memory = new MemoryStream();
				await stream.CopyToAsync(memory);
				var url = $"data:image/jpeg;base64,{Convert.ToBase64String(memory.ToArray())}";
				var size = await JS.InvokeAsync<double[]>("rfImageSize", url);
				if (size.Length != 2 || size[0] <= 0 || size[1] <= 0)
				{
					portraitError = UiText.PortraitTooLarge(Lang);
					return;
				}
				cropSource = url;
				cropWidth = size[0];
				cropHeight = size[1];
				cropX = 50;
				cropY = 50;
				cropZoom = 100;
			}
			catch (Exception)
			{
				portraitError = UiText.PortraitTooLarge(Lang);
			}
		}

		private void CloseCrop()
		{
			cropSource = null;
			cropDragging = false;
		}

		private async Task SaveCropAsync()
		{
			if (cropSource is null)
			{
				return;
			}
			try
			{
				var cropped = await JS.InvokeAsync<string>("rfCropImage", cropSource, cropX, cropY, cropZoom / 100.0, PortraitSize);
				if (string.IsNullOrEmpty(cropped) || cropped.Length > 400_000)
				{
					portraitError = UiText.PortraitTooLarge(Lang);
				}
				else
				{
					Sheet.Portrait = cropped;
					Sheet.PortraitX = null;
					Sheet.PortraitY = null;
					Changed();
				}
			}
			catch (Exception)
			{
				portraitError = UiText.PortraitTooLarge(Lang);
			}
			CloseCrop();
		}

		private void RemovePortrait()
		{
			Sheet.Portrait = null;
			Sheet.PortraitX = null;
			Sheet.PortraitY = null;
			Changed();
		}

		private void SetCropZoom(ChangeEventArgs e)
		{
			if (int.TryParse(e.Value?.ToString(), out var zoom))
			{
				cropZoom = Math.Clamp(zoom, 100, 300);
			}
		}

		private void StartCropDrag(PointerEventArgs e)
		{
			cropDragging = true;
			cropStartX = e.ClientX;
			cropStartY = e.ClientY;
			cropFromX = cropX;
			cropFromY = cropY;
		}

		//	Dragging the picture right shows more of its left side: the position goes down. A side that fits the frame
		//	has nothing to move
		private void CropDrag(PointerEventArgs e)
		{
			if (!cropDragging)
			{
				return;
			}
			var spareX = CropShownWidth - CropFrame;
			var spareY = CropShownHeight - CropFrame;
			if (spareX > 0.5)
			{
				cropX = Math.Clamp((int)Math.Round(cropFromX - (e.ClientX - cropStartX) / spareX * 100), 0, 100);
			}
			if (spareY > 0.5)
			{
				cropY = Math.Clamp((int)Math.Round(cropFromY - (e.ClientY - cropStartY) / spareY * 100), 0, 100);
			}
		}

		private void EndCropDrag() => cropDragging = false;

		//	Keyboard: the arrows move the picture a little, + and - zoom
		private void CropWithKeys(KeyboardEventArgs e)
		{
			switch (e.Key)
			{
				case "ArrowLeft": cropX = Math.Clamp(cropX - 5, 0, 100); break;
				case "ArrowRight": cropX = Math.Clamp(cropX + 5, 0, 100); break;
				case "ArrowUp": cropY = Math.Clamp(cropY - 5, 0, 100); break;
				case "ArrowDown": cropY = Math.Clamp(cropY + 5, 0, 100); break;
				case "+": cropZoom = Math.Clamp(cropZoom + 10, 100, 300); break;
				case "-": cropZoom = Math.Clamp(cropZoom - 10, 100, 300); break;
			}
		}
	}
}
