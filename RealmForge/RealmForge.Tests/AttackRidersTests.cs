using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

///	<summary>
///	Divine Smite: 2d8 with a 1st level slot, 1d8 more per level above it, at most 5d8, one more against undead and fiends.
///	</summary>
public class AttackRidersTests
{
	[Theory]
	[InlineData(1, false, "2d8")]
	[InlineData(2, false, "3d8")]
	[InlineData(4, false, "5d8")]
	[InlineData(6, false, "5d8")]
	[InlineData(1, true, "3d8")]
	[InlineData(5, true, "6d8")]
	public void Divine_smite_dice(int slot, bool undead, string dice) => Assert.Equal(dice, AttackRiders.SmiteDice(slot, undead));
}
