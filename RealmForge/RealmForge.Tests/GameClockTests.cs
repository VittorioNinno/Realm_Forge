using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

public class GameClockTests
{
	[Theory]
	[InlineData("8 hours", 480)]
	[InlineData("8 ore", 480)]
	[InlineData("Concentration, up to 1 hour", 60)]
	[InlineData("Concentrazione, fino a 10 minuti", 10)]
	[InlineData("10 days", 14400)]
	[InlineData("24 ore", 1440)]
	[InlineData("Concentration, up to 1 minute", null)]
	[InlineData("1 round", null)]
	[InlineData("Instantaneous", null)]
	[InlineData("Until dispelled", null)]
	[InlineData(null, null)]
	public void Durations_are_read_in_both_languages(string? text, int? minutes) =>
		Assert.Equal(minutes, GameClock.DurationMinutes(text));

	[Fact]
	public void Days_and_times_follow_the_minutes()
	{
		Assert.Equal(1, GameClock.Day(GameClock.Start));
		Assert.Equal(8, GameClock.Hour(GameClock.Start));
		Assert.Equal(3, GameClock.Day(2 * GameClock.MinutesPerDay + 5));
		Assert.Equal(1, GameClock.DaysCrossed(540, 1980));
		Assert.Equal(0, GameClock.DaysCrossed(540, 1400));
	}

	[Fact]
	public void Half_the_ammunition_shot_comes_back()
	{
		var arrows = new InventoryItem { Name = "Frecce", Quantity = 5 };
		var sheet = new CharacterSheetState { Inventory = { arrows } };
		for (var i = 0; i < 5; i++)
		{
			InventoryRules.Shoot(sheet, sheet.Inventory.First(x => x.Name == "Frecce"));
		}
		Assert.Empty(sheet.Inventory);
		Assert.Equal(5, InventoryRules.SpentAmmunitionCount(sheet));
		Assert.Equal(2, InventoryRules.RecoverAmmunition(sheet));
		Assert.Equal(2, sheet.Inventory.Single().Quantity);
		Assert.Empty(sheet.SpentAmmunition);
	}

	[Fact]
	public void Rations_are_eaten_one_a_day()
	{
		var sheet = new CharacterSheetState { Inventory = { new InventoryItem { Name = "Razioni", Quantity = 2 }, new InventoryItem { Name = "Torcia", Quantity = 3 } } };
		Assert.Equal(1, InventoryRules.EatRations(sheet, _ => null, 3));
		Assert.Equal("Torcia", sheet.Inventory.Single().Name);
		Assert.Equal(InventoryRules.Supply.Torches, InventoryRules.SupplyOf(sheet.Inventory[0], null));
	}
}

public class TreasureRulesTests
{
	[Fact]
	public void Coins_are_shared_out_with_the_rest_changed()
	{
		var (each, left) = TreasureRules.Split(new CoinPurse { Gp = 10, Sp = 5, Cp = 2 }, 3);
		//	3 gp and 1 sp each, then 1 gp + 2 sp + 2 cp = 122 cp left over: 40 cp each (4 sp), 2 cp stay
		Assert.Equal(3, each.Gp);
		Assert.Equal(5, each.Sp);
		Assert.Equal(0, each.Cp);
		Assert.Equal(2, left.Cp);
		Assert.Equal(1000 + 50 + 2, InventoryRules.Total(new CoinPurse { Gp = 10, Sp = 5, Cp = 2 }));
		Assert.Equal(InventoryRules.Total(new CoinPurse { Gp = 10, Sp = 5, Cp = 2 }), 3 * InventoryRules.Total(each) + InventoryRules.Total(left));
	}

	[Fact]
	public void One_share_takes_everything()
	{
		var (each, left) = TreasureRules.Split(new CoinPurse { Pp = 1, Ep = 3 }, 1);
		Assert.Equal(1, each.Pp);
		Assert.Equal(3, each.Ep);
		Assert.Equal(0, InventoryRules.Total(left));
	}
}
