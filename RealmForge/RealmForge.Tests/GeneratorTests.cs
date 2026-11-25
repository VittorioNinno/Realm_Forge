using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

public class ShopGeneratorTests
{
	[Fact]
	public void TheSameSeedMakesTheSameShop()
	{
		var a = ShopGenerator.For(ShopKind.Tavern, new Random(7));
		var b = ShopGenerator.For(ShopKind.Tavern, new Random(7));
		Assert.Equal(a.NameIt, b.NameIt);
		Assert.Equal(a.DescriptionEn, b.DescriptionEn);
		Assert.Equal(a.PricePercent, b.PricePercent);
	}

	[Theory]
	[InlineData(ShopKind.General)]
	[InlineData(ShopKind.Blacksmith)]
	[InlineData(ShopKind.Armorer)]
	[InlineData(ShopKind.Alchemist)]
	[InlineData(ShopKind.Arcane)]
	[InlineData(ShopKind.Tavern)]
	public void EveryKindHasANameAndFairPrices(ShopKind kind)
	{
		for (var seed = 0; seed < 50; seed++)
		{
			var plan = ShopGenerator.For(kind, new Random(seed));
			Assert.False(string.IsNullOrWhiteSpace(plan.NameIt));
			Assert.False(string.IsNullOrWhiteSpace(plan.NameEn));
			Assert.InRange(plan.PricePercent, 90, 120);
			Assert.True(plan.Stock.Mundane + plan.Stock.Magic + plan.Extras.Count > 0);
		}
	}

	[Fact]
	public void ATavernHasAMenuAndARumour()
	{
		var plan = ShopGenerator.For(ShopKind.Tavern, new Random(3));
		Assert.Equal(6, plan.Extras.Count);
		Assert.Contains("Si mormora", plan.DescriptionIt);
		Assert.Contains("Word is", plan.DescriptionEn);
	}
}
