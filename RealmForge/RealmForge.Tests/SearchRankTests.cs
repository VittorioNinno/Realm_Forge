using RealmForge.Shared.Text;

namespace RealmForge.Tests;

public class SearchRankTests
{
	[Theory]
	[InlineData("Paralizzato", "Paralizzato", 0)]
	[InlineData("paralizzato", "Paralizzato", 0)]
	[InlineData("Palla", "Palla di fuoco", 1)]
	[InlineData("fuoco", "Palla di fuoco", 2)]
	[InlineData("esploratore", "Sguardo dell'esploratore", 2)]
	[InlineData("uoco", "Palla di fuoco", 3)]
	[InlineData("Paralizzato", "Stordito", SearchRank.TextOnly)]
	public void Ranks_the_name_before_the_text(string term, string name, int rank) => Assert.Equal(rank, SearchRank.Of(term, name));

	[Fact]
	public void An_alias_counts_like_the_name()
	{
		Assert.Equal(0, SearchRank.Of("prone", "Prono", new[] { "=prone", "prona" }));
		Assert.Equal(0, SearchRank.Of(" ", "Qualsiasi"));
	}

	[Fact]
	public void The_named_entry_sorts_first_and_the_others_keep_their_order()
	{
		var entries = new[] { "Afferrato", "Incosciente", "Paralizzato", "Pietrificato" };
		var sorted = entries.OrderBy(e => SearchRank.Of("paralizzato", e)).ToList();
		Assert.Equal(new[] { "Paralizzato", "Afferrato", "Incosciente", "Pietrificato" }, sorted);
	}
}
