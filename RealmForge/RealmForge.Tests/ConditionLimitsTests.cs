using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

public class ConditionLimitsTests
{
	[Theory]
	[InlineData("stunned")]
	[InlineData("paralyzed")]
	[InlineData("unconscious")]
	[InlineData("incapacitated")]
	public void These_conditions_stop_every_action(string key) =>
		Assert.Equal(key, ConditionLimits.ActionBlocker(new[] { "prone", key }));

	[Fact]
	public void Frightened_or_poisoned_do_not_stop_the_actions() =>
		Assert.Null(ConditionLimits.ActionBlocker(new[] { "frightened", "poisoned", "prone" }));

	[Fact]
	public void The_heaviest_reason_comes_first()
	{
		Assert.Equal("unconscious", ConditionLimits.MoveBlocker(new[] { "grappled", "unconscious" }));
		Assert.Equal("restrained", ConditionLimits.MoveBlocker(new[] { "prone", "restrained" }));
		Assert.Null(ConditionLimits.MoveBlocker(new[] { "prone", "frightened", "stunned" }));
		Assert.Null(ConditionLimits.MoveBlocker(null));
	}

	[Fact]
	public void The_limits_skip_what_stops_nothing_and_name_the_condition()
	{
		var limits = ConditionLimits.Limiting(new[] { "invisible", "frightened", "concentrating", "stunned" });
		Assert.Equal(new[] { "stunned", "frightened" }, limits);
		Assert.StartsWith("Spaventato: ", ConditionLimits.Line("frightened", true));
		Assert.StartsWith("Stunned:", ConditionLimits.NoActionText("stunned", false));
		Assert.StartsWith("Trattenuto:", ConditionLimits.NoMoveText("restrained", true));
	}
}
