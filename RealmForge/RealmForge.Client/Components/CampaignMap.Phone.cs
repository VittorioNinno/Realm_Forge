using Microsoft.JSInterop;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The table on a phone, upright or sideways: the card of a token opens as a sheet instead of next to the token, where
	///	it would go off the screen; the initiative starts folded to a strip and opens as a list; the dice and the log open
	///	in the panel, never as floating cards; the controls of the table wait in a panel of their own, the panels of the
	///	masters behind one button. The rest is CSS (the tools on a rail over the map, the panels as sheets); the desktop
	///	layout does not change.
	///	</summary>
	public partial class CampaignMap
	{
		private bool phone;
		private bool initFoldedForPhone;

		private bool PhoneSheet => phone && Table;

		//	The dice and the log as they were docked before the phone docked them, to put them back on a wide screen
		private (bool Dice, bool Log)? dockedBeforePhone;

		//	The initiative as a column: on a phone when it is open (a list), else as the master chose
		private bool InitColumn => phone ? !initCollapsed : initVertical;

		private void TogglePhoneInit()
		{
			initCollapsed = !initCollapsed;
			initFoldedForPhone = false;
		}

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
			//	The dice and the log in the panel on a phone (not saved: a wide screen gets back the layout chosen there)
			if (narrow)
			{
				dockedBeforePhone ??= (diceDocked, logDocked);
				if (!diceDocked && diceOpen)
				{
					diceOpen = false;
				}
				if (!logDocked && logOpen)
				{
					logOpen = false;
				}
				(diceDocked, logDocked) = (true, true);
			}
			else if (dockedBeforePhone is { } before)
			{
				(diceDocked, logDocked) = (before.Dice, before.Log);
				dockedBeforePhone = null;
				if (panel is "dice" or "log" or "hub" or "table")
				{
					panel = null;
				}
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
