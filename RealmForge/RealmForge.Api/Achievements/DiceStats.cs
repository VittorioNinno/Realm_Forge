using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.DTOs;
using AchievementRules = RealmForge.Shared.Dice.Achievements;

namespace RealmForge.Api.Achievements
{
	///	<summary>
	///	How a roll at the table counts for the achievements of the person who made it: one more roll, the natural 20s and
	///	1s of its d20s (the kept ones), and the moments made of a sequence (a 1 then a 20, two 20s in a sitting, a 20 after
	///	midnight on the person's own clock).
	///	</summary>
	public static class DiceStatsRules
	{
		private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		///	<summary>The clock of "after midnight" when the person's own is unknown.</summary>
		public const string DefaultTimeZone = "Europe/Rome";

		public static TimeZoneInfo Zone(string? id)
		{
			if (id is { Length: > 0 } && TimeZoneInfo.TryFindSystemTimeZoneById(id, out var zone))
			{
				return zone;
			}
			return TimeZoneInfo.TryFindSystemTimeZoneById(DefaultTimeZone, out var rome) ? rome : TimeZoneInfo.Utc;
		}

		public static List<RollDieDto> Dice(string? json)
		{
			try
			{
				return string.IsNullOrEmpty(json) ? new() : JsonSerializer.Deserialize<List<RollDieDto>>(json, Json) ?? new();
			}
			catch (JsonException)
			{
				return new();
			}
		}

		///	<summary>
		///	Counts a roll. With <paramref name="moments"/> false (the rolls made before the counting began) only the totals
		///	move: the moments of a sequence are met only from now on.
		///	</summary>
		public static void Apply(UserDiceStats stats, Guid campaignId, DateTimeOffset at, IEnumerable<RollDieDto> dice, bool moments = true)
		{
			stats.Rolls++;
			foreach (var value in AchievementRules.NaturalD20s(dice.Select(d => (d.Sides, d.Value, d.Dropped))))
			{
				if (value == 20)
				{
					stats.NaturalTwenties++;
					if (moments)
					{
						if (stats.LastD20 == 1)
						{
							stats.OneThenTwenty = true;
						}
						if (stats.LastTwentyCampaignId == campaignId && stats.LastTwentyAt is { } last && at >= last && at - last <= AchievementRules.Sitting)
						{
							stats.TwoTwentiesInASitting = true;
						}
						if (AchievementRules.AfterMidnight(at, Zone(stats.TimeZone)))
						{
							stats.TwentyAfterMidnight = true;
						}
					}
					stats.LastTwentyCampaignId = campaignId;
					stats.LastTwentyAt = at;
				}
				else if (value == 1)
				{
					stats.NaturalOnes++;
				}
				stats.LastD20 = value;
			}
		}

		///	<summary>
		///	The counts of a person who has none yet, from the rolls the dice logs still keep (each campaign keeps only its
		///	latest rolls, so this is a start, not the whole story).
		///	</summary>
		public static async Task<UserDiceStats> StartAsync(RealmForgeDbContext context, string userId, CancellationToken cancel = default)
		{
			var stats = new UserDiceStats { UserId = userId };
			var rolls = await context.CampaignRolls.AsNoTracking().Where(r => r.UserId == userId)
				.OrderBy(r => r.CreatedAt).Select(r => new { r.CampaignId, r.CreatedAt, r.Dice }).ToListAsync(cancel);
			foreach (var roll in rolls)
			{
				Apply(stats, roll.CampaignId, roll.CreatedAt, Dice(roll.Dice), moments: false);
			}
			return stats;
		}

		///	<summary>The counts of a person, tracked (started from the dice logs the first time).</summary>
		public static async Task<UserDiceStats> OfAsync(RealmForgeDbContext context, string userId, CancellationToken cancel = default)
		{
			var stats = context.UserDiceStats.Local.FirstOrDefault(s => s.UserId == userId)
				?? await context.UserDiceStats.FirstOrDefaultAsync(s => s.UserId == userId, cancel);
			if (stats is null)
			{
				stats = await StartAsync(context, userId, cancel);
				context.UserDiceStats.Add(stats);
			}
			return stats;
		}
	}

	///	<summary>
	///	Counts every roll saved in a dice log for the person who made it, in the same save (wherever the roll comes from:
	///	the campaign page, a sheet, an attack or a save on the map).
	///	</summary>
	public sealed class DiceStatsInterceptor : SaveChangesInterceptor
	{
		private static async Task CountAsync(DbContext? db, CancellationToken cancel)
		{
			if (db is not RealmForgeDbContext context)
			{
				return;
			}
			var rolls = context.ChangeTracker.Entries<CampaignRoll>()
				.Where(e => e.State == EntityState.Added && !string.IsNullOrEmpty(e.Entity.UserId))
				.Select(e => e.Entity).ToList();
			if (rolls.Count == 0)
			{
				return;
			}
			foreach (var mine in rolls.GroupBy(r => r.UserId))
			{
				var stats = await DiceStatsRules.OfAsync(context, mine.Key, cancel);
				foreach (var roll in mine.OrderBy(r => r.CreatedAt))
				{
					DiceStatsRules.Apply(stats, roll.CampaignId, roll.CreatedAt, DiceStatsRules.Dice(roll.Dice));
				}
				stats.UpdatedAt = DateTimeOffset.UtcNow;
			}
			context.ChangeTracker.DetectChanges();
		}

		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
		{
			CountAsync(eventData.Context, default).GetAwaiter().GetResult();
			return result;
		}

		public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
		{
			await CountAsync(eventData.Context, cancellationToken);
			return result;
		}
	}
}
