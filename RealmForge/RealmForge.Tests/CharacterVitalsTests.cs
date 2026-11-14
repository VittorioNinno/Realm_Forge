using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

///	<summary>
///	A character's hit points wherever they change: down at 0 unconscious and prone, hits while down are failed death
///	saves, healing wakes the character; the cut cells on the edges of a map are cells too.
///	</summary>
public class CharacterVitalsTests
{
	[Fact]
	public void Dropping_to_zero_makes_the_character_unconscious_and_prone()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 5, TemporaryHitPoints = 2, Concentration = Guid.NewGuid() };
		var outcome = CharacterVitals.Damage(sheet, 13, 8, false, RulesetVersion.Dnd5e_2024);

		Assert.True(outcome.Dropped);
		Assert.Equal(0, sheet.CurrentHitPoints);
		Assert.Equal(0, sheet.TemporaryHitPoints);
		Assert.Null(sheet.Concentration);
		Assert.Contains("unconscious", sheet.Conditions);
		Assert.Contains("prone", sheet.Conditions);
	}

	[Fact]
	public void A_hit_while_down_fails_death_saves_and_healing_wakes()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 0 };
		CharacterVitals.Fall(sheet);
		Assert.True(CharacterVitals.Damage(sheet, 13, 3, true, null).HitWhileDown);
		Assert.Equal(2, sheet.DeathSaveFailures);

		CharacterVitals.Heal(sheet, 13, 4);
		Assert.Equal(4, sheet.CurrentHitPoints);
		Assert.DoesNotContain("unconscious", sheet.Conditions);
		Assert.Contains("prone", sheet.Conditions);
		Assert.Equal(0, sheet.DeathSaveFailures);
	}

	[Fact]
	public void Massive_damage_kills_and_a_natural_twenty_brings_back()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 5 };
		Assert.True(CharacterVitals.Damage(sheet, 10, 15, false, null).InstantDeath);
		Assert.Equal(3, sheet.DeathSaveFailures);

		var down = new CharacterSheetState { CurrentHitPoints = 0 };
		CharacterVitals.Fall(down);
		Assert.False(CharacterVitals.DeathSave(down, 10, 9).Success);
		Assert.Equal(1, down.DeathSaveFailures);
		Assert.True(CharacterVitals.DeathSave(down, 10, 12).Success);
		Assert.Equal(1, down.DeathSaveSuccesses);
		Assert.True(CharacterVitals.DeathSave(down, 10, 20).Twenty);
		Assert.Equal(1, down.CurrentHitPoints);
		Assert.Equal(0, down.DeathSaveFailures);
		Assert.DoesNotContain("unconscious", down.Conditions);
	}

	[Fact]
	public void The_cut_cells_on_the_edges_of_a_map_are_on_it()
	{
		//	A grid moved 30 px right and down: column and row -1 are 30 px wide, the last ones cut at the far edges
		Assert.True(MapGeometry.Inside(GridType.Square, 70, 30, 30, -1, -1, 1, 700, 490));
		Assert.True(MapGeometry.Inside(GridType.Square, 70, 30, 30, 9, 6, 1, 700, 490));
		Assert.False(MapGeometry.Inside(GridType.Square, 70, 30, 30, -2, 0, 1, 700, 490));
		Assert.False(MapGeometry.Inside(GridType.Square, 70, 0, 0, -1, 0, 1, 700, 490));
		Assert.Equal((-1, -1), MapGeometry.Nearest(GridType.Square, 70, 30, 30, 10, 10));
	}
}
