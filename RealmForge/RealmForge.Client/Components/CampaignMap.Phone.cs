using Microsoft.JSInterop;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The table on a phone, upright or sideways: the card of a token opens as a sheet instead of next to the token, where
	///	it would go off the screen, and the initiative starts folded to leave the map its room. The rest of the phone
	///	layout is CSS only (upright: the tools along the bottom, the side panel as a sheet); the desktop one does not change.
	///	</summary>
	public partial class CampaignMap
	{
		private bool phone;
		private bool initFoldedForPhone;

		private bool PhoneSheet => phone && Table;

		[JSInvokable]
		public Task PhoneChanged(bool narrow)
		{
			if (phone == narrow)
			{
				return Task.CompletedTask;
			}
			phone = narrow;
			//	Folded for the phone, opened again when the screen is wide once more (unless folded by hand meanwhile)
			if (narrow && !initCollapsed)
			{
				initCollapsed = true;
				initFoldedForPhone = true;
			}
			else if (!narrow && initFoldedForPhone)
			{
				initCollapsed = false;
				initFoldedForPhone = false;
			}
			return InvokeAsync(StateHasChanged);
		}

		private async Task WatchPhoneAsync()
		{
			if (self is null)
			{
				return;
			}
			try
			{
				await JS.InvokeVoidAsync("rfMedia.watch", self, "(max-width: 767.98px), (max-height: 500px) and (max-width: 1023.98px) and (orientation: landscape)", "PhoneChanged");
			}
			catch (JSException)
			{
			}
		}

		private async Task UnwatchPhoneAsync()
		{
			if (self is null)
			{
				return;
			}
			try
			{
				await JS.InvokeVoidAsync("rfMedia.unwatch", self);
			}
			catch (Exception)
			{
				//	The page is going away
			}
		}
	}
}
