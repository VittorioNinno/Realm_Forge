using RealmForge.Api.Achievements;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Dice;
using RealmForge.Shared.DTOs;
using AchievementRules = RealmForge.Shared.Dice.Achievements;

namespace RealmForge.Tests;

public class AchievementsTests
{
	private static readonly Guid Table = Guid.NewGuid();

	private static List<RollDieDto> D20(int value, int? dropped = null) =>
		dropped is { } other ? [new(20, value), new(20, other, true)] : [new(20, value)];

	[Fact]
	public void EveryDieHasOneAchievement()
	{
		Assert.Equal(15, AchievementRules.All.Count);
		Assert.Equal(AchievementRules.All.Count, AchievementRules.All.Select(a => a.Key).Distinct().Count());
		Assert.Equal(DiceSkins.Unlockable.OrderBy(s => s), AchievementRules.All.Select(a => a.Skin).OrderBy(s => s));
		//	The missions of the special dice are shown; those of the secret dice are hidden until completed
		Assert.All(AchievementRules.All, a => Assert.Equal(DiceSkins.IsSecret(a.Skin), a.Hidden));
		Assert.All(AchievementRules.All, a => Assert.True(a.Target > 0));
		Assert.Equal(DiceSkins.Sands, AchievementRules.Find("sands")?.Skin);
		Assert.Null(AchievementRules.Find("gold"));
	}

	[Fact]
	public void TheKeptD20sCount()
	{
		var stats = new UserDiceStats();
		DiceStatsRules.Apply(stats, Table, DateTimeOffset.UtcNow, D20(20, dropped: 3));
		DiceStatsRules.Apply(stats, Table, DateTimeOffset.UtcNow, D20(4, dropped: 20));
		DiceStatsRules.Apply(stats, Table, DateTimeOffset.UtcNow, [new(6, 1), new(8, 1)]);
		DiceStatsRules.Apply(stats, Table, DateTimeOffset.UtcNow, D20(1));
		Assert.Equal(4, stats.Rolls);
		Assert.Equal(1, stats.NaturalTwenties);
		Assert.Equal(1, stats.NaturalOnes);
		Assert.Equal(1, stats.LastD20);
	}

	[Fact]
	public void AOneThenATwenty()
	{
		var noon = new DateTimeOffset(2026, 6, 1, 12, 0, 0, TimeSpan.Zero);
		var stats = new UserDiceStats();
		DiceStatsRules.Apply(stats, Table, noon, D20(1));
		DiceStatsRules.Apply(stats, Table, noon.AddMinutes(1), [new(8, 5)]);
		DiceStatsRules.Apply(stats, Table, noon.AddMinutes(2), D20(20));
		Assert.True(stats.OneThenTwenty);

		var other = new UserDiceStats();
		DiceStatsRules.Apply(other, Table, noon, D20(1));
		DiceStatsRules.Apply(other, Table, noon.AddMinutes(1), D20(12));
		DiceStatsRules.Apply(other, Table, noon.AddMinutes(2), D20(20));
		Assert.False(other.OneThenTwenty);
	}

	[Fact]
	public void TwoTwentiesInASitting()
	{
		var noon = new DateTimeOffset(2026, 6, 1, 12, 0, 0, TimeSpan.Zero);
		var apart = new UserDiceStats();
		DiceStatsRules.Apply(apart, Table, noon, D20(20));
		DiceStatsRules.Apply(apart, Table, noon.AddHours(7), D20(20));
		DiceStatsRules.Apply(apart, Guid.NewGuid(), noon.AddHours(8), D20(20));
		Assert.False(apart.TwoTwentiesInASitting);

		var close = new UserDiceStats();
		DiceStatsRules.Apply(close, Table, noon, D20(20));
		DiceStatsRules.Apply(close, Table, noon.AddHours(2), D20(20));
		Assert.True(close.TwoTwentiesInASitting);
	}

	[Fact]
	public void ATwentyAfterMidnightOnThePersonsClock()
	{
		//	23:30 UTC in January is 00:30 in Rome; 10:00 UTC is not night anywhere near
		var night = new UserDiceStats { TimeZone = "Europe/Rome" };
		DiceStatsRules.Apply(night, Table, new DateTimeOffset(2026, 1, 10, 23, 30, 0, TimeSpan.Zero), D20(20));
		Assert.True(night.TwentyAfterMidnight);

		var day = new UserDiceStats { TimeZone = "Europe/Rome" };
		DiceStatsRules.Apply(day, Table, new DateTimeOffset(2026, 1, 10, 10, 0, 0, TimeSpan.Zero), D20(20));
		Assert.False(day.TwentyAfterMidnight);

		//	The rolls of before the counting move the totals, never the moments
		var before = new UserDiceStats { TimeZone = "Europe/Rome" };
		DiceStatsRules.Apply(before, Table, new DateTimeOffset(2026, 1, 10, 23, 30, 0, TimeSpan.Zero), D20(20), moments: false);
		Assert.False(before.TwentyAfterMidnight);
		Assert.Equal(1, before.NaturalTwenties);
	}
}
