using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;

namespace RealmForge.Tests;

public class EncounterSheetSyncTests
{
	private static EncounterCombatant Hero(CharacterSheetState sheet, int maxHp)
	{
		var c = new EncounterCombatant { Kind = CombatantKind.Character, CharacterId = Guid.NewGuid(), Name = "Eroe" };
		EncounterSheetSync.Show(c, sheet, maxHp, 15);
		return c;
	}

	[Fact]
	public void The_encounter_shows_the_sheet()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 5, TemporaryHitPoints = 2, Conditions = new() { "prone", "something" }, Exhaustion = 1, Concentration = Guid.NewGuid() };
		var c = Hero(sheet, 19);

		Assert.Equal((5, 19, 2, 15), (c.Hp, c.MaxHp, c.TempHp, c.ArmorClass));
		Assert.Equal(new[] { "prone", EncounterRules.Exhaustion, EncounterRules.Concentrating }, c.Conditions);
		Assert.Equal(5, c.SheetHp);

		//	A sheet at full health has no current value
		Assert.Equal(19, Hero(new CharacterSheetState(), 19).Hp);
	}

	[Fact]
	public void Damage_counts_from_the_sheet_as_it_is_now()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 10 };
		var c = Hero(sheet, 20);

		//	The player heals 5 on the sheet while the master deals 3 in the encounter
		sheet.CurrentHitPoints = 15;
		c.Hp -= 3;

		Assert.True(EncounterSheetSync.Apply(sheet, 20, c));
		Assert.Equal(12, sheet.CurrentHitPoints);
		Assert.Equal(1, sheet.VitalsStamp);
	}

	[Fact]
	public void Conditions_added_and_removed_go_to_the_sheet()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 8, Conditions = new() { "prone", "charmed" }, Concentration = Guid.NewGuid() };
		var c = Hero(sheet, 8);
		c.Conditions = new() { "charmed", "poisoned", EncounterRules.Exhaustion };

		Assert.True(EncounterSheetSync.Apply(sheet, 8, c));
		Assert.Equal(new[] { "charmed", "poisoned" }, sheet.Conditions);
		Assert.Equal(1, sheet.Exhaustion);
		Assert.Null(sheet.Concentration);
	}

	[Fact]
	public void Nothing_changed_leaves_the_sheet_alone()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 8 };
		var c = Hero(sheet, 10);
		Assert.False(EncounterSheetSync.Apply(sheet, 10, c));
		Assert.Equal(0, sheet.VitalsStamp);

		//	Added by hand, without the values of a sheet: nothing to compare with
		var added = new EncounterCombatant { Kind = CombatantKind.Character, Hp = 1 };
		Assert.False(EncounterSheetSync.Apply(sheet, 10, added));
	}

	[Fact]
	public void Healing_to_the_maximum_and_dropping_to_zero()
	{
		var sheet = new CharacterSheetState { CurrentHitPoints = 3, Concentration = Guid.NewGuid(), DeathSaveFailures = 1 };
		var c = Hero(sheet, 10);
		c.Hp = 0;
		EncounterSheetSync.Apply(sheet, 10, c);
		Assert.Equal(0, sheet.CurrentHitPoints);
		Assert.Null(sheet.Concentration);

		c = Hero(sheet, 10);
		c.Hp = 25;
		EncounterSheetSync.Apply(sheet, 10, c);
		Assert.Null(sheet.CurrentHitPoints);
		Assert.Equal(0, sheet.DeathSaveFailures);
	}
}
