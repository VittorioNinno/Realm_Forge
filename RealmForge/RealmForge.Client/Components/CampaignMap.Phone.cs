using Microsoft.JSInterop;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The table on a phone held sideways (the only way the table works on a phone: upright it asks to turn it): the card
	///	of a token opens on the right side of the screen instead of next to the token, where it would go off the screen.
	///	The rest of the phone layout is CSS only; the desktop one does not change.
	///	</summary>
	public partial class CampaignMap
	{
		private bool phone;

		private bool PhoneSheet => phone && Table;

		[JSInvokable]
		public Task PhoneChanged(bool narrow)
		{
			if (phone == narrow)
			{
				return Task.CompletedTask;
			}
			phone = narrow;
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
				await JS.InvokeVoidAsync("rfMedia.watch", self, "(max-height: 500px) and (max-width: 1023.98px) and (orientation: landscape)", "PhoneChanged");
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
