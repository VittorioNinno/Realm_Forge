using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Rules;

namespace RealmForge.Tests;

public class DiceNotationTests
{
	[Theory]
	[InlineData("1d20+5", "1d20 + 5")]
	[InlineData("d8", "1d8")]
	[InlineData("2d6 + 1d4 - 1", "2d6 + 1d4 - 1")]
	[InlineData("2D20KH1", "2d20kh1")]
	[InlineData("2d20kl1+3", "2d20kl1 + 3")]
	[InlineData("4d6k3", "4d6kh3")]
	[InlineData("-1d4+2", "-1d4 + 2")]
	public void Valid_expressions_are_normalized(string text, string normalized)
	{
		Assert.True(DiceNotation.TryParse(text, out var parsed));
		Assert.Equal(normalized, parsed.Text);
	}

	[Theory]
	[InlineData("")]
	[InlineData("5")]
	[InlineData("1d1")]
	[InlineData("1d20 5")]
	[InlineData("1d20+")]
	[InlineData("abc")]
	[InlineData("51d6")]
	[InlineData("2d20kh3")]
	[InlineData("2d20kh0")]
	[InlineData("1d1001")]
	[InlineData("1d6+1d6+1d6+1d6+1d6+1d6+1d6+1d6+1d6+1d6+1d6")]
	public void Invalid_expressions_are_refused(string text) => Assert.False(DiceNotation.TryParse(text, out _));

	[Fact]
	public void Advantage_keeps_the_highest_die_and_adds_the_modifier()
	{
		Assert.True(DiceNotation.TryParse("2d20kh1+5", out var parsed));
		var faces = new Queue<int>(new[] { 7, 15 });
		var (dice, total) = DiceNotation.Roll(parsed, _ => faces.Dequeue());
		Assert.Equal(20, total);
		Assert.True(dice[0].Dropped);
		Assert.False(dice[1].Dropped);
	}

	[Fact]
	public void Disadvantage_keeps_the_lowest_die()
	{
		Assert.True(DiceNotation.TryParse("2d20kl1", out var parsed));
		var faces = new Queue<int>(new[] { 7, 15 });
		var (dice, total) = DiceNotation.Roll(parsed, _ => faces.Dequeue());
		Assert.Equal(7, total);
		Assert.False(dice[0].Dropped);
		Assert.True(dice[1].Dropped);
	}

	[Fact]
	public void Groups_are_added_and_subtracted()
	{
		Assert.True(DiceNotation.TryParse("2d6-1d4+3", out var parsed));
		var faces = new Queue<int>(new[] { 4, 5, 2 });
		var (dice, total) = DiceNotation.Roll(parsed, _ => faces.Dequeue());
		Assert.Equal(3, dice.Count);
		Assert.Equal(4 + 5 - 2 + 3, total);
	}

	[Fact]
	public void Rolls_stay_within_the_faces()
	{
		Assert.True(DiceNotation.TryParse("50d6", out var parsed));
		var (dice, total) = DiceNotation.Roll(parsed, sides => Random.Shared.Next(1, sides + 1));
		Assert.All(dice, d => Assert.InRange(d.Value, 1, 6));
		Assert.InRange(total, 50, 300);
	}

	[Fact]
	public void Session_and_roll_rules_follow_the_roles()
	{
		Assert.True(SessionRules.CanManageSessions(CampaignRole.CoMaster));
		Assert.False(SessionRules.CanManageSessions(CampaignRole.Player));
		Assert.False(SessionRules.CanSeeMasterNotes(CampaignRole.Player));
		Assert.False(SessionRules.CanRollHidden(CampaignRole.Player));
		Assert.True(SessionRules.CanSeeRoll(CampaignRole.Player, hidden: true, mine: true));
		Assert.False(SessionRules.CanSeeRoll(CampaignRole.Player, hidden: true, mine: false));
		Assert.True(SessionRules.CanSeeRoll(CampaignRole.CoMaster, hidden: true, mine: false));
		Assert.False(SessionRules.CanClearRolls(CampaignRole.CoMaster));
	}
}
