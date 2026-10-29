using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Bringing the character to one of my campaigns (the server checks the campaign's requirements and lists what does
	///	not fit), and placing the portrait in its square frame by dragging it.
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

		// ===== Portrait framing =====

		//	Size of the frame in CSS pixels: a drag across it moves the picture by 100%
		private const double PortraitFrame = 140;

		private bool panning;
		private double panStartX;
		private double panStartY;
		private int panFromX;
		private int panFromY;

		private int PortraitX => Sheet.PortraitX ?? 50;
		private int PortraitY => Sheet.PortraitY ?? 50;

		private string? PortraitStyle => Sheet.Portrait is { } src
			? $"background-image: url('{src}'); background-position: {PortraitX}% {PortraitY}%;"
			: null;

		private void StartPan(PointerEventArgs e)
		{
			if (ReadOnly || Sheet.Portrait is null)
			{
				return;
			}
			panning = true;
			panStartX = e.ClientX;
			panStartY = e.ClientY;
			panFromX = PortraitX;
			panFromY = PortraitY;
		}

		//	Dragging the picture right shows more of its left side: the position goes down
		private void Pan(PointerEventArgs e)
		{
			if (!panning)
			{
				return;
			}
			Sheet.PortraitX = Math.Clamp((int)Math.Round(panFromX - (e.ClientX - panStartX) / PortraitFrame * 100), 0, 100);
			Sheet.PortraitY = Math.Clamp((int)Math.Round(panFromY - (e.ClientY - panStartY) / PortraitFrame * 100), 0, 100);
		}

		private void EndPan()
		{
			if (!panning)
			{
				return;
			}
			panning = false;
			Changed();
		}

		//	Keyboard: the arrows move the picture a little
		private void PanWithKeys(KeyboardEventArgs e)
		{
			if (ReadOnly || Sheet.Portrait is null)
			{
				return;
			}
			var (dx, dy) = e.Key switch
			{
				"ArrowLeft" => (-5, 0),
				"ArrowRight" => (5, 0),
				"ArrowUp" => (0, -5),
				"ArrowDown" => (0, 5),
				_ => (0, 0)
			};
			if (dx == 0 && dy == 0)
			{
				return;
			}
			Sheet.PortraitX = Math.Clamp(PortraitX + dx, 0, 100);
			Sheet.PortraitY = Math.Clamp(PortraitY + dy, 0, 100);
			Changed();
		}
	}
}
