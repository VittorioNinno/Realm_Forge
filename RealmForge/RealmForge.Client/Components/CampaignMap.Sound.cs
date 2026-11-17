using Microsoft.JSInterop;
using RealmForge.Shared.DTOs;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	The soundboard at the table: every screen plays the track the master started, in time with its start, and each
	///	effect once. Browsers play sound only after a gesture on the page: until then a button offers to turn it on.
	///	</summary>
	public partial class CampaignMap
	{
		private MapSoundDto? tableSound;
		private bool soundUnlocked;
		private bool soundMuted;
		private string? cueHeard;
		private bool soundStarted;

		private bool SoundWaiting => Table && !soundUnlocked && tableSound?.TrackUrl is not null;

		private async Task ApplySoundAsync(MapSoundDto? sound)
		{
			var first = !soundStarted;
			soundStarted = true;
			tableSound = sound;
			if (!Table)
			{
				return;
			}
			try
			{
				var offset = sound?.TrackAt is { } at ? Math.Max(0, (DateTimeOffset.UtcNow - at).TotalSeconds) : 0;
				await JS.InvokeVoidAsync("rfSound.track", sound?.TrackId is { } id ? $"{id}|{sound.TrackAt:O}" : null, sound?.TrackUrl, sound?.TrackVolume ?? 0, offset);

				//	An effect plays once, and not when the table opens long after it
				var cue = sound?.CueAt is { } cueAt ? $"{sound.CueId}|{cueAt:O}" : null;
				if (cue is not null && cue != cueHeard)
				{
					cueHeard = cue;
					if (!first || DateTimeOffset.UtcNow - sound!.CueAt!.Value < TimeSpan.FromSeconds(15))
					{
						await JS.InvokeVoidAsync("rfSound.cue", sound!.CueUrl, sound.CueVolume);
					}
				}
			}
			catch (JSException)
			{
			}
		}

		private async Task UnlockSoundAsync()
		{
			try
			{
				soundUnlocked = await JS.InvokeAsync<bool>("rfSound.unlock");
			}
			catch (JSException)
			{
			}
		}

		private async Task ToggleMuteAsync()
		{
			soundMuted = !soundMuted;
			try
			{
				await JS.InvokeVoidAsync("rfSound.setVolume", soundMuted ? 0 : 1);
			}
			catch (JSException)
			{
			}
		}

		private async Task StopSoundAsync()
		{
			try
			{
				await JS.InvokeVoidAsync("rfSound.stopAll");
			}
			catch (Exception)
			{
				//	The page is going away
			}
		}
	}
}
