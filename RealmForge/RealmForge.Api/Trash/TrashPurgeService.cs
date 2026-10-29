using RealmForge.Infrastructure.Persistence;
using RealmForge.Infrastructure.Persistence.Trash;

namespace RealmForge.Api.Trash
{
	///	<summary>
	///	Once an hour, deletes for good what has been in the bin longer than the retention. The first run waits a few
	///	minutes, so that it never races the migrations applied at startup.
	///	</summary>
	public sealed class TrashPurgeService : BackgroundService
	{
		private readonly IServiceScopeFactory _scopes;
		private readonly ILogger<TrashPurgeService> _logger;

		public TrashPurgeService(IServiceScopeFactory scopes, ILogger<TrashPurgeService> logger)
		{
			_scopes = scopes;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
				using var timer = new PeriodicTimer(TimeSpan.FromHours(1));
				do
				{
					try
					{
						using var scope = _scopes.CreateScope();
						var context = scope.ServiceProvider.GetRequiredService<RealmForgeDbContext>();
						var purged = await TrashBin.PurgeAsync(context, stoppingToken);
						if (purged > 0)
						{
							_logger.LogInformation("Bin: {Count} expired entries deleted for good", purged);
						}
					}
					catch (Exception ex) when (ex is not OperationCanceledException)
					{
						_logger.LogWarning(ex, "Bin: the purge of the expired entries failed");
					}
				}
				while (await timer.WaitForNextTickAsync(stoppingToken));
			}
			catch (OperationCanceledException)
			{
				//	Shutting down
			}
		}
	}
}
