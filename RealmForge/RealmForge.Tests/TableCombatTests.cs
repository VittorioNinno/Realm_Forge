using RealmForge.Shared.Campaigns;

namespace RealmForge.Tests;

public class TableCombatTests
{
	[Theory]
	[InlineData("Incantatore (cono di 18 metri)", "", ShapeKind.Cone, 12, 0, true)]
	[InlineData("Self (60-foot cone)", "", ShapeKind.Cone, 12, 0, true)]
	[InlineData("Incantatore (linea di 30 metri)", "", ShapeKind.Line, 20, 0, true)]
	[InlineData("Self (15-foot cube)", "", ShapeKind.Cube, 3, 0, true)]
	[InlineData("Incantatore (raggio di 9 metri)", "", ShapeKind.Sphere, 6, 0, true)]
	[InlineData("45 metri", "Ogni creatura in una sfera del raggio di 6 metri centrata su quel punto deve effettuare un tiro salvezza.", ShapeKind.Sphere, 4, 30, false)]
	[InlineData("150 feet", "Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw.", ShapeKind.Sphere, 4, 30, false)]
	[InlineData("18 metri", "Un cubo con spigolo di 6 metri appare in un punto entro gittata.", ShapeKind.Cube, 4, 12, false)]
	[InlineData("60 feet", "A 20-foot cube of fog.", ShapeKind.Cube, 4, 12, false)]
	[InlineData("Vista", "una sfera del raggio di 3 metri", ShapeKind.Sphere, 2, TableCombat.Unlimited, false)]
	public void Spell_areas_are_read_from_range_and_description(string range, string description, ShapeKind kind, int size, int reach, bool fromCaster)
	{
		var area = TableCombat.AreaOf(range, description);
		Assert.NotNull(area);
		Assert.Equal(kind, area!.Kind);
		Assert.Equal(size, area.Size);
		Assert.Equal(reach, area.Range);
		Assert.Equal(fromCaster, area.FromCaster);
	}

	[Theory]
	[InlineData("18 metri", "Una creatura entro gittata deve superare un tiro salvezza su Saggezza.")]
	[InlineData("Contatto", "Tocchi una creatura.")]
	[InlineData("Self", "")]
	public void Spells_without_an_area_have_none(string range, string description) =>
		Assert.Null(TableCombat.AreaOf(range, description));

	[Theory]
	[InlineData("*Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio.", 1, 0, 0)]
	[InlineData("*Melee Weapon Attack:* +6 to hit, reach 10 ft., one target.", 2, 0, 0)]
	[InlineData("*Attacco con arma a distanza:* +4 al tiro per colpire, gittata 24/96 m, un bersaglio.", 0, 16, 64)]
	[InlineData("*Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 20/60 ft., one target.", 1, 4, 12)]
	[InlineData("Il drago colpisce.", 1, 0, 0)]
	public void Statblock_attacks_have_their_reach(string text, int reach, int range, int longRange)
	{
		var r = TableCombat.OfStatblock(text);
		Assert.Equal(new AttackReach(reach, range, longRange), r);
	}

	[Fact]
	public void Weapon_reach_follows_its_properties()
	{
		Assert.Equal(new AttackReach(1, 0, 0), TableCombat.OfWeapon(false, false, false, null, null));
		Assert.Equal(new AttackReach(2, 0, 0), TableCombat.OfWeapon(false, true, false, null, null));
		Assert.Equal(new AttackReach(1, 4, 12), TableCombat.OfWeapon(false, false, true, 20, 60));
		Assert.Equal(new AttackReach(0, 30, 120), TableCombat.OfWeapon(true, false, false, 150, 600));
	}

	[Fact]
	public void Reach_tells_disadvantage_past_the_normal_range()
	{
		var bow = new AttackReach(0, 16, 64);
		Assert.Equal((true, false), bow.At(10));
		Assert.Equal((true, true), bow.At(40));
		Assert.Equal((false, false), bow.At(65));
		Assert.Equal((true, false), AttackReach.Melee.At(1));
		Assert.Equal((false, false), AttackReach.Melee.At(2));
	}

	[Theory]
	[InlineData(0, 0, 1, 1, 0, 1, 1)]
	[InlineData(0, 0, 1, 3, 3, 1, 3)]
	[InlineData(0, 0, 2, 2, 0, 1, 1)]
	[InlineData(0, 0, 2, 3, 1, 1, 2)]
	[InlineData(5, 5, 1, 2, 2, 2, 2)]
	public void Gap_counts_from_the_nearest_cells(int x1, int y1, int s1, int x2, int y2, int s2, int expected) =>
		Assert.Equal(expected, TableCombat.Gap(GridType.Square, x1, y1, s1, x2, y2, s2));

