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
		Assert.All(DiceSkins.Special, s => Assert.True(DiceSkins.IsKnown(s)));
		Assert.False(DiceSkins.IsKnown("gold"));
		Assert.False(DiceSkins.IsKnown(null));
	}
}
