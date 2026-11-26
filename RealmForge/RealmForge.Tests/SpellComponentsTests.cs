using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

public class SpellComponentsTests
{
	private static SpellComponents.Kit Kit(int hands, bool focus = false, bool pouch = false, bool emblem = false, bool warCaster = false) =>
		new(hands, focus, pouch, emblem, warCaster);

	[Fact]
	public void APriceAndAConsumedComponentAreRead()
	{
		Assert.Equal(300, SpellComponents.Price("diamonds worth 300 gp, which the spell consumes"));
		Assert.Equal(1000, SpellComponents.Price("un diamante del valore di almeno 1.000 mo"));
		Assert.Null(SpellComponents.Price("a pinch of sulfur"));
		Assert.True(SpellComponents.Consumed("diamonds worth 300 gp, which the spell consumes"));
		Assert.True(SpellComponents.Consumed("diamanti per 300 mo, che l'incantesimo consuma"));
		Assert.False(SpellComponents.Consumed("a pearl worth at least 100 gp"));
	}

	[Fact]
	public void SomaticComponentsNeedAHand()
	{
		Assert.Equal(SpellComponents.Problem.NoHand, SpellComponents.Check(true, false, null, false, Kit(0)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(true, false, null, true, Kit(0)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(true, false, null, false, Kit(0, warCaster: true)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(true, true, "bat guano", false, Kit(0, emblem: true)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(true, false, null, false, Kit(1)));
	}

	[Fact]
	public void MaterialComponentsNeedAFocusOrAPouch()
	{
		Assert.Equal(SpellComponents.Problem.NoFocus, SpellComponents.Check(false, true, "a feather", false, Kit(1)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(false, true, "a feather", false, Kit(1, pouch: true)));
		Assert.Equal(SpellComponents.Problem.None, SpellComponents.Check(true, true, "a diamond worth 300 gp", false, Kit(1)));
	}
}
