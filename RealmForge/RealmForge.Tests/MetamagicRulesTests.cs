using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

public class MetamagicRulesTests
{
	private static CastingOptions Sorcerer(bool is2014) =>
		new("sorcerer-points", CastingOptions.All.Select(o => o.Key).ToList(), 3, false, 0, false, 0, 0, is2014);

	[Fact]
	public void TheCostsFollowTheEdition()
	{
		var old = Sorcerer(true);
		var now = Sorcerer(false);
		Assert.Equal(3, old.Cost("heightened", 3));
		Assert.Equal(2, now.Cost("heightened", 3));
		Assert.Equal(1, old.Cost("twinned", 0));
		Assert.Equal(4, old.Cost("twinned", 4));
		Assert.Equal(1, now.Cost("twinned", 4));
		Assert.Equal(2, now.Cost("quickened", 1));
	}

	[Fact]
	public void OneOptionASpellSaveEmpoweredAndSeeking()
	{
		var old = Sorcerer(true);
		var now = Sorcerer(false);
		Assert.True(now.TooMany(new[] { "quickened", "distant" }));
		Assert.False(now.TooMany(new[] { "quickened", "empowered", "seeking" }));
		Assert.False(old.TooMany(new[] { "quickened", "empowered" }));
		Assert.True(old.TooMany(new[] { "quickened", "seeking" }));
	}
}
