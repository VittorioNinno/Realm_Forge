using RealmForge.Shared.Text;

namespace RealmForge.Tests;

public class NicknamesTests
{
	[Theory]
	[InlineData("Sylas", true)]
	[InlineData("Elminster il Saggio", true)]
	[InlineData("Ser Àlvaro_2", true)]
	[InlineData("ab", false)]
	[InlineData(" leading", false)]
	[InlineData("-dash", false)]
	[InlineData("tag<script>", false)]
	[InlineData("a-very-long-nickname-over-24", false)]
	public void Valid_nicknames(string value, bool valid) => Assert.Equal(valid, Nicknames.IsValid(value));

	[Fact]
	public void Nicknames_are_cleaned_and_compared_without_case()
	{
		Assert.Equal("Sylas il Bardo", Nicknames.Clean("  Sylas   il  Bardo "));
		Assert.Null(Nicknames.Clean("   "));
		Assert.Equal(Nicknames.Normalize("Sylas"), Nicknames.Normalize("SYLAS"));
	}

	[Fact]
	public void Without_a_nickname_the_address_is_never_shown()
	{
		Assert.Equal("Sylas", Nicknames.Display("Sylas", "vittorio@example.com"));
		Assert.Equal("vi•••", Nicknames.Display(null, "vittorio@example.com"));
		Assert.DoesNotContain("@", Nicknames.Display(null, "a@example.com"));
	}
}
