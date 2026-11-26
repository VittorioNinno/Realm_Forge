using RealmForge.Shared.Dice;

namespace RealmForge.Tests;

public class DiceSkinsTests
{
	[Fact]
	public void ACodeIsTheSameInAnyCaseWithSpacesOrDashes()
	{
		Assert.Equal("CODICEDIPROVA42", DiceSkins.Normalize(" codice-di prova_42 "));
		Assert.Equal(DiceSkins.Hash("CODICE-DI-PROVA-42"), DiceSkins.Hash("codice di prova 42"));
		Assert.Equal(64, DiceSkins.Hash("x").Length);
	}

	[Fact]
	public void TheLooksAreKnown()
	{
		Assert.True(DiceSkins.IsKnown(DiceSkins.Resin));
		Assert.All(DiceSkins.Unlockable, s => Assert.True(DiceSkins.IsKnown(s)));
		Assert.Equal(12, DiceSkins.Unlockable.Distinct().Count());
		//	Three special and nine secret: the rows of three in the settings are always full
		Assert.Equal(3, DiceSkins.Special.Count);
		Assert.Equal(9, DiceSkins.Secret.Count);
		Assert.True(DiceSkins.IsSecret(DiceSkins.Tide));
		Assert.False(DiceSkins.IsSecret(DiceSkins.Dawn));
		Assert.True(DiceSkins.IsSecret(DiceSkins.Arcane));
		Assert.False(DiceSkins.IsSecret(DiceSkins.Ember));
		Assert.False(DiceSkins.IsKnown("gold"));
		Assert.False(DiceSkins.IsKnown(null));
	}
}