	[Fact]
	public void Conditions_change_the_attack_roll()
	{
		var none = Array.Empty<string>();
		Assert.Equal(-1, TableCombat.Effect(new[] { "poisoned" }, none, 1, false).Mode);
		Assert.Equal(1, TableCombat.Effect(none, new[] { "restrained" }, 1, false).Mode);
		Assert.Equal(1, TableCombat.Effect(none, new[] { "prone" }, 1, false).Mode);
		Assert.Equal(-1, TableCombat.Effect(none, new[] { "prone" }, 4, false).Mode);
		Assert.Equal(0, TableCombat.Effect(new[] { "poisoned" }, new[] { "stunned" }, 1, false).Mode);
		Assert.Equal(-1, TableCombat.Effect(none, none, 20, true).Mode);
		Assert.True(TableCombat.Effect(none, new[] { "unconscious" }, 1, false).AutoCritical);
		Assert.False(TableCombat.Effect(none, new[] { "unconscious" }, 3, false).AutoCritical);
	}

	[Theory]
	[InlineData("1d8 + 3", "2d8 + 3")]
	[InlineData("2d6", "4d6")]
	[InlineData("d10+1d4", "2d10+2d4")]
	public void Critical_doubles_the_dice(string expression, string critical) =>
		Assert.Equal(critical, TableCombat.Critical(expression));

	[Theory]
	[InlineData("*Melee Weapon Attack:* +4 to hit, reach 5 ft. *Hit:* 7 (1d8 + 3) slashing damage plus 3 (1d6) fire damage.", "1d8+3+1d6")]
	[InlineData("*Attacco con arma da mischia:* +4 al tiro per colpire. *Colpito:* 5 (1d6 + 2) danni perforanti.", "1d6+2")]
	[InlineData("*Melee Weapon Attack:* +2 to hit. *Hit:* 1 piercing damage.", "1")]
	[InlineData("It casts a spell.", null)]
	public void The_damage_of_an_attack_joins_every_group(string text, string? damage) =>
		Assert.Equal(damage, TableCombat.DamageOf(text));

	[Theory]
	[InlineData("*Hit:* 6 (1d8 + 2) bludgeoning damage, and the target is grappled (escape DC 12).", "grappled")]
	[InlineData("*Colpito:* 5 (1d6 + 2) danni perforanti e il bersaglio deve superare un TS o cadere prono.", "prone")]
	[InlineData("*Hit:* 4 (1d4 + 2) piercing damage plus 7 (2d6) poison damage.", null)]
	[InlineData("*Colpito:* 7 (2d6) danni da veleno e il bersaglio è avvelenato fino alla fine del suo turno.", "poisoned")]
	public void The_condition_of_an_attack_is_read_from_its_text(string text, string? condition) =>
		Assert.Equal(condition, TableCombat.ConditionOf(text));

	[Fact]
	public void A_spell_attack_is_read_with_its_reach_and_damage()
	{
		var bolt = TableCombat.TargetOf("120 feet", "Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage.", null, 0, 0, 5);
		Assert.NotNull(bolt);
		Assert.True(bolt!.Attack);
		Assert.False(bolt.Melee);
		Assert.Equal(24, bolt.Range);
		Assert.Equal("2d10", bolt.Damage);

		var grasp = TableCombat.TargetOf("Touch", "Make a melee spell attack against the target. On a hit, the target takes 1d8 lightning damage.", null, 0, 0, 1);
		Assert.True(grasp!.Melee);
		Assert.Equal(1, grasp.Range);
		Assert.Equal("1d8", grasp.Damage);
	}

	[Fact]
	public void A_saving_throw_spell_grows_with_the_slot()
	{
		var flame = TableCombat.TargetOf("60 feet", "The target must succeed on a Dexterity saving throw or take 1d8 radiant damage.", null, 0, 0, 11);
		Assert.False(flame!.Attack);
		Assert.Equal("Dexterity", flame.SaveAbility);
		Assert.Equal(12, flame.Range);
		Assert.Equal("3d8", flame.Damage);

		var bolt = TableCombat.TargetOf("120 feet", "Make a ranged spell attack against the target. On a hit, the target takes 4d6 radiant damage.",
			"The damage increases by 1d6 for each slot level above 1st.", 1, 3, 5);
		Assert.Equal("6d6", bolt!.Damage);

		var it = TableCombat.TargetOf("18 metri", "Il bersaglio deve effettuare un tiro salvezza su Saggezza o subire 2d8 danni psichici.", null, 1, 1, 3);
		Assert.Equal("Saggezza", it!.SaveAbility);
		Assert.Equal(12, it.Range);

		Assert.Null(TableCombat.TargetOf("Touch", "You touch a creature and it regains hit points.", null, 1, 1, 1));
	}
}
