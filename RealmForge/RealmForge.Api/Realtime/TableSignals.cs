using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RealmForge.Domain.Entities;

namespace RealmForge.Api.Realtime
{
	///	<summary>
	///	Wakes the tables waiting for news (the long poll of the map state) the moment something of a table is saved, instead
	///	of letting them find it at their next look at the database: every waiter checks again at once, the others go on
	///	waiting. With more than one server the periodic look still finds what another server saved.
	///	</summary>
	public sealed class TableSignals
	{
		private TaskCompletionSource pulse = new(TaskCreationOptions.RunContinuationsAsynchronously);

		///	<summary>Something of a table was saved: everyone waiting looks again.</summary>
		public void Pulse() => Interlocked.Exchange(ref pulse, new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously)).TrySetResult();

		///	<summary>Waits for the next save of a table or the time given, whichever comes first.</summary>
		public async Task WaitAsync(TimeSpan most, CancellationToken aborted)
		{
			var next = Volatile.Read(ref pulse).Task;
			await Task.WhenAny(next, Task.Delay(most, aborted));
			aborted.ThrowIfCancellationRequested();
		}
	}

	///	<summary>
	///	Pulses <see cref="TableSignals"/> after a save that changed a map, a token or an encounter.
	///	</summary>
	public sealed class TableChangeInterceptor(TableSignals signals) : SaveChangesInterceptor
	{
		private static readonly ConditionalWeakTable<DbContext, object> Touched = new();

		private static void Note(DbContext? context)
		{
			if (context is not null && context.ChangeTracker.Entries().Any(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted
				&& e.Entity is CampaignMap or CampaignToken or CampaignEncounter or CampaignRoll))
			{
				Touched.AddOrUpdate(context, true);
			}
		}

		private void Send(DbContext? context)
		{
			if (context is not null && Touched.Remove(context))
			{
				signals.Pulse();
			}
		}

		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
		{
			Note(eventData.Context);
			return result;
		}

		public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
		{
			Note(eventData.Context);
			return ValueTask.FromResult(result);
		}

		public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
		{
			Send(eventData.Context);
			return result;
		}

		public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
		{
			Send(eventData.Context);
			return ValueTask.FromResult(result);
		}
	}
}
