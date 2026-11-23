namespace RealmForge.Shared.Campaigns;

///	<summary>
///	Factions and progress clocks of a campaign. A faction's standing goes from hostile (-3) to allied (+3) and moves
///	the prices of the shops tied to it; a progress clock (4, 6, 8 or 12 segments, as in Blades in the Dark) fills by
///	hand or with the game time.
///	</summary>
public static class FactionRules
{
	public const int Hostile = -3;
	public const int Allied = 3;
	public static readonly int[] Segments = { 4, 6, 8, 12 };

	//	The prices of a shop tied to a faction, as a percentage of its own: +50% for an enemy, -20% for an ally
	public static int PricePercent(int standing) => Math.Clamp(standing, Hostile, Allied) switch
	{
		-3 => 150,
		-2 => 125,
		-1 => 110,
		0 => 100,
		1 => 95,
		2 => 90,
		_ => 80
	};

	public static int Effective(int shopPercent, int? standing) =>
		standing is { } s ? (int)Math.Min(1000, Math.Round(shopPercent * (decimal)PricePercent(s) / 100m, MidpointRounding.AwayFromZero)) : shopPercent;

	//	The segments a clock that fills every few hours of game time gains when the time moves from one moment to another
	public static int Ticks(long from, long to, int hours) =>
		hours <= 0 || to <= from ? 0 : (int)Math.Min(int.MaxValue, to / (hours * 60L) - from / (hours * 60L));
}
