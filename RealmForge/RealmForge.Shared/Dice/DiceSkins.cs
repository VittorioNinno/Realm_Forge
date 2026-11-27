namespace RealmForge.Shared.Dice;

///	<summary>
///	The looks of the 3D dice. Resin (in any colour) is everyone's; every other die is unlocked by an achievement
///	(<see cref="Achievements"/>), or given by an administrator.
///	</summary>
public static class DiceSkins
{
	public const string Resin = "resin";
	public const string Ember = "ember";
	public const string Stardust = "stardust";
	public const string Frost = "frost";
	public const string Storm = "storm";
	public const string Bone = "bone";
	public const string Hoard = "hoard";
	public const string Abyss = "abyss";
	public const string Fey = "fey";
	public const string Acid = "acid";
	public const string Arcane = "arcane";
	public const string Dawn = "dawn";
	public const string Tide = "tide";
	public const string Blood = "blood";
	public const string Gear = "gear";
	public const string Sands = "sands";

	///	<summary>The special dice: shown locked until their (visible) mission is completed, in the order they are shown.</summary>
	public static readonly IReadOnlyList<string> Special = [Ember, Stardust, Dawn];

	///	<summary>The secret dice: shown nowhere until their hidden mission unlocks them (whoever finds one finds a new die).</summary>
	public static readonly IReadOnlyList<string> Secret = [Frost, Storm, Bone, Hoard, Abyss, Fey, Acid, Arcane, Tide, Blood, Gear, Sands];

	///	<summary>Every die an achievement unlocks.</summary>
	public static readonly IReadOnlyList<string> Unlockable = [.. Special, .. Secret];

	public static bool IsKnown(string? skin) => skin == Resin || Unlockable.Contains(skin);

	public static bool IsSecret(string? skin) => Secret.Contains(skin);
}
