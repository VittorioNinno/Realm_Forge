using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

public class ClassProgressionTableTests
{
	private const string Table = "Intro.\n\n| Livello | Bonus di competenza | Privilegi | 1° |\n|---|---|---|---|\n| 1° | +2 | Nemico Prescelto, Esploratore Nato | — |\n| 2° | +2 | Stile di Combattimento, Incantesimi | 2 |\n| 9° | +4 | — | 4 |";

	[Fact]
	public void The_features_of_a_class_level_are_read_from_the_table()
	{
		Assert.Equal(new[] { "Stile di Combattimento", "Incantesimi" }, ClassProgressionTable.FeaturesAt(Table, 2));
		Assert.Empty(ClassProgressionTable.FeaturesAt(Table, 9));
		Assert.Empty(ClassProgressionTable.FeaturesAt(Table, 5));
		Assert.Empty(ClassProgressionTable.FeaturesAt(null, 1));
	}
}
