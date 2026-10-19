using Microsoft.Extensions.Logging;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Runs every SRD seeder at startup. Each module is isolated: a failure in one is logged
///	and does not prevent the others from running.
///	</summary>
public static class DatabaseSeeder
{
	public static async Task SeedAsync(RealmForgeDbContext context, ILogger logger, CancellationToken cancellationToken = default)
	{
		await RunAsync("species", () => SpeciesSeeder.SeedAsync(context), context, logger);
		await RunAsync("feats", () => FeatSeeder.SeedAsync(context, cancellationToken), context, logger);

		//	After feats: backgrounds reference their Origin feat
		await RunAsync("backgrounds", () => BackgroundSeeder.SeedAsync(context, cancellationToken), context, logger);
		await RunAsync("spells", () => SpellSeeder.SeedAsync(context, cancellationToken), context, logger);
		await RunAsync("classes", () => ClassSeeder.SeedAsync(context, cancellationToken), context, logger);
		await RunAsync("equipment", () => EquipmentSeeder.SeedAsync(context, cancellationToken), context, logger);
	}

	private static async Task RunAsync(string module, Func<Task> seed, RealmForgeDbContext context, ILogger logger)
	{
		try
		{
			await seed();
			logger.LogInformation("SRD seeding completed for {Module}.", module);
		}
		catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
		{
			foreach (var entry in ex.Entries)
			{
				logger.LogError("Concurrency failure on {Entity} ({State}) key={Key}", entry.Metadata.ClrType.Name, entry.State,
					string.Join(",", entry.Properties.Where(p => p.Metadata.IsPrimaryKey()).Select(p => p.CurrentValue)));
			}
			logger.LogError(ex, "SRD seeding failed for {Module}. The other modules will still be seeded.", module);
			context.ChangeTracker.Clear();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "SRD seeding failed for {Module}. The other modules will still be seeded.", module);

			//	Drop pending changes of the failed module so they don't leak into the next one
			context.ChangeTracker.Clear();
		}
	}
}
