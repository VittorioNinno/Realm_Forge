using RealmForge.Shared.Dice;

namespace RealmForge.Tests;

public class DiceSkinsTests
{
	[Fact]
	public void TheLooksAreKnown()
	{
		Assert.True(DiceSkins.IsKnown(DiceSkins.Resin));
		Assert.All(DiceSkins.Unlockable, s => Assert.True(DiceSkins.IsKnown(s)));
		Assert.Equal(15, DiceSkins.Unlockable.Distinct().Count());
		//	Three special and twelve secret: the rows of three in the settings are always full
		Assert.Equal(3, DiceSkins.Special.Count);
		Assert.Equal(12, DiceSkins.Secret.Count);
		Assert.True(DiceSkins.IsSecret(DiceSkins.Sands));
		Assert.True(DiceSkins.IsSecret(DiceSkins.Tide));
		Assert.False(DiceSkins.IsSecret(DiceSkins.Dawn));
		Assert.True(DiceSkins.IsSecret(DiceSkins.Arcane));
		Assert.False(DiceSkins.IsSecret(DiceSkins.Ember));
		Assert.False(DiceSkins.IsKnown("gold"));
		Assert.False(DiceSkins.IsKnown(null));
	}
}
