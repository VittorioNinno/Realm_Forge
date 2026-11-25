namespace RealmForge.Client.Services
{
	///	<summary>
	///	Whether dice are rolling on this page (the tray, the 3D dice, the throw of another player, an attack between its
	///	to-hit and its damage). The effects that tell a result (the strike on a token, its damage) wait for the dice to
	///	rest, so they never give the result away before the dice show it.
	///	</summary>
	public static class DiceActivity
	{
		private static int busy;

		public static bool Rolling => Volatile.Read(ref busy) > 0;

		///	<summary>Dice rolling until the returned handle is disposed.</summary>
		public static IDisposable Hold()
		{
			Interlocked.Increment(ref busy);
			return new Handle();
		}

		///	<summary>
		///	Waits until no dice roll (at most <paramref name="max"/>); a short grace first, for dice about to start (a
		///	roll and its effect can reach the page in either order).
		///	</summary>
		public static async Task WhenIdleAsync(TimeSpan grace, TimeSpan max)
		{
			await Task.Delay(grace);
			var until = DateTime.UtcNow + max;
			while (Rolling && DateTime.UtcNow < until)
			{
				await Task.Delay(80);
			}
		}

		private sealed class Handle : IDisposable
		{
			private int done;

			public void Dispose()
			{
				if (Interlocked.Exchange(ref done, 1) == 0)
				{
					Interlocked.Decrement(ref busy);
				}
			}
		}
	}
}
