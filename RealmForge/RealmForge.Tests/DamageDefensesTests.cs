using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Tests;

public class DamageDefensesTests
{
	[Fact]
	public void A_statblock_is_read_with_its_nonmagical_clause()
	{
		var d = DamageDefenses.FromStatblock("radiant", "cold; bludgeoning, piercing, and slashing from nonmagical attacks", "poison");
		Assert.Equal((0, "immune"), d.Apply(10, DamageType.Poison, magical: false));
		Assert.Equal((5, "resist"), d.Apply(11, DamageType.Cold, magical: true));
		Assert.Equal((4, "resist"), d.Apply(9, DamageType.Slashing, magical: false));
		Assert.Equal((9, null), d.Apply(9, DamageType.Slashing, magical: true));
		Assert.Equal((14, "vulnerable"), d.Apply(7, DamageType.Radiant, magical: true));
		Assert.Equal((8, null), d.Apply(8, DamageType.Fire, magical: true));
	}

	[Fact]
	public void The_italian_lines_and_damage_types_are_read()
	{
		var d = DamageDefenses.FromStatblock("", "fuoco; contundenti, perforanti e taglienti da attacchi non magici", "veleno");
		Assert.Equal(DamageType.Slashing, DamageDefenses.TypeOf("taglienti"));
		Assert.Equal(DamageType.Fire, DamageDefenses.TypeOf("da fuoco"));
		Assert.Equal((3, "resist"), d.Apply(6, DamageDefenses.TypeOf("fuoco"), magical: true));
		Assert.Equal((0, "immune"), d.Apply(6, DamageDefenses.TypeOf("veleno"), magical: false));
		Assert.Equal((3, "resist"), d.Apply(6, DamageDefenses.TypeOf("perforanti"), magical: false));
	}

	[Fact]
	public void A_characters_defenses_round_trip()
	{
		var text = DamageDefenses.Write(new[] { DamageType.Fire, DamageType.Fire, DamageType.Cold }, new[] { DamageType.Poison });
		var d = DamageDefenses.Read(text);
		Assert.Equal((5, "resist"), d.Apply(10, DamageType.Fire, magical: true));
		Assert.Equal((0, "immune"), d.Apply(10, DamageType.Poison, magical: false));
		Assert.True(DamageDefenses.Read(null).IsEmpty);
	}
}
