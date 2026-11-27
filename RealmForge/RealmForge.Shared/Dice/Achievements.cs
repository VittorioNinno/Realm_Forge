namespace RealmForge.Shared.Dice;

///	<summary>What an achievement counts.</summary>
public enum AchievementMeasure
{
	//	Rolls made at a table (any roll of the campaign's dice log)
	Rolls = 1,
	NaturalTwenties = 2,
	NaturalOnes = 3,
	//	Sessions marked as played in a campaign the person was in by then
	SessionsPlayed = 4,
	//	Sessions marked as played in a campaign the person runs (master or co-master)
	SessionsMastered = 5,
	//	Different months with a session played
	PlayedMonths = 6,
	Homebrew = 7,
	//	Maps created for a campaign (not copies)
	Maps = 8,
	//	The highest level among one's characters
	CharacterLevel = 9,
	//	The richest of one's characters, in gold pieces
	CharacterGold = 10,
	//	Once: a natural 1 followed right away by a natural 20 (one's own d20s)
	OneThenTwenty = 11,
	//	Once: two natural 20s at the same table within a sitting
	TwoTwentiesInASitting = 12,
	//	Once: a natural 20 between midnight and five in the morning, the person's own time
	TwentyAfterMidnight = 13
}

///	<summary>An achievement: the die it unlocks, what it counts and how far; hidden ones are not shown until earned.</summary>
public sealed record Achievement(string Key, string Skin, AchievementMeasure Measure, int Target, bool Hidden);

///	<summary>
///	The achievements of RealmForge: each one unlocks a die of its own. The three special dice have visible missions;
///	the secret dice have hidden missions, shown only once completed. An administrator can grant or revoke any of them.
///	</summary>
public static class Achievements
{
	///	<summary>How long a sitting lasts for "two natural 20s in the same session".</summary>
	public static readonly TimeSpan Sitting = TimeSpan.FromHours(6);

	///	<summary>The night of "after midnight": from 00:00 to 04:59 of the person's own clock.</summary>
	public const int NightEndsAtHour = 5;

	public static readonly IReadOnlyList<Achievement> All =
	[
		new("ember", DiceSkins.Ember, AchievementMeasure.Rolls, 100, false),
		new("stardust", DiceSkins.Stardust, AchievementMeasure.NaturalTwenties, 5, false),
		new("dawn", DiceSkins.Dawn, AchievementMeasure.SessionsPlayed, 1, false),
		new("frost", DiceSkins.Frost, AchievementMeasure.SessionsPlayed, 10, true),
		new("storm", DiceSkins.Storm, AchievementMeasure.TwoTwentiesInASitting, 1, true),
		new("bone", DiceSkins.Bone, AchievementMeasure.NaturalOnes, 13, true),
		new("hoard", DiceSkins.Hoard, AchievementMeasure.CharacterGold, 1000, true),
		new("abyss", DiceSkins.Abyss, AchievementMeasure.OneThenTwenty, 1, true),
		new("fey", DiceSkins.Fey, AchievementMeasure.CharacterLevel, 5, true),
		new("acid", DiceSkins.Acid, AchievementMeasure.Homebrew, 5, true),
		new("arcane", DiceSkins.Arcane, AchievementMeasure.SessionsMastered, 5, true),
		new("tide", DiceSkins.Tide, AchievementMeasure.Rolls, 1000, true),
		new("blood", DiceSkins.Blood, AchievementMeasure.TwentyAfterMidnight, 1, true),
		new("gear", DiceSkins.Gear, AchievementMeasure.Maps, 3, true),
		new("sands", DiceSkins.Sands, AchievementMeasure.PlayedMonths, 6, true)
	];

	public static Achievement? Find(string? key) => All.FirstOrDefault(a => a.Key == key);

	public static Achievement? OfSkin(string? skin) => All.FirstOrDefault(a => a.Skin == skin);

	///	<summary>A d20 roll's natural results, in order: the d20s kept (not the dropped one of advantage or disadvantage).</summary>
	public static IEnumerable<int> NaturalD20s(IEnumerable<(int Sides, int Value, bool Dropped)> dice) =>
		dice.Where(d => d.Sides == 20 && !d.Dropped).Select(d => d.Value);

	///	<summary>Whether a moment falls in the night after midnight on the person's own clock.</summary>
	public static bool AfterMidnight(DateTimeOffset at, TimeZoneInfo zone) =>
		TimeZoneInfo.ConvertTime(at, zone).Hour < NightEndsAtHour;
}
